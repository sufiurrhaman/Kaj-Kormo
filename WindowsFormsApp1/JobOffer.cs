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
    public partial class JobOffer : UserControl
    {
        string cs = ConfigurationManager.ConnectionStrings["dbcs"].ConnectionString;

        private string userPhoneDB;
        private string userName;
        private string userLocation;
        private string userTime;
        private string userDate;
        private string userCost;
        private string userMessage;
        private string catagory;
        public string Catagory
        {
            set { this.catagory = value; }
            get { return this.catagory; }
        }

        public string UserPhoneDB
        {
            set { this.userPhoneDB = value;}
            get { return this.userPhoneDB; }
        }

        public string UserName
        {
            set { this.userName = value; this.label1.Text = value; }
            get { return this.userName; }
        }

        public string UserLocation
        {
            set { this.userLocation = value; this.label2.Text = value; }
            get { return this.userLocation; }
        }

        public string UserTime
        {
            set { this.userTime = value; this.label4.Text = "Exp. Time: "+value + "hr"; }
            get { return this.userTime; }
        }

        public string UserDate
        {
            set { string[] s = value.Split(' '); this.userDate = s[0]; this.label5.Text ="Date:"+ s[0]; }
            get { return this.userDate; }
        }

        public string UserCost
        {
            set { this.userCost = value; this.label6.Text = "Exp. payment:"+value+"TK"; }
            get { return this.userCost; }
        }

        public string UserMessage
        {
            set { this.userMessage = value; this.label3.Text ="Note: "+ value; }
            get { return this.userMessage; }
        }

        public JobOffer()
        {
            InitializeComponent();
        }

        private void button2_Click(object sender, EventArgs e)
        {
            if(catagory == "offer")
            {
                SqlConnection con = new SqlConnection(cs);

                string query = "update book_worker set s_tatus = 'processing' where u_ser = @User and w_orker = " +
                    "@Worker and (s_tatus = 'viewed' or s_tatus = 'requested') and work_date = @Date and exp_work_time = @Time";
                SqlCommand cmd = new SqlCommand(query, con);
                cmd.Parameters.AddWithValue("@User", this.userPhoneDB);
                cmd.Parameters.AddWithValue("@Worker", Form2main.Instance2.AccountPhoneDB);
                cmd.Parameters.AddWithValue("@Date", this.userDate);
                cmd.Parameters.AddWithValue("@Time", this.userTime);


                con.Open();
                int a = cmd.ExecuteNonQuery();
                con.Close();
                if (a > 0)
                {
                    MessageBox.Show("Job Accepted.", "Success", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);

                    SqlConnection con2 = new SqlConnection(cs);
                    string query2 = "update w_orker set assigned = 'Yes' where phone = @Phone";
                    SqlCommand cmd2 = new SqlCommand(query2, con2);
                    cmd2.Parameters.AddWithValue("@Phone", Form2main.Instance2.AccountPhoneDB);
                    con2.Open();
                    cmd2.ExecuteNonQuery();
                    con2.Close();
                }
                else
                {
                    MessageBox.Show("Something went wrong.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);

                }
            }
            else
            {
                SqlConnection con = new SqlConnection(cs);
                string query = "select * from w_orker where phone = @Phone";
                SqlCommand cmd = new SqlCommand(query, con);
                cmd.Parameters.AddWithValue("@Phone", Form2main.Instance2.AccountPhoneDB);
                con.Open();
                SqlDataReader dr = cmd.ExecuteReader();
                dr.Read();
                int f = int.Parse(dr[7].ToString()) * int.Parse(this.userTime);
                con.Close();

                SqlConnection con2 = new SqlConnection(cs);
                string query2 = "update book_worker set s_tatus = 'processing', w_orker = @Worker, exp_fees = @Fees where u_ser = @User and " +
                    " s_tatus = 'post'  and work_date = @Date and exp_work_time = @Time and catagory = @Skill";
                SqlCommand cmd2 = new SqlCommand(query2, con2);
                cmd2.Parameters.AddWithValue("@User", this.userPhoneDB);
                cmd2.Parameters.AddWithValue("@Worker", Form2main.Instance2.AccountPhoneDB);
                cmd2.Parameters.AddWithValue("@Date", this.userDate);
                cmd2.Parameters.AddWithValue("@Time", this.userTime);
                cmd2.Parameters.AddWithValue("@Fees", f);
                cmd2.Parameters.AddWithValue("@Skill", Form2main.Instance2.Skill);
                con2.Open();
                int a = cmd2.ExecuteNonQuery();
                con2.Close();
                if (a > 0)
                {
                    MessageBox.Show("Job Accepted.", "Success", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);

                    SqlConnection con22 = new SqlConnection(cs);
                    string query22 = "update w_orker set assigned = 'Yes' where phone = @Phone";
                    SqlCommand cmd22 = new SqlCommand(query22, con22);
                    cmd22.Parameters.AddWithValue("@Phone", Form2main.Instance2.AccountPhoneDB);
                    con22.Open();
                    cmd22.ExecuteNonQuery();
                    con22.Close();
                }
                else
                {
                    MessageBox.Show("Something went wrong.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);

                }

            }

        }
    }
}
