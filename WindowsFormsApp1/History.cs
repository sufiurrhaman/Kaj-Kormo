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
    public partial class History : UserControl
    {
        [Category("Custom props")]
        public Label UserPhone
        {
            set { this.label2 = value; }
            get { return this.label2; }
        }

        [Category("Custom props")]
        public Label UserEarn
        {
            set { this.label4 = value; }
            get { return this.label4; }
        }

        [Category("Custom props")]
        public Label UserReview
        {
            set { this.label5 = value; }
            get { return this.label5; }
        }

        public History()
        {
            InitializeComponent();
        }

        private void label2_Click(object sender, EventArgs e)
        {

        }

        private void label4_Click(object sender, EventArgs e)
        {

        }
    }
}
