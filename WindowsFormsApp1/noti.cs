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
    public partial class noti : Form
    {
        string cs = ConfigurationManager.ConnectionStrings["dbcs"].ConnectionString;

        public noti()
        {
            InitializeComponent();
        }

        private void noti_Load(object sender, EventArgs e)
        {
            SqlConnection con2 = new SqlConnection(cs);
            string query2 = "select * from book_worker where u_ser = @Phone and s_tatus = 'cancel'";
            SqlCommand cmd2 = new SqlCommand(query2, con2);
            cmd2.Parameters.AddWithValue("@Phone", Form2main.Instance2.AccountPhoneDB);
            con2.Open();
            SqlDataReader dr2 = cmd2.ExecuteReader();
            flowLayoutPanel1.Controls.Clear();
            if (dr2.HasRows)
            {
                while (dr2.Read())
                {
                    SqlConnection con = new SqlConnection(cs);
                    string query = "select * from w_orker where phone = @Phone";
                    SqlCommand cmd = new SqlCommand(query, con);
                    cmd.Parameters.AddWithValue("@Phone", dr2[2].ToString());
                    con.Open();
                    SqlDataReader dr = cmd.ExecuteReader();
                    dr.Read();

                    notinotes n = new notinotes();
                    n.lbl4.Text = dr[1].ToString();
                    flowLayoutPanel1.Controls.Add(n);
                    con.Close();
                }
            }
            else
            {
                MessageBox.Show("Nothing to show.", "Blank", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);

            }
            con2.Close();

            
        }

        private void linkLabel1_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
        {
            SqlConnection con = new SqlConnection(cs);
            string query = "update book_worker set s_tatus = 'cancelview' where u_ser = @Phone and s_tatus = 'cancel'";
            SqlCommand cmd = new SqlCommand(query, con);
            cmd.Parameters.AddWithValue("@Phone", Form2main.Instance2.AccountPhoneDB);
            con.Open();
            int a = cmd.ExecuteNonQuery();
            con.Close();
            if (a > 0)
            {
                this.Dispose();
                Form2main.Instance2.pb4.Image = Properties.Resources.icons8_bell_48;

            }
        }
    }
}
