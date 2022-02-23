namespace ChattingServer
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
            this.rtb_text = new System.Windows.Forms.RichTextBox();
            this.label1 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.btn_data_send = new System.Windows.Forms.Button();
            this.btn_data_send_all = new System.Windows.Forms.Button();
            this.label3 = new System.Windows.Forms.Label();
            this.rtb_send_Text = new System.Windows.Forms.RichTextBox();
            this.lb_client_list = new System.Windows.Forms.ListBox();
            this.SuspendLayout();
            // 
            // rtb_text
            // 
            this.rtb_text.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.rtb_text.Location = new System.Drawing.Point(276, 36);
            this.rtb_text.Name = "rtb_text";
            this.rtb_text.ReadOnly = true;
            this.rtb_text.Size = new System.Drawing.Size(391, 398);
            this.rtb_text.TabIndex = 1;
            this.rtb_text.Text = "";
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(275, 20);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(57, 12);
            this.label1.TabIndex = 2;
            this.label1.Text = "채팅 내용";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(12, 20);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(145, 12);
            this.label2.TabIndex = 3;
            this.label2.Text = "접속한 클라이언트 리스트";
            // 
            // btn_data_send
            // 
            this.btn_data_send.Location = new System.Drawing.Point(40, 401);
            this.btn_data_send.Name = "btn_data_send";
            this.btn_data_send.Size = new System.Drawing.Size(94, 33);
            this.btn_data_send.TabIndex = 5;
            this.btn_data_send.Text = "보내기";
            this.btn_data_send.UseVisualStyleBackColor = true;
            this.btn_data_send.Click += new System.EventHandler(this.btn_data_send_Click);
            // 
            // btn_data_send_all
            // 
            this.btn_data_send_all.Location = new System.Drawing.Point(144, 401);
            this.btn_data_send_all.Name = "btn_data_send_all";
            this.btn_data_send_all.Size = new System.Drawing.Size(94, 33);
            this.btn_data_send_all.TabIndex = 6;
            this.btn_data_send_all.Text = "전체 보내기";
            this.btn_data_send_all.UseVisualStyleBackColor = true;
            this.btn_data_send_all.Click += new System.EventHandler(this.btn_data_send_all_Click);
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(12, 273);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(57, 12);
            this.label3.TabIndex = 9;
            this.label3.Text = "보낼 내용";
            // 
            // rtb_send_Text
            // 
            this.rtb_send_Text.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.rtb_send_Text.Location = new System.Drawing.Point(12, 288);
            this.rtb_send_Text.Name = "rtb_send_Text";
            this.rtb_send_Text.Size = new System.Drawing.Size(226, 107);
            this.rtb_send_Text.TabIndex = 10;
            this.rtb_send_Text.Text = "";
            // 
            // lb_client_list
            // 
            this.lb_client_list.FormattingEnabled = true;
            this.lb_client_list.ItemHeight = 12;
            this.lb_client_list.Location = new System.Drawing.Point(14, 47);
            this.lb_client_list.Name = "lb_client_list";
            this.lb_client_list.Size = new System.Drawing.Size(224, 208);
            this.lb_client_list.TabIndex = 11;
            // 
            // Mainform
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(7F, 12F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(684, 450);
            this.Controls.Add(this.lb_client_list);
            this.Controls.Add(this.rtb_send_Text);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.btn_data_send_all);
            this.Controls.Add(this.btn_data_send);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.rtb_text);
            this.Name = "Mainform";
            this.Text = "채팅서버_출처 : https://jeongkyun-it.tistory.com";
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.RichTextBox rtb_text;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Button btn_data_send;
        private System.Windows.Forms.Button btn_data_send_all;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.RichTextBox rtb_send_Text;
        private System.Windows.Forms.ListBox lb_client_list;
    }
}

