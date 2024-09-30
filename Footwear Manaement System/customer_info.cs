using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Data.SqlClient;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Footwear_Manaement_System
{
    public partial class customer_info : UserControl
    {
        SqlConnection connect = new SqlConnection(@"Data Source=MANTHAN\SQLEXPRESS;Initial Catalog=FootwareManagementSystem;Integrated Security=True;TrustServerCertificate=True");


        public customer_info()
        {
            InitializeComponent();

            displayCustomerData();
            disableFields();
        }
        public void RefreshData()
        {
            if (InvokeRequired)
            {
                Invoke((MethodInvoker)RefreshData);
                return;
            }
            displayCustomerData();
            disableFields();
        }
        public void displayCustomerData()
        {
            CustomerData cd = new CustomerData();
            List<CustomerData> listData = cd.CustomerListData();

            dataGridView1.DataSource = listData;
        }
        public void disableFields()
        {
            addCustomer_id.Enabled = false;
        }
        private void label6_Click(object sender, EventArgs e)
        {

        }

        private void addCustomer_addBtn_Click(object sender, EventArgs e)
        {
            if (
                   addCustomer_fullName.Text == ""
                  || addCustomer_Address.Text == ""
                  || addCustomer_phoneNum.Text == ""
                  || addCustomer_Email.Text == "")
            {
                MessageBox.Show("Please fill all blank fields"
                    , "Error Message", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            else if (!System.Text.RegularExpressions.Regex.IsMatch(addCustomer_phoneNum.Text.Trim(), @"^\d{10}$"))
            {
                MessageBox.Show("Phone number must be exactly 10 digits.", "Error Message", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            else if (!System.Text.RegularExpressions.Regex.IsMatch(addCustomer_fullName.Text.Trim(), @"^[a-zA-Z\s]+$"))
            {
                MessageBox.Show("Full name should not contain special characters or numbers.", "Error Message", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            else
            {
                if (connect.State == ConnectionState.Closed)
                {
                    try
                    {
                        connect.Open();

                        DateTime today = DateTime.Today;
                        string insertData = "INSERT INTO customer " +
                                            "(full_name, address, contact_number, email, bill, insert_date) " +
                                            "VALUES(@fullName, @address, @contactNum, @email, @bill, @insertDate)";

                        using (SqlCommand cmd = new SqlCommand(insertData, connect))
                        {
                            cmd.Parameters.AddWithValue("@fullName", addCustomer_fullName.Text.Trim());
                            cmd.Parameters.AddWithValue("@address", addCustomer_Address.Text.Trim());
                            cmd.Parameters.AddWithValue("@contactNum", addCustomer_phoneNum.Text.Trim());
                            cmd.Parameters.AddWithValue("@email", addCustomer_Email.Text.Trim());
                            cmd.Parameters.AddWithValue("@bill", 0);
                            cmd.Parameters.AddWithValue("@insertDate", today);

                            cmd.ExecuteNonQuery();

                            displayCustomerData();

                            MessageBox.Show("Added successfully!", "Information Message", MessageBoxButtons.OK, MessageBoxIcon.Information);

                            clearFields();
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

        private void dataGridView1_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {
            if (e.RowIndex != -1)
            {
                DataGridViewRow row = dataGridView1.Rows[e.RowIndex];
                addCustomer_id.Text = row.Cells[0].Value.ToString();
                addCustomer_fullName.Text = row.Cells[1].Value.ToString();
                addCustomer_Address.Text = row.Cells[2].Value.ToString();
                addCustomer_phoneNum.Text = row.Cells[3].Value.ToString();
                addCustomer_Email.Text = row.Cells[4].Value.ToString();

            }
        }

        public void clearFields()
        {
            addCustomer_id.Text = "";
            addCustomer_fullName.Text = "";
            addCustomer_Address.Text = "";
            addCustomer_phoneNum.Text = "";
            addCustomer_Email.Text = "";

        }

        private void addCustomer_clearBtn_Click(object sender, EventArgs e)
        {
            clearFields();
        }

        private void addCustomer_updateBtn_Click(object sender, EventArgs e)
        {
            if (addCustomer_id.Text == ""
                 || addCustomer_fullName.Text == ""
                 || addCustomer_Address.Text == ""
                 || addCustomer_phoneNum.Text == ""
                 || addCustomer_Email.Text == ""
                 )
            {
                MessageBox.Show("Please fill all blank fields"
                    , "Error Message", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            else if (!System.Text.RegularExpressions.Regex.IsMatch(addCustomer_phoneNum.Text.Trim(), @"^\d{10}$"))
            {
                MessageBox.Show("Phone number must be exactly 10 digits.", "Error Message", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            else if (!System.Text.RegularExpressions.Regex.IsMatch(addCustomer_fullName.Text.Trim(), @"^[a-zA-Z\s]+$"))
            {
                MessageBox.Show("Full name should not contain special characters or numbers.", "Error Message", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            else
            {
                DialogResult check = MessageBox.Show("Are you sure you want to UPDATE " +
                    "Customer ID: " + addCustomer_id.Text.Trim() + "?", "Confirmation Message"
                    , MessageBoxButtons.YesNo, MessageBoxIcon.Information);

                if (check == DialogResult.Yes)
                {
                    try
                    {
                        connect.Open();
                        DateTime today = DateTime.Today;

                        string updateData = "UPDATE  customer SET" +
                                           " full_name = @fullName, address = @address," +
                                           "contact_number = @contactNum," +
                                           " email = @email " +
                                           "Where customer_id = @customerID";

                        using (SqlCommand cmd = new SqlCommand(updateData, connect))
                        {
                            cmd.Parameters.AddWithValue("@customerID", addCustomer_id.Text.Trim());
                            cmd.Parameters.AddWithValue("@fullName", addCustomer_fullName.Text.Trim());
                            cmd.Parameters.AddWithValue("@address", addCustomer_Address.Text.Trim());
                            cmd.Parameters.AddWithValue("@contactNum", addCustomer_phoneNum.Text.Trim());
                            cmd.Parameters.AddWithValue("@email", addCustomer_Email.Text.Trim());
                            cmd.Parameters.AddWithValue("@insertDate", today);

                            cmd.ExecuteNonQuery();

                            displayCustomerData();

                            MessageBox.Show("Update successfully!"
                                , "Information Message", MessageBoxButtons.OK, MessageBoxIcon.Information);

                            clearFields();
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
                else
                {
                    MessageBox.Show("Cancelled."
                        , "Information Message", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                }

            }
        }

      
    }

}
