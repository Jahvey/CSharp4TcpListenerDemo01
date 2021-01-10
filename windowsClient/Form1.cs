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

namespace windowsClient
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }

        #region

        public delegate void TxtReceiveAddContentEventHandler(string txtValue);
        public void TxtReceiveAddContent(string txtValue)
        {
            if (richMainTextBox.InvokeRequired)
            {
                TxtReceiveAddContentEventHandler addContent = TxtReceiveAddContent;
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
        public delegate void TxtReceiveIpListContentEventHandler(string txtValue);
        public void TxtReceiveIpListContent(string txtValue)
        {
            if (richListTextBox.InvokeRequired)
            {
                TxtReceiveIpListContentEventHandler addContent = TxtReceiveIpListContent;
                richListTextBox.Invoke(addContent, new object[] { txtValue });
            }
            else
            {
                richListTextBox.Text = txtValue + "\r\n" + richListTextBox.Text;
            }
        }

        private void button1_Click(object sender, EventArgs e)
        {
            button1.Enabled = false;
            //IPEndPoint ipEndPoint = new IPEndPoint(IPAddress.Parse("192.168.1.101"), 18001);
            String ipTxt = ipTextBox.Text;
            String portTxt = portTextBox.Text;
            // IPEndPoint ipEndPoint = new IPEndPoint(IPAddress.Parse("127.0.0.1"), 18001);
            IPEndPoint ipEndPoint = new IPEndPoint(IPAddress.Parse(ipTxt),Int32.Parse(portTxt));
            TxtReceiveAddContent("连接中。。。。。"+ipTxt+":"+portTxt);
            Thread th = new Thread(ReceiveFileFunc);
            th.Start(ipEndPoint);
            th.IsBackground = true;

        }

        private void ReceiveFileFunc(object obj)
        {
            IPEndPoint ipEndPoint = obj as IPEndPoint;
            TcpClient tcpClient = new TcpClient();

          
                try
                {
                    tcpClient.Connect(ipEndPoint);
                }
                catch
                {
                    TxtReceiveAddContent("连接失败，找不到服务器！");
                }

                if (tcpClient.Connected)
                {
                    TxtReceiveIpListContent("IP地址：" + ipEndPoint.Address.ToString() + "\n端口号：" + ipEndPoint.Port);
                    NetworkStream stream = tcpClient.GetStream();
                    if (stream != null)
                    {

                        byte[] fileNameLengthForValueByte = Encoding.Unicode.GetBytes((256).ToString("D11"));
                        byte[] fileNameLengByte = new byte[102400];
                        int fileNameLengthSize = stream.Read(fileNameLengByte, 0, fileNameLengthForValueByte.Length);
                        string fileNameLength = Encoding.Unicode.GetString(fileNameLengByte, 0, fileNameLengthSize);
                        TxtReceiveAddContent("文件名字符流的长度为：" + fileNameLength);

                        int fileNameLengthNum = Convert.ToInt32(fileNameLength);
                        byte[] fileNameByte = new byte[fileNameLengthNum];

                        int fileNameSize = stream.Read(fileNameByte, 0, fileNameLengthNum);
                        string fileName = Encoding.Unicode.GetString(fileNameByte, 0, fileNameSize);
                        TxtReceiveAddContent("文件名为：" + fileName);

                    // string dirPath = Application.StartupPath + "\\WebFile";
                    string dirPath ="C:\\WebFile";
                    if (!Directory.Exists(dirPath))
                        {
                            Directory.CreateDirectory(dirPath);
                        }
                        FileStream fileStream = new FileStream(dirPath + "\\" + fileName, FileMode.Create, FileAccess.Write);
                        int fileReadSize = 0;
                        byte[] buffer = new byte[204800];
                        while ((fileReadSize = stream.Read(buffer, 0, buffer.Length)) > 0)
                        {
                            fileStream.Write(buffer, 0, fileReadSize);

                        }
                        fileStream.Flush();
                        fileStream.Close();
                        stream.Flush();
                        stream.Close();
                        tcpClient.Close();
                        TxtReceiveAddContent("接收成功");
                    }
                }
            


        }
 

            #endregion
        }
}
