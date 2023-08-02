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
    public partial class Signup : UserControl
    {
        string cs = ConfigurationManager.ConnectionStrings["dbcs"].ConnectionString;

        public Signup()
        {
            InitializeComponent();
        }

        private void comboBox1_Leave(object sender, EventArgs e)
        {
            if (comboBox1.SelectedItem == null)
            {
                comboBox1.Focus();
                errorProvider1.Icon = Properties.Resources.icons8_Cancel;
                errorProvider1.SetError(this.comboBox1, "Invalid");
            }
        }

        private void button1_Click(object sender, EventArgs e)
        {
            Login l = new Login();
            l.Visible = true;
        }

        private void groupBox1_Enter(object sender, EventArgs e)
        {
            /*if (comboBox1.SelectedItem == null)
            {
                comboBox1.Focus();
                errorProvider1.Icon = Properties.Resources.icons8_Cancel;
                errorProvider1.SetError(comboBox1, "Empty Field.");
            }
            else
            {
                errorProvider1.Icon = Properties.Resources.icons8_Checked;
                errorProvider1.SetError(comboBox1, "Valid Field.");

                if (comboBox1.SelectedItem == "Worker")
                {
                    this.button1.Text = "Next";
                }
                else
                {
                    this.button1.Text = "Sign Up";
                }
            }*/
        }

        private void textBox1_Leave(object sender, EventArgs e)
        {
            if (String.IsNullOrEmpty(textBox1.Text) || textBox1.Text == "")
            {
                textBox1.Focus();
                errorProvider2.Icon = Properties.Resources.icons8_Cancel;
                errorProvider2.SetError(textBox1, "Empty Field.");
            }
            else
            {
                errorProvider2.Icon = Properties.Resources.icons8_Checked;
                errorProvider2.SetError(textBox1, "Valid Field.");
            }
        }

        private void textBox2_Leave(object sender, EventArgs e)
        {
            if (String.IsNullOrEmpty(textBox2.Text) == true)
            {
                textBox2.Focus();
                errorProvider3.Icon = Properties.Resources.icons8_Cancel;
                errorProvider3.SetError(this.textBox2, "Empty Field.");
            }
            else if (textBox2.Text.Length < 11 || textBox2.Text.Length > 11)
            {
                textBox2.Focus();
                errorProvider3.Icon = Properties.Resources.icons8_Cancel;
                errorProvider3.SetError(this.textBox2, "Invalid Number.1");
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
                    errorProvider3.Icon = Properties.Resources.icons8_Cancel;
                    errorProvider3.SetError(this.textBox2, "Invalid Format.");
                }
                else
                {
                    errorProvider3.Icon = Properties.Resources.icons8_Checked;
                    errorProvider3.SetError(this.textBox2, "Correct.");
                }
            }
        }

        private void textBox3_Leave(object sender, EventArgs e)
        {
            if (String.IsNullOrEmpty(textBox3.Text) || textBox3.Text == "")
            {
                textBox3.Focus();
                errorProvider5.Icon = Properties.Resources.icons8_Cancel;
                errorProvider5.SetError(textBox3, "Empty Field.");
            }
            else
            {
                errorProvider5.Icon = Properties.Resources.icons8_Checked;
                errorProvider5.SetError(textBox3, "Valid Field.");
            }
        }

        private void textBox4_Leave(object sender, EventArgs e)
        {
            if (String.IsNullOrEmpty(textBox4.Text) == true)
            {
                textBox4.Focus();
                errorProvider4.Icon = Properties.Resources.icons8_Cancel;
                errorProvider4.SetError(this.textBox4, "Empty Field.");
            }

            else
            {
                int flag = 0;
                for (int i = 0; i < textBox4.Text.Length; i++)
                {
                    if (Char.IsLetter(textBox4.Text[i]))
                    {
                        flag = 1;
                        break;
                    }
                }
                if (flag == 1)
                {
                    textBox4.Focus();
                    errorProvider4.Icon = Properties.Resources.icons8_Cancel;
                    errorProvider4.SetError(this.textBox4, "Invalid Format.");
                }
                else
                {
                    errorProvider4.Icon = Properties.Resources.icons8_Checked;
                    errorProvider4.SetError(this.textBox4, "Valid");
                }
            }
        }

        private void button1_MouseEnter(object sender, EventArgs e)
        {
            if (!checkBox1.Checked)
            {
                checkBox1.Focus();
                errorProvider6.Icon = Properties.Resources.icons8_Cancel;
                errorProvider6.SetError(linkLabel1, "Not Checked");
            }
            else
            {
                errorProvider6.Icon = Properties.Resources.icons8_Checked;
                errorProvider6.SetError(linkLabel1, "Checked");
                if (comboBox1.SelectedItem == "Worker")
                {
                    /*if (comboBox2.SelectedItem == null)
                    {
                        comboBox2.Focus();
                        errorProvider7.Icon = Properties.Resources.icons8_Cancel;
                        errorProvider7.SetError(comboBox2, "Invalid");
                    }
                    else
                    {
                        errorProvider7.Icon = Properties.Resources.icons8_Checked;
                        errorProvider7.SetError(comboBox2, "Valid");
                    }*/
                }
            }
        }

        private void button1_Enter(object sender, EventArgs e)
        {
            if (!checkBox1.Checked)
            {
                checkBox1.Focus();
                errorProvider6.Icon = Properties.Resources.icons8_Cancel;
                errorProvider6.SetError(linkLabel1, "Not Checked");
            }
            else
            {
                errorProvider6.Icon = Properties.Resources.icons8_Checked;
                errorProvider6.SetError(linkLabel1, "Checked");
                if (comboBox1.SelectedItem == "Worker")
                {

                }
            }
        }

        private void button1_Click_1(object sender, EventArgs e)
        {
            if (this.button1.Text == "Sign Up")
            {
                SqlConnection con = new SqlConnection(cs);
                string query = "insert into u_ser values(@Phone, @Username, @Gender, @Location, @Pin, 0,0,null)";
                SqlCommand cmd = new SqlCommand(query, con);
                //con.Open();
                //cmd.Parameters.AddWithValue("@", textBox2.Text);
                cmd.Parameters.AddWithValue("@Phone", textBox2.Text + "u");
                cmd.Parameters.AddWithValue("@Username", textBox1.Text);
                cmd.Parameters.AddWithValue("@Gender", comboBox2.SelectedItem.ToString());
                cmd.Parameters.AddWithValue("@Location", textBox3.Text);
                cmd.Parameters.AddWithValue("@Pin", int.Parse(textBox4.Text));
                con.Open();
                int a = cmd.ExecuteNonQuery();
                //con.Open();
                //SqlDataReader dr = cmd.ExecuteReader();
                if (a > 0)
                {
                    MessageBox.Show("Account Creation Successful.\n Username: "+textBox2.Text+"u.\nPin: "+textBox4.Text+".", "Success", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                    if (!Form1.Instance.mainPanel.Controls.ContainsKey("Login"))
                    {
                        Login sn = new Login();
                        sn.Dock = DockStyle.Fill;
                        Form1.Instance.mainPanel.Controls.Add(sn);
                    }
                    Form1.Instance.mainPanel.Controls["Login"].BringToFront();
                    Form1.Instance.backButton.Visible = true;
                    this.Dispose();
                }
                else
                {
                    MessageBox.Show("Sign Up Failed. Try again!", "Error", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);

                }
                con.Close();
            }
            else
            {
                SqlConnection con = new SqlConnection(cs);
                string query = "insert into w_orker values(@Phone, @Username, @Gender, @Location, @Pin, null,null,null,null,null,null,null,null,null)";
                SqlCommand cmd = new SqlCommand(query, con);
                //con.Open();
                //cmd.Parameters.AddWithValue("@", textBox2.Text);
                cmd.Parameters.AddWithValue("@Phone", textBox2.Text + "w");
                cmd.Parameters.AddWithValue("@Username", textBox1.Text);
                cmd.Parameters.AddWithValue("@Gender", comboBox2.SelectedItem.ToString());
                cmd.Parameters.AddWithValue("@Location", textBox3.Text);
                cmd.Parameters.AddWithValue("@Pin", int.Parse(textBox4.Text));
                con.Open();
                int a = cmd.ExecuteNonQuery();
                //con.Open();
                //SqlDataReader dr = cmd.ExecuteReader();
                if (a > 0)
                {
                    if (!Form1.Instance.mainPanel.Controls.ContainsKey("SignupNext"))
                    {
                        SignupNext sn = new SignupNext();
                        sn.SignupName = textBox2.Text + "w";
                        sn.SignupPin = textBox4.Text;
                        sn.Dock = DockStyle.Fill;
                        Form1.Instance.mainPanel.Controls.Add(sn);
                    }
                    con.Close();
                    Form1.Instance.mainPanel.Controls["Signup"].BringToFront();
                    Form1.Instance.backButton.Visible = true;
                    this.Dispose();
                }
                else
                {
                    MessageBox.Show("Failed. Try again!", "Error", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                    con.Close();
                }
                /*
                //MessageBox.Show("Hello Worker");
                if (!Form1.Instance.mainPanel.Controls.ContainsKey("SignupNext"))
                {
                    SignupNext sn = new SignupNext();
                    sn.Dock = DockStyle.Fill;
                    Form1.Instance.mainPanel.Controls.Add(sn);
                }
                Form1.Instance.mainPanel.Controls["Signup"].BringToFront();
                Form1.Instance.backButton.Visible = true;
                this.Dispose();
                */
            }
        }

        private void groupBox1_MouseHover(object sender, EventArgs e)
        {
            if (comboBox1.SelectedItem == null)
            {
                comboBox1.Focus();
                errorProvider1.Icon = Properties.Resources.icons8_Cancel;
                errorProvider1.SetError(comboBox1, "Empty Field.");
            }
            else
            {
                errorProvider1.Icon = Properties.Resources.icons8_Checked;
                errorProvider1.SetError(comboBox1, "Valid Field.");

                if (comboBox1.SelectedItem == "Worker")
                {
                    this.button1.Text = "Next";
                }
                else
                {
                    this.button1.Text = "Sign Up";
                }
            }
        }

        private void textBox1_Enter(object sender, EventArgs e)
        {
            if (comboBox1.SelectedItem == null)
            {
                comboBox1.Focus();
                errorProvider1.Icon = Properties.Resources.icons8_Cancel;
                errorProvider1.SetError(comboBox1, "Empty Field.");
            }
            else
            {
                errorProvider1.Icon = Properties.Resources.icons8_Checked;
                errorProvider1.SetError(comboBox1, "Valid Field.");

                if (comboBox1.SelectedItem == "Worker")
                {
                    this.button1.Text = "Next";
                }
                else
                {
                    this.button1.Text = "Sign Up";
                }
            }
        }
    }
}
