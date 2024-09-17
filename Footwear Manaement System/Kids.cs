﻿using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Data.SqlClient;
using System.Drawing;
using System.Linq;
using System.Runtime.Remoting.Contexts;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Footwear_Manaement_System
{


    public partial class Kids : UserControl
    {
        SqlConnection connect = new SqlConnection(@"Data Source=MANTHAN\SQLEXPRESS;Initial Catalog=FootwareManagementSystem;Integrated Security=True;TrustServerCertificate=True");

        List<string> images;
        int currentIndex = 0;
        public Kids()
        {
            InitializeComponent();
            InitializeImagePaths();
            DisplayCurrentImage();
        }

        private void InitializeImagePaths()
        {
            // Initialize the list of image paths. 
            // Adjust the paths according to your images' location.
            images = new List<string>
            {
                @"C:\Users\lenovo\source\repos\Footwear Manaement System\Footwear Manaement System\Resources\kids\1.jpg",
                @"C:\Users\lenovo\source\repos\Footwear Manaement System\Footwear Manaement System\Resources\kids\2.jpg",
                @"C:\Users\lenovo\source\repos\Footwear Manaement System\Footwear Manaement System\Resources\kids\3.jpg",
                @"C:\Users\lenovo\source\repos\Footwear Manaement System\Footwear Manaement System\Resources\kids\4.jpg",
                @"C:\Users\lenovo\source\repos\Footwear Manaement System\Footwear Manaement System\Resources\kids\5.jpg",
                @"C:\Users\lenovo\source\repos\Footwear Manaement System\Footwear Manaement System\Resources\kids\6.jpg",
                @"C:\Users\lenovo\source\repos\Footwear Manaement System\Footwear Manaement System\Resources\kids\7.jpg",
                @"C:\Users\lenovo\source\repos\Footwear Manaement System\Footwear Manaement System\Resources\kids\8.jpg",

                @"C:\Users\lenovo\source\repos\Footwear Manaement System\Footwear Manaement System\Resources\kids\10.jpg",
                @"C:\Users\lenovo\source\repos\Footwear Manaement System\Footwear Manaement System\Resources\kids\11.jpg",
                @"C:\Users\lenovo\source\repos\Footwear Manaement System\Footwear Manaement System\Resources\kids\12.jpg",
                @"C:\Users\lenovo\source\repos\Footwear Manaement System\Footwear Manaement System\Resources\kids\13.jpg",
                @"C:\Users\lenovo\source\repos\Footwear Manaement System\Footwear Manaement System\Resources\kids\14.jpg",
                @"C:\Users\lenovo\source\repos\Footwear Manaement System\Footwear Manaement System\Resources\kids\15.jpg",

            };
            currentIndex = 0; // Start with the first image
        }

        private void DisplayCurrentImage()
        {
            if (images.Count > 0)
            {
                pictureBox1.Image = Image.FromFile(images[currentIndex]);
                // Optionally, update a label or listbox here
                // listBox1.SelectedItem = _imagePaths[_currentIndex];
            }
        }

        private void button2_Click(object sender, EventArgs e)
        {
            if (images.Count > 0)
            {
                currentIndex = (currentIndex + 1) % images.Count; // Move to the next image
                DisplayCurrentImage();
            }
        }

        private void button1_Click(object sender, EventArgs e)
        {
            if (images.Count > 0)
            {
                currentIndex = (currentIndex - 1 + images.Count) % images.Count; // Move to the previous image
                DisplayCurrentImage();
            }
        }

        private void Add_TO_Cart_Click(object sender, EventArgs e)
        {
            if (addKids_ModelNo.Text == ""
             || addKids_Quantity.Text == ""
             || addKids_CustomerID.Text == ""
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
                            int count = 0;
                            string checkCustID = "SELECT COUNT(*) FROM bill  WHERE customer_id = @custID ";

                            using (SqlCommand checkCust = new SqlCommand(checkCustID, connect))
                            {
                                int customerID;
                                if (int.TryParse(addKids_CustomerID.Text.Trim(), out customerID))
                                    checkCust.Parameters.AddWithValue("@custID", customerID);


                                count = (int)checkCust.ExecuteScalar();
                            }

                            int price = 0;
                            string GetPrice = "Select price from product where model_no = @model_no";
                            using (SqlCommand cmd = new SqlCommand(GetPrice, connect))
                            {

                                cmd.Parameters.AddWithValue("@model_no", addKids_ModelNo.Text.Trim());

                                price = (int)cmd.ExecuteScalar();

                            }
                            decimal quantity, totalAmount;
                            if (decimal.TryParse(addKids_Quantity.Text.Trim(), out quantity))
                            {
                                totalAmount = quantity * price;
                            }
                            else
                            {
                                MessageBox.Show("Invalid input for quantity or price.", "Error Message", MessageBoxButtons.OK, MessageBoxIcon.Error);
                                return;
                            }

                            if (count > 0)
                            {
                                DateTime today = DateTime.Today;
                                string insertData = "update bill set total_amount=total_amount + @total_amt where customer_id=@customerID";



                                using (SqlCommand cmd = new SqlCommand(insertData, connect))
                                {
                                    cmd.Parameters.AddWithValue("@customerID", addKids_CustomerID.Text.Trim());
                                    cmd.Parameters.AddWithValue("@total_amt", totalAmount);

                                    cmd.ExecuteNonQuery();

                                    MessageBox.Show("Added successfully!"
                                        , "Information Message", MessageBoxButtons.OK, MessageBoxIcon.Information);

                                    clearFields();
                                }
                            }
                            else
                            {
                                DateTime today = DateTime.Today;
                                string insertData = "INSERT INTO bill " +
                                    "(customer_id,total_amount)" +
                                    "values(@customerID,@total_amt)";

                                using (SqlCommand cmd = new SqlCommand(insertData, connect))
                                {
                                    cmd.Parameters.AddWithValue("@customerID", addKids_CustomerID.Text.Trim());
                                    cmd.Parameters.AddWithValue("@total_amt", totalAmount);

                                    cmd.ExecuteNonQuery();

                                    MessageBox.Show("Added successfully!"
                                        , "Information Message", MessageBoxButtons.OK, MessageBoxIcon.Information);

                                    clearFields();
                                }


                            }
                            int productno = 0;
                            string GetProductID = "Select product_id from product where model_no = @model_no";
                            using (SqlCommand cmd = new SqlCommand(GetProductID, connect))
                            {

                                cmd.Parameters.AddWithValue("@model_no", addKids_ModelNo.Text.Trim());

                                productno = (int)cmd.ExecuteScalar();

                            }

                            string AddOrder = "INSERT INTO orders " +
                                   "(customer_id,product_id,Quantity)" +
                               "values(@customerID,@product_id,@Quantity)";

                            using (SqlCommand cmd = new SqlCommand(AddOrder, connect))
                            {
                                cmd.Parameters.AddWithValue("@customerID", addKids_CustomerID.Text.Trim());
                                cmd.Parameters.AddWithValue("@product_id", productno);
                                cmd.Parameters.AddWithValue("@Quantity", addKids_Quantity.Text.Trim());

                                cmd.ExecuteNonQuery();

                            }


                            string updateData = "update product set quantity=quantity - @quantity where model_no=@model_no";

                            using (SqlCommand cmd = new SqlCommand(updateData, connect))
                            {
                                int Quantity;
                                int.TryParse(addKids_Quantity.Text.Trim(), out Quantity);

                                cmd.Parameters.AddWithValue("@model_no", addKids_ModelNo.Text.Trim());
                                cmd.Parameters.AddWithValue("@quantity", quantity);

                                cmd.ExecuteNonQuery();

                                MessageBox.Show("update  successfully!"
                                    , "Information Message", MessageBoxButtons.OK, MessageBoxIcon.Information);

                                clearFields();
                            }
                    }
                    catch (Exception ex)
                    {
                        MessageBox.Show("Error: " + ex.Message
                    , "Error Message", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    }
                    finally
                    {
                        connect.Close();
                    }
                }

            }

        }
        public void clearFields()
        {
            addKids_CustomerID.Text = "";
            addKids_ModelNo.Text = "";
            addKids_Quantity.Text = "";

        }

        private void clearBtn_Click(object sender, EventArgs e)
        {
            clearFields();
        }
    }

}
