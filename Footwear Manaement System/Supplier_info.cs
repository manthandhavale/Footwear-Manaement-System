﻿using System;
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
    public partial class Supplier_info : UserControl
    {
        SqlConnection connect = new SqlConnection(@"Data Source=MANTHAN\SQLEXPRESS;Initial Catalog=FootwareManagementSystem;Integrated Security=True;TrustServerCertificate=True");
        public Supplier_info()
        {
            InitializeComponent();

            displaySupplierData();
            disableFields();
        }

        public void RefreshData()
        {
            if (InvokeRequired)
            {
                Invoke((MethodInvoker)RefreshData);
                return;
            }
            displaySupplierData();
            disableFields();
        }
        public void displaySupplierData()
        {
            SupplierData sd = new SupplierData();
            List<SupplierData> listData = sd.SupplierListData();

            dataGridView1.DataSource = listData;
        }
        public void disableFields()
        {
            addSupplier_id.Enabled = false;
        }
        private void addSupplier_addBtn_Click(object sender, EventArgs e)
        {
            if (
                  addSupplier_fullName.Text == ""
                 || addSupplier_Address.Text == ""
                 || addSupplier_phoneNum.Text == ""
                 || addSupplier_Email.Text == ""
                 ||addSupplier_Order.Text=="")
            {
                MessageBox.Show("Please fill all blank fields"
                    , "Error Message", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            else if (!System.Text.RegularExpressions.Regex.IsMatch(addSupplier_phoneNum.Text.Trim(), @"^\d{10}$"))
            {
                MessageBox.Show("Phone number must be exactly 10 digits.", "Error Message", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            else if (!System.Text.RegularExpressions.Regex.IsMatch(addSupplier_fullName.Text.Trim(), @"^[a-zA-Z\s]+$"))
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
                        string insertData = "INSERT INTO supplier " +
                                            "(full_name, address, contact_number, email, order_details, insert_date) " +
                                            "VALUES(@fullName, @address, @contactNum, @email, @order, @insertDate)";

                        using (SqlCommand cmd = new SqlCommand(insertData, connect))
                        {
                            cmd.Parameters.AddWithValue("@fullName", addSupplier_fullName.Text.Trim());
                            cmd.Parameters.AddWithValue("@address", addSupplier_Address.Text.Trim());
                            cmd.Parameters.AddWithValue("@contactNum", addSupplier_phoneNum.Text.Trim());
                            cmd.Parameters.AddWithValue("@email", addSupplier_Email.Text.Trim());
                            cmd.Parameters.AddWithValue("@order", addSupplier_Order.Text.Trim());
                            cmd.Parameters.AddWithValue("@insertDate", today);

                            cmd.ExecuteNonQuery();

                            displaySupplierData();

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
                addSupplier_id.Text = row.Cells[0].Value.ToString();
                addSupplier_fullName.Text = row.Cells[1].Value.ToString();
                addSupplier_Address.Text = row.Cells[2].Value.ToString();
                addSupplier_phoneNum.Text = row.Cells[3].Value.ToString();
                addSupplier_Email.Text = row.Cells[4].Value.ToString();
                addSupplier_Order.Text=row.Cells[5].Value.ToString();

            }
        }
        public void clearFields()
        {
            addSupplier_id.Text = "";
            addSupplier_fullName.Text = "";
            addSupplier_Address.Text = "";
            addSupplier_phoneNum.Text = "";
            addSupplier_Email.Text = "";
            addSupplier_Order.Text = "";

        }

        private void addSupplier_clearBtn_Click(object sender, EventArgs e)
        {
            clearFields();
        }

        private void addSupplier_updateBtn_Click(object sender, EventArgs e)
        {
            if (addSupplier_id.Text == ""
               || addSupplier_fullName.Text == ""
               || addSupplier_Address.Text == ""
               || addSupplier_phoneNum.Text == ""
               || addSupplier_Email.Text == ""
               || addSupplier_Order.Text==""
                    )
            {
                MessageBox.Show("Please fill all blank fields"
                    , "Error Message", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            else if (!System.Text.RegularExpressions.Regex.IsMatch(addSupplier_phoneNum.Text.Trim(), @"^\d{10}$"))
            {
                MessageBox.Show("Phone number must be exactly 10 digits.", "Error Message", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            else if (!System.Text.RegularExpressions.Regex.IsMatch(addSupplier_fullName.Text.Trim(), @"^[a-zA-Z\s]+$"))
            {
                MessageBox.Show("Full name should not contain special characters or numbers.", "Error Message", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            else
            {
                DialogResult check = MessageBox.Show("Are you sure you want to UPDATE " +
                    "Supplier ID: " + addSupplier_id.Text.Trim() + "?", "Confirmation Message"
                    , MessageBoxButtons.YesNo, MessageBoxIcon.Information);

                if (check == DialogResult.Yes)
                {
                    try
                    {
                        connect.Open();
                        DateTime today = DateTime.Today;

                        string updateData = "UPDATE  supplier SET " +
                                   "full_name = @fullName" +
                                   ",address =  @address, contact_number = @contactNum" +
                                   ",email =  @email , order_details =  @order  " +
                                   "WHERE supplier_id = @supplierID";
                                  

                        using (SqlCommand cmd = new SqlCommand(updateData, connect))
                        {
                            cmd.Parameters.AddWithValue("@supplierID", addSupplier_id.Text.Trim());
                            cmd.Parameters.AddWithValue("@fullName", addSupplier_fullName.Text.Trim());
                            cmd.Parameters.AddWithValue("@address", addSupplier_Address.Text.Trim());
                            cmd.Parameters.AddWithValue("@contactNum", addSupplier_phoneNum.Text.Trim());
                            cmd.Parameters.AddWithValue("@email", addSupplier_Email.Text.Trim());
                            cmd.Parameters.AddWithValue("@order", addSupplier_Order.Text.Trim());
                            cmd.Parameters.AddWithValue("@insertDate", today);

                            cmd.ExecuteNonQuery();

                            displaySupplierData();

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
