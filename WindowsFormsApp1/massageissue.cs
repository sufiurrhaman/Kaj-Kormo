using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace WindowsFormsApp1
{
    public partial class massageissue : UserControl
    {
        private string title;
        private string sender;
        private string reportAccount;
        private string details;

        public string Title
        {
            set { this.title = value; this.label1.Text = value; }
            get { return this.title; }
        }

        public string Sender
        {
            set
            {
                this.sender = value; 
                this.label5.Text = value;
                //MessageBox.Show(value[19].ToString());
                if (value[19] == 'u')
                {
                    //MessageBox.Show(value[11].ToString());
                    this.pictureBox2.Image = Properties.Resources.User_96px;
                }
                else
                {
                    this.pictureBox2.Image = Properties.Resources.Worker_96px;
                }
            }
            get { return this.sender; }
        }

        public string ReportAccount
        {
            set { this.reportAccount = value; this.label2.Text = value; }
            get { return this.reportAccount; }
        }

        public string Details
        {
            set { this.details = value; this.label3.Text = value; }
            get { return this.details; }
        }

        public massageissue()
        {
            InitializeComponent();
        }
    }
}
