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
    public partial class message : Form
    {
        string cs = ConfigurationManager.ConnectionStrings["dbcs"].ConnectionString;

        public message()
        {
            InitializeComponent();
        }

        private void message_Load(object sender, EventArgs e)
        {
            SqlConnection con = new SqlConnection(cs);
            string query = "select * from Report_issue where viewed = 'No' or viewed = 'Yes'";
            SqlCommand cmd = new SqlCommand(query, con);
            con.Open();
            SqlDataReader dr = cmd.ExecuteReader();

            if (dr.HasRows)
            {
                this.flowLayoutPanel1.Controls.Clear();

                while (dr.Read())
                {
                    massageissue m = new massageissue();
                    m.Title = "Title: "+dr[3].ToString();
                    m.Sender ="Sender: "+ dr[1].ToString();
                    m.Details = dr[4].ToString();
                    if (dr[2].ToString() == "" || dr[2].ToString() == "null")
                    {
                        m.ReportAccount = "";
                    }
                    else
                    {
                        m.ReportAccount = "Reported account: "+dr[2].ToString();
                    }
                    this.flowLayoutPanel1.Controls.Add(m);
                }
                SqlConnection con2 = new SqlConnection(cs);
                string query2 = "update Report_issue set viewed = 'Yes'";
                SqlCommand cmd2 = new SqlCommand(query2, con2);
                con2.Open();
                cmd2.ExecuteNonQuery();
                con2.Close();
            }
            con.Close();
        }
    }
}
