using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Configuration;
using System.Data.SqlClient;


namespace ADMIN
{
    public partial class Form1 : Form
    {
        string cs = ConfigurationManager.ConnectionStrings["dbcs"].ConnectionString;
        public Form1()
        {
            InitializeComponent();

        }

        private void button1_Click(object sender, EventArgs e)
        {
            if (textBox1.Text != "")
            {
                string us = dataGridView1.SelectedRows[0].Cells[0].Value.ToString();
                if (us[11] == 'u')
                {
                    SqlConnection con = new SqlConnection(cs);
                    string query = "delete from u_ser where phone=@phone";
                    SqlCommand cmd = new SqlCommand(query, con);
                    cmd.Parameters.AddWithValue("@phone", textBox1.Text);
                    con.Open();
                    int a = cmd.ExecuteNonQuery();//0 1
                    if (a >= 0)
                    {
                        MessageBox.Show("Data Deleted Successfully ! ");
                        BindGridview();
                        ResetControl();
                    }
                    else
                    {
                        MessageBox.Show("Data not Deleted ! ");
                    }
                }
                else
                {
                    SqlConnection con = new SqlConnection(cs);
                    string query = "delete from w_orker where phone=@phone";
                    SqlCommand cmd = new SqlCommand(query, con);
                    cmd.Parameters.AddWithValue("@phone", textBox1.Text);
                    con.Open();
                    int a = cmd.ExecuteNonQuery();//0 1
                    if (a >= 0)
                    {
                        MessageBox.Show("Data Deleted Successfully ! ");
                        gridviewshow();
                        ResetControl();
                    }
                    else
                    {
                        MessageBox.Show("Data not Deleted ! ");
                    }
                }
            }
            else
            {
                MessageBox.Show("Data  ! ");
            }


        }


        void BindGridview()
        {

                SqlConnection con = new SqlConnection(cs);
                string query = "Select * from u_ser";
                SqlCommand cmd = new SqlCommand(query, con);
                SqlDataAdapter sad = new SqlDataAdapter(query, con);
                DataTable data = new DataTable();
                sad.Fill(data);
                dataGridView1.DataSource = data;
                dataGridView1.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.Fill;
            }

             void gridviewshow()        
            {
                SqlConnection con = new SqlConnection(cs);
                string query = "Select * from w_orker";
                SqlCommand cmd = new SqlCommand(query, con);
                SqlDataAdapter sad = new SqlDataAdapter(query, con);
                DataTable data = new DataTable();
                sad.Fill(data);
                dataGridView1.DataSource = data;
                dataGridView1.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.Fill;
            }
        

        private void button5_Click(object sender, EventArgs e)
        {
            textBox6.Visible = false;
            label6.Visible = false;
            textBox7.Visible = false;
            label7.Visible = false;
            ResetControl();
            BindGridview();
           // ResetControl();
        }

        private void button4_Click(object sender, EventArgs e)
        {
            ResetControl();
        }

         void ResetControl()
        {
            textBox1.Clear();
            textBox2.Clear();
            textBox5.Clear();
            textBox6.Clear();
            textBox7.Clear();
            
        }

        private void dataGridView1_MouseDoubleClick(object sender, MouseEventArgs e)
        {
            string us =dataGridView1.SelectedRows[0].Cells[0].Value.ToString();
            if(us[11]=='u')
            {
                ResetControl();
                textBox1.Text = dataGridView1.SelectedRows[0].Cells[0].Value.ToString();
                textBox2.Text = dataGridView1.SelectedRows[0].Cells[1].Value.ToString();
                textBox5.Text = dataGridView1.SelectedRows[0].Cells[4].Value.ToString();
            }

            else
            {
                ResetControl();
                textBox1.Text = dataGridView1.SelectedRows[0].Cells[0].Value.ToString();
                textBox2.Text = dataGridView1.SelectedRows[0].Cells[1].Value.ToString();
                textBox5.Text = dataGridView1.SelectedRows[0].Cells[4].Value.ToString();
                textBox6.Text = dataGridView1.SelectedRows[0].Cells[11].Value.ToString();
                textBox7.Text = dataGridView1.SelectedRows[0].Cells[12].Value.ToString();
               
            }

           
        }

        private void button2_Click(object sender, EventArgs e)
        {
            if (textBox1.Text != "")
            {
                string us = dataGridView1.SelectedRows[0].Cells[0].Value.ToString();
                if (us[11] == 'w')
                {
                    SqlConnection con = new SqlConnection(cs);
                    string query = "update w_orker set review=@review,reviewNumber=@reviewNumber where phone=@phone";
                    SqlCommand cmd = new SqlCommand(query, con);
                    cmd.Parameters.AddWithValue("@phone", textBox1.Text);
                    cmd.Parameters.AddWithValue("@userName", textBox2.Text);
                    cmd.Parameters.AddWithValue("@pin", textBox6.Text);
                    cmd.Parameters.AddWithValue("@review", textBox6.Text);
                    cmd.Parameters.AddWithValue("@reviewNumber", textBox7.Text);

                    con.Open();
                    int a = cmd.ExecuteNonQuery();//0 1
                    if (a >= 0)
                    {
                        MessageBox.Show("Data Updated Successfully ! ");
                        gridviewshow();
                        ResetControl();
                    }
                    else
                    {
                        MessageBox.Show("Data not Updated ! ");
                    }
                }
                else
                {
                    MessageBox.Show("Can Not Update ! ");
                }
            }
            else
            {
                MessageBox.Show("Can not upadate  ! ");
            }
        }
       
        private void button6_Click(object sender, EventArgs e)
        {
            ResetControl();
            gridviewshow();
            textBox6.Visible = true;
            label6.Visible = true;
            textBox7.Visible = true;
            label7.Visible = true;
            //  ResetControl();

        }

        private void textBox3_TextChanged(object sender, EventArgs e)
        {
        }       
        private void Form1_Load(object sender, EventArgs e)
        {
        }

        private void button3_Click(object sender, EventArgs e)
        {

            if (textBox3.Text == " ")
            {
                MessageBox.Show("Please write something to search", "Invalid", MessageBoxButtons.OK, MessageBoxIcon.Information);

            }
            else
            {

                string us = dataGridView1.SelectedRows[0].Cells[0].Value.ToString();
                if (us[11] == 'u')
                {
                    SqlConnection con = new SqlConnection(cs);
                    con.Open();
                    string query = "select * from u_ser where phone like '%" + textBox3.Text + "%' ";
                    // DataTable dt = LoadStuff(query);


                    SqlCommand cmd = new SqlCommand(query, con);
                    cmd.ExecuteNonQuery();
                    SqlDataAdapter adp = new SqlDataAdapter(cmd);
                    DataSet ds = new DataSet();
                    adp.Fill(ds);
                    DataTable dt = ds.Tables[0];

                    //DataTable dt2 = ds.Tables[1];
                    dataGridView1.AutoGenerateColumns = false;
                    dataGridView1.DataSource = dt;
                    dataGridView1.Refresh();
                    con.Close();
                    ResetControl();
                }
                else
                {
                    SqlConnection con = new SqlConnection(cs);
                    con.Open();
                    string query = "select * from w_orker where phone like '%" + textBox3.Text + "%' ";
                    // DataTable dt = LoadStuff(query);


                    SqlCommand cmd = new SqlCommand(query, con);
                    cmd.ExecuteNonQuery();
                    SqlDataAdapter adp = new SqlDataAdapter(cmd);
                    DataSet ds = new DataSet();
                    adp.Fill(ds);
                    DataTable dt = ds.Tables[0];

                    //DataTable dt2 = ds.Tables[1];
                    dataGridView1.AutoGenerateColumns = false;
                    dataGridView1.DataSource = dt;
                    dataGridView1.Refresh();
                    con.Close();
                    ResetControl();
                }
            }

        }

        private void panel4_Paint(object sender, PaintEventArgs e)
        {

        }

        private void pictureBox2_Click(object sender, EventArgs e)
        {
            if (textBox3.Text == " ")
            {
                MessageBox.Show("Please write something to search", "Invalid", MessageBoxButtons.OK, MessageBoxIcon.Information);

            }
            else
            {

                string us = dataGridView1.SelectedRows[0].Cells[0].Value.ToString();
                if (us[11] == 'u')
                {
                    SqlConnection con = new SqlConnection(cs);
                    con.Open();
                    string query = "select * from u_ser where phone like '%" + textBox3.Text + "%' ";
                    // DataTable dt = LoadStuff(query);


                    SqlCommand cmd = new SqlCommand(query, con);
                    cmd.ExecuteNonQuery();
                    SqlDataAdapter adp = new SqlDataAdapter(cmd);
                    DataSet ds = new DataSet();
                    adp.Fill(ds);
                    DataTable dt = ds.Tables[0];

                    //DataTable dt2 = ds.Tables[1];
                    dataGridView1.AutoGenerateColumns = false;
                    dataGridView1.DataSource = dt;
                    dataGridView1.Refresh();
                    con.Close();
                    ResetControl();
                }
                else
                {
                    SqlConnection con = new SqlConnection(cs);
                    con.Open();
                    string query = "select * from w_orker where phone like '%" + textBox3.Text + "%' ";
                    // DataTable dt = LoadStuff(query);


                    SqlCommand cmd = new SqlCommand(query, con);
                    cmd.ExecuteNonQuery();
                    SqlDataAdapter adp = new SqlDataAdapter(cmd);
                    DataSet ds = new DataSet();
                    adp.Fill(ds);
                    DataTable dt = ds.Tables[0];

                    //DataTable dt2 = ds.Tables[1];
                    dataGridView1.AutoGenerateColumns = false;
                    dataGridView1.DataSource = dt;
                    dataGridView1.Refresh();
                    con.Close();
                    ResetControl();
                }
            }
        }

        private void button3_Click_1(object sender, EventArgs e)
        {
            this.Dispose();
            WindowsFormsApp1.Form1 f = new WindowsFormsApp1.Form1();
            f.Visible = true;
        }

        private void textBox3_Enter(object sender, EventArgs e)
        {
            this.textBox3.Text = null;
        }

        private void button7_Click(object sender, EventArgs e)
        {
            WindowsFormsApp1.message m = new WindowsFormsApp1.message();
            m.Visible = true;
        }
    }
}

    