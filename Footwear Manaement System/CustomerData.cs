using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Footwear_Manaement_System
{
    internal class CustomerData
    {
      
        public string CustomerID { set; get; }
        public string Name { set; get; }
        public string Address { set; get; }
        public string Contact { set; get; }
        public string Email { set; get; }
 


        SqlConnection connect = new SqlConnection(@"Data Source=MANTHAN\SQLEXPRESS;Initial Catalog=FootwareManagementSystem;Integrated Security=True;TrustServerCertificate=True");


        public List<CustomerData> CustomerListData()
        {
            List<CustomerData> listdata = new List<CustomerData>();

            if (connect.State != ConnectionState.Open)
            {
                try
                {
                    connect.Open();

                    string selectData = "SELECT * FROM customer WHERE delete_date IS NULL";

                    using (SqlCommand cmd = new SqlCommand(selectData, connect))
                    {
                        SqlDataReader reader = cmd.ExecuteReader();

                        while (reader.Read())
                        {
                            CustomerData cd = new CustomerData();
                            
                            cd.CustomerID = reader["customer_id"].ToString();
                            cd.Name = reader["full_name"].ToString();
                            cd.Address = reader["address"].ToString();
                            cd.Contact = reader["contact_number"].ToString();
                            cd.Email = reader["email"].ToString();
                           
                            listdata.Add(cd);
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

        public List<CustomerData> billCustomerListData()
        {
            List<CustomerData> listdata = new List<CustomerData>();

            if (connect.State != ConnectionState.Open)
            {
                try
                {
                    connect.Open();

                    string selectData = "SELECT * FROM customer WHERE delete_date IS NULL";

                    using (SqlCommand cmd = new SqlCommand(selectData, connect))
                    {
                        SqlDataReader reader = cmd.ExecuteReader();

                        while (reader.Read())
                        {
                            CustomerData cd = new CustomerData();
                            cd.CustomerID = reader["customer_id"].ToString();
                            cd.Name = reader["full_name"].ToString();
                            cd.Address = reader["address"].ToString();

                            listdata.Add(cd);
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

