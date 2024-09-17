using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Footwear_Manaement_System
{
    public partial class Product : UserControl
    {
        private Men _men;
        private Women _women;
        private Kids _kids;

        public Product()
        {
            InitializeComponent();
        }

        public Product(Men men, Women women, Kids kids)
        {
            InitializeComponent();
            _men = men;
            _women = women;
            _kids = kids;
        }

        public void RefreshData()
        {
            if (InvokeRequired)
            {
                Invoke((MethodInvoker)RefreshData);
                return;
            }
            //displayCustomerData();
        }

        private void pictureBox1_Click(object sender, EventArgs e)
        {
            _men.Visible = true;
            this.Visible = false;
        }

        private void pictureBox2_Click(object sender, EventArgs e)
        {
            _women.Visible = true;
            this.Visible = false;
        }

        private void pictureBox3_Click(object sender, EventArgs e)
        {
            _kids.Visible = true;
            this.Visible = false;
        }
    }
}
