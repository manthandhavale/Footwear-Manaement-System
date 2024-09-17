using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Footwear_Manaement_System
{
    internal class WarehouseData
    {
      
        public string ProductID { set; get; } // 1
        public string Model_no { set; get; } // 2
        public string Category { set; get; } // 3
        public string Price { set; get; } // 4
        public string Size { set; get; } // 5
        public string Image { set; get; } // 6
        public String Brand { set; get; } // 7

        public String Quantity { set; get; }


        SqlConnection connect = new SqlConnection(@"Data Source=MANTHAN\SQLEXPRESS;Initial Catalog=FootwareManagementSystem;Integrated Security=True;TrustServerCertificate=True");


        public List<WarehouseData> warehouseListData()
        {
            List<WarehouseData> listdata = new List<WarehouseData>();

            if (connect.State != ConnectionState.Open)
            {
                try
                {
                    connect.Open();

                    string selectData = "SELECT * FROM product WHERE delete_date IS NULL";

                    using (SqlCommand cmd = new SqlCommand(selectData, connect))
                    {
                        SqlDataReader reader = cmd.ExecuteReader();

                        while (reader.Read())
                        {
                            WarehouseData wd = new WarehouseData();
                           
                            wd.ProductID = reader["product_id"].ToString();
                            wd.Model_no = reader["model_no"].ToString();
                            wd.Category = reader["category"].ToString();
                            wd.Price = reader["price"].ToString();
                            wd.Size = reader["size"].ToString();
                            wd.Image = reader["image"].ToString();
                            wd.Brand = reader["brand"].ToString();
                            wd.Quantity = reader["quantity"].ToString();
                           

                            listdata.Add(wd);
                        }
                    }

                }
                catch (Exception ex)
                {
                    Console.WriteLine("Error: " + ex);
                }
                finally
                {
                    connect.Close();
                }
            }
            return listdata;
        }

        
    }
}
