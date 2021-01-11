namespace WFADemo01
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
            this.btn_clientForm = new System.Windows.Forms.Button();
            this.btn_ServerForm = new System.Windows.Forms.Button();
            this.label1 = new System.Windows.Forms.Label();
            this.SuspendLayout();
            // 
            // btn_clientForm
            // 
            this.btn_clientForm.Location = new System.Drawing.Point(113, 71);
            this.btn_clientForm.Name = "btn_clientForm";
            this.btn_clientForm.Size = new System.Drawing.Size(75, 23);
            this.btn_clientForm.TabIndex = 0;
            this.btn_clientForm.Text = "客户端";
            this.btn_clientForm.UseVisualStyleBackColor = true;
            this.btn_clientForm.Click += new System.EventHandler(this.btn_clientForm_Click);
            // 
            // btn_ServerForm
            // 
            this.btn_ServerForm.Location = new System.Drawing.Point(266, 71);
            this.btn_ServerForm.Name = "btn_ServerForm";
            this.btn_ServerForm.Size = new System.Drawing.Size(75, 23);
            this.btn_ServerForm.TabIndex = 1;
            this.btn_ServerForm.Text = "服务端";
            this.btn_ServerForm.UseVisualStyleBackColor = true;
            this.btn_ServerForm.Click += new System.EventHandler(this.btn_ServerForm_Click);
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(165, 33);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(101, 12);
            this.label1.TabIndex = 2;
            this.label1.Text = "文件传输工具v1.0";
            // 
            // Form1
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 12F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(458, 161);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.btn_ServerForm);
            this.Controls.Add(this.btn_clientForm);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle;
            this.Name = "Form1";
            this.Text = "文件传输组件";
            this.Load += new System.EventHandler(this.Form1_Load);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Button btn_clientForm;
        private System.Windows.Forms.Button btn_ServerForm;
        private System.Windows.Forms.Label label1;
    }
}

