using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Runtime.InteropServices;
using System.Runtime.Remoting.Channels;


namespace Footwear_Manaement_System
{
    public partial class Mainform : Form
    {

        [DllImport("Gdi32.dll", EntryPoint ="CreateRoundRectRgn")]

        private static extern IntPtr CreateRoundRectRgn
            (

            int nLeftRect,
            int nTopRect,
            int nRightRect,
            int nBottomRect,
            int nWidthEllipse,
            int nHeightEllipse

              );
        public Mainform()
        {
            InitializeComponent();

            Region =System.Drawing.Region.FromHrgn(CreateRoundRectRgn(0, 0, Width, Height, 25, 25));

        }

        private void button4_Click(object sender, EventArgs e)
        {
            panel4.Height = AddEmployee_btn.Height;
            panel4.Top = AddEmployee_btn.Top;
            panel4.Left = AddEmployee_btn.Left;
            AddEmployee_btn.BackColor = Color.FromArgb(46, 51, 73);

            dashbord1.Visible = false;
            addEmployee1.Visible=true;
            salary1.Visible=false;

            AddEmployee addEmForm = addEmployee1 as AddEmployee;
            if (addEmForm != null)
            {
                addEmForm.RefreshData();
            }
        }

        private void button1_Click(object sender, EventArgs e)
        {
            panel4.Height = dashbord__btn.Height;
            panel4.Top = dashbord__btn.Top;
            panel4.Left = dashbord__btn.Left;
            dashbord__btn.BackColor = Color.FromArgb(46, 51, 73);

            dashbord1.Visible = true;
            addEmployee1.Visible = false ;
            salary1.Visible = false;

           dashboard1 dashForm= dashbord1 as dashboard1 ;

            if (dashForm != null)
            {
                dashForm.RefreshData();
            }


        }

        private void button2_Click(object sender, EventArgs e)
        {
            panel4.Height = custmoer_btn.Height;
            panel4.Top = custmoer_btn.Top;
            panel4.Left = custmoer_btn.Left;
            custmoer_btn.BackColor = Color.FromArgb(46, 51, 73);

            dashbord1.Visible = false;
            addEmployee1.Visible = false;
            salary1.Visible = false;
            supplier_info1.Visible = false;
            customer_info1.Visible = true;
           

            customer_info addcustForm = customer_info1 as customer_info;
            if (addcustForm != null)
            {
                addcustForm.RefreshData();
            }
        }

        private void button3_Click(object sender, EventArgs e)
        {
            panel4.Height = warehouse_btn.Height;
            panel4.Top = warehouse_btn.Top;
            panel4.Left = warehouse_btn.Left;
            warehouse_btn.BackColor = Color.FromArgb(46, 51, 73);
        }

        private void button5_Click(object sender, EventArgs e)
        {
            panel4.Height = supplier_info_btn.Height;
            panel4.Top = supplier_info_btn.Top;
            panel4.Left = supplier_info_btn.Left;
            supplier_info_btn.BackColor = Color.FromArgb(46, 51, 73);

            dashbord1.Visible = false;
            addEmployee1.Visible = true;
            salary1.Visible = false;
            supplier_info1.Visible = true;
            customer_info1.Visible=false;

            Supplier_info addsupForm = supplier_info1 as Supplier_info;
            if (addsupForm != null)
            {
                addsupForm.RefreshData();
                
            }
        }

        private void button6_Click(object sender, EventArgs e)
        {
            panel4.Height = biling_btn.Height;
            panel4.Top = biling_btn.Top;
            panel4.Left = biling_btn.Left;
            biling_btn.BackColor = Color.FromArgb(46, 51, 73);
        }

        private void button7_Click(object sender, EventArgs e)
        {
            panel4.Height = button7.Height;
            panel4.Top = button7.Top;
            panel4.Left = button7.Left;
            button7.BackColor = Color.FromArgb(46, 51, 73);

            DialogResult check = MessageBox.Show("Are you sure you want to logout?"
               , "Confirmation Message", MessageBoxButtons.YesNo, MessageBoxIcon.Question);

            if (check == DialogResult.Yes)
            {
                Form1 loginForm = new Form1();
                loginForm.Show();
                this.Hide();
            }
        }

        private void button8_Click(object sender, EventArgs e)
        {
            Application.Exit(); 
        }

        private void button1_Leave(object sender, EventArgs e)
        {
            dashbord__btn.BackColor = Color.FromArgb(24, 30, 54);
        }

        private void button2_Leave(object sender, EventArgs e)
        {
            custmoer_btn.BackColor = Color.FromArgb(24, 30, 54);
        }

        private void button3_Leave(object sender, EventArgs e)
        {
            warehouse_btn.BackColor = Color.FromArgb(24, 30, 54);
        }

        private void button4_Leave(object sender, EventArgs e)
        {
            AddEmployee_btn.BackColor = Color.FromArgb(24, 30, 54);
        }

        private void button6_Leave(object sender, EventArgs e)
        {
            biling_btn.BackColor = Color.FromArgb(24, 30, 54);
        }

        private void button5_Leave(object sender, EventArgs e)
        {
            supplier_info_btn.BackColor = Color.FromArgb(24, 30, 54);
        }

        private void button7_Leave(object sender, EventArgs e)
        {
            button7.BackColor = Color.FromArgb(24, 30, 54);
        }

        private void label1_Click(object sender, EventArgs e)
        {

        }

        private void panel5_Paint(object sender, PaintEventArgs e)
        {

        }

        private void button1_Click_1(object sender, EventArgs e)
        {
            panel4.Height = Salary_btn.Height;
            panel4.Top = Salary_btn.Top;
            panel4.Left = Salary_btn.Left;
            Salary_btn.BackColor = Color.FromArgb(46, 51, 73);

            dashbord1.Visible = false;
            addEmployee1.Visible = false;
            salary1.Visible=true;

            Salary salaryForm = salary1 as Salary;

            if (salaryForm != null)
            {
                salaryForm.RefreshData();
            }

        }

        private void Salary_btn_Leave(object sender, EventArgs e)
        {
            Salary_btn.BackColor = Color.FromArgb(24, 30, 54);
        }

        private void dashbord1_Load(object sender, EventArgs e)
        {

        }

        private void addEmployee1_Load(object sender, EventArgs e)
        {

        }
    }
}
