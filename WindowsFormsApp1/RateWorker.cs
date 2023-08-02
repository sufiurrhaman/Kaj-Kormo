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
    public partial class RateWorker : Form
    {
        string cs = ConfigurationManager.ConnectionStrings["dbcs"].ConnectionString;

        private int workerRate;
        private int workerRatedby;
        private string username;

        public int WorkerRate
        {
            set { this.workerRate = value; this.numericUpDown1.Value = value; }
            get { return this.workerRate; }
        }

        public int WorkerRatedby
        {
            set { this.workerRatedby = value; }
            get { return this.workerRatedby; }
        }

        public string UserName
        {
            set { this.username = value; }
            get { return this.username; }
        }

        public RateWorker()
        {
            InitializeComponent();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            this.Dispose();
        }

        private void button4_Click(object sender, EventArgs e)
        {
            this.Dispose();
        }

        private void button3_Click(object sender, EventArgs e)
        {
           // int index = int.Parse(dr3[0].ToString());

            /*double r = (this.workerRate * this.workerRatedby) + int.Parse(numericUpDown1.Value.ToString());
            r = r / (this.workerRatedby + 1);
            string rr = r.ToString("F1");
            string[] rrr = rr.Split('.');
            if (int.Parse(rrr[1]) >= 5)
            {
                r = int.Parse(rrr[0]) + 1;
            }
            else
            {
                r = int.Parse(rrr[0]);
            }
            MessageBox.Show(r.ToString());*/
            
            SqlConnection con3 = new SqlConnection(cs);

            string query3 = "select * from book_worker where (s_tatus = 'done' or s_tatus = 'processing' or s_tatus = 'payment') and w_orker = @Worker and u_ser = @User and review is null";
            SqlCommand cmd3 = new SqlCommand(query3, con3);
            cmd3.Parameters.AddWithValue("@User",Form2main.Instance2.AccountPhoneDB);
            cmd3.Parameters.AddWithValue("@Worker", this.username);
            //cmd3.Parameters.AddWithValue("@Number", this.workerRatedby + 1);
            con3.Open();
            SqlDataReader dr3 = cmd3.ExecuteReader();
            if(dr3.HasRows)
            {
                dr3.Read();
                int index = int.Parse(dr3[0].ToString());

                double r = (this.workerRate * this.workerRatedby) + int.Parse(numericUpDown1.Value.ToString());
                r = r / (this.workerRatedby + 1);
                string rr = r.ToString("F1");
                string[] rrr = rr.Split('.');
                if (int.Parse(rrr[1]) >= 5)
                {
                    r = int.Parse(rrr[0]) + 1;
                }
                else
                {
                    r = int.Parse(rrr[0]);
                }
                MessageBox.Show(r.ToString());
                SqlConnection con = new SqlConnection(cs);

                string query = "update w_orker set review = @Review, reviewNumber = @Number where phone = @Phone";
                SqlCommand cmd = new SqlCommand(query, con);
                cmd.Parameters.AddWithValue("@Phone", this.username);
                cmd.Parameters.AddWithValue("@Review", r);
                cmd.Parameters.AddWithValue("@Number", this.workerRatedby + 1);

                con.Open();
                int a = cmd.ExecuteNonQuery();
                con.Close();
                if (a > 0)
                {
                    MessageBox.Show("Thank you for your response.", "Success", MessageBoxButtons.OK, MessageBoxIcon.Information);
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
                    con2.Close();


                    SqlConnection con4 = new SqlConnection(cs);
                    string query4 = "update book_worker set review = @Review where consecutiveNumber = @Number";
                    SqlCommand cmd4 = new SqlCommand(query4, con4);
                    cmd4.Parameters.AddWithValue("@Number", index);
                    cmd4.Parameters.AddWithValue("@Review", this.numericUpDown1.Value);

                    con4.Open();
                    cmd4.ExecuteNonQuery();
                    con4.Close();
                }
                else
                {
                    MessageBox.Show("Something went wrong.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);

                }
            }
            else
            {
                MessageBox.Show("You have already rated the user.", "Information", MessageBoxButtons.OK, MessageBoxIcon.Information);

            }
            con3.Close();
            
        }
            
    }
}
