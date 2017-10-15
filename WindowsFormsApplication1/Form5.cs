using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Data.SqlClient;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Text;
using System.Windows.Forms;

namespace WindowsFormsApplication1
{
    public partial class Form5 : Form
    {
        public Form5()
        {
            InitializeComponent();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            File.Delete("IPAdress.txt");
            StreamWriter sw = new StreamWriter("IPAdress.txt", true);
            sw.WriteLine(textBox1.Text.Trim ());//向创建的文件中写入内容
            sw.Close();//关闭当前文件写入流
            this.Hide();

        }

        private void toolStripButton4_Click(object sender, EventArgs e)
        {

        }

        private void button5_Click(object sender, EventArgs e)
        {
            this.Hide();
        }

        private void Form5_Load(object sender, EventArgs e)
        {
            StreamReader sr = new StreamReader("IPAdress.txt");
            //调用ReadToEnd方法读取选中文件的全部内容
            textBox1.Text = sr.ReadToEnd();
            sr.Close();//关闭当前文件读取流
        }
    }
}
