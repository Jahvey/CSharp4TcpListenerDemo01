using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace WindowsFormsApp0100
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            StringBuilder sb = new StringBuilder();
            for (int i = 1; i < 10; i++)
            {
                for (int j = 1; j <=i; j++)
                {
                    sb.Append(i+"*"+j+"="+(i*j)+"\t");

                }
                sb.Append("\n");

            }
            if (richTextBox1.Text != null) {
                richTextBox1.Text = "";
            }
            richTextBox1.AppendText(sb.ToString());
        }

        private void richTextBox1_TextChanged(object sender, EventArgs e)
        {

        }
    }
}
