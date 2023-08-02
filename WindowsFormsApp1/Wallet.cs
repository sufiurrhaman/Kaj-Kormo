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
    public partial class Wallet : UserControl
    {
        string cs = ConfigurationManager.ConnectionStrings["dbcs"].ConnectionString;

        private string accNumber;
        private string userName;
        private int Balance;

        public string AccNumber
        {
            set
            {
                string[] number = value.Split(new char[] { 'u', 'w' });
                this.accNumber = number[0];
                this.label8.Text = number[0];

            }
            get { return this.accNumber; }
        }

        public string UserName
        {
            set { this.userName = value; this.label9.Text = value; }
            get { return this.userName; }
        }

        public int AccBalancr
        {
            set { this.Balance = value; this.label10.Text = value.ToString(); }
            get { return this.Balance; }
        }

        public GroupBox GB
        {
            set { this.groupBox1 = value; }
            get { return this.groupBox1; }
        }

        public Wallet()
        {
            InitializeComponent();
        }

        private void button3_Click(object sender, EventArgs e)
        {
            this.groupBox1.Location = new System.Drawing.Point(30, 23);
            this.groupBox2.Text = "Recharge";
            this.groupBox2.Visible = true;
            this.label5.Text = "Recharge Using";
        }

        private void pictureBox1_Click(object sender, EventArgs e)
        {
            if(this.userName[11] == 'u')
            {
                Homepage h = new Homepage();
                Form2main.Instance2.f2mainpanel.Controls.Clear();
                Form2main.Instance2.f2mainpanel.Controls.Add(h);
                this.Dispose();
            }
            else
            {
                Form2main.Instance2.viewWorker();
                this.Dispose();
            }
            

        }

        private void button1_Click(object sender, EventArgs e)
        {
            this.groupBox2.Visible = false;
            this.groupBox1.Location = new System.Drawing.Point(241, 23);
        }

        private void button4_Click(object sender, EventArgs e)
        {
            this.groupBox1.Location = new System.Drawing.Point(30, 23);
            this.groupBox2.Text = "Cash Out";
            this.groupBox2.Visible = true;
            this.label5.Text = "Cash Out Using";
        }

        private void button2_Click(object sender, EventArgs e)
        {
            SqlConnection con = new SqlConnection(cs);
            if (groupBox2.Text == "Recharge")
            {
                if (this.userName[11] == 'u')
                {
                    int balance = int.Parse(label10.Text) + int.Parse(textBox2.Text);
                    string query = "update u_ser set balance = @Balance where phone = @Phone";
                    SqlCommand cmd = new SqlCommand(query, con);
                    cmd.Parameters.AddWithValue("@Balance", balance);
                    cmd.Parameters.AddWithValue("@Phone", this.userName);
                    con.Open();
                    int a = cmd.ExecuteNonQuery();

                    if (a > 0)
                    {

                        this.label10.Text = balance.ToString();
                        MessageBox.Show("Balance added successfully.\nNew balance: " + balance + " TK.", "Success", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                    }
                    else
                    {
                        MessageBox.Show("Something went wrong. Try again later.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);

                    }
                    con.Close();
                }
                else
                {
                    int balance = int.Parse(label10.Text) + int.Parse(textBox2.Text);
                    string query = "update w_orker set balance = @Balance where phone = @Phone";
                    SqlCommand cmd = new SqlCommand(query, con);
                    cmd.Parameters.AddWithValue("@Balance", balance);
                    cmd.Parameters.AddWithValue("@Phone", this.userName);
                    con.Open();
                    int a = cmd.ExecuteNonQuery();

                    if (a > 0)
                    {

                        this.label10.Text = balance.ToString();
                        MessageBox.Show("Balance added successfully.\nNew balance: " + balance + " TK.", "Success", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                    }
                    else
                    {
                        MessageBox.Show("Something went wrong. Try again later.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);

                    }
                    con.Close();
                }

            }
            else
            {
                if (this.userName[11] == 'u')
                {
                    int balance = int.Parse(label10.Text) - int.Parse(textBox2.Text);
                    if(balance > 10)
                    {
                        string query = "update u_ser set balance = @Balance where phone = @Phone";
                        SqlCommand cmd = new SqlCommand(query, con);
                        cmd.Parameters.AddWithValue("@Balance", balance);
                        cmd.Parameters.AddWithValue("@Phone", this.userName);
                        con.Open();
                        int a = cmd.ExecuteNonQuery();

                        if (a > 0)
                        {

                            this.label10.Text = balance.ToString();
                            MessageBox.Show("Cash Out successfully.\nNew balance: " + balance + " TK.", "Success", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                        }
                        else
                        {
                            MessageBox.Show("Something went wrong. Try again later.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);

                        }
                        con.Close();

                    }
                    else
                    {
                        MessageBox.Show("Insufficient Balance." + balance + " TK.", "Success", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);

                    }

                }
                else
                {
                    int balance = int.Parse(label10.Text) - int.Parse(textBox2.Text);
                    if (balance > 10)
                    {
                        string query = "update w_orker set balance = @Balance where phone = @Phone";
                        SqlCommand cmd = new SqlCommand(query, con);
                        cmd.Parameters.AddWithValue("@Balance", balance);
                        cmd.Parameters.AddWithValue("@Phone", this.userName);
                        con.Open();
                        int a = cmd.ExecuteNonQuery();

                        if (a > 0)
                        {

                            this.label10.Text = balance.ToString();
                            MessageBox.Show("Cash Out successfully.\nNew balance: " + balance + " TK.", "Success", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                        }
                        else
                        {
                            MessageBox.Show("Something went wrong. Try again later.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);

                        }
                        con.Close();

                    }
                    else
                    {
                        MessageBox.Show("Insufficient Balance." + balance + " TK.", "Success", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);

                    }
                }
            }
        }
    }
}
