using Newtonsoft.Json.Linq;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Net;
using System.Net.Sockets;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace ChattingServer
{
    public partial class Mainform : Form
    {
        Dictionary<string, Socket> dic_client = null;
        List<Socket> listSock = null;
        List<String> listUser = null;
        Crypto crypto = null;
        public Mainform()
        {
            InitializeComponent();
            init();
            serverOpen();
        }

        /// <summary>
        /// 변수 초기화
        /// </summary>
        private void init()
        {
            dic_client = new Dictionary<string, Socket>();
            listSock = new List<Socket>();
            listUser = new List<String>();
            crypto = new Crypto();

            rtb_text.AppendText("Server Listening ...");
            rtb_text.AppendText("\r\n");
        }

        /// <summary>
        /// 서버 Open
        /// </summary>
        private void serverOpen()
        {
            Socket server = new Socket(AddressFamily.InterNetwork, SocketType.Stream, ProtocolType.Tcp);
            server.Bind(new IPEndPoint(IPAddress.Any, 12000));
            server.Listen(10);

            SocketAsyncEventArgs sockAsync = new SocketAsyncEventArgs();
            sockAsync.Completed += new EventHandler<SocketAsyncEventArgs>(sockAsync_Completed);
            server.AcceptAsync(sockAsync);
        }

        /// <summary>
        /// 연결 될 시 발생되는 이벤트
        /// </summary>
        /// <param name="sender">이벤트 발생시킨 소켓 </param>
        /// <param name="e"></param>
        private void sockAsync_Completed(object sender, SocketAsyncEventArgs e)
        {
            try
            {

                Socket server = (Socket)sender;
                Socket client = e.AcceptSocket;
                byte[] name = new byte[100];
                client.Receive(name);

                String str_data = Encoding.UTF8.GetString(name).Trim().Replace("\0", "");

                str_data = crypto.AESDecrypt256(str_data, "1234567890123456");

                JObject jobj = JObject.Parse(str_data);

                string user = jobj["text"].ToString();

                dic_client.Add(user, client);
                SocketAsyncEventArgs receiveAsync = new SocketAsyncEventArgs();
                receiveAsync.Completed += new EventHandler<SocketAsyncEventArgs>(receiveAsync_Completed);
                receiveAsync.SetBuffer(new byte[4096], 0, 4096);
                receiveAsync.UserToken = client;
                client.ReceiveAsync(receiveAsync);

                StringBuilder sb = new StringBuilder();
                sb.Append(user + " - Connected ");
                sb.AppendLine();

                Invoke((MethodInvoker)delegate
                {
                    rtb_text.AppendText(sb.ToString());
                    lb_client_list.Items.Add(user);
                });

                e.AcceptSocket = null;
                server.AcceptAsync(e);
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }

        }

        /// <summary>
        /// 응답이 올 경우 발생하는 이벤트
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void receiveAsync_Completed(object sender, SocketAsyncEventArgs e)
        {

            Socket client = (Socket)sender;
            String Name = string.Empty;

            if (client.Connected && e.BytesTransferred > 0)
            {
                int length = e.Buffer.Length;
                byte[] data = new byte[length];

                client.Receive(data, length, SocketFlags.None);
                String str_data = Encoding.UTF8.GetString(data).Replace("\0", "");

                if (str_data == "")
                    return;

                str_data = crypto.AESDecrypt256(str_data, "1234567890123456");
                JObject jobj = JObject.Parse(str_data);

                if (searchSocket(client) == "")
                {
                    MessageBox.Show("접속 클라이언트를 찾을 수 없습니다.");
                    return;
                }
                else
                    Name = searchSocket(client);


                StringBuilder sb = new StringBuilder();
                sb.AppendLine("[" + Name + "]" + " -----> "+jobj["text"].ToString());                

                Invoke((MethodInvoker)delegate
                {
                    rtb_text.AppendText(sb.ToString());
                });

                client.ReceiveAsync(e);

            }
        }

        private String searchSocket(Socket sender)
        {
            foreach (String key in dic_client.Keys)
            {
                if (dic_client[key] == sender)
                {
                    return key;
                }
            }

            return string.Empty;
        }

        private void Send(string text, string flag)
        {

            int sel_idx = lb_client_list.SelectedIndex;

            if (sel_idx == -1)
                sel_idx = 0;

            String sender = lb_client_list.Items[sel_idx].ToString();
            String message = text;

            //전체보내기
            if (flag == "all")
            {
                try
                {
                    for (int i = 0; i < lb_client_list.Items.Count; i++)
                    {
                        listUser.Add(lb_client_list.Items[i].ToString());
                    }

                    for (int i = 0; i < listUser.Count; i++)
                    {
                        listSock.Add(dic_client[listUser[i]]);
                    }

                    for (int i = 0; i < listSock.Count; i++)
                    {
                        byte[] data = Encoding.UTF8.GetBytes(message);
                        listSock[i].Send(BitConverter.GetBytes(data.Length));
                        listSock[i].Send(data, data.Length, SocketFlags.None);
                    }
                    listSock.Clear();
                    listUser.Clear();
                }
                catch (Exception ex) { MessageBox.Show("Send Error : " + ex.Message); }
            }
            //특정 클라이언트에게 보내기
            else
            {
                try
                {
                    if (dic_client.ContainsKey(sender))
                    {
                        Socket client = dic_client[sender];
                        byte[] data = Encoding.UTF8.GetBytes(message);
                        client.Send(BitConverter.GetBytes(data.Length));
                        client.Send(data, data.Length, SocketFlags.None);
                    }
                    else
                    {
                        MessageBox.Show("소켓을 찾지 못했습니다");
                    }
                }
                catch (Exception ex)
                {
                    MessageBox.Show("Send Error : " + ex.Message);
                }
            }

        }


        /// <summary>
        /// 특정 클라이언트에게 메세지 보내기
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void btn_data_send_Click(object sender, EventArgs e)
        {
            if (lb_client_list.Items.Count == 0)
            {
                MessageBox.Show("보낼 클라이언트가 없습니다.");
                return;
            }

            if (rtb_send_Text.Text == "")
            {
                MessageBox.Show("보낼 메세지를 입력해주세요.");
                return;
            }

            string msg = crypto.AESEncrypt256(rtb_send_Text.Text, "1234567890123456");

            Send(msg, "one");
        }

        /// <summary>
        /// 모든 클라이언트에게 보내기
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void btn_data_send_all_Click(object sender, EventArgs e)
        {
            if (lb_client_list.Items.Count == 0)
            {
                MessageBox.Show("보낼 클라이언트가 없습니다.");
                return;
            }

            if (rtb_send_Text.Text == "")
            {
                MessageBox.Show("보낼 메세지를 입력해주세요.");
                return;
            }

            string msg = crypto.AESEncrypt256(rtb_send_Text.Text, "1234567890123456");

            Send(msg, "all");
        }
    }
}
