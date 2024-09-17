using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Runtime.InteropServices;
using System.Data.SqlClient;

namespace Footwear_Manaement_System
{
    public partial class Form1 : Form
    {
        SqlConnection connect
           = new SqlConnection(@"Data Source=MANTHAN\SQLEXPRESS;Initial Catalog=FootwareManagementSystem;Integrated Security=True;TrustServerCertificate=True");
        [DllImport("Gdi32.dll", EntryPoint = "CreateRoundRectRgn")]
        private static extern IntPtr CreateRoundRectRgn
            (

            int nLeftRect,
            int nTopRect,
            int nRightRect,
            int nBottomRect,
            int nWidthEllipse,
            int nHeightEllipse

              );
        public Form1()
        {
            InitializeComponent();
            Region = System.Drawing.Region.FromHrgn(CreateRoundRectRgn(0, 0, Width, Height, 25, 25));
        }

        private void Form1_Load(object sender, EventArgs e)
        {
            panel1.BackColor=Color.FromArgb(100, 0, 0,0);
        }

        private void label2_Click(object sender, EventArgs e)
        {

        }

        private void textBox1_TextChanged(object sender, EventArgs e)
        {

        }

        private void panel1_Paint(object sender, PaintEventArgs e)
        {

        }

        private void button1_Click(object sender, EventArgs e)
        {
            if (textBox1.Text == ""
               || textBox2.Text == "")
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

                        string selectData = "SELECT * FROM users WHERE username = @username " +
                            "AND password = @password";

                        using (SqlCommand cmd = new SqlCommand(selectData, connect))
                        {
                            cmd.Parameters.AddWithValue("@username", textBox1.Text.Trim());
                            cmd.Parameters.AddWithValue("@password", textBox2.Text.Trim());

                            SqlDataAdapter adapter = new SqlDataAdapter(cmd);
                            DataTable table = new DataTable();
                            adapter.Fill(table);

                            if (table.Rows.Count >= 1)
                            {
                                MessageBox.Show("Login successfully!"
                                    , "Information Message", MessageBoxButtons.OK, MessageBoxIcon.Information);

                                Mainform mForm = new Mainform();
                                mForm.Show();
                                this.Hide();
                            }
                            else
                            {
                                MessageBox.Show("Incorrect Username/Password"
                                    , "Error Message", MessageBoxButtons.OK, MessageBoxIcon.Error);
                            }
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

            }

        }

        private void checkBox1_CheckedChanged(object sender, EventArgs e)
        {
            textBox2.PasswordChar = checkBox1.Checked ? '\0' : '*';
        }

        private void button2_Click(object sender, EventArgs e)
        {
            Application.Exit(); 
        }

        private void button3_Click(object sender, EventArgs e)
        {
            register regform = new register();
            regform.Show();
            this.Hide();
        }

        private void label4_Click(object sender, EventArgs e)
        {
            Application.Exit();
        }
    }
}
