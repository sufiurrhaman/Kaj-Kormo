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
    public partial class SignupNext : UserControl
    {
        string cs = ConfigurationManager.ConnectionStrings["dbcs"].ConnectionString;

        private string signupName;
        private string signupPin;
        public string SignupName
        {
            set { this.signupName = value; }
            get { return this.signupName; }
        }

        public string SignupPin
        {
            set { this.signupPin = value; }
            get { return this.signupPin; }
        }

        public SignupNext()
        {
            InitializeComponent();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            if(textBox1.Text == "")
            {
                textBox1.Focus();
            }
            else if(textBox2.Text == "")
            {
                textBox2.Focus();
            }
            else if(comboBox2.SelectedItem == null)
            {
                comboBox2.Focus();
            }
            else
            {
                SqlConnection con = new SqlConnection(cs);
                string query = "update w_orker set skill = @Skill,balance = 0,fees = @Fees,age = @Age, assigned = 'No'," +
                    "jobs = 0,review = 0,reviewNumber = 0,picture = null where phone =@Phone";
                SqlCommand cmd = new SqlCommand(query, con);
                //con.Open();
                cmd.Parameters.AddWithValue("@Phone", SignupName);
                cmd.Parameters.AddWithValue("@Skill", comboBox2.SelectedItem.ToString());
                cmd.Parameters.AddWithValue("@Fees", int.Parse(textBox1.Text));
                cmd.Parameters.AddWithValue("@Age", int.Parse(textBox2.Text));
                //cmd.Parameters.AddWithValue("@Location", textBox3.Text);
                //cmd.Parameters.AddWithValue("@Pin", int.Parse(textBox4.Text));
                con.Open();
                int a = cmd.ExecuteNonQuery();
                //con.Open();
                //SqlDataReader dr = cmd.ExecuteReader();
                if (a > 0)
                {
                    MessageBox.Show("Account Creation Successful.\n Username: " + SignupName + "\nPin: " + SignupPin + ".", "Success", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
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
        }

        private void textBox2_Enter(object sender, EventArgs e)
        {
            int flag = 0;
            for (int i = 0; i < textBox1.Text.Length; i++)
            {
                if (Char.IsLetter(textBox1.Text[i]))
                {
                    flag = 1;
                    break;
                }
            }
            if (flag == 1)
            {
                textBox1.Focus();
                errorProvider1.Icon = Properties.Resources.icons8_Cancel;
                errorProvider1.SetError(this.textBox1, "Invalid Format.");
            }
            else
            {
                errorProvider1.Icon = Properties.Resources.icons8_Checked;
                errorProvider1.SetError(this.textBox1, "Valid");
            }
        }

        private void comboBox2_Enter(object sender, EventArgs e)
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

        private void button1_MouseEnter(object sender, EventArgs e)
        {
            if(comboBox2.SelectedItem == null){
                comboBox2.Focus();
                errorProvider3.Icon = Properties.Resources.icons8_Cancel;
                errorProvider3.SetError(this.comboBox2, "Invalid Format.");
            }
            else
            {
                errorProvider3.Icon = Properties.Resources.icons8_Checked;
                errorProvider3.SetError(this.comboBox2, "Valid");
            }
        }

        private void button1_Enter(object sender, EventArgs e)
        {
            if (comboBox2.SelectedItem == null)
            {
                comboBox2.Focus();
                errorProvider3.Icon = Properties.Resources.icons8_Cancel;
                errorProvider3.SetError(this.comboBox2, "Invalid Format.");
            }
            else
            {
                errorProvider3.Icon = Properties.Resources.icons8_Checked;
                errorProvider3.SetError(this.comboBox2, "Valid");
            }
        }
    }
}
