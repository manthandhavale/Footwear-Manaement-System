using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Data.SqlClient;
using System.Drawing;
using System.Drawing.Printing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Footwear_Manaement_System
{
    public partial class BillSearch : UserControl
    {
        SqlConnection connect = new SqlConnection(@"Data Source=MANTHAN\SQLEXPRESS;Initial Catalog=FootwareManagementSystem;Integrated Security=True;TrustServerCertificate=True");


        String printbill = string.Empty;
        public BillSearch()
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
            Bill_CustomerID.Enabled = false;
            Bill_Address.Enabled = false;
            Bill_Email.Enabled = false;
            Bill_name.Enabled = true;
            Bill_PhoneNo.Enabled = true;
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
        private void Bill_name_TextChanged(object sender, EventArgs e)
        {

        }

        private void label6_Click(object sender, EventArgs e)
        {

        }

        private void button2_Click(object sender, EventArgs e)
        {
            if (Bill_name.Text == "" && Bill_PhoneNo.Text == "")
            {
                MessageBox.Show("Please fill in either the Name or Phone Number fields.", "Error Message", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            else
            {
                if (connect.State == ConnectionState.Closed)
                {
                    try
                    {
                        connect.Open();
                        string checkBillID = "SELECT customer.full_name, customer.address, customer.email, customer.contact_number, customer.Customer_id,bill.total_amount " +
                                             "FROM customer " +
                                             "INNER JOIN bill ON customer.customer_id = bill.customer_id " +
                                             "WHERE (@custName IS NULL OR customer.full_name = @custName) " +
                                             "AND (@custPhone IS NULL OR customer.contact_number = @custPhone)";

                        using (SqlCommand checkBill = new SqlCommand(checkBillID, connect))
                        {
                            checkBill.Parameters.AddWithValue("@custName", string.IsNullOrEmpty(Bill_name.Text.Trim()) ? (object)DBNull.Value : Bill_name.Text.Trim());
                            checkBill.Parameters.AddWithValue("@custPhone", string.IsNullOrEmpty(Bill_PhoneNo.Text.Trim()) ? (object)DBNull.Value : Bill_PhoneNo.Text.Trim());

                            SqlDataReader reader = checkBill.ExecuteReader();

                            if (reader.HasRows)
                            {
                                while (reader.Read())
                                {
                                    Bill_name.Text = reader["full_name"].ToString();
                                    Bill_Address.Text = reader["address"].ToString();
                                    Bill_PhoneNo.Text = reader["contact_number"].ToString();
                                    Bill_Email.Text = reader["email"].ToString();
                                    Bill_CustomerID.Text = reader["Customer_id "].ToString();

                                    Total_Amount.Text = reader["total_amount"].ToString();
                                }
                            }
                            else
                            {
                                MessageBox.Show("No customer found with the provided details.", "Information", MessageBoxButtons.OK, MessageBoxIcon.Information);
                            }
                        }
                    }
                    catch (Exception ex)
                    {
                        MessageBox.Show("Error: " + ex.Message, "Error Message", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    }
                    finally
                    {
                        connect.Close();
                    }
                }
            }

        }

        private void Bill_generate_Click(object sender, EventArgs e)
        {
            string CustName = string.Empty;
            int billID = 0;

            if (string.IsNullOrEmpty(Bill_name.Text) && string.IsNullOrEmpty(Bill_PhoneNo.Text))
            {
                MessageBox.Show("Please enter either the Customer Name or Phone Number.", "Error Message", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            else
            {
                if (connect.State == ConnectionState.Closed)
                {
                    try
                    {
                        connect.Open();

                        // Query to find customer by name or phone number
                        string checkBillID = "SELECT customer.full_name, bill.bill_id " +
                                             "FROM customer " +
                                             "INNER JOIN bill ON customer.customer_id = bill.customer_id " +
                                             "WHERE (@custName IS NULL OR customer.full_name = @custName) " +
                                             "AND (@custPhone IS NULL OR customer.contact_number = @custPhone)";

                        using (SqlCommand checkBill = new SqlCommand(checkBillID, connect))
                        {
                            checkBill.Parameters.AddWithValue("@custName", string.IsNullOrEmpty(Bill_name.Text.Trim()) ? (object)DBNull.Value : Bill_name.Text.Trim());
                            checkBill.Parameters.AddWithValue("@custPhone", string.IsNullOrEmpty(Bill_PhoneNo.Text.Trim()) ? (object)DBNull.Value : Bill_PhoneNo.Text.Trim());

                            SqlDataReader reader = checkBill.ExecuteReader();

                            if (reader.HasRows)
                            {
                                while (reader.Read())
                                {
                                    CustName = reader["full_name"].ToString();
                                    billID = (int)reader["bill_id"];
                                }
                            }
                            else
                            {
                                MessageBox.Show("No customer found with the provided details.", "Information", MessageBoxButtons.OK, MessageBoxIcon.Information);
                                return;
                            }
                            reader.Close();
                        }

                        // Proceed to generate the bill information
                        string storeName = "MR Footwear";
                        string date = DateTime.Now.ToString("dd/MM/yyyy");
                        string billText = $"{storeName}\n";
                        billText += $"Date: {date}\n";
                        billText += $"Customer: {CustName}\n";
                        billText += $"Bill No: {billID}\n\n";
                        billText += $"{"Item",-10}{"Qty",-5}{"Price",-10}{"Total",-10}\n";
                        billText += new string('-', 40) + "\n";

                        // Fetch order information
                        string orderInfo = "SELECT product.model_no, orders.quantity, product.price " +
                                           "FROM product " +
                                           "INNER JOIN orders ON product.product_id = orders.product_id " +
                                           "WHERE orders.customer_id = @custID";

                        using (SqlCommand orderCmd = new SqlCommand(orderInfo, connect))
                        {
                            orderCmd.Parameters.AddWithValue("@custID", billID); // Assuming billID is the same as customerID here

                            SqlDataReader orderReader = orderCmd.ExecuteReader();
                            int total = 0;

                            while (orderReader.Read())
                            {
                                string modelNo = orderReader["model_no"].ToString();
                                int quan = (int)orderReader["quantity"];
                                int price = Convert.ToInt32(orderReader["price"]);

                                int itemTotal = quan * price;
                                total += itemTotal;
                                billText += $"{modelNo,-10}{quan,-5}{price,-10:C}{itemTotal,-10:C}\n";
                            }
                            billText += new string('-', 40) + "\n";
                            billText += $"Total: {total:C}\n";
                            orderReader.Close();
                        }

                        richTextBox1.Text = billText;
                        printbill = billText;
                    }
                    catch (Exception ex)
                    {
                        MessageBox.Show("Error: " + ex.Message, "Error Message", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    }
                    finally
                    {
                        connect.Close();
                    }
                }
            }

        }

        private void printDocument1_PrintPage(object sender, System.Drawing.Printing.PrintPageEventArgs e)
        {
            Font printFont = new Font("Arial", 12);
            float x = e.MarginBounds.Left;
            float y = e.MarginBounds.Top;

            // Print the bill content
            e.Graphics.DrawString(printbill, printFont, Brushes.Black, x, y);
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

        private void clearBtn_Click(object sender, EventArgs e)
        {
            clearFields();
        }

        private void richTextBox1_TextChanged(object sender, EventArgs e)
        {

        }
    }
    
}
