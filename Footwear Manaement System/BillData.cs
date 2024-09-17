using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Footwear_Manaement_System
{
    internal class BillData
    {
        public int  CustomerID { set; get; }
        public string Name { set; get; }
        public string Address { set; get; }
        public string Contact { set; get; }
        public string Email { set; get; }
        public int Total_Amount { set; get; }

       
        SqlConnection connect = new SqlConnection(@"Data Source=MANTHAN\SQLEXPRESS;Initial Catalog=FootwareManagementSystem;Integrated Security=True;TrustServerCertificate=True");


        public List<BillData> BillCustomerListData()
        {
            List<BillData> listdata = new List<BillData>();

            if (connect.State != ConnectionState.Open)
            {
                try
                {
                    connect.Open();

                    string selectData = "select c.full_name,c.address,c.email,c.contact_number,b.tota_amount" +
                        ",from customer c inner join bill b on c.customer_id=b.customer_id"+
                        ",where c.customer_id=@customerID";
                        

                    using (SqlCommand cmd = new SqlCommand(selectData, connect))
                    {
                        SqlDataReader reader = cmd.ExecuteReader();

                        while (reader.Read())
                        {
                            BillData sd = new BillData();
                            sd.CustomerID = (int)reader["customer_id"];
                            sd.Name = reader["full_name"].ToString();
                            sd.Address = reader["address"].ToString();
                            sd.Contact = reader["contact_number"].ToString();
                            sd.Email = reader["email"].ToString();
                            sd.Total_Amount = (int)reader["total_amt"];

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
