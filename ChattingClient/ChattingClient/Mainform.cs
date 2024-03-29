﻿using Newtonsoft.Json;
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

namespace ChattingClient
{
    public partial class Mainform : Form
    {
        string user_id = string.Empty;
        Socket client = null;
        Crypto crypto = new Crypto();
        bool _server_connect_status = false;


        public Mainform()
        {
            InitializeComponent();
        }

        private void serverConnect()
        {
            if (tb_userid.Text == "")
            {
                MessageBox.Show("사용자 ID를 입력 해 주세요");
                return;
            }

            user_id = tb_userid.Text;

            if (user_id.Trim().Length > 0)
            {
                try
                {
                    client = new Socket(AddressFamily.InterNetwork, SocketType.Stream, ProtocolType.Tcp);

                    client.Connect(IPAddress.Parse(tb_server_ip.Text), int.Parse(tb_server_port.Text));

                    JObject data = new JObject();

                    data.Add("type", "init");
                    data.Add("text", tb_userid.Text);

                    string make_data = JsonConvert.SerializeObject(data);

                    string send_text = crypto.AESEncrypt256(make_data, "1234567890123456");

                    byte[] byte_data = Encoding.UTF8.GetBytes(send_text);

                    client.Send(byte_data);
                    SocketAsyncEventArgs receiveAsync = new SocketAsyncEventArgs();
                    receiveAsync.Completed += new EventHandler<SocketAsyncEventArgs>(receiveAsync_Completed);
                    receiveAsync.SetBuffer(new byte[4], 0, 4);
                    receiveAsync.UserToken = client;
                    client.ReceiveAsync(receiveAsync);
                }
                catch (SocketException ex)
                {
                    MessageBox.Show(ex.Message);
                }
                finally
                {
                    rtb_text.AppendText("\r\n");
                    rtb_text.AppendText("===== Server 연결 성공 !! =====");
                    btn_server_connect.Text = "연결 종료";
                    _server_connect_status = true;
                }
            }
        }

        private void serverClose()
        {

            try
            {
                string msg = crypto.AESEncrypt256(tb_userid.Text, "1234567890123456");
                byte[] data = Encoding.UTF8.GetBytes(msg);
                client.Send(BitConverter.GetBytes(data.Length));

                //Send(msg, "all");
            }
            catch (Exception ex) { }

            try
            {
                if (client != null)
                {
                    client.Shutdown(SocketShutdown.Send);
                    client.Close();
                    client = null;
                }
                rtb_text.AppendText("\r\n");
                rtb_text.AppendText("===== Server 연결 종료 .. =====");
                btn_server_connect.Text = "서버 연결";
                _server_connect_status = false;
            }
            catch (SocketException ex)
            {
                MessageBox.Show(ex.Message);
            }

        }


        /// <summary>
        /// 서버 연결 버튼
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void btn_server_connect_Click(object sender, EventArgs e)
        {
            // false : 서버 연결 안되어있음
            // true : 서버 연결 되어있음
            if (!_server_connect_status)
            {
                serverConnect();
            }
            else
            {
                serverClose();
            }

        }

        private void receiveAsync_Completed(object sender, SocketAsyncEventArgs e)
        {
            try
            {

                Socket client = (Socket)sender;
                if (client.Connected && e.BytesTransferred > 0)
                {
                    byte[] lengthByte = e.Buffer;
                    int length = BitConverter.ToInt32(lengthByte, 0);
                    byte[] data = new byte[length];
                    client.Receive(data, length, SocketFlags.None);

                    string str_data = Encoding.UTF8.GetString(data);
                    str_data = crypto.AESDecrypt256(str_data, "1234567890123456");

                    StringBuilder sb = new StringBuilder();
                    sb.Append("\r\n");
                    sb.Append("server");
                    sb.Append("  -  ");
                    sb.Append(str_data);
                    sb.AppendLine();

                    Invoke((MethodInvoker)delegate
                    {
                        rtb_text.AppendText(sb.ToString());
                    });
                    client.ReceiveAsync(e);
                }
            }
            catch (Exception ex) { MessageBox.Show(ex.Message); }

        }

        /// <summary>
        /// 데이터 보내기
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void btn_data_send_Click(object sender, EventArgs e)
        {

            if (client == null || client.Connected == false)
            {
                MessageBox.Show("서버 접속이 필요합니다.");
                return;
            }

            try
            {

                JObject data = new JObject();

                data.Add("userID", tb_userid.Text);
                data.Add("type", "op");
                data.Add("text", rtb_send_Text.Text);

                string make_data = JsonConvert.SerializeObject(data);

                byte[] send_text = Encoding.UTF8.GetBytes(crypto.AESEncrypt256(make_data, "1234567890123456"));

                client.Send(send_text);
            }
            catch (SocketException ex)
            {
                MessageBox.Show(ex.Message);
            }

        }

    }
}
