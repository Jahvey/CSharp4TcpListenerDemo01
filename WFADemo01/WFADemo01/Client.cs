using System;
using System.IO;
using System.Net;
using System.Net.Sockets;
using System.Threading;
using System.Windows.Forms;

namespace WFADemo01
{
    public partial class Client : Form
    {
        public Client()
        {
            InitializeComponent();
        }
        FileHelper.FileHelper fileHelper;
        private const int port = 58080; //端口  



        private IPEndPoint ipEndPoint;
        private Thread th;

        private void ReceiveFileFunc(object obj) {

            IPEndPoint ipEndPoint = obj as IPEndPoint;
            TcpClient tcpClient = new TcpClient();


            try
            {
                tcpClient.Connect(ipEndPoint);
            }
            catch
            {
                TxtClientAddContent("连接失败，找不到服务器！");
            }

            if (tcpClient.Connected)
            {
                TxtClientIpListContent("IP地址：" + ipEndPoint.Address.ToString() + "\n端口号：" + ipEndPoint.Port);
                NetworkStream stream = tcpClient.GetStream();
                if (stream != null)
                {

                    //  TxtClientAddContent("文件名字符流的长度为：" + fileNameLength);

                    //TxtClientAddContent("文件名为：" + fileName);

                    String textBoxFileRecvPath = textBoxFileRecv.Text;
                    string dirPath = "C:\\WebFile\\";
                    if (textBoxFileRecvPath != "") {
                        dirPath = textBoxFileRecvPath + "\\";
                    }
                    if (!Directory.Exists(dirPath))
                    {
                        Directory.CreateDirectory(dirPath);
                    }

                    fileHelper = new FileHelper.FileHelper();
                    bool isReceiveSuccess=fileHelper.ReceiveFile(dirPath, stream);
                  //  progressBar_client.Maximum=(int)fileHelper.RecevieMaxLength;
                  //  progressBar_client.Value = fileHelper.RecevieStatus;
                    
                    if (isReceiveSuccess)
                    {
                        TxtClientAddContent("接收成功！！！");
                    }
                    else {
                        TxtClientAddContent("接收失败！！！");
                    }

                  
                }
            }


        }
        private void btn_client_Click(object sender, EventArgs e)
        {
            String textIp = textBoxIP.Text;
            String textPort = textBoxPort1.Text;
            

            if (!string.IsNullOrEmpty(textIp) && !string.IsNullOrEmpty(textPort) )
            {
                 ipEndPoint = new IPEndPoint(IPAddress.Parse(textIp), Int32.Parse(textPort));//将网络端点表示为IP和端口号 

                TxtClientAddContent("连接中。。。。。" + textIp + ":" + textPort);

                 th = new Thread(ReceiveFileFunc);
                th.Start(ipEndPoint);
                //TcpClient tcpClient = new TcpClient(ipoint);//实例化TcpClient类  //最方便 

                //if (tcpClient != null)
                //{
                //    networkStream = tcpClient.GetStream();//得到网络流 
                //    binayRead = new BinaryReader(networkStream);
                //    binayWrite = new BinaryWriter(networkStream);
                //}

            }
            else
            {
                MessageBox.Show("ip或者port为空，请检查输入！！！");
                
            }


        }



        public delegate void TxtClientAddContentEventHandler(string txtValue);
        /// <summary>
        /// 保证线程之间的通信正常
        /// </summary>
        /// <param name="txtValue"></param>
        public void TxtClientAddContent(String txtValue)
        {
            if (richTextContent.InvokeRequired)
            {
                TxtClientAddContentEventHandler addContent = TxtClientAddContent;
                richTextContent.Invoke(addContent, new object[] { txtValue });

            }
            else
            {
                richTextContent.Text = txtValue + "\r\n" + richTextContent.Text;
            }
        }




        /// <summary>
        /// 
        /// </summary>
        /// <param name="txtValue"></param>
        public delegate void TxtClientIpListContentEventHandler(string txtValue);
        public void TxtClientIpListContent(string txtValue)
        {
            if (richTextList.InvokeRequired)
            {
                TxtClientIpListContentEventHandler addContent = TxtClientIpListContent;
                richTextList.Invoke(addContent, new object[] { txtValue });
            }
            else
            {
                richTextList.Text = txtValue + "\r\n" + richTextList.Text;
            }
        }

        private void btn_Select_Click(object sender, EventArgs e)
        {


            FolderBrowserDialog P_File_Folder = new FolderBrowserDialog();
 
            if (P_File_Folder.ShowDialog() == DialogResult.OK)
            {

               // MessageBox.Show(P_File_Folder.SelectedPath);//选定目录后打印路径信息
                textBoxFileRecv.Text = P_File_Folder.SelectedPath;

            }

        }
    }
}
