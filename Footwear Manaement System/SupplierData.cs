using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Footwear_Manaement_System
{
    internal class SupplierData
    {
      
        public string SupplierID { set; get; }
        public string Name { set; get; }
        public string Address { set; get; }
        public string Contact { set; get; }
        public string Email { set; get; }
        public string Order { set; get; }



        SqlConnection connect = new SqlConnection(@"Data Source=MANTHAN\SQLEXPRESS;Initial Catalog=FootwareManagementSystem;Integrated Security=True;TrustServerCertificate=True");


        public List<SupplierData> SupplierListData()
        {
            List<SupplierData> listdata = new List<SupplierData>();

            if (connect.State != ConnectionState.Open)
            {
                try
                {
                    connect.Open();

                    string selectData = "SELECT * FROM supplier WHERE delete_date IS NULL";

                    using (SqlCommand cmd = new SqlCommand(selectData, connect))
                    {
                        SqlDataReader reader = cmd.ExecuteReader();

                        while (reader.Read())
                        {
                            SupplierData sd = new SupplierData();
                           
                            sd.SupplierID = reader["supplier_id"].ToString();
                            sd.Name = reader["full_name"].ToString();
                            sd.Address = reader["address"].ToString();
                            sd.Contact = reader["contact_number"].ToString();
                            sd.Email = reader["email"].ToString();
                            sd.Order = reader["order_details"].ToString();

                            listdata.Add(sd);
                        }
                    }

                }
                catch (Exception ex)
                {
                    Console.WriteLine("Error: " + ex.Message);
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
