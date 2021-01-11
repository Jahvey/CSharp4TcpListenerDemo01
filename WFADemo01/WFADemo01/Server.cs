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
using WFADemo01.FileHelper;

namespace WFADemo01
{
    public partial class Server : Form
    {
        public Server()
        {
            InitializeComponent();
        }

        TcpClientHelper tcpClientHelper ;
        FileHelper.FileHelper fileHelper;
        private void btn_selectFile_Click(object sender, EventArgs e)
        {
            //这是直接打开文件夹的相关操作
            //FolderBrowserDialog dialog = new FolderBrowserDialog();
            //dialog.Description = "请选择文件路径";

            //if (dialog.ShowDialog() == DialogResult.OK)
            //{
            //    String savePath = dialog.SelectedPath;
            //    textBox_filelocation.Text = savePath;
            //}

            //这才是直接打开对应的文件路径，并保存到对应的fileDialog当中
            OpenFileDialog openFileDialog = new OpenFileDialog();
            openFileDialog.InitialDirectory = "c:\\";//注意这里写路径时要用c:\\而不是c:\
            openFileDialog.Filter = "文本文件|*.*|C#文件|*.cs|所有文件|*.*";
            openFileDialog.RestoreDirectory = true;
            openFileDialog.FilterIndex = 1;
            if (openFileDialog.ShowDialog() == DialogResult.OK)
            {
                //String fName = openFileDialog.FileName;
                textBox_filelocation.Text = openFileDialog.FileName;
            }

        }


        //声明 
        private IPAddress localAddress;// IP地址 IPAddress类 在命名空间 using System.Net下 
        private const int port = 18002;//端口 
        private TcpListener tcpListener;//监听套接字 TcpLestener与TcpClient类 在命名空间 using System.Net.Sockets下 
        private TcpClient tcpClient;//服务端与客户端建立连接 
        private NetworkStream newworkStream;//利用NetworkStream对象与远程主机发送数据或接收数据\ 
        private BinaryReader binaryReader;//读取 BinaryReader与BinaryWriter类在命名空间using System.IO下 
        private BinaryWriter binaryWrite;//写入 
        private Thread thread;
        private void btn_server_Click(object sender, EventArgs e)
        {
            String textBox_filepath = textBox_filelocation.Text;
            if (!string.IsNullOrEmpty(textBox_filepath))
            {
                btn_server.Enabled = false;

                tcpListener = new TcpListener(IPAddress.Any, port);//创建TcpListener对象 
                tcpListener.Start();//开始监听 
                richTextContent.Text = "服务器开始监听....";
               // TxtServerAddContent();
                 thread = new Thread(AcceptClientConnect);//启动一个线程接收请求 
                thread.Start(tcpListener);//启动线程 
                


            }
            else {

                MessageBox.Show("选择的的文件路径为空！请检查！！！");
            }
        }


        //发起请求 
        private void AcceptClientConnect(object obj)
        {
            TcpListener tcpListener = obj as TcpListener;
            while (true)
            {
                try
                {
                    tcpClient = tcpListener.AcceptTcpClient();//从端口接收一个连接，并赋予它TcpClient对象 
                   if (tcpClient.Connected)
                    {
                        string address = tcpClient.Client.RemoteEndPoint.ToString();

                        TxtServerIpListContent(address + "开始连接。。。");

                        newworkStream = tcpClient.GetStream();

                        fileHelper = new FileHelper.FileHelper();
                        bool isSendSuccess=fileHelper.SendFile(textBox_filelocation.Text, newworkStream);
                        //binaryReader = new BinaryReader(newworkStream);
                        // binaryWrite = new BinaryWriter(newworkStream);
                        string FileName = System.IO.Path.GetFileName(textBox_filelocation.Text);
                        if (isSendSuccess) {
                            
                            TxtServerAddContent(string.Format("{0}文件发送成功", FileName));
                        }
                        else
                        {
                           
                            TxtServerAddContent(string.Format("{0}文件发送失败", FileName));

                        }

                        
                    }

                }
                catch
                {
                    break;
                }
            }
        }


        public delegate void TxtServerAddContentEventHandler(string txtValue);
        /// <summary>
        /// 保证线程之间的通信正常
        /// </summary>
        /// <param name="txtValue"></param>
        public void TxtServerAddContent(String txtValue)
        {
            if (richTextContent.InvokeRequired)
            {
                TxtServerAddContentEventHandler addContent = TxtServerAddContent;
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
        public delegate void TxtServerIpListContentEventHandler(string txtValue);
        public void TxtServerIpListContent(string txtValue)
        {
            if (richTextList.InvokeRequired)
            {
                TxtServerIpListContentEventHandler addContent = TxtServerIpListContent;
                richTextList.Invoke(addContent, new object[] { txtValue });
            }
            else
            {
                richTextList.Text = txtValue + "\r\n" + richTextList.Text;
            }
        }
    }
}
