namespace WFADemo01
{
    partial class Server
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
            this.richTextContent = new System.Windows.Forms.RichTextBox();
            this.richTextList = new System.Windows.Forms.RichTextBox();
            this.label1 = new System.Windows.Forms.Label();
            this.btn_server = new System.Windows.Forms.Button();
            this.btn_selectFile = new System.Windows.Forms.Button();
            this.textBox_filelocation = new System.Windows.Forms.TextBox();
            this.SuspendLayout();
            // 
            // richTextContent
            // 
            this.richTextContent.Location = new System.Drawing.Point(165, 106);
            this.richTextContent.Name = "richTextContent";
            this.richTextContent.Size = new System.Drawing.Size(436, 204);
            this.richTextContent.TabIndex = 11;
            this.richTextContent.Text = "";
            // 
            // richTextList
            // 
            this.richTextList.Location = new System.Drawing.Point(29, 106);
            this.richTextList.Name = "richTextList";
            this.richTextList.Size = new System.Drawing.Size(130, 204);
            this.richTextList.TabIndex = 10;
            this.richTextList.Text = "";
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(35, 62);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(59, 12);
            this.label1.TabIndex = 8;
            this.label1.Text = "选择文件:";
            // 
            // btn_server
            // 
            this.btn_server.Location = new System.Drawing.Point(496, 57);
            this.btn_server.Name = "btn_server";
            this.btn_server.Size = new System.Drawing.Size(75, 23);
            this.btn_server.TabIndex = 7;
            this.btn_server.Text = "启动服务";
            this.btn_server.UseVisualStyleBackColor = true;
            this.btn_server.Click += new System.EventHandler(this.btn_server_Click);
            // 
            // btn_selectFile
            // 
            this.btn_selectFile.Location = new System.Drawing.Point(367, 56);
            this.btn_selectFile.Name = "btn_selectFile";
            this.btn_selectFile.Size = new System.Drawing.Size(75, 23);
            this.btn_selectFile.TabIndex = 13;
            this.btn_selectFile.Text = "选择文件";
            this.btn_selectFile.UseVisualStyleBackColor = true;
            this.btn_selectFile.Click += new System.EventHandler(this.btn_selectFile_Click);
            // 
            // textBox_filelocation
            // 
            this.textBox_filelocation.Location = new System.Drawing.Point(121, 56);
            this.textBox_filelocation.Name = "textBox_filelocation";
            this.textBox_filelocation.ReadOnly = true;
            this.textBox_filelocation.Size = new System.Drawing.Size(208, 21);
            this.textBox_filelocation.TabIndex = 14;
            // 
            // Server
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 12F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(630, 367);
            this.Controls.Add(this.textBox_filelocation);
            this.Controls.Add(this.btn_selectFile);
            this.Controls.Add(this.richTextContent);
            this.Controls.Add(this.richTextList);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.btn_server);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle;
            this.Name = "Server";
            this.Text = "Server";
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.RichTextBox richTextContent;
        private System.Windows.Forms.RichTextBox richTextList;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Button btn_server;
        private System.Windows.Forms.Button btn_selectFile;
        private System.Windows.Forms.TextBox textBox_filelocation;
    }
}