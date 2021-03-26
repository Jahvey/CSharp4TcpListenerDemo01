using System;
using System.Windows.Forms;

namespace WFADemo01
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }

        private void Form1_Load(object sender, EventArgs e)
        {

        }
        Client client;
        Server server;

        private void btn_clientForm_Click(object sender, EventArgs e)
        {
            
             client = new Client();
            //client.showDialog();//这个函数实现的是如果父窗口打开了一个子窗口，那么子窗口的不关闭，父窗口就无法被选中
            client.Show();
        }

        private void btn_ServerForm_Click(object sender, EventArgs e)
        {
             server = new Server();
            server.Show();
        }
    }
}
