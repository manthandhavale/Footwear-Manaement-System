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
using System.Drawing.Printing;


namespace Footwear_Manaement_System
{
    
    public partial class Bill : UserControl
    {
        SqlConnection connect = new SqlConnection(@"Data Source=MANTHAN\SQLEXPRESS;Initial Catalog=FootwareManagementSystem;Integrated Security=True;TrustServerCertificate=True");

        String printbill = string.Empty;

        public Bill()
        {
            InitializeComponent();

         
            disableFields();
        }
        public void RefreshData()
        {
            if (InvokeRequired)
            {
                Invoke((MethodInvoker)RefreshData);
                return;
            }

         
            disableFields();
        }
        public void disableFields()
        {
            Bill_CustomerID.Enabled = true;
            Bill_Address.Enabled = false;
            Bill_Email.Enabled = false;
            Bill_name.Enabled = false;
            Bill_PhoneNo.Enabled = false;
            Total_Amount.Enabled = false;
            richTextBox1.Enabled = false;
            
        }

      
        public void clearFields()
        {
            Bill_CustomerID.Text = "";
            Bill_Address.Text = "";
            Bill_Email.Text = "";
            Bill_name.Text = "";
            Bill_PhoneNo.Text = "";
            Total_Amount.Text = "";
            richTextBox1.Clear();
        }
        private void label1_Click(object sender, EventArgs e)
        {

        }

      

        private void salary_clearBtn_Click(object sender, EventArgs e)
        {
             clearFields();
        }

        private void button2_Click(object sender, EventArgs e)
        {
            if (Bill_CustomerID.Text == ""
            )
            {
                MessageBox.Show("Please fill all blank fields"
                    , "Error Message", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            else
            {
                if (connect.State == ConnectionState.Closed)
                {
                    try
                    {
                        connect.Open();
                        string checkBillID = "SELECT customer.full_name,customer.address,customer.email,customer.contact_number,bill.total_amount " +
                                              "from customer inner join bill on customer.customer_id=bill.customer_id " +
                                                "where customer.customer_id=@custID";

                        using (SqlCommand checkBill = new SqlCommand(checkBillID, connect))
                        {
                            int customerID;
                            if (int.TryParse(Bill_CustomerID.Text.Trim(), out customerID))
                                checkBill.Parameters.AddWithValue("@custID", customerID);
                           
                                SqlDataReader reader = checkBill.ExecuteReader();

                                while (reader.Read())
                                {

                                     Bill_name.Text = reader["full_name"].ToString();
                                     Bill_Address.Text = reader["address"].ToString();
                                     Bill_PhoneNo.Text = reader["contact_number"].ToString();
                                     Bill_Email.Text = reader["email"].ToString();
                                     Total_Amount.Text = reader["total_amount"].ToString();
                                }

                        }
                    }
                    catch (Exception ex)
                    {
                        MessageBox.Show("Error: " + ex
                    , "Error Message", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    }
                    finally
                    {
                        connect.Close();
                    }
                }
            }
        }

        private void Bill_CustomerID_TextChanged(object sender, EventArgs e)
        {

        }

        private void Bill_generate_Click(object sender, EventArgs e)
        {
            string CustName = string.Empty;
            int billID = 0;

            if (Bill_CustomerID.Text == ""
           )
            {
                MessageBox.Show("Please fill all blank fields"
                    , "Error Message", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            else
            {
                if (connect.State == ConnectionState.Closed)
                {
                    try
                    {
                        connect.Open();
                        string checkBillID = "SELECT customer.full_name,bill.bill_id " +
                                              "from customer inner join bill on customer.customer_id=bill.customer_id " +
                                                "where customer.customer_id=@custID";

                        using (SqlCommand checkBill = new SqlCommand(checkBillID, connect))
                        {
                            int customerID;
                            if (int.TryParse(Bill_CustomerID.Text.Trim(), out customerID))
                                checkBill.Parameters.AddWithValue("@custID", customerID);

                            SqlDataReader reader = checkBill.ExecuteReader();

                            while (reader.Read())
                            {

                                CustName = reader["full_name"].ToString();
                                billID = (int)reader["bill_id"];
                            }
                            reader.Close();

                        }
                        string storeName = "MR Footwear";
                        string date = DateTime.Now.ToString("dd/MM/yyyy");
                        string billText = $"{storeName}\n";
                        billText += $"Date: {date}\n";
                        billText += $"Customer: {CustName}\n";
                        billText += $"Bill No: {billID}\n\n";
                        billText += $"{"Item",-10}{"Qty",-5}{"Price",-10}{"Total",-10}\n";
                        billText += new string('-', 40) + "\n";

                        string orderInfo = "SELECT product.model_no, orders.quantity, product.price " +
                                              "from product inner join orders on product.product_id=orders.product_id " +
                                                "where orders.customer_id=@custID";

                        using (SqlCommand checkBill = new SqlCommand(orderInfo, connect))
                        {
                            int customerID;
                            if (int.TryParse(Bill_CustomerID.Text.Trim(), out customerID))
                                checkBill.Parameters.AddWithValue("@custID", customerID);

                            SqlDataReader reader = checkBill.ExecuteReader();

                            int total = 0;

                            while (reader.Read())
                            {

                                string modelNo = reader["model_no"].ToString();
                                int quan = (int)reader["quantity"];
                                string price = reader["price"].ToString();

                                int itemTotal = quan * Int32.Parse(price);
                                total += itemTotal;
                                billText += $"{modelNo,-10}{quan,-5}{price,-10:C}{itemTotal,-10:C}\n";
                            }
                            billText += new string('-', 40) + "\n";
                            billText += $"Total: {total:C}\n";
                            
                        }


                        richTextBox1.Text = billText ;
                        printbill = billText;
                    }
                    catch (Exception ex)
                    {
                        MessageBox.Show("Error: " + ex
                    , "Error Message", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    }
                    finally
                    {
                        connect.Close();
                    }
                }
            }
        }

        private void Print_Click(object sender, EventArgs e)
        {

            PrintDialog printDialog = new PrintDialog();
            PrintDocument printDocument = new PrintDocument();

            printDocument.PrintPage += new PrintPageEventHandler(printDocument1_PrintPage);
            printDialog.Document = printDocument;

            // Show the Print dialog
            if (printDialog.ShowDialog() == DialogResult.OK)
            {
                printDocument.Print();
            }
           
        }

        private void printDocument1_PrintPage(object sender, PrintPageEventArgs e)
        {
            Font printFont = new Font("Arial", 12);
            float x = e.MarginBounds.Left;
            float y = e.MarginBounds.Top;

            // Print the bill content
            e.Graphics.DrawString(printbill, printFont, Brushes.Black, x, y);
        }
    }
}
