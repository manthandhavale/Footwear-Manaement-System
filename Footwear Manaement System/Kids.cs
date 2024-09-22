using System;
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

            }
        }

        private void button2_Click(object sender, EventArgs e)
        {
            if (images.Count > 0)
            {
                currentIndex = (currentIndex + 1) % images.Count;
                DisplayCurrentImage();
            }
        }

        private void button1_Click(object sender, EventArgs e)
        {
            if (images.Count > 0)
            {
                currentIndex = (currentIndex - 1 + images.Count) % images.Count;
                DisplayCurrentImage();
            }
        }

        private void Add_TO_Cart_Click(object sender, EventArgs e)
        {
            if (string.IsNullOrWhiteSpace(addKids_ModelNo.Text) ||
      string.IsNullOrWhiteSpace(addKids_Quantity.Text) ||
      string.IsNullOrWhiteSpace(addKids_CustomerID.Text))
            {
                MessageBox.Show("Please fill all blank fields", "Error Message", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }

            if (!int.TryParse(addKids_CustomerID.Text.Trim(), out int customerID) ||
                !decimal.TryParse(addKids_Quantity.Text.Trim(), out decimal requestedQuantity))
            {
                MessageBox.Show("Invalid input for Customer ID or Quantity.", "Error Message", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }

            try
            {
                if (connect.State == ConnectionState.Closed)
                    connect.Open();

                // Check if product exists and get the current quantity
                string checkQuantityQuery = "SELECT quantity FROM product WHERE model_no = @model_no";
                decimal currentQuantity = 0;

                using (SqlCommand cmd = new SqlCommand(checkQuantityQuery, connect))
                {
                    cmd.Parameters.AddWithValue("@model_no", addKids_ModelNo.Text.Trim());
                    object result = cmd.ExecuteScalar();

                    if (result == null || result == DBNull.Value)
                    {
                        MessageBox.Show("Product not found or quantity is unavailable.", "Error Message", MessageBoxButtons.OK, MessageBoxIcon.Error);
                        return;
                    }

                    // Convert the result to decimal
                    currentQuantity = Convert.ToDecimal(result);
                }

                // Check if the requested quantity exceeds the available quantity
                if (requestedQuantity > currentQuantity)
                {
                    MessageBox.Show("Insufficient stock available. Please enter a smaller quantity.", "Error Message", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    return;
                }

                // Check if the operation will make the stock zero
                if (requestedQuantity == currentQuantity)
                {
                    MessageBox.Show("The requested quantity will exhaust the available stock.", "Warning Message", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    return;
                }

                // Proceed with your logic if quantity is sufficient
                string checkCustID = "SELECT COUNT(*) FROM bill WHERE customer_id = @custID";
                int count = 0;

                using (SqlCommand checkCust = new SqlCommand(checkCustID, connect))
                {
                    checkCust.Parameters.AddWithValue("@custID", customerID);
                    count = Convert.ToInt32(checkCust.ExecuteScalar());
                }

                // Retrieve product price
                string getPrice = "SELECT price FROM product WHERE model_no = @model_no";
                decimal price = 0;

                using (SqlCommand cmd = new SqlCommand(getPrice, connect))
                {
                    cmd.Parameters.AddWithValue("@model_no", addKids_ModelNo.Text.Trim());
                    object result = cmd.ExecuteScalar();

                    if (result == null || result == DBNull.Value)
                    {
                        MessageBox.Show("Price not found for the specified product.", "Error Message", MessageBoxButtons.OK, MessageBoxIcon.Error);
                        return;
                    }

                    // Convert the result to decimal
                    price = Convert.ToDecimal(result);
                }

                decimal totalAmount = requestedQuantity * price;

                // Update or insert into bill table
                string billQuery = count > 0
                    ? "UPDATE bill SET total_amount = total_amount + @total_amt WHERE customer_id = @customerID"
                    : "INSERT INTO bill (customer_id, total_amount) VALUES (@customerID, @total_amt)";

                using (SqlCommand cmd = new SqlCommand(billQuery, connect))
                {
                    cmd.Parameters.AddWithValue("@customerID", customerID);
                    cmd.Parameters.AddWithValue("@total_amt", totalAmount);
                    cmd.ExecuteNonQuery();
                }

                // Retrieve product ID
                string getProductID = "SELECT product_id FROM product WHERE model_no = @model_no";
                int productID = 0;

                using (SqlCommand cmd = new SqlCommand(getProductID, connect))
                {
                    cmd.Parameters.AddWithValue("@model_no", addKids_ModelNo.Text.Trim());
                    object result = cmd.ExecuteScalar();

                    if (result == null || result == DBNull.Value)
                    {
                        MessageBox.Show("Product ID not found.", "Error Message", MessageBoxButtons.OK, MessageBoxIcon.Error);
                        return;
                    }

                    productID = Convert.ToInt32(result);
                }

                // Insert into orders table
                string addOrder = "INSERT INTO orders (customer_id, product_id, Quantity) VALUES (@customerID, @productID, @Quantity)";
                using (SqlCommand cmd = new SqlCommand(addOrder, connect))
                {
                    cmd.Parameters.AddWithValue("@customerID", customerID);
                    cmd.Parameters.AddWithValue("@productID", productID);
                    cmd.Parameters.AddWithValue("@Quantity", requestedQuantity);
                    cmd.ExecuteNonQuery();
                }

                // Update product quantity
                string updateProduct = "UPDATE product SET quantity = quantity - @quantity WHERE model_no = @model_no";
                using (SqlCommand cmd = new SqlCommand(updateProduct, connect))
                {
                    cmd.Parameters.AddWithValue("@quantity", requestedQuantity);
                    cmd.Parameters.AddWithValue("@model_no", addKids_ModelNo.Text.Trim());
                    cmd.ExecuteNonQuery();
                }

                MessageBox.Show("Operation completed successfully!", "Information Message", MessageBoxButtons.OK, MessageBoxIcon.Information);
                clearFields();
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error: " + ex.Message, "Error Message", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            finally
            {
                if (connect.State == ConnectionState.Open)
                    connect.Close();
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
