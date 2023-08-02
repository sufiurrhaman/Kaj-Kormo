
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
    public partial class Form2main : Form
    {
        static Form2main _obj;
        string cs = ConfigurationManager.ConnectionStrings["dbcs"].ConnectionString;
        private string accountPhoneDB;
        private string accBalance;
        private string balance;
        private string skill;
        /*
        public List<String> WorkerName = new List<string>();
        public List<String> WorkerLocatin = new List<string>();
        public List<String> WorkerSkill = new List<string>();
        public List<String> WorkerGender = new List<string>();
        public List<int> WorkerNumber = new List<int>();
        public List<int> WorkerAge = new List<int>();
        */
        public static Form2main Instance2
        {
            get
            {
                if (_obj == null)
                {
                    _obj = new Form2main();
                }
                return _obj;
            }
        }

        public string Skill
        {
            set { this.skill = value; }
            get { return this.skill; }
        }

        public PictureBox pb4
        {
            set { this.pictureBox4 = value; }
            get { return this.pictureBox4; }
        }

        public string AccBalance
        {
            set { this.balance = value; }
            get { return this.balance; }
        }

        public string AccButtonName
        {
            set { this.accBalance = value; this.button2.Text = value; }
            get { return this.accBalance; }
        }

        public LinkLabel MyAc
        {
            set { this.linkLabel1 = value; }
            get { return this.linkLabel1; }
        }

        public string AccountPhoneDB
        {
            set { this.accountPhoneDB = value; }
            get { return this.accountPhoneDB; }
        }

        public Label AccountUserName
        {
            set { this.label2.Text = value.Text; }
            get { return this.label2; }
        }

        public FlowLayoutPanel f2mainpanel
        {
            set { flowLayoutPanel1 = value; }
            get { return flowLayoutPanel1; }
        }

        public Button Homebutton
        {
            set { button1 = value; }
            get { return button1; }
        }

        public Button Workersbutton
        {
            set { button2 = value; }
            get { return button2; }
        }

        public Button Assignedbuttom
        {
            set { button3 = value; }
            get { return button3; }
        }

        public Button Walletbutton
        {
            set { button4 = value; }
            get { return button4; }
        }

        public Button sentJob
        {
            set { button5 = value; }
            get { return button5; }
        }

        public Form2main()
        {
            InitializeComponent();
        }

        protected override void OnFormClosing(FormClosingEventArgs e)
        {
            //base.OnFormClosing(e);
            Application.Exit();
        }


        private void textBox1_Enter(object sender, EventArgs e)
        {
            textBox1.Text = null;
        }

        private void Form2main_Load(object sender, EventArgs e)
        {
            _obj = this;
            if(this.accountPhoneDB[11] == 'u')
            {
                Homepage h = new Homepage();
                flowLayoutPanel1.Controls.Add(h);
                getNotification();
            }
            else
            {
                //SqlConnection con = new SqlConnection(cs);

                //string query = "select * from w_orker where phone = @Phone";
                //SqlCommand cmd = new SqlCommand(query, con);
                //cmd.Parameters.AddWithValue("@Phone", accountPhoneDB);
                ////cmd.Parameters.AddWithValue("@Pin", textBox2.Text);
                //con.Open();
                //SqlDataReader dr = cmd.ExecuteReader();

                //if (dr.HasRows)
                //{
                //    dr.Read();
                //    WorkerHome w = new WorkerHome();
                //    w.WorkerPhone = dr[0].ToString();
                //    w.WorkerUsername = dr[0].ToString();
                //    w.WorkerLocation = dr[3].ToString();
                //    w.WorkerBalance = dr[6].ToString();
                //    w.WorkerReview = dr[11].ToString();
                //    w.WorkerReviewby = dr[12].ToString();
                //    w.WorkerTotaljob = dr[10].ToString();
                //    flowLayoutPanel1.Controls.Add(w);
                //    //MessageBox.Show( dr[1].ToString(), "Success", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                //}
                //else
                //{
                //    MessageBox.Show("Something went wrong.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);

                //}
                //con.Close();
                viewWorker();
            }
            
        }

        private void getNotification()
        {
            SqlConnection con = new SqlConnection(cs);

            string query = "select * from book_worker where s_tatus = 'cancel' and u_ser = @Phone";
            SqlCommand cmd = new SqlCommand(query, con);
            cmd.Parameters.AddWithValue("@Phone", accountPhoneDB);
            //cmd.Parameters.AddWithValue("@Pin", textBox2.Text);
            con.Open();
            SqlDataReader dr = cmd.ExecuteReader();
            if (dr.HasRows)
            {
                pictureBox4.Image = Properties.Resources.icons8_alarm_48;

            }
            else
            {
                pictureBox4.Image = Properties.Resources.icons8_bell_48;
            }
        }

        public void viewWorker()
        {
            SqlConnection con = new SqlConnection(cs);

            string query = "select * from w_orker where phone = @Phone";
            SqlCommand cmd = new SqlCommand(query, con);
            cmd.Parameters.AddWithValue("@Phone", accountPhoneDB);
            //cmd.Parameters.AddWithValue("@Pin", textBox2.Text);
            con.Open();
            SqlDataReader dr = cmd.ExecuteReader();
            flowLayoutPanel1.Controls.Clear();
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
                flowLayoutPanel1.Controls.Add(w);
                //MessageBox.Show( dr[1].ToString(), "Success", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
            }
            else
            {
                MessageBox.Show("Something went wrong.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);

            }
            con.Close();
        }

        private void button2_Click(object sender, EventArgs e)
        {
            if(this.accountPhoneDB[11] == 'u')
            {
                pupulateitems();
            }
            else
            {
                populateUser();
            }
            
        }

        private void populateUser()
        {
            List<string> userName = new List<string>();
            List<string> userLocatin = new List<string>();
            List<string> userTime = new List<string>();
            List<string> userCost = new List<string>();
            List<string> userDate = new List<string>();
            List<string> userMessage = new List<string>();
            List<string> userPhone = new List<string>();
            List<string> catagory = new List<string>();


            SqlConnection con = new SqlConnection(cs);
            
            string query = "select * from book_worker where w_orker = @worker and (s_tatus = 'requested' or s_tatus = 'viewed')";
            SqlCommand cmd = new SqlCommand(query, con);
            cmd.Parameters.AddWithValue("@worker", this.accountPhoneDB);
            con.Open();
            flowLayoutPanel1.Controls.Clear();
            SqlDataReader dr = cmd.ExecuteReader();
            if (dr.HasRows)
            {
                while (dr.Read())
                {
                    SqlConnection con2 = new SqlConnection(cs);
                    string query2 = "select * from u_ser where phone = @thisPhone";
                    SqlCommand cmd2 = new SqlCommand(query2, con2);
                    cmd2.Parameters.AddWithValue("@thisPhone", dr[1].ToString());
                    con2.Open();
                    SqlDataReader dr2 = cmd2.ExecuteReader();
                    dr2.Read();

                    userName.Add(dr2[1].ToString());
                    userLocatin.Add(dr2[3].ToString());
                    userPhone.Add(dr[1].ToString());
                    userCost.Add(dr[7].ToString());
                    userTime.Add(dr[6].ToString());
                    userDate.Add(dr[5].ToString());
                    userMessage.Add(dr[3].ToString());
                    catagory.Add(dr[11].ToString());

                    con2.Close();
                }
                con.Close();

                SqlConnection con3 = new SqlConnection(cs);
                string query3 = "update book_worker set s_tatus = 'viewed' where w_orker = @worker and s_tatus = 'requested'";
                SqlCommand cmd3 = new SqlCommand(query3, con3);
                cmd3.Parameters.AddWithValue("@worker", this.accountPhoneDB);
                con3.Open();
                cmd3.ExecuteNonQuery();
                con3.Close();
            }
            else
            {
                MessageBox.Show("Nothing to show.", "Blank", MessageBoxButtons.OK, MessageBoxIcon.Information);

            }


            flowLayoutPanel1.Controls.Clear();
            JobOffer[] j = new JobOffer[userName.Count()];

            for (int i = 0; i < j.Length; i++)
            {
                j[i] = new JobOffer();
                j[i].UserPhoneDB = userPhone.ElementAt(i);
                j[i].UserLocation = userLocatin.ElementAt(i);
                j[i].UserCost = userCost.ElementAt(i);
                j[i].UserTime = userTime.ElementAt(i);
                j[i].UserDate = userDate.ElementAt(i);
                j[i].UserMessage = userMessage.ElementAt(i);
                j[i].UserName = userName.ElementAt(i);
                j[i].Catagory = catagory.ElementAt(i);

                flowLayoutPanel1.Controls.Add(j[i]);
            }
            
            //SqlConnection con3 = new SqlConnection(cs);
            //string query3 = "update book_worker set s_tatus = 'viewed' where w_orker = @worker";
            //SqlCommand cmd3 = new SqlCommand(query3, con3);
            //cmd3.Parameters.AddWithValue("@worker", this.accountPhoneDB);
            //con3.Open();
            //cmd3.ExecuteNonQuery();
            //con3.Close();
            
        }

        private void pupulateitems()
        {
            List<string> WorkerName = new List<string>();
            List<string> WorkerLocatin = new List<string>();
            List<string> WorkerSkill = new List<string>();
            List<string> WorkerGender = new List<string>();
            List<string> WorkerNumber = new List<string>();
            List<string> assigned = new List<string>();
            List<string> WorkerTotalJobDone = new List<string>();
            List<int> WorkerFees = new List<int>();
            List<int> WorkerRatedby = new List<int>();
            List<int> WorkerAge = new List<int>();
            List<int> WorkerRating = new List<int>();

            SqlConnection con = new SqlConnection(cs);
            string query = "select * from w_orker";
            SqlCommand cmd = new SqlCommand(query, con);
            //cmd.Parameters.AddWithValue("@Phone", textBox1.Text);
            //cmd.Parameters.AddWithValue("@Pin", textBox2.Text);
            con.Open();
            SqlDataReader dr = cmd.ExecuteReader();

            /*while (dr.HasRows)
            {
                
                Form2main m = new Form2main();
                m.StartPosition = FormStartPosition.CenterScreen;
                m.Visible = true;
                Form1.Instance.Visible = false;
                dr.Read();
                MessageBox.Show(dr[1].ToString(), "Success", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                
            }
            */
            //int i = 0;
            //Userlist[] userlist = new Userlist[20];
            
            //flowLayoutPanel1.Controls.Clear();
            while (dr.Read() )
            {
                /*
                MessageBox.Show(dr[1].ToString());
                userlist[i] = new Userlist();
                userlist[i].UserName = dr[1].ToString();
                userlist[i].UserLocation = dr[3].ToString();
                userlist[i].UserSkill = dr[5].ToString();
                userlist[i].UserAge = dr[8].ToString();

                flowLayoutPanel1.Controls.Add(userlist[i]);
                i++;*/
                WorkerName.Add(dr[1].ToString());
                WorkerNumber.Add(dr[0].ToString());
                WorkerLocatin.Add(dr[3].ToString());
                WorkerSkill.Add(dr[5].ToString());
                WorkerAge.Add(int.Parse(dr[8].ToString()));
                WorkerGender.Add(dr[2].ToString());
                WorkerRating.Add(int.Parse(dr[11].ToString()));
                WorkerTotalJobDone.Add(dr[10].ToString());
                WorkerFees.Add(int.Parse(dr[7].ToString()));
                WorkerRatedby.Add(int.Parse(dr[12].ToString()));
                assigned.Add(dr[9].ToString());

            }
            con.Close();
            flowLayoutPanel1.Controls.Clear();
            Userlist[] userlist = new Userlist[WorkerName.Count()];
            
            for (int i = 0; i < userlist.Length; i++)
            {
                userlist[i] = new Userlist();
                userlist[i].UserName = WorkerName.ElementAt(i);
                userlist[i].UserLocation = WorkerLocatin.ElementAt(i);
                userlist[i].UserSkill = WorkerSkill.ElementAt(i);
                userlist[i].UserAge = WorkerAge.ElementAt(i).ToString();
                userlist[i].Gender = WorkerGender.ElementAt(i).ToString();
                userlist[i].UserNumberofDB = WorkerNumber.ElementAt(i);
                userlist[i].UserRatingNum = WorkerRating.ElementAt(i);
                userlist[i].UserRatedBy = WorkerRatedby.ElementAt(i);
                userlist[i].UserTotalJobDone = WorkerTotalJobDone.ElementAt(i);
                userlist[i].UserFees = WorkerFees.ElementAt(i);
                userlist[i].Assigned = assigned.ElementAt(i);

                if(WorkerRating.ElementAt(i) == 0)
                {
                    userlist[i].UserRating = Properties.Resources._0star;
                }
                else if (WorkerRating.ElementAt(i) == 1)
                {
                    userlist[i].UserRating = Properties.Resources._1star;
                }
                else if (WorkerRating.ElementAt(i) == 2)
                {
                    userlist[i].UserRating = Properties.Resources._2star;
                }
                else if (WorkerRating.ElementAt(i) == 3)
                {
                    userlist[i].UserRating = Properties.Resources._3star;
                }
                else if (WorkerRating.ElementAt(i) == 4)
                {
                    userlist[i].UserRating = Properties.Resources._5star;
                }
                else if (WorkerRating.ElementAt(i) == 5)
                {
                    userlist[i].UserRating = Properties.Resources._5star;
                }
                /*else
                {
                    userlist[i].UserRating = Properties.Resources._0star;
                }*/
                flowLayoutPanel1.Controls.Add(userlist[i]);
            }
            
        }

        private void button1_Click(object sender, EventArgs e)
        {
            if(accountPhoneDB[11] == 'u')
            {
                flowLayoutPanel1.Controls.Clear();
                Homepage h = new Homepage();
                flowLayoutPanel1.Controls.Add(h);
            }
            else
            {
                viewWorker();
            }
            
        }

        private void label1_Click(object sender, EventArgs e)
        {

        }

        private void linkLabel1_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
        {
            if(this.accountPhoneDB[11] == 'u')
            {
                UserAccountProfile u = new UserAccountProfile();
                flowLayoutPanel1.Controls.Clear();
                flowLayoutPanel1.Controls.Add(u);


                this.MyAccount();
            }
            else
            {
                WorkerAccountProfile w = new WorkerAccountProfile();
                flowLayoutPanel1.Controls.Clear();
                flowLayoutPanel1.Controls.Add(w);

                this.MyAccount();
            }
            
            
        }

        public void MyAccount()
        {
            if (AccountPhoneDB[11] == 'u')
            {
                SqlConnection con = new SqlConnection(cs);
                string query = "select * from u_ser where phone = @Phone";
                SqlCommand cmd = new SqlCommand(query, con);
                cmd.Parameters.AddWithValue("@Phone", this.AccountPhoneDB);
                con.Open();
                SqlDataReader dr = cmd.ExecuteReader();

                if (dr.HasRows)
                {
                    dr.Read();

                    UserAccountProfile u = new UserAccountProfile();
                    u.AccountName = dr[1].ToString();
                    u.UserPhone = dr[0].ToString();
                    u.UserName = dr[0].ToString();
                    u.UserLocation = dr[3].ToString();
                    u.UserPin = int.Parse(dr[4].ToString());
                    u.UserOrders = int.Parse(dr[5].ToString());
                    u.UserBalance = int.Parse(dr[6].ToString());
                    u.UserGender = dr[2].ToString();
                    flowLayoutPanel1.Controls.Clear();
                    flowLayoutPanel1.Controls.Add(u);

                    //Form2main m = new Form2main();
                    //m.AccountUserName.Text = dr[1].ToString();
                    //m.StartPosition = FormStartPosition.CenterScreen;
                    //m.Visible = true;
                    //Form1.Instance.Visible = false;

                    //MessageBox.Show( dr[1].ToString(), "Success", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                }
                else
                {
                    MessageBox.Show("Something went wrong.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);

                }
                con.Close();
            }
            else
            {
                SqlConnection con = new SqlConnection(cs);
                string query = "select * from w_orker where phone = @Phone";
                SqlCommand cmd = new SqlCommand(query, con);
                cmd.Parameters.AddWithValue("@Phone", this.AccountPhoneDB);
                con.Open();
                SqlDataReader dr = cmd.ExecuteReader();

                if (dr.HasRows)
                {
                    dr.Read();

                    WorkerAccountProfile u = new WorkerAccountProfile();
                    u.AccountName = dr[1].ToString();
                    u.UserPhone = dr[0].ToString();
                    u.UserName = dr[0].ToString();
                    u.UserLocation = dr[3].ToString();
                    u.UserPin = int.Parse(dr[4].ToString());
                    u.UserOrders = int.Parse(dr[10].ToString());
                    u.UserBalance = int.Parse(dr[6].ToString());
                    u.UserGender = dr[2].ToString();
                    u.UserFees = dr[7].ToString();
                    u.UserSkill = dr[5].ToString();
                    u.UserAge = dr[8].ToString();
                    flowLayoutPanel1.Controls.Clear();
                    flowLayoutPanel1.Controls.Add(u);

                    //Form2main m = new Form2main();
                    //m.AccountUserName.Text = dr[1].ToString();
                    //m.StartPosition = FormStartPosition.CenterScreen;
                    //m.Visible = true;
                    //Form1.Instance.Visible = false;

                    //MessageBox.Show( dr[1].ToString(), "Success", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                }
                else
                {
                    MessageBox.Show("Something went wrong.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);

                }
                con.Close();
            }
        }

        private void label3_MouseEnter(object sender, EventArgs e)
        {
            //this.label3.Font = new System.Drawing.Font("Arial Rounded MT Bold", 13.8F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));

        }

        private void button4_Click(object sender, EventArgs e)
        {
            if (AccountPhoneDB[11] == 'u')
            {
                SqlConnection con = new SqlConnection(cs);
                string query = "select * from u_ser where phone = @Phone";
                SqlCommand cmd = new SqlCommand(query, con);
                cmd.Parameters.AddWithValue("@Phone", this.AccountPhoneDB);
                con.Open();
                SqlDataReader dr = cmd.ExecuteReader();

                if (dr.HasRows)
                {
                    dr.Read();

                    Wallet w = new Wallet();
                    w.AccBalancr = int.Parse(dr[6].ToString());
                    w.UserName = this.accountPhoneDB;
                    w.AccNumber = this.accountPhoneDB;
                    w.GB.Location = new System.Drawing.Point(241, 23);
                    this.flowLayoutPanel1.Controls.Clear();
                    this.flowLayoutPanel1.Controls.Add(w);

                    
                }
                else
                {
                    MessageBox.Show("Something went wrong.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);

                }
                con.Close();
            }
            else
            {
                SqlConnection con = new SqlConnection(cs);
                string query = "select * from w_orker where phone = @Phone";
                SqlCommand cmd = new SqlCommand(query, con);
                cmd.Parameters.AddWithValue("@Phone", this.AccountPhoneDB);
                con.Open();
                SqlDataReader dr = cmd.ExecuteReader();

                if (dr.HasRows)
                {
                    dr.Read();

                    Wallet w = new Wallet();
                    w.AccBalancr = int.Parse(dr[6].ToString());
                    w.UserName = this.accountPhoneDB;
                    w.AccNumber = this.accountPhoneDB;
                    w.GB.Location = new System.Drawing.Point(241, 23);
                    this.flowLayoutPanel1.Controls.Clear();
                    this.flowLayoutPanel1.Controls.Add(w);

                }
                else
                {
                    MessageBox.Show("Something went wrong.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);

                }
                con.Close();
            }
            
        }


        private void button3_Click(object sender, EventArgs e)
        {
            
            
            if(this.AccountPhoneDB[11] == 'u')
            {
                SqlConnection con = new SqlConnection(cs);
                string query = "select * from book_worker where u_ser  = @Phone and s_tatus = 'processing' or s_tatus = 'payment'";
                SqlCommand cmd = new SqlCommand(query, con);
                cmd.Parameters.AddWithValue("@Phone", this.AccountPhoneDB);
                con.Open();
                SqlDataReader dr = cmd.ExecuteReader();
                flowLayoutPanel1.Controls.Clear();
                if (dr.HasRows)
                {
                    while (dr.Read())
                    {
                        SqlConnection con2 = new SqlConnection(cs);
                        string query2 = "select * from w_orker where phone = @thisPhone";
                        SqlCommand cmd2 = new SqlCommand(query2, con2);
                        cmd2.Parameters.AddWithValue("@thisPhone", dr[2].ToString());
                        con2.Open();
                        SqlDataReader dr2 = cmd2.ExecuteReader();
                        dr2.Read();

                        Assigned a = new Assigned();
                        a.LoginUsername = AccountPhoneDB;
                        a.WNote = dr[3].ToString();
                        a.WTime = dr[6].ToString();
                        a.WFees = dr[7].ToString();
                        a.WPhone = dr[2].ToString();
                        a.WDate = dr[5].ToString();
                        a.WName = dr2[1].ToString();
                        a.WBalance = dr2[6].ToString();
                        a.Wid = dr[0].ToString();
                        if (dr[4].ToString() == "payment")
                        {
                            //a.b1.Visible = false;
                            a.g1.Visible = false;
                        }
                        else
                        {
                            //a.b1.Visible = true;
                            a.g1.Visible = true;
                        }
                        
                        flowLayoutPanel1.Controls.Add(a);
                        con2.Close();
                    }
                }
                else
                {
                    MessageBox.Show("Nothing to show.", "Blank", MessageBoxButtons.OK, MessageBoxIcon.Information);

                }
                con.Close();
            }
            else
            {
                SqlConnection con = new SqlConnection(cs);
                string query = "select * from book_worker where w_orker  = @Phone and (s_tatus = 'processing' or s_tatus = 'payment')";
                SqlCommand cmd = new SqlCommand(query, con);
                cmd.Parameters.AddWithValue("@Phone", this.AccountPhoneDB);
                con.Open();
                SqlDataReader dr = cmd.ExecuteReader();
                if (dr.HasRows)
                {
                    while (dr.Read())
                    {
                        SqlConnection con2 = new SqlConnection(cs);
                        string query2 = "select * from u_ser where phone = @thisPhone";
                        SqlCommand cmd2 = new SqlCommand(query2, con2);
                        cmd2.Parameters.AddWithValue("@thisPhone", dr[1].ToString());
                        con2.Open();
                        SqlDataReader dr2 = cmd2.ExecuteReader();
                        dr2.Read();

                        AssignedForWorker a = new AssignedForWorker();
                        a.LoginUsername = AccountPhoneDB;
                        a.WNote = dr[3].ToString();
                        a.WTime = dr[6].ToString();
                        a.WFees = dr[7].ToString();
                        a.WPhone = dr[1].ToString();
                        a.WDate = dr[5].ToString();
                        a.WName = dr2[1].ToString();
                        a.WLocation = dr2[3].ToString();
                        a.Wid = dr[0].ToString();
                        a.FinalFees = dr[9].ToString();
                        a.FinalTime = dr[8].ToString();
                        
                        if(dr[4].ToString() == "payment")
                        {
                            //a.b1.Visible = false;
                            a.g1.Visible = true;
                        }
                        else
                        {
                            //a.b1.Visible = true;
                            a.g1.Visible = false;
                        }
                        flowLayoutPanel1.Controls.Clear();
                        flowLayoutPanel1.Controls.Add(a);
                        con2.Close();
                    }
                }
                else
                {
                    MessageBox.Show("Nothing to show.", "Blank", MessageBoxButtons.OK, MessageBoxIcon.Information);

                }
                con.Close();
            }
        }

        private void button6_Click(object sender, EventArgs e)
        {
            Form1 f = new Form1();
            f.Visible = true;
            this.Dispose();
        }

        private void button5_Click(object sender, EventArgs e)
        {
            if (this.accountPhoneDB[11] == 'u')
            {
                List<string> WName = new List<string>();
                List<string> WLocatin = new List<string>();
                List<string> WGender = new List<string>();
                List<string> WSkill = new List<string>();
                List<string> Wage = new List<string>();
                List<string> Wstatus = new List<string>();
                List<int> index = new List<int>();
                List<System.Drawing.Bitmap> pn = new List<System.Drawing.Bitmap>();

                SqlConnection con = new SqlConnection(cs);

                string query = "select * from book_worker where u_ser = @User and (s_tatus = 'requested' or s_tatus = 'viewed' or s_tatus = 'post')";
                SqlCommand cmd = new SqlCommand(query, con);
                cmd.Parameters.AddWithValue("@User", this.accountPhoneDB);
                con.Open();
                flowLayoutPanel1.Controls.Clear();
                SqlDataReader dr = cmd.ExecuteReader();
                if (dr.HasRows)
                {
                    while (dr.Read())
                    {
                        if(dr[2].ToString() != "")
                        {
                            SqlConnection con2 = new SqlConnection(cs);
                            string query2 = "select * from w_orker where phone = @thisPhone";
                            SqlCommand cmd2 = new SqlCommand(query2, con2);
                            cmd2.Parameters.AddWithValue("@thisPhone", dr[2].ToString());
                            con2.Open();
                            SqlDataReader dr2 = cmd2.ExecuteReader();
                            dr2.Read();

                            WName.Add(dr2[1].ToString());
                            WGender.Add(dr2[2].ToString());
                            WLocatin.Add(dr2[3].ToString());
                            WSkill.Add(dr2[5].ToString());
                            Wage.Add(dr2[8].ToString());
                            Wstatus.Add(dr[4].ToString());
                            index.Add(int.Parse(dr[0].ToString()));
                            pn.Add(Properties.Resources.Worker_96px);
                            con2.Close();
                        }
                        else
                        {
                            WName.Add("Job Post");
                            WGender.Add("Post Details:"+dr[3].ToString());
                            WLocatin.Add("");
                            WSkill.Add("");
                            Wage.Add("");
                            pn.Add(Properties.Resources.icons8_news_96);
                            index.Add(int.Parse(dr[0].ToString()));
                            Wstatus.Add(dr[4].ToString());


                        }
                    }
                    con.Close();

                }
                else
                {
                    MessageBox.Show("Nothing to show.", "Blank", MessageBoxButtons.OK, MessageBoxIcon.Information);

                }


                flowLayoutPanel1.Controls.Clear();
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
                    flowLayoutPanel1.Controls.Add(j[i]);
                }
            }
            else
            {
                List<string> userName = new List<string>();
                List<string> userLocatin = new List<string>();
                List<string> userTime = new List<string>();
                List<string> userCost = new List<string>();
                List<string> userDate = new List<string>();
                List<string> userMessage = new List<string>();
                List<string> userPhone = new List<string>();
                List<string> catagory = new List<string>();


                SqlConnection con = new SqlConnection(cs);

                string query = "select * from book_worker where catagory =@Catagory and s_tatus = 'post'";
                SqlCommand cmd = new SqlCommand(query, con);
                cmd.Parameters.AddWithValue("@Catagory", this.skill);

                con.Open();
                flowLayoutPanel1.Controls.Clear();
                SqlDataReader dr = cmd.ExecuteReader();
                if (dr.HasRows)
                {
                    while (dr.Read())
                    {
                        SqlConnection con2 = new SqlConnection(cs);
                        string query2 = "select * from u_ser where phone = @thisPhone";
                        SqlCommand cmd2 = new SqlCommand(query2, con2);
                        cmd2.Parameters.AddWithValue("@thisPhone", dr[1].ToString());
                        con2.Open();
                        SqlDataReader dr2 = cmd2.ExecuteReader();
                        dr2.Read();

                        userName.Add(dr2[1].ToString());
                        userLocatin.Add(dr2[3].ToString());
                        userPhone.Add(dr[1].ToString());
                        userCost.Add(dr[7].ToString());
                        userTime.Add(dr[6].ToString());
                        userDate.Add(dr[5].ToString());
                        userMessage.Add(dr[3].ToString());
                        catagory.Add(dr[10].ToString());

                        con2.Close();
                    }
                    con.Close();

                    /*SqlConnection con3 = new SqlConnection(cs);
                    string query3 = "update book_worker set s_tatus = 'viewed' where w_orker = @worker and s_tatus = 'requested'";
                    SqlCommand cmd3 = new SqlCommand(query3, con3);
                    cmd3.Parameters.AddWithValue("@worker", this.accountPhoneDB);
                    con3.Open();
                    cmd3.ExecuteNonQuery();
                    con3.Close();*/
                }
                else
                {
                    MessageBox.Show("Nothing to show.", "Blank", MessageBoxButtons.OK, MessageBoxIcon.Information);

                }

                flowLayoutPanel1.Controls.Clear();
                JobOffer[] j = new JobOffer[userName.Count()];

                for (int i = 0; i < j.Length; i++)
                {
                    j[i] = new JobOffer();
                    j[i].UserPhoneDB = userPhone.ElementAt(i);
                    j[i].UserLocation = userLocatin.ElementAt(i);
                    j[i].UserCost = userCost.ElementAt(i);
                    j[i].UserTime = userTime.ElementAt(i);
                    j[i].UserDate = userDate.ElementAt(i);
                    j[i].UserMessage = userMessage.ElementAt(i);
                    j[i].UserName = userName.ElementAt(i);
                    j[i].Catagory = catagory.ElementAt(i);

                    flowLayoutPanel1.Controls.Add(j[i]);
                }

                //SqlConnection con3 = new SqlConnection(cs);
                //string query3 = "update book_worker set s_tatus = 'viewed' where w_orker = @worker";
                //SqlCommand cmd3 = new SqlCommand(query3, con3);
                //cmd3.Parameters.AddWithValue("@worker", this.accountPhoneDB);
                //con3.Open();
                //cmd3.ExecuteNonQuery();
                //con3.Close();

            }
        }

        private void pictureBox2_Click(object sender, EventArgs e)
        {
            string s = "";
            for (int i = 0; i < 3; i++)
            {
                s = s + textBox1.Text[i];
            }
            
            if(s.ToLower() == "lif")
            {
                string query = "select * from w_orker where skill = 'Lift engineer'";
                pupulateitems2(query);
                textBox1.Text = "Lift Engineer";
            }
            else if (s.ToLower() == "van")
            {
                string query = "select * from w_orker where skill = 'Van puller'";
                pupulateitems2(query);
                textBox1.Text = "Van Puller";

            }
            else if (s.ToLower() == "ele")
            {
                string query = "select * from w_orker where skill = 'Electrician'";
                pupulateitems2(query);
                textBox1.Text = "Electrician";
            }
            else if (s.ToLower() == "arc")
            {
                string query = "select * from w_orker where skill = 'Architect'";
                pupulateitems2(query);
                textBox1.Text = "Architect";
            }
            else if (s.ToLower() == "plu")
            {
                string query = "select * from w_orker where skill = 'Plumber'";
                pupulateitems2(query);
                textBox1.Text = "Plumber";
            }
            else if (s.ToLower() == "was")
            {
                string query = "select * from w_orker where skill = 'Waste cleaner'";
                pupulateitems2(query);
                textBox1.Text = "Waste cleaner";
            }
            else if (s.ToLower() == "swi")
            {
                string query = "select * from w_orker where skill = 'Swiper'";
                pupulateitems2(query);
                textBox1.Text = "Swiper";
            }
            else if (s.ToLower() == "loc")
            {
                string query = "select * from w_orker where skill = 'Lock fixer'";
                pupulateitems2(query);
                textBox1.Text = "Lock fixer";
            }
            else if (s.ToLower() == "gas")
            {
                string query = "select * from w_orker where skill = 'Gas mechanic'";
                pupulateitems2(query);
                textBox1.Text = "Gas mechanic";
            }
            else if (s.ToLower() == "lab")
            {
                string query = "select * from w_orker where skill = 'labour'";
                pupulateitems2(query);
                textBox1.Text = "labour";
            }



        }

        private void pupulateitems2(string query)
        {
            List<string> WorkerName = new List<string>();
            List<string> WorkerLocatin = new List<string>();
            List<string> WorkerSkill = new List<string>();
            List<string> WorkerGender = new List<string>();
            List<string> WorkerNumber = new List<string>();
            List<string> WorkerTotalJobDone = new List<string>();
            List<int> WorkerFees = new List<int>();
            List<int> WorkerRatedby = new List<int>();
            List<int> WorkerAge = new List<int>();
            List<int> WorkerRating = new List<int>();
            List<string> assigned = new List<string>();


            SqlConnection con = new SqlConnection(cs);


            SqlCommand cmd = new SqlCommand(query, con);
            //cmd.Parameters.AddWithValue("@P", textBox1.Text);
            //cmd.Parameters.AddWithValue("@Pin", textBox2.Text);
            con.Open();
            SqlDataReader dr = cmd.ExecuteReader();

            /*while (dr.HasRows)
            {
                
                Form2main m = new Form2main();
                m.StartPosition = FormStartPosition.CenterScreen;
                m.Visible = true;
                Form1.Instance.Visible = false;
                dr.Read();
                MessageBox.Show(dr[1].ToString(), "Success", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                
            }
            */
            //int i = 0;
            //Userlist[] userlist = new Userlist[20];

            //flowLayoutPanel1.Controls.Clear();
            if (dr.HasRows)
            {
                while (dr.Read())
                {
                    /*
                    MessageBox.Show(dr[1].ToString());
                    userlist[i] = new Userlist();
                    userlist[i].UserName = dr[1].ToString();
                    userlist[i].UserLocation = dr[3].ToString();
                    userlist[i].UserSkill = dr[5].ToString();
                    userlist[i].UserAge = dr[8].ToString();

                    flowLayoutPanel1.Controls.Add(userlist[i]);
                    i++;*/
                    WorkerName.Add(dr[1].ToString());
                    WorkerNumber.Add(dr[0].ToString());
                    WorkerLocatin.Add(dr[3].ToString());
                    WorkerSkill.Add(dr[5].ToString());
                    WorkerAge.Add(int.Parse(dr[8].ToString()));
                    WorkerGender.Add(dr[2].ToString());
                    WorkerRating.Add(int.Parse(dr[11].ToString()));
                    WorkerTotalJobDone.Add(dr[10].ToString());
                    WorkerFees.Add(int.Parse(dr[7].ToString()));
                    WorkerRatedby.Add(int.Parse(dr[12].ToString()));
                    assigned.Add(dr[9].ToString());

                }
                con.Close();
                Form2main.Instance2.f2mainpanel.Controls.Clear();
                Userlist[] userlist = new Userlist[WorkerName.Count()];

                for (int i = 0; i < userlist.Length; i++)
                {
                    userlist[i] = new Userlist();
                    userlist[i].UserName = WorkerName.ElementAt(i);
                    userlist[i].UserLocation = WorkerLocatin.ElementAt(i);
                    userlist[i].UserSkill = WorkerSkill.ElementAt(i);
                    userlist[i].UserAge = WorkerAge.ElementAt(i).ToString();
                    userlist[i].Gender = WorkerGender.ElementAt(i).ToString();
                    userlist[i].UserNumberofDB = WorkerNumber.ElementAt(i);
                    userlist[i].UserRatedBy = WorkerRatedby.ElementAt(i);
                    userlist[i].UserTotalJobDone = WorkerTotalJobDone.ElementAt(i);
                    userlist[i].UserFees = WorkerFees.ElementAt(i);
                    userlist[i].Assigned = assigned.ElementAt(i);

                    if (WorkerRating.ElementAt(i) == 0)
                    {
                        userlist[i].UserRating = Properties.Resources._0star;
                    }
                    else if (WorkerRating.ElementAt(i) == 1)
                    {
                        userlist[i].UserRating = Properties.Resources._1star;
                    }
                    else if (WorkerRating.ElementAt(i) == 2)
                    {
                        userlist[i].UserRating = Properties.Resources._2star;
                    }
                    else if (WorkerRating.ElementAt(i) == 3)
                    {
                        userlist[i].UserRating = Properties.Resources._3star;
                    }
                    else if (WorkerRating.ElementAt(i) == 4)
                    {
                        userlist[i].UserRating = Properties.Resources._5star;
                    }
                    else if (WorkerRating.ElementAt(i) == 5)
                    {
                        userlist[i].UserRating = Properties.Resources._5star;
                    }
                    /*else
                    {
                        userlist[i].UserRating = Properties.Resources._0star;
                    }*/
                    Form2main.Instance2.f2mainpanel.Controls.Add(userlist[i]);
                }
            }
            else
            {
                MessageBox.Show("Nothing TO Show.");
            }


        }

        private void pictureBox4_MouseLeave(object sender, EventArgs e)
        {
            this.pictureBox4.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(12)))), ((int)(((byte)(124)))), ((int)(((byte)(224)))));

        }

        private void pictureBox4_MouseEnter(object sender, EventArgs e)
        {
            this.pictureBox4.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(8)))), ((int)(((byte)(82)))), ((int)(((byte)(159)))));

        }

        private void pictureBox4_Click(object sender, EventArgs e)
        {
            this.pictureBox4.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(12)))), ((int)(((byte)(124)))), ((int)(((byte)(224)))));
            noti n = new noti();
            n.Location = new Point(1099, 180);
            n.Visible = true;
            
        }

        private void pictureBox4_MouseHover(object sender, EventArgs e)
        {
            this.pictureBox4.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(8)))), ((int)(((byte)(82)))), ((int)(((byte)(159)))));

        }
    }
}
