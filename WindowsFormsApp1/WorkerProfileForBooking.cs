using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Data.SqlClient;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace WindowsFormsApp1
{
    public partial class WorkerProfileForBooking : UserControl
    {
        private string wbName;
        private string wbSkill;
        private string wbPhone;
        private string wbLocation;
        private string wbGender;
        private string wbAge;
        private string wbTotaJobDone;
        private int wbFees;
        private int wbRatedby;
        private int wbRate;
        private Image rateImage;

        public GroupBox gbox2
        {
            set { this.groupBox2 = value; }
            get { return this.groupBox2; }
        }

        public Label Lbl
        {
            set { this.label21 = value; }
            get { return label21; }
        }

        public string WbPhone
        {
            set
            {
                string[] Phone = value.Split('w');
                this.wbPhone = Phone[0];
                this.label8.Text = Phone[0];
            }
            get { return this.wbPhone; }
        }

        public string WbName
        {
            set { this.wbName = value; this.label1.Text = value; }
            get { return this.wbName; }
        }

        public string WbSkill
        {
            set { this.wbSkill = value; this.label15.Text = value; }
            get { return this.wbSkill; }
        }

        public string WbLocation
        {
            set { this.wbLocation = value; this.label10.Text = value; }
            get { return this.wbLocation; }
        }

        public string WbGender
        {
            set { this.wbGender = value; this.label18.Text = value; }
            get { return this.wbGender; }
        }

        public string WbAge
        {
            set { this.wbAge = value; this.label16.Text = value; }
            get { return this.wbAge; }
        }

        public string WbTotalJobsDone
        {
            set { this.wbTotaJobDone = value; this.label12.Text = value; }
            get { return this.wbTotaJobDone; }
        }

        public int WbFees
        {
            set { this.wbFees = value; this.label13.Text = value.ToString(); }
            get { return this.wbFees; }
        }

        public int WbRatedBy
        {
            set { this.wbRatedby = value; this.label3.Text = value.ToString(); }
            get { return this.wbRatedby; }
        }

        public Image RateImage
        {
            set { this.rateImage = value; this.pictureBox2.Image = value;}
            get { return this.rateImage; }
        }

        public int WbRate
        {
            set
            {
                this.wbRate = value;
                /*if (value == 0)
                {
                    this.pictureBox2.Image = Properties.Resources._0star;
                }
                else if (value == 1)
                {
                    this.pictureBox2.Image = Properties.Resources._1star;
                }
                else if (value == 2)
                {
                    this.pictureBox2.Image = Properties.Resources._2star;
                }
                else if (value == 3)
                {
                    this.pictureBox2.Image = Properties.Resources._3star;
                }
                else if (value == 4)
                {
                    this.pictureBox2.Image = Properties.Resources._4star;
                }
                else if (value == 5)
                {
                    this.pictureBox2.Image = Properties.Resources._5star;
                }
                */

            }
            get { return this.wbRate; }
        }

        public WorkerProfileForBooking()
        {
            InitializeComponent();
        }

        private void button3_Click(object sender, EventArgs e)
        {
            if (check())
            {
                BookJob b = new BookJob();
                b.WorkDate = this.dateTimePicker1.Text;
                b.ExpectedCost = int.Parse(textBox2.Text) * int.Parse(label13.Text);
                b.ExpectedTime = int.Parse(textBox2.Text);
                b.WorkersFees = int.Parse(this.label13.Text);
                b.WorkerPhone = this.label8.Text;
                b.Message = this.textBox4.Text;
                b.Visible = true;
            }
            
        }

        private bool check()
        {
            if (String.IsNullOrEmpty(textBox2.Text) == true || textBox2.Text == "")
            {
                textBox2.Focus();
                errorProvider1.Icon = Properties.Resources.icons8_Cancel;
                errorProvider1.SetError(this.textBox2, "Empty Field.");

                return false;
            }

            else
            {
                int flag = 0;
                for (int i = 0; i < textBox2.Text.Length; i++)
                {
                    if (Char.IsLetter(textBox2.Text[i]))
                    {
                        flag = 1;
                        break;
                    }
                }
                if (flag == 1)
                {
                    textBox2.Focus();
                    errorProvider1.Icon = Properties.Resources.icons8_Cancel;
                    errorProvider1.SetError(this.textBox2, "Invalid Format.");

                    return false;
                }
                else
                {
                    errorProvider1.Icon = Properties.Resources.icons8_Checked;
                    errorProvider1.SetError(this.textBox2, "Valid");

                    return true;
                }
            }
        }

        private void button3_Enter(object sender, EventArgs e)
        {
            if (String.IsNullOrEmpty(textBox2.Text) == true || textBox2.Text == "")
            {
                textBox2.Focus();
                errorProvider1.Icon = Properties.Resources.icons8_Cancel;
                errorProvider1.SetError(this.textBox2, "Empty Field.");
            }

            else
            {
                int flag = 0;
                for (int i = 0; i < textBox2.Text.Length; i++)
                {
                    if (Char.IsLetter(textBox2.Text[i]))
                    {
                        flag = 1;
                        break;
                    }
                }
                if (flag == 1)
                {
                    textBox2.Focus();
                    errorProvider1.Icon = Properties.Resources.icons8_Cancel;
                    errorProvider1.SetError(this.textBox2, "Invalid Format.");
                }
                else
                {
                    errorProvider1.Icon = Properties.Resources.icons8_Checked;
                    errorProvider1.SetError(this.textBox2, "Valid");
                }
            }
        }

        private void button1_Click(object sender, EventArgs e)
        {
            RateWorker r = new RateWorker();
            r.UserName = this.wbPhone + "w";
            r.WorkerRate = this.wbRate;
            r.WorkerRatedby = wbRatedby;
            r.Visible = true;
        }

        private void button5_Click(object sender, EventArgs e)
        {
            Homepage h = new Homepage();
            Form2main.Instance2.f2mainpanel.Controls.Clear();
            Form2main.Instance2.f2mainpanel.Controls.Add(h);
            this.Dispose();
        }

        private void button2_Click(object sender, EventArgs e)
        {
            Report r = new Report();
            r.cbox.SelectedItem = "Report an account";
            r.tbox.Visible = true;
            r.lbl.Visible=true;
            r.tbox.Text = this.wbPhone + "w";
            r.Visible = true;
        }
    }
}
