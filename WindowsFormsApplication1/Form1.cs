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

namespace WindowsFormsApplication1
{
    public partial class Form1 : Form
    {
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

                
                SqlConnection conn = new SqlConnection("server=.;database=ErYingDatabase; uid=sa; pwd=9876543q");
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
    }
}
