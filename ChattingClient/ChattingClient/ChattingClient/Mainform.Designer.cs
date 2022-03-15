namespace ChattingClient
{
    partial class Mainform
    {
        /// <summary>
        /// 필수 디자이너 변수입니다.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// 사용 중인 모든 리소스를 정리합니다.
        /// </summary>
        /// <param name="disposing">관리되는 리소스를 삭제해야 하면 true이고, 그렇지 않으면 false입니다.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form 디자이너에서 생성한 코드

        /// <summary>
        /// 디자이너 지원에 필요한 메서드입니다. 
        /// 이 메서드의 내용을 코드 편집기로 수정하지 마세요.
        /// </summary>
        private void InitializeComponent()
        {
            this.rtb_send_Text = new System.Windows.Forms.RichTextBox();
            this.btn_data_send = new System.Windows.Forms.Button();
            this.label2 = new System.Windows.Forms.Label();
            this.label1 = new System.Windows.Forms.Label();
            this.rtb_text = new System.Windows.Forms.RichTextBox();
            this.tb_server_ip = new System.Windows.Forms.TextBox();
            this.label3 = new System.Windows.Forms.Label();
            this.tb_server_port = new System.Windows.Forms.TextBox();
            this.btn_server_connect = new System.Windows.Forms.Button();
            this.tb_userid = new System.Windows.Forms.TextBox();
            this.label4 = new System.Windows.Forms.Label();
            this.SuspendLayout();
            // 
            // rtb_send_Text
            // 
            this.rtb_send_Text.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.rtb_send_Text.Location = new System.Drawing.Point(10, 152);
            this.rtb_send_Text.Name = "rtb_send_Text";
            this.rtb_send_Text.Size = new System.Drawing.Size(226, 239);
            this.rtb_send_Text.TabIndex = 17;
            this.rtb_send_Text.Text = "";
            // 
            // btn_data_send
            // 
            this.btn_data_send.Location = new System.Drawing.Point(142, 397);
            this.btn_data_send.Name = "btn_data_send";
            this.btn_data_send.Size = new System.Drawing.Size(94, 33);
            this.btn_data_send.TabIndex = 14;
            this.btn_data_send.Text = "보내기";
            this.btn_data_send.UseVisualStyleBackColor = true;
            this.btn_data_send.Click += new System.EventHandler(this.btn_data_send_Click);
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(26, 35);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(84, 12);
            this.label2.TabIndex = 13;
            this.label2.Text = "접속할 서버 IP";
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(273, 16);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(57, 12);
            this.label1.TabIndex = 12;
            this.label1.Text = "채팅 내용";
            // 
            // rtb_text
            // 
            this.rtb_text.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.rtb_text.Location = new System.Drawing.Point(274, 32);
            this.rtb_text.Name = "rtb_text";
            this.rtb_text.ReadOnly = true;
            this.rtb_text.Size = new System.Drawing.Size(391, 398);
            this.rtb_text.TabIndex = 11;
            this.rtb_text.Text = "";
            // 
            // tb_server_ip
            // 
            this.tb_server_ip.Location = new System.Drawing.Point(136, 32);
            this.tb_server_ip.Name = "tb_server_ip";
            this.tb_server_ip.Size = new System.Drawing.Size(100, 21);
            this.tb_server_ip.TabIndex = 18;
            this.tb_server_ip.Text = "127.0.0.1";
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(14, 72);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(106, 12);
            this.label3.TabIndex = 19;
            this.label3.Text = "접속할 서버 PORT";
            // 
            // tb_server_port
            // 
            this.tb_server_port.Location = new System.Drawing.Point(136, 66);
            this.tb_server_port.Name = "tb_server_port";
            this.tb_server_port.Size = new System.Drawing.Size(100, 21);
            this.tb_server_port.TabIndex = 20;
            this.tb_server_port.Text = "12000";
            // 
            // btn_server_connect
            // 
            this.btn_server_connect.Location = new System.Drawing.Point(42, 397);
            this.btn_server_connect.Name = "btn_server_connect";
            this.btn_server_connect.Size = new System.Drawing.Size(94, 33);
            this.btn_server_connect.TabIndex = 21;
            this.btn_server_connect.Text = "서버 연결";
            this.btn_server_connect.UseVisualStyleBackColor = true;
            this.btn_server_connect.Click += new System.EventHandler(this.btn_server_connect_Click);
            // 
            // tb_userid
            // 
            this.tb_userid.Location = new System.Drawing.Point(136, 99);
            this.tb_userid.Name = "tb_userid";
            this.tb_userid.Size = new System.Drawing.Size(100, 21);
            this.tb_userid.TabIndex = 23;
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Location = new System.Drawing.Point(44, 103);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(44, 12);
            this.label4.TabIndex = 22;
            this.label4.Text = "접속 ID";
            // 
            // Mainform
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(7F, 12F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(695, 450);
            this.Controls.Add(this.tb_userid);
            this.Controls.Add(this.label4);
            this.Controls.Add(this.btn_server_connect);
            this.Controls.Add(this.tb_server_port);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.tb_server_ip);
            this.Controls.Add(this.rtb_send_Text);
            this.Controls.Add(this.btn_data_send);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.rtb_text);
            this.Name = "Mainform";
            this.Text = "채팅클라이언트_출처 : https://jeongkyun-it.tistory.com";
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.RichTextBox rtb_send_Text;
        private System.Windows.Forms.Button btn_data_send;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.RichTextBox rtb_text;
        private System.Windows.Forms.TextBox tb_server_ip;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.TextBox tb_server_port;
        private System.Windows.Forms.Button btn_server_connect;
        private System.Windows.Forms.TextBox tb_userid;
        private System.Windows.Forms.Label label4;
    }
}

