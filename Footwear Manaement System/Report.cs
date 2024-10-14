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
           Customer_Report customer = new Customer_Report();
            customer.Show();
        }

        private void pictureBox2_Click(object sender, EventArgs e)
        {
          Employee_Report employee = new Employee_Report();
            employee.Show();
        }

        private void pictureBox3_Click(object sender, EventArgs e)
        {
           Product_Report product = new Product_Report();
            product.Show();
        }

        private void pictureBox4_Click(object sender, EventArgs e)
        {
           Supplier_Report supplier = new Supplier_Report();    
            supplier.Refresh();
            supplier.Show();
        }

        private void pictureBox5_Click(object sender, EventArgs e)
        {
           Order_Report order = new Order_Report();
            order.Show();
        }

        private void pictureBox6_Click(object sender, EventArgs e)
        {
           Bill_Report bill = new Bill_Report();
            bill.Show();
        }
    }
}
