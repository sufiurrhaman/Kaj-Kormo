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
    public partial class UserHomeHistory : UserControl
    {
        string cs = ConfigurationManager.ConnectionStrings["dbcs"].ConnectionString;

        private string userName;
        private string location;
        private string name;
        private string phone;

        public string UserName
        {
            set { this.userName = value; this.label1.Text = "UserName: " + value; }
            get { return this.userName; }
        }

        public string WorkerName
        {
            set { this.name = value; this.label2.Text = "Name: " + value; }
            get { return name; }
        }

        public string Phone
        {
            set { string[] ph = value.Split('w'); this.phone = ph[0]; this.label3.Text = "Phone: " + ph[0]; }
            get { return phone; }
        }

        public string WorkerLocation
        {
            set { this.location = value; this.label4.Text = "Location: " + value; }
            get { return location; }
        }

        public UserHomeHistory()
        {
            InitializeComponent();
        }

        private void UserHomeHistory_DoubleClick(object sender, EventArgs e)
        {
            this.viewWorker();
        }

        private void label1_Click(object sender, EventArgs e)
        {
            this.viewWorker();
        }

        private void viewWorker()
        {
            SqlConnection con2 = new SqlConnection(cs);
            string query2 = "select * from w_orker where phone = @Phone";
            SqlCommand cmd2 = new SqlCommand(query2, con2);
            cmd2.Parameters.AddWithValue("@Phone",this.userName);
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

            if(dr2[9].ToString() == "No")
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

        }
    }
}
