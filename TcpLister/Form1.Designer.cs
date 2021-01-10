
namespace TcpLister
{
    partial class Form1
    {
        /// <summary>
        /// 必需的设计器变量。
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// 清理所有正在使用的资源。
        /// </summary>
        /// <param name="disposing">如果应释放托管资源，为 true；否则为 false。</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows 窗体设计器生成的代码

        /// <summary>
        /// 设计器支持所需的方法 - 不要修改
        /// 使用代码编辑器修改此方法的内容。
        /// </summary>
        private void InitializeComponent()
        {
            this.label1 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.button1 = new System.Windows.Forms.Button();
            this.richListTextBox = new System.Windows.Forms.RichTextBox();
            this.richMainTextBox = new System.Windows.Forms.RichTextBox();
            this.ipTextBox = new System.Windows.Forms.TextBox();
            this.portTextBox = new System.Windows.Forms.TextBox();
            this.btn_upload = new System.Windows.Forms.Button();
            this.label3 = new System.Windows.Forms.Label();
            this.filePathText = new System.Windows.Forms.TextBox();
            this.openFileDialog1 = new System.Windows.Forms.OpenFileDialog();
            this.SuspendLayout();
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Enabled = false;
            this.label1.Location = new System.Drawing.Point(65, 47);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(28, 14);
            this.label1.TabIndex = 0;
            this.label1.Text = "ip:";
            this.label1.Visible = false;
            this.label1.Click += new System.EventHandler(this.label1_Click);
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Enabled = false;
            this.label2.Location = new System.Drawing.Point(338, 47);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(42, 14);
            this.label2.TabIndex = 1;
            this.label2.Text = "port:";
            this.label2.Visible = false;
            this.label2.Click += new System.EventHandler(this.label2_Click);
            // 
            // button1
            // 
            this.button1.Location = new System.Drawing.Point(610, 38);
            this.button1.Name = "button1";
            this.button1.Size = new System.Drawing.Size(75, 23);
            this.button1.TabIndex = 2;
            this.button1.Text = "启动服务";
            this.button1.UseVisualStyleBackColor = true;
            this.button1.Click += new System.EventHandler(this.button1_Click);
            // 
            // richListTextBox
            // 
            this.richListTextBox.Location = new System.Drawing.Point(67, 88);
            this.richListTextBox.Name = "richListTextBox";
            this.richListTextBox.Size = new System.Drawing.Size(180, 317);
            this.richListTextBox.TabIndex = 3;
            this.richListTextBox.Text = "";
            this.richListTextBox.TextChanged += new System.EventHandler(this.richListTextBox_TextChanged);
            // 
            // richMainTextBox
            // 
            this.richMainTextBox.Location = new System.Drawing.Point(266, 88);
            this.richMainTextBox.Name = "richMainTextBox";
            this.richMainTextBox.Size = new System.Drawing.Size(488, 317);
            this.richMainTextBox.TabIndex = 4;
            this.richMainTextBox.Text = "";
            this.richMainTextBox.TextChanged += new System.EventHandler(this.richMainTextBox_TextChanged);
            // 
            // ipTextBox
            // 
            this.ipTextBox.Enabled = false;
            this.ipTextBox.Location = new System.Drawing.Point(135, 45);
            this.ipTextBox.Name = "ipTextBox";
            this.ipTextBox.Size = new System.Drawing.Size(198, 23);
            this.ipTextBox.TabIndex = 5;
            this.ipTextBox.Visible = false;
            this.ipTextBox.TextChanged += new System.EventHandler(this.ipTextBox_TextChanged);
            // 
            // portTextBox
            // 
            this.portTextBox.Enabled = false;
            this.portTextBox.Location = new System.Drawing.Point(413, 44);
            this.portTextBox.Name = "portTextBox";
            this.portTextBox.Size = new System.Drawing.Size(144, 23);
            this.portTextBox.TabIndex = 6;
            this.portTextBox.Visible = false;
            this.portTextBox.TextChanged += new System.EventHandler(this.portTextBox_TextChanged);
            // 
            // btn_upload
            // 
            this.btn_upload.Location = new System.Drawing.Point(610, 8);
            this.btn_upload.Name = "btn_upload";
            this.btn_upload.Size = new System.Drawing.Size(75, 23);
            this.btn_upload.TabIndex = 7;
            this.btn_upload.Text = "文件上传";
            this.btn_upload.UseVisualStyleBackColor = true;
            this.btn_upload.Click += new System.EventHandler(this.btn_upload_Click);
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(65, 9);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(70, 14);
            this.label3.TabIndex = 8;
            this.label3.Text = "文件路径:";
            // 
            // filePathText
            // 
            this.filePathText.Location = new System.Drawing.Point(134, 9);
            this.filePathText.Name = "filePathText";
            this.filePathText.Size = new System.Drawing.Size(426, 23);
            this.filePathText.TabIndex = 9;
            // 
            // openFileDialog1
            // 
            this.openFileDialog1.FileName = "openFileDialog1";
            // 
            // Form1
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(7F, 14F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(800, 450);
            this.Controls.Add(this.filePathText);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.btn_upload);
            this.Controls.Add(this.portTextBox);
            this.Controls.Add(this.ipTextBox);
            this.Controls.Add(this.richMainTextBox);
            this.Controls.Add(this.richListTextBox);
            this.Controls.Add(this.button1);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.label1);
            this.Name = "Form1";
            this.Text = "服务端";
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Button button1;
        private System.Windows.Forms.RichTextBox richListTextBox;
        private System.Windows.Forms.RichTextBox richMainTextBox;
        private System.Windows.Forms.TextBox ipTextBox;
        private System.Windows.Forms.TextBox portTextBox;
        private System.Windows.Forms.Button btn_upload;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.TextBox filePathText;
        private System.Windows.Forms.OpenFileDialog openFileDialog1;
    }
}

