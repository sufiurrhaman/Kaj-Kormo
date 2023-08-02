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
    public partial class Form1 : Form
    {
        static Form1 _obj;

        public static Form1 Instance
        {
            get
            {
                if(_obj == null)
                {
                    _obj = new Form1();
                }
                return _obj;
            }
        }

        public Panel mainPanel
        {
            get { return panelContainer; }
            set { panelContainer = value; }
        }

        public Button backButton
        {
            get { return button1; }
            set { button1 = value; }
        }

        public Form1()
        {
            
            InitializeComponent();
        }

        private void button1_MouseEnter(object sender, EventArgs e)
        {
            button1.BackColor = Color.White;
        }

        private void button1_MouseLeave(object sender, EventArgs e)
        {
            button1.BackColor = Color.Transparent;
        }

        private void Form1_Load(object sender, EventArgs e)
        {
            button1.Visible = false;
            _obj = this;

            Login ln = new Login();
            ln.Dock = DockStyle.Fill;
            panelContainer.Controls.Add(ln);
        }

        private void button1_Click(object sender, EventArgs e)
        {
            if (!Form1.Instance.mainPanel.Controls.ContainsKey("Login"))
            {
                Login sn = new Login();
                sn.Dock = DockStyle.Fill;
                Form1.Instance.mainPanel.Controls.Add(sn);
            }
            Form1.Instance.mainPanel.Controls["Login"].BringToFront();
            Form1.Instance.backButton.Visible = false;
            /*try
            {
                Form1.Instance.mainPanel.Controls["Signup"].Dispose();
            }
            catch
            {
                Form1.Instance.mainPanel.Controls["SignupNext"].Dispose();
            }
            */
            if (Form1.Instance.mainPanel.Controls.ContainsKey("Signup"))
            {
                Form1.Instance.mainPanel.Controls["Signup"].Dispose();
            }
            if (Form1.Instance.mainPanel.Controls.ContainsKey("SignupNext"))
            {
                Form1.Instance.mainPanel.Controls["SignupNext"].Dispose();
            }
            //Form1.Instance.mainPanel.Controls["Signup"].Dispose();
            //Form1.Instance.mainPanel.Controls["SignupNext"].Dispose();
        }
    }
}
