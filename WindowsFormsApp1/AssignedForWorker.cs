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
    public partial class AssignedForWorker : UserControl
    {
        string cs = ConfigurationManager.ConnectionStrings["dbcs"].ConnectionString;

        private string loginUsername;
        private string name;
        private string phone;
        private string date;
        private string time;
        private string fees;
        private string note;
        private string username;
        private string location;

        private string finalTime;
        private string finalFees;
        private string id;

        public string Wid
        {
            set { this.id = value; }
            get { return this.id; }
        }

        public string FinalTime
        {
            set { this.finalTime = value; this.textBox1.Text = value; }
            get { return this.finalTime; }
        }

        public string FinalFees
        {
            set { this.finalFees = value; this.textBox2.Text = value; }
            get { return this.finalFees; }
        }


        public Button b1
        {
            set { this.button1 = value; }
            get { return this.button1; }
        }

        public GroupBox g1
        {
            set { this.groupBox2 = value; }
            get { return this.groupBox2; }
        }

        public string WLocation
        {
            set { this.location = value; this.label14.Text = value; }
            get { return this.location; }
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
                string[] Phone = value.Split('u');
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
            set { this.time = value; this.label10.Text = value; }
            get { return this.time; }
        }

        public string WFees
        {
            set { this.fees = value;  this.label12.Text = value; }
            get { return this.fees; }
        }

        public string WNote
        {
            set { this.note = value; this.label2.Text = value; }
            get { return this.note; }
        }

        public AssignedForWorker()
        {
            InitializeComponent();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            SqlConnection con = new SqlConnection(cs);
            string query = "update book_worker set s_tatus = 'cancel' where consecutiveNumber = @id";
            SqlCommand cmd = new SqlCommand(query, con);
            //cmd.Parameters.AddWithValue("@Time", this.textBox1.Text);
            //cmd.Parameters.AddWithValue("@Fees", this.textBox2.Text);
            cmd.Parameters.AddWithValue("@id", this.id);
            con.Open();
            int a = cmd.ExecuteNonQuery();
            con.Close();
            if (a > 0)
            {
                SqlConnection con2 = new SqlConnection(cs);
                string query2 = "update w_orker set assigned = 'No' where phone = @Phone";
                SqlCommand cmd2 = new SqlCommand(query2, con2);
                //cmd2.Parameters.AddWithValue("@Jobs", Jobs);
                cmd2.Parameters.AddWithValue("@Phone", Form2main.Instance2.AccountPhoneDB);
                //cmd2.Parameters.AddWithValue("@id", this.id);
                con2.Open();
                int a2 = cmd2.ExecuteNonQuery();
                con2.Close();
                MessageBox.Show("Job cancled.", "Success", MessageBoxButtons.OK, MessageBoxIcon.Information);
                Form2main.Instance2.viewWorker();
                this.Dispose();
            }
        }

        private void button2_Click(object sender, EventArgs e)
        {
            SqlConnection con = new SqlConnection(cs);
            string query = "update book_worker set s_tatus = 'done' where consecutiveNumber = @id";
            SqlCommand cmd = new SqlCommand(query, con);
            //cmd.Parameters.AddWithValue("@Time", this.textBox1.Text);
            //cmd.Parameters.AddWithValue("@Fees", this.textBox2.Text);
            cmd.Parameters.AddWithValue("@id", this.id);
            con.Open();
            int a = cmd.ExecuteNonQuery();
            con.Close();

            SqlConnection con3 = new SqlConnection(cs);
            string query3 = "select * from w_orker where phone = @Phone";
            SqlCommand cmd3 = new SqlCommand(query3, con3);
            cmd3.Parameters.AddWithValue("@Phone",Form2main.Instance2.AccountPhoneDB);
            con3.Open();
            SqlDataReader dr = cmd3.ExecuteReader();
            dr.Read();
            int Jobs = int.Parse(dr[10].ToString()) + 1;
            con3.Close();

            SqlConnection con2 = new SqlConnection(cs);
            string query2 = "update w_orker set jobs = @Jobs, assigned = 'No' where phone = @Phone";
            SqlCommand cmd2 = new SqlCommand(query2, con2);
            cmd2.Parameters.AddWithValue("@Jobs", Jobs);
            cmd2.Parameters.AddWithValue("@Phone", Form2main.Instance2.AccountPhoneDB);
            //cmd2.Parameters.AddWithValue("@id", this.id);
            con2.Open();
            int a2 = cmd2.ExecuteNonQuery();
            con2.Close();

            if (a > 0 && a2 > 0)
            {
                MessageBox.Show("Confirmed.", "Success", MessageBoxButtons.OK, MessageBoxIcon.Information);
                viewWorker();
            }
            else
            {
                MessageBox.Show("Something went wrong.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }

        }

        public void viewWorker()
        {
            SqlConnection con = new SqlConnection(cs);

            string query = "select * from w_orker where phone = @Phone";
            SqlCommand cmd = new SqlCommand(query, con);
            cmd.Parameters.AddWithValue("@Phone", Form2main.Instance2.AccountPhoneDB);
            //cmd.Parameters.AddWithValue("@Pin", textBox2.Text);
            con.Open();
            SqlDataReader dr = cmd.ExecuteReader();
            Form2main.Instance2.f2mainpanel.Controls.Clear();
            if (dr.HasRows)
            {
                dr.Read();
                WorkerHome w = new WorkerHome();
                w.WorkerPhone = dr[0].ToString();
                w.WorkerUsername = dr[0].ToString();
                w.WorkerLocation = dr[3].ToString();
                w.WorkerBalance = dr[6].ToString();
                w.WorkerReview = dr[11].ToString();
                w.WorkerReviewby = dr[12].ToString();
                w.WorkerTotaljob = dr[10].ToString();
                Form2main.Instance2.f2mainpanel.Controls.Add(w);
                //MessageBox.Show( dr[1].ToString(), "Success", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
            }
            else
            {
                MessageBox.Show("Something went wrong.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);

            }
            con.Close();
        }
    }
}
