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
    public partial class Report : UserControl
    {
        public Report()
        {
            InitializeComponent();
        }

        private void pictureBox1_Click(object sender, EventArgs e)
        {
            Customer_Report cr = new Customer_Report();
            cr.Show();
        }

        private void pictureBox2_Click(object sender, EventArgs e)
        {
            Employee_Report ep = new Employee_Report();
            ep.Show();
        }

        private void pictureBox3_Click(object sender, EventArgs e)
        {
            Product_Report p = new Product_Report();
            p.Show();
        }

        private void pictureBox4_Click(object sender, EventArgs e)
        {
            Supplier_Report s= new Supplier_Report();
            s.Show();
        }

        private void pictureBox5_Click(object sender, EventArgs e)
        {
            Order_Report o= new Order_Report();
            o.Show();
        }

        private void pictureBox6_Click(object sender, EventArgs e)
        {
            Bill_Report b = new Bill_Report();
            b.Show();
        }
    }
}
