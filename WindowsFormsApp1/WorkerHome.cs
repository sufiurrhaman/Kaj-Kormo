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

    public partial class WorkerHome : UserControl
    {
        static WorkerHome _obj;
        
        string cs = ConfigurationManager.ConnectionStrings["dbcs"].ConnectionString;

        private string workerPhone;
        private string workerUsername;
        private string workerBalance;
        private string workerReview;
        private string workerReviewby;
        private string workerTotalJob;
        private string workerLocation;
        public static WorkerHome Instance4
        {
            get
            {
                if (_obj == null)
                {
                    _obj = new WorkerHome();
                }
                return _obj;
            }
        }

        public string WorkerUsername
        {
            set { this.workerUsername = value; this.label9.Text = value; }
            get { return this.workerUsername; }
        }

        

        public string WorkerBalance
        {
            set { this.workerBalance = value; this.label13.Text = value; }
            get { return this.workerBalance; }
        }

        public string WorkerLocation
        {
            set { this.workerLocation = value; this.label10.Text = value; }
            get { return this.workerLocation; }
        }

        public string WorkerReview
        {
            set { this.workerReview = value; this.label11.Text = value; }
            get { return this.workerReview; }
        }

        public string WorkerReviewby
        {
            set { this.workerReviewby = value; this.label12.Text = value; }
            get { return this.workerReviewby; }
        }

        public string WorkerPhone
        {
            set
            {
                string[] number = value.Split('w');
                this.workerPhone = number[0];
                this.label8.Text = number[0];
            }
            get { return this.workerPhone; }
        }

        public string WorkerTotaljob
        {
            set { this.workerTotalJob = value; this.label18.Text = value; }
            get { return this.workerTotalJob; }
        }

        public WorkerHome()
        {
            InitializeComponent();
        }

        private void WorkerHome_Load(object sender, EventArgs e)
        {
            _obj = this;
            viewHistory();
            this.label14.Text = Form2main.Instance2.Skill;
            
        }

        public void viewHistory()
        {
            List<string> userphone = new List<string>();
            List<string> userearn = new List<string>();
            List<string> userrating = new List<string>();

            SqlConnection con = new SqlConnection(cs);

            string query = "select * from book_worker where w_orker = @Phone and s_tatus = 'done'";
            SqlCommand cmd = new SqlCommand(query, con);
            cmd.Parameters.AddWithValue("@Phone", this.workerUsername);
            //cmd.Parameters.AddWithValue("@Pin", textBox2.Text);
            con.Open();
            SqlDataReader dr = cmd.ExecuteReader();

            if (dr.HasRows)
            {
                
                while (dr.Read())
                {
                    /*History h = new History();
                    h.UserPhone.Text = dr[1].ToString();
                    h.UserEarn.Text = dr[9].ToString();
                    h.UserReview.Text = dr[10].ToString();
                    h.Size = new System.Drawing.Size(340, 111);
                    this.flowLayoutPanel1.Controls.Add(h);*/
                    userearn.Add(dr[9].ToString());
                    userrating.Add(dr[10].ToString());
                    userphone.Add(dr[1].ToString());
                }
                this.flowLayoutPanel1.Controls.Clear();
                History[] h = new History[userphone.Count];
                for (int i = 0; i < h.Length; i++)
                {
                    h[i] = new History();
                    h[i].UserPhone.Text = "Username: "+userphone.ElementAt(i);
                    h[i].UserEarn.Text ="My Earnings: "+ userearn.ElementAt(i) + "TK";
                    h[i].UserReview.Text ="Rating: "+ userrating.ElementAt(i);
                    this.flowLayoutPanel1.Controls.Add(h[i]);
                }

            }
            else
            {
                //MessageBox.Show("Incorrect Phone or Pin.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);

            }
            con.Close();
        }

        private void groupBox2_Enter(object sender, EventArgs e)
        {

        }
    }
}
