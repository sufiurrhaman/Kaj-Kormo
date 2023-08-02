using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Configuration;
using System.Data;
using System.Data.SqlClient;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace WindowsFormsApp1
{
    public partial class Login : UserControl
    {
        string cs = ConfigurationManager.ConnectionStrings["dbcs"].ConnectionString;
        
        public Login()
        {
            
            InitializeComponent();
            //textBox1.Text = "01993830224u";
            //textBox2.Text = "1234";
        }

        private void label3_Click(object sender, EventArgs e)
        {

        }

        private void textBox1_Leave(object sender, EventArgs e)
        { 
           if (String.IsNullOrEmpty(textBox1.Text) == true || textBox1.Text == "")
            {
                textBox1.Focus();
                errorProvider1.Icon = Properties.Resources.icons8_Cancel;
                errorProvider1.SetError(this.textBox1, "Empty Field.");
            }
           else if(textBox1.Text == "admin")
            {
                errorProvider1.Icon = Properties.Resources.icons8_Checked;
                errorProvider1.SetError(this.textBox1, "Correct.");
            }
            else if (textBox1.Text.Length < 12 || textBox1.Text.Length > 12)
            {
                textBox1.Focus();
                errorProvider1.Icon = Properties.Resources.icons8_Cancel;
                errorProvider1.SetError(this.textBox1, "Invalid Number.1");
            }
            else
            {
                int flag = 0;
                for (int i = 0; i < textBox1.Text.Length; i++)
                {
                    if (Char.IsLetter(textBox1.Text[i]))
                    {
                        flag++;
                        break;
                    }
                }
                if (flag == 1)
                {
                    errorProvider1.Icon = Properties.Resources.icons8_Checked;
                    errorProvider1.SetError(this.textBox1, "Correct.");
                }
                else
                {
                    textBox1.Focus();
                    errorProvider1.Icon = Properties.Resources.icons8_Cancel;
                    errorProvider1.SetError(this.textBox1, "Invalid Format.");
                }
            }
        }

        private void textBox2_Leave(object sender, EventArgs e)
        {
            if (String.IsNullOrEmpty(textBox2.Text) == true || textBox2.Text == "")
            {
                textBox2.Focus();
                errorProvider2.Icon = Properties.Resources.icons8_Cancel;
                errorProvider2.SetError(this.textBox2, "Empty Field.");
            }

            else
            {
                int flag = 0;
                for (int i = 0; i < textBox2.Text.Length; i++)
                {
                    if (Char.IsLetter(textBox2.Text[i]))
                    {
                        flag = 1;
                        break;
                    }
                }
                if (flag == 1)
                {
                    textBox2.Focus();
                    errorProvider2.Icon = Properties.Resources.icons8_Cancel;
                    errorProvider2.SetError(this.textBox2, "Invalid Format.");
                }
                else
                {
                    errorProvider2.Icon = Properties.Resources.icons8_Checked;
                    errorProvider2.SetError(this.textBox2, "Valid");
                }
            }
        }

        private void checkBox1_CheckedChanged(object sender, EventArgs e)
        {
            if (this.checkBox1.Checked)
            {
                textBox2.UseSystemPasswordChar = false;
            }
            else
            {
                textBox2.UseSystemPasswordChar = true;

            }
        }

        private void button1_MouseEnter(object sender, EventArgs e)
        {
            
        }

        private void linkLabel1_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
        {
            if (!Form1.Instance.mainPanel.Controls.ContainsKey("Signup"))
            {
                Signup sn = new Signup();
                sn.Dock = DockStyle.Fill;
                Form1.Instance.mainPanel.Controls.Add(sn);
            }
            Form1.Instance.mainPanel.Controls["Signup"].BringToFront();
            Form1.Instance.backButton.Visible = true;
            this.Dispose();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            /*
            Form2main m = new Form2main();
            m.StartPosition = FormStartPosition.CenterScreen;
            m.Visible = true;
            Form1.Instance.Visible = false;
            */
            
            string[] splitName = textBox1.Text.Split(new char[] { 'u', 'w' });
            //MessageBox.Show(splitName[0]);
            SqlConnection con = new SqlConnection(cs);
            if (textBox1.Text == "admin")
            {
                ADMIN.Form1 f = new ADMIN.Form1();
                f.StartPosition = FormStartPosition.CenterScreen;
                f.Visible = true;
                Form1.Instance.Visible = false;
            }
            else if (textBox1.Text[11] == 'u')
            {
                string query = "select * from u_ser where phone = @Phone and pin = @Pin";
                SqlCommand cmd = new SqlCommand(query, con);
                cmd.Parameters.AddWithValue("@Phone", textBox1.Text);
                cmd.Parameters.AddWithValue("@Pin", textBox2.Text);
                con.Open();
                SqlDataReader dr = cmd.ExecuteReader();
                
                if (dr.HasRows)
                {
                    dr.Read();
                    Form2main m = new Form2main();
                    m.AccountUserName.Text = dr[1].ToString();
                    m.AccountPhoneDB = dr[0].ToString();
                    m.AccButtonName = "  Worker's List";
                    m.Workersbutton.Image = Properties.Resources.icons8_workers_30;
                    m.sentJob.Image = Properties.Resources.icons8_request_service_30;
                    m.AccBalance = dr[6].ToString();
                    m.StartPosition = FormStartPosition.CenterScreen;
                    m.Visible = true;
                    Form1.Instance.Visible = false;
                    
                    //MessageBox.Show( dr[1].ToString(), "Success", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                }
                else
                {
                    MessageBox.Show("Incorrect Phone or Pin.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);

                }
                con.Close();
            
            }
            else if(textBox1.Text[11] == 'w')
            {
                string query = "select * from w_orker where phone = @Phone and pin = @Pin";
                SqlCommand cmd = new SqlCommand(query, con);
                cmd.Parameters.AddWithValue("@Phone", textBox1.Text);
                cmd.Parameters.AddWithValue("@Pin", textBox2.Text);
                con.Open();
                SqlDataReader dr = cmd.ExecuteReader();

                if (dr.HasRows)
                {
                    dr.Read();
                    Form2main m = new Form2main();
                    m.AccountUserName.Text = dr[1].ToString();
                    m.AccountPhoneDB = dr[0].ToString();
                    m.AccButtonName = "    Job Offers";
                    m.Workersbutton.Image = Properties.Resources.icons8_post_box_30;
                    m.sentJob.Image = Properties.Resources.icons8_news_30;
                    m.sentJob.Text = "        Posts";
                    m.Skill = dr[5].ToString();
                    m.StartPosition = FormStartPosition.CenterScreen;
                    
                    m.Visible = true;
                    Form1.Instance.Visible = false;

                    //MessageBox.Show( dr[1].ToString(), "Success", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                }
                else
                {
                    MessageBox.Show("Incorrect Phone or Pin.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);

                }
                con.Close();
            }
           
            
            
        }

        private void button1_Enter(object sender, EventArgs e)
        {
            if (textBox1.Text == "")
            {
                textBox1.Focus();
                errorProvider1.Icon = Properties.Resources.icons8_Cancel;
                errorProvider1.SetError(this.textBox1, "Invalid.");
            }
            else if (textBox2.Text == "")
            {
                textBox2.Focus();
                errorProvider2.Icon = Properties.Resources.icons8_Cancel;
                errorProvider2.SetError(this.textBox2, "Invalid.");
            }

        }
    }
}
