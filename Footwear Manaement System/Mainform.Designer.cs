﻿namespace Footwear_Manaement_System
{
    partial class Mainform
    {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(Mainform));
            this.panel1 = new System.Windows.Forms.Panel();
            this.panel4 = new System.Windows.Forms.Panel();
            this.panel2 = new System.Windows.Forms.Panel();
            this.label1 = new System.Windows.Forms.Label();
            this.panel3 = new System.Windows.Forms.Panel();
            this.label3 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.panel5 = new System.Windows.Forms.Panel();
            this.billSearch1 = new Footwear_Manaement_System.BillSearch();
            this.customer_info2 = new Footwear_Manaement_System.customer_info();
            this.women1 = new Footwear_Manaement_System.Women();
            this.kids1 = new Footwear_Manaement_System.Kids();
            this.men1 = new Footwear_Manaement_System.Men();
            this.bill1 = new Footwear_Manaement_System.Bill();
            this.warehouse1 = new Footwear_Manaement_System.warehouse();
            this.product1 = new Footwear_Manaement_System.Product();
            this.supplier_info1 = new Footwear_Manaement_System.Supplier_info();
            this.dashbord1 = new Footwear_Manaement_System.dashboard1();
            this.addEmployee1 = new Footwear_Manaement_System.AddEmployee();
            this.salary1 = new Footwear_Manaement_System.Salary();
            this.customer_info1 = new Footwear_Manaement_System.customer_info();
            this.button1 = new System.Windows.Forms.Button();
            this.Product_btn = new System.Windows.Forms.Button();
            this.Salary_btn = new System.Windows.Forms.Button();
            this.supplier_info_btn = new System.Windows.Forms.Button();
            this.button7 = new System.Windows.Forms.Button();
            this.biling_btn = new System.Windows.Forms.Button();
            this.AddEmployee_btn = new System.Windows.Forms.Button();
            this.warehouse_btn = new System.Windows.Forms.Button();
            this.custmoer_btn = new System.Windows.Forms.Button();
            this.dashbord__btn = new System.Windows.Forms.Button();
            this.pictureBox1 = new System.Windows.Forms.PictureBox();
            this.button2 = new System.Windows.Forms.Button();
            this.report1 = new Footwear_Manaement_System.Report();
            this.product1= new Product(men1,women1,kids1);
            this.panel1.SuspendLayout();
            this.panel2.SuspendLayout();
            this.panel3.SuspendLayout();
            this.panel5.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).BeginInit();
            this.SuspendLayout();
            // 
            // panel1
            // 
            this.panel1.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(24)))), ((int)(((byte)(30)))), ((int)(((byte)(54)))));
            this.panel1.Controls.Add(this.button2);
            this.panel1.Controls.Add(this.button1);
            this.panel1.Controls.Add(this.Product_btn);
            this.panel1.Controls.Add(this.Salary_btn);
            this.panel1.Controls.Add(this.panel4);
            this.panel1.Controls.Add(this.supplier_info_btn);
            this.panel1.Controls.Add(this.button7);
            this.panel1.Controls.Add(this.biling_btn);
            this.panel1.Controls.Add(this.AddEmployee_btn);
            this.panel1.Controls.Add(this.warehouse_btn);
            this.panel1.Controls.Add(this.custmoer_btn);
            this.panel1.Controls.Add(this.dashbord__btn);
            this.panel1.Controls.Add(this.panel2);
            this.panel1.Dock = System.Windows.Forms.DockStyle.Left;
            this.panel1.Location = new System.Drawing.Point(0, 0);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(183, 852);
            this.panel1.TabIndex = 0;
            // 
            // panel4
            // 
            this.panel4.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(126)))), ((int)(((byte)(249)))));
            this.panel4.Location = new System.Drawing.Point(3, 150);
            this.panel4.Name = "panel4";
            this.panel4.Size = new System.Drawing.Size(7, 51);
            this.panel4.TabIndex = 2;
            // 
            // panel2
            // 
            this.panel2.Controls.Add(this.label1);
            this.panel2.Controls.Add(this.pictureBox1);
            this.panel2.Dock = System.Windows.Forms.DockStyle.Top;
            this.panel2.Location = new System.Drawing.Point(0, 0);
            this.panel2.Name = "panel2";
            this.panel2.Size = new System.Drawing.Size(183, 144);
            this.panel2.TabIndex = 0;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label1.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(126)))), ((int)(((byte)(249)))));
            this.label1.Location = new System.Drawing.Point(64, 112);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(54, 18);
            this.label1.TabIndex = 1;
            this.label1.Text = "Admin";
            this.label1.Click += new System.EventHandler(this.label1_Click);
            // 
            // panel3
            // 
            this.panel3.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(24)))), ((int)(((byte)(30)))), ((int)(((byte)(54)))));
            this.panel3.Controls.Add(this.label3);
            this.panel3.Controls.Add(this.label2);
            this.panel3.Dock = System.Windows.Forms.DockStyle.Top;
            this.panel3.Location = new System.Drawing.Point(183, 0);
            this.panel3.Name = "panel3";
            this.panel3.Size = new System.Drawing.Size(1180, 144);
            this.panel3.TabIndex = 1;
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Font = new System.Drawing.Font("MingLiU-ExtB", 72F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label3.ForeColor = System.Drawing.SystemColors.ButtonHighlight;
            this.label3.Location = new System.Drawing.Point(208, 11);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(721, 120);
            this.label3.TabIndex = 1;
            this.label3.Text = "MR Footwear";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Font = new System.Drawing.Font("Microsoft Sans Serif", 13.8F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label2.ForeColor = System.Drawing.Color.Red;
            this.label2.Location = new System.Drawing.Point(1136, 7);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(31, 29);
            this.label2.TabIndex = 0;
            this.label2.Text = "X";
            this.label2.Click += new System.EventHandler(this.label2_Click);
            // 
            // panel5
            // 
            this.panel5.Controls.Add(this.report1);
            this.panel5.Controls.Add(this.billSearch1);
            this.panel5.Controls.Add(this.customer_info2);
            this.panel5.Controls.Add(this.women1);
            this.panel5.Controls.Add(this.kids1);
            this.panel5.Controls.Add(this.men1);
            this.panel5.Controls.Add(this.bill1);
            this.panel5.Controls.Add(this.warehouse1);
            this.panel5.Controls.Add(this.product1);
            this.panel5.Controls.Add(this.supplier_info1);
            this.panel5.Controls.Add(this.dashbord1);
            this.panel5.Controls.Add(this.addEmployee1);
            this.panel5.Controls.Add(this.salary1);
            this.panel5.Dock = System.Windows.Forms.DockStyle.Fill;
            this.panel5.Location = new System.Drawing.Point(183, 144);
            this.panel5.Name = "panel5";
            this.panel5.Size = new System.Drawing.Size(1180, 708);
            this.panel5.TabIndex = 2;
            this.panel5.Paint += new System.Windows.Forms.PaintEventHandler(this.panel5_Paint);
            // 
            // billSearch1
            // 
            this.billSearch1.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(24)))), ((int)(((byte)(30)))), ((int)(((byte)(54)))));
            this.billSearch1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.billSearch1.Location = new System.Drawing.Point(0, 0);
            this.billSearch1.Name = "billSearch1";
            this.billSearch1.Size = new System.Drawing.Size(1180, 708);
            this.billSearch1.TabIndex = 11;
            // 
            // customer_info2
            // 
            this.customer_info2.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(24)))), ((int)(((byte)(30)))), ((int)(((byte)(54)))));
            this.customer_info2.Dock = System.Windows.Forms.DockStyle.Fill;
            this.customer_info2.Location = new System.Drawing.Point(0, 0);
            this.customer_info2.Name = "customer_info2";
            this.customer_info2.Size = new System.Drawing.Size(1180, 708);
            this.customer_info2.TabIndex = 10;
            // 
            // women1
            // 
            this.women1.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(24)))), ((int)(((byte)(30)))), ((int)(((byte)(54)))));
            this.women1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.women1.Location = new System.Drawing.Point(0, 0);
            this.women1.Name = "women1";
            this.women1.Size = new System.Drawing.Size(1180, 708);
            this.women1.TabIndex = 9;
            // 
            // kids1
            // 
            this.kids1.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(24)))), ((int)(((byte)(30)))), ((int)(((byte)(54)))));
            this.kids1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.kids1.Location = new System.Drawing.Point(0, 0);
            this.kids1.Name = "kids1";
            this.kids1.Size = new System.Drawing.Size(1180, 708);
            this.kids1.TabIndex = 8;
            // 
            // men1
            // 
            this.men1.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(24)))), ((int)(((byte)(30)))), ((int)(((byte)(54)))));
            this.men1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.men1.Location = new System.Drawing.Point(0, 0);
            this.men1.Name = "men1";
            this.men1.Size = new System.Drawing.Size(1180, 708);
            this.men1.TabIndex = 7;
            // 
            // bill1
            // 
            this.bill1.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(24)))), ((int)(((byte)(30)))), ((int)(((byte)(54)))));
            this.bill1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.bill1.Location = new System.Drawing.Point(0, 0);
            this.bill1.Name = "bill1";
            this.bill1.Size = new System.Drawing.Size(1180, 708);
            this.bill1.TabIndex = 6;
            // 
            // warehouse1
            // 
            this.warehouse1.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(24)))), ((int)(((byte)(30)))), ((int)(((byte)(54)))));
            this.warehouse1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.warehouse1.Location = new System.Drawing.Point(0, 0);
            this.warehouse1.Name = "warehouse1";
            this.warehouse1.Size = new System.Drawing.Size(1180, 708);
            this.warehouse1.TabIndex = 5;
            // 
            // product1
            // 
            this.product1.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(24)))), ((int)(((byte)(30)))), ((int)(((byte)(54)))));
            this.product1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.product1.Location = new System.Drawing.Point(0, 0);
            this.product1.Name = "product1";
            this.product1.Size = new System.Drawing.Size(1180, 708);
            this.product1.TabIndex = 4;
            // 
            // supplier_info1
            // 
            this.supplier_info1.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(24)))), ((int)(((byte)(30)))), ((int)(((byte)(54)))));
            this.supplier_info1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.supplier_info1.Location = new System.Drawing.Point(0, 0);
            this.supplier_info1.Name = "supplier_info1";
            this.supplier_info1.Size = new System.Drawing.Size(1180, 708);
            this.supplier_info1.TabIndex = 3;
            // 
            // dashbord1
            // 
            this.dashbord1.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(24)))), ((int)(((byte)(30)))), ((int)(((byte)(54)))));
            this.dashbord1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.dashbord1.ForeColor = System.Drawing.SystemColors.ActiveCaptionText;
            this.dashbord1.Location = new System.Drawing.Point(0, 0);
            this.dashbord1.Name = "dashbord1";
            this.dashbord1.Size = new System.Drawing.Size(1180, 708);
            this.dashbord1.TabIndex = 2;
            this.dashbord1.Load += new System.EventHandler(this.dashbord1_Load);
            // 
            // addEmployee1
            // 
            this.addEmployee1.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(24)))), ((int)(((byte)(30)))), ((int)(((byte)(54)))));
            this.addEmployee1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.addEmployee1.Location = new System.Drawing.Point(0, 0);
            this.addEmployee1.Name = "addEmployee1";
            this.addEmployee1.Size = new System.Drawing.Size(1180, 708);
            this.addEmployee1.TabIndex = 1;
            this.addEmployee1.Load += new System.EventHandler(this.addEmployee1_Load);
            // 
            // salary1
            // 
            this.salary1.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(24)))), ((int)(((byte)(30)))), ((int)(((byte)(54)))));
            this.salary1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.salary1.Location = new System.Drawing.Point(0, 0);
            this.salary1.Name = "salary1";
            this.salary1.Size = new System.Drawing.Size(1180, 708);
            this.salary1.TabIndex = 0;
            // 
            // customer_info1
            // 
            this.customer_info1.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(24)))), ((int)(((byte)(30)))), ((int)(((byte)(54)))));
            this.customer_info1.Location = new System.Drawing.Point(0, 0);
            this.customer_info1.Name = "customer_info1";
            this.customer_info1.Size = new System.Drawing.Size(1180, 708);
            this.customer_info1.TabIndex = 0;
            // 
            // button1
            // 
            this.button1.Dock = System.Windows.Forms.DockStyle.Top;
            this.button1.FlatAppearance.BorderSize = 0;
            this.button1.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.button1.Font = new System.Drawing.Font("Nirmala UI", 10.2F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.button1.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(126)))), ((int)(((byte)(249)))));
            this.button1.Image = global::Footwear_Manaement_System.Properties.Resources.icons8_search_24;
            this.button1.ImageAlign = System.Drawing.ContentAlignment.MiddleRight;
            this.button1.Location = new System.Drawing.Point(0, 530);
            this.button1.Name = "button1";
            this.button1.Size = new System.Drawing.Size(183, 47);
            this.button1.TabIndex = 10;
            this.button1.Text = "Search Bill                ";
            this.button1.UseVisualStyleBackColor = true;
            this.button1.Click += new System.EventHandler(this.button1_Click_2);
            this.button1.Leave += new System.EventHandler(this.button1_Leave_1);
            // 
            // Product_btn
            // 
            this.Product_btn.Dock = System.Windows.Forms.DockStyle.Top;
            this.Product_btn.FlatAppearance.BorderSize = 0;
            this.Product_btn.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.Product_btn.Font = new System.Drawing.Font("Nirmala UI", 10.2F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.Product_btn.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(126)))), ((int)(((byte)(249)))));
            this.Product_btn.Image = ((System.Drawing.Image)(resources.GetObject("Product_btn.Image")));
            this.Product_btn.ImageAlign = System.Drawing.ContentAlignment.MiddleRight;
            this.Product_btn.Location = new System.Drawing.Point(0, 483);
            this.Product_btn.Name = "Product_btn";
            this.Product_btn.Size = new System.Drawing.Size(183, 47);
            this.Product_btn.TabIndex = 9;
            this.Product_btn.Text = "Product                 ";
            this.Product_btn.UseVisualStyleBackColor = true;
            this.Product_btn.Click += new System.EventHandler(this.Product_btn_Click);
            this.Product_btn.Leave += new System.EventHandler(this.Product_btn_Leave);
            // 
            // Salary_btn
            // 
            this.Salary_btn.Dock = System.Windows.Forms.DockStyle.Top;
            this.Salary_btn.FlatAppearance.BorderSize = 0;
            this.Salary_btn.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.Salary_btn.Font = new System.Drawing.Font("Nirmala UI", 10.2F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.Salary_btn.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(126)))), ((int)(((byte)(249)))));
            this.Salary_btn.Image = ((System.Drawing.Image)(resources.GetObject("Salary_btn.Image")));
            this.Salary_btn.ImageAlign = System.Drawing.ContentAlignment.MiddleRight;
            this.Salary_btn.Location = new System.Drawing.Point(0, 436);
            this.Salary_btn.Name = "Salary_btn";
            this.Salary_btn.Size = new System.Drawing.Size(183, 47);
            this.Salary_btn.TabIndex = 8;
            this.Salary_btn.Text = "Employee Salary     ";
            this.Salary_btn.UseVisualStyleBackColor = true;
            this.Salary_btn.Click += new System.EventHandler(this.button1_Click_1);
            this.Salary_btn.Leave += new System.EventHandler(this.Salary_btn_Leave);
            // 
            // supplier_info_btn
            // 
            this.supplier_info_btn.Dock = System.Windows.Forms.DockStyle.Top;
            this.supplier_info_btn.FlatAppearance.BorderSize = 0;
            this.supplier_info_btn.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.supplier_info_btn.Font = new System.Drawing.Font("Nirmala UI", 10.2F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.supplier_info_btn.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(126)))), ((int)(((byte)(249)))));
            this.supplier_info_btn.Image = ((System.Drawing.Image)(resources.GetObject("supplier_info_btn.Image")));
            this.supplier_info_btn.ImageAlign = System.Drawing.ContentAlignment.MiddleRight;
            this.supplier_info_btn.Location = new System.Drawing.Point(0, 389);
            this.supplier_info_btn.Name = "supplier_info_btn";
            this.supplier_info_btn.Size = new System.Drawing.Size(183, 47);
            this.supplier_info_btn.TabIndex = 7;
            this.supplier_info_btn.Text = "Supplier Info           ";
            this.supplier_info_btn.UseVisualStyleBackColor = true;
            this.supplier_info_btn.Click += new System.EventHandler(this.button5_Click);
            this.supplier_info_btn.Leave += new System.EventHandler(this.button5_Leave);
            // 
            // button7
            // 
            this.button7.FlatAppearance.BorderSize = 0;
            this.button7.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.button7.Font = new System.Drawing.Font("Nirmala UI", 10.2F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.button7.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(126)))), ((int)(((byte)(249)))));
            this.button7.Image = ((System.Drawing.Image)(resources.GetObject("button7.Image")));
            this.button7.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.button7.Location = new System.Drawing.Point(0, 802);
            this.button7.Name = "button7";
            this.button7.Size = new System.Drawing.Size(186, 47);
            this.button7.TabIndex = 6;
            this.button7.Text = "    Login Out";
            this.button7.UseVisualStyleBackColor = true;
            this.button7.Click += new System.EventHandler(this.button7_Click);
            this.button7.Leave += new System.EventHandler(this.button7_Leave);
            // 
            // biling_btn
            // 
            this.biling_btn.Dock = System.Windows.Forms.DockStyle.Top;
            this.biling_btn.FlatAppearance.BorderSize = 0;
            this.biling_btn.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.biling_btn.Font = new System.Drawing.Font("Nirmala UI", 10.2F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.biling_btn.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(126)))), ((int)(((byte)(249)))));
            this.biling_btn.Image = ((System.Drawing.Image)(resources.GetObject("biling_btn.Image")));
            this.biling_btn.ImageAlign = System.Drawing.ContentAlignment.MiddleRight;
            this.biling_btn.Location = new System.Drawing.Point(0, 342);
            this.biling_btn.Name = "biling_btn";
            this.biling_btn.Size = new System.Drawing.Size(183, 47);
            this.biling_btn.TabIndex = 5;
            this.biling_btn.Text = "Billing                      ";
            this.biling_btn.UseVisualStyleBackColor = true;
            this.biling_btn.Click += new System.EventHandler(this.button6_Click);
            this.biling_btn.Leave += new System.EventHandler(this.button6_Leave);
            // 
            // AddEmployee_btn
            // 
            this.AddEmployee_btn.Dock = System.Windows.Forms.DockStyle.Top;
            this.AddEmployee_btn.FlatAppearance.BorderSize = 0;
            this.AddEmployee_btn.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.AddEmployee_btn.Font = new System.Drawing.Font("Nirmala UI", 10.2F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.AddEmployee_btn.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(126)))), ((int)(((byte)(249)))));
            this.AddEmployee_btn.Image = ((System.Drawing.Image)(resources.GetObject("AddEmployee_btn.Image")));
            this.AddEmployee_btn.ImageAlign = System.Drawing.ContentAlignment.MiddleRight;
            this.AddEmployee_btn.Location = new System.Drawing.Point(0, 295);
            this.AddEmployee_btn.Name = "AddEmployee_btn";
            this.AddEmployee_btn.Size = new System.Drawing.Size(183, 47);
            this.AddEmployee_btn.TabIndex = 4;
            this.AddEmployee_btn.Text = "Employee Info         ";
            this.AddEmployee_btn.UseVisualStyleBackColor = true;
            this.AddEmployee_btn.Click += new System.EventHandler(this.button4_Click);
            this.AddEmployee_btn.Leave += new System.EventHandler(this.button4_Leave);
            // 
            // warehouse_btn
            // 
            this.warehouse_btn.Dock = System.Windows.Forms.DockStyle.Top;
            this.warehouse_btn.FlatAppearance.BorderSize = 0;
            this.warehouse_btn.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.warehouse_btn.Font = new System.Drawing.Font("Nirmala UI", 10.2F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.warehouse_btn.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(126)))), ((int)(((byte)(249)))));
            this.warehouse_btn.Image = ((System.Drawing.Image)(resources.GetObject("warehouse_btn.Image")));
            this.warehouse_btn.ImageAlign = System.Drawing.ContentAlignment.MiddleRight;
            this.warehouse_btn.Location = new System.Drawing.Point(0, 242);
            this.warehouse_btn.Name = "warehouse_btn";
            this.warehouse_btn.Size = new System.Drawing.Size(183, 53);
            this.warehouse_btn.TabIndex = 3;
            this.warehouse_btn.Text = "Warehouse              ";
            this.warehouse_btn.UseVisualStyleBackColor = true;
            this.warehouse_btn.Click += new System.EventHandler(this.button3_Click);
            this.warehouse_btn.Leave += new System.EventHandler(this.button3_Leave);
            // 
            // custmoer_btn
            // 
            this.custmoer_btn.Dock = System.Windows.Forms.DockStyle.Top;
            this.custmoer_btn.FlatAppearance.BorderSize = 0;
            this.custmoer_btn.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.custmoer_btn.Font = new System.Drawing.Font("Nirmala UI", 10.2F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.custmoer_btn.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(126)))), ((int)(((byte)(249)))));
            this.custmoer_btn.Image = ((System.Drawing.Image)(resources.GetObject("custmoer_btn.Image")));
            this.custmoer_btn.ImageAlign = System.Drawing.ContentAlignment.MiddleRight;
            this.custmoer_btn.Location = new System.Drawing.Point(0, 195);
            this.custmoer_btn.Name = "custmoer_btn";
            this.custmoer_btn.Size = new System.Drawing.Size(183, 47);
            this.custmoer_btn.TabIndex = 2;
            this.custmoer_btn.Text = "Customer Info         ";
            this.custmoer_btn.UseVisualStyleBackColor = true;
            this.custmoer_btn.Click += new System.EventHandler(this.button2_Click);
            this.custmoer_btn.Leave += new System.EventHandler(this.button2_Leave);
            // 
            // dashbord__btn
            // 
            this.dashbord__btn.BackColor = System.Drawing.Color.Transparent;
            this.dashbord__btn.Dock = System.Windows.Forms.DockStyle.Top;
            this.dashbord__btn.FlatAppearance.BorderSize = 0;
            this.dashbord__btn.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.dashbord__btn.Font = new System.Drawing.Font("Nirmala UI", 10.2F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.dashbord__btn.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(126)))), ((int)(((byte)(249)))));
            this.dashbord__btn.Image = ((System.Drawing.Image)(resources.GetObject("dashbord__btn.Image")));
            this.dashbord__btn.ImageAlign = System.Drawing.ContentAlignment.MiddleRight;
            this.dashbord__btn.Location = new System.Drawing.Point(0, 144);
            this.dashbord__btn.Name = "dashbord__btn";
            this.dashbord__btn.Size = new System.Drawing.Size(183, 51);
            this.dashbord__btn.TabIndex = 1;
            this.dashbord__btn.Text = "Dashbord                ";
            this.dashbord__btn.UseVisualStyleBackColor = false;
            this.dashbord__btn.Click += new System.EventHandler(this.button1_Click);
            this.dashbord__btn.Leave += new System.EventHandler(this.button1_Leave);
            // 
            // pictureBox1
            // 
            this.pictureBox1.Image = ((System.Drawing.Image)(resources.GetObject("pictureBox1.Image")));
            this.pictureBox1.Location = new System.Drawing.Point(36, 0);
            this.pictureBox1.Name = "pictureBox1";
            this.pictureBox1.Size = new System.Drawing.Size(123, 109);
            this.pictureBox1.SizeMode = System.Windows.Forms.PictureBoxSizeMode.Zoom;
            this.pictureBox1.TabIndex = 0;
            this.pictureBox1.TabStop = false;
            // 
            // button2
            // 
            this.button2.Dock = System.Windows.Forms.DockStyle.Top;
            this.button2.FlatAppearance.BorderSize = 0;
            this.button2.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.button2.Font = new System.Drawing.Font("Nirmala UI", 10.2F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.button2.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(126)))), ((int)(((byte)(249)))));
            this.button2.Image = global::Footwear_Manaement_System.Properties.Resources.icons8_report_24;
            this.button2.ImageAlign = System.Drawing.ContentAlignment.MiddleRight;
            this.button2.Location = new System.Drawing.Point(0, 577);
            this.button2.Name = "button2";
            this.button2.Size = new System.Drawing.Size(183, 53);
            this.button2.TabIndex = 11;
            this.button2.Text = "Reports                    ";
            this.button2.UseVisualStyleBackColor = true;
            this.button2.Click += new System.EventHandler(this.button2_Click_1);
            // 
            // report1
            // 
            this.report1.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(24)))), ((int)(((byte)(30)))), ((int)(((byte)(54)))));
            this.report1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.report1.Location = new System.Drawing.Point(0, 0);
            this.report1.Name = "report1";
            this.report1.Size = new System.Drawing.Size(1180, 708);
            this.report1.TabIndex = 12;
            // 
            // Mainform
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(46)))), ((int)(((byte)(51)))), ((int)(((byte)(73)))));
            this.ClientSize = new System.Drawing.Size(1363, 852);
            this.Controls.Add(this.panel5);
            this.Controls.Add(this.panel3);
            this.Controls.Add(this.panel1);
            this.ForeColor = System.Drawing.Color.Black;
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.None;
            this.Name = "Mainform";
            this.SizeGripStyle = System.Windows.Forms.SizeGripStyle.Hide;
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Mainform";
            this.panel1.ResumeLayout(false);
            this.panel2.ResumeLayout(false);
            this.panel2.PerformLayout();
            this.panel3.ResumeLayout(false);
            this.panel3.PerformLayout();
            this.panel5.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Panel panel1;
        private System.Windows.Forms.Panel panel2;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.PictureBox pictureBox1;
        private System.Windows.Forms.Button dashbord__btn;
        private System.Windows.Forms.Button warehouse_btn;
        private System.Windows.Forms.Button custmoer_btn;
        private System.Windows.Forms.Button AddEmployee_btn;
        private System.Windows.Forms.Button button7;
        private System.Windows.Forms.Button biling_btn;
        private System.Windows.Forms.Panel panel3;
        private System.Windows.Forms.Panel panel4;
        private System.Windows.Forms.Button supplier_info_btn;
        private System.Windows.Forms.Panel panel5;
        private AddEmployee addEmployee1;
        private Salary salary1;
        private dashboard1 dashbord1;
        private System.Windows.Forms.Button Salary_btn;
       // private Supplier_info supplier_info2;
        private Supplier_info supplier_info1;
        private customer_info customer_info1;
        private System.Windows.Forms.Button Product_btn;
        private Product product1;
        private warehouse warehouse1;
        private Kids kids1;
        private Men men1;
        private Bill bill1;
        private Women women1;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label label3;
        private customer_info customer_info2;
        private System.Windows.Forms.Button button1;
        private BillSearch billSearch1;
        private System.Windows.Forms.Button button2;
        private Report report1;
    }
}