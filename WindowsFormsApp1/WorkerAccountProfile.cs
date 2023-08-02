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
    public partial class WorkerAccountProfile : UserControl
    {
        string cs = ConfigurationManager.ConnectionStrings["dbcs"].ConnectionString;

        private string accountName;
        private string userName;
        private string userPhone;
        private string userLoaction;
        private string userGender;
        private int userPin;
        private int userBalance;
        private int userOrders;
        private Image userImage;
        private string userSkill;
        private string userFees;
        private string userAge;


        public string UserAge
        {
            set { this.userAge = value; this.label21.Text = value; this.textBox4.Text = value; }
            get { return this.userAge; }
        }

        public string UserFees
        {
            set { this.userFees = value; this.label13.Text = value; this.textBox6.Text = value; }
            get { return this.userFees; }
        }

        public string UserSkill
        {
            set { this.userSkill = value; this.label23.Text = value; this.comboBox2.Text = value; }
            get { return this.userSkill; }
        }

        public string AccountName
        {
            set { this.accountName = value; this.label1.Text = value; this.textBox2.Text = value; }
            get { return this.accountName; }
        }

        public string UserName
        {
            set { this.userName = value; this.label9.Text = value; }
            get { return this.userName; }
        }

        public Image UserImage
        {
            set { this.userImage = value; this.pictureBox1.Image = value; }
            get { return this.userImage; }
        }

        public string UserPhone
        {
            set
            {
                string[] Phone = value.Split('w');
                this.userPhone = Phone[0];
                this.label8.Text = Phone[0];
                this.textBox1.Text = Phone[0];
            }
            get { return this.userPhone; }
        }

        public string UserLocation
        {
            set { this.userLoaction = value; this.label10.Text = value; this.textBox3.Text = value; }
            get { return this.userLoaction; }
        }

        public string UserGender
        {
            set { this.userGender = value; this.label18.Text = value; this.comboBox1.Text = value; }
            get { return this.userGender; }
        }

        public int UserPin
        {
            set { this.userPin = value; this.label11.Text = value.ToString(); this.textBox5.Text = value.ToString(); }
            get { return this.userPin; }
        }

        public int UserOrders
        {
            set { this.userOrders = value; this.label12.Text = value.ToString(); }
            get { return this.userOrders; }
        }

        public int UserBalance
        {
            set { this.userBalance = value; this.label27.Text = value.ToString(); }
            get { return this.userBalance; }
        }

        public WorkerAccountProfile()
        {
            InitializeComponent();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            this.groupBox1.Size = new System.Drawing.Size(380, 650);
            this.groupBox2.Visible = true;
        }

        private void WorkerAccountProfile_Load(object sender, EventArgs e)
        {
            this.groupBox1.Size = new System.Drawing.Size(802, 650);
        }

        private void button4_Click(object sender, EventArgs e)
        {
            this.groupBox1.Size = new System.Drawing.Size(802, 650);
            this.groupBox2.Visible = false;
        }

        private void button3_Click(object sender, EventArgs e)
        {
            SqlConnection con = new SqlConnection(cs);
            string query = "update w_orker set phone = @Phone, username = @Name, locatin = @Location, gender = @Gender, pin = @Pin, age = @Age," +
                "fees = @Fees, skill = @Skill where phone = @mainPhone";
            SqlCommand cmd = new SqlCommand(query, con);
            //con.Open();
            //cmd.Parameters.AddWithValue("@", textBox2.Text);
            cmd.Parameters.AddWithValue("@Phone", textBox1.Text + "w");
            cmd.Parameters.AddWithValue("@Name", textBox2.Text);
            cmd.Parameters.AddWithValue("@Gender", comboBox1.SelectedItem.ToString());
            cmd.Parameters.AddWithValue("@Location", textBox3.Text);
            cmd.Parameters.AddWithValue("@Pin", int.Parse(textBox5.Text));
            cmd.Parameters.AddWithValue("@Age", int.Parse(textBox4.Text));
            cmd.Parameters.AddWithValue("@Fees", int.Parse(textBox6.Text));
            cmd.Parameters.AddWithValue("@Skill", comboBox2.SelectedItem.ToString());
            cmd.Parameters.AddWithValue("@mainPhone", this.userName);

            con.Open();
            int a = cmd.ExecuteNonQuery();
            //con.Open();
            //SqlDataReader dr = cmd.ExecuteReader();
            if (a > 0)
            {
                MessageBox.Show("Account Update Successful.\n Username: " + textBox1.Text + "u.\nPin: " + textBox5.Text + ".", "Success", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);

                UserAccountProfile u = new UserAccountProfile();
                //Form1.Instance.mainPanel.Controls.Clear();
                Form2main.Instance2.f2mainpanel.Controls.Clear();
                Form2main.Instance2.MyAccount();
                //Form2main.Instance2.f2mainpanel.Controls.Add(u);
                //this.Dispose();
            }
            else
            {
                MessageBox.Show("Something went wrong.. Try again!", "Error", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);

            }
            con.Close();
        }

        private void button5_Click(object sender, EventArgs e)
        {
            Form2main.Instance2.viewWorker();
            this.Dispose();
        }

        private void button2_Click(object sender, EventArgs e)
        {
            Report r = new Report();
            r.Visible = true;
        }
    }
}
