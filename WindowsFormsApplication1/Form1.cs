using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Data.SqlClient;
using MathWorks.MATLAB.NET.Arrays;
using Gang;
using System.IO;

namespace WindowsFormsApplication1
{
    public partial class Form1 : Form
    {
        string ipAdress;
        public Form1()
        {
            InitializeComponent();
            
        }

        private void button1_Click(object sender, EventArgs e)
        {
            try
            {
                if (textBox1.Text == string.Empty)
                {
                    MessageBox.Show("用户名不能为空！", "错误提示", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    return;
                }
                string name = textBox1.Text.Trim();
                string pwd = textBox2.Text.Trim();

                try
                {
                    StreamReader sr = new StreamReader("IPAdress.txt");
                    //调用ReadToEnd方法读取选中文件的全部内容
                    ipAdress = sr.ReadToEnd();
                    TextBox t1 = new TextBox();
                    t1.Text = ipAdress;
                    ipAdress = t1.Text.Trim();
                    sr.Close();//关闭当前文件读取流
                }
                catch
                {
                }
                SqlConnection conn = new SqlConnection("server="+ipAdress +";database=ErYingDatabase; uid=sa; pwd=9876543q");
                if (conn.State != ConnectionState.Open)
                {
                    conn.Open();
                }
                SqlCommand sqlcmd = new SqlCommand();
                sqlcmd.Connection = conn;
                sqlcmd.CommandText = "select *from ClientTable where Clientname='" + name + "'and Clientpwd='" + pwd+"'";
                sqlcmd.CommandType = CommandType.Text;
                SqlDataReader sdr = sqlcmd.ExecuteReader();
                sdr.Read();
                if (sdr.HasRows)
                {
                   
                   // string sql = "update Logintime=" + time + "where Clientname=" + name;
                   // sqlcmd = new SqlCommand(sql, conn);
                   // sqlcmd.ExecuteNonQuery();
                    conn.Close();
                    string time = DateTime.Now.ToString();
                    this.Hide();
                    Form2 Main = new Form2();
                    Main.name = name;
                    Main.time = time;
                    Main.Show();
                    //this.Close();
                }
                else
                {
                    textBox1.Text = "";
                    textBox2.Text = "";
                    MessageBox.Show("用户名或密码错误！", "提示", MessageBoxButtons.OK, MessageBoxIcon.Information);

                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }

           
           
        }
        
        private void textBox1_TextChanged(object sender, EventArgs e)
        {

        }

        private void textBox1_KeyUp(object sender, KeyEventArgs e)
        {
            if (e.KeyValue == 13)
                textBox2.Focus();
        }

        private void textBox2_KeyUp(object sender, KeyEventArgs e)
        {
            if (e.KeyValue == 13)
                button1.Focus();
        }

        private void button2_Click(object sender, EventArgs e)
        {
            Application.Exit();
        }

        private void button3_Click(object sender, EventArgs e)
        {
            this.Hide ();
            Form3  Frm3=new Form3() ;
            Frm3 .Show();
        }

        private void Form1_Load(object sender, EventArgs e)
        {

        }

        private void label20_Click(object sender, EventArgs e)
        {

        }

        private void button1_MouseDown(object sender, MouseEventArgs e)
        {
            button1.BackgroundImage = Properties.Resources.b13;
        }

        private void button1_MouseLeave(object sender, EventArgs e)
        {
            button1.BackgroundImage = Properties.Resources.b11;
        }

        private void button1_MouseMove(object sender, MouseEventArgs e)
        {
            button1.BackgroundImage = Properties.Resources.b12;
        }

        private void button1_MouseUp(object sender, MouseEventArgs e)
        {
            button1.BackgroundImage = Properties.Resources.b12;
        }

        private void Form1_MouseLeave(object sender, EventArgs e)
        {
            
        }

        private void button3_MouseLeave(object sender, EventArgs e)
        {
            button3.BackgroundImage = Properties.Resources.b21;
        }

        private void button3_MouseMove(object sender, MouseEventArgs e)
        {
            button3.BackgroundImage = Properties.Resources.b22;
        }

        private void button3_MouseUp(object sender, MouseEventArgs e)
        {
            button3.BackgroundImage = Properties.Resources.b22;
        }

        private void button3_MouseDown(object sender, MouseEventArgs e)
        {
            button3.BackgroundImage = Properties.Resources.b23;
        }

        private void button2_MouseDown(object sender, MouseEventArgs e)
        {
            button2.BackgroundImage = Properties.Resources.b03;
        }

        private void button2_MouseLeave(object sender, EventArgs e)
        {
            button2.BackgroundImage = Properties.Resources.b01;
        }

        private void button2_MouseMove(object sender, MouseEventArgs e)
        {
            button2.BackgroundImage = Properties.Resources.b02;
        }

        private void button2_MouseUp(object sender, MouseEventArgs e)
        {
            button2.BackgroundImage = Properties.Resources.b02;
        }

        private void button4_MouseMove(object sender, MouseEventArgs e)
        {
            button4.ForeColor = Color.LightPink;
        }

        private void button4_MouseUp(object sender, MouseEventArgs e)
        {

        }

        private void button4_MouseLeave(object sender, EventArgs e)
        {
            button4.ForeColor = Color.White ;
        }

        private void button4_Click(object sender, EventArgs e)
        {
            Form ipSet = new Form5();
            ipSet.Show();
        }
    }
}
