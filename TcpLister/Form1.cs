using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Net;
using System.Net.Sockets;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace TcpLister
{
    public partial class Form1 : Form
    {
        /// <summary>
        /// 定义一个接受消息的相关的委托类
        /// </summary>
        /// <param name="txtValue"></param>
        public delegate void TxtReceiveAddContentEventHandler(string txtValue);
        public Form1()
        {
            InitializeComponent();
        }

        TcpListener listener;
        public static String filePathTemp = "";
        public static Thread th;
        public static Boolean isReSend = false;


        public void TxtAddContent(String txtValue) {
            if (richMainTextBox.InvokeRequired)
            {
                TxtReceiveAddContentEventHandler addContent = TxtAddContent;
                richMainTextBox.Invoke(addContent, new object[] { txtValue });

            }
            else
            {
                richMainTextBox.Text = txtValue + "\r\n" + richMainTextBox.Text;
            }
        }




        /// <summary>
        /// 服务器确认的内容分发机器
        /// </summary>
        /// <param name="txtValue"></param>
        public delegate void TxtServerIpListContentEventHandler(string txtValue);
        public void TxtServerIpListContent(string txtValue)
        {
            if (richListTextBox.InvokeRequired)
            {
                TxtServerIpListContentEventHandler addContent = TxtServerIpListContent;
                richListTextBox.Invoke(addContent, new object[] { txtValue });
            }
            else
            {
                richListTextBox.Text = txtValue + "\r\n" + richListTextBox.Text;
            }
        }

        #region 服务器启动监听服务，并开始接收文件
        private void button1_Click(object sender, EventArgs e)
        {
            button1.Enabled = false;
            // listener = new TcpListener(IPAddress.Parse(ipTextBox.Text), int.Parse(portTextBox.Text));
            listener = new TcpListener(IPAddress.Any, 18001);
            listener.Start();
            richMainTextBox.Text = "服务器开始监听....";
            SendFileCenter();
        }


        private  void SendFileCenter() {

            if (th == null)
            {
                th = new Thread(SendFileFunc);
                th.Start(listener);
                th.IsBackground = true;
            }
            //else {
            //    Thread th1 = new Thread(SendFileFunc);
            //    th1.Start(listener);
            //    th1.IsBackground = true;

            //}
           

        }

   
        //统一对话框
        private bool InitialDialog(FileDialog fileDialog, string title)
        {

            fileDialog.Title = title;
            fileDialog.InitialDirectory = @"C:\\";//设置文件打开初始目录为E盘
            fileDialog.Title = "打开文本文件";//设置打开文件对话框标题
            fileDialog.Filter = "All Files(*.*)|*.*|txt Files(*.txt)|*.txt";//设置文件过滤类型
            fileDialog.FilterIndex = 2;//根据文件类型索引设置文件过滤类型
            fileDialog.RestoreDirectory = true;//设置对话框是否记忆之前打开的目录
            if (fileDialog.ShowDialog() == DialogResult.OK)//当点击文件对话框的确定按钮时打开相应的文件
            {                                                  //并执行如下语句块
                filePathText.Text = fileDialog.FileName;//获取选择文件的完整路径名（含文件名称）
               // filePathTemp = filePathText.Text;
                return true;
            }                                             //获取选择文件的完整文件名（不含路径）
            else
            {
                return false;
            }
        }


        public void SendFileFunc(object obj)
        {
            TcpListener tcpListener = obj as TcpListener;
            while (true)
            {
                try
                {
                    TcpClient tcpClient = tcpListener.AcceptTcpClient();
        
                    if (tcpClient.Connected)
                    {
                        string address = tcpClient.Client.RemoteEndPoint.ToString();

                        TxtServerIpListContent(address + "开始连接。。。");
                    
                        NetworkStream stream = tcpClient.GetStream();

                        filePathTemp= filePathText.Text;

                        // 执行相关文件操作
                        if (filePathText.Text == null || filePathText.Text == "")
                        {
                            MessageBox.Show("请选择需要上传的文件！");
                            // stream.Close();
                            continue;
                        }
                        else 
                        {
                            //string FileName = filePathText.Text.Substring(filePathText.Text.LastIndexOf("\\") + 1);
                            string FileName = System.IO.Path.GetFileName(filePathText.Text);

                            byte[] fileNameByte = Encoding.Unicode.GetBytes(FileName);

                            byte[] fileNameLengthForValueByte = Encoding.Unicode.GetBytes(fileNameByte.Length.ToString("D11"));
                            byte[] fileAttributeByte = new byte[fileNameByte.Length + fileNameLengthForValueByte.Length];

                            fileNameLengthForValueByte.CopyTo(fileAttributeByte, 0);  //文件名字符流的长度的字符流排在前面。

                            fileNameByte.CopyTo(fileAttributeByte, fileNameLengthForValueByte.Length);  //紧接着文件名的字符流

                            stream.Write(fileAttributeByte, 0, fileAttributeByte.Length);
                            TxtAddContent(filePathText.Text);
                            FileStream fileStrem = new FileStream(filePathText.Text, FileMode.Open);

                            int fileReadSize = 0;
                            long fileLength = 0;
                            while (fileLength < fileStrem.Length)
                            {
                                byte[] buffer = new byte[204800];
                                fileReadSize = fileStrem.Read(buffer, 0, buffer.Length);
                                stream.Write(buffer, 0, fileReadSize);
                                fileLength += fileReadSize;

                            }
                            fileStrem.Flush();
                            stream.Flush();
                           fileStrem.Close();
                           stream.Close();

                            TxtAddContent(string.Format("{0}文件发送成功", FileName));
                           


                        }


                    }

                }
                catch (Exception ex)
                {
                    
                }
            }
        }




        #endregion

        private void ipTextBox_TextChanged(object sender, EventArgs e)
        {

        }

        private void portTextBox_TextChanged(object sender, EventArgs e)
        {

        }

        private void richListTextBox_TextChanged(object sender, EventArgs e)
        {

        }

        private void richMainTextBox_TextChanged(object sender, EventArgs e)
        {

        }

        private void label2_Click(object sender, EventArgs e)
        {

        }

        private void label1_Click(object sender, EventArgs e)
        {

        }

        private void openFileDialog1_FileOk(object sender, CancelEventArgs e)
        {
           // MessageBox.Show("正在上传,请稍后！");
        }

        private void btn_upload_Click(object sender, EventArgs e)
        {
            //连接成功，开始打开文件夹
            OpenFileDialog openFileDialog = new OpenFileDialog();//打开文件对话框              
            if (InitialDialog(openFileDialog, "Open"))
            {
                using (Stream fileStrem = openFileDialog.OpenFile())
                {
                }
            }
        }

        private void btn_send_Click(object sender, EventArgs e)
        {
            //MessageBox.Show(filePathTemp +"====="+ filePathText.Text);
            if (filePathTemp == filePathText.Text)
            {
                MessageBox.Show("请重新选择文件！");

            }
            else {
              
                SendFileCenter();
            }

         

        }
    }
}
