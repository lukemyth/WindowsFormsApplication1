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
using System.IO ;
using MathWorks.MATLAB.NET.Arrays;
using Gang;


namespace WindowsFormsApplication1
{
    public partial class Form2 : Form
    {
        public string name, time;
        public byte[] imagebytes=null ;
        
        
        public Form2()
        {
            InitializeComponent();
            
        }
        
        private void button1_Click(object sender, EventArgs e)
        {

        }

        private void checkedListBox1_SelectedIndexChanged(object sender, EventArgs e)
        {

        }

        private void button1_Click_1(object sender, EventArgs e)
        {

        }

        private void dataGridView1_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {

        }

        private void Form2_Load(object sender, EventArgs e)
        {
            label53.Text = "当前用户名：" + name;
            label54.Text = "登录时间：" + time;
            textBox30.Text = name;/*
            SqlConnection sqlConn = new SqlConnection("server=.;database=ErYingDatabase; uid=sa; pwd=9876543q");


            if (radioButton1.Checked == true)
            {
                SqlDataAdapter sda1 = new SqlDataAdapter("select distinct ST_Num from ST_Information", sqlConn);
                DataSet ds1 = new DataSet();
                sda1.Fill(ds1, "emp");
                comboBox4.DisplayMember = "ST_Num";
                comboBox4.DataSource = ds1.Tables[0];
            }
            else
            {
                SqlDataAdapter sda1 = new SqlDataAdapter("select distinct ST_name from ST_Information", sqlConn);
                DataSet ds1 = new DataSet();
                sda1.Fill(ds1, "emp");
                comboBox4.DisplayMember = "ST_name";
                comboBox4.DataSource = ds1.Tables[0];
            }
            comboBox4.Text = "所有人员";
            groupBox5.Visible = false;
            label44.Visible = false;
            comboBox14.Visible = false;
            button14.Enabled = false;
            button15.Enabled = false;
            SqlDataAdapter sda2 = new SqlDataAdapter("select distinct * from ClientTable where Clientname='" + name + "'", sqlConn);
            DataSet ds2 = new DataSet();
            sda2.Fill(ds2, "emp");
            if (ds2.Tables[0].Rows[0][2].ToString() == "0")
            {
                groupBox2.Visible = false;
                groupBox3.Visible = false;
                button4.Visible = false; button6.Visible = false; button7.Visible = false;
                button5.Visible = false; button13.Visible = false; button21.Visible = false;
                button14.Visible = false; button15.Visible = false;
            }
            if (ds2.Tables[0].Rows[0][3].ToString() == "0")
            {
                button12.Visible = false; button16.Visible = false;
            }*/
        }

        private void button20_Click(object sender, EventArgs e)
        {
            
            
            this.Close();
            Form1 Frm1 = new Form1();
            Frm1.ShowDialog();
        }

        private void button17_Click(object sender, EventArgs e)
        {

            Application.Exit();
        }

        private void tabPage5_Click(object sender, EventArgs e)
        {

        }

        private void button19_Click(object sender, EventArgs e)
        {

        }

        private void button18_Click(object sender, EventArgs e)
        {

        }

        private void tabPage8_Click(object sender, EventArgs e)
        {
            
        }

        private void label15_Click(object sender, EventArgs e)
        {

        }

        private void button3_Click(object sender, EventArgs e)
        {
            foreach (Control c in tabPage5.Controls)
            {
                if (c is TextBox)
                {
                    if (string.IsNullOrEmpty((c as TextBox).Text))
                    {
                       label57.Text =("提示：请先将数据补充完整！");
                        return ;
                    }
                }
            }
            if (ST_birth.ForeColor == Color.Gray)
            { 
                label57.Text = ("提示：请先将数据补充完整！");
                         return ;
            }

            SqlConnection conn = new SqlConnection("server=.;database=ErYingDatabase; uid=sa; pwd=9876543q");
            if (conn.State != ConnectionState.Open)
            {
                conn.Open(); 
            }
            SqlCommand sqlcmd = new SqlCommand();
            sqlcmd.Connection = conn;
            sqlcmd.CommandText = "insert ST_Information ( ST_name,ST_sex,ST_birth,ST_race,ST_jiguan,ST_Num,ST_IDNum,ST_QorS,ST_polID,ST_address,ST_major,ST_isonlychild,ST_experience,ST_PreSchool)values"
               + "('"+ ST_name.Text.Trim()+ "','"+ ST_sex.Text.Trim() + "','"+ ST_birth.Text.Trim() + "','" + ST_race.Text.Trim() + "','" + ST_jiguan.Text.Trim() + "','" + ST_Num.Text.Trim() + "','" + ST_IDNum.Text.Trim()
                + "','" + ST_QorS.Text.Trim() + "','" + ST_polID.Text.Trim() + "','" + ST_address.Text.Trim() + "','" + ST_major.Text.Trim() + "','" + ST_isonlychild.Text.Trim()
                 + "','" + ST_experience.Text.Trim() + "','" + ST_PreSchool.Text.Trim() + "')";
            sqlcmd.CommandType = CommandType.Text;
            try
            {
                
                sqlcmd.ExecuteNonQuery();
                label57.Text = ("提示:学员" + ST_name.Text + "数据添加成功！");                          
                SqlDataAdapter sda1 = new SqlDataAdapter("select * from ST_Information", conn);
                DataSet ds1 = new DataSet();
                sda1.Fill(ds1, "emp");
                dataGridView1.DataSource = ds1.Tables[0];
               try
                {
                //FileStream fs = new FileStream("tem.dat", FileMode.Open);
               // byte[] imagebytes = new byte[fs.Length];
                //fs.Read(imagebytes, 0, imagebytes.Length);
                //fs.Close();
                SqlCommand sqlcmd1 = new SqlCommand();
                sqlcmd1.Connection = conn;
                sqlcmd1.CommandText = "insert ST_Photos (ST_Num,ST_photo)values" + "('" + ST_Num.Text.Trim() + "',@imagelist)";
                sqlcmd1.Parameters.Add("@imagelist", SqlDbType.Image).Value =imagebytes;
                //sqlcmd1.Parameters["imagelist"].Value = ;
                sqlcmd1.ExecuteNonQuery();
                if (conn.State != ConnectionState.Open)
                {
                    conn.Dispose(); conn.Dispose();
                }
                

                }
               catch
               {
                   if (conn.State != ConnectionState.Open)
                   {
                       conn.Dispose(); conn.Dispose();
                   }
               }
            }
            catch (Exception ex)
            {
                label57.Text = "提示：操作错误，数据录入失败！！！";
                MessageBox.Show(ex.Message);
                if (conn.State != ConnectionState.Open)
                {
                    conn.Dispose(); conn.Dispose();
                }
            }

             
        }

        private void button22_Click(object sender, EventArgs e)
        {
            foreach (Control c in tabPage5.Controls)
            {
                if (c is TextBox)
                {
                    if (string.IsNullOrEmpty((c as TextBox).Text))
                    {
                        label57.Text = ("提示：请先将数据补充完整！");
                        return ;
                    }
                }
            }
            //if (ST_birth.ForeColor == Color.Gray)
            //{
              //  label57.Text = ("提示：请先将数据补充完整！");
                //return;
            //}
            SqlConnection conn = new SqlConnection("server=.;database=ErYingDatabase; uid=sa; pwd=9876543q");
            if (conn.State != ConnectionState.Open)
            {
                conn.Open();
            }
            SqlCommand sqlcmd = new SqlCommand();
            sqlcmd.Connection = conn;
            sqlcmd.CommandText =  "update ST_Information set ST_name='" + ST_name.Text.Trim() + "',ST_sex='" + ST_sex.Text.Trim()
                + "',ST_birth='" + ST_birth.Text.Trim() + "',ST_race='" + ST_race.Text.Trim()
                + "',ST_jiguan='" + ST_jiguan.Text.Trim() + "',ST_Num='" + ST_Num.Text.Trim() + "',ST_IDNum='" + ST_IDNum.Text.Trim()
                + "',ST_QorS='" + ST_QorS.Text.Trim() + "',ST_polID='" + ST_polID.Text.Trim() + "',ST_address='" + ST_address.Text.Trim()
                + "',ST_major='" + ST_major.Text.Trim() + "',ST_isonlychild='" + ST_isonlychild.Text.Trim()
                + "',ST_experience='" + ST_experience.Text.Trim() + "',ST_PreSchool='" + ST_PreSchool.Text.Trim()+"'where ST_Num='"+ST_Num .Text .Trim ()+"'";
            sqlcmd.CommandType = CommandType.Text;
            try
            {
                sqlcmd.ExecuteNonQuery();
                label57.Text = ("提示:学员" + ST_name.Text + "数据修改成功！");
                SqlDataAdapter sda1 = new SqlDataAdapter("select * from ST_Information", conn);
                DataSet ds1 = new DataSet();
                sda1.Fill(ds1, "emp");
                dataGridView1.DataSource = ds1.Tables[0];
                try
                {
                    //FileStream fs = new FileStream("tem.dat", FileMode.Open);
                    // byte[] imagebytes = new byte[fs.Length];
                    //fs.Read(imagebytes, 0, imagebytes.Length);
                    //fs.Close();
                    SqlCommand sqlcmd1 = new SqlCommand();
                    sqlcmd1.Connection = conn;
                    try
                    {
                        sqlcmd1.CommandText = "insert ST_Photos (ST_Num,ST_photo)values" + "('" + ST_Num.Text.Trim() + "',@imagelist)";
                        sqlcmd1.Parameters.Add("@imagelist", SqlDbType.Image).Value = imagebytes;
                        //sqlcmd1.Parameters["imagelist"].Value = ;
                        sqlcmd1.ExecuteNonQuery();
                    }
                    catch
                    {
                        sqlcmd1.CommandText = "update ST_Photos set ST_photo=@imagelist where ST_Num=' " + ST_Num.Text.Trim() + "'";
                        //sqlcmd1.Parameters.Add("@imagelist", SqlDbType.Image).Value = imagebytes;
                        //sqlcmd1.Parameters["imagelist"].Value = ;
                        sqlcmd1.ExecuteNonQuery();
                    }
                    if (conn.State != ConnectionState.Open)
                    {
                        conn.Dispose(); conn.Dispose();
                    }
                }
                catch (Exception ex)
                {
                    MessageBox.Show(ex.Message);
                    if (conn.State != ConnectionState.Open)
                    {
                        conn.Dispose(); conn.Dispose();
                    }
                }
            }
            catch (Exception ex)
            {
                label57.Text = "提示：操作错误，数据修改失败！！！";
                MessageBox.Show(ex.Message);
                if (conn.State != ConnectionState.Open)
                {
                    conn.Dispose(); conn.Dispose();
                }
            }
            
        }

        private void ST_sex_TextChanged(object sender, EventArgs e)
        {

        }

        private void ST_birth_Click(object sender, EventArgs e)
        {
            if (ST_birth.Text == "例如：1995/08")
            {
                //ST_birth.Text = "";
                //ST_birth.ForeColor = Color.Black;
            }

        }
        private void ST_birth_KeyUp(object sender, KeyEventArgs e)
        {
            if (ST_birth.Text.Trim() == "")
            {
                //ST_birth.Text = "例如：1995/08";
                //ST_birth.ForeColor = Color.Gray;
            }
        }

        private void ST_birth_TextChanged(object sender, EventArgs e)
        {

        }

        private void button2_Click(object sender, EventArgs e)
        {
            if (comboBox4.Text == "所有人员")
            {
                //SqlConnection conn = new SqlConnection();
                SqlConnection sqlConn = new SqlConnection("server=.;database=ErYingDatabase; uid=sa; pwd=9876543q");
                SqlDataAdapter sda = new SqlDataAdapter("select ST_name as '学员姓名',ST_sex as '性别',ST_birth as '出生年月',ST_race as '民族',ST_jiguan as '籍贯',ST_Num as '学号',ST_IDNum as '身份证号',ST_QorS as '士兵/青年学员',ST_polID as '政治面貌',ST_address as '现居住地',ST_major as '专业',ST_isonlychild as '是否独生子',ST_experience as '个人经历',ST_PreSchool as '入学前单位/学校' from ST_Information "
                     , sqlConn);
                DataSet ds = new DataSet();
                sda.Fill(ds, "emp");
                dataGridView1.DataSource = ds.Tables[0];
            }
            else
            {
                if (radioButton1.Checked == true)
                {


                    //SqlConnection conn = new SqlConnection();
                    SqlConnection sqlConn = new SqlConnection("server=.;database=ErYingDatabase; uid=sa; pwd=9876543q");
                    SqlDataAdapter sda = new SqlDataAdapter("select ST_name as '学员姓名',ST_sex as '性别',ST_birth as '出生年月',ST_race as '民族',ST_jiguan as '籍贯',ST_Num as '学号',ST_IDNum as '身份证号',ST_QorS as '士兵/青年学员',ST_polID as '政治面貌',ST_address as '现居住地',ST_major as '专业',ST_isonlychild as '是否独生子',ST_experience as '个人经历',ST_PreSchool as '入学前单位/学校' from ST_Information where ST_Num='" +
                        comboBox4.Text + "'", sqlConn);
                    DataSet ds = new DataSet();
                    try
                    {
                        sda.Fill(ds, "emp");
                        dataGridView1.DataSource = ds.Tables[0];
                        if (sqlConn.State != ConnectionState.Open)
                        {
                            sqlConn.Dispose(); sqlConn.Dispose();
                        }
                    }
                    catch (Exception ex)
                    {
                        label57.Text = "提示：操作错误，数据查找失败！！！";
                        MessageBox.Show(ex.Message);
                        if (sqlConn.State != ConnectionState.Open)
                        {
                            sqlConn.Dispose(); sqlConn.Dispose();
                        }
                    }


                }
                else
                {
                    //SqlConnection conn = new SqlConnection();
                    SqlConnection sqlConn = new SqlConnection("server=.;database=ErYingDatabase; uid=sa; pwd=9876543q");
                    SqlDataAdapter sda = new SqlDataAdapter("select ST_name as '学员姓名',ST_sex as '性别',ST_birth as '出生年月',ST_race as '民族',ST_jiguan as '籍贯',ST_Num as '学号',ST_IDNum as '身份证号',ST_QorS as '士兵/青年学员',ST_polID as '政治面貌',ST_address as '现居住地',ST_major as '专业',ST_isonlychild as '是否独生子',ST_experience as '个人经历',ST_PreSchool as '入学前单位/学校' from ST_Information where ST_name='" +
                        comboBox4.Text + "'", sqlConn);
                    DataSet ds = new DataSet();
                    sda.Fill(ds, "emp");
                    dataGridView1.DataSource = ds.Tables[0];
                    if (sqlConn.State != ConnectionState.Open)
                    {
                        sqlConn.Dispose(); sqlConn.Dispose();
                    }
                }
            }
        }

        private void ST_birth_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (ST_birth.ForeColor == Color.Gray)
            {
                ST_birth.Text = "";
            }
        }

        private void dataGridView1_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (dataGridView1.SelectedCells.Count != 0)
            {
                

                //得到选中行某列的值
                ST_name.Text  = dataGridView1.CurrentRow.Cells[1].Value.ToString();
                
            }

        }

        private void dataGridView1_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            if (dataGridView1.SelectedCells.Count != 0)
            {
               

                //得到选中行某列的值
                //string str = dataGridView1.CurrentRow.Cells[2].Value.ToString();
                ST_name.Text = dataGridView1.CurrentRow.Cells[0].Value.ToString();
                ST_sex.Text = dataGridView1.CurrentRow.Cells[1].Value.ToString();
                ST_birth.Text = dataGridView1.CurrentRow.Cells[2].Value.ToString();
                ST_race.Text = dataGridView1.CurrentRow.Cells[3].Value.ToString();
                ST_jiguan.Text = dataGridView1.CurrentRow.Cells[4].Value.ToString();
                ST_Num.Text = dataGridView1.CurrentRow.Cells[5].Value.ToString();
                ST_IDNum.Text = dataGridView1.CurrentRow.Cells[6].Value.ToString();
                ST_QorS.Text = dataGridView1.CurrentRow.Cells[7].Value.ToString();
                ST_polID.Text = dataGridView1.CurrentRow.Cells[8].Value.ToString();
                ST_address.Text = dataGridView1.CurrentRow.Cells[9].Value.ToString();
                ST_major.Text = dataGridView1.CurrentRow.Cells[10].Value.ToString();
                ST_isonlychild.Text = dataGridView1.CurrentRow.Cells[11].Value.ToString();
                ST_experience.Text = dataGridView1.CurrentRow.Cells[12].Value.ToString();
                ST_PreSchool.Text = dataGridView1.CurrentRow.Cells[13].Value.ToString();
                try
                {
                SqlConnection conn = new SqlConnection("server=.;database=ErYingDatabase; uid=sa; pwd=9876543q");
                
                if (conn.State != ConnectionState.Open)
                {
                    conn.Open();
                }
                //FileStream fs = new FileStream("tem.dat", FileMode.Open);
                
                //fs.Read(imagebytes, 0, imagebytes.Length);
                //fs.Close();

                try
                {
                    SqlCommand sqlcmd1 = new SqlCommand();

                    sqlcmd1.Connection = conn;
                    sqlcmd1.CommandText = "select ST_photo from ST_Photos where ST_Num='" + ST_Num.Text.Trim() + "'";
                    SqlDataReader sdr = sqlcmd1.ExecuteReader();
                    sdr.Read();
                    Byte[] mybyte = new byte[0];
                    mybyte = (byte[])sdr["ST_photo"];
                    MemoryStream ms = new MemoryStream(mybyte);
                    pictureBox1.Image = System.Drawing.Image.FromStream(ms, true);
                }
                catch { pictureBox1.Image = null; imagebytes = null; }


                    // sqlcmd1.Parameters.Add("imagelist", SqlDbType.Image);
               // sqlcmd1.Parameters["imagelist"].Value = imagebytes;
               /* SqlDataAdapter sda = new SqlDataAdapter("select ST_photo from ST_Photos where ST_Num='" + ST_Num.Text.Trim() + "'"
                , conn);
                
                DataSet ds = new DataSet();
                sda.Fill(ds, "emp");
                int c = ds.Tables["emp"].Rows.Count;
                if (c > 0)
                {
                    
                    mybyte = (Byte[])(ds.Tables["emp"].Rows[c - 1][0]);
                    MemoryStream ms = new MemoryStream(mybyte);
                    pictureBox1.Image = Image.FromStream(ms);
                }*/
                //byte[] imagebytes=new byte [0];               
                //sdr.Read();
                //imagebytes = (byte[])sdr.GetValue(0);
                //while (dr.Read())                
                //{
                //ST_experience.Text = ds.Tables [0];  //(byte[])               
                //}
                //sdr.Close();
                //MemoryStream ms = new MemoryStream(imagebytes); 
                //Bitmap bmpt = new Bitmap(ms); 
               
                }
                catch (Exception ex)
                {
                    label57.Text = "提示：操作错误，数据录入失败！！！";
                    MessageBox.Show(ex.Message);
                }
            }

        }

        private void dataGridView1_CellBeginEdit(object sender, DataGridViewCellCancelEventArgs e)
        {
            if (dataGridView1.SelectedCells.Count != 0)
            {


                //得到选中行某列的值
                //string str = dataGridView1.CurrentRow.Cells[2].Value.ToString();
               // ST_name.Text = dataGridView1.CurrentRow.Cells[0].Value.ToString();
            }

        }

        private void dataGridView1_ColumnAdded(object sender, DataGridViewColumnEventArgs e)
        {
            if (dataGridView1.SelectedCells.Count != 0)
            {


                //得到选中行某列的值
                //string str = dataGridView1.CurrentRow.Cells[2].Value.ToString();
                //ST_name.Text = dataGridView1.CurrentRow.Cells[0].Value.ToString();
            }
        }

        private void dataGridView1_ColumnDisplayIndexChanged(object sender, DataGridViewColumnEventArgs e)
        {
            if (dataGridView1.SelectedCells.Count != 0)
            {


                //得到选中行某列的值
                //string str = dataGridView1.CurrentRow.Cells[2].Value.ToString();
                ST_name.Text = dataGridView1.CurrentRow.Cells[0].Value.ToString();
            }
        }

        private void button23_Click(object sender, EventArgs e)
        {
          if(ST_Num .Text .Trim ()=="")
            {
                label57.Text = ("提示：请先将学号补充完整！");
                return;
            }
            SqlConnection conn = new SqlConnection("server=.;database=ErYingDatabase; uid=sa; pwd=9876543q");
            if (conn.State != ConnectionState.Open)
            {
                conn.Open();
            }
            SqlCommand sqlcmd = new SqlCommand();
            sqlcmd.Connection = conn;
            sqlcmd.CommandText = "delete from ST_Information where ST_Num='"+ST_Num .Text .Trim ()+"'";
            sqlcmd.CommandType = CommandType.Text;
            try
            {
                try
                {
                    SqlCommand sqlcmd1 = new SqlCommand();
                    sqlcmd1.Connection = conn;
                    sqlcmd1.CommandText = "delete from ST_Photos where ST_Num='" + ST_Num.Text.Trim() + "'";
                    sqlcmd1.CommandType = CommandType.Text;
                    sqlcmd1.ExecuteNonQuery();
                }
                catch { }
                sqlcmd.ExecuteNonQuery();
                label57.Text = ("提示:学员" + ST_name.Text + "数据删除成功！");
                SqlDataAdapter sda1 = new SqlDataAdapter("select * from ST_Information", conn);
                DataSet ds1 = new DataSet();
                sda1.Fill(ds1, "emp");
                dataGridView1.DataSource = ds1.Tables[0];
            }
            catch (Exception ex)
            {
                label57.Text = "提示：操作错误，数据删除失败！！！";
                MessageBox.Show(ex.Message);
            }
            
        }

        private void dateTimePicker1_KeyUp(object sender, KeyEventArgs e)
        {
           // textBox20.Text = dateTimePicker1.Text;
        }

        private void dateTimePicker1_BindingContextChanged(object sender, EventArgs e)
        {
            All_behavior.Text = dateTimePicker1.Text;
        }

        private void dateTimePicker1_ValueChanged(object sender, EventArgs e)
        {
            string data_year = dateTimePicker1.Value .Year .ToString ();
            string data_month = dateTimePicker1.Value.Month .ToString();
            string data_day = dateTimePicker1.Value.Day .ToString();
            SqlConnection conn = new SqlConnection("server=.;database=ErYingDatabase; uid=sa; pwd=9876543q");
            if (conn.State != ConnectionState.Open)
            {
                conn.Open();
            }
            SqlCommand sqlcmd = new SqlCommand();
            sqlcmd.Connection = conn;
            sqlcmd.CommandText = "select count(*) from All_Management where All_notingtime='" + data_year +"-"+data_month +"-"+data_day + "'";
            sqlcmd.CommandType = CommandType.Text;
            int i = Convert.ToInt32(sqlcmd.ExecuteScalar());
            if (i == 1)
            {
                sqlcmd.CommandText = "select * from All_Management where All_notingtime='" + data_year + "-" + data_month + "-" + data_day + "'";
                DataSet ds = new DataSet();
                SqlDataAdapter da = new SqlDataAdapter(sqlcmd.CommandText  ,conn );
                da.Fill(ds);
                All_behavior.Text = ds.Tables[0].Rows[0][1].ToString();
                All_assignment.Text = ds.Tables[0].Rows[0][2].ToString();
                All_selfstudy.Text = ds.Tables[0].Rows[0][3].ToString();
                All_clean.Text = ds.Tables[0].Rows[0][4].ToString();
                All_sleeping.Text = ds.Tables[0].Rows[0][5].ToString();
                All_breakrule.Text = ds.Tables[0].Rows[0][6].ToString();
                All_phone.Text = ds.Tables[0].Rows[0][7].ToString();
                All_other.Text = ds.Tables[0].Rows[0][8].ToString();
                All_zaocaoper.Text = ds.Tables[0].Rows[0][9].ToString();
                All_kaifanper.Text = ds.Tables[0].Rows[0][10].ToString();
                All_tinengper.Text = ds.Tables[0].Rows[0][11].ToString();
                All_dianmingper.Text = ds.Tables[0].Rows[0][12].ToString();
                textBox16.Text = ds.Tables[0].Rows[0][13].ToString();
                textBox17.Text = ds.Tables[0].Rows[0][14].ToString();
                textBox18.Text = ds.Tables[0].Rows[0][15].ToString();
                textBox19.Text = ds.Tables[0].Rows[0][16].ToString();
                textBox35.Text = ds.Tables[0].Rows[0][17].ToString();
                textBox34.Text = ds.Tables[0].Rows[0][18].ToString();
                textBox33.Text = ds.Tables[0].Rows[0][19].ToString();
                textBox27.Text = ds.Tables[0].Rows[0][20].ToString();
                Kitchen_guard.Text = ds.Tables[0].Rows[0][21].ToString();


            }


        }

        private void label39_Click(object sender, EventArgs e)
        {

        }

        private void textBox16_TextChanged(object sender, EventArgs e)
        {
            if (textBox16.Text.Trim() != "" && textBox35.Text.Trim() != "")
            {

                float num1, num2,num3;
                num1 =float.Parse(textBox16.Text.Trim());
                num2 =float.Parse(textBox35.Text.Trim());
                num3 = num2 / num1*100;
                All_zaocaoper.Text = num3.ToString() ;
            }
        }

        private void textBox35_TextChanged(object sender, EventArgs e)
        {
            if (textBox16.Text.Trim() != "" && textBox35.Text.Trim() != "")
            {
                float num1, num2, num3;
                num1 = float.Parse(textBox16.Text.Trim());
                num2 = float.Parse(textBox35.Text.Trim());
                num3 = num2 / num1 * 100;
                All_zaocaoper.Text = num3.ToString();
            }
        }

        private void textBox17_TextChanged(object sender, EventArgs e)
        {
            if (textBox17.Text.Trim() != "" && textBox34.Text.Trim() != "")
            {
                float num1, num2, num3;
                num1 = float.Parse(textBox17.Text.Trim());
                num2 = float.Parse(textBox34.Text.Trim());
                num3 = num2 / num1*100;
                All_kaifanper.Text = num3.ToString();
            }
        }

        private void textBox34_TextChanged(object sender, EventArgs e)
        {
            if (textBox17.Text.Trim() != "" && textBox34.Text.Trim() != "")
            {
                float num1, num2, num3;
                num1 = float.Parse(textBox17.Text.Trim());
                num2 = float.Parse(textBox34.Text.Trim());
                num3 = num2 / num1*100;
                All_kaifanper.Text = num3.ToString();
            }
        }

        private void textBox18_TextChanged(object sender, EventArgs e)
        {
            if (textBox18.Text.Trim() != "" && textBox33.Text.Trim() != "")
            {
                float num1, num2, num3;
                num1 = float.Parse(textBox18.Text.Trim());
                num2 = float.Parse(textBox33.Text.Trim());
                num3 = num2 / num1*100;
                All_tinengper.Text = num3.ToString();
            }
              
        }

        private void textBox33_TextChanged(object sender, EventArgs e)
        {
            if (textBox18.Text.Trim() != "" && textBox33.Text.Trim() != "")
            {
            float num1, num2, num3;
            num1 = float.Parse(textBox18.Text.Trim());
            num2 = float.Parse(textBox33.Text.Trim());
            num3 = num2 / num1*100;
            All_tinengper.Text = num3.ToString();
            }
        }

        private void textBox19_TextChanged(object sender, EventArgs e)
        {
            if (textBox19.Text.Trim() != "" && textBox27.Text.Trim() != "")
            {
            float num1, num2, num3;
            num1 = float.Parse(textBox19.Text.Trim());
            num2 = float.Parse(textBox27.Text.Trim());
            num3 = num2 / num1*100;
            All_dianmingper.Text = num3.ToString();
            }
        }

        private void textBox27_TextChanged(object sender, EventArgs e)
        {
            try
            {
                if (textBox19.Text.Trim() != "" && textBox27.Text.Trim() != "")
                {
                    float num1, num2, num3;
                    num1 = float.Parse(textBox19.Text.Trim());
                    num2 = float.Parse(textBox27.Text.Trim());
                    num3 = num2 / num1 * 100;
                    All_dianmingper.Text = num3.ToString();
                }
            }
            catch { }
            
        }

        private void button21_Click(object sender, EventArgs e)
        {
            SqlConnection conn = new SqlConnection("server=.;database=ErYingDatabase; uid=sa; pwd=9876543q");
            if (conn.State != ConnectionState.Open)
            {
                conn.Open();
            }
            SqlCommand sqlcmd = new SqlCommand();
            sqlcmd.Connection = conn;
            sqlcmd.CommandText = "insert All_Management ( All_notingtime,All_behavior,All_assignment,All_selfstudy,All_clean,All_sleeping,All_breakrule,All_phone,All_other,All_zaocaoper,All_kaifanper,All_tinengper,All_dianmingper,All_zaocaoying,All_kaifanying,All_tinengying,All_dianmingying,All_zaocaoshi,All_kaifanshi,All_tinengshi,All_dianmingshi,Kitchen_guard)values"
               + "('" + dateTimePicker1 .Value .Year .ToString ()+"-"+dateTimePicker1 .Value .Month .ToString ()+"-"+dateTimePicker1 .Value .Day .ToString () + "','" + All_behavior.Text.Trim() + "','" + All_assignment.Text.Trim() + "','" + All_selfstudy.Text.Trim() + "','" + All_clean.Text.Trim() + "','" + All_sleeping.Text.Trim() + "','" + All_breakrule.Text.Trim()
                + "','" + All_phone.Text.Trim() + "','" + All_other.Text.Trim() + "','" + All_zaocaoper.Text.Trim() + "','" + All_kaifanper.Text.Trim() + "','" + All_tinengper.Text.Trim()
                 + "','" + All_dianmingper.Text.Trim() + "','"+ textBox16 .Text .Trim ()+ "','"+ textBox17.Text.Trim() + "','"+ textBox18.Text.Trim() + "','"+ textBox19.Text.Trim() + "','"+ textBox35.Text.Trim() + "','"+ textBox34.Text.Trim() + "','" + textBox33.Text.Trim() + "','" + textBox27.Text.Trim() + "','" + Kitchen_guard.Text.Trim() + "')";
            sqlcmd.CommandType = CommandType.Text;
            try
            { sqlcmd.ExecuteNonQuery();
              label57.Text = ("提示:日期 " + dateTimePicker1.Value.Year.ToString() + "年" + dateTimePicker1.Value.Month.ToString() + "月" + dateTimePicker1.Value.Day.ToString() + "日" + ST_name.Text + "数据添加成功！");

            }
            catch (Exception ex)
            {
                label57.Text = "提示：操作错误，数据添加失败！！！";
                MessageBox.Show(ex.Message);
            }
        }

        private void button13_Click(object sender, EventArgs e)
        {
            SqlConnection conn = new SqlConnection("server=.;database=ErYingDatabase; uid=sa; pwd=9876543q");
            if (conn.State != ConnectionState.Open)
            {
                conn.Open();
            }
            SqlCommand sqlcmd = new SqlCommand();
            sqlcmd.Connection = conn;
            sqlcmd.CommandText = "update All_management set All_behavior='" + All_behavior.Text.Trim()
                + "',All_assignment='" + All_assignment.Text.Trim() + "',All_selfstudy='" + All_selfstudy.Text.Trim()
                + "',All_clean='" + All_clean.Text.Trim() + "',All_sleeping='" + All_sleeping.Text.Trim() + "',All_breakrule='" + All_breakrule.Text.Trim()
                + "',All_phone='" + All_phone.Text.Trim() + "',All_other='" + All_other.Text.Trim() + "',All_zaocaoper='" + All_zaocaoper.Text.Trim()
                + "',All_kaifanper='" + All_kaifanper.Text.Trim() + "',All_tinengper='" + All_tinengper.Text.Trim()
                + "',All_dianmingper='" + All_dianmingper.Text.Trim() + "',All_zaocaoying='" + textBox16.Text.Trim() + "',All_kaifanying='" + textBox17.Text.Trim() + "',All_tinengying='" + textBox18.Text.Trim()
                 + "',All_dianmingying='" + textBox19.Text.Trim() + "',All_zaocaoshi='" + textBox35.Text.Trim() + "',All_kaifanshi='" + textBox34.Text.Trim() + "',All_tinengshi='" + textBox33.Text.Trim()
                  + "',All_dianmingshi='" + textBox27.Text.Trim() + "',Kitchen_guard='" + Kitchen_guard.Text.Trim() + "' where All_notingtime='" + dateTimePicker1.Value.Year.ToString() + "-"
                  + dateTimePicker1.Value.Month.ToString() + "-" + dateTimePicker1.Value.Day.ToString()+"'";
            sqlcmd.CommandType = CommandType.Text;
            try
            {
                sqlcmd.ExecuteNonQuery();
                label57.Text = ("提示:日期 " + dateTimePicker1.Value.Year.ToString() + "年" + dateTimePicker1.Value.Month.ToString() + "月" + dateTimePicker1.Value.Day.ToString() + "日" + ST_name.Text + "数据更新成功！");
            }
            catch (Exception ex)
            {
                label57.Text = "提示：操作错误，数据更新失败！！！";
                MessageBox.Show(ex.Message);
            }
        }

        private void button5_Click(object sender, EventArgs e)
        {
            SqlConnection conn = new SqlConnection("server=.;database=ErYingDatabase; uid=sa; pwd=9876543q");
            if (conn.State != ConnectionState.Open)
            {
                conn.Open();
            }
            SqlCommand sqlcmd = new SqlCommand();
            sqlcmd.Connection = conn;
            sqlcmd.CommandText = "delete from All_management where All_notingtime='" +dateTimePicker1.Value.Year.ToString() + "-" + dateTimePicker1.Value.Month.ToString() + "-" + dateTimePicker1.Value.Day.ToString()+"'";
            sqlcmd.CommandType = CommandType.Text;
            try
            {
                sqlcmd.ExecuteNonQuery();
                label57.Text = ("提示:日期 " + dateTimePicker1.Value.Year.ToString() + "年" + dateTimePicker1.Value.Month.ToString() + "月" + dateTimePicker1.Value.Day.ToString() + "日" + ST_name.Text + "数据删除成功！");
            }
            catch (Exception ex)
            {
                label57.Text = "提示：操作错误，数据删除失败！！！";
                MessageBox.Show(ex.Message);
            }
        }

        private void tabPage7_Click(object sender, EventArgs e)
        {
            
        }

        private void comboBox10_SelectedIndexChanged(object sender, EventArgs e)
        {
            string str1, str2;
            if (radioButton5.Checked == true)
            {
                str1 = "ST_Study"; str2 = "ST_studysubject";
            }
            else
            {
                str1 = "ST_Training"; str2 = "ST_trainsubject";
            }
            if (checkBox1.CheckState ==CheckState.Checked)
            if (ST_majors .Text !="所有专业")
            {
            SqlConnection sqlConn = new SqlConnection("server=.;database=ErYingDatabase; uid=sa; pwd=9876543q");
            SqlDataAdapter sda = new SqlDataAdapter("select ST.ST_Num as '学号', ST.ST_name as '姓名',SU.ST_result as'"
                + ST_subject.Text.Trim() + "成绩'from (select* from ST_Information  where ST_major='" + ST_majors.Text 
                + "') as ST left outer join " + str1 + " as SU on ST.ST_Num=SU.ST_Num and SU." + str2 + "='" 
                + ST_subject.Text.Trim() + "'", sqlConn);
            DataSet ds = new DataSet();
            sda.Fill(ds, "emp");
            dataGridView2.DataSource = ds.Tables[0];          
            }
        }

        private void comboBox3_SelectedIndexChanged(object sender, EventArgs e)
        {
            SqlConnection sqlConn = new SqlConnection("server=.;database=ErYingDatabase; uid=sa; pwd=9876543q");
            string str1, str2,str3;
            
            if (radioButton4.Checked == true)
            {
               str3 = "ST_Num"; 
            }
            else
            {
                str3 = "ST_name"; 
            }
            
            if (radioButton5.Checked == true)
            {
                str1 = "ST_Study"; str2 = "ST_studysubject";
            }
            else
            {
                str1 = "ST_Training"; str2 = "ST_trainsubject";
            }
            if (ST_subject.Text == "所有专业")
            {
                try
                {
                    SqlDataAdapter sda = new SqlDataAdapter("select ST.ST_Num as '学号', ST.ST_name as '姓名', SU.ST_result as'"
                    + ST_subject.Text.Trim() + "成绩'from (select*from ST_Information where" + str3 + " ='" + comboBox3.Text.Trim()
                    + "')as ST left outer join " + str1 + "as SU on ST.ST_Num=SU.ST_Num", sqlConn);
                    DataSet ds = new DataSet();
                    sda.Fill(ds, "emp");
                    dataGridView2.DataSource = ds.Tables[0];
                }
                catch { }
            }
            else
            {
                try
                {
                    SqlDataAdapter sda = new SqlDataAdapter("select ST.ST_Num as '学号', ST.ST_name as '姓名' ,SU.ST_result as'"
                    + ST_subject.Text.Trim() + "成绩'from (select*from ST_Information where " + str3 + " ='" + comboBox3.Text.Trim()
                        + "')as ST left outer join " + str1 + " as SU on ST.ST_Num=SU.ST_Num and SU." + str2 + "='" + ST_majors.Text.Trim() + "'", sqlConn);
                    DataSet ds = new DataSet();
                    sda.Fill(ds, "emp");
                    dataGridView2.DataSource = ds.Tables[0];
                }
                catch { }
            }
            
            
            
            
        }

        private void tabPage6_Click(object sender, EventArgs e)
        {
            
        }

        private void button6_Click(object sender, EventArgs e)
        {
            SqlConnection conn = new SqlConnection("server=.;database=ErYingDatabase; uid=sa; pwd=9876543q");
            if (conn.State != ConnectionState.Open)
            {
                conn.Open();
            }
            SqlCommand sqlcmd = new SqlCommand();
            sqlcmd.Connection = conn;                
                    int i;
                    string str1, str2,str3,str4;
                    if (radioButton5.Checked == true)
                    {
                        str3 = "ST_Study"; str4 = "ST_studysubject";
                    }
                    else
                    {
                        str3 = "ST_Training"; str4 = "ST_trainsubject";
                    }

                    sqlcmd.CommandText = "insert "+str3+" ( ST_term,"+str4+",ST_Num,ST_result)";
                   for (i = 0; i < dataGridView2.Rows.Count-1; i++)
                    {
                        str1 = dataGridView2.Rows[i].Cells[0].Value.ToString();
                        str2 = dataGridView2.Rows[i].Cells[2].Value.ToString();
                       sqlcmd.CommandText = sqlcmd.CommandText + "select"
                               + "'" + ST_terms.Text.Trim() + "','" + ST_subject.Text.Trim() + "','" + str1 + "','" + str2 +"'";
                        if (i + 1 != dataGridView2.Rows.Count-1)
                        {
                            sqlcmd.CommandText = sqlcmd.CommandText + "union ";
                        }
                    }                                          
                try
                {
                    sqlcmd.ExecuteNonQuery();
                    label57.Text = ("提示: " + ST_terms.Text.Trim() + "学期" + ST_subject.Text.Trim() + "成绩" +i .ToString () +"条数据添加成功！");

                }
                catch (Exception ex)
                {
                    label57.Text = "提示：操作错误，数据添加失败！！！";
                    MessageBox.Show(ex.Message);
                }
           
        }

        private void radioButton1_CheckedChanged(object sender, EventArgs e)
        {
            SqlConnection sqlConn = new SqlConnection("server=.;database=ErYingDatabase; uid=sa; pwd=9876543q");
            
            
            if (radioButton1.Checked == true)
            {
                SqlDataAdapter sda1 = new SqlDataAdapter("select distinct ST_Num from ST_Information", sqlConn);
                DataSet ds1 = new DataSet();
                sda1.Fill(ds1, "emp");
                comboBox4.DataSource = ds1.Tables[0];
                comboBox4.DisplayMember = "ST_Num";
                
            }
            else
            {
                SqlDataAdapter sda2 = new SqlDataAdapter("select distinct ST_name from ST_Information", sqlConn);
                DataSet ds2 = new DataSet();
                sda2.Fill(ds2, "emp");
                comboBox4.DataSource = ds2.Tables[0];
                comboBox4.DisplayMember = "ST_name";
                

            }
            comboBox4.Text = "所有人员";
        }

        private void comboBox13_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (comboBox13.Text == "学期")
            {
                label44.Visible = true;
                comboBox14.Visible = true;
                groupBox5.Visible = false ;
                SqlConnection sqlConn = new SqlConnection("server=.;database=ErYingDatabase; uid=sa; pwd=9876543q");
                SqlDataAdapter sda1 = new SqlDataAdapter("select distinct ST_term as '学期'from ST_Semester", sqlConn);
                DataSet ds1 = new DataSet();
                sda1.Fill(ds1, "emp");
                comboBox14.DataSource = ds1.Tables[0];
                comboBox14.DisplayMember = "学期";
                dataGridView3.DataSource = ds1.Tables[0];
            }
            else
            {
                label44.Visible = true;
                comboBox14.Visible = true;
                groupBox5.Visible = true;
                if (radioButton8.Checked == true)
                {
                    SqlConnection sqlConn = new SqlConnection("server=.;database=ErYingDatabase; uid=sa; pwd=9876543q");
                    SqlDataAdapter sda1 = new SqlDataAdapter("select distinct ST_studysubject as'科目' from ST_StudySubject", sqlConn);
                    DataSet ds1 = new DataSet();
                    sda1.Fill(ds1, "emp");
                    comboBox14.DataSource = ds1.Tables[0];
                    comboBox14.DisplayMember = "科目";
                    dataGridView3.DataSource = ds1.Tables[0];
                }
                else
                {
                    SqlConnection sqlConn = new SqlConnection("server=.;database=ErYingDatabase; uid=sa; pwd=9876543q");
                    SqlDataAdapter sda1 = new SqlDataAdapter("select distinct ST_trainsubject as'科目'  from ST_TrainSubject", sqlConn);
                    DataSet ds1 = new DataSet();
                    sda1.Fill(ds1, "emp");
                    comboBox14.DataSource = ds1.Tables[0];
                    comboBox14.DisplayMember = "科目";
                    dataGridView3.DataSource = ds1.Tables[0];
                }

            }
            button14.Enabled = true;
            button15.Enabled = true;
        }

        private void comboBox14_MouseClick(object sender, MouseEventArgs e)
        {
            if (groupBox5.Visible == true)
            {
                if (radioButton8.Checked == true)
                {
                    SqlConnection sqlConn = new SqlConnection("server=.;database=ErYingDatabase; uid=sa; pwd=9876543q");
                    SqlDataAdapter sda1 = new SqlDataAdapter("select distinct ST_studysubject  as'科目'from ST_StudySubject", sqlConn);
                    DataSet ds1 = new DataSet();
                    sda1.Fill(ds1, "emp");
                    comboBox14.DataSource = ds1.Tables[0];
                    comboBox14.DisplayMember = "科目";
                }
                else
                {
                    SqlConnection sqlConn = new SqlConnection("server=.;database=ErYingDatabase; uid=sa; pwd=9876543q");
                    SqlDataAdapter sda1 = new SqlDataAdapter("select distinct ST_trainsubject as'科目' from ST_TrainSubject", sqlConn);
                    DataSet ds1 = new DataSet();
                    sda1.Fill(ds1, "emp");
                    comboBox14.DataSource = ds1.Tables[0];
                    comboBox14.DisplayMember = "科目";
                }
            }
        }

        private void button14_Click(object sender, EventArgs e)
        {
            if (comboBox13.Text == "学期")
            {
                SqlConnection conn = new SqlConnection("server=.;database=ErYingDatabase; uid=sa; pwd=9876543q");
                if (conn.State != ConnectionState.Open)
                {
                    conn.Open();
                }
                SqlCommand sqlcmd = new SqlCommand();
                sqlcmd.Connection = conn;
                sqlcmd.CommandText = "insert ST_Semester ( ST_term)values"
                      + "('" + comboBox14.Text + "')";
                sqlcmd.CommandType = CommandType.Text;

                try
                {
                    sqlcmd.ExecuteNonQuery();
                    label57.Text = ("提示:学期 " + comboBox14.Text + "数据添加成功！");
                    SqlDataAdapter sda1 = new SqlDataAdapter("select ST_term as '学期' from ST_Semester", conn);
                    DataSet ds1 = new DataSet();
                    sda1.Fill(ds1, "emp");
                    dataGridView3.DataSource = ds1.Tables[0];

                }
                catch (Exception ex)
                {
                    label57.Text = "提示：操作错误，数据添加失败！！！";
                    MessageBox.Show(ex.Message);

                }
            }
            else
            {
                string str1, str2;

                if (radioButton8.Checked == true)
                {str1 = "ST_StudySubject";str2 = "ST_studysubject"; }
                else
                { str1 = "ST_TrainSubject"; str2 = "ST_trainsubject"; }
                  SqlConnection sqlConn = new SqlConnection("server=.;database=ErYingDatabase; uid=sa; pwd=9876543q");
                        if (sqlConn.State != ConnectionState.Open)
                        {
                            sqlConn.Open();
                        }
                        SqlCommand sqlcmd = new SqlCommand();
                        sqlcmd.Connection = sqlConn;
                        sqlcmd.CommandText = "insert "+ str1+"(" +str2+" )values"
                              + "('" + comboBox14.Text + "')";
                        sqlcmd.CommandType = CommandType.Text;

                        try
                        {
                            sqlcmd.ExecuteNonQuery();
                            label57.Text = ("提示:科目 " + comboBox14.Text + "数据添加成功！");
                            SqlDataAdapter sda1 = new SqlDataAdapter("select distinct "+ str2+" as '科目'from "+str1, sqlConn);
                            DataSet ds1 = new DataSet();
                            sda1.Fill(ds1, "emp");
                            dataGridView3.DataSource = ds1.Tables[0];

                        }
                        catch (Exception ex)
                        {
                            label57.Text = "提示：操作错误，数据添加失败！！！";
                            MessageBox.Show(ex.Message);

                        }
                        
                    
            }
        }

        private void radioButton8_CheckedChanged(object sender, EventArgs e)
        {
            if (radioButton8.Checked == true)
            {
                SqlConnection conn = new SqlConnection("server=.;database=ErYingDatabase; uid=sa; pwd=9876543q");
                SqlDataAdapter sda1 = new SqlDataAdapter("select distinct ST_studysubject as '科目'from ST_StudySubject", conn);
                DataSet ds1 = new DataSet();
                sda1.Fill(ds1, "emp");
                dataGridView3.DataSource = ds1.Tables[0];
                comboBox14.DataSource = ds1.Tables[0];
                comboBox14.DisplayMember = "科目";
            }
            else
            {
                SqlConnection conn = new SqlConnection("server=.;database=ErYingDatabase; uid=sa; pwd=9876543q");
                SqlDataAdapter sda1 = new SqlDataAdapter("select distinct ST_trainsubject as '科目'from ST_TrainSubject", conn);
                DataSet ds1 = new DataSet();
                sda1.Fill(ds1, "emp");
                dataGridView3.DataSource = ds1.Tables[0];
                comboBox14.DataSource = ds1.Tables[0];
                comboBox14.DisplayMember = "科目";
            }

        }

        private void button15_Click(object sender, EventArgs e)
        {
            string str1,str2,str3;
            if (comboBox13 .Text =="学期")
            {
                str1 = "ST_Semester"; str2 = "ST_term"; str3 = "学期";
            }
            else 
            {
                if (radioButton8.Checked == true)
                {
                    str1 = "ST_StudySubject"; str2 = "ST_studysubject"; str3 = "科目";
                }
                else 
                {
                    str1 = "ST_TrainSubject"; str2 = "ST_trainsubject"; str3 = "科目";
                }
            }
            SqlConnection conn = new SqlConnection("server=.;database=ErYingDatabase; uid=sa; pwd=9876543q");
            if (conn.State != ConnectionState.Open)
            {
                conn.Open();
            }
            SqlCommand sqlcmd = new SqlCommand();
            sqlcmd.Connection = conn;
            sqlcmd.CommandText = "delete from "+str1 +" where "+str2 +"='"+dataGridView3.CurrentCell.Value.ToString ()+"'";
            sqlcmd.CommandType = CommandType.Text;
            try
            {
                sqlcmd.ExecuteNonQuery();
                label57.Text = ("提示:" + dataGridView3.CurrentCell.Value.ToString() + "数据删除成功！");
                SqlDataAdapter sda1 = new SqlDataAdapter("select distinct " + str2 + " as '" + str3 + "'from " + str1, conn);
                DataSet ds1 = new DataSet();
                sda1.Fill(ds1, "emp");
                dataGridView3.DataSource = ds1.Tables[0];
                comboBox14.DataSource = ds1.Tables[0];
                comboBox14.DisplayMember = str3;
            }
            catch (Exception ex)
            {
                label57.Text = "提示：操作错误，数据删除失败！！！";
                MessageBox.Show(ex.Message);

            }
            
        }

        private void tabControl2_Click(object sender, EventArgs e)
        {
            /*SqlConnection conn = new SqlConnection("server=.;database=ErYingDatabase; uid=sa; pwd=9876543q");
            if (conn.State != ConnectionState.Open)
            {
                conn.Open();
            }
            SqlCommand sqlcmd = new SqlCommand();
            sqlcmd.Connection = conn;
            //label57.Text = ("提示:科目 " + comboBox14.Text + "数据添加成功！");
            SqlDataAdapter sda1 = new SqlDataAdapter("select distinct ST_term as '学期'from ST_Semester", conn);
            DataSet ds1 = new DataSet();
            sda1.Fill(ds1, "emp");
            ST_terms.DataSource = ds1.Tables[0];
            ST_terms.DisplayMember = "学期";
            ST_terms.Text = "选择学期";
            string str1,str2;
            if (radioButton5.Checked == true)
            { str1 = "ST_StudySubject"; str2 = "ST_studysubject"; }
            else
            {
                str1 = "TrainSubject"; str2 = "ST_trainsubject";
            }
            SqlDataAdapter sda2 = new SqlDataAdapter("select distinct " + str2 + " as '科目'from " + str1, conn);
            DataSet ds2 = new DataSet();
            sda2.Fill(ds2, "emp");
            ST_subject.DataSource = ds2.Tables[0];
            ST_subject.DisplayMember = "科目";
            
            SqlDataAdapter sda3 = new SqlDataAdapter("select distinct ST_major as '专业'from ST_Information" , conn);
            DataSet ds3 = new DataSet();
            sda3.Fill(ds3, "emp");
            ST_majors.DataSource = ds3.Tables[0];
            ST_majors.DisplayMember = "专业";
            ST_majors.Text = "选择专业";*/
            ST_terms.Text = "选择学期";
            ST_majors.Text = "选择专业";
            ST_subject.Text = "选择科目";
            SqlConnection sqlConn = new SqlConnection("server=.;database=ErYingDatabase; uid=sa; pwd=9876543q");
            SqlDataAdapter sda = new SqlDataAdapter("select Clientname  from ClientTable", sqlConn);
            DataSet ds = new DataSet();
            sda.Fill(ds, "emp");

        }

        private void radioButton5_CheckedChanged(object sender, EventArgs e)
        {
            SqlConnection conn = new SqlConnection("server=.;database=ErYingDatabase; uid=sa; pwd=9876543q");
            string str1, str2;
            if (radioButton5.Checked == true)
            { str1 = "ST_StudySubject"; str2 = "ST_studysubject"; }
            else
            {
                str1 = "ST_TrainSubject"; str2 = "ST_trainsubject";
            }
            SqlDataAdapter sda2 = new SqlDataAdapter("select distinct " + str2 + " as '科目'from " + str1, conn);
            DataSet ds2 = new DataSet();
            sda2.Fill(ds2, "emp");
            ST_subject.DataSource = ds2.Tables[0];
            ST_subject.DisplayMember = "科目";
        }

        private void radioButton4_CheckedChanged(object sender, EventArgs e)
        {
             /*SqlConnection sqlConn = new SqlConnection("server=.;database=ErYingDatabase; uid=sa; pwd=9876543q");


           if (radioButton4.Checked == true)
            {
                SqlDataAdapter sda4 = new SqlDataAdapter("select distinct ST_Num from ST_Information", sqlConn);
                DataSet ds1 = new DataSet();
                sda4.Fill(ds1, "emp");
                comboBox3.DisplayMember = "ST_Num";
                comboBox3.DataSource = ds1.Tables[0];
            }
            else
            {
                SqlDataAdapter sda1 = new SqlDataAdapter("select distinct ST_name from ST_Information", sqlConn);
                DataSet ds1 = new DataSet();
                sda1.Fill(ds1, "emp");
                comboBox3.DisplayMember = "ST_name";
                comboBox3.DataSource = ds1.Tables[0];
            }*/
            comboBox3.Text = "所有人员";
        }

        private void comboBox4_MouseClick(object sender, MouseEventArgs e)
        {
            SqlConnection sqlConn = new SqlConnection("server=.;database=ErYingDatabase; uid=sa; pwd=9876543q");


            if (radioButton1.Checked == true)
            {
                SqlDataAdapter sda4 = new SqlDataAdapter("select distinct ST_Num from ST_Information", sqlConn);
                DataSet ds1 = new DataSet();
                sda4.Fill(ds1, "emp");
                
                comboBox4.DataSource = ds1.Tables[0];
                comboBox4.DisplayMember = "ST_Num";
            }
            else
            {
                SqlDataAdapter sda1 = new SqlDataAdapter("select distinct ST_name from ST_Information", sqlConn);
                DataSet ds1 = new DataSet();
                sda1.Fill(ds1, "emp");
                
                comboBox4.DataSource = ds1.Tables[0];
                comboBox4.DisplayMember = "ST_name";
            }
            comboBox4.Text = "所有人员";
        }

        private void comboBox3_MouseClick(object sender, MouseEventArgs e)
        {
            if (comboBox3.Text == "所有人员")
            {
                comboBox3.Text = "";
            }
            string str1, str2,str3;
            if (radioButton4.Checked == true)
            { str1 = "ST_Information"; str2 = "ST_Num";}
            else
            {
                str1 = "ST_Information"; str2 = "ST_name";
            }
            if (ST_majors.Text == "所有专业")
            {
                SqlConnection sqlConn = new SqlConnection("server=.;database=ErYingDatabase; uid=sa; pwd=9876543q");
                SqlDataAdapter sda1 = new SqlDataAdapter("select distinct " + str2 + "  from " + str1, sqlConn);
                DataSet ds1 = new DataSet();
                sda1.Fill(ds1, "emp");
                comboBox3.DataSource = ds1.Tables[0];
                comboBox3.DisplayMember = str2;
            }
            else
            {
                str3 = ST_majors.Text;
                SqlConnection sqlConn = new SqlConnection("server=.;database=ErYingDatabase; uid=sa; pwd=9876543q");
                SqlDataAdapter sda1 = new SqlDataAdapter("select distinct " + str2 + "  from " + str1+" where ST_major='"+str3 +"'", sqlConn);
                DataSet ds1 = new DataSet();
                sda1.Fill(ds1, "emp");
                comboBox3.DataSource = ds1.Tables[0];
                comboBox3.DisplayMember = str2;
            }
            
            
        }

        private void ST_terms_MouseClick(object sender, MouseEventArgs e)
        {
            SqlConnection sqlConn = new SqlConnection("server=.;database=ErYingDatabase; uid=sa; pwd=9876543q");
            SqlDataAdapter sda1 = new SqlDataAdapter("select distinct ST_term from ST_Semester", sqlConn);
            DataSet ds1 = new DataSet();
            sda1.Fill(ds1, "emp");
            
            ST_terms.DataSource = ds1.Tables[0];
            ST_terms.DisplayMember = "ST_term";
            if (ST_terms.Text == "选择学期")
            {
                ST_terms.Text = "所有时间";
            }
        }

        private void ST_subject_MouseClick(object sender, MouseEventArgs e)
        {
            string str1, str2;
            if (radioButton5.Checked == true)
            { str1 = "ST_StudySubject"; str2 = "ST_studysubject"; }
            else
            {
                str1 = "ST_TrainSubject"; str2 = "ST_trainsubject";
            }
            SqlConnection sqlConn = new SqlConnection("server=.;database=ErYingDatabase; uid=sa; pwd=9876543q");
            SqlDataAdapter sda1 = new SqlDataAdapter("select distinct "+str2 +"  from "+str1 , sqlConn);
            DataSet ds1 = new DataSet();
            sda1.Fill(ds1, "emp");
            
            ST_subject.DataSource = ds1.Tables[0];
            ST_subject.DisplayMember = str2;
            if (ST_subject.Text == "选择科目")
            {
                ST_subject.Text = "";
            }
            if (dataGridView2.Columns.Count == 2)
            {
                DataGridViewTextBoxColumn c = new DataGridViewTextBoxColumn();
                c.HeaderText = "成绩";
                dataGridView2.Columns.Add(c);
                dataGridView2.Columns[2].ReadOnly = false;
            }
        }

        private void ST_majors_MouseClick(object sender, MouseEventArgs e)
        {
            SqlConnection sqlConn = new SqlConnection("server=.;database=ErYingDatabase; uid=sa; pwd=9876543q");
            SqlDataAdapter sda1 = new SqlDataAdapter("select distinct ST_major  from ST_Information" , sqlConn);
            DataSet ds1 = new DataSet();
            sda1.Fill(ds1, "emp");
            
            ST_majors.DataSource = ds1.Tables[0];
            ST_majors.DisplayMember = "ST_major";
            if (ST_majors.Text == "选择专业")
            {
                ST_majors.Text = "";
            }
        }

        private void button4_Click(object sender, EventArgs e)
        {
            SqlConnection conn = new SqlConnection("server=.;database=ErYingDatabase; uid=sa; pwd=9876543q");
            if (conn.State != ConnectionState.Open)
            {
                conn.Open();
            }
            SqlCommand sqlcmd = new SqlCommand();
            sqlcmd.Connection = conn;
            int i;
            string str1, str2, str3, str4;
            if (radioButton5.Checked == true)
            {
                str3 = "ST_Study"; str4 = "ST_studysubject";
            }
            else
            {
                str3 = "ST_Training"; str4 = "ST_trainsubject";
            }

            
            for (i = 0; i < dataGridView2.Rows.Count - 1; i++)
            {
                str1 = dataGridView2.Rows[i].Cells[0].Value.ToString();
                str2 = dataGridView2.Rows[i].Cells[2].Value.ToString();
                sqlcmd.CommandText = "update " + str3 + " set ST_result='"+str2 +"'where ST_term='" + ST_terms.Text.Trim() +"'and "+ str4 + "='" + ST_subject.Text.Trim() + 
                    "'and ST_Num='" + str1 + "'";
                try
                {
                    sqlcmd.ExecuteNonQuery();


                }
                catch (Exception ex)
                {
                    label57.Text = "提示：操作错误，数据更新失败！！！";
                    MessageBox.Show(ex.Message);
                }             
            }
           
            label57.Text = ("提示: " + ST_terms.Text.Trim() + "学期" + ST_subject.Text.Trim() + "成绩" + i.ToString() + "条数据更新成功！");
        }

        private void button7_Click(object sender, EventArgs e)
        {
            string str1, str2;
            if (radioButton5.Checked == true)
            {
                str1 = "ST_Study"; str2 = "ST_studysubject";
            }
            else
            {
                str1 = "ST_Training"; str2 = "ST_trainsubject";
            }
            SqlConnection conn = new SqlConnection("server=.;database=ErYingDatabase; uid=sa; pwd=9876543q");
            if (conn.State != ConnectionState.Open)
            {
                conn.Open();
            }
            SqlCommand sqlcmd = new SqlCommand();
            sqlcmd.Connection = conn;
            sqlcmd.CommandText = "delete from "+str1+" where ST_Num='" + dataGridView2 .CurrentCell .Value .ToString ()
                + "'and " + str2 + "='" + ST_subject.Text + "'and ST_term='"+ST_terms.Text  +"'";
            sqlcmd.CommandType = CommandType.Text;
            try
            {
                sqlcmd.ExecuteNonQuery();
                label57.Text = ("提示:学号为" + dataGridView2 .CurrentCell .Value .ToString ()+ "学员"+ST_terms.Text +"学期"+ST_subject.Text +"成绩删除成功！");
                dataGridView2.CurrentCell.Dispose();
            }
            catch (Exception ex)
            {
                label57.Text = "提示：操作错误，数据删除失败！！！";
                MessageBox.Show(ex.Message);
            }
        }

        private void tabPage7_MouseClick(object sender, MouseEventArgs e)
        {
            
        }

        

        private void textBox30_TextChanged(object sender, EventArgs e)
        {

        }

        private void comboBox5_MouseClick(object sender, MouseEventArgs e)
        {
            SqlConnection sqlConn = new SqlConnection("server=.;database=ErYingDatabase; uid=sa; pwd=9876543q");
            SqlDataAdapter sda4 = new SqlDataAdapter("select distinct Clientname from ClientTable", sqlConn);
                DataSet ds1 = new DataSet();
                sda4.Fill(ds1, "emp");
                comboBox5.DataSource = ds1.Tables[0];
                comboBox5.DisplayMember = "Clientname";
          
        }

        

        private void comboBox5_SelectedIndexChanged(object sender, EventArgs e)
        {
            SqlConnection sqlConn = new SqlConnection("server=.;database=ErYingDatabase; uid=sa; pwd=9876543q");
            SqlDataAdapter sda4 = new SqlDataAdapter("select Clientname,ClientRight1,ClientRight2,ClientRight3 from ClientTable where Clientname='" + comboBox5.Text.Trim() + "'", sqlConn);
            DataSet ds1 = new DataSet();
            sda4.Fill(ds1, "emp");
            int i;
            try
            {
                textBox30.Text = ds1.Tables[0].Rows[0][0].ToString();
                for (i = 1; i <= 3; i++)
                {
                    if (ds1.Tables[0].Rows[0][i].ToString ()=="1")
                    {
                        checkedListBox1.SetItemChecked(i - 1, true);
                    }
                    else
                    {
                        checkedListBox1.SetItemChecked(i - 1, false );
                    }
                }
            }
            catch { }
        }

        private void button11_Click(object sender, EventArgs e)
        {
            SqlConnection conn = new SqlConnection("server=.;database=ErYingDatabase; uid=sa; pwd=9876543q");
            if (conn.State != ConnectionState.Open)
            {
                conn.Open();
            }
            SqlCommand sqlcmd,sqlcmd1 = new SqlCommand();
            sqlcmd = new SqlCommand();
            sqlcmd1.Connection = conn; sqlcmd.Connection = conn;
            sqlcmd1.CommandText = "select * from ClientTable where Clientname='" + textBox30.Text + "'and Clientpwd='" + textBox32.Text +"'";
            sqlcmd1.CommandType = CommandType.Text;
             SqlDataReader sdr = sqlcmd1.ExecuteReader();
                sdr.Read();
                
               
                if (sdr.HasRows)
                {
                    sdr.Close();

                    if (textBox31.Text == textBox1.Text)
                    {

                        sqlcmd.CommandText = "update ClientTable set Clientpwd='" + textBox31.Text.Trim() + "'where Clientname='" + textBox30.Text + "'";
                        sqlcmd.CommandType = CommandType.Text;
                        try
                        {
                            sqlcmd.ExecuteNonQuery();
                            label57.Text = ("提示:用户" + textBox30.Text + "密码修改成功！");

                        }
                        catch (Exception ex)
                        {
                            label57.Text = "提示：操作错误，密码修改失败！！！";
                            MessageBox.Show(ex.Message);
                        }
                    }
                    else
                    {
                        label57.Text = "提示：两次密码输入不一致！！！";
                    }
            }
            else
            {
                label57.Text = "提示：用户名或密码输入错误";
            }
        }

        private void button12_Click(object sender, EventArgs e)
        {
            int k1,k2,k3;
            if (checkedListBox1.GetItemChecked(0))
            {
                k1 = 1;
            }
            else
            {
                k1 = 0;
            }
            if (checkedListBox1.GetItemChecked(1))
            {
                k2 = 1;
            }
            else
            {
                k2 = 0;
            }
            /*if (checkedListBox1.GetItemChecked(2))
            {
                k3 = 1;
            }
            else
            {
                k3 = 0;
            }*/
            k3 = 0;
            SqlConnection conn = new SqlConnection("server=.;database=ErYingDatabase; uid=sa; pwd=9876543q");
            if (conn.State != ConnectionState.Open)
            {
                conn.Open();
            }
            SqlCommand sqlcmd = new SqlCommand();
            sqlcmd.Connection = conn;
            sqlcmd.CommandText = "update ClientTable set ClientRight1='" + k1.ToString() + "',ClientRight2='" + k2.ToString() + "',ClientRight3='" + k3.ToString() + "'where Clientname='" + textBox30.Text + "'";
            sqlcmd.CommandType = CommandType.Text;
            try
            {
                sqlcmd.ExecuteNonQuery();
                label57.Text = ("提示:用户" + textBox30.Text + "权限修改成功！");

            }
            catch (Exception ex)
            {
                label57.Text = "提示：操作错误，权限修改失败！！！";
                MessageBox.Show(ex.Message);
            }
        }

        private void button16_Click(object sender, EventArgs e)
        {
            SqlConnection conn = new SqlConnection("server=.;database=ErYingDatabase; uid=sa; pwd=9876543q");
            if (conn.State != ConnectionState.Open)
            {
                conn.Open();
            }
            SqlCommand sqlcmd = new SqlCommand();
            sqlcmd.Connection = conn;
            sqlcmd.CommandText = "delete from ClientTable where Clientname='" + textBox30.Text + "'";
            sqlcmd.CommandType = CommandType.Text;
            try
            {
                sqlcmd.ExecuteNonQuery();
                label57.Text = ("提示:用户" + textBox30.Text + "数据删除成功！");
                
            }
            catch (Exception ex)
            {
                label57.Text = "提示：操作错误，数据删除失败！！！";
                MessageBox.Show(ex.Message);
            }
        }

        private void label20_Click(object sender, EventArgs e)
        {

        }

        private void button19_Click_1(object sender, EventArgs e)
        {
            //Stream aa;
            OpenFileDialog openFileDialog1=new OpenFileDialog() ;
             openFileDialog1.Filter = "*jpg|*.JPG|*.GIF|*.GIF|*.BMP|*.BMP|*.png|*.PNG";             
            if(openFileDialog1.ShowDialog()==DialogResult.OK)             
            {                
                string fullpath =openFileDialog1.FileName;//文件路径     
                
                //aa = openFileDialog1.OpenFile();
                FileStream fs = new FileStream(fullpath, FileMode.Open );
                imagebytes = new byte[fs.Length];
                BinaryReader br = new BinaryReader(fs);
                imagebytes = br.ReadBytes(Convert.ToInt32(fs.Length));
                fs.Close();
                pictureBox1.Load(fullpath);
               // ST_experience .Text =pictureBox1.AccessibilityObject.Value.ToString();
                //
                if (pictureBox1.Image != null)
                {
                    pictureBox1.Image.Save("tem.dat");
                   
                    //Image picimage = pictureBox1.Image;
                    //ST_experience.Text = imagebytes.ToString();
                   // SqlParameter sp[13] = new SqlParameter("@BookImage", imagebytes);
                }
                //                 
                //BinaryReader br = new BinaryReader(fs);                  
                //imagebytes = br.ReadBytes(Convert.ToInt32(fs.Length));
                
            }
        }

        private void label38_Click(object sender, EventArgs e)
        {

        }

        private void tabPage11_Click(object sender, EventArgs e)
        {

        }

        private void button24_Click(object sender, EventArgs e)
        {
            PaiGangClass PaiGang = new PaiGangClass();
            PaiGang.PaiGang();
        }

        private void label11_Click(object sender, EventArgs e)
        {

        }

        private void button18_Click_1(object sender, EventArgs e)
        {

        }

        private void dateTimePicker2_ValueChanged(object sender, EventArgs e)
        {

        }

        private void checkBox1_CheckedChanged(object sender, EventArgs e)
        {
            if (checkBox1.CheckState == CheckState.Checked)
                ST_terms.Enabled = false ;
            else
                ST_terms.Enabled = true ;
        }

        private void checkBox2_CheckedChanged(object sender, EventArgs e)
        {
            if (checkBox2.CheckState == CheckState.Checked)
                ST_subject.Enabled = false;
            else
                ST_subject.Enabled = true;
        }

        private void checkBox3_CheckedChanged(object sender, EventArgs e)
        {
            if (checkBox3.CheckState == CheckState.Checked)
                ST_majors.Enabled = false;
            else
                ST_majors.Enabled = true;
        }

        private void All_breakrule_TextChanged(object sender, EventArgs e)
        {

        }

        private void button28_Click(object sender, EventArgs e)
        {
                    if (string.IsNullOrEmpty(Eq_name.Text))
                    {
                        label57.Text = ("提示：请先将装备名称补充完整！");
                        return;
                    }
            SqlConnection conn = new SqlConnection("server=.;database=ErYingDatabase; uid=sa; pwd=9876543q");
            if (conn.State != ConnectionState.Open)
            {
                conn.Open();
            }
            SqlCommand sqlcmd = new SqlCommand();
            sqlcmd.Connection = conn;
            sqlcmd.CommandText = "insert Eq_Information ( Eq_type,Eq_name,Eq_model,Eq_color,Eq_num,Eq_engine,Eq_underpan,Eq_resource,Eq_factoryDate,Eq_distribute,Eq_repair,Eq_remark)values"
               + "('" + Eq_type.Text.Trim() + "','" + Eq_name.Text.Trim() + "','" + Eq_model.Text.Trim() + "','" + Eq_color.Text.Trim() + "','" + Eq_num.Text.Trim() + "','" + Eq_engine.Text.Trim() + "','" + Eq_underpan.Text.Trim()
                + "','" + Eq_resource.Text.Trim() + "','" + Eq_factoryDate.Text.Trim() + "','" + Eq_distributeDate.Text.Trim() + "','" + Eq_repair.Text.Trim() + "','" + Eq_remark.Text.Trim()+ "')";
            sqlcmd.CommandType = CommandType.Text;
            try
            {

                sqlcmd.ExecuteNonQuery();
                label57.Text = ("提示:装备" + Eq_name.Text + "数据添加成功！");
                SqlDataAdapter sda1 = new SqlDataAdapter("select Eq_type as '装备类别',Eq_name as '装备名称',Eq_model as '装备型号',Eq_color as '车辆颜色',Eq_num as '装备编号',Eq_engine as '发动机号',Eq_underpan as '底盘号',Eq_resource as '配发来源',Eq_factoryDate as '出厂时间',Eq_distribute as '配发时间',Eq_repair as '整修情况',Eq_remark as '备注',Eq_ID from Eq_Information ", conn);
                DataSet ds1 = new DataSet();
                sda1.Fill(ds1, "emp");
                dataGridView4.DataSource = ds1.Tables[0];
            }
            catch (Exception ex)
            {
                label57.Text = "提示：操作错误，数据录入失败！！！";
                MessageBox.Show(ex.Message);
                if (conn.State != ConnectionState.Open)
                {
                    conn.Dispose(); conn.Dispose();
                }
            }

        }

        private void button25_Click(object sender, EventArgs e)
        {
            if (string.IsNullOrEmpty(Eq_name.Text))
            {
                label57.Text = ("提示：请先将装备名称补充完整！");
                return;
            }
            //if (ST_birth.ForeColor == Color.Gray)
            //{
            //  label57.Text = ("提示：请先将数据补充完整！");
            //return;
            //}
            SqlConnection conn = new SqlConnection("server=.;database=ErYingDatabase; uid=sa; pwd=9876543q");
            if (conn.State != ConnectionState.Open)
            {
                conn.Open();
            }
            SqlCommand sqlcmd = new SqlCommand();
            sqlcmd.Connection = conn;
            sqlcmd.CommandText = "update Eq_Information set Eq_type='" + Eq_type.Text.Trim() + "',Eq_name='" + Eq_name.Text.Trim()
                + "',Eq_model='" + Eq_model.Text.Trim() + "',Eq_color='" + Eq_color.Text.Trim()
                + "',Eq_num='" + Eq_num.Text.Trim() + "',Eq_engine='" + Eq_engine.Text.Trim() + "',Eq_underpan='" + Eq_underpan.Text.Trim()
                + "',Eq_resource='" + Eq_resource.Text.Trim() + "',Eq_factoryDate='" + Eq_factoryDate.Text.Trim() + "',Eq_distribute='" + Eq_distributeDate.Text.Trim()
                + "',Eq_repair='" + Eq_repair.Text.Trim() + "',Eq_remark='" + Eq_remark.Text.Trim()+ "'";
            sqlcmd.CommandType = CommandType.Text;
            try
            {
                sqlcmd.ExecuteNonQuery();
                label57.Text = ("提示:装备" + Eq_name.Text + "数据修改成功！");
                SqlDataAdapter sda1 = new SqlDataAdapter("select Eq_type as '装备类别',Eq_name as '装备名称',Eq_model as '装备型号',Eq_color as '车辆颜色',Eq_num as '装备编号',Eq_engine as '发动机号',Eq_underpan as '底盘号',Eq_resource as '配发来源',Eq_factoryDate as '出厂时间',Eq_distribute as '配发时间',Eq_repair as '整修情况',Eq_remark as '备注',Eq_ID from Eq_Information ", conn);
                DataSet ds1 = new DataSet();
                sda1.Fill(ds1, "emp");
                dataGridView4.DataSource = ds1.Tables[0];
            }
            catch (Exception ex)
            {
                label57.Text = "提示：操作错误，数据修改失败！！！";
                MessageBox.Show(ex.Message);
                if (conn.State != ConnectionState.Open)
                {
                    conn.Dispose(); conn.Dispose();
                }
            }
        }

        private void button26_Click(object sender, EventArgs e)
        {
            if (Eq_name.Text.Trim() == "")
            {
                label57.Text = ("提示：请先将装备名称补充完整！");
                return;
            }
            SqlConnection conn = new SqlConnection("server=.;database=ErYingDatabase; uid=sa; pwd=9876543q");
            if (conn.State != ConnectionState.Open)
            {
                conn.Open();
            }
            SqlCommand sqlcmd = new SqlCommand();
            sqlcmd.Connection = conn;
            sqlcmd.CommandText = "delete from Eq_Information where Eq_name='" + Eq_name.Text.Trim() + "' and Eq_num='"+Eq_num .Text .Trim ()+"'";
            sqlcmd.CommandType = CommandType.Text;
            try
            {
                sqlcmd.ExecuteNonQuery();
                label57.Text = ("提示:装备" + Eq_name.Text + "数据删除成功！");
                SqlDataAdapter sda1 = new SqlDataAdapter("select Eq_type as '装备类别',Eq_name as '装备名称',Eq_model as '装备型号',Eq_color as '车辆颜色',Eq_num as '装备编号',Eq_engine as '发动机号',Eq_underpan as '底盘号',Eq_resource as '配发来源',Eq_factoryDate as '出厂时间',Eq_distribute as '配发时间',Eq_repair as '整修情况',Eq_remark as '备注',Eq_ID from Eq_Information ", conn);
                DataSet ds1 = new DataSet();
                sda1.Fill(ds1, "emp");
                dataGridView4.DataSource = ds1.Tables[0];
            }
            catch (Exception ex)
            {
                label57.Text = "提示：操作错误，数据删除失败！！！";
                MessageBox.Show(ex.Message);
            }

        }

        private void button29_Click(object sender, EventArgs e)
        {
            if (comboBox6.Text == "所有装备")
            {
                //SqlConnection conn = new SqlConnection();
                SqlConnection sqlConn = new SqlConnection("server=.;database=ErYingDatabase; uid=sa; pwd=9876543q");
                SqlDataAdapter sda = new SqlDataAdapter("select Eq_type as '装备类别',Eq_name as '装备名称',Eq_model as '装备型号',Eq_color as '车辆颜色',Eq_num as '装备编号',Eq_engine as '发动机号',Eq_underpan as '底盘号',Eq_resource as '配发来源',Eq_factoryDate as '出厂时间',Eq_distribute as '配发时间',Eq_repair as '整修情况',Eq_remark as '备注',Eq_ID from Eq_Information "
                     , sqlConn);
                DataSet ds = new DataSet();
                sda.Fill(ds, "emp");
                dataGridView4.DataSource = ds.Tables[0];
            }
            else
            {
                    //SqlConnection conn = new SqlConnection();
                    SqlConnection sqlConn = new SqlConnection("server=.;database=ErYingDatabase; uid=sa; pwd=9876543q");
                    SqlDataAdapter sda = new SqlDataAdapter(
                        "select Eq_type as '装备类别',Eq_name as '装备名称',Eq_model as '装备型号',Eq_color as '车辆颜色',Eq_num as '装备编号',Eq_engine as '发动机号',Eq_underpan as '底盘号',Eq_resource as '配发来源',Eq_factoryDate as '出厂时间',Eq_distribute as '配发时间',Eq_repair as '整修情况',Eq_remark as '备注',Eq_ID from Eq_Information  where Eq_name='" +
                        comboBox6.Text + "'", sqlConn);
                    DataSet ds = new DataSet();
                    try
                    {
                        sda.Fill(ds, "emp");
                        dataGridView4.DataSource = ds.Tables[0];
                        if (sqlConn.State != ConnectionState.Open)
                        {
                            sqlConn.Dispose(); sqlConn.Dispose();
                        }
                    }
                    catch (Exception ex)
                    {
                        label57.Text = "提示：操作错误，数据查找失败！！！";
                        MessageBox.Show(ex.Message);
                        if (sqlConn.State != ConnectionState.Open)
                        {
                            sqlConn.Dispose(); sqlConn.Dispose();
                        }
                    }


               
               
            }
        }

        private void comboBox4_SelectedIndexChanged(object sender, EventArgs e)
        {

        }

        private void comboBox6_MouseClick(object sender, MouseEventArgs e)
        {
            SqlConnection sqlConn = new SqlConnection("server=.;database=ErYingDatabase; uid=sa; pwd=9876543q");


                SqlDataAdapter sda4 = new SqlDataAdapter("select distinct Eq_name from Eq_Information", sqlConn);
                DataSet ds1 = new DataSet();
                sda4.Fill(ds1, "emp");

                comboBox6.DataSource = ds1.Tables[0];
                comboBox6.DisplayMember = "Eq_name";
            comboBox6.Text = "所有装备";
        
        }

        private void comboBox6_SelectedIndexChanged(object sender, EventArgs e)
        {

        }

        private void dataGridView4_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {
            if (dataGridView4.SelectedCells.Count != 0)
            {


                //得到选中行某列的值
                //string str = dataGridView1.CurrentRow.Cells[2].Value.ToString();
                Eq_type.Text = dataGridView4.CurrentRow.Cells[0].Value.ToString();
                Eq_name.Text = dataGridView4.CurrentRow.Cells[1].Value.ToString();
                Eq_model.Text = dataGridView4.CurrentRow.Cells[2].Value.ToString();
                Eq_color.Text = dataGridView4.CurrentRow.Cells[3].Value.ToString();
                Eq_num.Text = dataGridView4.CurrentRow.Cells[4].Value.ToString();
                Eq_engine.Text = dataGridView4.CurrentRow.Cells[5].Value.ToString();
                Eq_underpan.Text = dataGridView4.CurrentRow.Cells[6].Value.ToString();
                Eq_resource.Text = dataGridView4.CurrentRow.Cells[7].Value.ToString();
                Eq_factoryDate.Text = dataGridView4.CurrentRow.Cells[8].Value.ToString();
                Eq_distributeDate.Text = dataGridView4.CurrentRow.Cells[9].Value.ToString();
                Eq_repair.Text = dataGridView4.CurrentRow.Cells[10].Value.ToString();
                Eq_remark.Text = dataGridView4.CurrentRow.Cells[11].Value.ToString();
               
            }
        }

        private void dataGridView1_CellContentClick_1(object sender, DataGridViewCellEventArgs e)
        {

        }

        private void dataGridView4_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            if (dataGridView4.SelectedCells.Count != 0)
            {


                //得到选中行某列的值
                //string str = dataGridView1.CurrentRow.Cells[2].Value.ToString();
                Eq_type.Text = dataGridView4.CurrentRow.Cells[0].Value.ToString();
                Eq_name.Text = dataGridView4.CurrentRow.Cells[1].Value.ToString();
                Eq_model.Text = dataGridView4.CurrentRow.Cells[2].Value.ToString();
                Eq_color.Text = dataGridView4.CurrentRow.Cells[3].Value.ToString();
                Eq_num.Text = dataGridView4.CurrentRow.Cells[4].Value.ToString();
                Eq_engine.Text = dataGridView4.CurrentRow.Cells[5].Value.ToString();
                Eq_underpan.Text = dataGridView4.CurrentRow.Cells[6].Value.ToString();
                Eq_resource.Text = dataGridView4.CurrentRow.Cells[7].Value.ToString();
                Eq_factoryDate.Text = dataGridView4.CurrentRow.Cells[8].Value.ToString();
                Eq_distributeDate.Text = dataGridView4.CurrentRow.Cells[9].Value.ToString();
                Eq_repair.Text = dataGridView4.CurrentRow.Cells[10].Value.ToString();
                Eq_remark.Text = dataGridView4.CurrentRow.Cells[11].Value.ToString();

            }
            SqlConnection sqlConn = new SqlConnection("server=.;database=ErYingDatabase; uid=sa; pwd=9876543q");
            SqlDataAdapter sda = new SqlDataAdapter("select Eq_outDate as '出库日期',Eq_inDate as '入库日期',Eq_event as '事由',Eq_principal as '负责人' from Eq_move where Eq_Id='"
                + dataGridView4.CurrentRow.Cells[12].Value.ToString()+"'"
                 , sqlConn);
            DataSet ds = new DataSet();
            sda.Fill(ds, "emp");
            dataGridView5.DataSource = ds.Tables[0];

        }

        private void button30_Click(object sender, EventArgs e)
        {
            SqlConnection conn = new SqlConnection("server=.;database=ErYingDatabase; uid=sa; pwd=9876543q");
            if (conn.State != ConnectionState.Open)
            {
                conn.Open();
            }
            SqlCommand sqlcmd = new SqlCommand();
            sqlcmd.Connection = conn;
            sqlcmd.CommandText = "insert Eq_Move ( Eq_outDate,Eq_inDate,Eq_ID,Eq_event,Eq_principal)values"
               + "('" + Eq_outDate.Value.Year.ToString() + "-" + Eq_outDate.Value.Month.ToString() + "-" 
               + Eq_outDate.Value.Day.ToString() + "','" + Eq_inDate.Value.Year.ToString() + "-" 
               + Eq_inDate.Value.Month.ToString() + "-" + Eq_inDate.Value.Day.ToString() + "','" + dataGridView4.CurrentRow.Cells[12].Value.ToString() + "','" + Eq_event.Text.Trim() + "','" + Eq_principal.Text.Trim() + "')";
            sqlcmd.CommandType = CommandType.Text;
            try
            {
                sqlcmd.ExecuteNonQuery();

                SqlDataAdapter sda = new SqlDataAdapter("select Eq_outDate as '出库日期',Eq_inDate as '入库日期',Eq_event as'事由',Eq_principal as'负责人' from Eq_move where Eq_ID='"
                    + dataGridView4.CurrentRow.Cells[12].Value.ToString() + "'", conn);
                DataSet ds = new DataSet();
                sda.Fill(ds, "emp");
                dataGridView5.DataSource = ds.Tables[0];
                label57.Text = ("提示:装备出入库数据添加成功！");

            }
            catch (Exception ex)
            {
                label57.Text = "提示：操作错误，数据添加失败！！！";
                MessageBox.Show(ex.Message);
            }
        }

        private void dataGridView4_Click(object sender, EventArgs e)
        {

        }

        private void button31_Click(object sender, EventArgs e)
        {
            SqlConnection conn = new SqlConnection("server=.;database=ErYingDatabase; uid=sa; pwd=9876543q");
            if (conn.State != ConnectionState.Open)
            {
                conn.Open();
            }
            SqlCommand sqlcmd = new SqlCommand();
            sqlcmd.Connection = conn;
            string  d1 = Convert .ToDateTime (dataGridView5.CurrentRow.Cells[0].Value.ToString()).ToString ("yyyy-MM-dd");
            string  d2 =  Convert.ToDateTime(dataGridView5.CurrentRow.Cells[1].Value.ToString()).ToString ("yyyy-MM-dd");
            sqlcmd.CommandText = "delete from Eq_move where Eq_outDate='"+
                d1  +"'and Eq_inDate='"
            + d2+ "' and Eq_ID='"+ 
                dataGridView4.CurrentRow.Cells[12].Value.ToString() + "'and Eq_event='" +
               dataGridView5.CurrentRow.Cells[2].Value.ToString()+"'";
            sqlcmd.CommandType = CommandType.Text;
            try
            {
                sqlcmd.ExecuteNonQuery();
                label57.Text = ("提示:出库日期为" + dataGridView5.CurrentRow.Cells[0].Value +  "的数据删除成功！");
                dataGridView5.CurrentCell.Dispose();
            }
            catch (Exception ex)
            {
                label57.Text = "提示：操作错误，数据删除失败！！！";
                MessageBox.Show(ex.Message);
            }
        }

        private void dataGridView5_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {

        }

        private void StudyTraining()
        {
            string str1, str2, str3;
            if (radioButton4.Checked == true)
            {
                str3 = "ST_Num";
            }
            else
            {
                str3 = "ST_name";
            }
            if (radioButton5.Checked == true)//判断是学习还是训练
            {
                str1 = "ST_Study"; str2 = "ST_studysubject";
            }
            else
            {
                str1 = "ST_Training"; str2 = "ST_trainsubject";
            }
            //判断各种选择
            bool flag_time, flag_subject, flag_major, flag_person;
            flag_time= flag_subject= flag_major= flag_person=false ;
            if (checkBox1.CheckState ==CheckState.Checked) flag_time = false;
            else flag_time = true;//如果是所有时间，flag_time 就是false
            if (checkBox2.CheckState == CheckState.Checked) flag_subject = false;
            else flag_subject = true;//如果是所有科目，flag_subject就是false
            if (checkBox3.CheckState == CheckState.Checked) flag_major = false;
            else flag_major = true;//如果是所有专业，flag_major 就是false
            if ("所有人员".Equals(comboBox3.Text.Trim())) flag_person = false;
            else flag_person = true ;
            SqlConnection sqlConn = new SqlConnection("server=.;database=ErYingDatabase; uid=sa; pwd=9876543q");
            SqlDataAdapter sda=null ;
            if (flag_time&& flag_subject&& flag_major && flag_person)//全是所有
            {
                try
                {
                    sda = new SqlDataAdapter(
                        "select SU.ST_term as '时间', ST.ST_Num as '编号', ST.ST_name as '姓名',SU.ST_subject as '科目名称'， SU.ST_result as '成绩'from (select*from ST_Information)as ST left outer join "
                        + str1 + "as SU on ST.ST_Num=SU.ST_Num order by SU.ST_term", sqlConn);
                    
                }
                catch { }
            }
            else if (flag_subject && flag_major && flag_person)//时间有值
            {
                try
                {
                    sda = new SqlDataAdapter(
                        "select SU.ST_term as '时间', ST.ST_Num as '编号', ST.ST_name as '姓名', SU.ST_subject as '科目名称'，SU.ST_result as '成绩'from (select*from ST_Information)as ST left outer join " 
                        + str1 + "as SU on ST.ST_Num=SU.ST_Num and SU.ST_term="
                    + ST_terms.Text .Trim ()+" order by ST.ST_Num", sqlConn);

                }
                catch { }
            }
            else if (flag_time && flag_subject && flag_major)//人有值
            {
                try
                {
                    sda = new SqlDataAdapter(
                        "select SU.ST_term as '时间', ST.ST_Num as '编号', ST.ST_name as '姓名',SU.ST_subject as '科目名称'，SU.ST_result as '成绩'from (select*from ST_Information where " 
                        + comboBox3 .Text .Trim ()+ "="+str3 +")as ST left outer join "
                    + str1 + "as SU on ST.ST_Num=SU.ST_Num order by ST.ST_Num", sqlConn);//先到这

                }
                catch { }
            }
            else if (flag_time && flag_subject && flag_person)//专业有值
            {
                try
                {
                    sda = new SqlDataAdapter("select SU.ST_term as '时间', ST.ST_Num as '编号', ST.ST_name as '姓名', SU.ST_result as'"
                    + ST_subject.Text.Trim() + "成绩'from (select*from ST_Information where ST_major="+ ST_majors .Text .Trim ()+ ")as ST left outer join " + str1 + "as SU on ST.ST_Num=SU.ST_Num and SU.ST_term="
                    + ST_terms.Text.Trim() + " order by ST.ST_Num", sqlConn);

                }
                catch { }
            }
            else if (flag_time && flag_major && flag_person)//科目有值
            {
                try
                {
                    sda = new SqlDataAdapter("select SU.ST_term as '时间', ST.ST_Num as '编号', ST.ST_name as '姓名', SU.ST_result as'"
                    + ST_subject.Text.Trim() + "成绩'from (select*from ST_Information where ST_major=" + ST_majors.Text.Trim() + ")as ST left outer join " + str1 + "as SU on ST.ST_Num=SU.ST_Num and SU.ST_term="
                    + ST_terms.Text.Trim() + " order by ST.ST_Num", sqlConn);

                }
                catch { }
            }
            else if (flag_time && flag_major)//时间和专业是所有值
            {
                try
                {
                    sda = new SqlDataAdapter(
                        "select SU.ST_term as '时间', ST.ST_Num as '编号', ST.ST_name as '姓名',SU.ST_subject as '科目名称'， SU.ST_result as '成绩'from (select*from ST_Information)as ST left outer join "
                        + str1 + "as SU on ST.ST_Num=SU.ST_Num order by SU.ST_term", sqlConn);

                }
                catch { }
            }
            else if (flag_major && flag_person)//专业和人员是所有值
            {
                try
                {
                    sda = new SqlDataAdapter(
                        "select SU.ST_term as '时间', ST.ST_Num as '编号', ST.ST_name as '姓名',SU.ST_subject as '科目名称'， SU.ST_result as '成绩'from (select*from ST_Information)as ST left outer join "
                        + str1 + "as SU on ST.ST_Num=SU.ST_Num order by SU.ST_term", sqlConn);

                }
                catch { }
            }
            else if (flag_time && flag_subject)//时间和科目是所有值
            {
                try
                {
                    sda = new SqlDataAdapter(
                        "select SU.ST_term as '时间', ST.ST_Num as '编号', ST.ST_name as '姓名',SU.ST_subject as '科目名称'， SU.ST_result as '成绩'from (select*from ST_Information)as ST left outer join "
                        + str1 + "as SU on ST.ST_Num=SU.ST_Num order by SU.ST_term", sqlConn);

                }
                catch { }
            }
            else if (flag_subject && flag_person)//科目和人员是所有值
            {
                try
                {
                    sda = new SqlDataAdapter(
                        "select SU.ST_term as '时间', ST.ST_Num as '编号', ST.ST_name as '姓名',SU.ST_subject as '科目名称'， SU.ST_result as '成绩'from (select*from ST_Information)as ST left outer join "
                        + str1 + "as SU on ST.ST_Num=SU.ST_Num order by SU.ST_term", sqlConn);

                }
                catch { }
            }
            else if (flag_subject && flag_major)//科目和专业是所有值
            {
                try
                {
                    sda = new SqlDataAdapter(
                        "select SU.ST_term as '时间', ST.ST_Num as '编号', ST.ST_name as '姓名',SU.ST_subject as '科目名称'， SU.ST_result as '成绩'from (select*from ST_Information)as ST left outer join "
                        + str1 + "as SU on ST.ST_Num=SU.ST_Num order by SU.ST_term", sqlConn);

                }
                catch { }
            }
            else if (flag_time && flag_person)//时间和科目是所有值
            {
                try
                {
                    sda = new SqlDataAdapter(
                        "select SU.ST_term as '时间', ST.ST_Num as '编号', ST.ST_name as '姓名',SU.ST_subject as '科目名称'， SU.ST_result as '成绩'from (select*from ST_Information)as ST left outer join "
                        + str1 + "as SU on ST.ST_Num=SU.ST_Num order by SU.ST_term", sqlConn);

                }
                catch { }
            }
            else if (flag_time)//仅时间是所有值
            {
                try
                {
                    sda = new SqlDataAdapter(
                        "select SU.ST_term as '时间', ST.ST_Num as '编号', ST.ST_name as '姓名',SU.ST_subject as '科目名称'， SU.ST_result as '成绩'from (select*from ST_Information)as ST left outer join "
                        + str1 + "as SU on ST.ST_Num=SU.ST_Num order by SU.ST_term", sqlConn);

                }
                catch { }
            }
            else if (flag_person)//仅人员是所有值
            {
                try
                {
                    sda = new SqlDataAdapter(
                        "select SU.ST_term as '时间', ST.ST_Num as '编号', ST.ST_name as '姓名',SU.ST_subject as '科目名称'， SU.ST_result as '成绩'from (select*from ST_Information)as ST left outer join "
                        + str1 + "as SU on ST.ST_Num=SU.ST_Num order by SU.ST_term", sqlConn);

                }
                catch { }
            }
            else if (flag_major)//仅专业是所有值
            {
                try
                {
                    sda = new SqlDataAdapter(
                        "select SU.ST_term as '时间', ST.ST_Num as '编号', ST.ST_name as '姓名',SU.ST_subject as '科目名称'， SU.ST_result as '成绩'from (select*from ST_Information)as ST left outer join "
                        + str1 + "as SU on ST.ST_Num=SU.ST_Num order by SU.ST_term", sqlConn);

                }
                catch { }
            }
            else if (flag_subject)//仅科目是所有值
            {
                try
                {
                    sda = new SqlDataAdapter(
                        "select SU.ST_term as '时间', ST.ST_Num as '编号', ST.ST_name as '姓名',SU.ST_subject as '科目名称'， SU.ST_result as '成绩'from (select*from ST_Information)as ST left outer join "
                        + str1 + "as SU on ST.ST_Num=SU.ST_Num order by SU.ST_term", sqlConn);

                }
                catch { }
            }
            else//全都有值
            {
                try
                {
                    sda = new SqlDataAdapter(
                        "select SU.ST_term as '时间', ST.ST_Num as '编号', ST.ST_name as '姓名',SU.ST_subject as '科目名称'， SU.ST_result as '成绩'from (select*from ST_Information)as ST left outer join "
                        + str1 + "as SU on ST.ST_Num=SU.ST_Num order by SU.ST_term", sqlConn);

                }
                catch { }
            }
            try
            {
                DataSet ds = new DataSet();
                sda.Fill(ds, "emp");
                dataGridView2.DataSource = ds.Tables[0];
            }
            catch { }
            


        }
    }
}
