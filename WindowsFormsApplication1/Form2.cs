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
using System.Diagnostics;




namespace WindowsFormsApplication1
{
    public partial class Form2 : Form
    {
        public string name, time;
        public byte[] imagebytes=null ;
        string ipAdress = ".";
        
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
            try
            {
                StreamReader sr = new StreamReader("IPAdress.txt");
                //调用ReadToEnd方法读取选中文件的全部内容
                ipAdress = sr.ReadToEnd();
                TextBox t1 = new TextBox ();
                t1.Text = ipAdress;
                ipAdress = t1.Text.Trim();
                sr.Close();//关闭当前文件读取流
            }
            catch
            {
            }
            
            label53.Text = "当前用户名：" + name+ "  登录时间：" + time;
            label57.Text = "提示：欢迎！";
            textBox30.Text = name;
            string str = "server=" + ipAdress + ";database=ErYingDatabase; uid=sa; pwd=9876543q";
            //MessageBox.Show(ipAdress);
            SqlConnection sqlConn = new SqlConnection(str );
/*

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
            }*/
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
                button43.Visible = false;
                button4.Visible = false; button6.Visible = false; button7.Visible = false;
                button5.Visible = false;
                //button13.Visible = false;
                button21.Visible = false;
                button14.Visible = false; button15.Visible = false; groupBox6.Visible = false;
                groupBox8 .Visible = false;
                button40.Visible = false;
                button47.Visible = false;
                button39.Visible = false;
                button42.Visible = false;
                button41.Visible = false;
                button33.Visible = false;
                button27.Visible = false;
                button34.Visible = false;
                button32.Visible = false;
                button45.Visible = false;
                button44.Visible = false;
                button24.Visible = false;
               
                
            }
            if (ds2.Tables[0].Rows[0][3].ToString() == "0")
            {
                button12.Visible = false; button16.Visible = false; checkedListBox1.Visible = false;
                label50.Visible = false;
            }
            //加载界面信息
            SetLeaveBack();
            SetLeaveBackColor();
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
            /*foreach (Control c in tabPage5.Controls)
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

            SqlConnection conn = new SqlConnection("server="+ipAdress+";database=ErYingDatabase; uid=sa; pwd=9876543q");
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
                SqlDataAdapter sda1 = new SqlDataAdapter("select ST_name as '姓名',ST_sex as '性别',ST_race as '民族',ST_birth as '出生年月',ST_jiguan as '籍贯',ST_major as '专业',ST_Num as '证件号',ST_PreSchool as '所属班排',ST_IDNum as '身份证号',ST_polID as '政治面貌',ST_isonlychild as '职务',ST_QorS as '干部/士兵/义务兵',ST_address as '现居住地',ST_experience as '个人经历', from ST_Information ", conn);
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
            */
            AddUpdateData();
            SetPeopleColor1();


        }

        private void button22_Click(object sender, EventArgs e)
        {
            foreach (Control c in tabPage5.Controls)
            {
                if (c is TextBox)
                {
                    if (string.IsNullOrEmpty((c as TextBox).Text))
                    {
                        label57.Text = "提示：请先将数据补充完整！";
                        return ;
                    }
                }
            }
            //if (ST_birth.ForeColor == Color.Gray)
            //{
              //  label57.Text = ("提示：请先将数据补充完整！");
                //return;
            //}
            SqlConnection conn = new SqlConnection("server="+ipAdress+";database=ErYingDatabase; uid=sa; pwd=9876543q");
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
                SqlDataAdapter sda1 = new SqlDataAdapter("select ST_name as '姓名',ST_sex as '性别',ST_race as '民族',ST_birth as '出生年月',ST_jiguan as '籍贯',ST_major as '专业',ST_Num as '证件号',ST_PreSchool as '所属班排',ST_IDNum as '身份证号',ST_polID as '政治面貌',ST_isonlychild as '职务',ST_QorS as '干部/士兵/义务兵',ST_address as '现居住地',ST_experience as '个人经历', from ST_Information ", conn);
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
                ST_birth.Text = "例如：1995/08";
               ST_birth.ForeColor = Color.Gray;
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
                SqlConnection sqlConn = new SqlConnection("server="+ipAdress+";database=ErYingDatabase; uid=sa; pwd=9876543q");
                //string str = "Select ST_name as '姓名',ST_Num as '证件号',ST_sex as '性别',ST_birth as '出生时间',ST_race as '民族',ST_jiguan,ST_IDNum," +
                        //"ST_QorS,ST_polID,ST_address,ST_major,ST_isonlychild,ST_experience,ST_PreSchool," +
                        //"InArmy,Grade,PartyTime,IsMarry,IsPregnant,VacationPlan,Family,Family_Mobile,Education,BloodType " +
                        //"from ST_Information where ST_Num='" + dataGridView1.CurrentRow.Cells[1].Value.ToString() + "'";
                //ST_experience.Text = str;
                //DataSet t = SelectSQL(str);
                SqlDataAdapter sda = new SqlDataAdapter("select ST_name as '姓名',ST_Num as '证件号',ST_PreSchool as '所属班排',ST_IDNum as '身份证号' from ST_Information "
                     , sqlConn);
                DataSet ds = new DataSet();
                sda.Fill(ds, "emp");
                dataGridView1.DataSource = ds.Tables[0];
                SetPeopleColor1();
            }
            else
            {
                if (radioButton1.Checked == true)
                {


                    //SqlConnection conn = new SqlConnection();
                    SqlConnection sqlConn = new SqlConnection("server="+ipAdress+";database=ErYingDatabase; uid=sa; pwd=9876543q");
                    SqlDataAdapter sda = new SqlDataAdapter("select ST_name as '姓名',ST_Num as '证件号',ST_PreSchool as '所属班排',ST_IDNum as '身份证号' from ST_Information where ST_Num='"+
                        comboBox4.Text + "'", sqlConn);
                    DataSet ds = new DataSet();
                    try
                    {
                        sda.Fill(ds, "emp");
                        dataGridView1.DataSource = ds.Tables[0];
                        SetPeopleColor1();
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
                    SqlConnection sqlConn = new SqlConnection("server="+ipAdress+";database=ErYingDatabase; uid=sa; pwd=9876543q");
                    SqlDataAdapter sda = new SqlDataAdapter("select ST_name as '姓名',ST_Num as '证件号',ST_PreSchool as '所属班排',ST_IDNum as '身份证号' from ST_Information where ST_name='" +
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
            foreach (Control c in tabPage5.Controls)
            {
                if (c is TextBox)
                {
                    c.Text = "无";
                }
            }
            if (dataGridView1.SelectedCells.Count != 0)
            {

                //得到选中行某列的值
                //string str = dataGridView1.CurrentRow.Cells[2].Value.ToString();
                
                try
                {
                    string str= "Select ST_name,ST_sex,ST_birth,ST_race,ST_jiguan,ST_Num,ST_IDNum," +
                        "ST_QorS,ST_polID,ST_address,ST_major,ST_isonlychild,ST_experience,ST_PreSchool," +
                        "InArmy,Grade,PartyTime,IsMarry,IsPregnant,VacationPlan,Family,Family_Mobile,Education,BloodType " +
                        "from ST_Information where ST_Num='" + dataGridView1.CurrentRow.Cells[1].Value.ToString()+"'";
                    //ST_experience.Text = str;
                    DataSet t = SelectSQL(str);
                    ST_name.Text = t.Tables[0].Rows[0][0].ToString();
                    ST_sex.Text = t.Tables[0].Rows[0][1].ToString();
                    ST_birth.Text = t.Tables[0].Rows[0][2].ToString();
                    ST_race.Text = t.Tables[0].Rows[0][3].ToString();
                    ST_jiguan.Text = t.Tables[0].Rows[0][4].ToString();
                    ST_Num.Text = t.Tables[0].Rows[0][5].ToString();
                    ST_IDNum.Text = t.Tables[0].Rows[0][6].ToString();
                    ST_QorS.Text = t.Tables[0].Rows[0][7].ToString();
                    ST_polID.Text = t.Tables[0].Rows[0][8].ToString();
                    ST_address.Text = t.Tables[0].Rows[0][9].ToString();
                    ST_major.Text = t.Tables[0].Rows[0][10].ToString();
                    ST_isonlychild.Text = t.Tables[0].Rows[0][11].ToString();
                    ST_experience.Text = t.Tables[0].Rows[0][12].ToString();
                    ST_PreSchool.Text = t.Tables[0].Rows[0][13].ToString();
                    InArmy .Text = t.Tables[0].Rows[0][14].ToString();
                    Grade .Text = t.Tables[0].Rows[0][15].ToString();
                    PartyTime.Text = t.Tables[0].Rows[0][16].ToString();
                    IsMarry .Text =t.Tables[0].Rows[0][17].ToString();
                    IsPregnant .Text = t.Tables[0].Rows[0][18].ToString();
                    VacationPlan .Text = t.Tables[0].Rows[0][19].ToString();
                    Family .Text = t.Tables[0].Rows[0][20].ToString();
                    Family_Mobile.Text  = t.Tables[0].Rows[0][21].ToString();
                    EducationLevel .Text = t.Tables[0].Rows[0][22].ToString();
                    BloodType .Text = t.Tables[0].Rows[0][23].ToString();

                }
                catch(Exception e1)
                {
                    MessageBox.Show(e1.ToString());
                }
                try
                {
                SqlConnection conn = new SqlConnection("server="+ipAdress+";database=ErYingDatabase; uid=sa; pwd=9876543q");
                
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
                    imagebytes = (byte[])sdr["ST_photo"];
                    MemoryStream ms = new MemoryStream(imagebytes);
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
                    label57.Text = "提示：操作错误，数据查找失败！！！";
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
          string table0="ST_Photos";
          string str0= " ST_Num='" + ST_Num.Text.Trim() + "'";
            try
            {
                DeleteSQL(table0, str0);//删除照片信息
            }
            catch { }
            finally
            {
                try
                {
                     table0 = "ST_study";
                    DeleteSQL(table0, str0);//删除理论学习成绩信息
                }
                catch { }
                finally
                {
                    try
                    {
                         table0 = "ST_trainning";
                        DeleteSQL(table0, str0);//删除训练成绩信息
                    }
                    catch { }
                    finally
                    {
                        try
                        {
                            table0 = "PhoneLend";
                            DeleteSQL(table0, str0);//删除人员信息
                        }
                        catch{  }
                        finally
                        {
                            try
                            {
                                table0 = "Phones";
                                DeleteSQL(table0, str0);
                            }
                            catch { }
                            finally
                            {
                                try
                                {
                                    table0 = "ST_Information";
                                    DeleteSQL(table0, str0);
                                }
                                catch(Exception e0)
                                {
                                    MessageBox.Show(e0.ToString());
                                }
                            }
                        }

                    }
                }
                SetPeopleColor1();
                
            }
           


            SqlConnection conn = new SqlConnection("server="+ipAdress+";database=ErYingDatabase; uid=sa; pwd=9876543q");
            if (conn.State != ConnectionState.Open)
            {
                conn.Open();
            }
            SqlCommand sqlcmd = new SqlCommand();
            sqlcmd.Connection = conn;
            sqlcmd.CommandText = "delete from ST_Information where ST_Num='"+ST_Num .Text .Trim ()+"'";
            sqlcmd.CommandType = CommandType.Text;
            sqlcmd.ExecuteNonQuery();
            try
            {

            }
            catch { }
            
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
                
                label57.Text = ("提示:学员" + ST_name.Text + "数据删除成功！");
                object sender1 = new object(); EventArgs e0 = new EventArgs();
                button2_Click(sender1, e0);
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
           // All_behavior.Text = dateTimePicker1.Text;
        }

        private void dateTimePicker1_ValueChanged(object sender, EventArgs e)
        {
           string data_year = dateTimePicker1.Value .Year .ToString ();
            string data_month = dateTimePicker1.Value.Month .ToString();
            string data_day = dateTimePicker1.Value.Day .ToString();
            SqlConnection conn = new SqlConnection("server="+ipAdress+";database=ErYingDatabase; uid=sa; pwd=9876543q");
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
                //All_breakrule.Text = ds.Tables[0].Rows[0][6].ToString();
                All_phone.Text = ds.Tables[0].Rows[0][6].ToString();
                All_other.Text = ds.Tables[0].Rows[0][7].ToString();
                All_zaocaoper.Text = ds.Tables[0].Rows[0][8].ToString();
                All_kaifanper.Text = ds.Tables[0].Rows[0][9].ToString();
                All_tinengper.Text = ds.Tables[0].Rows[0][10].ToString();
                All_dianmingper.Text = ds.Tables[0].Rows[0][11].ToString();
                textBox16.Text = ds.Tables[0].Rows[0][12].ToString();
                textBox17.Text = ds.Tables[0].Rows[0][13].ToString();
                textBox18.Text = ds.Tables[0].Rows[0][14].ToString();
                textBox19.Text = ds.Tables[0].Rows[0][15].ToString();
                textBox35.Text = ds.Tables[0].Rows[0][16].ToString();
                textBox34.Text = ds.Tables[0].Rows[0][17].ToString();
                textBox33.Text = ds.Tables[0].Rows[0][18].ToString();
                textBox27.Text = ds.Tables[0].Rows[0][19].ToString();
                Kitchen_guard.Text = ds.Tables[0].Rows[0][20].ToString();
                // phoneLend .Text = ds.Tables[0].Rows[0][22].ToString();
               


            }

            ShowPersonLeave();
            SetPeopleLeaveColor();


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

            SqlConnection conn = new SqlConnection("server="+ipAdress+";database=ErYingDatabase; uid=sa; pwd=9876543q");
            if (conn.State != ConnectionState.Open)
            {
                conn.Open();
            }
            SqlCommand sqlcmd = new SqlCommand();
            sqlcmd.Connection = conn;
            sqlcmd.CommandText = "insert All_Management ( All_notingtime,All_behavior,All_assignment,All_selfstudy,All_clean,All_sleeping,All_phone,All_other,All_zaocaoper,All_kaifanper,All_tinengper,All_dianmingper,All_zaocaoying,All_kaifanying,All_tinengying,All_dianmingying,All_zaocaoshi,All_kaifanshi,All_tinengshi,All_dianmingshi,Kitchen_guard)values"
               + "('" + dateTimePicker1 .Value .Year .ToString ()+"-"+dateTimePicker1 .Value .Month .ToString ()+"-"+dateTimePicker1 .Value .Day .ToString () + "','" + All_behavior.Text.Trim() + "','" + All_assignment.Text.Trim() + "','" + All_selfstudy.Text.Trim() + "','" + All_clean.Text.Trim() + "','" + All_sleeping.Text.Trim() 
                + "','" + All_phone.Text.Trim() + "','" + All_other.Text.Trim() + "','" + All_zaocaoper.Text.Trim() + "','" + All_kaifanper.Text.Trim() + "','" + All_tinengper.Text.Trim()
                 + "','" + All_dianmingper.Text.Trim() + "','"+ textBox16 .Text .Trim ()+ "','"+ textBox17.Text.Trim() + "','"+ textBox18.Text.Trim() + "','"+ textBox19.Text.Trim() + "','"+ textBox35.Text.Trim() + "','"+ textBox34.Text.Trim() + "','" + textBox33.Text.Trim() + "','" + textBox27.Text.Trim() + "','" + Kitchen_guard.Text.Trim() +"')";
            sqlcmd.CommandType = CommandType.Text;
            try
            { sqlcmd.ExecuteNonQuery();
              label57.Text = ("提示:日期 " + dateTimePicker1.Value.Year.ToString() + "年" + dateTimePicker1.Value.Month.ToString() + "月" + dateTimePicker1.Value.Day.ToString() + "日" + ST_name.Text + "数据添加成功！");

            }
            catch
            {
                try
                {

                    //SqlConnection conn = new SqlConnection("server="+ipAdress+";database=ErYingDatabase; uid=sa; pwd=9876543q");
                    if (conn.State != ConnectionState.Open)
                    {
                        conn.Open();
                    }
                    //SqlCommand sqlcmd = new SqlCommand();
                    sqlcmd.Connection = conn;
                    sqlcmd.CommandText = "update All_management set All_behavior='" + All_behavior.Text.Trim()
                        + "',All_assignment='" + All_assignment.Text.Trim() + "',All_selfstudy='" + All_selfstudy.Text.Trim()
                        + "',All_clean='" + All_clean.Text.Trim() + "',All_sleeping='" + All_sleeping.Text.Trim()
                        + "',All_phone='" + All_phone.Text.Trim() + "',All_other='" + All_other.Text.Trim() + "',All_zaocaoper='" + All_zaocaoper.Text.Trim()
                        + "',All_kaifanper='" + All_kaifanper.Text.Trim() + "',All_tinengper='" + All_tinengper.Text.Trim()
                        + "',All_dianmingper='" + All_dianmingper.Text.Trim() + "',All_zaocaoying='" + textBox16.Text.Trim() + "',All_kaifanying='" + textBox17.Text.Trim() + "',All_tinengying='" + textBox18.Text.Trim()
                         + "',All_dianmingying='" + textBox19.Text.Trim() + "',All_zaocaoshi='" + textBox35.Text.Trim() + "',All_kaifanshi='" + textBox34.Text.Trim() + "',All_tinengshi='" + textBox33.Text.Trim()
                          + "',All_dianmingshi='" + textBox27.Text.Trim() + "',Kitchen_guard='" + Kitchen_guard.Text.Trim() + "' where All_notingtime='" + dateTimePicker1.Value.Year.ToString() + "-"
                          + dateTimePicker1.Value.Month.ToString() + "-" + dateTimePicker1.Value.Day.ToString() + "'";
                    sqlcmd.CommandType = CommandType.Text;
                    try
                    {
                        sqlcmd.ExecuteNonQuery();
                        label57.Text = ("提示:日期 " + dateTimePicker1.Value.Year.ToString() + "年" + dateTimePicker1.Value.Month.ToString() + "月" + dateTimePicker1.Value.Day.ToString() + "日" + ST_name.Text + "数据更新成功！");
                    }
                    catch (Exception ex)
                    {
                        label57.Text = "提示：操作错误，数据添加或更新失败！！！";
                        MessageBox.Show(ex.Message);
                    }
                }
                catch
                {


                }
               
            }
        }

        private void button13_Click(object sender, EventArgs e)
        {
            SqlConnection conn = new SqlConnection("server="+ipAdress+";database=ErYingDatabase; uid=sa; pwd=9876543q");
            if (conn.State != ConnectionState.Open)
            {
                conn.Open();
            }
            SqlCommand sqlcmd = new SqlCommand();
            sqlcmd.Connection = conn;
            sqlcmd.CommandText = "update All_management set All_behavior='" + All_behavior.Text.Trim()
                + "',All_assignment='" + All_assignment.Text.Trim() + "',All_selfstudy='" + All_selfstudy.Text.Trim()
                + "',All_clean='" + All_clean.Text.Trim() + "',All_sleeping='" + All_sleeping.Text.Trim() 
                + "',All_phone='" + All_phone.Text.Trim() + "',All_other='" + All_other.Text.Trim() + "',All_zaocaoper='" + All_zaocaoper.Text.Trim()
                + "',All_kaifanper='" + All_kaifanper.Text.Trim() + "',All_tinengper='" + All_tinengper.Text.Trim()
                + "',All_dianmingper='" + All_dianmingper.Text.Trim() + "',All_zaocaoying='" + textBox16.Text.Trim() + "',All_kaifanying='" + textBox17.Text.Trim() + "',All_tinengying='" + textBox18.Text.Trim()
                 + "',All_dianmingying='" + textBox19.Text.Trim() + "',All_zaocaoshi='" + textBox35.Text.Trim() + "',All_kaifanshi='" + textBox34.Text.Trim() + "',All_tinengshi='" + textBox33.Text.Trim()
                  + "',All_dianmingshi='" + textBox27.Text.Trim() + "',Kitchen_guard='" + Kitchen_guard.Text.Trim()+"' where All_notingtime='" + dateTimePicker1.Value.Year.ToString() + "-"
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
            SqlConnection conn = new SqlConnection("server="+ipAdress+";database=ErYingDatabase; uid=sa; pwd=9876543q");
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
            /*string str1, str2;
            if (radioButton5.Checked == true)
            {
                str1 = "ST_Study"; str2 = "ST_studysubject";
            }
            else
            {
                str1 = "ST_Training"; str2 = "ST_trainsubject";
            }
            if (checkBox1.CheckState ==CheckState.Checked)
            if (ST_majors .Text !="选择专业")
            {
            SqlConnection sqlConn = new SqlConnection("server="+ipAdress+";database=ErYingDatabase; uid=sa; pwd=9876543q");
            SqlDataAdapter sda = new SqlDataAdapter("select ST.ST_Num as '学号', ST.ST_name as '姓名',SU.ST_result as'"
                + ST_subject.Text.Trim() + "成绩'from (select* from ST_Information  where ST_major='" + ST_majors.Text 
                + "') as ST left outer join " + str1 + " as SU on ST.ST_Num=SU.ST_Num and SU." + str2 + "='" 
                + ST_subject.Text.Trim() + "'", sqlConn);
            DataSet ds = new DataSet();
            sda.Fill(ds, "emp");
            dataGridView2.DataSource = ds.Tables[0];          
            }*/
        }

        private void comboBox3_SelectedIndexChanged(object sender, EventArgs e)
        {
            
            
            
            
            
        }

        private void tabPage6_Click(object sender, EventArgs e)
        {
            
        }

        private void button6_Click(object sender, EventArgs e)
        {
            SqlConnection conn = new SqlConnection("server="+ipAdress+";database=ErYingDatabase; uid=sa; pwd=9876543q");
            if (conn.State != ConnectionState.Open)
            {
                conn.Open();
            }
            SqlCommand sqlcmd = new SqlCommand();
            sqlcmd.Connection = conn;                
                    int i;
                    string str1, str2,str3,str4,str5,str6;
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
                if ("所有时间".Equals(ST_terms.Text.Trim())) str5 = dataGridView2.Rows[i].Cells[0].Value.ToString();
                else str5 = ST_terms.Text.Trim();
                if ("所有科目".Equals(ST_terms.Text.Trim())) str6 = dataGridView2.Rows[i].Cells[3].Value.ToString();
                else str6 = ST_subject.Text.Trim();
                str1 = dataGridView2.Rows[i].Cells[1].Value.ToString();
                        str2 = dataGridView2.Rows[i].Cells[4].Value.ToString();
                       sqlcmd.CommandText = sqlcmd.CommandText + "select"
                               + "'" + str5  + "','" + str6  + "','" + str1 + "','" + str2 +"'";
                        if (i + 1 != dataGridView2.Rows.Count-1)
                        {
                            sqlcmd.CommandText = sqlcmd.CommandText + "union ";
                        }
                    }                                          
                try
                {
                    sqlcmd.ExecuteNonQuery();
                    label57.Text = ("提示: " + ST_terms.Text.Trim() + "学期" + ST_subject.Text.Trim() + "成绩" +i .ToString () +"条数据添加成功！");
                WriteGradesNotes();
                StudyTraining();
                SetGradesColor();

            }
                catch (Exception ex)
                {
                    label57.Text = "提示：操作错误，数据添加失败！！！";
                    MessageBox.Show(ex.Message);
                }
           
        }

        private void radioButton1_CheckedChanged(object sender, EventArgs e)
        {
            SqlConnection sqlConn = new SqlConnection("server="+ipAdress+";database=ErYingDatabase; uid=sa; pwd=9876543q");
            
            
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
            if (comboBox13.Text == "时间")
            {
                label44.Visible = true;
                comboBox14.Visible = true;
                groupBox5.Visible = false ;
                SqlConnection sqlConn = new SqlConnection("server="+ipAdress+";database=ErYingDatabase; uid=sa; pwd=9876543q");
                SqlDataAdapter sda1 = new SqlDataAdapter("select distinct ST_term as '时间'from ST_Semester", sqlConn);
                DataSet ds1 = new DataSet();
                sda1.Fill(ds1, "emp");
                comboBox14.DataSource = ds1.Tables[0];
                comboBox14.DisplayMember = "时间";
                dataGridView3.DataSource = ds1.Tables[0];
            }
            else
            {
                label44.Visible = true;
                comboBox14.Visible = true;
                groupBox5.Visible = true;
                if (radioButton8.Checked == true)
                {
                    SqlConnection sqlConn = new SqlConnection("server="+ipAdress+";database=ErYingDatabase; uid=sa; pwd=9876543q");
                    SqlDataAdapter sda1 = new SqlDataAdapter("select distinct ST_studysubject as'科目' from ST_StudySubject", sqlConn);
                    DataSet ds1 = new DataSet();
                    sda1.Fill(ds1, "emp");
                    comboBox14.DataSource = ds1.Tables[0];
                    comboBox14.DisplayMember = "科目";
                    dataGridView3.DataSource = ds1.Tables[0];
                }
                else
                {
                    SqlConnection sqlConn = new SqlConnection("server="+ipAdress+";database=ErYingDatabase; uid=sa; pwd=9876543q");
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
                    SqlConnection sqlConn = new SqlConnection("server="+ipAdress+";database=ErYingDatabase; uid=sa; pwd=9876543q");
                    SqlDataAdapter sda1 = new SqlDataAdapter("select distinct ST_studysubject  as'科目'from ST_StudySubject", sqlConn);
                    DataSet ds1 = new DataSet();
                    sda1.Fill(ds1, "emp");
                    comboBox14.DataSource = ds1.Tables[0];
                    comboBox14.DisplayMember = "科目";
                }
                else
                {
                    SqlConnection sqlConn = new SqlConnection("server="+ipAdress+";database=ErYingDatabase; uid=sa; pwd=9876543q");
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
            if (comboBox13.Text == "时间")
            {
                SqlConnection conn = new SqlConnection("server="+ipAdress+";database=ErYingDatabase; uid=sa; pwd=9876543q");
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
                    label57.Text = ("提示:时间 " + comboBox14.Text + "数据添加成功！");
                    SqlDataAdapter sda1 = new SqlDataAdapter("select ST_term as '时间' from ST_Semester", conn);
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
                  SqlConnection sqlConn = new SqlConnection("server="+ipAdress+";database=ErYingDatabase; uid=sa; pwd=9876543q");
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
                SqlConnection conn = new SqlConnection("server="+ipAdress+";database=ErYingDatabase; uid=sa; pwd=9876543q");
                SqlDataAdapter sda1 = new SqlDataAdapter("select distinct ST_studysubject as '科目'from ST_StudySubject", conn);
                DataSet ds1 = new DataSet();
                sda1.Fill(ds1, "emp");
                dataGridView3.DataSource = ds1.Tables[0];
                comboBox14.DataSource = ds1.Tables[0];
                comboBox14.DisplayMember = "科目";
            }
            else
            {
                SqlConnection conn = new SqlConnection("server="+ipAdress+";database=ErYingDatabase; uid=sa; pwd=9876543q");
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
            if (comboBox13 .Text =="时间")
            {
                str1 = "ST_Semester"; str2 = "ST_term"; str3 = "时间";
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
            SqlConnection conn = new SqlConnection("server="+ipAdress+";database=ErYingDatabase; uid=sa; pwd=9876543q");
            if (conn.State != ConnectionState.Open)
            {
                conn.Open();
            }
            SqlCommand sqlcmd = new SqlCommand();
            sqlcmd.Connection = conn;
            sqlcmd.CommandText = "delete from "+str1 +" where "+str2 +"='"+dataGridView3.CurrentCell.Value.ToString ()+"'";
            sqlcmd.CommandType = CommandType.Text;
            
            //for (int i=0;i<)
            try
            {
                sqlcmd.ExecuteNonQuery();
                label57.Text = "提示:" + dataGridView3.CurrentCell.Value.ToString() + "数据删除成功！";
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
            /*SqlConnection conn = new SqlConnection("server="+ipAdress+";database=ErYingDatabase; uid=sa; pwd=9876543q");
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
            ST_terms.Text = "选择时间";
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
            ST_terms.Text = "选择时间";
            ST_majors.Text = "选择专业";
            ST_subject.Text = "选择科目";
            SqlConnection sqlConn = new SqlConnection("server="+ipAdress+";database=ErYingDatabase; uid=sa; pwd=9876543q");
            SqlDataAdapter sda = new SqlDataAdapter("select Clientname  from ClientTable", sqlConn);
            DataSet ds = new DataSet();
            sda.Fill(ds, "emp");

        }

        private void radioButton5_CheckedChanged(object sender, EventArgs e)
        {
            /*SqlConnection conn = new SqlConnection("server="+ipAdress+";database=ErYingDatabase; uid=sa; pwd=9876543q");
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
            ST_subject.DisplayMember = "科目";*/
        }

        private void radioButton4_CheckedChanged(object sender, EventArgs e)
        {
             /*SqlConnection sqlConn = new SqlConnection("server="+ipAdress+";database=ErYingDatabase; uid=sa; pwd=9876543q");


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
            SqlConnection sqlConn = new SqlConnection("server="+ipAdress+";database=ErYingDatabase; uid=sa; pwd=9876543q");


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
            if (ST_majors.Text == "选择专业")
            {
                SqlConnection sqlConn = new SqlConnection("server="+ipAdress+";database=ErYingDatabase; uid=sa; pwd=9876543q");
                SqlDataAdapter sda1 = new SqlDataAdapter("select distinct " + str2 + "  from " + str1, sqlConn);
                DataSet ds1 = new DataSet();
                sda1.Fill(ds1, "emp");
                comboBox3.DataSource = ds1.Tables[0];
                comboBox3.DisplayMember = str2;
                comboBox3.Text  = "选择人员";
            }
            else
            {
                str3 = ST_majors.Text;
                SqlConnection sqlConn = new SqlConnection("server="+ipAdress+";database=ErYingDatabase; uid=sa; pwd=9876543q");
                SqlDataAdapter sda1 = new SqlDataAdapter("select distinct " + str2 + "  from " + str1+" where ST_major='"+str3 +"'", sqlConn);
                DataSet ds1 = new DataSet();
                sda1.Fill(ds1, "emp");
                comboBox3.DataSource = ds1.Tables[0];
                comboBox3.DisplayMember = str2;
                comboBox3.Text = "选择人员";
            }
            
            
        }

        private void ST_terms_MouseClick(object sender, MouseEventArgs e)
        {
            SqlConnection sqlConn = new SqlConnection("server="+ipAdress+";database=ErYingDatabase; uid=sa; pwd=9876543q");
            SqlDataAdapter sda1 = new SqlDataAdapter("select distinct ST_term from ST_Semester", sqlConn);
            DataSet ds1 = new DataSet();
            sda1.Fill(ds1, "emp");
            
            ST_terms.DataSource = ds1.Tables[0];
            ST_terms.DisplayMember = "ST_term";

                ST_terms.Text = "选择时间";

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
            SqlConnection sqlConn = new SqlConnection("server="+ipAdress+";database=ErYingDatabase; uid=sa; pwd=9876543q");
            SqlDataAdapter sda1 = new SqlDataAdapter("select distinct "+str2 +"  from "+str1 , sqlConn);
            DataSet ds1 = new DataSet();
            sda1.Fill(ds1, "emp");
            
            ST_subject.DataSource = ds1.Tables[0];
            ST_subject.DisplayMember = str2;

                ST_subject.Text = "选择科目";

            /*if (dataGridView2.Columns.Count == 2)
            {
                DataGridViewTextBoxColumn c = new DataGridViewTextBoxColumn();
                c.HeaderText = "成绩";
                dataGridView2.Columns.Add(c);
                dataGridView2.Columns[2].ReadOnly = false;
            }*/
        }

        private void ST_majors_MouseClick(object sender, MouseEventArgs e)
        {
            SqlConnection sqlConn = new SqlConnection("server="+ipAdress+";database=ErYingDatabase; uid=sa; pwd=9876543q");
            SqlDataAdapter sda1 = new SqlDataAdapter("select distinct ST_major  from ST_Information" , sqlConn);
            DataSet ds1 = new DataSet();
            sda1.Fill(ds1, "emp");
            
            ST_majors.DataSource = ds1.Tables[0];
            ST_majors.DisplayMember = "ST_major";
            ST_majors.Text = "选择专业";
            /*if (ST_majors.Text == "选择专业")
            {
                ST_majors.Text = "";
            }*/
        }

        private void button4_Click(object sender, EventArgs e)
        {
           /* SqlConnection conn = new SqlConnection("server="+ipAdress+";database=ErYingDatabase; uid=sa; pwd=9876543q");
            if (conn.State != ConnectionState.Open)
            {
                conn.Open();
            }
            SqlCommand sqlcmd = new SqlCommand();
            sqlcmd.Connection = conn;*/
            int i;
            string str1, str2, str3, str4,str5,str6;
            if (radioButton5.Checked == true)
            {
                str3 = "ST_Study"; str4 = "ST_studysubject";
            }
            else
            {
                str3 = "ST_Training"; str4 = "ST_trainsubject";
            }

            string str0;
            for (i = 0; i < dataGridView2.Rows.Count-1 ; i++)
            {
                if ("所有时间".Equals(ST_terms.Text.Trim())) str5 = dataGridView2.Rows[i].Cells[0].Value.ToString();
                else str5 = ST_terms.Text.Trim();
                if ("所有科目".Equals(ST_terms.Text.Trim())) str6 = dataGridView2.Rows[i].Cells[3].Value.ToString();
                else str6 = ST_subject.Text.Trim();
                str1 = dataGridView2.Rows[i].Cells[1].Value.ToString();
                str2 = dataGridView2.Rows[i].Cells[4].Value.ToString();
                //dataGridView2.Rows[i].Cells[3].Value = dataGridView2.Rows[i].Cells[4].Value;
               str0 = "update " + str3 + " set ST_result='"+str2 +"'where ST_term='" + str5 +"'and "+ str4 + "='" + str6  + 
                    "'and ST_Num='" + str1 + "'";
                try
                {
                    //sqlcmd.ExecuteNonQuery();
                    WriteGradesNotes();
                    ComSQL(str0);
                    SetGradesColor();


                }
                catch (Exception ex)
                {
                    label57.Text = "提示：操作错误，数据更新失败！！！";
                    MessageBox.Show(ex.Message);
                }             

            }
            StudyTraining();
            WriteGradesNotes();

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
            SqlConnection conn = new SqlConnection("server="+ipAdress+";database=ErYingDatabase; uid=sa; pwd=9876543q");
            if (conn.State != ConnectionState.Open)
            {
                conn.Open();
            }
            SqlCommand sqlcmd = new SqlCommand();
            sqlcmd.Connection = conn;
            sqlcmd.CommandText = "delete from "+str1+" where ST_Num='" + dataGridView2 .CurrentRow.Cells[1].Value.ToString()
                + "'and " + str2 + "='" + dataGridView2.CurrentRow.Cells[3].Value.ToString() + "'and ST_term='"
                + dataGridView2.CurrentRow.Cells[0].Value.ToString() + "'";
            sqlcmd.CommandType = CommandType.Text;
            try
            {
                sqlcmd.ExecuteNonQuery();
                label57.Text = ("提示:学号为" + dataGridView2 .CurrentCell .Value .ToString ()+ "学员"+ST_terms.Text +"学期"+ST_subject.Text +"成绩删除成功！");
                StudyTraining();
                SetGradesColor();
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
            SqlConnection sqlConn = new SqlConnection("server="+ipAdress+";database=ErYingDatabase; uid=sa; pwd=9876543q");
            SqlDataAdapter sda4 = new SqlDataAdapter("select distinct Clientname from ClientTable", sqlConn);
                DataSet ds1 = new DataSet();
                sda4.Fill(ds1, "emp");
                comboBox5.DataSource = ds1.Tables[0];
                comboBox5.DisplayMember = "Clientname";
          
        }

        

        private void comboBox5_SelectedIndexChanged(object sender, EventArgs e)
        {
            SqlConnection sqlConn = new SqlConnection("server="+ipAdress+";database=ErYingDatabase; uid=sa; pwd=9876543q");
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
            SqlConnection conn = new SqlConnection("server="+ipAdress+";database=ErYingDatabase; uid=sa; pwd=9876543q");
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
                            label57.Text = "提示:用户" + textBox30.Text + "密码修改成功！";

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
            SqlConnection conn = new SqlConnection("server="+ipAdress+";database=ErYingDatabase; uid=sa; pwd=9876543q");
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
            SqlConnection conn = new SqlConnection("server="+ipAdress+";database=ErYingDatabase; uid=sa; pwd=9876543q");
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
                Image imgRead = Image.FromFile(fullpath );
                pictureBox1.Image = new Bitmap(imgRead);
                imgRead.Dispose();
                imagebytes = GetImageBytes(pictureBox1.Image);

                //aa = openFileDialog1.OpenFile();
                /*FileStream fs = new FileStream(fullpath, FileMode.Open );
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
                }*/
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
            //PaiGangClass paiGang = new PaiGangClass();
            //paiGang.PaiGang();
            Process p = Process.Start("F:/程序代码/PaiGangProgram/PaiGang.exe");
            p.WaitForExit();


        }

        private void label11_Click(object sender, EventArgs e)
        {

        }

        private void button18_Click_1(object sender, EventArgs e)
        {
            OpenFileDialog openFileDialog1 = new OpenFileDialog();
            openFileDialog1.Filter = "*jpg|*.JPG|*.gif|*.GIF|*.bmp|*.BMP|*.png|*.PNG";
            if (openFileDialog1.ShowDialog() == DialogResult.OK)
            {
                string fullpath = openFileDialog1.FileName;//文件路径                  
                tabPage11.BackgroundImage = Image.FromFile(System.IO.Path.GetFullPath(fullpath));
            }
            SqlConnection conn = new SqlConnection("server="+ipAdress+";database=ErYingDatabase; uid=sa; pwd=9876543q");
            if (conn.State != ConnectionState.Open)
            {
                conn.Open();
            }
            SqlCommand sqlcmd1 = new SqlCommand();
            sqlcmd1.Connection = conn;
            sqlcmd1.CommandText = "update ST_Photos set ST_photo=@imagelist where picturepos='1'";
            sqlcmd1.Parameters.Add("@imagelist", SqlDbType.Image).Value = imagebytes;
            //sqlcmd1.Parameters["imagelist"].Value = ;
            sqlcmd1.ExecuteNonQuery();
            label1.Text = "提示：照片修改成功！";


        }

            private void dateTimePicker2_ValueChanged(object sender, EventArgs e)
        {

        }

        private void checkBox1_CheckedChanged(object sender, EventArgs e)
        {
            
        }

        private void checkBox2_CheckedChanged(object sender, EventArgs e)
        {
            
        }

        private void checkBox3_CheckedChanged(object sender, EventArgs e)
        {
            
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
            SqlConnection conn = new SqlConnection("server="+ipAdress+";database=ErYingDatabase; uid=sa; pwd=9876543q");
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
                SetEqColor();
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
            SqlConnection conn = new SqlConnection("server="+ipAdress+";database=ErYingDatabase; uid=sa; pwd=9876543q");
            if (conn.State != ConnectionState.Open)
            {
                conn.Open();
            }
            SqlCommand sqlcmd = new SqlCommand();
            sqlcmd.Connection = conn;
            sqlcmd.CommandText = "update Eq_Information set Eq_type='" + Eq_type.Text.Trim() + "',Eq_name='" + Eq_name.Text.Trim()
                + "',Eq_model='" + Eq_model.Text.Trim() + "',Eq_color='" + Eq_color.Text.Trim()
                 + "',Eq_engine='" + Eq_engine.Text.Trim() + "',Eq_underpan='" + Eq_underpan.Text.Trim()
                + "',Eq_resource='" + Eq_resource.Text.Trim() + "',Eq_factoryDate='" + Eq_factoryDate.Text.Trim() + "',Eq_distribute='" + Eq_distributeDate.Text.Trim()
                + "',Eq_repair='" + Eq_repair.Text.Trim() + "',Eq_remark='" + Eq_remark.Text.Trim()+ "' where Eq_num='" + Eq_num.Text.Trim()+"'";
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
            SqlConnection conn = new SqlConnection("server="+ipAdress+";database=ErYingDatabase; uid=sa; pwd=9876543q");
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
                SetEqColor();
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
                SqlConnection sqlConn = new SqlConnection("server="+ipAdress+";database=ErYingDatabase; uid=sa; pwd=9876543q");
                SqlDataAdapter sda = new SqlDataAdapter("select Eq_type as '装备类别',Eq_name as '装备名称',Eq_model as '装备型号',Eq_color as '车辆颜色',Eq_num as '装备编号',Eq_engine as '发动机号',Eq_underpan as '底盘号',Eq_resource as '配发来源',Eq_factoryDate as '出厂时间',Eq_distribute as '配发时间',Eq_repair as '整修情况',Eq_remark as '备注',Eq_ID from Eq_Information "
                     , sqlConn);
                DataSet ds = new DataSet();
                sda.Fill(ds, "emp");
                dataGridView4.DataSource = ds.Tables[0];
                SetEqColor();
            }
            else
            {
                    //SqlConnection conn = new SqlConnection();
                    SqlConnection sqlConn = new SqlConnection("server="+ipAdress+";database=ErYingDatabase; uid=sa; pwd=9876543q");
                    SqlDataAdapter sda = new SqlDataAdapter(
                        "select Eq_type as '装备类别',Eq_name as '装备名称',Eq_model as '装备型号',Eq_color as '车辆颜色',Eq_num as '装备编号',Eq_engine as '发动机号',Eq_underpan as '底盘号',Eq_resource as '配发来源',Eq_factoryDate as '出厂时间',Eq_distribute as '配发时间',Eq_repair as '整修情况',Eq_remark as '备注',Eq_ID from Eq_Information  where Eq_name='" +
                        comboBox6.Text + "'", sqlConn);
                    DataSet ds = new DataSet();
                    try
                    {
                        sda.Fill(ds, "emp");
                        dataGridView4.DataSource = ds.Tables[0];
                    SetEqColor();
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
            SqlConnection sqlConn = new SqlConnection("server="+ipAdress+";database=ErYingDatabase; uid=sa; pwd=9876543q");


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
            if (radioButton14 .Checked ==true)
            {
                ShowEqInOut();
            }
            else
            {
                ShowEqRepair();
            }
            
            

        }

        private void button30_Click(object sender, EventArgs e)
        {
            SqlConnection conn = new SqlConnection("server="+ipAdress+";database=ErYingDatabase; uid=sa; pwd=9876543q");
            if (conn.State != ConnectionState.Open)
            {
                conn.Open();
            }
            SqlCommand sqlcmd = new SqlCommand();
            sqlcmd.Connection = conn;
            if (radioButton14 .Checked == true)
            {
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
            else
            {
                string table0 = "Eq_repair";
                string[] str1 = { "Eq_Num","RepairTime","RepairPerson","RepairType","RepairContent","Eq_principal"};
                TextBox[] t = new TextBox[6];
                t[0] = Eq_num;
                t[1] = new TextBox ();
                t[1].Text = Eq_outDate.Value.Year.ToString() + "-" + Eq_outDate.Value.Month.ToString() + "-"+ Eq_outDate.Value.Day.ToString();
                t[2] = RepairPerson;
                t[3] = RepairType;
                t[4] = Eq_event;
                t[5] = Eq_principal;
                try
                {
                    InsertSQL(str1, t, table0);
                    object sender1 = new object(); EventArgs e1 = new EventArgs();
                    radioButton14_CheckedChanged(sender1, e1);
                }
                catch (Exception e0)
                {
                    MessageBox.Show(e0.ToString());
                }
            }
            EqInOut();


        }

        private void dataGridView4_Click(object sender, EventArgs e)
        {
            EqInOut();
        }

        private void button31_Click(object sender, EventArgs e)
        {
            if (radioButton14 .Checked ==true)
            {
                SqlConnection conn = new SqlConnection("server="+ipAdress+";database=ErYingDatabase; uid=sa; pwd=9876543q");
                if (conn.State != ConnectionState.Open)
                {
                    conn.Open();
                }
                SqlCommand sqlcmd = new SqlCommand();
                sqlcmd.Connection = conn;
                //string  d1 = Convert .ToDateTime (dataGridView5.CurrentRow.Cells[0].Value.ToString()).ToString ("yyyy-MM-dd");
                // string  d2 =  Convert.ToDateTime(dataGridView5.CurrentRow.Cells[1].Value.ToString()).ToString ("yyyy-MM-dd");
                sqlcmd.CommandText = "delete from Eq_move where Eq_outDate='" +
                    dataGridView5.CurrentRow.Cells[0].Value.ToString() + "' and Eq_ID='" +
                    dataGridView4.CurrentRow.Cells[12].Value.ToString() + "'and Eq_event='" +
                   dataGridView5.CurrentRow.Cells[2].Value.ToString() + "'";
                sqlcmd.CommandType = CommandType.Text;
                try
                {
                    sqlcmd.ExecuteNonQuery();
                    label57.Text = ("提示:出库日期为" + dataGridView5.CurrentRow.Cells[0].Value + "的数据删除成功！");
                    SqlDataAdapter sda = new SqlDataAdapter("select Eq_outDate as '出库日期',Eq_inDate as '入库日期',Eq_event as'事由',Eq_principal as'负责人' from Eq_move where Eq_ID='"
                        + dataGridView4.CurrentRow.Cells[12].Value.ToString() + "'", conn);
                    DataSet ds = new DataSet();
                    sda.Fill(ds, "emp");
                    dataGridView5.DataSource = ds.Tables[0];
                }
                catch (Exception ex)
                {
                    label57.Text = "提示：操作错误，数据删除失败！！！";
                    MessageBox.Show(ex.Message);
                }
            }
            else
            {
                string table0 = "Eq_Repair";
                string strc ="Eq_Num='"+Eq_num .Text +"'and RepairTime='"+ dataGridView5.CurrentRow .Cells[0].Value .ToString ()+"'" ;
                DeleteSQL(table0, strc);
                ShowEqRepair();

            }
            


        }

        private void dataGridView5_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {

        }

        private void comboBox3_MouseDown(object sender, MouseEventArgs e)
        {
            
        }

        private void comboBox3_SelectionChangeCommitted(object sender, EventArgs e)
        {
            
        }

        private void comboBox3_TextChanged(object sender, EventArgs e)
        {
            /*SqlConnection sqlConn = new SqlConnection("server="+ipAdress+";database=ErYingDatabase; uid=sa; pwd=9876543q");
            string str1, str2, str3;

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
            if (ST_subject.Text == "选择专业")
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

                SqlDataAdapter sda = new SqlDataAdapter("select ST.ST_Num as '学号', ST.ST_name as '姓名' ,SU.ST_result as'"
                + ST_subject.Text.Trim() + "成绩'from (select*from ST_Information where " + str3 + " ='" + comboBox3.Text.Trim()
                    + "')as ST left outer  join (select *from " + str1 + " where " + str2 + "='" + ST_subject.Text.Trim() + "')as SU on ST.ST_Num=SU.ST_Num ", sqlConn);
                DataSet ds = new DataSet();
                sda.Fill(ds, "emp");
                dataGridView2.DataSource = ds.Tables[0];

            }*/
            StudyTraining();
        }

        private void ST_terms_TextChanged(object sender, EventArgs e)
        {
            StudyTraining();
        }

        private void ST_subject_TextChanged(object sender, EventArgs e)
        {
            StudyTraining();
        }

        private void ST_majors_TextChanged(object sender, EventArgs e)
        {
            StudyTraining();
        }

        private void button33_Click(object sender, EventArgs e)
        {

        }

        private void button34_Click(object sender, EventArgs e)
        {
            string str = "insert into Files(File_Num,File_Class,File_Title,File_Accepter,File_Time,File_Amount," +
                "File_Place,File_Notes)values('" + File_Num.Text.Trim() + "','" + File_Class.Text.Trim() + "','"
                + File_Title.Text.Trim() + "','" + File_Accepter.Text.Trim() + "','" + File_Time.Text.Trim()
                + "','" + File_Amount.Text.Trim() + "','" + File_Place.Text.Trim() + "','" + File_Notes.Text.Trim()
                + "')";
            try
            {
                ComSQL(str);
                label57.Text = "提示：《" + File_Title.Text + "》录入成功！";
                object sender1 = new object(); EventArgs e1 = new EventArgs();
                button35_Click(sender1, e1);

            }
            catch 
            {
                str = "update Files set File_Num='" + File_Num.Text.Trim() + "'File_Class='" + File_Class.Text.Trim() + "'File_Title='"
                    + File_Title.Text.Trim() + "'File_Accepter='" + File_Accepter.Text.Trim() + "'File_Time='" + File_Time.Text.Trim() + "'File_Amount='" +
                    File_Amount.Text.Trim() + "'File_Place='" + File_Place.Text.Trim() + "'File_Notes='" + File_Notes.Text.Trim()+ "'where File_Num='" + File_Num.Text.Trim()+ "'and File_Class='" + File_Class.Text.Trim() + "'";
                try
                {
                    ComSQL(str);
                    label57.Text = "提示：《" + File_Title.Text + "》更新成功！";
                    object sender1 = new object(); EventArgs e1 = new EventArgs();
                    button35_Click(sender1, e1);

                }
                catch (Exception e1)
                {
                    MessageBox.Show(e1.ToString());
                }
                
                
            }
            finally
            {
                SetFileColor();
            }
        }

        private void StudyTraining()
        {
            string str1, str2, str3,str0;
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
            //判断各种选择System.Data.DataRowView
            if ("System.Data.DataRowView".Equals(ST_terms.Text.Trim()) || "System.Data.DataRowView".Equals(ST_subject.Text.Trim())
                || "System.Data.DataRowView".Equals(ST_majors.Text.Trim())
                || "System.Data.DataRowView".Equals(comboBox3.Text.Trim())) return;
                bool flag_time, flag_subject, flag_major, flag_person;
            flag_time= flag_subject= flag_major= flag_person= true;
            if ("选择时间".Equals(ST_terms .Text.Trim())) flag_time = true;
            else flag_time = false ;//如果是选择时间，flag_time 就是false
            if ("选择科目".Equals(ST_subject .Text.Trim())) flag_subject = true;
            else flag_subject = false;//如果是所有科目，flag_subject就是false
            if ("选择专业".Equals(ST_majors .Text.Trim())) flag_major = true;
            else flag_major = false;//如果是所有专业，flag_major 就是false
            if ("选择人员".Equals(comboBox3.Text.Trim())) flag_person = true;
            else flag_person = false;
            SqlConnection sqlConn = new SqlConnection("server="+ipAdress+";database=ErYingDatabase; uid=sa; pwd=9876543q");
            SqlDataAdapter sda=null ;
            dataGridView2.DataSource = null;
            if (flag_time && flag_subject && flag_major && flag_person)//全是所有
            {
                try
                {
                    str0 = "select SU.ST_term as '时间', ST.ST_Num as '编号', ST.ST_name as '姓名',SU." + str2 + " as '科目名称', SU.ST_result as '成绩'from (select*from ST_Information)as ST left outer join "
                        + str1 + " as SU on ST.ST_Num=SU.ST_Num order by SU.ST_term";
                    sda = new SqlDataAdapter(str0 
                       , sqlConn);

                }
                catch { }
            }
            else if (flag_subject && flag_major && flag_person)//时间有值
            {
                try
                {
                    str0 = "select SU.ST_term as '时间', ST.ST_Num as '编号', ST.ST_name as '姓名', SU." + str2 + " as '科目名称',SU.ST_result as '成绩'from (select*from ST_Information)as ST left outer join (select*from "
                        + str1 + " where ST_term='" + ST_terms.Text.Trim() + "')as SU on ST.ST_Num=SU.ST_Num  order by ST.ST_Num";
                    sda = new SqlDataAdapter(str0 
                       , sqlConn);

                }
                catch { }
            }
            else if (flag_time && flag_subject && flag_major)//人有值
            {
                try
                {
                    str0 = "select SU.ST_term as '时间', ST.ST_Num as '编号', ST.ST_name as '姓名',SU." + str2 + " as '科目名称',SU.ST_result as '成绩'from (select*from ST_Information where "
                        + str3 + "='" + comboBox3.Text.Trim() + "')as ST left outer join "
                    + str1 + " as SU on ST.ST_Num=SU.ST_Num order by ST.ST_Num";
                    sda = new SqlDataAdapter(str0 
                       , sqlConn);

                }
                catch { }
            }
            else if (flag_time && flag_subject && flag_person)//专业有值
            {
                try
                {
                    str0 ="select SU.ST_term as '时间', ST.ST_Num as '编号', ST.ST_name as '姓名',SU." + str2 + " as '科目名称', SU.ST_result as'成绩'from (select*from ST_Information where ST_major='"
                        + ST_majors.Text.Trim() + "')as ST left outer join " + str1 + " as SU on ST.ST_Num=SU.ST_Num  order by ST.ST_Num";
                    sda = new SqlDataAdapter(str0 
                        , sqlConn);

                }
                catch { }
            }
            else if (flag_time && flag_major && flag_person)//科目有值
            {
                try
                {
                    str0 = "select SU.ST_term as '时间', ST.ST_Num as '编号', ST.ST_name as '姓名', SU." + str2 + " as '科目名称',SU.ST_result as'成绩'from (select*from ST_Information )as ST left outer join (select*from "
                        + str1 + " where " + str2 + "='" + ST_subject.Text.Trim() + "')as SU on ST.ST_Num=SU.ST_Num order by ST.ST_Num";
                    sda = new SqlDataAdapter(
                        str0 , sqlConn);

                }
                catch { }
            }
            else if (flag_time && flag_major)//时间和专业是所有值
            {
                try
                {
                    str0 = "select SU.ST_term as '时间', ST.ST_Num as '编号', ST.ST_name as '姓名',SU." + str2 + " as '科目名称', SU.ST_result as '成绩'from (select*from ST_Information where "
                        + str3 + "='" + comboBox3.Text.ToString().Trim() + "')as ST left outer join (select*from "
                        + str1 + " where " + str2 + "='" + ST_subject.Text.Trim() + "')as SU on ST.ST_Num=SU.ST_Num order by SU.ST_term";
                    sda = new SqlDataAdapter(
                       str0 , sqlConn);

                }
                catch { }
            }
            else if (flag_major && flag_person)//专业和人员是所有值
            {
                try
                {
                    str0 = "select SU.ST_term as '时间', ST.ST_Num as '编号', ST.ST_name as '姓名',SU." + str2 + " as '科目名称', SU.ST_result as '成绩'from (select*from ST_Information)as ST left outer join (select*from "
                        + str1 + " where ST_term='" + ST_terms.Text.Trim() + "' and " + str2 + "='" + ST_subject.Text.Trim()
                        + "')as SU on ST.ST_Num=SU.ST_Num order by SU.ST_term";
                    sda = new SqlDataAdapter(
                        str0 , sqlConn);

                }
                catch { }
            }
            else if (flag_time && flag_subject)//时间和科目是所有值
            {
                try
                {
                    str0 = "select SU.ST_term as '时间', ST.ST_Num as '编号', ST.ST_name as '姓名',SU." + str2 + " as '科目名称',SU.ST_result as '成绩'from (select*from ST_Information where "
                        + str3 + "='" + comboBox3.Text.Trim() + "')as ST left outer join "
                    + str1 + " as SU on ST.ST_Num=SU.ST_Num order by ST.ST_Num";
                    sda = new SqlDataAdapter(str0 
                       , sqlConn);

                }
                catch { }
            }
            else if (flag_subject && flag_person)//科目和人员是所有值
            {
                try
                {
                    str0 = "select SU.ST_term as '时间', ST.ST_Num as '编号', ST.ST_name as '姓名',SU." + str2 + " as '科目名称', SU.ST_result as '成绩'from (select*from ST_Information where ST_major='"
                        + ST_majors.Text.Trim() + "')as ST left outer join (select * from " + str1 + " where ST_term='"
                        + ST_terms.Text.Trim() + "')as SU on ST.ST_Num=SU.ST_Num order by SU.ST_term";
                    sda = new SqlDataAdapter(
                       str0 , sqlConn);//先到这

                }
                catch { }
            }
            else if (flag_subject && flag_major)//科目和专业是所有值
            {
                try
                {
                    str0 = "select SU.ST_term as '时间', ST.ST_Num as '编号', ST.ST_name as '姓名',SU." + str2 + " as '科目名称', SU.ST_result as '成绩'from (select*from ST_Information where "
                        +str3 + "='" + comboBox3.Text.Trim()  + "')as ST left outer join (select *from " + str1 + " where ST_term='"
                        + ST_terms.Text.Trim() + "')as SU on ST.ST_Num=SU.ST_Num order by SU.ST_term";
                    sda = new SqlDataAdapter(
                        str0 , sqlConn);

                }
                catch { }
            }
            else if (flag_time && flag_person)//时间和人员是所有值
            {
                try
                {
                    str0 = "select SU.ST_term as '时间', ST.ST_Num as '编号', ST.ST_name as '姓名',SU." + str2 + " as '科目名称', SU.ST_result as '成绩'from (select*from ST_Information where ST_major='"
                        + ST_majors.Text.Trim() + "')as ST left outer join (select * from " + str1 + " where " + str2 + "='"
                        + ST_subject.Text.Trim() + "')as SU on ST.ST_Num=SU.ST_Num order by SU.ST_term";
                    sda = new SqlDataAdapter(
                        str0 , sqlConn);

                }
                catch { }
            }
            else if (flag_time)//仅时间是所有值
            {
                try
                {
                    str0 = "select SU.ST_term as '时间', ST.ST_Num as '编号', ST.ST_name as '姓名',SU." + str2 + " as '科目名称', SU.ST_result as '成绩'from (select*from ST_Information where "
                        + str3 + "='" + comboBox3.Text.Trim() + "')as ST left outer join (select * from " + str1 + " where " + str2 + "='"
                        + ST_subject.Text.Trim() + "')as SU on ST.ST_Num=SU.ST_Num order by SU.ST_term";
                    sda = new SqlDataAdapter(
                       str0 , sqlConn);

                }
                catch { }
            }
            else if (flag_person)//仅人员是所有值
            {
                try
                {
                    str0 = "select SU.ST_term as '时间', ST.ST_Num as '编号', ST.ST_name as '姓名',SU." + str2 + " as '科目名称', SU.ST_result as '成绩'from (select*from ST_Information where ST_major='"
                        + ST_majors.Text.Trim() + "')as ST left outer join (select*from "
                        + str1 + " where ST_term='" + ST_terms.Text.Trim() + "' and " + str2 + "='" + ST_subject.Text.Trim() + "')as SU on ST.ST_Num=SU.ST_Num order by SU.ST_term";
                    sda = new SqlDataAdapter(
                       str0 , sqlConn);

                }
                catch { }
            }
            else if (flag_major)//仅专业是所有值
            {
                try
                {
                    str0 = "select SU.ST_term as '时间', ST.ST_Num as '编号', ST.ST_name as '姓名',SU." + str2 + " as '科目名称',SU.ST_result as '成绩'from(select*from ST_Information where "
                        + str3 + "='" + comboBox3.Text.Trim() + "')as ST left outer join  (select*from "
                        + str1 + " where ST_term='" + ST_terms.Text.Trim() + "' and " + str2 + "='" + ST_subject.Text.Trim() + "')as SU on ST.ST_Num=SU.ST_Num order by SU.ST_term";
                    sda = new SqlDataAdapter(
                        str0 , sqlConn);

                }
                catch { }
            }
            else if (flag_subject)//仅科目是所有值
            {
                try
                {
                    str0 = "select SU.ST_term as '时间', ST.ST_Num as '编号', ST.ST_name as '姓名',SU." + str2 + " as '科目名称', SU.ST_result as '成绩'from (select*from ST_Information where "
                        + str3  + "='" + comboBox3.Text.Trim()+ "')as ST left outer join (select*from "
                        + str1 + " where ST_term='" + ST_terms.Text.Trim() + "')as SU on ST.ST_Num=SU.ST_Num order by SU.ST_term";
                    sda = new SqlDataAdapter(
                       str0 , sqlConn);

                }
                catch(Exception e1)
                { MessageBox.Show(e1.ToString ()); }
            }
            else if (!flag_time && !flag_subject && !flag_major && !flag_person)//全都有值
            {
                try
                {
                    str0 = "select SU.ST_term as '时间', ST.ST_Num as '编号', ST.ST_name as '姓名',SU." + str2 + " as '科目名称', SU.ST_result as '成绩'from(select*from ST_Information where "
                        + str3 + "='" + comboBox3.Text.Trim() + "')as ST left outer join  (select*from "
                        + str1 + " where ST_term='" + ST_terms.Text.Trim() + "' and " + str2 + "='" + ST_subject.Text.Trim() + "')as SU on ST.ST_Num=SU.ST_Num order by SU.ST_term";
                    sda = new SqlDataAdapter(
                        str0 , sqlConn);

                }
                catch { }
            }
            else label57.Text = "提示：出现错误";
            try
            {
                DataSet ds = new DataSet();
                sda.Fill(ds, "emp");dataGridView2.DataSource = ds.Tables[0];
                SetGradesColor();
                ReadGradesNotes();
               
            }
            catch { }
           
            


        }
        private void AddUpdateData()
        {
            foreach (Control c in tabPage5.Controls)
            {
                /*if (c is TextBox)
                {
                    if (string.IsNullOrEmpty((c as TextBox).Text))
                    {
                        label57.Text = ("提示：请先将数据补充完整！");
                        return;
                    }
                }*/
                if (string.IsNullOrEmpty(ST_Num.Text))
                {
                    label57.Text = ("提示：请先将数据补充完整！");
                    return;
                }

            }
            /*if (ST_birth.ForeColor == Color.Gray)
            {
                label57.Text = ("提示：请先将数据补充完整！");
                return;
            }*/

            SqlConnection conn = new SqlConnection("server="+ipAdress+";database=ErYingDatabase; uid=sa; pwd=9876543q");
            if (conn.State != ConnectionState.Open)
            {
                conn.Open();
            }
            SqlCommand sqlcmd = new SqlCommand();
            sqlcmd.Connection = conn;
            sqlcmd.CommandText = "insert ST_Information ( ST_name,ST_sex,ST_birth,ST_race,ST_jiguan,ST_Num,ST_IDNum,ST_QorS,ST_polID,ST_address,ST_major,ST_isonlychild,ST_experience,ST_PreSchool,InArmy,Grade,PartyTime," +
                "IsMarry,IsPregnant,VacationPlan,Family,Family_Mobile,Education,BloodType)values"
               + "('" + ST_name.Text.Trim() + "','" + ST_sex.Text.Trim() + "','" + ST_birth.Text.Trim() + "','" + ST_race.Text.Trim() + "','" + ST_jiguan.Text.Trim() + "','" + ST_Num.Text.Trim() + "','" + ST_IDNum.Text.Trim()
                + "','" + ST_QorS.Text.Trim() + "','" + ST_polID.Text.Trim() + "','" + ST_address.Text.Trim() + "','" + ST_major.Text.Trim() + "','" + ST_isonlychild.Text.Trim()
                 + "','" + ST_experience.Text.Trim() + "','" + ST_PreSchool.Text.Trim() + "','" + InArmy .Text .Trim () + "','" +
                 Grade.Text .Trim () + "','" + PartyTime.Text .Trim () + "','" + IsMarry.Text .Trim () + "','" + IsPregnant.Text .Trim () + "','" + VacationPlan.Text .Trim() + "','" +
                 Family.Text .Trim () + "','" + Family_Mobile.Text .Trim () + "','" + EducationLevel .Text .Trim () + "','" + BloodType .Text .Trim () + "')";
            sqlcmd.CommandType = CommandType.Text;
            try
            {

                sqlcmd.ExecuteNonQuery();
                label57.Text = ("提示:学员" + ST_name.Text + "数据添加成功！");
                object sender1 = new object(); EventArgs e0 = new EventArgs();
                button2_Click(sender1, e0);

            }
            catch
            {


                if (conn.State != ConnectionState.Open)
                {
                    conn.Open();
                }
                
                sqlcmd.Connection = conn;
                sqlcmd.CommandText = "update ST_Information set ST_name='" + ST_name.Text.Trim() + "',ST_sex='" + ST_sex.Text.Trim()
                    + "',ST_birth='" + ST_birth.Text.Trim() + "',ST_race='" + ST_race.Text.Trim()
                    + "',ST_jiguan='" + ST_jiguan.Text.Trim() + "',ST_Num='" + ST_Num.Text.Trim() + "',ST_IDNum='" + ST_IDNum.Text.Trim()
                    + "',ST_QorS='" + ST_QorS.Text.Trim() + "',ST_polID='" + ST_polID.Text.Trim() + "',ST_address='" + ST_address.Text.Trim()
                    + "',ST_major='" + ST_major.Text.Trim() + "',ST_isonlychild='" + ST_isonlychild.Text.Trim()
                    + "',ST_experience='" + ST_experience.Text.Trim() + "',ST_PreSchool='" + ST_PreSchool.Text.Trim() 
                    + "',InArmy='"+ InArmy .Text .Trim ()+ "',Grade='"+ Grade .Text .Trim ()+ "',PartyTime='"
                    + PartyTime .Text .Trim ()+ "',IsMarry='"+ IsMarry .Text .Trim ()+ "',IsPregnant='"
                    + IsPregnant .Text .Trim ()+ "',VacationPlan='"+ VacationPlan .Text .Trim ()+ "',Family='"
                    + Family .Text .Trim ()+ "',Family_Mobile='"+ Family_Mobile .Text .Trim ()+ "',Education='"
                    +EducationLevel .Text .Trim ()+ "',BloodType='"+BloodType .Text .Trim ()+ "'where ST_Num='" 
                    + ST_Num.Text.Trim() + "'";
                sqlcmd.CommandType = CommandType.Text;
                try
                {
                    sqlcmd.ExecuteNonQuery();
                    label57.Text = ("提示:学员" + ST_name.Text + "数据修改成功！");
                    object sender1 = new object();EventArgs e0 = new EventArgs();
                    button2_Click(sender1   , e0);
                    

                }
                catch(Exception e2)
                {
                    MessageBox.Show(e2.ToString());
                }
            }
            try
            {
                //FileStream fs = new FileStream("tem.dat", FileMode.Open);
                // byte[] imagebytes = new byte[fs.Length];
                //fs.Read(imagebytes, 0, imagebytes.Length);
                //fs.Close();
                SqlCommand sqlcmd1 = new SqlCommand();
                sqlcmd1.Connection = conn;
                byte[] imageBytes = GetImageBytes(pictureBox1.Image);
                try
                {
                    

                    string connStr = "SQL Server连接字符串";

                    
                        string sql = "Insert Into ST_photos(ST_Num,ST_photo) Values ('"+ST_Num .Text .Trim ()+"',@ImgData) ";

                            SqlParameter param = new SqlParameter("ImgData", SqlDbType.VarBinary, imageBytes.Length);
                            param.Value = imageBytes;
                    sqlcmd1.CommandText = sql;
                    sqlcmd1.Parameters.Add(param);
                    if (conn.State != ConnectionState.Open)
                    {
                        conn.Open();
                    }
                    sqlcmd1.Connection = conn;
                            
                            int i = sqlcmd1.ExecuteNonQuery();
                            //MessageBox.Show(i.ToString());
                       
                    

                    //sqlcmd1.CommandText = "insert ST_Photos (ST_Num,ST_photo)values" + "('" + ST_Num.Text.Trim() + "',@imagelist)";
                    //sqlcmd1.Parameters.Add("@imagelist", SqlDbType.Image).Value = imagebytes;
                    //sqlcmd1.Parameters["imagelist"].Value = ;
                    //sqlcmd1.ExecuteNonQuery();
                    label57.Text += "照片添加成功！";
                }
                catch
                {
                    try
                    {
                        //ST_experience.Text = e.ToString();
                        //ST_experience .Text = ex1.ToString();
                        sqlcmd1.CommandText = "update ST_Photos set ST_photo=@imagelist where ST_Num=' " + ST_Num.Text.Trim() + "'";
                        sqlcmd1.Parameters.Add("@imagelist", SqlDbType.Image).Value = imagebytes;
                        //sqlcmd1.Parameters["imagelist"].Value = ;
                        sqlcmd1.ExecuteNonQuery();
                        label57.Text += "照片修改成功！";
                    }
                    catch { }
                    
                }
                finally
                {
                    if (conn.State != ConnectionState.Open)
                    {
                        conn.Open();
                    }
                    //FileStream fs = new FileStream("tem.dat", FileMode.Open);

                    //fs.Read(imagebytes, 0, imagebytes.Length);
                    //fs.Close();

                    try
                    {

                        sqlcmd1.Connection = conn;
                        sqlcmd1.CommandText = "select ST_photo from ST_Photos where ST_Num='" + ST_Num.Text.Trim() + "'";
                        SqlDataReader sdr = sqlcmd1.ExecuteReader();
                        sdr.Read();
                        imagebytes = (byte[])sdr["ST_photo"];
                        MemoryStream ms = new MemoryStream(imagebytes);
                        pictureBox1.Image = System.Drawing.Image.FromStream(ms, true);
                    }
                    catch { pictureBox1.Image = null; imagebytes = null; }
                }
                if (conn.State != ConnectionState.Open)
                {
                    conn.Dispose(); conn.Dispose();
                }
            }
            catch (Exception ex)
            {
                //MessageBox.Show(ex.Message);
                if (conn.State != ConnectionState.Open)
                {
                    conn.Dispose(); conn.Dispose();
                }
            }
        }
        private byte[] GetImageBytes(Image image)
        {
            MemoryStream mstream = new MemoryStream();
            image.Save(mstream, System.Drawing.Imaging.ImageFormat.Jpeg);
            byte[] byteData = new Byte[mstream.Length];
            mstream.Position = 0;
            mstream.Read(byteData, 0, byteData.Length);
            mstream.Close();
            return byteData;
        }
        //数据库查询函数
        private DataSet SelectSQL(string str)
        {
            SqlConnection sqlConn = new SqlConnection("server="+ipAdress+";database=ErYingDatabase; uid=sa; pwd=9876543q");
            SqlDataAdapter sda = new SqlDataAdapter(str , sqlConn);
            DataSet ds = new DataSet();
            sda.Fill(ds, "emp");           
            if (sqlConn.State != ConnectionState.Open)
            {
                sqlConn.Dispose(); sqlConn.Dispose();
            }
            return ds ;

        }

        private void button37_Click(object sender, EventArgs e)
        {
            if ("".Equals (ST_Num2 .Text .Trim()))
            {
                MessageBox.Show("请将数据补充完整！");
                return;
            }
            string str = "insert into Phones(ST_Num,PhoneModel,PhoneNumber,Management,QQ_Num,WeChat_Num,Card_Num,AwaitModel," +
                "MobileNetwork,SetOperation)values('"+ST_Num2 .Text .Trim ()+"','" +PhoneModel .Text .Trim ()+ "','"
                +PhoneNumber .Text .Trim ()+ "','" +Management .Text .Trim ()+ "','" +QQ_Num .Text .Trim ()+ "','" + 
                WeChat_Num .Text .Trim ()+"','" +Card_Num .Text .Trim ()+ "','" +AwaitModel .Text .Trim ()+ "','" 
                +MobileNetwork .Text .Trim ()+ "','" +SetOperation .Text .Trim ()+ "')";
            try
            {
                ComSQL(str);
                label57.Text = "提示：" + ST_Name2.Text.ToString() + "手机数据录入成功！";
            }
            catch
            {
                str = "update Phones set ST_Num='" + ST_Num2.Text.Trim() + "',PhoneModel='" + PhoneModel.Text.Trim()
                    + "',PhoneNumber='" + PhoneNumber.Text.Trim() + "',Management='" + Management.Text.Trim() + "',QQ_Num='"
                    + QQ_Num.Text.Trim() + "',WeChat_Num='" + WeChat_Num.Text.Trim() + "',Card_Num='" + Card_Num.Text.Trim()
                    + "',AwaitModel='" + AwaitModel.Text.Trim() + "',MobileNetwork='" + MobileNetwork.Text.Trim()
                    + "',SetOperation='" + SetOperation.Text.Trim() + "'";
                try
                {
                    ComSQL(str);
                    label57.Text = "提示：" + ST_Name2.Text.ToString() + "手机数据更新成功！";
                }
                catch (Exception e0)
                {
                    MessageBox.Show(e0.ToString());
                }
            }
            finally
            {
                SetPeopleColor2();
            }
            
        }

        private void button36_Click(object sender, EventArgs e)
        {
            string str = "delete from Phones where ST_Num='" + dataGridView7.CurrentRow.Cells[1].Value .ToString() + "'";
            try
            {
                ComSQL(str);
                label57.Text ="提示："+ ST_Name2.Text + "手机数据删除成功！";
                /*object sender1 = new object();
                EventArgs e1 = new EventArgs();
                button38_Click(sender1,e1);*/
                PhoneModel.Text = null;
                PhoneNumber.Text = null;
                Management.Text = null;
                QQ_Num.Text = null;
                WeChat_Num.Text = null;
                Card_Num.Text = null;
                AwaitModel.Text = null;
                MobileNetwork.Text = null;
                SetOperation.Text = null;

            }
            catch (Exception e0)
            {
                MessageBox.Show(e0.ToString());
            }
            finally
            {
                SetPeopleColor2(); 
            }
            
        }
        
        private void comboBox8_MouseClick(object sender, MouseEventArgs e)
        {
            SqlConnection sqlConn = new SqlConnection("server="+ipAdress+";database=ErYingDatabase; uid=sa; pwd=9876543q");
            if (radioButton12.Checked == true)
            {
                SqlDataAdapter sda4 = new SqlDataAdapter("select distinct ST_Num from ST_Information", sqlConn);
                DataSet ds1 = new DataSet();
                sda4.Fill(ds1, "emp");

                comboBox8.DataSource = ds1.Tables[0];
                comboBox8.DisplayMember = "ST_Num";
            }
            else
            {
                SqlDataAdapter sda1 = new SqlDataAdapter("select distinct ST_name from ST_Information", sqlConn);
                DataSet ds1 = new DataSet();
                sda1.Fill(ds1, "emp");
                DataRow r= ds1.Tables[0].NewRow();
                r["ST_name"] = "所有人员";
                ds1.Tables[0].Rows.InsertAt(r, 0);
                comboBox8.DataSource = ds1.Tables[0];
                comboBox8.DisplayMember = "ST_name";
            }
            if ("所有人员".Equals (comboBox8 .Text))
            {
                comboBox8.Text = "";
            }
            //comboBox4.Text = "所有人员";
        }

        private void button38_Click(object sender, EventArgs e)
        {
            if (comboBox8.Text == "所有人员")
            {
                //SqlConnection conn = new SqlConnection();
                SqlConnection sqlConn = new SqlConnection("server="+ipAdress+";database=ErYingDatabase; uid=sa; pwd=9876543q");
                SqlDataAdapter sda = new SqlDataAdapter("select ST_name as '姓名',ST_Num as '证件号',ST_PreSchool as '所属班排',ST_IDNum as '身份证号' from ST_Information "
                     , sqlConn);
                DataSet ds = new DataSet();
                sda.Fill(ds, "emp");
                dataGridView7.DataSource = ds.Tables[0];
            }
            else
            {
                if (radioButton12.Checked == true)
                {


                    //SqlConnection conn = new SqlConnection();
                    SqlConnection sqlConn = new SqlConnection("server="+ipAdress+";database=ErYingDatabase; uid=sa; pwd=9876543q");
                    SqlDataAdapter sda = new SqlDataAdapter("select ST_name as '姓名',ST_Num as '证件号',ST_PreSchool as '所属班排',ST_IDNum as '身份证号' from ST_Information where ST_Num='" +
                        comboBox8.Text + "'", sqlConn);
                    DataSet ds = new DataSet();
                    try
                    {
                        sda.Fill(ds, "emp");
                        dataGridView7.DataSource = ds.Tables[0];
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
                    SqlConnection sqlConn = new SqlConnection("server="+ipAdress+";database=ErYingDatabase; uid=sa; pwd=9876543q");
                    SqlDataAdapter sda = new SqlDataAdapter("select ST_name as '姓名',ST_Num as '证件号',ST_PreSchool as '所属班排',ST_IDNum as '身份证号' from ST_Information where ST_name='" +
                        comboBox8.Text + "'", sqlConn);
                    DataSet ds = new DataSet();
                    sda.Fill(ds, "emp");
                    dataGridView7.DataSource = ds.Tables[0];
                    if (sqlConn.State != ConnectionState.Open)
                    {
                        sqlConn.Dispose(); sqlConn.Dispose();
                    }
                }
            }
            SetPeopleColor2();
        }

        private void dataGridView7_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            if (dataGridView7.SelectedCells.Count != 0)
            {

                //得到选中行某列的值
                string str0 = dataGridView7.CurrentRow.Cells[1].Value.ToString();

                try
                {
                    string str = "Select ST.ST_name,ST.ST_Num ,SU.PhoneNumber,SU.PhoneModel,SU.Management," +
                        "SU.QQ_Num,SU.Card_Num,SU.AwaitModel,SU.MobileNetwork,SU.SetOperation ,SU.WeChat_Num from(select*from " +
                        "ST_Information where ST_Num='" + str0 + "')as ST left outer join (select*from Phones )as SU " +
                        "on ST.ST_Num=SU.ST_Num";
                    //ST_experience.Text = str;
                    DataSet t = SelectSQL(str);
                    ST_Name2.Text = t.Tables[0].Rows[0][0].ToString();
                    ST_Num2.Text = t.Tables[0].Rows[0][1].ToString();
                    PhoneNumber .Text = t.Tables[0].Rows[0][2].ToString();
                    PhoneModel .Text = t.Tables[0].Rows[0][3].ToString();
                    Management .Text = t.Tables[0].Rows[0][4].ToString();
                    QQ_Num .Text = t.Tables[0].Rows[0][5].ToString();
                    Card_Num .Text = t.Tables[0].Rows[0][6].ToString();
                    AwaitModel .Text = t.Tables[0].Rows[0][7].ToString();
                    MobileNetwork .Text = t.Tables[0].Rows[0][8].ToString();
                    SetOperation .Text = t.Tables[0].Rows[0][9].ToString();
                    WeChat_Num .Text = t.Tables[0].Rows[0][10].ToString();
                    ShowPhoneLend();
                    //string str

                }
                catch (Exception e1)
                {
                    MessageBox.Show(e1.ToString());
                }
            }
            }

        private void File_Accepter_TextChanged(object sender, EventArgs e)
        {

        }

        private void button35_Click(object sender, EventArgs e)
        {
            if (comboBox7.Text == "所有文件")
            {
                //SqlConnection conn = new SqlConnection();
                SqlConnection sqlConn = new SqlConnection("server="+ipAdress+";database=ErYingDatabase; uid=sa; pwd=9876543q");
                SqlDataAdapter sda = new SqlDataAdapter("select File_Num as '文件编号',File_Title as '文件标题',File_Class " +
                    "as '密级',File_Time as '发文月日',File_Amount as '份数',File_Accepter as '收者签名', File_Place as '存放位置'," +
                    "File_Notes as '附注' from Files order by File_Class", sqlConn);
                DataSet ds = new DataSet();
                sda.Fill(ds, "emp");
                dataGridView6.DataSource = ds.Tables[0];
                SetFileColor();
            }
            else
            {                if (radioButton10.Checked == true)
                {


                    //SqlConnection conn = new SqlConnection();
                    SqlConnection sqlConn = new SqlConnection("server="+ipAdress+";database=ErYingDatabase; uid=sa; pwd=9876543q");
                    SqlDataAdapter sda = new SqlDataAdapter("select File_Num as '文件编号',File_Title as '文件标题',File_Class " +
                        "as '密级',File_Time as '发文月日',File_Amount as '份数',File_Accepter as '收者签名', File_Place as '存放位置'," +
                        "File_Notes as '附注' from Files  where File_Num ='" + comboBox7.Text + "'", sqlConn);
                    DataSet ds = new DataSet();
                    try
                    {
                        sda.Fill(ds, "emp");
                        dataGridView6.DataSource = ds.Tables[0];
                        SetFileColor();
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
                    SqlConnection sqlConn = new SqlConnection("server="+ipAdress+";database=ErYingDatabase; uid=sa; pwd=9876543q");
                    SqlDataAdapter sda = new SqlDataAdapter("select File_Num as '文件编号',File_Title as '文件标题',File_Class " +
                        "as '密级',File_Time as '发文月日',File_Amount as '份数',File_Accepter as '收者签名', File_Place as '存放位置'," +
                        "File_Notes as '附注' from Files where File_Title ='" + comboBox7.Text + "'" , sqlConn);
                    DataSet ds = new DataSet();
                    sda.Fill(ds, "emp");
                    dataGridView6.DataSource = ds.Tables[0];
                    SetFileColor();
                    if (sqlConn.State != ConnectionState.Open)
                    {
                        sqlConn.Dispose(); sqlConn.Dispose();
                    }
                }
                
            }

        }

        //数据库插入、更新、删除函数
        private void ComSQL(string str)
        {
            SqlConnection conn = new SqlConnection("server="+ipAdress+";database=ErYingDatabase; uid=sa; pwd=9876543q");
            if (conn.State != ConnectionState.Open)
            {
                conn.Open();
            }
            SqlCommand sqlcmd = new SqlCommand();
            sqlcmd.Connection = conn;
            sqlcmd.CommandText = str ;
            sqlcmd.CommandType = CommandType.Text;
            sqlcmd.ExecuteNonQuery();
            if (conn.State == ConnectionState.Open)
            {
                conn.Dispose(); conn.Dispose();
            }

        }

        private void tabPage12_Click(object sender, EventArgs e)
        {

        }

        //向数据库中插入数控件中的数据
        private void InsertSQL(string [] str,TextBox []  c,string table0)
        {
            string str0 = "insert " + table0+"(";
            for (int i=0;i<str .Length;i++)
            {
                str0 += str[i];
                if (i <str .Length - 1)
                {
                    str0 += ",";
                }
            }
            str0 += ") values('";
            for (int i=0;i<c.Length;i++)
            {
                str0 += c[i].Text.Trim()+"'";
                if (i <c .Length - 1)
                {
                    str0 += ",'";
                }
            }
            str0 += ")";
            ComSQL(str0);
        }
        //插入数据重载
        private void InsertSQL(string[] str, DataGridView d, string table0)
        {
            string str0 ;
            for (int k=0;k<d.Rows .Count-1;k++)
            {
                str0 = "insert " + table0 + "(";
                for (int i = 0; i < str.Length; i++)
                {
                    str0 += str[i];
                    if (i < str.Length - 1)
                    {
                        str0 += ",";
                    }
                }
                str0 += ") values('";
                for (int i = 0; i < str .Length; i++)
                {
                    str0 += d .Rows [k].Cells [i].Value .ToString () + "'";
                    if (i < str .Length - 1)
                    {
                        str0 += ",'";
                    }
                }
                str0 += ")";
                ComSQL(str0);

            }
            
        }
        //更新数据库数据
        private void UpdateSQL(string [] str,TextBox [] c,string table0,string strc)
        {
            string str0 = "update " + table0 + " set ";
            for (int i=0;i<str .Length; i++)
            {
                str0 += str[i] + "='" + c[i].Text.Trim() + "'";
                if (i<str .Length - 1)
                {
                    str0 += ",";
                }
            }
            str0 += " where "+strc;
            ComSQL(str0);

        }
        //更新数据库数据重载
        private void UpdateSQL(string[] str, DataGridView d, string table0, int posc)
        {
            string str0;
            for (int k=0;k<d.Rows .Count-1;k++)
            {
                str0 = "update " + table0 + " set ";
                for (int i = 0; i < str.Length; i++)
                {
                    str0 += str[i] + "='" + d.Rows [k].Cells[i ].Value .ToString ()  + "'";
                    if (i < str.Length - 1)
                    {
                        str0 += ",";
                    }
                }
                str0 += " where " + str [posc ]+"='"+ d.Rows[k].Cells[posc ].Value.ToString()+"'";
                ComSQL(str0);

            }
        }
        private void UpdateSQL(string[] str, DataGridView d, string table0, int[] posc)
        {
            string str0;
            for (int k = 0; k < d.Rows.Count - 1; k++)
            {
                str0 = "update " + table0 + " set ";
                for (int i = 0; i < str.Length; i++)
                {
                    str0 += str[i] + "='" + d.Rows[k].Cells[i].Value.ToString() + "'";
                    if (i < str.Length - 1)
                    {
                        str0 += ",";
                    }
                }
                str0 += " where ";
                for (int i=0;i<posc .Length;i++)
                {
                    str0 +=   str[posc[i]] + "='" + d.Rows[k].Cells[posc[i ]].Value.ToString() + "'";
                    if (i <posc.Length - 1)
                    {
                        str0 += "and ";
                    }
                }
               
                ComSQL(str0);

            }
        }
        //删除数据库数据
        private void DeleteSQL(string  table0,string strc)
        {
            string str0 = "delete from " + table0 + " where " + strc;
            ComSQL(str0);
        }
        //删除数据库函数重载
        private void DeleteSQL(string table0,DataGridView d, string strc,int posc)
        {
            //strc:删除数据的索引字段字符串
            string str0;
            for (int k = 0; k < d.RowCount-1; k++)
            {
                str0 = "delete from " + table0 + " where "+strc +"='"+d .Rows[k ].Cells [posc ]+"'";
                ComSQL(str0);
            }
        }

        private void button32_Click(object sender, EventArgs e)
        {
            try
            {
                DeleteSQL("Files", "File_Num='" + File_Num.Text.Trim()+"'and File_Class='"+File_Class .Text .Trim ()+"'");
                label57.Text = "提示：文件《" + File_Title.Text + "》删除成功！";
                object sender1 = new object(); EventArgs e1 = new EventArgs();
                button35_Click(sender1,e1 );
                SetFileColor();
            }
            catch(Exception e0)
            {
                MessageBox.Show(e0.ToString());
                label57.Text = "提示：文件《"+File_Title .Text +"》删除失败！";
            }
        }

        private void dataGridView6_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            
            if (dataGridView6.SelectedCells.Count != 0)
            {
                File_Num.Text = dataGridView6.CurrentRow.Cells[0].Value.ToString();
                File_Title.Text = dataGridView6.CurrentRow.Cells[1].Value.ToString();
                File_Class.Text = dataGridView6.CurrentRow.Cells[2].Value.ToString();
                File_Time.Text = dataGridView6.CurrentRow.Cells[3].Value.ToString();
                File_Amount.Text = dataGridView6.CurrentRow.Cells[4].Value.ToString();
                File_Accepter.Text = dataGridView6.CurrentRow.Cells[5].Value.ToString();
                File_Place .Text = dataGridView6.CurrentRow.Cells[6].Value.ToString();
                File_Notes .Text = dataGridView6.CurrentRow.Cells[7].Value.ToString();
                //string str="select "
                ShowFileLend();
                

            }
        }

        private void dataGridView6_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {
            
        }

        private void radioButton14_CheckedChanged(object sender, EventArgs e)
        {
            if (radioButton14 .Checked ==true)//选择装备出入库
            {
                groupBox8.Text = "出入库登记";
                label64.Text = "出入库情况";
                label59.Text = "出库时间";
                label60.Text = "入库时间";
                Eq_inDate.Visible = true;
                label62.Text = "事        由";
                label63.Text = "负  责  人";
                RepairPersonText.Visible = false;
                RepairType.Visible = false;
                RepairPerson.Visible = false;
                groupBox8.Text = "出入库登记";
                ShowEqInOut();

            }
            else
            {
                groupBox8.Text = "装备维护登记";
                label64.Text = "维修保养情况";
                label59.Text = "维护时间";
                label60.Text = "维护种类";
                Eq_inDate.Visible = false ;
                label62.Text = "内容问题";
                //label63.Text = "负  责  人";
                RepairPersonText.Visible = true ;
                RepairType.Visible = true ;
                RepairPerson.Visible = true;
                groupBox8.Text = "维修登记";
                ShowEqRepair();
            }
        }

        private void DeleteSQL(string table0, DataGridView d, string[] strc, int[] posc)
        {
            //strc:删除数据的索引字段字符串
            string str0;
            for (int k = 0; k < d.RowCount - 1; k++)
            {
                str0 = "delete from " + table0 + " where " ;
                for (int i=0;i<posc.Length; i++)
                {
                    str0 += strc[i] + "='" + d.Rows[k].Cells[i].Value.ToString() + "'";
                    if (i<posc .Length - 1)
                    {
                        str0 += "and";
                    }
                }
                ComSQL(str0);
            }
        }
        private void ShowEqInOut()
        {
            SqlConnection sqlConn = new SqlConnection("server="+ipAdress+";database=ErYingDatabase; uid=sa; pwd=9876543q");
            SqlDataAdapter sda = new SqlDataAdapter("select Eq_outDate as '出库日期',Eq_inDate as '入库日期',Eq_event as '事由',Eq_principal as '负责人' from Eq_move where Eq_Id='"
                + dataGridView4.CurrentRow.Cells[12].Value.ToString() + "'"
                 , sqlConn);
            DataSet ds = new DataSet();
            sda.Fill(ds, "emp");
            dataGridView5.DataSource = ds.Tables[0];
            EqInOut();
            dataGridView5.AutoSizeColumnsMode  = DataGridViewAutoSizeColumnsMode .Fill ;
        }
        private void ShowEqRepair()
        {
            string str = "select RepairTime as '维修时间',RepairType as'维护保养种类',RepairContent as '维护保养内容、情况及存在问题'," +
                "RepairPerson as '参加人数',Eq_principal as'负责人'from Eq_Repair where Eq_Num='" + Eq_num.Text.Trim() + "'";
            DataSet d= SelectSQL (str);
            dataGridView5.DataSource = d.Tables[0];
            dataGridView5.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.AllCells;
            EqInOut();
        }

        private void button42_Click(object sender, EventArgs e)
        {
            string table0 = "File_Lend";
            string[] str1 = { "LendTime", "LendAmount", "LendNum ", "LendUse", "LendPerson",  "File_Num","File_Class" };
            TextBox[] b = new TextBox[7];
            b[0] = new TextBox();b[0].Text = LendTime.Value.Year.ToString() + "-" + LendTime.Value.Month .ToString() + "-" +
                LendTime.Value.Day .ToString();
            b[1] = LendAmount;
            b[2] = LendNum;
            b[3] = LendUse;
            b[4] = LendPerson;
            b[5] = File_Num ;
            b[6] = File_Class;

            try
            {
                InsertSQL(str1, b, table0);
                label57.Text ="提示："+ LendTime.Value.ToString() + LendPerson.Text + "成功借阅文件！";
                ShowFileLend();
                SetFileLendColor();
            }
            catch(Exception e0)
            {
                MessageBox.Show(e0.ToString());
                label57.Text =  "提示：操作有误，借阅失败！";
            }
            

           // b[5] = new TextBox();b [5].Text = ReturnTime .Value.Year.ToString() + "-" + ReturnTime.Value.Month.ToString() + "-" +
            //    ReturnTime.Value.Day.ToString();
            

        }

        private void button41_Click(object sender, EventArgs e)
        {
            try
            {
                string table0 = "File_Lend";
                string strc = "File_Num ='" + File_Num.Text.Trim() + "'and LendTime='" + dataGridView10 .CurrentRow .Cells [0] .Value .ToString () + "'and LendPerson='"
                    + dataGridView10.CurrentRow.Cells[4].Value.ToString() + "'and File_Class='"+File_Class .Text .Trim ()+"'and LendAmount='"+
                    dataGridView10 .CurrentRow.Cells[2].Value.ToString() +"'";
                DeleteSQL(table0, strc);
                ShowFileLend();
                SetFileLendColor();
            }
            catch(Exception e0)
            {
                MessageBox.Show(e0.ToString());
            }
            
        }

        private void button33_Click_1(object sender, EventArgs e)
        {
            try
            {
                string table0 = "File_Lend";
                string[] str = { "ReturnTime", "DeletingPerson", "Notes" };
                TextBox[] b = new TextBox[3];
                b[0] = new TextBox(); b[0].Text = ReturnTime.Value.Year.ToString() + "-" + ReturnTime.Value.Month.ToString() +
                    "-" + ReturnTime.Value.Day.ToString();
                b[1] = DeletingPerson;
                b[2] = Notes;
                string strc = " File_Num='" + File_Num.Text.Trim() + "'and LendTime='" +dataGridView10 .CurrentRow .Cells [0].Value .ToString () 
                    + "'and LendPerson='" +
                     dataGridView10.CurrentRow.Cells[4].Value.ToString() + "' and File_Class='"+File_Class .Text .Trim ()+ "'and LendAmount='" +
                    dataGridView10.CurrentRow.Cells[2].Value.ToString() + "'";
                UpdateSQL(str, b, table0, strc);
                label57.Text = "提示：" + dataGridView10.CurrentRow.Cells[4].Value.ToString() + "于" + ReturnTime.Value.Day.ToString() + "归还文件";
                ShowFileLend();
                SetFileLendColor();

            }
            catch(Exception e0)
            {
                MessageBox.Show(e0.ToString());
            }
            
        }

        private void button27_Click(object sender, EventArgs e)
        {
            string str= "update File_lend set ReturnTime=null,DeletingPerson='',Notes='' where  File_Num = '" + File_Num.Text.Trim() + "'and LendTime = '" +dataGridView10 .CurrentRow .Cells [0].Value .ToString () 
                       + "'and LendPerson='" +
                        dataGridView10.CurrentRow.Cells[4].Value.ToString() + "' and File_Class='" + File_Class.Text.Trim() + "'and LendAmount='" +
                       dataGridView10.CurrentRow.Cells[2].Value.ToString() + "'";
            try
            {
                ComSQL(str);
                label57.Text = "提示：删除了一条注销数据！";
                ShowFileLend();
            }
            catch(Exception e0)
            {
                MessageBox.Show(e0.ToString());
            }
           
        }

        private void button46_Click(object sender, EventArgs e)
        {
            try
            {
                if (radioButton18.Checked  == true)
                {
                    string str = "select PrintNum as '序号',PrintDate as '日期',PrintTitle as '文件标题',PrintClass " +
                        "as '密级',PrintAmount as '份数',PrintPage as '页数',PrintUse as '用途',PrintPrincipal as '责任人',PrintNotes as '备注'" +
                        " from PrintFile where PrintDate='" + dateTimePicker5.Value.Year.ToString() + "-" + dateTimePicker5.Value.Month.ToString()
                        + "-" + dateTimePicker5.Value.Day.ToString() + "'";
                    DataSet d = SelectSQL(str);
                    dataGridView11.DataSource = d.Tables[0];
                }
                else
                {
                    if (comboBox9.Text == "所有文件")
                    {
                        //SqlConnection conn = new SqlConnection();
                        SqlConnection sqlConn = new SqlConnection("server="+ipAdress+";database=ErYingDatabase; uid=sa; pwd=9876543q");
                        SqlDataAdapter sda = new SqlDataAdapter("select PrintNum as '序号',PrintDate as '日期',PrintTitle as '文件标题',PrintClass " +
                            "as '密级',PrintAmount as '份数',PrintPage as '页数',PrintUse as '用途',PrintPrincipal as '责任人',PrintNotes as '备注'" +
                            " from PrintFile"
                             , sqlConn);
                        DataSet ds = new DataSet();
                        sda.Fill(ds, "emp");
                        dataGridView11.DataSource = ds.Tables[0];
                    }
                    else
                    {
                        //SqlConnection conn = new SqlConnection();
                        SqlConnection sqlConn = new SqlConnection("server="+ipAdress+";database=ErYingDatabase; uid=sa; pwd=9876543q");
                        SqlDataAdapter sda = new SqlDataAdapter("select PrintNum as '序号',PrintDate as '日期',PrintTitle as '文件标题',PrintClass " +
                            "as '密级',PrintAmount as '份数',PrintPage as '页数',PrintUse as '用途',PrintPrincipal as '责任人',PrintNotes as '备注'" +
                            " from PrintFile where PrintTitle='" + PrintTitle.Text.Trim() + "'"
                             , sqlConn);
                        DataSet ds = new DataSet();
                        sda.Fill(ds, "emp");
                        dataGridView11.DataSource = ds.Tables[0];
                    }
                }
            }
            catch(Exception e0)
            {
                MessageBox.Show(e0.ToString());
            }
            SetPrintColor();



        }

        private void radioButton18_CheckedChanged(object sender, EventArgs e)
        {
            if (radioButton18 .Checked ==true)
            {
                dateTimePicker5.Visible = true;comboBox9.Visible = false;
                dateTimePicker5.Value = DateTime.Now;

            }
            else
            {
                dateTimePicker5.Visible = false ; comboBox9.Visible = true ;

            }
        }

        private void dataGridView11_CellClick(object sender, DataGridViewCellEventArgs e)
        {
           if ( dataGridView11.SelectedCells.Count != 0)
            {
                PrintNum.Text = dataGridView11.CurrentRow.Cells[0].Value.ToString();
               // PrintDate.Value = (DateTime)(dataGridView11.CurrentRow.Cells[0].Value.ToString());
                PrintTitle.Text  = dataGridView11.CurrentRow.Cells[2].Value.ToString();
                PrintClass.Text  = dataGridView11.CurrentRow.Cells[3].Value.ToString();
                PrintAmount .Text = dataGridView11.CurrentRow.Cells[4].Value.ToString();
                PrintPage.Text  = dataGridView11.CurrentRow.Cells[5].Value.ToString();
                PrintUse.Text  = dataGridView11.CurrentRow.Cells[6].Value.ToString();
                PrintPrincipal .Text = dataGridView11.CurrentRow.Cells[7].Value.ToString();
                PrintNotes.Text  = dataGridView11.CurrentRow.Cells[8].Value.ToString();
            }
        }

        private void button45_Click(object sender, EventArgs e)
        {
            string table0 = "PrintFile";
            string[] str = { "PrintNum", "PrintDate", "PrintTitle", "PrintClass", "PrintAmount", "PrintPage", "PrintUse",
                    "PrintPrincipal" ,"PrintNotes"};
            TextBox[] t = new TextBox[9];
            t[0] = PrintNum;
            t[1] = new TextBox(); t[1].Text = PrintDate.Value.Year.ToString() + "-" + PrintDate.Value.Month.ToString() +
                 "-" + PrintDate.Value.Day.ToString();
            t[2] = PrintTitle;
            t[3] = PrintClass;
            t[4] = PrintAmount;
            t[5] = PrintPage;
            t[6] = PrintUse;
            t[7] = PrintPrincipal;
            t[8] = PrintNotes;
            try
            {              
                InsertSQL(str, t, table0);
                label57.Text = "提示：编号为" + PrintNum.Text + "的打印记录添加成功！";
                object sender1 = new object(); EventArgs e1 = new EventArgs();
                button46_Click(sender1, e1);

            }
            catch
            {
                try
                {
                    string strc = "PrintNum='" + PrintNum.Text.Trim()+"'";
                    UpdateSQL (str, t, table0,strc );
                    label57.Text = "提示：编号为" + PrintNum.Text + "的打印记录更新成功！";
                    object sender1 = new object(); EventArgs e1 = new EventArgs();
                    button46_Click(sender1, e1);
                }
                catch(Exception e0)
                {
                    MessageBox.Show(e0.ToString());
                }

            }
            finally
            {
                SetPrintColor();
            }
        }

        private void button44_Click(object sender, EventArgs e)
        {
            string table0 = "PrintFile";
            string strc = "PrintNum='" + dataGridView11.CurrentRow.Cells[0].Value.ToString() + "'";
            try
            {
                DeleteSQL(table0, strc);
                label57.Text = "提示：序号为" + dataGridView11.CurrentRow.Cells[0].Value.ToString() + "的数据删除成功！";
                object sender1 = new object(); EventArgs e1 = new EventArgs();
                button46_Click(sender1, e1);
                SetPrintColor();

            }
            catch(Exception e0)
            {
                MessageBox.Show(e0.ToString());
            }
        }

        private void comboBox9_Click(object sender, EventArgs e)
        {
            SqlConnection sqlConn = new SqlConnection("server="+ipAdress+";database=ErYingDatabase; uid=sa; pwd=9876543q");
            SqlDataAdapter sda1 = new SqlDataAdapter("select distinct  PrintTitle   from PrintFile" , sqlConn);
            DataSet ds1 = new DataSet();
            sda1.Fill(ds1, "emp");

            comboBox9 .DataSource = ds1.Tables[0];
            comboBox9.DisplayMember = "PrintTitle";
            comboBox9.Text = "所有文件";

            
        }

        private void button22_Click_1(object sender, EventArgs e)
        {
            //Stream aa;
            OpenFileDialog openFileDialog1 = new OpenFileDialog();
            openFileDialog1.Filter = "*jpg|*.JPG|*.GIF|*.GIF|*.BMP|*.BMP|*.png|*.PNG";
            if (openFileDialog1.ShowDialog() == DialogResult.OK)
            {
                string fullpath = openFileDialog1.FileName;//文件路径   
                Image imgRead = Image.FromFile(fullpath);
                pictureBox2.Image = new Bitmap(imgRead);
                imgRead.Dispose();
                imagebytes = GetImageBytes(pictureBox2.Image);
            }
        }

        private void button40_Click(object sender, EventArgs e)
        {
            string table0 = "PhoneLend";
            string[] str1 = { "ST_Num","PhoneTime","PhoneOperate","PhonePrincipal","PhoneNote"};
            TextBox[] t = new TextBox[5];
            t[0] = ST_Num2;
            t[1] =new TextBox ();t[1].Text = PhoneTime.Value.Year.ToString()+ "-" + PhoneTime.Value.Month .ToString() + "-" + PhoneTime.Value.Day .ToString() + " " + PhoneTime.Value.TimeOfDay.ToString();
            t[2] = new TextBox ();t[2].Text = "取用";
            t[3] = PhonePrincipal;
            t[4] = PhoneNote;
            try
            {
                InsertSQL(str1, t, table0);
                label57.Text = "提示："+ST_name.Text + "在" + t[1].Text + "取用了手机！";
                ShowPhoneLend();

            }
            catch(Exception e0)
            {
                MessageBox.Show(e0.ToString());
            }

        }

        private void ShowFileLend()
        {
            try
            {
                string str = "select LendTime as '借阅时间',LendNum as '卷号份次',LendAmount as'份数', LendUse as '利用效果',LendPerson as" +
                "'借阅人',ReturnTime as '归还时间',DeletingPerson as '注销人',Notes as '备注'From File_Lend where File_Num='"
                + File_Num.Text.Trim() + "'and File_Class='"+File_Class .Text .Trim ()+"'order by LendTime";
                DataSet d = SelectSQL(str);
                dataGridView10.DataSource = d.Tables[0];
                SetFileLendColor();
            }
            catch (Exception e0)
            {
                MessageBox.Show(e0.ToString());
            }
            
        }

        private void button47_Click(object sender, EventArgs e)
        {
            string table0 = "PhoneLend";
            string[] str1 = { "ST_Num", "PhoneTime", "PhoneOperate", "PhonePrincipal", "PhoneNote" };
            TextBox[] t = new TextBox[5];
            t[0] = ST_Num2;
            t[1] = new TextBox(); t[1].Text = PhoneTime.Value.Year.ToString() + "-" + PhoneTime.Value.Month.ToString() + "-" + PhoneTime.Value.Day.ToString() + " " + PhoneTime.Value.TimeOfDay.ToString();
            t[2] = new TextBox(); t[2].Text = "归还";
            t[3] = PhonePrincipal;
            t[4] = PhoneNote;
            try
            {
                InsertSQL(str1, t, table0);
                label57.Text = "提示："+ST_name.Text + "在" + t[1].Text + "归还了手机！";
                ShowPhoneLend();

            }
            catch (Exception e0)
            {
                MessageBox.Show(e0.ToString());
            }
        }

        private void button39_Click(object sender, EventArgs e)
        {
            string table0 = "PhoneLend";
            string strc = "PhoneTime='" + dataGridView9.CurrentRow.Cells[0].Value.ToString() + "'and ST_Num='" + ST_Num2.Text.Trim() +
                "'and PhoneOperate='" + dataGridView9.CurrentRow.Cells[1].Value.ToString() + "'";
            DeleteSQL(table0, strc);
            ShowPhoneLend();
        }

        private void dataGridView8_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {

        }

        private void ShowPhoneLend()
        {

            string str = "select PhoneTime as '时间',PhoneOperate as '操作',PhonePrincipal as '责任人',PhoneNote as '备注'from PhoneLend where " +
                "ST_Num='"+ST_Num2 .Text .Trim ()+"'order by PhoneTime";
            DataSet d = SelectSQL(str);
            dataGridView9.DataSource = d.Tables[0];
            SetPhoneClolor();

        }

        private void dataGridView8_CellClick(object sender, DataGridViewCellEventArgs e)
        {

        }

        private void button43_Click(object sender, EventArgs e)
        {
            string table0 = "PersonLeave";
            string strc="All_notingtime='" + dateTimePicker1.Value.Year.ToString() + "-" +
                    dateTimePicker1.Value.Month.ToString() + "-" + dateTimePicker1.Value.Day.ToString()+"'";
            DeleteSQL(table0, strc);
            string[] str = { "Name", "Position", "Reason", "OutTime", "Leader", "LeaveTime", "BackTime",
                "OverTime", "All_notingtime" };
            string str0=null ;
            for (int i = 0; i < dataGridView8.Rows .Count -1; i++)

            {
                str0 = "insert PersonLeave (";
                for (int ii = 0; ii < 9; ii++)
                {
                    str0 += str[ii];
                    if (ii < 8)
                    {
                        str0 += ",";
                    }

                }
                str0 += ")values(";
                for (int k = 0; k < 8; k++)
                {
                    str0 += "'" + dataGridView8.Rows[i].Cells[k].Value .ToString () + "',";

                }
                str0 += "'"+dateTimePicker1.Value.Year.ToString() + "-" +
                    dateTimePicker1.Value.Month.ToString() + "-" + dateTimePicker1.Value.Day.ToString()+"')";
                try
                {
                    ComSQL(str0);
                }
                catch(Exception e0)
                {
                    MessageBox.Show(e0.ToString());
                }
               

            }
                label57.Text = "提示："+(dataGridView8.RowCount - 1 )+ "名人员请假外出数据添加成功！";
            SetPeopleLeaveColor();




        }

        private void checkedListBox1_SelectedIndexChanged_1(object sender, EventArgs e)
        {

        }

        private void groupBox16_Enter(object sender, EventArgs e)
        {

        }

        private void radioButton19_CheckedChanged(object sender, EventArgs e)
        {

        }

        private void label20_Click_1(object sender, EventArgs e)
        {

        }

        private void ShowPersonLeave()
        {

            string str = "Select Name as'姓名',Position as '职务',Reason as '事由',OutTime as '小时数或天数',Leader as '准假部门',LeaveTime as " +
                "'离队时间',BackTime as '归队时间',OverTime as'超（误）假时（天）数' from PersonLeave where All_notingtime='" + dateTimePicker1.Value.Year.ToString() + "-" + 
                dateTimePicker1.Value.Month.ToString() + "-" + dateTimePicker1.Value.Day.ToString() + "'";
            DataSet d = SelectSQL(str);
            dataGridView8.DataSource = d.Tables[0];
            
            //dataGridView8.Columns[8].Visible = false;

        }
        private void SetPhoneClolor()
        {
            for (int i=0;i<dataGridView9 .Rows .Count - 1; i++)
            {
                if ("取用".Equals (dataGridView9 .Rows [i].Cells [1].Value .ToString()))
                {
                    dataGridView9.Rows[i].DefaultCellStyle.BackColor = Color.HotPink ;
                }
                else
                {
                    dataGridView9.Rows[i].DefaultCellStyle.BackColor = Color.LightGreen;
                }
            }
        }
        private void SetPeopleColor1()
        {
            for (int i = 0; i < dataGridView1.Rows.Count - 1; i++)
            {
                if (i%2==0)
                {
                    dataGridView1.Rows[i].DefaultCellStyle.BackColor = Color.Aqua;//DeepSkyBlue/DarkTurquoise/Gainsboro/MediumSpringGreen
                }
                else
                {
                    dataGridView1.Rows[i].DefaultCellStyle.BackColor = Color.White;//LightCyan/White//MintCream
                }
            }
        }
        private void SetPrintColor()
        {
            for (int i = 0; i < dataGridView11.Rows.Count - 1; i++)
            {
                if ("已回收".Equals(dataGridView11.Rows[i].Cells[8].Value.ToString()))
                {
                    dataGridView11.Rows[i].DefaultCellStyle.BackColor = Color.LightGreen;
                }
                else
                {
                    dataGridView11.Rows[i].DefaultCellStyle.BackColor = Color.LightPink;
                }
            }
        }
        private void SetPeopleColor2()
        {
            for (int i = 0; i < dataGridView7.Rows.Count - 1; i++)
            {
                if (i % 2 == 0)
                {
                    dataGridView7.Rows[i].DefaultCellStyle.BackColor = Color.Aqua;//DeepSkyBlue/DarkTurquoise/Gainsboro/MediumSpringGreen
                }
                else
                {
                    dataGridView7.Rows[i].DefaultCellStyle.BackColor = Color.White;//LightCyan/White//MintCream
                }
            }
        }
        private void SetGradesColor()
        {
            for (int i = 0; i < dataGridView2.Rows.Count - 1; i++)
            {
                if (i % 2 == 0)
                {
                    dataGridView2.Rows[i].DefaultCellStyle.BackColor = Color.Gainsboro;//DeepSkyBlue/DarkTurquoise/Aqua/MediumSpringGreen
                }
                else
                {
                    dataGridView2.Rows[i].DefaultCellStyle.BackColor = Color.White;//LightCyan/White//MintCream
                }
            }
        }
        private void SetPeopleLeaveColor()
        {
            for (int i = 0; i < dataGridView8.Rows.Count - 1; i++)
            {
                if (i % 2 == 0)
                {
                    dataGridView8.Rows[i].DefaultCellStyle.BackColor = Color.Gainsboro;//DeepSkyBlue/DarkTurquoise/Aqua/MediumSpringGreen
                }
                else
                {
                    dataGridView8.Rows[i].DefaultCellStyle.BackColor = Color.White;//LightCyan/White//MintCream
                }
            }
        }
        private void SetEqColor()
        {
            for (int i = 0; i < dataGridView4.Rows.Count - 1; i++)
            {
                if (i % 2 == 0)
                {
                    dataGridView4.Rows[i].DefaultCellStyle.BackColor = Color.MediumSpringGreen;//DeepSkyBlue/DarkTurquoise/Aqua/Gainsboro
                }
                else
                {
                    dataGridView4.Rows[i].DefaultCellStyle.BackColor = Color.White;//LightCyan/White//MintCream
                }
            }
        }
        private void EqInOut()
        {
            for (int i = 0; i < dataGridView5.Rows.Count - 1; i++)
            {
                if (i % 2 == 0)
                {
                    dataGridView5.Rows[i].DefaultCellStyle.BackColor = Color.DeepSkyBlue;//MediumSpringGreen/DarkTurquoise/Aqua/Gainsboro
                }
                else
                {
                    dataGridView5.Rows[i].DefaultCellStyle.BackColor = Color.White;//LightCyan/White//MintCream
                }
            }
        }
        private void SetFileColor()
        {
            for (int i = 0; i < dataGridView6.Rows.Count - 1; i++)
            {
                if ("机密".Equals(dataGridView6.Rows[i].Cells[2].Value.ToString()))
                {
                    dataGridView6.Rows[i].DefaultCellStyle.BackColor = Color.LightPink ;///DarkTurquoise//Gainsboro/
                }
                else if("秘密".Equals(dataGridView6.Rows[i].Cells[2].Value.ToString()))
                {
                    dataGridView6.Rows[i].DefaultCellStyle.BackColor = Color.DeepSkyBlue;//LightCyan/White//MintCream
                }
                else
                {
                    dataGridView6.Rows[i].DefaultCellStyle.BackColor = Color.MediumSpringGreen;
                }
            }
        }

        private void button2_MouseClick(object sender, MouseEventArgs e)
        {
            
        }

        private void button2_MouseMove(object sender, MouseEventArgs e)
        {
            button2.BackgroundImage = Properties.Resources._03;
        }

        private void button2_MouseDown(object sender, MouseEventArgs e)
        {
            button2.BackgroundImage = Properties.Resources._04;
        }

        private void button2_MouseUp(object sender, MouseEventArgs e)
        {
            button2.BackgroundImage = Properties.Resources._03;
        }

        private void button2_MouseLeave(object sender, EventArgs e)
        {
            button2.BackgroundImage = Properties.Resources._2;
        }

        private void button38_MouseDown(object sender, MouseEventArgs e)
        {
            button38.BackgroundImage = Properties.Resources._04;
        }

        private void button38_MouseUp(object sender, MouseEventArgs e)
        {
            button38.BackgroundImage = Properties.Resources._03;
        }

        private void button38_MouseMove(object sender, MouseEventArgs e)
        {
            button38.BackgroundImage = Properties.Resources._03;
        }

        private void button38_MouseLeave(object sender, EventArgs e)
        {
            button38.BackgroundImage = Properties.Resources._2;
        }

        private void button29_MouseDown(object sender, MouseEventArgs e)
        {
            button29.BackgroundImage = Properties.Resources._04;
        }

        private void button29_MouseLeave(object sender, EventArgs e)
        {
            button29.BackgroundImage = Properties.Resources._2;
        }

        private void button29_MouseMove(object sender, MouseEventArgs e)
        {
            button29.BackgroundImage = Properties.Resources._03;
        }

        private void button29_MouseUp(object sender, MouseEventArgs e)
        {
            button29.BackgroundImage = Properties.Resources._03;
        }

        private void button46_MouseDown(object sender, MouseEventArgs e)
        {
            button46.BackgroundImage = Properties.Resources._04;
        }

        private void button46_MouseLeave(object sender, EventArgs e)
        {
            button46.BackgroundImage = Properties.Resources._2;
        }

        private void button46_MouseMove(object sender, MouseEventArgs e)
        {
            button46.BackgroundImage = Properties.Resources._03;

        }

        private void button46_MouseUp(object sender, MouseEventArgs e)
        {
            button46.BackgroundImage = Properties.Resources._03;
        }

        private void button42_MouseDown(object sender, MouseEventArgs e)
        {
            button42.BackgroundImage = Properties.Resources.b43;
        }

        private void button42_MouseLeave(object sender, EventArgs e)
        {
            button42.BackgroundImage = Properties.Resources.b41;
        }

        private void button42_MouseMove(object sender, MouseEventArgs e)
        {
            button42.BackgroundImage = Properties.Resources.b42;
        }

        private void button42_MouseUp(object sender, MouseEventArgs e)
        {
            button42.BackgroundImage = Properties.Resources.b42;
        }

        private void button37_MouseDown(object sender, MouseEventArgs e)
        {
            button37.BackgroundImage = Properties.Resources.b43;
        }

        private void button37_MouseLeave(object sender, EventArgs e)
        {
            button37.BackgroundImage = Properties.Resources.b41;
        }

        private void button37_MouseMove(object sender, MouseEventArgs e)
        { 
            button37.BackgroundImage = Properties.Resources.b42;
        }

        private void button37_MouseUp(object sender, MouseEventArgs e)
        {
            button37.BackgroundImage = Properties.Resources.b42;
        }

        private void button21_MouseDown(object sender, MouseEventArgs e)
        {
            button21.BackgroundImage = Properties.Resources.b43;
        }

        private void button21_MouseLeave(object sender, EventArgs e)
        {
            button21.BackgroundImage = Properties.Resources.b41;
        }

        private void button21_MouseMove(object sender, MouseEventArgs e)
        {
            button21.BackgroundImage = Properties.Resources.b42;
        }

        private void button21_MouseUp(object sender, MouseEventArgs e)
        {
            button21.BackgroundImage = Properties.Resources.b42;
        }

        private void button28_MouseDown(object sender, MouseEventArgs e)
        {
            button28.BackgroundImage = Properties.Resources.b43;
        }

        private void button28_MouseLeave(object sender, EventArgs e)
        {
            button28.BackgroundImage = Properties.Resources.b41;
        }

        private void button28_MouseMove(object sender, MouseEventArgs e)
        {
            button28.BackgroundImage = Properties.Resources.b42;
        }

        private void button28_MouseUp(object sender, MouseEventArgs e)
        {
            button28.BackgroundImage = Properties.Resources.b42;
        }

        private void button3_MouseClick(object sender, MouseEventArgs e)
        {

        }

        private void button3_ControlRemoved(object sender, ControlEventArgs e)
        {
           // button28.BackgroundImage = Properties.Resources.b42;
        }

        private void button3_MouseDown(object sender, MouseEventArgs e)
        {
            button3.BackgroundImage = Properties.Resources.b43;
        }

        private void button3_MouseEnter(object sender, EventArgs e)
        {
           // button3.BackgroundImage = Properties.Resources.b43;
        }

        private void button3_MouseLeave(object sender, EventArgs e)
        {
            button3.BackgroundImage = Properties.Resources.b41;
        }

        private void button3_MouseMove(object sender, MouseEventArgs e)
        {
            button3.BackgroundImage = Properties.Resources.b42;
        }

        private void button3_MouseUp(object sender, MouseEventArgs e)
        {
            button3.BackgroundImage = Properties.Resources.b42;
        }

        private void button45_MouseDown(object sender, MouseEventArgs e)
        {
            button45.BackgroundImage = Properties.Resources.b43;
        }

        private void button45_MouseLeave(object sender, EventArgs e)
        {
            button45.BackgroundImage = Properties.Resources.b41;
        }

        private void button45_MouseMove(object sender, MouseEventArgs e)
        {

            button45.BackgroundImage = Properties.Resources.b42;
        }

        private void button45_MouseUp(object sender, MouseEventArgs e)
        {
            button45.BackgroundImage = Properties.Resources.b42;
        }

        private void button14_MouseDown(object sender, MouseEventArgs e)
        {
            button14.BackgroundImage = Properties.Resources.b43;
        }

        private void button14_MouseLeave(object sender, EventArgs e)
        {
            button14.BackgroundImage = Properties.Resources.b41;
        }

        private void button14_MouseMove(object sender, MouseEventArgs e)
        {
            button14.BackgroundImage = Properties.Resources.b42;
        }

        private void button14_MouseUp(object sender, MouseEventArgs e)
        {
            button14.BackgroundImage = Properties.Resources.b42;
        }

        private void button6_MouseDown(object sender, MouseEventArgs e)
        {
            button6.BackgroundImage = Properties.Resources.b43;
        }

        private void button23_MouseDown(object sender, MouseEventArgs e)
        {
            button23.BackgroundImage = Properties.Resources.b53;
        }

        private void button23_MouseLeave(object sender, EventArgs e)
        {
            button23.BackgroundImage = Properties.Resources.b51;
        }

        private void button23_MouseMove(object sender, MouseEventArgs e)
        {
            button23.BackgroundImage = Properties.Resources.b52;
        }

        private void button23_MouseUp(object sender, MouseEventArgs e)
        {
            button23.BackgroundImage = Properties.Resources.b52;
        }

        private void button7_MouseDown(object sender, MouseEventArgs e)
        {
            button7.BackgroundImage = Properties.Resources.b53;
        }

        private void button7_MouseLeave(object sender, EventArgs e)
        {
            button7.BackgroundImage = Properties.Resources.b51;
        }

        private void button7_MouseMove(object sender, MouseEventArgs e)
        {
            button7.BackgroundImage = Properties.Resources.b52;
        }

        private void button7_MouseUp(object sender, MouseEventArgs e)
        {
            button7.BackgroundImage = Properties.Resources.b52;
        }

        private void button36_MouseDown(object sender, MouseEventArgs e)
        {
            button36.BackgroundImage = Properties.Resources.b53;
        }

        private void button36_MouseLeave(object sender, EventArgs e)
        {
            button36.BackgroundImage = Properties.Resources.b51;
        }

        private void button36_MouseMove(object sender, MouseEventArgs e)
        {
            button36.BackgroundImage = Properties.Resources.b52;
        }

        private void button36_MouseUp(object sender, MouseEventArgs e)
        {
            button36.BackgroundImage = Properties.Resources.b52;
        }

        private void button39_MouseDown(object sender, MouseEventArgs e)
        {
            button39.BackgroundImage = Properties.Resources.b53;
        }

        private void button39_MouseLeave(object sender, EventArgs e)
        {
            button39.BackgroundImage = Properties.Resources.b51;
        }

        private void button39_MouseMove(object sender, MouseEventArgs e)
        {
            button39.BackgroundImage = Properties.Resources.b52;
        }

        private void button39_MouseUp(object sender, MouseEventArgs e)
        {
            button39.BackgroundImage = Properties.Resources.b52;
        }

        private void button5_MouseDown(object sender, MouseEventArgs e)
        {
            button5.BackgroundImage = Properties.Resources.b53;
        }

        private void button5_MouseLeave(object sender, EventArgs e)
        {
            button5.BackgroundImage = Properties.Resources.b51;
        }

        private void button5_MouseMove(object sender, MouseEventArgs e)
        {
            button5.BackgroundImage = Properties.Resources.b52;
        }

        private void button5_MouseUp(object sender, MouseEventArgs e)
        {
            button5.BackgroundImage = Properties.Resources.b52;
        }

        private void button26_MouseDown(object sender, MouseEventArgs e)
        {
            button26.BackgroundImage = Properties.Resources.b53;
        }

        private void button26_MouseLeave(object sender, EventArgs e)
        {
            button26.BackgroundImage = Properties.Resources.b51;
        }

        private void button26_MouseMove(object sender, MouseEventArgs e)
        {
            button26.BackgroundImage = Properties.Resources.b52;
        }

        private void button26_MouseUp(object sender, MouseEventArgs e)
        {
            button26.BackgroundImage = Properties.Resources.b52;
        }

        private void button31_MouseDown(object sender, MouseEventArgs e)
        {
            button31.BackgroundImage = Properties.Resources.b53;
        }

        private void button31_MouseLeave(object sender, EventArgs e)
        {
            button31.BackgroundImage = Properties.Resources.b51;
        }

        private void button31_MouseMove(object sender, MouseEventArgs e)
        {
            button31.BackgroundImage = Properties.Resources.b52;
        }

        private void button31_MouseUp(object sender, MouseEventArgs e)
        {
            button31.BackgroundImage = Properties.Resources.b52;
        }

        private void button44_MouseDown(object sender, MouseEventArgs e)
        {
            button44.BackgroundImage = Properties.Resources.b53;
        }

        private void button44_DragLeave(object sender, EventArgs e)
        {

        }

        private void button44_MouseLeave(object sender, EventArgs e)
        {
            button44.BackgroundImage = Properties.Resources.b51;
        }

        private void button44_MouseMove(object sender, MouseEventArgs e)
        {
            button44.BackgroundImage = Properties.Resources.b52;
        }

        private void button44_MouseUp(object sender, MouseEventArgs e)
        {
            button44.BackgroundImage = Properties.Resources.b52;
        }

        private void button15_MouseDown(object sender, MouseEventArgs e)
        {
            button15.BackgroundImage = Properties.Resources.b53;
        }

        private void button15_MouseLeave(object sender, EventArgs e)
        {
            button15.BackgroundImage = Properties.Resources.b51;
        }

        private void button15_MouseMove(object sender, MouseEventArgs e)
        {
            button15.BackgroundImage = Properties.Resources.b52;
        }

        private void button15_MouseUp(object sender, MouseEventArgs e)
        {
            button15.BackgroundImage = Properties.Resources.b52;
        }

        private void button16_MouseDown(object sender, MouseEventArgs e)
        {
            button16.BackgroundImage = Properties.Resources.b53;
        }

        private void button16_MouseLeave(object sender, EventArgs e)
        {
            button16.BackgroundImage = Properties.Resources.b51;
        }

        private void button16_MouseMove(object sender, MouseEventArgs e)
        {
            button16.BackgroundImage = Properties.Resources.b52;
        }

        private void button16_MouseUp(object sender, MouseEventArgs e)
        {
            button16.BackgroundImage = Properties.Resources.b52;
        }

        private void button41_MouseDown(object sender, MouseEventArgs e)
        {
            button41.BackgroundImage = Properties.Resources.b53;
        }

        private void button41_MouseLeave(object sender, EventArgs e)
        {
            button41.BackgroundImage = Properties.Resources.b51;
        }

        private void button41_MouseMove(object sender, MouseEventArgs e)
        {
            button41.BackgroundImage = Properties.Resources.b52;
        }

        private void button41_MouseUp(object sender, MouseEventArgs e)
        {
            button41.BackgroundImage = Properties.Resources.b52;
        }

        private void button27_MouseDown(object sender, MouseEventArgs e)
        {
            button27.BackgroundImage = Properties.Resources.b53;
        }

        private void button27_MouseLeave(object sender, EventArgs e)
        {
            button27.BackgroundImage = Properties.Resources.b51;
        }

        private void button27_MouseMove(object sender, MouseEventArgs e)
        {
            button27.BackgroundImage = Properties.Resources.b52;
        }

        private void button27_MouseUp(object sender, MouseEventArgs e)
        {
            button27.BackgroundImage = Properties.Resources.b52;
        }

        private void button32_MouseDown(object sender, MouseEventArgs e)
        {
            button32.BackgroundImage = Properties.Resources.b53;
        }

        private void button32_MouseLeave(object sender, EventArgs e)
        {
            button32.BackgroundImage = Properties.Resources.b51;
        }

        private void button32_MouseMove(object sender, MouseEventArgs e)
        {
            button32.BackgroundImage = Properties.Resources.b52;
        }

        private void button32_MouseUp(object sender, MouseEventArgs e)
        {
            button32.BackgroundImage = Properties.Resources.b52;
        }

        private void button34_MouseDown(object sender, MouseEventArgs e)
        {
            button34.BackgroundImage = Properties.Resources.b43;
        }

        private void button34_MouseLeave(object sender, EventArgs e)
        {
            button34.BackgroundImage = Properties.Resources.b41;
        }

        private void button34_MouseMove(object sender, MouseEventArgs e)
        {
            button34.BackgroundImage = Properties.Resources.b42;
        }

        private void button34_MouseUp(object sender, MouseEventArgs e)
        {
            button34.BackgroundImage = Properties.Resources.b42;
        }

        private void button35_MouseDown(object sender, MouseEventArgs e)
        {
            button35.BackgroundImage = Properties.Resources._04;
        }

        private void button35_MouseLeave(object sender, EventArgs e)
        {
            button35.BackgroundImage = Properties.Resources._2;
        }

        private void button35_MouseMove(object sender, MouseEventArgs e)
        {
            button35.BackgroundImage = Properties.Resources._03;
        }

        private void button35_MouseUp(object sender, MouseEventArgs e)
        {
            button35.BackgroundImage = Properties.Resources._03;
        }

        private void button19_MouseDown(object sender, MouseEventArgs e)
        {
            button19.BackgroundImage = Properties.Resources.b63;
        }

        private void button19_MouseLeave(object sender, EventArgs e)
        {
            button19.BackgroundImage = Properties.Resources.b61;
        }

        private void button19_MouseMove(object sender, MouseEventArgs e)
        {
            button19.BackgroundImage = Properties.Resources.b62;
        }

        private void button19_MouseUp(object sender, MouseEventArgs e)
        {
            button19.BackgroundImage = Properties.Resources.b62;
        }

        private void button4_MouseDown(object sender, MouseEventArgs e)
        {
            button4.BackgroundImage = Properties.Resources.b63;
        }

        private void button4_MouseLeave(object sender, EventArgs e)
        {
            button4.BackgroundImage = Properties.Resources.b61;
        }

        private void button4_MouseMove(object sender, MouseEventArgs e)
        {
            button4.BackgroundImage = Properties.Resources.b62;
        }

        private void button4_MouseUp(object sender, MouseEventArgs e)
        {
            button4.BackgroundImage = Properties.Resources.b62;
        }

        private void button40_MouseDown(object sender, MouseEventArgs e)
        {
            button40.BackgroundImage = Properties.Resources.b63;
        }

        private void button40_MouseLeave(object sender, EventArgs e)
        {
            button40.BackgroundImage = Properties.Resources.b61;
        }

        private void button40_MouseMove(object sender, MouseEventArgs e)
        {
            button40.BackgroundImage = Properties.Resources.b62;
        }

        private void button40_MouseUp(object sender, MouseEventArgs e)
        {
            button40.BackgroundImage = Properties.Resources.b62;
        }

        private void button43_MouseDown(object sender, MouseEventArgs e)
        {
            button43.BackgroundImage = Properties.Resources.b63;
        }

        private void button43_MouseLeave(object sender, EventArgs e)
        {
            button43.BackgroundImage = Properties.Resources.b61;
        }

        private void button43_MouseMove(object sender, MouseEventArgs e)
        {
            button43.BackgroundImage = Properties.Resources.b62;
        }

        private void button43_MouseUp(object sender, MouseEventArgs e)
        {
            button43.BackgroundImage = Properties.Resources.b62;
        }

        private void button25_MouseDown(object sender, MouseEventArgs e)
        {
            button25.BackgroundImage = Properties.Resources.b63;
        }

        private void button25_MouseLeave(object sender, EventArgs e)
        {
            button25.BackgroundImage = Properties.Resources.b61;
        }

        private void button25_MouseMove(object sender, MouseEventArgs e)
        {
            button25.BackgroundImage = Properties.Resources.b62;
        }

        private void button25_MouseUp(object sender, MouseEventArgs e)
        {
            button25.BackgroundImage = Properties.Resources.b62;
        }

        private void button11_MouseDown(object sender, MouseEventArgs e)
        {
            button11.BackgroundImage = Properties.Resources.b63;
        }

        private void button11_MouseLeave(object sender, EventArgs e)
        {
            button11.BackgroundImage = Properties.Resources.b61;
        }

        private void button11_MouseMove(object sender, MouseEventArgs e)
        {
            button11.BackgroundImage = Properties.Resources.b62;
        }

        private void button11_MouseUp(object sender, MouseEventArgs e)
        {
            button11.BackgroundImage = Properties.Resources.b62;
        }

        private void button12_MouseDown(object sender, MouseEventArgs e)
        {
            button12.BackgroundImage = Properties.Resources.b63;
        }

        private void button12_MouseLeave(object sender, EventArgs e)
        {
            button12.BackgroundImage = Properties.Resources.b61;
        }

        private void button12_MouseMove(object sender, MouseEventArgs e)
        {
            button12.BackgroundImage = Properties.Resources.b62;
        }

        private void button12_MouseUp(object sender, MouseEventArgs e)
        {
            button12.BackgroundImage = Properties.Resources.b62;
        }

        private void button22_MouseDown(object sender, MouseEventArgs e)
        {
            button22.BackgroundImage = Properties.Resources.b63;
        }

        private void button22_MouseLeave(object sender, EventArgs e)
        {
            button22.BackgroundImage = Properties.Resources.b61;
        }

        private void button22_MouseMove(object sender, MouseEventArgs e)
        {
            button22.BackgroundImage = Properties.Resources.b62;
        }

        private void button22_MouseUp(object sender, MouseEventArgs e)
        {
            button22.BackgroundImage = Properties.Resources.b62;
        }

        private void button47_MouseDown(object sender, MouseEventArgs e)
        {
            button47.BackgroundImage = Properties.Resources.b33;
        }

        private void button47_MouseLeave(object sender, EventArgs e)
        {
            button47.BackgroundImage = Properties.Resources.b31;
        }

        private void button47_MouseMove(object sender, MouseEventArgs e)
        {
            button47.BackgroundImage = Properties.Resources.b32;
        }

        private void button47_MouseUp(object sender, MouseEventArgs e)
        {
            button47.BackgroundImage = Properties.Resources.b32;
        }

        private void button33_MouseDown(object sender, MouseEventArgs e)
        {
            button33.BackgroundImage = Properties.Resources.b33;
        }

        private void button33_MouseLeave(object sender, EventArgs e)
        {
            button33.BackgroundImage = Properties.Resources.b31;
        }

        private void button33_MouseMove(object sender, MouseEventArgs e)
        {
            button33.BackgroundImage = Properties.Resources.b32;
        }

        private void button33_MouseUp(object sender, MouseEventArgs e)
        {
            button33.BackgroundImage = Properties.Resources.b32;
        }

        private void button6_MouseLeave(object sender, EventArgs e)
        {
            button6.BackgroundImage = Properties.Resources.b41;
        }

        private void button6_MouseMove(object sender, MouseEventArgs e)
        {
            button6.BackgroundImage = Properties.Resources.b42;
        }

        private void button6_MouseUp(object sender, MouseEventArgs e)
        {
            button6.BackgroundImage = Properties.Resources.b42;
        }

        private void button30_MouseDown(object sender, MouseEventArgs e)
        {
            button30.BackgroundImage = Properties.Resources.b43;
        }

        private void button30_MouseLeave(object sender, EventArgs e)
        {
            button30.BackgroundImage = Properties.Resources.b41;
        }

        private void button30_MouseMove(object sender, MouseEventArgs e)
        {
            button30.BackgroundImage = Properties.Resources.b42;
        }

        private void button30_MouseUp(object sender, MouseEventArgs e)
        {
            button30.BackgroundImage = Properties.Resources.b42;
        }

        private void comboBox7_MouseClick(object sender, MouseEventArgs e)
        {
            SqlConnection sqlConn = new SqlConnection("server="+ipAdress+";database=ErYingDatabase; uid=sa; pwd=9876543q");


            if (radioButton10.Checked == true)
            {
                SqlDataAdapter sda4 = new SqlDataAdapter("select distinct File_Num from Files order by File_Num", sqlConn);
                DataSet ds1 = new DataSet();
                sda4.Fill(ds1, "emp");

                comboBox7.DataSource = ds1.Tables[0];
                comboBox7.DisplayMember = "File_Num";
            }
            else
            {
                SqlDataAdapter sda1 = new SqlDataAdapter("select distinct File_Title from Files", sqlConn);
                DataSet ds1 = new DataSet();
                sda1.Fill(ds1, "emp");

                comboBox7.DataSource = ds1.Tables[0];
                comboBox7.DisplayMember = "File_Title";
            }
            comboBox7.Text = "所有文件";
        }

        private void SetFileLendColor()
        {
            for (int i = 0; i < dataGridView10.Rows.Count - 1; i++)
            {
                if ("".Equals(dataGridView10.Rows[i].Cells[5].Value.ToString()))
                {
                    dataGridView10.Rows[i].DefaultCellStyle.BackColor = Color.LightPink;
                }
                else
                {
                    dataGridView10.Rows[i].DefaultCellStyle.BackColor = Color.LightGreen;
                }
            }
        }
        private void WriteGradesNotes()
        {
            if ("所有时间".Equals (ST_terms .Text )||"所有科目".Equals (ST_subject .Text))
            {
                return;
            }
            else
            {
                string str1 = "insert TestComments (ST_term,Test_subject,Notes)values('" + ST_terms.Text.Trim() + "','" + ST_subject.Text.Trim() +
                    "','" + TestComments.Text.Trim() + "')";
                string str2 = "update TestComments set Notes=" + TestComments.Text.Trim() + "' where ST_term='" + ST_terms.Text.Trim() + 
                    "'and Test_subject='" + ST_subject.Text.Trim() + "'";
                try
                {
                    ComSQL(str1);

                }
                catch
                {
                    try
                    {
                        ComSQL(str2);
                    }
                    catch { }
                    
                }

            }
        }

        private void TestComments_TextChanged(object sender, EventArgs e)
        {

        }

        private void comboBox8_KeyUp(object sender, KeyEventArgs e)
        {
            //if (comboBox8 .Text =="")
            //{
            //    comboBox8.Text = "所有人员";
            //}
        }

        private void ReadGradesNotes()

        {
            TestComments.Text = "";
            if ("所有时间".Equals(ST_terms.Text) || "所有科目".Equals(ST_subject.Text))
            {
                return;
            }
            else
            {
                string str = "select Notes from TestComments where ST_term='" + ST_terms.Text.Trim() + "'and Test_subject='" +
                    ST_subject.Text.Trim() + "'";
                DataSet d = SelectSQL(str);
                TestComments.Text = d.Tables[0].Rows[0][0].ToString();

            }
        }

        private void comboBox10_MouseClick(object sender, MouseEventArgs e)
        {
            SqlConnection sqlConn = new SqlConnection("server="+ipAdress+";database=ErYingDatabase; uid=sa; pwd=9876543q");


            if (radioButton23.Checked == true)
            {
                SqlDataAdapter sda4 = new SqlDataAdapter("select distinct ST_Num from ST_Information", sqlConn);
                DataSet ds1 = new DataSet();
                sda4.Fill(ds1, "emp");

                comboBox10.DataSource = ds1.Tables[0];
                comboBox10.DisplayMember = "ST_Num";
            }
            else
            {
                SqlDataAdapter sda1 = new SqlDataAdapter("select distinct ST_name from ST_Information", sqlConn);
                DataSet ds1 = new DataSet();
                sda1.Fill(ds1, "emp");

                comboBox10.DataSource = ds1.Tables[0];
                comboBox10.DisplayMember = "ST_name";
            }
            comboBox4.Text = "所有人员";
        }

        private void button13_Click_1(object sender, EventArgs e)
        {
            if (comboBox10.Text == "所有人员")
            {
                //SqlConnection conn = new SqlConnection();
                SqlConnection sqlConn = new SqlConnection("server="+ipAdress+";database=ErYingDatabase; uid=sa; pwd=9876543q");
                //string str = "Select ST_name as '姓名',ST_Num as '证件号',ST_sex as '性别',ST_birth as '出生时间',ST_race as '民族',ST_jiguan,ST_IDNum," +
                //"ST_QorS,ST_polID,ST_address,ST_major,ST_isonlychild,ST_experience,ST_PreSchool," +
                //"InArmy,Grade,PartyTime,IsMarry,IsPregnant,VacationPlan,Family,Family_Mobile,Education,BloodType " +
                //"from ST_Information where ST_Num='" + dataGridView1.CurrentRow.Cells[1].Value.ToString() + "'";
                //ST_experience.Text = str;
                //DataSet t = SelectSQL(str);
                SqlDataAdapter sda = new SqlDataAdapter("select ST_name as '姓名',ST_Num as '证件号',ST_PreSchool as '所属班排',ST_IDNum as '身份证号' from ST_Information "
                     , sqlConn);
                DataSet ds = new DataSet();
                sda.Fill(ds, "emp");
                dataGridView12.DataSource = ds.Tables[0];
                SetPeopleColor1();
            }
            else
            {
                if (radioButton23.Checked == true)
                {


                    //SqlConnection conn = new SqlConnection();
                    SqlConnection sqlConn = new SqlConnection("server="+ipAdress+";database=ErYingDatabase; uid=sa; pwd=9876543q");
                    SqlDataAdapter sda = new SqlDataAdapter("select ST_name as '姓名',ST_Num as '证件号',ST_PreSchool as '所属班排',ST_IDNum as '身份证号' from ST_Information where ST_Num='" +
                        comboBox10.Text + "'", sqlConn);
                    DataSet ds = new DataSet();
                    try
                    {
                        sda.Fill(ds, "emp");
                        dataGridView12.DataSource = ds.Tables[0];
                        SetPeopleColor1();
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
                    SqlConnection sqlConn = new SqlConnection("server="+ipAdress+";database=ErYingDatabase; uid=sa; pwd=9876543q");
                    SqlDataAdapter sda = new SqlDataAdapter("select ST_name as '姓名',ST_Num as '证件号',ST_PreSchool as '所属班排',ST_IDNum as '身份证号' from ST_Information where ST_name='" +
                        comboBox10.Text + "'", sqlConn);
                    DataSet ds = new DataSet();
                    sda.Fill(ds, "emp");
                    dataGridView12.DataSource = ds.Tables[0];
                    if (sqlConn.State != ConnectionState.Open)
                    {
                        sqlConn.Dispose(); sqlConn.Dispose();
                    }
                }
            }
        }

        private void dataGridView12_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            foreach (Control c in tabPage5.Controls)
            {
                if (c is TextBox)
                {
                    c.Text = "无";
                }
            }
            if (dataGridView12.SelectedCells.Count != 0)
            {

                //得到选中行某列的值
                //string str = dataGridView1.CurrentRow.Cells[2].Value.ToString();
                ST_name3.Text = dataGridView12.CurrentRow.Cells[0].Value.ToString();
                ST_Num3.Text = dataGridView12.CurrentRow.Cells[1].Value.ToString();
                ST_Class3.Text = dataGridView12.CurrentRow.Cells[2].Value.ToString();

               
               
            }
        }

        private void tabPage15_Click(object sender, EventArgs e)
        {

            
        }

        public void AddString()
        {
            DataSet ds1 = new DataSet();
            //sda1.Fill(ds1, "emp");
            DataRow r = ds1.Tables[0].NewRow();
            r["ST_name"] = "所有人员";
            ds1.Tables[0].Rows.InsertAt(r, 0);
            comboBox8.DataSource = ds1.Tables[0];
            comboBox8.DisplayMember = "ST_name";
        }
        public void SetLeaveBack()
        {
            string str = "select S.ST_Name as '姓名',L.ST_Num as'证件号',S.ST_PreSchool as '所在班排',L.Lreason as '事由'," +
                "L.LeaveTime as '离队时间', L.BackTime as '应归队时间',L.LPrincipal as '批假人',L.RBackTime as '实归队时间'" +
                "from LeaveBack as L join ST_Information as S on L.ST_Num=S.ST_Num";
            dataGridView13.DataSource = null;
            if (radioButton25.Checked == true)
            {
                str += " and L.RBackTime is null";
            }
            DataSet d = SelectSQL(str);
            DataTable data = d.Tables[0];
            if (data .Columns .Count ==8)
            data.Columns.Add("距归队天数");
            for (int i=0;i<data .Rows.Count; i++)
            {
                string str1 = DateTime.Now.ToString();
                string str2 = data.Rows[i][5].ToString();
                if (!"".Equals(data .Rows[i][7].ToString()))
                {
                    data.Rows[i][8]= 0;
                }
                else
                {
                    data.Rows[i][8] = CountTime(str1, str2).ToString();

                }
            }
            dataGridView13.DataSource = data;
           
            SetLeaveBackColor();
            

            }

        private void button49_Click(object sender, EventArgs e)
        {
            string table0 = "LeaveBack";
            string[] str1 = { "ST_Num", "LeaveTime", "BackTime", "LReason", "LPrincipal" };
            TextBox[] t = new TextBox[5];
            t[0]=ST_Num3;
            t[1] = new TextBox();t[1].Text = dateTimePicker2.Value.ToString();
            t[2] = new TextBox(); t[2].Text = dateTimePicker3.Value.ToString();
            t[3] = LReason;
            t[4] = LPrincipal;
            try
            {
                InsertSQL(str1, t, table0);
                SetLeaveBack();
                label57.Text = "提示：" + ST_name3.Text + "离队信息设置成功！";
            }
            catch(Exception e0)
            {
                MessageBox.Show(e0.ToString());
            }
            
        }

        private void button50_Click(object sender, EventArgs e)
        {
            string str = "update  LeaveBack set RBackTime='"+dateTimePicker4 .Value .ToString ()+"' where ST_Num='"
                +dataGridView13 .CurrentRow .Cells [1].Value .ToString ()+"'and LeaveTime='"+
                dataGridView13.CurrentRow.Cells[4].Value.ToString() + "'and BackTime='" + 
                dataGridView13.CurrentRow.Cells[5].Value.ToString()+"'";
            try
            {
                ComSQL(str);
                label57.Text = "提示：" + dataGridView13.CurrentRow.Cells[0].Value.ToString() + "已归队";
                SetLeaveBack();
            }
            catch (Exception e0)
            {
                MessageBox.Show(e0.ToString());
            }
        }

        private void button51_Click(object sender, EventArgs e)
        {
            string str = "update  LeaveBack set BackTime='" + dateTimePicker4.Value.ToString() + "' where ST_Num='"
                + dataGridView13.CurrentRow.Cells[1].Value.ToString() + "'and LeaveTime='" +
                dataGridView13.CurrentRow.Cells[4].Value.ToString() + "'and BackTime='" +
                dataGridView13.CurrentRow.Cells[5].Value.ToString() + "'";
            try
            {
                ComSQL(str);
                label57.Text = "提示：" + dataGridView13.CurrentRow.Cells[0].Value.ToString() + "已归队";
                SetLeaveBack();
            }
            catch (Exception e0)
            {
                MessageBox.Show(e0.ToString());
            }
        }

        private void button48_Click(object sender, EventArgs e)
        {
            int len = dataGridView13.ColumnCount;
            string str = "delete from  LeaveBack  where ST_Num='"
                + dataGridView13.CurrentRow.Cells[len -8].Value.ToString() + "'and LeaveTime='" +
                dataGridView13.CurrentRow.Cells[len - 5].Value.ToString() + "'and BackTime='" +
                dataGridView13.CurrentRow.Cells[len -4].Value.ToString() + "'";
            try
            {
                ComSQL(str);
                label57.Text = "提示：" + dataGridView13.CurrentRow.Cells[0].Value.ToString() + "已归队";
                SetLeaveBack();
            }
            catch (Exception e0)
            {
                MessageBox.Show(e0.ToString());
            }
        }

        public string  CountTime(string str1,string str2)
        {
            DateTime d1 = Convert.ToDateTime(str1);
            DateTime d2 = Convert.ToDateTime(str2);
            TimeSpan d3 = d2.Subtract(d1);
            string str = d3.Days.ToString();
            return str;
        }

        private void radioButton25_CheckedChanged(object sender, EventArgs e)
        {
            SetLeaveBack();
        }

        private void button49_MouseDown(object sender, MouseEventArgs e)
        {
            button49.BackgroundImage = Properties.Resources.b43;
        }

        private void button49_MouseLeave(object sender, EventArgs e)
        {
            button49.BackgroundImage = Properties.Resources.b41;
        }

        private void button49_MouseMove(object sender, MouseEventArgs e)
        {
            button49.BackgroundImage = Properties.Resources.b42;
        }

        private void button49_MouseUp(object sender, MouseEventArgs e)
        {
            button49.BackgroundImage = Properties.Resources.b42;
        }

        private void button48_MouseDown(object sender, MouseEventArgs e)
        {
            button48.BackgroundImage = Properties.Resources.b53;
        }

        private void button48_MouseLeave(object sender, EventArgs e)
        {
            button48.BackgroundImage = Properties.Resources.b51;
        }

        private void button48_MouseMove(object sender, MouseEventArgs e)
        {
            button48.BackgroundImage = Properties.Resources.b52;
        }

        private void button48_MouseUp(object sender, MouseEventArgs e)
        {
            button48.BackgroundImage = Properties.Resources.b52;
        }

        private void button51_MouseDown(object sender, MouseEventArgs e)
        {
            button51.BackgroundImage = Properties.Resources.b63;
        }

        private void button51_MouseLeave(object sender, EventArgs e)
        {
            button51.BackgroundImage = Properties.Resources.b61;
        }

        private void button51_MouseMove(object sender, MouseEventArgs e)
        {
            button51.BackgroundImage = Properties.Resources.b62;
        }

        private void button51_MouseUp(object sender, MouseEventArgs e)
        {
            button51.BackgroundImage = Properties.Resources.b62;
        }

        private void button50_MouseDown(object sender, MouseEventArgs e)
        {
            button50.BackgroundImage = Properties.Resources.b33;
        }

        private void button50_MouseLeave(object sender, EventArgs e)
        {
            button50.BackgroundImage = Properties.Resources.b31;
        }

        private void button50_MouseMove(object sender, MouseEventArgs e)
        {
            button50.BackgroundImage = Properties.Resources.b32;
        }

        private void button50_MouseUp(object sender, MouseEventArgs e)
        {
            button50.BackgroundImage = Properties.Resources.b32;
        }

        private void tabControl2_Selected(object sender, TabControlEventArgs e)
        {
            if (tabControl2.SelectedIndex ==10)
            {
                SetLeaveBackColor();
            }
        }

        public void SetLeaveBackColor()
        {
           
            for (int i=0;i<dataGridView13 .RowCount - 1; i++)
            {
                int k = Convert .ToInt16 ( dataGridView13.Rows[i].Cells[8].Value.ToString ());
                if (k < 4)
                {
                    dataGridView13.Rows[i].DefaultCellStyle.BackColor = Color.LightPink;
                    //label57.Text += i+"行应该粉色k="+k +";";
                    if (!"".Equals(dataGridView13.Rows[i].Cells[7].Value.ToString()))
                    {
                        dataGridView13.Rows[i].DefaultCellStyle.BackColor = Color.LightGreen;
                        //label57.Text += i + "行应该绿色k=" + k + ";";
                    }
                }
                
            }
            
        }
            
    }
    
    
}

