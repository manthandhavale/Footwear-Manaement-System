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
    public partial class warehouse : UserControl
    {
        SqlConnection connect = new SqlConnection(@"Data Source=MANTHAN\SQLEXPRESS;Initial Catalog=FootwareManagementSystem;Integrated Security=True;TrustServerCertificate=True");
        public warehouse()
        {
            InitializeComponent();

            displayWarehouseData();
        }
        public void RefreshData()
        {
            if (InvokeRequired)
            {
                Invoke((MethodInvoker)RefreshData);
                return;
            }
            displayWarehouseData();
        }
        public void displayWarehouseData()
        {
            WarehouseData wd = new WarehouseData();
            List<WarehouseData> listData = wd.warehouseListData();

            dataGridView1.DataSource = listData;
        }

        private void addStock_addBtn_Click(object sender, EventArgs e)
        {
            if (addProduct_id.Text == ""
             || addModel_No.Text == ""
             || addCategory.Text == ""
             || addPrice.Text == ""
             || addSize.Text == ""
             || addBrand.Text == ""
             || addProduct_picture.Image == null)
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
                        string checkProID = "SELECT COUNT(*) FROM product WHERE product_id = @proID AND delete_date IS NULL";

                        using (SqlCommand checkPro = new SqlCommand(checkProID, connect))
                        {
                            checkPro.Parameters.AddWithValue("@proID", addProduct_id.Text.Trim());
                            int count = (int)checkPro.ExecuteScalar();

                            if (count >= 1)
                            {
                                MessageBox.Show(addProduct_id.Text.Trim() + " is already taken"
                                    , "Error Message", MessageBoxButtons.OK, MessageBoxIcon.Error);
                            }
                            else
                            {
                                DateTime today = DateTime.Today;
                                string insertData = "INSERT INTO product " +
                                    "(  product_id, model_no,category, price" +
                                    ",size, image, brand, insert_date,quantity) " +
                                    "VALUES(@productID, @model_no, @category, @price" +
                                    ", @size, @image, @brand, @insertDate,@qunt)";

                                string path = Path.Combine(@"C:\Users\lenovo\source\repos\Footwear Manaement System\Footwear Manaement System\Product"
                                    + addProduct_id.Text.Trim() + ".jpg");

                                string directoryPath = Path.GetDirectoryName(path);

                                if (!Directory.Exists(directoryPath))
                                {
                                    Directory.CreateDirectory(directoryPath);
                                }

                                File.Copy(addProduct_picture.ImageLocation, path, true);

                                using (SqlCommand cmd = new SqlCommand(insertData, connect))
                                {
                                    cmd.Parameters.AddWithValue("@productID", addProduct_id.Text.Trim());
                                    cmd.Parameters.AddWithValue("@model_no", addModel_No.Text.Trim());
                                    cmd.Parameters.AddWithValue("@category", addCategory.Text.Trim());
                                    cmd.Parameters.AddWithValue("@brand", addBrand.Text.Trim());
                                    cmd.Parameters.AddWithValue("@price", addPrice.Text.Trim());
                                    cmd.Parameters.AddWithValue("@image", path);
                                    cmd.Parameters.AddWithValue("@size", addSize.Text.Trim());
                                    cmd.Parameters.AddWithValue("@insertDate", today);
                                    cmd.Parameters.AddWithValue("@qunt", addQuantity.Text.Trim());


                                    cmd.ExecuteNonQuery();

                                    displayWarehouseData();

                                    MessageBox.Show("Added successfully!"
                                        , "Information Message", MessageBoxButtons.OK, MessageBoxIcon.Information);

                                    clearFields();
                                }
                            }
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

        private void addStock_importBtn_Click(object sender, EventArgs e)
        {
            try
            {
                OpenFileDialog dialog = new OpenFileDialog();
                dialog.Filter = "Image Files (*.jpg; *.png)|*.jpg;*.png";
                string imagePath = "";
                if (dialog.ShowDialog() == DialogResult.OK)
                {
                    imagePath = dialog.FileName;
                    addProduct_picture.ImageLocation = imagePath;
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error: " + ex.Message, "Error Message"
                    , MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void dataGridView1_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {
            if (e.RowIndex != -1)
            {
                DataGridViewRow row = dataGridView1.Rows[e.RowIndex];
                addProduct_id.Text = row.Cells[0].Value.ToString();
                addModel_No.Text = row.Cells[1].Value.ToString();
                addCategory.Text = row.Cells[2].Value.ToString();
                addPrice.Text = row.Cells[3].Value.ToString();
                addSize.Text = row.Cells[4].Value.ToString();
                addBrand.Text = row.Cells[6].Value.ToString();
                addQuantity.Text= row.Cells[7].Value.ToString();
                string imagePath = row.Cells[5].Value.ToString();

                if (imagePath != null)
                {
                    addProduct_picture.Image = Image.FromFile(imagePath);
                }
                else
                {
                    addProduct_picture.Image = null;
                }

            }
        }
        public void clearFields()
        {
            addProduct_id.Text = "";
            addModel_No.Text = "";
            addCategory.SelectedIndex = -1;
            addPrice.Text = "";
            addSize.SelectedIndex = -1;
            addBrand.SelectedIndex = -1;
            addProduct_picture.Image = null;
            addQuantity.Text = "";
        }

        private void addStock_updateBtn_Click(object sender, EventArgs e)
        {
            if (addProduct_id.Text == ""
            || addModel_No.Text == ""
            || addCategory.Text == ""
            || addPrice.Text == ""
            || addSize.Text == ""
            || addBrand.Text == ""
            || addProduct_picture.Image == null
            || addQuantity.Text=="")
            {
                MessageBox.Show("Please fill all blank fields"
                    , "Error Message", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            else
            {
                DialogResult check = MessageBox.Show("Are you sure you want to UPDATE " +
                    "Product ID: " + addProduct_id.Text.Trim() + "?", "Confirmation Message"
                    , MessageBoxButtons.YesNo, MessageBoxIcon.Information);

                if (check == DialogResult.Yes)
                {
                    try
                    {
                        connect.Open();
                        DateTime today = DateTime.Today;

                        string updateData = "UPDATE product SET model_no = @model_no" +
                                            ", category = @category, price = @price, size = @size, quantity = @qunt" +
                                            ", brand = @brand, update_date = @updateDate " + 
                                             "WHERE product_id = @productID";


                        using (SqlCommand cmd = new SqlCommand(updateData, connect))
                        {
                            cmd.Parameters.AddWithValue("@model_no", addModel_No.Text.Trim());
                            cmd.Parameters.AddWithValue("@category", addCategory.Text.Trim());
                            cmd.Parameters.AddWithValue("@price", addPrice.Text.Trim());
                            cmd.Parameters.AddWithValue("@size", addSize.Text.Trim());
                            cmd.Parameters.AddWithValue("@updateDate", today);
                            cmd.Parameters.AddWithValue("@brand", addBrand.Text.Trim());
                            cmd.Parameters.AddWithValue("@productID", addProduct_id.Text.Trim());
                            cmd.Parameters.AddWithValue("@qunt",addQuantity.Text.Trim());

                            cmd.ExecuteNonQuery();

                            displayWarehouseData();

                            MessageBox.Show("Update successfully!"
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
                else
                {
                    MessageBox.Show("Cancelled."
                        , "Information Message", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                }

            }
        }

        private void addStock_clearBtn_Click(object sender, EventArgs e)
        {
            clearFields();
        }

        private void addStock_deleteBtn_Click(object sender, EventArgs e)
        {
            if (addProduct_id.Text == ""
           || addModel_No.Text == ""
           || addCategory.Text == ""
           || addPrice.Text == ""
           || addSize.Text == ""
           || addBrand.Text == ""
           || addProduct_picture.Image == null)
            {
                MessageBox.Show("Please fill all blank fields"
                    , "Error Message", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            else
            {
                DialogResult check = MessageBox.Show("Are you sure you want to DELETE " +
                    "Product ID: " + addProduct_id.Text.Trim() + "?", "Confirmation Message"
                    , MessageBoxButtons.YesNo, MessageBoxIcon.Information);

                if (check == DialogResult.Yes)
                {
                    try
                    {
                        connect.Open();
                        DateTime today = DateTime.Today;

                        string updateData = "UPDATE product SET delete_date = @deleteDate " +
                            "WHERE product_id = @productID";

                        using (SqlCommand cmd = new SqlCommand(updateData, connect))
                        {
                            cmd.Parameters.AddWithValue("@deleteDate", today);
                            cmd.Parameters.AddWithValue("@productID", addProduct_id.Text.Trim());

                            cmd.ExecuteNonQuery();

                            displayWarehouseData();

                            MessageBox.Show("Update successfully!"
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
                else
                {
                    MessageBox.Show("Cancelled."
                        , "Information Message", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                }


            }
        }
    }
}
