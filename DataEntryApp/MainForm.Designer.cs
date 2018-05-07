namespace DataEntryApp
{
    partial class MainForm
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
            this.label1 = new System.Windows.Forms.Label();
            this.Catalog_Box = new System.Windows.Forms.TextBox();
            this.Connect_Button = new System.Windows.Forms.Button();
            this.Search_Box = new System.Windows.Forms.TextBox();
            this.Results_View = new System.Windows.Forms.ListView();
            this.columnHeader1 = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.columnHeader2 = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.columnHeader3 = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.columnHeader4 = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.columnHeader5 = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.label2 = new System.Windows.Forms.Label();
            this.label3 = new System.Windows.Forms.Label();
            this.label4 = new System.Windows.Forms.Label();
            this.Uid_Box = new System.Windows.Forms.TextBox();
            this.Assign_Button = new System.Windows.Forms.Button();
            this.Cancel_Button = new System.Windows.Forms.Button();
            this.tabControl1 = new System.Windows.Forms.TabControl();
            this.tabPage1 = new System.Windows.Forms.TabPage();
            this.tabPage2 = new System.Windows.Forms.TabPage();
            this.Assigned_Radio = new System.Windows.Forms.RadioButton();
            this.Unassigned_Radio = new System.Windows.Forms.RadioButton();
            this.All_Radio = new System.Windows.Forms.RadioButton();
            this.Delete_Button = new System.Windows.Forms.Button();
            this.Status_List = new System.Windows.Forms.ListView();
            this.columnHeader6 = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.columnHeader7 = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.columnHeader8 = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.columnHeader9 = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.columnHeader10 = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.columnHeader11 = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.tabPage3 = new System.Windows.Forms.TabPage();
            this.listView1 = new System.Windows.Forms.ListView();
            this.columnHeader12 = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.columnHeader13 = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.Add_Button = new System.Windows.Forms.Button();
            this.Serial_Box = new System.Windows.Forms.TextBox();
            this.Temp_Uid_Box = new System.Windows.Forms.TextBox();
            this.label12 = new System.Windows.Forms.Label();
            this.label11 = new System.Windows.Forms.Label();
            this.groupBox1 = new System.Windows.Forms.GroupBox();
            this.Password_Box = new System.Windows.Forms.TextBox();
            this.Username_Box = new System.Windows.Forms.TextBox();
            this.Server_Box = new System.Windows.Forms.TextBox();
            this.label7 = new System.Windows.Forms.Label();
            this.label6 = new System.Windows.Forms.Label();
            this.label5 = new System.Windows.Forms.Label();
            this.groupBox2 = new System.Windows.Forms.GroupBox();
            this.Assigned_Guests_Label = new System.Windows.Forms.Label();
            this.Unassigned_Guests_Label = new System.Windows.Forms.Label();
            this.Total_Guests_Label = new System.Windows.Forms.Label();
            this.label10 = new System.Windows.Forms.Label();
            this.label9 = new System.Windows.Forms.Label();
            this.label8 = new System.Windows.Forms.Label();
            this.tabPage4 = new System.Windows.Forms.TabPage();
            this.Add_Special_Button = new System.Windows.Forms.Button();
            this.Special_Uid_Box = new System.Windows.Forms.TextBox();
            this.label13 = new System.Windows.Forms.Label();
            this.label14 = new System.Windows.Forms.Label();
            this.Special_Level_Combo = new System.Windows.Forms.ComboBox();
            this.tabControl1.SuspendLayout();
            this.tabPage1.SuspendLayout();
            this.tabPage2.SuspendLayout();
            this.tabPage3.SuspendLayout();
            this.groupBox1.SuspendLayout();
            this.groupBox2.SuspendLayout();
            this.tabPage4.SuspendLayout();
            this.SuspendLayout();
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(46, 48);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(46, 13);
            this.label1.TabIndex = 0;
            this.label1.Text = "Catalog:";
            // 
            // Catalog_Box
            // 
            this.Catalog_Box.Location = new System.Drawing.Point(98, 45);
            this.Catalog_Box.Name = "Catalog_Box";
            this.Catalog_Box.Size = new System.Drawing.Size(162, 20);
            this.Catalog_Box.TabIndex = 1;
            // 
            // Connect_Button
            // 
            this.Connect_Button.Location = new System.Drawing.Point(185, 141);
            this.Connect_Button.Name = "Connect_Button";
            this.Connect_Button.Size = new System.Drawing.Size(75, 23);
            this.Connect_Button.TabIndex = 4;
            this.Connect_Button.Text = "Connect";
            this.Connect_Button.UseVisualStyleBackColor = true;
            this.Connect_Button.Click += new System.EventHandler(this.Connect_Button_Click);
            // 
            // Search_Box
            // 
            this.Search_Box.Enabled = false;
            this.Search_Box.Location = new System.Drawing.Point(84, 32);
            this.Search_Box.Name = "Search_Box";
            this.Search_Box.Size = new System.Drawing.Size(252, 20);
            this.Search_Box.TabIndex = 1;
            this.Search_Box.TextChanged += new System.EventHandler(this.Search_Box_TextChanged);
            this.Search_Box.KeyDown += new System.Windows.Forms.KeyEventHandler(this.Search_Box_KeyDown);
            // 
            // Results_View
            // 
            this.Results_View.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.Results_View.Columns.AddRange(new System.Windows.Forms.ColumnHeader[] {
            this.columnHeader1,
            this.columnHeader2,
            this.columnHeader3,
            this.columnHeader4,
            this.columnHeader5});
            this.Results_View.Enabled = false;
            this.Results_View.FullRowSelect = true;
            this.Results_View.GridLines = true;
            this.Results_View.Location = new System.Drawing.Point(84, 58);
            this.Results_View.Name = "Results_View";
            this.Results_View.Size = new System.Drawing.Size(634, 166);
            this.Results_View.TabIndex = 2;
            this.Results_View.UseCompatibleStateImageBehavior = false;
            this.Results_View.View = System.Windows.Forms.View.Details;
            this.Results_View.SelectedIndexChanged += new System.EventHandler(this.Results_View_SelectedIndexChanged);
            this.Results_View.KeyDown += new System.Windows.Forms.KeyEventHandler(this.Results_View_KeyDown);
            this.Results_View.MouseDoubleClick += new System.Windows.Forms.MouseEventHandler(this.Results_View_MouseDoubleClick);
            // 
            // columnHeader1
            // 
            this.columnHeader1.Text = "Title";
            this.columnHeader1.Width = 35;
            // 
            // columnHeader2
            // 
            this.columnHeader2.Text = "Name";
            this.columnHeader2.Width = 121;
            // 
            // columnHeader3
            // 
            this.columnHeader3.Text = "Surname";
            this.columnHeader3.Width = 117;
            // 
            // columnHeader4
            // 
            this.columnHeader4.Text = "Position";
            this.columnHeader4.Width = 127;
            // 
            // columnHeader5
            // 
            this.columnHeader5.Text = "Organization";
            this.columnHeader5.Width = 189;
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(34, 35);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(44, 13);
            this.label2.TabIndex = 5;
            this.label2.Text = "Search:";
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(33, 58);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(45, 13);
            this.label3.TabIndex = 6;
            this.label3.Text = "Results:";
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Location = new System.Drawing.Point(15, 9);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(63, 13);
            this.label4.TabIndex = 7;
            this.label4.Text = "Current Uid:";
            this.label4.Click += new System.EventHandler(this.label4_Click);
            // 
            // Uid_Box
            // 
            this.Uid_Box.Enabled = false;
            this.Uid_Box.Location = new System.Drawing.Point(84, 6);
            this.Uid_Box.Name = "Uid_Box";
            this.Uid_Box.Size = new System.Drawing.Size(192, 20);
            this.Uid_Box.TabIndex = 0;
            // 
            // Assign_Button
            // 
            this.Assign_Button.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.Assign_Button.Enabled = false;
            this.Assign_Button.Location = new System.Drawing.Point(549, 255);
            this.Assign_Button.Name = "Assign_Button";
            this.Assign_Button.Size = new System.Drawing.Size(92, 23);
            this.Assign_Button.TabIndex = 3;
            this.Assign_Button.Text = "Assign";
            this.Assign_Button.UseVisualStyleBackColor = true;
            this.Assign_Button.Click += new System.EventHandler(this.Assign_Button_Click);
            // 
            // Cancel_Button
            // 
            this.Cancel_Button.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.Cancel_Button.Enabled = false;
            this.Cancel_Button.Location = new System.Drawing.Point(647, 255);
            this.Cancel_Button.Name = "Cancel_Button";
            this.Cancel_Button.Size = new System.Drawing.Size(71, 23);
            this.Cancel_Button.TabIndex = 4;
            this.Cancel_Button.Text = "Cancel";
            this.Cancel_Button.UseVisualStyleBackColor = true;
            this.Cancel_Button.Click += new System.EventHandler(this.Cancel_Button_Click);
            // 
            // tabControl1
            // 
            this.tabControl1.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.tabControl1.Controls.Add(this.tabPage1);
            this.tabControl1.Controls.Add(this.tabPage2);
            this.tabControl1.Controls.Add(this.tabPage4);
            this.tabControl1.Controls.Add(this.tabPage3);
            this.tabControl1.Location = new System.Drawing.Point(12, 188);
            this.tabControl1.Name = "tabControl1";
            this.tabControl1.SelectedIndex = 0;
            this.tabControl1.Size = new System.Drawing.Size(735, 310);
            this.tabControl1.TabIndex = 2;
            // 
            // tabPage1
            // 
            this.tabPage1.Controls.Add(this.Uid_Box);
            this.tabPage1.Controls.Add(this.Cancel_Button);
            this.tabPage1.Controls.Add(this.Search_Box);
            this.tabPage1.Controls.Add(this.Assign_Button);
            this.tabPage1.Controls.Add(this.Results_View);
            this.tabPage1.Controls.Add(this.label2);
            this.tabPage1.Controls.Add(this.label4);
            this.tabPage1.Controls.Add(this.label3);
            this.tabPage1.Location = new System.Drawing.Point(4, 22);
            this.tabPage1.Name = "tabPage1";
            this.tabPage1.Padding = new System.Windows.Forms.Padding(3);
            this.tabPage1.Size = new System.Drawing.Size(727, 284);
            this.tabPage1.TabIndex = 0;
            this.tabPage1.Text = "Add Guest";
            this.tabPage1.UseVisualStyleBackColor = true;
            // 
            // tabPage2
            // 
            this.tabPage2.Controls.Add(this.Assigned_Radio);
            this.tabPage2.Controls.Add(this.Unassigned_Radio);
            this.tabPage2.Controls.Add(this.All_Radio);
            this.tabPage2.Controls.Add(this.Delete_Button);
            this.tabPage2.Controls.Add(this.Status_List);
            this.tabPage2.Location = new System.Drawing.Point(4, 22);
            this.tabPage2.Name = "tabPage2";
            this.tabPage2.Padding = new System.Windows.Forms.Padding(3);
            this.tabPage2.Size = new System.Drawing.Size(727, 284);
            this.tabPage2.TabIndex = 1;
            this.tabPage2.Text = "List";
            this.tabPage2.UseVisualStyleBackColor = true;
            // 
            // Assigned_Radio
            // 
            this.Assigned_Radio.AutoSize = true;
            this.Assigned_Radio.Location = new System.Drawing.Point(202, 13);
            this.Assigned_Radio.Name = "Assigned_Radio";
            this.Assigned_Radio.Size = new System.Drawing.Size(68, 17);
            this.Assigned_Radio.TabIndex = 4;
            this.Assigned_Radio.Text = "Assigned";
            this.Assigned_Radio.UseVisualStyleBackColor = true;
            this.Assigned_Radio.CheckedChanged += new System.EventHandler(this.Radio_CheckedChanged);
            // 
            // Unassigned_Radio
            // 
            this.Unassigned_Radio.AutoSize = true;
            this.Unassigned_Radio.Location = new System.Drawing.Point(97, 13);
            this.Unassigned_Radio.Name = "Unassigned_Radio";
            this.Unassigned_Radio.Size = new System.Drawing.Size(81, 17);
            this.Unassigned_Radio.TabIndex = 3;
            this.Unassigned_Radio.Text = "Unassigned";
            this.Unassigned_Radio.UseVisualStyleBackColor = true;
            this.Unassigned_Radio.CheckedChanged += new System.EventHandler(this.Radio_CheckedChanged);
            // 
            // All_Radio
            // 
            this.All_Radio.AutoSize = true;
            this.All_Radio.Checked = true;
            this.All_Radio.Location = new System.Drawing.Point(6, 13);
            this.All_Radio.Name = "All_Radio";
            this.All_Radio.Size = new System.Drawing.Size(36, 17);
            this.All_Radio.TabIndex = 2;
            this.All_Radio.TabStop = true;
            this.All_Radio.Text = "All";
            this.All_Radio.UseVisualStyleBackColor = true;
            this.All_Radio.CheckedChanged += new System.EventHandler(this.Radio_CheckedChanged);
            // 
            // Delete_Button
            // 
            this.Delete_Button.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.Delete_Button.Enabled = false;
            this.Delete_Button.Location = new System.Drawing.Point(611, 36);
            this.Delete_Button.Name = "Delete_Button";
            this.Delete_Button.Size = new System.Drawing.Size(107, 23);
            this.Delete_Button.TabIndex = 1;
            this.Delete_Button.Text = "Delete";
            this.Delete_Button.UseVisualStyleBackColor = true;
            this.Delete_Button.Click += new System.EventHandler(this.Delete_Button_Click);
            // 
            // Status_List
            // 
            this.Status_List.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.Status_List.Columns.AddRange(new System.Windows.Forms.ColumnHeader[] {
            this.columnHeader6,
            this.columnHeader7,
            this.columnHeader8,
            this.columnHeader9,
            this.columnHeader10,
            this.columnHeader11});
            this.Status_List.FullRowSelect = true;
            this.Status_List.GridLines = true;
            this.Status_List.Location = new System.Drawing.Point(6, 36);
            this.Status_List.Name = "Status_List";
            this.Status_List.Size = new System.Drawing.Size(599, 242);
            this.Status_List.TabIndex = 0;
            this.Status_List.UseCompatibleStateImageBehavior = false;
            this.Status_List.View = System.Windows.Forms.View.Details;
            this.Status_List.SelectedIndexChanged += new System.EventHandler(this.Status_List_SelectedIndexChanged);
            // 
            // columnHeader6
            // 
            this.columnHeader6.Text = "Uid";
            this.columnHeader6.Width = 108;
            // 
            // columnHeader7
            // 
            this.columnHeader7.Text = "Title";
            this.columnHeader7.Width = 38;
            // 
            // columnHeader8
            // 
            this.columnHeader8.Text = "Name";
            this.columnHeader8.Width = 77;
            // 
            // columnHeader9
            // 
            this.columnHeader9.Text = "Surname";
            this.columnHeader9.Width = 86;
            // 
            // columnHeader10
            // 
            this.columnHeader10.Text = "Position";
            this.columnHeader10.Width = 72;
            // 
            // columnHeader11
            // 
            this.columnHeader11.Text = "Organization";
            this.columnHeader11.Width = 172;
            // 
            // tabPage3
            // 
            this.tabPage3.Controls.Add(this.listView1);
            this.tabPage3.Controls.Add(this.Add_Button);
            this.tabPage3.Controls.Add(this.Serial_Box);
            this.tabPage3.Controls.Add(this.Temp_Uid_Box);
            this.tabPage3.Controls.Add(this.label12);
            this.tabPage3.Controls.Add(this.label11);
            this.tabPage3.Location = new System.Drawing.Point(4, 22);
            this.tabPage3.Name = "tabPage3";
            this.tabPage3.Padding = new System.Windows.Forms.Padding(3);
            this.tabPage3.Size = new System.Drawing.Size(727, 284);
            this.tabPage3.TabIndex = 2;
            this.tabPage3.Text = "Temporary Cards";
            this.tabPage3.UseVisualStyleBackColor = true;
            // 
            // listView1
            // 
            this.listView1.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.listView1.Columns.AddRange(new System.Windows.Forms.ColumnHeader[] {
            this.columnHeader12,
            this.columnHeader13});
            this.listView1.FullRowSelect = true;
            this.listView1.GridLines = true;
            this.listView1.Location = new System.Drawing.Point(262, 14);
            this.listView1.Name = "listView1";
            this.listView1.Size = new System.Drawing.Size(459, 264);
            this.listView1.TabIndex = 5;
            this.listView1.UseCompatibleStateImageBehavior = false;
            this.listView1.View = System.Windows.Forms.View.Details;
            // 
            // columnHeader12
            // 
            this.columnHeader12.Text = "Uid";
            // 
            // columnHeader13
            // 
            this.columnHeader13.Text = "Serial";
            this.columnHeader13.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            this.columnHeader13.Width = 168;
            // 
            // Add_Button
            // 
            this.Add_Button.Location = new System.Drawing.Point(181, 66);
            this.Add_Button.Name = "Add_Button";
            this.Add_Button.Size = new System.Drawing.Size(75, 23);
            this.Add_Button.TabIndex = 4;
            this.Add_Button.Text = "Add";
            this.Add_Button.UseVisualStyleBackColor = true;
            this.Add_Button.Click += new System.EventHandler(this.Add_Button_Click);
            // 
            // Serial_Box
            // 
            this.Serial_Box.Location = new System.Drawing.Point(92, 40);
            this.Serial_Box.Name = "Serial_Box";
            this.Serial_Box.Size = new System.Drawing.Size(164, 20);
            this.Serial_Box.TabIndex = 3;
            // 
            // Temp_Uid_Box
            // 
            this.Temp_Uid_Box.Enabled = false;
            this.Temp_Uid_Box.Location = new System.Drawing.Point(92, 14);
            this.Temp_Uid_Box.Name = "Temp_Uid_Box";
            this.Temp_Uid_Box.Size = new System.Drawing.Size(164, 20);
            this.Temp_Uid_Box.TabIndex = 2;
            // 
            // label12
            // 
            this.label12.AutoSize = true;
            this.label12.Location = new System.Drawing.Point(22, 43);
            this.label12.Name = "label12";
            this.label12.Size = new System.Drawing.Size(64, 13);
            this.label12.TabIndex = 1;
            this.label12.Text = "Serial Code:";
            // 
            // label11
            // 
            this.label11.AutoSize = true;
            this.label11.Location = new System.Drawing.Point(60, 17);
            this.label11.Name = "label11";
            this.label11.Size = new System.Drawing.Size(26, 13);
            this.label11.TabIndex = 0;
            this.label11.Text = "Uid:";
            // 
            // groupBox1
            // 
            this.groupBox1.Controls.Add(this.Password_Box);
            this.groupBox1.Controls.Add(this.Username_Box);
            this.groupBox1.Controls.Add(this.Server_Box);
            this.groupBox1.Controls.Add(this.label7);
            this.groupBox1.Controls.Add(this.label6);
            this.groupBox1.Controls.Add(this.label5);
            this.groupBox1.Controls.Add(this.Catalog_Box);
            this.groupBox1.Controls.Add(this.label1);
            this.groupBox1.Controls.Add(this.Connect_Button);
            this.groupBox1.Location = new System.Drawing.Point(12, 12);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Size = new System.Drawing.Size(266, 170);
            this.groupBox1.TabIndex = 0;
            this.groupBox1.TabStop = false;
            this.groupBox1.Text = "Database";
            // 
            // Password_Box
            // 
            this.Password_Box.Location = new System.Drawing.Point(98, 97);
            this.Password_Box.Name = "Password_Box";
            this.Password_Box.Size = new System.Drawing.Size(162, 20);
            this.Password_Box.TabIndex = 3;
            // 
            // Username_Box
            // 
            this.Username_Box.Location = new System.Drawing.Point(98, 71);
            this.Username_Box.Name = "Username_Box";
            this.Username_Box.Size = new System.Drawing.Size(162, 20);
            this.Username_Box.TabIndex = 2;
            // 
            // Server_Box
            // 
            this.Server_Box.Location = new System.Drawing.Point(98, 19);
            this.Server_Box.Name = "Server_Box";
            this.Server_Box.Size = new System.Drawing.Size(162, 20);
            this.Server_Box.TabIndex = 0;
            // 
            // label7
            // 
            this.label7.AutoSize = true;
            this.label7.Location = new System.Drawing.Point(51, 22);
            this.label7.Name = "label7";
            this.label7.Size = new System.Drawing.Size(41, 13);
            this.label7.TabIndex = 13;
            this.label7.Text = "Server:";
            // 
            // label6
            // 
            this.label6.AutoSize = true;
            this.label6.Location = new System.Drawing.Point(36, 100);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(56, 13);
            this.label6.TabIndex = 4;
            this.label6.Text = "Password:";
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Location = new System.Drawing.Point(34, 74);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(58, 13);
            this.label5.TabIndex = 3;
            this.label5.Text = "Username:";
            // 
            // groupBox2
            // 
            this.groupBox2.Controls.Add(this.Assigned_Guests_Label);
            this.groupBox2.Controls.Add(this.Unassigned_Guests_Label);
            this.groupBox2.Controls.Add(this.Total_Guests_Label);
            this.groupBox2.Controls.Add(this.label10);
            this.groupBox2.Controls.Add(this.label9);
            this.groupBox2.Controls.Add(this.label8);
            this.groupBox2.Location = new System.Drawing.Point(284, 12);
            this.groupBox2.Name = "groupBox2";
            this.groupBox2.Size = new System.Drawing.Size(463, 170);
            this.groupBox2.TabIndex = 1;
            this.groupBox2.TabStop = false;
            this.groupBox2.Text = "Statistics";
            // 
            // Assigned_Guests_Label
            // 
            this.Assigned_Guests_Label.AutoSize = true;
            this.Assigned_Guests_Label.Location = new System.Drawing.Point(129, 74);
            this.Assigned_Guests_Label.Name = "Assigned_Guests_Label";
            this.Assigned_Guests_Label.Size = new System.Drawing.Size(0, 13);
            this.Assigned_Guests_Label.TabIndex = 5;
            // 
            // Unassigned_Guests_Label
            // 
            this.Unassigned_Guests_Label.AutoSize = true;
            this.Unassigned_Guests_Label.Location = new System.Drawing.Point(129, 48);
            this.Unassigned_Guests_Label.Name = "Unassigned_Guests_Label";
            this.Unassigned_Guests_Label.Size = new System.Drawing.Size(0, 13);
            this.Unassigned_Guests_Label.TabIndex = 4;
            // 
            // Total_Guests_Label
            // 
            this.Total_Guests_Label.AutoSize = true;
            this.Total_Guests_Label.Location = new System.Drawing.Point(129, 22);
            this.Total_Guests_Label.Name = "Total_Guests_Label";
            this.Total_Guests_Label.Size = new System.Drawing.Size(0, 13);
            this.Total_Guests_Label.TabIndex = 3;
            // 
            // label10
            // 
            this.label10.AutoSize = true;
            this.label10.Location = new System.Drawing.Point(34, 74);
            this.label10.Name = "label10";
            this.label10.Size = new System.Drawing.Size(89, 13);
            this.label10.TabIndex = 2;
            this.label10.Text = "Assigned Guests:";
            // 
            // label9
            // 
            this.label9.AutoSize = true;
            this.label9.Location = new System.Drawing.Point(21, 48);
            this.label9.Name = "label9";
            this.label9.Size = new System.Drawing.Size(102, 13);
            this.label9.TabIndex = 1;
            this.label9.Text = "Unassigned Guests:";
            // 
            // label8
            // 
            this.label8.AutoSize = true;
            this.label8.Location = new System.Drawing.Point(53, 22);
            this.label8.Name = "label8";
            this.label8.Size = new System.Drawing.Size(70, 13);
            this.label8.TabIndex = 0;
            this.label8.Text = "Total Guests:";
            // 
            // tabPage4
            // 
            this.tabPage4.Controls.Add(this.Special_Level_Combo);
            this.tabPage4.Controls.Add(this.Add_Special_Button);
            this.tabPage4.Controls.Add(this.Special_Uid_Box);
            this.tabPage4.Controls.Add(this.label13);
            this.tabPage4.Controls.Add(this.label14);
            this.tabPage4.Location = new System.Drawing.Point(4, 22);
            this.tabPage4.Name = "tabPage4";
            this.tabPage4.Padding = new System.Windows.Forms.Padding(3);
            this.tabPage4.Size = new System.Drawing.Size(727, 284);
            this.tabPage4.TabIndex = 3;
            this.tabPage4.Text = "Crew/Protocol Cards";
            this.tabPage4.UseVisualStyleBackColor = true;
            // 
            // Add_Special_Button
            // 
            this.Add_Special_Button.Location = new System.Drawing.Point(181, 81);
            this.Add_Special_Button.Name = "Add_Special_Button";
            this.Add_Special_Button.Size = new System.Drawing.Size(75, 23);
            this.Add_Special_Button.TabIndex = 9;
            this.Add_Special_Button.Text = "Add";
            this.Add_Special_Button.UseVisualStyleBackColor = true;
            this.Add_Special_Button.Click += new System.EventHandler(this.Add_Special_Button_Click);
            // 
            // Special_Uid_Box
            // 
            this.Special_Uid_Box.Enabled = false;
            this.Special_Uid_Box.Location = new System.Drawing.Point(92, 14);
            this.Special_Uid_Box.Name = "Special_Uid_Box";
            this.Special_Uid_Box.Size = new System.Drawing.Size(164, 20);
            this.Special_Uid_Box.TabIndex = 7;
            // 
            // label13
            // 
            this.label13.AutoSize = true;
            this.label13.Location = new System.Drawing.Point(50, 43);
            this.label13.Name = "label13";
            this.label13.Size = new System.Drawing.Size(36, 13);
            this.label13.TabIndex = 6;
            this.label13.Text = "Level:";
            // 
            // label14
            // 
            this.label14.AutoSize = true;
            this.label14.Location = new System.Drawing.Point(60, 17);
            this.label14.Name = "label14";
            this.label14.Size = new System.Drawing.Size(26, 13);
            this.label14.TabIndex = 5;
            this.label14.Text = "Uid:";
            // 
            // Special_Level_Combo
            // 
            this.Special_Level_Combo.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.Special_Level_Combo.FormattingEnabled = true;
            this.Special_Level_Combo.Items.AddRange(new object[] {
            "Crew",
            "Protocol"});
            this.Special_Level_Combo.Location = new System.Drawing.Point(92, 40);
            this.Special_Level_Combo.Name = "Special_Level_Combo";
            this.Special_Level_Combo.Size = new System.Drawing.Size(164, 21);
            this.Special_Level_Combo.TabIndex = 10;
            // 
            // MainForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(759, 510);
            this.Controls.Add(this.groupBox2);
            this.Controls.Add(this.groupBox1);
            this.Controls.Add(this.tabControl1);
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Name = "MainForm";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "DataEntryApp - v0.0.8";
            this.Load += new System.EventHandler(this.MainForm_Load);
            this.tabControl1.ResumeLayout(false);
            this.tabPage1.ResumeLayout(false);
            this.tabPage1.PerformLayout();
            this.tabPage2.ResumeLayout(false);
            this.tabPage2.PerformLayout();
            this.tabPage3.ResumeLayout(false);
            this.tabPage3.PerformLayout();
            this.groupBox1.ResumeLayout(false);
            this.groupBox1.PerformLayout();
            this.groupBox2.ResumeLayout(false);
            this.groupBox2.PerformLayout();
            this.tabPage4.ResumeLayout(false);
            this.tabPage4.PerformLayout();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.TextBox Catalog_Box;
        private System.Windows.Forms.Button Connect_Button;
        private System.Windows.Forms.TextBox Search_Box;
        private System.Windows.Forms.ListView Results_View;
        private System.Windows.Forms.ColumnHeader columnHeader1;
        private System.Windows.Forms.ColumnHeader columnHeader2;
        private System.Windows.Forms.ColumnHeader columnHeader3;
        private System.Windows.Forms.ColumnHeader columnHeader4;
        private System.Windows.Forms.ColumnHeader columnHeader5;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.TextBox Uid_Box;
        private System.Windows.Forms.Button Assign_Button;
        private System.Windows.Forms.Button Cancel_Button;
        private System.Windows.Forms.TabControl tabControl1;
        private System.Windows.Forms.TabPage tabPage1;
        private System.Windows.Forms.TabPage tabPage2;
        private System.Windows.Forms.GroupBox groupBox1;
        private System.Windows.Forms.TextBox Password_Box;
        private System.Windows.Forms.TextBox Username_Box;
        private System.Windows.Forms.TextBox Server_Box;
        private System.Windows.Forms.Label label7;
        private System.Windows.Forms.Label label6;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.GroupBox groupBox2;
        private System.Windows.Forms.Label label10;
        private System.Windows.Forms.Label label9;
        private System.Windows.Forms.Label label8;
        private System.Windows.Forms.Label Assigned_Guests_Label;
        private System.Windows.Forms.Label Unassigned_Guests_Label;
        private System.Windows.Forms.Label Total_Guests_Label;
        private System.Windows.Forms.RadioButton Assigned_Radio;
        private System.Windows.Forms.RadioButton Unassigned_Radio;
        private System.Windows.Forms.RadioButton All_Radio;
        private System.Windows.Forms.Button Delete_Button;
        private System.Windows.Forms.ListView Status_List;
        private System.Windows.Forms.ColumnHeader columnHeader6;
        private System.Windows.Forms.ColumnHeader columnHeader7;
        private System.Windows.Forms.ColumnHeader columnHeader8;
        private System.Windows.Forms.ColumnHeader columnHeader9;
        private System.Windows.Forms.ColumnHeader columnHeader10;
        private System.Windows.Forms.ColumnHeader columnHeader11;
        private System.Windows.Forms.TabPage tabPage3;
        private System.Windows.Forms.ListView listView1;
        private System.Windows.Forms.ColumnHeader columnHeader12;
        private System.Windows.Forms.ColumnHeader columnHeader13;
        private System.Windows.Forms.Button Add_Button;
        private System.Windows.Forms.TextBox Serial_Box;
        private System.Windows.Forms.TextBox Temp_Uid_Box;
        private System.Windows.Forms.Label label12;
        private System.Windows.Forms.Label label11;
        private System.Windows.Forms.TabPage tabPage4;
        private System.Windows.Forms.ComboBox Special_Level_Combo;
        private System.Windows.Forms.Button Add_Special_Button;
        private System.Windows.Forms.TextBox Special_Uid_Box;
        private System.Windows.Forms.Label label13;
        private System.Windows.Forms.Label label14;
    }
}

