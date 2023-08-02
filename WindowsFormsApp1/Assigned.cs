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
    public partial class Assigned : UserControl
    {
        string cs = ConfigurationManager.ConnectionStrings["dbcs"].ConnectionString;

        private string name;
        private string phone;
        private string date;
        private string time;
        private string fees;
        private string note;
        private string username;
        private string loginUsername;
        private string balance;
        private string id;

        public GroupBox g1
        {
            set { this.groupBox2 = value; }
            get { return this.groupBox2; }
        }

        public string Wid
        {
            set { this.id = value; }
            get { return this.id; }
        }

        public string WBalance
        {
            set { this.balance = value; }
            get { return this.balance; }
        }

        public string LoginUsername
        {
            set { this.loginUsername = value; }
            get { return this.loginUsername; }
        }

        public string WName
        {
            set { this.name = value; this.label4.Text = value; }
            get { return this.name; }
        }

        public string WPhone
        {
            set
            {
                this.username = value;
                string[] Phone = value.Split('w');
                this.phone = Phone[0];
                this.label5.Text = Phone[0];

            }
            get { return this.phone; }
        }

        public string WDate
        {
            set { string[] d = value.Split(' '); this.date = d[0]; this.label8.Text = d[0]; }
            get { return this.date; }
        }

        public string WTime
        {
            set { this.time = value; this.label10.Text = value; this.textBox1.Text = value; }
            get { return this.time; }
        }

        public string WFees
        {
            set { this.fees = value; this.textBox2.Text = value; this.label12.Text = value; }
            get { return this.fees; }
        }

        public string WNote
        {
            set { this.note = value; this.label2.Text = value; }
            get { return this.note; }
        }

        public Assigned()
        {
            InitializeComponent();
        }

        private void button3_Click(object sender, EventArgs e)
        {
            int Balance = int.Parse(this.balance) + int.Parse(this.textBox2.Text);
            int Balance2 = int.Parse(Form2main.Instance2.AccBalance) - int.Parse(this.textBox2.Text);
            
            if(Balance2 > 10)
            {
                SqlConnection con2 = new SqlConnection(cs);
                string query2 = "update w_orker set balance = @Balance where phone = @Phone";
                SqlCommand cmd2 = new SqlCommand(query2, con2);
                cmd2.Parameters.AddWithValue("@Phone", this.username);
                cmd2.Parameters.AddWithValue("@Balance", Balance);
                con2.Open();
                cmd2.ExecuteNonQuery();
                con2.Close();

                SqlConnection con = new SqlConnection(cs);
                string query = "update book_worker set main_time = @Time, main_fees = @Fees, s_tatus = 'payment' where consecutiveNumber = @id";
                SqlCommand cmd = new SqlCommand(query, con);
                cmd.Parameters.AddWithValue("@Time", this.textBox1.Text);
                cmd.Parameters.AddWithValue("@Fees", this.textBox2.Text);
                cmd.Parameters.AddWithValue("@id", this.id);
                con.Open();
                cmd.ExecuteNonQuery();
                con.Close();

                SqlConnection con22 = new SqlConnection(cs);
                string query22 = "select * from u_ser where phone = @thisPhone";
                SqlCommand cmd22 = new SqlCommand(query22, con22);
                cmd22.Parameters.AddWithValue("@thisPhone", Form2main.Instance2.AccountPhoneDB);
                con22.Open();
                SqlDataReader dr22 = cmd22.ExecuteReader();
                dr22.Read();
                int orders = int.Parse(dr22[5].ToString()) + 1;
                con22.Close();

                SqlConnection con3 = new SqlConnection(cs);
                string query3 = "update u_ser set balance = @Balance, orders = @Orders where phone = @Phone";
                SqlCommand cmd3 = new SqlCommand(query3, con3);
                cmd3.Parameters.AddWithValue("@Phone", Form2main.Instance2.AccountPhoneDB);
                cmd3.Parameters.AddWithValue("@Balance", Balance2);
                cmd3.Parameters.AddWithValue("@Orders", orders);
                con3.Open();
                cmd3.ExecuteNonQuery();
                con3.Close();



                MessageBox.Show("Payment successfull.", "Success", MessageBoxButtons.OK, MessageBoxIcon.Information);

                this.groupBox2.Visible = false;
            }
            else
            {
                MessageBox.Show("Insufficient Balance. Try Cash Payment", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);

            }



        }

        private void label4_Click(object sender, EventArgs e)
        {
            //MessageBox.Show("Thank you for your response.", "Success", MessageBoxButtons.OK, MessageBoxIcon.Information);
            SqlConnection con2 = new SqlConnection(cs);
            string query2 = "select * from w_orker where phone = @Phone";
            SqlCommand cmd2 = new SqlCommand(query2, con2);
            cmd2.Parameters.AddWithValue("@Phone", this.username);
            con2.Open();
            SqlDataReader dr2 = cmd2.ExecuteReader();
            dr2.Read();

            WorkerProfileForBooking w = new WorkerProfileForBooking();
            w.WbPhone = dr2[0].ToString();
            w.WbName = dr2[1].ToString();
            w.WbSkill = dr2[5].ToString();
            w.WbLocation = dr2[3].ToString();
            w.WbGender = dr2[2].ToString();
            w.WbAge = dr2[8].ToString();
            w.WbTotalJobsDone = dr2[0].ToString();
            w.WbFees = int.Parse(dr2[7].ToString());
            w.WbRatedBy = int.Parse(dr2[12].ToString());
            w.WbRate = int.Parse(dr2[11].ToString());
            int rate = int.Parse(dr2[11].ToString());

            if (dr2[9].ToString() == "No")
            {
                w.gbox2.Visible = true;
                w.Lbl.Visible = false;
            }
            else
            {
                w.gbox2.Visible = false;
                w.Lbl.Visible = true;
            }

            if (rate == 0)
            {
                w.RateImage = Properties.Resources._0star;
            }
            else if (rate == 1)
            {
                w.RateImage = Properties.Resources._1star;
            }
            else if (rate == 2)
            {
                w.RateImage = Properties.Resources._2star;
            }
            else if (rate == 3)
            {
                w.RateImage = Properties.Resources._3star;
            }
            else if (rate == 4)
            {
                w.RateImage = Properties.Resources._4star;
            }
            else if (rate == 5)
            {
                w.RateImage = Properties.Resources._5star;
            }
            Form2main.Instance2.f2mainpanel.Controls.Clear();
            Form2main.Instance2.f2mainpanel.Controls.Add(w);
            this.Dispose();
        }
    }
}
