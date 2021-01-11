namespace WFADemo01
{
    partial class Client
    {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            this.btn_client = new System.Windows.Forms.Button();
            this.label1 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.richTextList = new System.Windows.Forms.RichTextBox();
            this.richTextContent = new System.Windows.Forms.RichTextBox();
            this.textBoxIP = new System.Windows.Forms.TextBox();
            this.textBoxPort = new System.Windows.Forms.TextBox();
            this.SuspendLayout();
            // 
            // btn_client
            // 
            this.btn_client.Location = new System.Drawing.Point(453, 56);
            this.btn_client.Name = "btn_client";
            this.btn_client.Size = new System.Drawing.Size(75, 23);
            this.btn_client.TabIndex = 0;
            this.btn_client.Text = "链接服务器";
            this.btn_client.UseVisualStyleBackColor = true;
            this.btn_client.Click += new System.EventHandler(this.btn_client_Click);
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(76, 61);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(23, 12);
            this.label1.TabIndex = 1;
            this.label1.Text = "ip:";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(260, 61);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(35, 12);
            this.label2.TabIndex = 2;
            this.label2.Text = "port:";
            // 
            // richTextList
            // 
            this.richTextList.Location = new System.Drawing.Point(52, 105);
            this.richTextList.Name = "richTextList";
            this.richTextList.Size = new System.Drawing.Size(130, 204);
            this.richTextList.TabIndex = 3;
            this.richTextList.Text = "";
            // 
            // richTextContent
            // 
            this.richTextContent.Location = new System.Drawing.Point(188, 105);
            this.richTextContent.Name = "richTextContent";
            this.richTextContent.Size = new System.Drawing.Size(436, 204);
            this.richTextContent.TabIndex = 4;
            this.richTextContent.Text = "";
            // 
            // textBoxIP
            // 
            this.textBoxIP.Location = new System.Drawing.Point(123, 56);
            this.textBoxIP.Name = "textBoxIP";
            this.textBoxIP.Size = new System.Drawing.Size(120, 21);
            this.textBoxIP.TabIndex = 5;
            // 
            // textBoxPort
            // 
            this.textBoxPort.Location = new System.Drawing.Point(305, 58);
            this.textBoxPort.Name = "textBoxPort";
            this.textBoxPort.Size = new System.Drawing.Size(120, 21);
            this.textBoxPort.TabIndex = 6;
            // 
            // Client
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 12F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(659, 382);
            this.Controls.Add(this.textBoxPort);
            this.Controls.Add(this.textBoxIP);
            this.Controls.Add(this.richTextContent);
            this.Controls.Add(this.richTextList);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.btn_client);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle;
            this.Name = "Client";
            this.Text = "Client";
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Button btn_client;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.RichTextBox richTextList;
        private System.Windows.Forms.RichTextBox richTextContent;
        private System.Windows.Forms.TextBox textBoxIP;
        private System.Windows.Forms.TextBox textBoxPort;
    }
}