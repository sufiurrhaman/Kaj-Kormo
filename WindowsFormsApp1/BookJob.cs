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
    public partial class BookJob : Form
    {
        string cs = ConfigurationManager.ConnectionStrings["dbcs"].ConnectionString;

        static BookJob _obj;
        private string workDate;
        private int expectedTime;
        private int expectedCost;
        private int workersFees;
        private string message;
        private string workerPhone;
        private string userPhone = Form2main.Instance2.AccountPhoneDB;

        public string WorkerPhone
        {
            set { this.workerPhone = value + "w"; }
            get { return this.workerPhone; }
        }

        public string Message
        {
            set { this.message = value; }
            get { return this.message; }
        }

        public string WorkDate
        {
            set { this.workDate = value; label2.Text = value; }
            get { return this.workDate; }
        }

        public int ExpectedTime
        {
            set { this.expectedTime = value; this.label4.Text = value.ToString(); }
            get { return this.expectedTime; }
        }

        public int ExpectedCost
        {
            set { this.expectedCost = value; this.label7.Text = value.ToString(); }
            get { return this.expectedCost; }
        }

        public int WorkersFees
        {
            set { this.workersFees = value; this.label6.Text = value.ToString(); }
            get { return this.workersFees; }
        }

        public static BookJob Instance3
        {
            get
            {
                if (_obj == null)
                {
                    _obj = new BookJob();
                }
                return _obj;
            }
        }

        public BookJob()
        {
            InitializeComponent();
        }

        private void button4_Click(object sender, EventArgs e)
        {
            this.Visible = false;
        }

        private void pictureBox1_Click(object sender, EventArgs e)
        {
            this.Visible = false;
        }

        private void button3_Click(object sender, EventArgs e)
        {
            SqlConnection con = new SqlConnection(cs);
            string query = "insert into book_worker values(@User, @Worker, @Note, 'requested', @Workdate,@Worktime ,@ExpFees" +
                ",null,null,null,'offer')";
            SqlCommand cmd = new SqlCommand(query, con);
            //con.Open();
            //cmd.Parameters.AddWithValue("@", textBox2.Text);
            cmd.Parameters.AddWithValue("@User", this.userPhone);
            cmd.Parameters.AddWithValue("@Worker", this.workerPhone);
            cmd.Parameters.AddWithValue("@Note", this.message);
            cmd.Parameters.AddWithValue("@Workdate", this.workDate);
            cmd.Parameters.AddWithValue("@Worktime", this.expectedTime);
            cmd.Parameters.AddWithValue("@ExpFees", this.expectedCost);


            //cmd.Parameters.AddWithValue("@Pin", int.Parse(textBox4.Text));
            con.Open();
            int a = cmd.ExecuteNonQuery();
            //con.Open();
            //SqlDataReader dr = cmd.ExecuteReader();
            if (a > 0)
            {
                MessageBox.Show("Request Sent.", "Success", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                
                this.Dispose();
            }
            else
            {
                MessageBox.Show("Something went wrong. Try again!", "Error", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);

            }
            con.Close();
        }
    }
}
