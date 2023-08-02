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
    public partial class Report : Form
    {
        string cs = ConfigurationManager.ConnectionStrings["dbcs"].ConnectionString;

        public ComboBox cbox
        {
            set { this.comboBox1 = value; }
            get { return this.comboBox1; }
        }

        public Label lbl
        {
            set { this.label2 = value; }
            get { return this.label2; }
        }

        public TextBox tbox
        {
            set { this.textBox1 = value; }
            get { return this.textBox1; }
        }

        public Report()
        {
            InitializeComponent();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            this.Dispose();
        }

        private void comboBox1_Leave(object sender, EventArgs e)
        {
            if(comboBox1.SelectedItem == null)
            {
                comboBox1.Focus();
                errorProvider1.Icon = Properties.Resources.icons8_Cancel;
                errorProvider1.SetError(comboBox1, "Invalid");
            }
            else if(comboBox1.SelectedItem == "Report an account")
            {
                errorProvider1.Icon = Properties.Resources.icons8_Checked;
                errorProvider1.SetError(comboBox1, "valid");
                label2.Visible = true;
                textBox1.Visible = true;
            }
            else
            {
                label2.Visible = false;
                textBox1.Visible = false;
                errorProvider1.Icon = Properties.Resources.icons8_Checked;
                errorProvider1.SetError(comboBox1, "valid");
            }
        }

        private void comboBox1_MouseLeave(object sender, EventArgs e)
        {
            if (comboBox1.SelectedItem == null)
            {
                comboBox1.Focus();
                errorProvider1.Icon = Properties.Resources.icons8_Cancel;
                errorProvider1.SetError(comboBox1, "Invalid");
            }
            else if (comboBox1.SelectedItem == "Report an account")
            {
                errorProvider1.Icon = Properties.Resources.icons8_Checked;
                errorProvider1.SetError(comboBox1, "valid");
                label2.Visible = true;
                textBox1.Visible = true;
            }
            else
            {
                label2.Visible = false;
                textBox1.Visible = false;
                errorProvider1.Icon = Properties.Resources.icons8_Checked;
                errorProvider1.SetError(comboBox1, "valid");
            }
        }

        private void groupBox1_MouseHover(object sender, EventArgs e)
        {
            if (comboBox1.SelectedItem == null)
            {
                comboBox1.Focus();
                errorProvider1.Icon = Properties.Resources.icons8_Cancel;
                errorProvider1.SetError(comboBox1, "Invalid");
            }
            else if (comboBox1.SelectedItem == "Report an account")
            {
                errorProvider1.Icon = Properties.Resources.icons8_Checked;
                errorProvider1.SetError(comboBox1, "valid");
                label2.Visible = true;
                textBox1.Visible = true;
            }
            else
            {
                label2.Visible = false;
                textBox1.Visible = false;
                errorProvider1.Icon = Properties.Resources.icons8_Checked;
                errorProvider1.SetError(comboBox1, "valid");
            }
        }

        private void button2_Click(object sender, EventArgs e)
        {
            if (comboBox1.SelectedItem == null)
            {
                comboBox1.Focus();
                errorProvider1.Icon = Properties.Resources.icons8_Cancel;
                errorProvider1.SetError(comboBox1, "Invalid");
            }
            else
            {
                if (comboBox1.SelectedItem == "Report an account")
                {
                    SqlConnection con3 = new SqlConnection(cs);

                    string query3 = "select * from book_worker where (s_tatus = 'done' or s_tatus = 'processing') and w_orker = @Worker and u_ser = @User";
                    SqlCommand cmd3 = new SqlCommand(query3, con3);
                    cmd3.Parameters.AddWithValue("@User", Form2main.Instance2.AccountPhoneDB);
                    cmd3.Parameters.AddWithValue("@Worker", this.textBox1.Text);
                    //cmd3.Parameters.AddWithValue("@Number", this.workerRatedby + 1);
                    con3.Open();
                    SqlDataReader dr3 = cmd3.ExecuteReader();
                    if (dr3.HasRows)
                    {
                        SqlConnection con = new SqlConnection(cs);

                        string query = "insert into Report_issue values(@Person,@Reported,@Title,@Details,'No')";
                        SqlCommand cmd = new SqlCommand(query, con);
                        cmd.Parameters.AddWithValue("@Person", Form2main.Instance2.AccountPhoneDB);
                        cmd.Parameters.AddWithValue("@Reported", this.textBox1.Text);
                        cmd.Parameters.AddWithValue("@Title", comboBox1.SelectedItem);
                        cmd.Parameters.AddWithValue("@Details", textBox2.Text);


                        //cmd3.Parameters.AddWithValue("@Number", this.workerRatedby + 1);
                        con.Open();
                        int a = cmd.ExecuteNonQuery();
                        con.Close();
                        if (a > 0)
                        {
                            MessageBox.Show("Response submitted. We will investigate the issue. Thank You.", "Success", MessageBoxButtons.OK, MessageBoxIcon.Information);
                            this.Dispose();

                        }
                    }
                    else
                    {
                        MessageBox.Show("Something went wrong. Try again.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);

                    }
                    con3.Close();
                }
                else
                {
                    SqlConnection con = new SqlConnection(cs);

                    string query = "insert into Report_issue values(@Person,'null',@Title,@Details,'No')";
                    SqlCommand cmd = new SqlCommand(query, con);
                    cmd.Parameters.AddWithValue("@Person", Form2main.Instance2.AccountPhoneDB);
                    //cmd.Parameters.AddWithValue("@Reported", this.textBox1.Text);
                    cmd.Parameters.AddWithValue("@Title", comboBox1.SelectedItem);
                    cmd.Parameters.AddWithValue("@Details", textBox2.Text);


                    //cmd3.Parameters.AddWithValue("@Number", this.workerRatedby + 1);
                    con.Open();
                    int a = cmd.ExecuteNonQuery();
                    con.Close();
                    if (a > 0)
                    {
                        MessageBox.Show("Response submitted. We will investigate the issue. Thank You.", "Success", MessageBoxButtons.OK, MessageBoxIcon.Information);
                        this.Dispose();

                    }
                }
            }
            
            
        }
    }
}
