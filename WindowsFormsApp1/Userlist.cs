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
    public partial class Userlist : UserControl
    {
        string cs = ConfigurationManager.ConnectionStrings["dbcs"].ConnectionString;

        public Userlist()
        {
            InitializeComponent();
        }

        #region Properties
        private string name;
        private string job;
        private string location;
        private string age;
        private string gender;
        private string userNumberofDB;
        private string totalJobdone;
        private int ratingNum;
        private int ratedBy;
        private int fees;
        private Image rating;
        private string assigned;
        private int index;
        
        [Category("Custom props")]
        public int Index
        {
            set { this.index = value; }
            get { return this.index; }
        }

        [Category("Custom props")]
        public PictureBox pn2
        {
            set { this.pictureBox2 = value; }
            get { return this.pictureBox2; }
        }

        [Category("Custom props")]
        public PictureBox pn1
        {
            set { this.pictureBox1 = value; }
            get { return this.pictureBox1; }
        }

        [Category("Custom props")]
        public Button btn1
        {
            set { this.button1 = value; }
            get { return this.button1; }
        }

        [Category("Custom props")]
        public Label lbl6
        {
            set { this.label6 = value; }
            get { return this.label6; }
        }

        [Category("Custom props")]
        public string Assigned
        {
            set { this.assigned = value; }
            get { return this.assigned; }
        }

        [Category("Custom props")]
        public string UserNumberofDB
        {
            set { this.userNumberofDB = value; }
            get { return this.userNumberofDB; }
        }

        [Category("Custom props")]
        public string UserTotalJobDone
        {
            set { this.totalJobdone = value; }
            get { return this.totalJobdone; }
        }

        [Category("Custom props")]
        public int UserRatingNum
        {
            set { this.ratingNum = value; }
            get { return this.ratingNum; }
        }

        [Category("Custom props")]
        public int UserRatedBy
        {
            set { this.ratedBy = value; }
            get { return this.ratedBy; }
        }

        [Category("Custom props")]
        public int UserFees
        {
            set { this.fees = value; }
            get { return this.fees; }
        }

        [Category("Custom props")]
        public string UserName
        {
            set { this.name = value; label1.Text = value; }
            get { return this.name; }
        }

        [Category("Custom props")]
        public Image UserRating
        {
            set { this.rating = value; pictureBox1.Image = value; }
            get { return this.rating; }
        }

        [Category("Custom props")]
        public string Gender
        {
            set { this.gender = value; label5.Text = value; }
            get { return this.gender; }
        }

        [Category("Custom props")]
        public string UserLocation
        {
            set { this.job = value; label2.Text = value; }
            get { return this.job; }
        }

        [Category("Custom props")]
        public string UserSkill
        {
            set { this.location = value; label3.Text = value; }
            get { return this.location; }
        }

        [Category("Custom props")]
        public string UserAge
        {
            set { this.age = value; label4.Text = value; }
            get { return age; }
        }
        #endregion

        private void Userlist_MouseEnter(object sender, EventArgs e)
        {
            this.BackColor = Color.Silver;
        }

        private void Userlist_MouseLeave(object sender, EventArgs e)
        {
            this.BackColor = Color.White;
        }

        private void label5_Click(object sender, EventArgs e)
        {

        }

        private void Userlist_MouseClick(object sender, MouseEventArgs e)
        {
            //MessageBox.Show(this.userNumberofDB);
        }

        private void Userlist_MouseDoubleClick(object sender, MouseEventArgs e)
        {
            if(lbl6.Visible == false)
            {
                WorkerProfileForBooking w = new WorkerProfileForBooking();
                w.WbPhone = this.userNumberofDB;
                w.WbName = this.name;
                w.WbSkill = this.location;
                w.WbLocation = this.job;
                w.WbGender = this.gender;
                w.WbAge = this.age;
                w.WbTotalJobsDone = this.totalJobdone;
                w.WbFees = this.fees;
                w.WbRatedBy = this.ratedBy;
                w.WbRate = this.ratingNum;
                w.RateImage = this.rating;
                if (assigned == "No")
                {
                    w.gbox2.Visible = true;
                    w.Lbl.Visible = false;
                }
                else
                {
                    w.gbox2.Visible = false;
                    w.Lbl.Visible = true;
                }
                Form2main.Instance2.f2mainpanel.Controls.Clear();
                Form2main.Instance2.f2mainpanel.Controls.Add(w);
            }
            

        }

        private void button1_Click(object sender, EventArgs e)
        {
            SqlConnection con = new SqlConnection(cs);

            string query = "delete from book_worker where consecutiveNumber = @number";
            SqlCommand cmd = new SqlCommand(query, con);
            cmd.Parameters.AddWithValue("@number", this.index);
            //cmd.Parameters.AddWithValue("@Pin", textBox2.Text);
            con.Open();
            int a = cmd.ExecuteNonQuery();
            if(a > 0)
            {
                MessageBox.Show("Operation Successful", "Success", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);

                List<string> WName = new List<string>();
                List<string> WLocatin = new List<string>();
                List<string> WGender = new List<string>();
                List<string> WSkill = new List<string>();
                List<string> Wage = new List<string>();
                List<string> Wstatus = new List<string>();
                List<int> index = new List<int>();
                List<System.Drawing.Bitmap> pn = new List<System.Drawing.Bitmap>();

                SqlConnection con2 = new SqlConnection(cs);

                string query2 = "select * from book_worker where u_ser = @User and (s_tatus = 'requested' or s_tatus = 'viewed' or s_tatus = 'post')";
                SqlCommand cmd2 = new SqlCommand(query2, con2);
                cmd2.Parameters.AddWithValue("@User", Form2main.Instance2.AccountPhoneDB);
                con2.Open();
                Form2main.Instance2.f2mainpanel.Controls.Clear();
                SqlDataReader dr2 = cmd2.ExecuteReader();
                if (dr2.HasRows)
                {
                    while (dr2.Read())
                    {
                        if (dr2[2].ToString() != "")
                        {
                            SqlConnection con22 = new SqlConnection(cs);
                            string query22 = "select * from w_orker where phone = @thisPhone";
                            SqlCommand cmd22 = new SqlCommand(query22, con22);
                            cmd22.Parameters.AddWithValue("@thisPhone", dr2[2].ToString());
                            con22.Open();
                            SqlDataReader dr22 = cmd22.ExecuteReader();
                            dr22.Read();

                            WName.Add(dr22[1].ToString());
                            WGender.Add(dr22[2].ToString());
                            WLocatin.Add(dr22[3].ToString());
                            WSkill.Add(dr22[5].ToString());
                            Wage.Add(dr22[8].ToString());
                            Wstatus.Add(dr2[4].ToString());
                            index.Add(int.Parse(dr2[0].ToString()));
                            pn.Add(Properties.Resources.Worker_96px);
                            con22.Close();
                        }
                        else
                        {
                            WName.Add("Job Post");
                            WGender.Add("Post Details:" + dr2[3].ToString());
                            WLocatin.Add("");
                            WSkill.Add("");
                            Wage.Add("");
                            pn.Add(Properties.Resources.icons8_news_96);
                            index.Add(int.Parse(dr2[0].ToString()));
                            Wstatus.Add(dr2[4].ToString());


                        }
                    }
                    con2.Close();

                }
                else
                {
                    MessageBox.Show("Nothing to show.", "Blank", MessageBoxButtons.OK, MessageBoxIcon.Information);

                }


                Form2main.Instance2.f2mainpanel.Controls.Clear();
                Userlist[] j = new Userlist[WName.Count()];

                for (int i = 0; i < j.Length; i++)
                {
                    j[i] = new Userlist();
                    j[i].lbl6.Visible = true;
                    j[i].lbl6.Text = "Status: " + Wstatus.ElementAt(i);
                    j[i].btn1.Visible = true;
                    j[i].Index = index.ElementAt(i);
                    j[i].UserName = WName.ElementAt(i);
                    j[i].UserAge = Wage.ElementAt(i);
                    j[i].UserLocation = WLocatin.ElementAt(i);
                    j[i].UserSkill = WSkill.ElementAt(i);
                    j[i].Gender = WGender.ElementAt(i);
                    j[i].pn1.Visible = false;
                    j[i].pn2.Image = pn.ElementAt(i);
                    Form2main.Instance2.f2mainpanel.Controls.Add(j[i]);
                }
            }
            else
            {
                MessageBox.Show("Something went wrong.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);

            }
        }
    }
}
