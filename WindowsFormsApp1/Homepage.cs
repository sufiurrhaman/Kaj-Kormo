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
    public partial class Homepage : UserControl
    {
        string cs = ConfigurationManager.ConnectionStrings["dbcs"].ConnectionString;
        //private static Homepage _obj;

        //public static Homepage HomeInstance
        //{
        //    get
        //    {
        //        _obj = new Homepage();
        //        return _obj;
        //    }
        //}
        public Homepage()
        {
            InitializeComponent();
        }

        private void panel1_Enter(object sender, EventArgs e)
        {
            this.panel1.BackColor = Color.Silver;
        }

        private void panel2_MouseEnter(object sender, EventArgs e)
        {
            this.panel2.BackColor = Color.Silver;

        }

        private void panel3_MouseEnter(object sender, EventArgs e)
        {
            this.panel3.BackColor = Color.Silver;

        }

        private void panel4_MouseEnter(object sender, EventArgs e)
        {
            this.panel4.BackColor = Color.Silver;

        }

        private void panel5_MouseEnter(object sender, EventArgs e)
        {
            this.panel5.BackColor = Color.Silver;

        }

        private void panel6_MouseEnter(object sender, EventArgs e)
        {
            this.panel6.BackColor = Color.Silver;

        }

        private void panel7_MouseEnter(object sender, EventArgs e)
        {
            this.panel7.BackColor = Color.Silver;

        }

        private void panel8_MouseEnter(object sender, EventArgs e)
        {
            this.panel8.BackColor = Color.Silver;

        }

        private void panel9_MouseEnter(object sender, EventArgs e)
        {
            this.panel9.BackColor = Color.Silver;

        }

        private void panel10_MouseEnter(object sender, EventArgs e)
        {
            this.panel10.BackColor = Color.Silver;

        }

        private void panel1_MouseLeave(object sender, EventArgs e)
        {

        }

        private void panel1_MouseMove(object sender, MouseEventArgs e)
        {
            this.panel1.BackColor = Color.LightGray;
        }

        private void panel2_MouseLeave(object sender, EventArgs e)
        {
            this.panel2.BackColor = Color.LightGray;

        }

        private void panel3_MouseLeave(object sender, EventArgs e)
        {
            this.panel3.BackColor = Color.LightGray;

        }

        private void panel4_MouseLeave(object sender, EventArgs e)
        {
            this.panel4.BackColor = Color.LightGray;

        }

        private void panel5_MouseLeave(object sender, EventArgs e)
        {
            this.panel5.BackColor = Color.LightGray;

        }

        private void panel6_MouseLeave(object sender, EventArgs e)
        {
            this.panel6.BackColor = Color.LightGray;

        }

        private void panel7_MouseLeave(object sender, EventArgs e)
        {
            this.panel7.BackColor = Color.LightGray;

        }

        private void panel8_MouseLeave(object sender, EventArgs e)
        {
            this.panel8.BackColor = Color.LightGray;

        }

        private void panel9_MouseLeave(object sender, EventArgs e)
        {
            this.panel9.BackColor = Color.LightGray;

        }

        private void panel10_MouseLeave(object sender, EventArgs e)
        {
            this.panel10.BackColor = Color.LightGray;
            
        }

        private void pictureBox1_MouseEnter(object sender, EventArgs e)
        {
            this.panel1.BackColor = Color.Silver;
        }

        private void pictureBox2_MouseEnter(object sender, EventArgs e)
        {
            this.panel2.BackColor = Color.Silver;

        }

        private void pictureBox3_MouseEnter(object sender, EventArgs e)
        {
            this.panel3.BackColor = Color.Silver;

        }

        private void pictureBox4_MouseEnter(object sender, EventArgs e)
        {
            this.panel4.BackColor = Color.Silver;

        }

        private void pictureBox5_MouseEnter(object sender, EventArgs e)
        {
            this.panel5.BackColor = Color.Silver;

        }

        private void pictureBox6_MouseEnter(object sender, EventArgs e)
        {
            this.panel6.BackColor = Color.Silver;

        }

        private void pictureBox7_MouseEnter(object sender, EventArgs e)
        {
            this.panel7.BackColor = Color.Silver;

        }

        private void pictureBox8_MouseEnter(object sender, EventArgs e)
        {
            this.panel8.BackColor = Color.Silver;

        }

        private void pictureBox9_MouseEnter(object sender, EventArgs e)
        {
            this.panel9.BackColor = Color.Silver;

        }

        private void pictureBox10_MouseEnter(object sender, EventArgs e)
        {
            this.panel10.BackColor = Color.Silver;

        }

        private void pictureBox1_MouseLeave(object sender, EventArgs e)
        {
            this.panel1.BackColor = Color.LightGray;

        }

        private void pictureBox2_MouseLeave(object sender, EventArgs e)
        {
            this.panel2.BackColor = Color.LightGray;

        }

        private void pictureBox3_MouseLeave(object sender, EventArgs e)
        {
            this.panel3.BackColor = Color.LightGray;

        }

        private void pictureBox4_MouseLeave(object sender, EventArgs e)
        {
            this.panel4.BackColor = Color.LightGray;

        }

        private void pictureBox5_MouseLeave(object sender, EventArgs e)
        {
            this.panel5.BackColor = Color.LightGray;

        }

        private void pictureBox6_MouseLeave(object sender, EventArgs e)
        {
            this.panel6.BackColor = Color.LightGray;

        }

        private void pictureBox7_MouseLeave(object sender, EventArgs e)
        {
            this.panel7.BackColor = Color.LightGray;

        }

        private void pictureBox8_MouseLeave(object sender, EventArgs e)
        {
            this.panel8.BackColor = Color.LightGray;

        }

        private void pictureBox9_MouseLeave(object sender, EventArgs e)
        {
            this.panel9.BackColor = Color.LightGray;

        }

        private void pictureBox10_MouseLeave(object sender, EventArgs e)
        {
            this.panel10.BackColor = Color.LightGray;

        }

        private void pictureBox1_Click(object sender, EventArgs e)
        {
            string query = "select * from w_orker where skill = 'Lift engineer'";
            pupulateitems(query);
        }

        private void pupulateitems(string query)
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

        private void pictureBox7_Click(object sender, EventArgs e)
        {
            string query = "select * from w_orker where skill = 'Labour'";
            pupulateitems(query);
        }

        private void pictureBox2_Click(object sender, EventArgs e)
        {
            string query = "select * from w_orker where skill = 'Plumber'";
            pupulateitems(query);
        }

        private void pictureBox3_Click(object sender, EventArgs e)
        {
            string query = "select * from w_orker where skill = 'Electrician'";
            pupulateitems(query);
        }

        private void pictureBox4_Click(object sender, EventArgs e)
        {
            string query = "select * from w_orker where skill = 'Swiper'";
            pupulateitems(query);
        }

        private void pictureBox5_Click(object sender, EventArgs e)
        {
            string query = "select * from w_orker where skill = 'Gas mechanic'";
            pupulateitems(query);
        }

        private void pictureBox6_Click(object sender, EventArgs e)
        {
            string query = "select * from w_orker where skill = 'Lock fixer'";
            pupulateitems(query);
        }

        private void pictureBox8_Click(object sender, EventArgs e)
        {
            string query = "select * from w_orker where skill = 'Van puller'";
            pupulateitems(query);
        }

        private void pictureBox9_Click(object sender, EventArgs e)
        {
            string query = "select * from w_orker where skill = 'Waste cleaner'";
            pupulateitems(query);
        }

        private void pictureBox10_Click(object sender, EventArgs e)
        {
            string query = "select * from w_orker where skill = 'Architect'";
            pupulateitems(query);
        }

        private void Homepage_Load(object sender, EventArgs e)
        {
            //_obj = this;
            flowLayoutPanel2.Controls.Clear();
            SqlConnection con = new SqlConnection(cs);
            string query = "select * from book_worker where u_ser = @Phone and s_tatus = 'done'";
            SqlCommand cmd = new SqlCommand(query, con);
            cmd.Parameters.AddWithValue("@Phone", Form2main.Instance2.AccountPhoneDB);
            con.Open();
            SqlDataReader dr = cmd.ExecuteReader();
            if (dr.HasRows)
            {
                while (dr.Read())
                {
                    

                    SqlConnection con2 = new SqlConnection(cs);
                    string query2 = "select * from w_orker where phone = @Phone";
                    SqlCommand cmd2 = new SqlCommand(query2, con2);
                    cmd2.Parameters.AddWithValue("@Phone", dr[2].ToString());
                    con2.Open();
                    SqlDataReader dr2 = cmd2.ExecuteReader();
                    dr2.Read();

                    UserHomeHistory u = new UserHomeHistory();
                    u.UserName = dr2[0].ToString();
                    u.WorkerName = dr2[1].ToString();
                    u.Phone = dr2[0].ToString();
                    u.WorkerLocation = dr2[3].ToString();
                    flowLayoutPanel2.Controls.Add(u);
                    con2.Close();
                }

            }
            con.Close();

        }

        private void groupBox1_Enter(object sender, EventArgs e)
        {



        }

        private void label17_Click(object sender, EventArgs e)
        {

        }

        private void button1_Click(object sender, EventArgs e)
        {
            SqlConnection con = new SqlConnection(cs);
            string query = "insert into book_worker values(@User, null, @Note, 'post', @Workdate,@Worktime ,null" +
                ",null,null,null,@Skill)";
            SqlCommand cmd = new SqlCommand(query, con);
            //con.Open();
            //cmd.Parameters.AddWithValue("@", textBox2.Text);
            cmd.Parameters.AddWithValue("@User", Form2main.Instance2.AccountPhoneDB);
            //cmd.Parameters.AddWithValue("@Worker", this.workerPhone);
            cmd.Parameters.AddWithValue("@Note", this.textBox4.Text);
            cmd.Parameters.AddWithValue("@Workdate", this.dateTimePicker1.Text);
            cmd.Parameters.AddWithValue("@Worktime", this.textBox2.Text);
            cmd.Parameters.AddWithValue("@Skill", this.comboBox2.SelectedItem);


            //cmd.Parameters.AddWithValue("@Pin", int.Parse(textBox4.Text));
            con.Open();
            int a = cmd.ExecuteNonQuery();
            //con.Open();
            //SqlDataReader dr = cmd.ExecuteReader();
            if (a > 0)
            {
                MessageBox.Show("Job Posted.", "Success", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                

            }
            else
            {
                MessageBox.Show("Something went wrong. Try again!", "Error", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);

            }
            con.Close();
        }
    }
}
