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
namespace WindowsFormsApplication1
{
    public partial class Form3 : Form
    {
        string ipAdress=".";
        public Form3()
        {
            InitializeComponent();
        }

        private void button2_Click(object sender, EventArgs e)
        {
            this.Hide();
            Form1 Frm1 = new Form1();
            Frm1.Show();
            return;
        }

        private void button1_Click(object sender, EventArgs e)
        {
            SqlConnection conn = new SqlConnection("server=" + ipAdress + ";database=ErYingDatabase; uid=sa; pwd=9876543q");
            if (conn.State != ConnectionState.Open)
            {
                conn.Open();
            }
            if (textBox1.Text == string.Empty)
            {
                MessageBox.Show("用户名不能为空！", "错误提示", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }
            string name = textBox1.Text.Trim();
      
            SqlCommand sqlcmd = new SqlCommand();
            sqlcmd.Connection = conn;
            sqlcmd.CommandText = "select *from ClientTable where Clientname='" + name + "'";
            sqlcmd.CommandType = CommandType.Text;
            SqlDataReader sdr = sqlcmd.ExecuteReader();
            sdr.Read();
            if (sdr.HasRows)
            {
                textBox1.Text = "";
                MessageBox.Show("该用户名已存在！", "错误提示", MessageBoxButtons.OK, MessageBoxIcon.Error);

                return;
                
            }
            sdr.Close();
            if (textBox2.Text == textBox3.Text)
            {
                SqlCommand sqlcmd1 = new SqlCommand();
                sqlcmd1.Connection = conn;
                sqlcmd1.CommandText = "insert into ClientTable values('" + name + "','" + textBox2.Text.Trim ()+"','0','0','0')";
                sqlcmd1.CommandType = CommandType.Text;
                sqlcmd1.ExecuteNonQuery();
                MessageBox.Show("注册成功！", "注册提示", MessageBoxButtons.OK, MessageBoxIcon.Information );
                    this.Hide();
                    Form1 Frm1 = new Form1();
                    Frm1.Show();
                    return;
            }
            else
            {
                    textBox2.Text = "";
                    textBox3.Text = "";
                    MessageBox.Show("两次密码不一致！", "错误提示", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    return;
            }
            

        }

        private void Form3_Load(object sender, EventArgs e)
        {

        }

        private void button1_MouseDown(object sender, MouseEventArgs e)
        {
            button1.BackgroundImage = Properties.Resources.b23;
        }

        private void button1_MouseLeave(object sender, EventArgs e)
        {
            button1.BackgroundImage = Properties.Resources.b21;
        }

        private void button1_MouseMove(object sender, MouseEventArgs e)
        {
            button1.BackgroundImage = Properties.Resources.b22;
        }

        private void button1_MouseUp(object sender, MouseEventArgs e)
        {
            button1.BackgroundImage = Properties.Resources.b22;
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
            button2.BackgroundImage = Properties.Resources.b22;
        }

        private void button2_MouseUp(object sender, MouseEventArgs e)
        {
            button2.BackgroundImage = Properties.Resources.b22;
        }
    }
}
