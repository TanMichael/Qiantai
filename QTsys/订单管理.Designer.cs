namespace QTsys
{
    partial class 订单管理
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
            this.dataGridView1 = new System.Windows.Forms.DataGridView();
            this.button3 = new System.Windows.Forms.Button();
            this.button2 = new System.Windows.Forms.Button();
            this.button1 = new System.Windows.Forms.Button();
            this.label1 = new System.Windows.Forms.Label();
            this.text订单编号 = new System.Windows.Forms.TextBox();
            this.label2 = new System.Windows.Forms.Label();
            this.com客户名 = new System.Windows.Forms.ComboBox();
            this.date创建时间 = new System.Windows.Forms.DateTimePicker();
            this.label客户名 = new System.Windows.Forms.Label();
            this.date发货时间 = new System.Windows.Forms.DateTimePicker();
            this.label4 = new System.Windows.Forms.Label();
            this.date最后更新时间 = new System.Windows.Forms.DateTimePicker();
            this.label5 = new System.Windows.Forms.Label();
            this.label6 = new System.Windows.Forms.Label();
            this.com订单状态 = new System.Windows.Forms.ComboBox();
            this.text快递单号 = new System.Windows.Forms.TextBox();
            this.label7 = new System.Windows.Forms.Label();
            this.text定金金额 = new System.Windows.Forms.TextBox();
            this.label8 = new System.Windows.Forms.Label();
            this.label9 = new System.Windows.Forms.Label();
            this.label10 = new System.Windows.Forms.Label();
            this.com订金方式 = new System.Windows.Forms.ComboBox();
            this.text收货地址 = new System.Windows.Forms.TextBox();
            this.label11 = new System.Windows.Forms.Label();
            this.label12 = new System.Windows.Forms.Label();
            this.com收货联系人 = new System.Windows.Forms.ComboBox();
            this.text收货电话 = new System.Windows.Forms.TextBox();
            this.label13 = new System.Windows.Forms.Label();
            this.com创建人 = new System.Windows.Forms.ComboBox();
            this.label14 = new System.Windows.Forms.Label();
            this.dateTimePicker_down = new System.Windows.Forms.DateTimePicker();
            this.dateTimePicker_up = new System.Windows.Forms.DateTimePicker();
            this.label15 = new System.Windows.Forms.Label();
            this.groupBox1 = new System.Windows.Forms.GroupBox();
            this.label16 = new System.Windows.Forms.Label();
            this.tabControl1 = new System.Windows.Forms.TabControl();
            this.tabPage1 = new System.Windows.Forms.TabPage();
            this.tabPage2 = new System.Windows.Forms.TabPage();
            this.dataGridView2 = new System.Windows.Forms.DataGridView();
            this.button6 = new System.Windows.Forms.Button();
            this.button4 = new System.Windows.Forms.Button();
            this.button5 = new System.Windows.Forms.Button();
            this.label22 = new System.Windows.Forms.Label();
            this.t成交价 = new System.Windows.Forms.TextBox();
            this.label21 = new System.Windows.Forms.Label();
            this.t折扣 = new System.Windows.Forms.TextBox();
            this.label20 = new System.Windows.Forms.Label();
            this.t单价 = new System.Windows.Forms.TextBox();
            this.label19 = new System.Windows.Forms.Label();
            this.t数量 = new System.Windows.Forms.TextBox();
            this.label18 = new System.Windows.Forms.Label();
            this.t产品编号 = new System.Windows.Forms.TextBox();
            this.label17 = new System.Windows.Forms.Label();
            this.t订单编号 = new System.Windows.Forms.TextBox();
            ((System.ComponentModel.ISupportInitialize)(this.dataGridView1)).BeginInit();
            this.groupBox1.SuspendLayout();
            this.tabControl1.SuspendLayout();
            this.tabPage1.SuspendLayout();
            this.tabPage2.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dataGridView2)).BeginInit();
            this.SuspendLayout();
            // 
            // dataGridView1
            // 
            this.dataGridView1.AllowUserToAddRows = false;
            this.dataGridView1.AllowUserToDeleteRows = false;
            this.dataGridView1.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dataGridView1.Location = new System.Drawing.Point(3, 177);
            this.dataGridView1.Name = "dataGridView1";
            this.dataGridView1.ReadOnly = true;
            this.dataGridView1.RowTemplate.Height = 23;
            this.dataGridView1.Size = new System.Drawing.Size(843, 321);
            this.dataGridView1.TabIndex = 0;
            this.dataGridView1.CellClick += new System.Windows.Forms.DataGridViewCellEventHandler(this.dataGridView1_CellClick);
            this.dataGridView1.CellContentClick += new System.Windows.Forms.DataGridViewCellEventHandler(this.dataGridView1_CellContentClick);
            // 
            // button3
            // 
            this.button3.Enabled = false;
            this.button3.Location = new System.Drawing.Point(757, 16);
            this.button3.Name = "button3";
            this.button3.Size = new System.Drawing.Size(75, 23);
            this.button3.TabIndex = 25;
            this.button3.Text = "新增";
            this.button3.UseVisualStyleBackColor = true;
            this.button3.Click += new System.EventHandler(this.button3_Click);
            // 
            // button2
            // 
            this.button2.Location = new System.Drawing.Point(757, 148);
            this.button2.Name = "button2";
            this.button2.Size = new System.Drawing.Size(75, 23);
            this.button2.TabIndex = 24;
            this.button2.Text = "删除";
            this.button2.UseVisualStyleBackColor = true;
            this.button2.Click += new System.EventHandler(this.button2_Click);
            // 
            // button1
            // 
            this.button1.Location = new System.Drawing.Point(654, 16);
            this.button1.Name = "button1";
            this.button1.Size = new System.Drawing.Size(75, 23);
            this.button1.TabIndex = 23;
            this.button1.Text = "修改并保存";
            this.button1.UseVisualStyleBackColor = true;
            this.button1.Click += new System.EventHandler(this.button1_Click);
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(19, 21);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(65, 12);
            this.label1.TabIndex = 26;
            this.label1.Text = "订单编号：";
            // 
            // text订单编号
            // 
            this.text订单编号.Enabled = false;
            this.text订单编号.Location = new System.Drawing.Point(90, 18);
            this.text订单编号.Name = "text订单编号";
            this.text订单编号.Size = new System.Drawing.Size(121, 21);
            this.text订单编号.TabIndex = 27;
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(19, 48);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(65, 12);
            this.label2.TabIndex = 28;
            this.label2.Text = "创建时间：";
            // 
            // com客户名
            // 
            this.com客户名.FormattingEnabled = true;
            this.com客户名.Location = new System.Drawing.Point(90, 73);
            this.com客户名.Name = "com客户名";
            this.com客户名.Size = new System.Drawing.Size(121, 20);
            this.com客户名.TabIndex = 29;
            // 
            // date创建时间
            // 
            this.date创建时间.Location = new System.Drawing.Point(90, 46);
            this.date创建时间.Name = "date创建时间";
            this.date创建时间.Size = new System.Drawing.Size(121, 21);
            this.date创建时间.TabIndex = 30;
            // 
            // label客户名
            // 
            this.label客户名.AutoSize = true;
            this.label客户名.Location = new System.Drawing.Point(17, 76);
            this.label客户名.Name = "label客户名";
            this.label客户名.Size = new System.Drawing.Size(53, 12);
            this.label客户名.TabIndex = 31;
            this.label客户名.Text = "客户名：";
            // 
            // date发货时间
            // 
            this.date发货时间.Location = new System.Drawing.Point(306, 18);
            this.date发货时间.Name = "date发货时间";
            this.date发货时间.Size = new System.Drawing.Size(121, 21);
            this.date发货时间.TabIndex = 33;
            this.date发货时间.ValueChanged += new System.EventHandler(this.dateTimePicker2_ValueChanged);
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Location = new System.Drawing.Point(241, 21);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(65, 12);
            this.label4.TabIndex = 32;
            this.label4.Text = "发货时间：";
            // 
            // date最后更新时间
            // 
            this.date最后更新时间.Enabled = false;
            this.date最后更新时间.Location = new System.Drawing.Point(306, 43);
            this.date最后更新时间.Name = "date最后更新时间";
            this.date最后更新时间.Size = new System.Drawing.Size(121, 21);
            this.date最后更新时间.TabIndex = 35;
            this.date最后更新时间.ValueChanged += new System.EventHandler(this.dateTimePicker3_ValueChanged);
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Location = new System.Drawing.Point(217, 48);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(89, 12);
            this.label5.TabIndex = 34;
            this.label5.Text = "最后更新时间：";
            // 
            // label6
            // 
            this.label6.AutoSize = true;
            this.label6.Location = new System.Drawing.Point(241, 76);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(65, 12);
            this.label6.TabIndex = 37;
            this.label6.Text = "订单状态：";
            // 
            // com订单状态
            // 
            this.com订单状态.FormattingEnabled = true;
            this.com订单状态.Location = new System.Drawing.Point(306, 73);
            this.com订单状态.Name = "com订单状态";
            this.com订单状态.Size = new System.Drawing.Size(121, 20);
            this.com订单状态.TabIndex = 36;
            // 
            // text快递单号
            // 
            this.text快递单号.Location = new System.Drawing.Point(517, 18);
            this.text快递单号.Name = "text快递单号";
            this.text快递单号.Size = new System.Drawing.Size(121, 21);
            this.text快递单号.TabIndex = 39;
            // 
            // label7
            // 
            this.label7.AutoSize = true;
            this.label7.Location = new System.Drawing.Point(446, 21);
            this.label7.Name = "label7";
            this.label7.Size = new System.Drawing.Size(65, 12);
            this.label7.TabIndex = 38;
            this.label7.Text = "快递单号：";
            // 
            // text定金金额
            // 
            this.text定金金额.Location = new System.Drawing.Point(517, 45);
            this.text定金金额.Name = "text定金金额";
            this.text定金金额.Size = new System.Drawing.Size(95, 21);
            this.text定金金额.TabIndex = 41;
            // 
            // label8
            // 
            this.label8.AutoSize = true;
            this.label8.Location = new System.Drawing.Point(446, 48);
            this.label8.Name = "label8";
            this.label8.Size = new System.Drawing.Size(65, 12);
            this.label8.TabIndex = 40;
            this.label8.Text = "定金金额：";
            // 
            // label9
            // 
            this.label9.AutoSize = true;
            this.label9.Location = new System.Drawing.Point(618, 48);
            this.label9.Name = "label9";
            this.label9.Size = new System.Drawing.Size(23, 12);
            this.label9.TabIndex = 42;
            this.label9.Text = "RMB";
            // 
            // label10
            // 
            this.label10.AutoSize = true;
            this.label10.Location = new System.Drawing.Point(446, 73);
            this.label10.Name = "label10";
            this.label10.Size = new System.Drawing.Size(65, 12);
            this.label10.TabIndex = 44;
            this.label10.Text = "订金方式：";
            // 
            // com订金方式
            // 
            this.com订金方式.FormattingEnabled = true;
            this.com订金方式.Location = new System.Drawing.Point(517, 72);
            this.com订金方式.Name = "com订金方式";
            this.com订金方式.Size = new System.Drawing.Size(121, 20);
            this.com订金方式.TabIndex = 43;
            // 
            // text收货地址
            // 
            this.text收货地址.Location = new System.Drawing.Point(90, 108);
            this.text收货地址.Name = "text收货地址";
            this.text收货地址.Size = new System.Drawing.Size(548, 21);
            this.text收货地址.TabIndex = 46;
            // 
            // label11
            // 
            this.label11.AutoSize = true;
            this.label11.Location = new System.Drawing.Point(19, 111);
            this.label11.Name = "label11";
            this.label11.Size = new System.Drawing.Size(65, 12);
            this.label11.TabIndex = 45;
            this.label11.Text = "收货地址：";
            // 
            // label12
            // 
            this.label12.AutoSize = true;
            this.label12.Location = new System.Drawing.Point(5, 145);
            this.label12.Name = "label12";
            this.label12.Size = new System.Drawing.Size(77, 12);
            this.label12.TabIndex = 47;
            this.label12.Text = "收货联系人：";
            // 
            // com收货联系人
            // 
            this.com收货联系人.FormattingEnabled = true;
            this.com收货联系人.Location = new System.Drawing.Point(90, 142);
            this.com收货联系人.Name = "com收货联系人";
            this.com收货联系人.Size = new System.Drawing.Size(121, 20);
            this.com收货联系人.TabIndex = 48;
            // 
            // text收货电话
            // 
            this.text收货电话.Location = new System.Drawing.Point(306, 142);
            this.text收货电话.Name = "text收货电话";
            this.text收货电话.Size = new System.Drawing.Size(121, 21);
            this.text收货电话.TabIndex = 50;
            // 
            // label13
            // 
            this.label13.AutoSize = true;
            this.label13.Location = new System.Drawing.Point(241, 148);
            this.label13.Name = "label13";
            this.label13.Size = new System.Drawing.Size(65, 12);
            this.label13.TabIndex = 49;
            this.label13.Text = "收货电话：";
            // 
            // com创建人
            // 
            this.com创建人.Enabled = false;
            this.com创建人.FormattingEnabled = true;
            this.com创建人.Location = new System.Drawing.Point(517, 145);
            this.com创建人.Name = "com创建人";
            this.com创建人.Size = new System.Drawing.Size(121, 20);
            this.com创建人.TabIndex = 52;
            // 
            // label14
            // 
            this.label14.AutoSize = true;
            this.label14.Location = new System.Drawing.Point(458, 148);
            this.label14.Name = "label14";
            this.label14.Size = new System.Drawing.Size(53, 12);
            this.label14.TabIndex = 51;
            this.label14.Text = "创建人：";
            // 
            // dateTimePicker_down
            // 
            this.dateTimePicker_down.Location = new System.Drawing.Point(33, 51);
            this.dateTimePicker_down.Name = "dateTimePicker_down";
            this.dateTimePicker_down.Size = new System.Drawing.Size(121, 21);
            this.dateTimePicker_down.TabIndex = 54;
            this.dateTimePicker_down.ValueChanged += new System.EventHandler(this.dateTimePicker_down_ValueChanged);
            // 
            // dateTimePicker_up
            // 
            this.dateTimePicker_up.Location = new System.Drawing.Point(33, 20);
            this.dateTimePicker_up.Name = "dateTimePicker_up";
            this.dateTimePicker_up.Size = new System.Drawing.Size(121, 21);
            this.dateTimePicker_up.TabIndex = 53;
            this.dateTimePicker_up.ValueChanged += new System.EventHandler(this.dateTimePicker_up_ValueChanged);
            // 
            // label15
            // 
            this.label15.AutoSize = true;
            this.label15.Location = new System.Drawing.Point(10, 25);
            this.label15.Name = "label15";
            this.label15.Size = new System.Drawing.Size(17, 12);
            this.label15.TabIndex = 55;
            this.label15.Text = "从";
            // 
            // groupBox1
            // 
            this.groupBox1.Controls.Add(this.label16);
            this.groupBox1.Controls.Add(this.dateTimePicker_up);
            this.groupBox1.Controls.Add(this.label15);
            this.groupBox1.Controls.Add(this.dateTimePicker_down);
            this.groupBox1.Location = new System.Drawing.Point(654, 48);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Size = new System.Drawing.Size(178, 94);
            this.groupBox1.TabIndex = 56;
            this.groupBox1.TabStop = false;
            this.groupBox1.Text = "订单创建日期范围";
            // 
            // label16
            // 
            this.label16.AutoSize = true;
            this.label16.Location = new System.Drawing.Point(10, 57);
            this.label16.Name = "label16";
            this.label16.Size = new System.Drawing.Size(17, 12);
            this.label16.TabIndex = 56;
            this.label16.Text = "到";
            // 
            // tabControl1
            // 
            this.tabControl1.Controls.Add(this.tabPage1);
            this.tabControl1.Controls.Add(this.tabPage2);
            this.tabControl1.Location = new System.Drawing.Point(12, 12);
            this.tabControl1.Name = "tabControl1";
            this.tabControl1.SelectedIndex = 0;
            this.tabControl1.Size = new System.Drawing.Size(860, 530);
            this.tabControl1.TabIndex = 57;
            this.tabControl1.Selected += new System.Windows.Forms.TabControlEventHandler(this.tabControl1_Selected);
            // 
            // tabPage1
            // 
            this.tabPage1.Controls.Add(this.label1);
            this.tabPage1.Controls.Add(this.dataGridView1);
            this.tabPage1.Controls.Add(this.groupBox1);
            this.tabPage1.Controls.Add(this.button1);
            this.tabPage1.Controls.Add(this.com创建人);
            this.tabPage1.Controls.Add(this.button2);
            this.tabPage1.Controls.Add(this.label14);
            this.tabPage1.Controls.Add(this.button3);
            this.tabPage1.Controls.Add(this.text收货电话);
            this.tabPage1.Controls.Add(this.text订单编号);
            this.tabPage1.Controls.Add(this.label13);
            this.tabPage1.Controls.Add(this.label2);
            this.tabPage1.Controls.Add(this.com收货联系人);
            this.tabPage1.Controls.Add(this.com客户名);
            this.tabPage1.Controls.Add(this.label12);
            this.tabPage1.Controls.Add(this.date创建时间);
            this.tabPage1.Controls.Add(this.text收货地址);
            this.tabPage1.Controls.Add(this.label客户名);
            this.tabPage1.Controls.Add(this.label11);
            this.tabPage1.Controls.Add(this.label4);
            this.tabPage1.Controls.Add(this.label10);
            this.tabPage1.Controls.Add(this.date发货时间);
            this.tabPage1.Controls.Add(this.com订金方式);
            this.tabPage1.Controls.Add(this.label5);
            this.tabPage1.Controls.Add(this.label9);
            this.tabPage1.Controls.Add(this.date最后更新时间);
            this.tabPage1.Controls.Add(this.text定金金额);
            this.tabPage1.Controls.Add(this.com订单状态);
            this.tabPage1.Controls.Add(this.label8);
            this.tabPage1.Controls.Add(this.label6);
            this.tabPage1.Controls.Add(this.text快递单号);
            this.tabPage1.Controls.Add(this.label7);
            this.tabPage1.Location = new System.Drawing.Point(4, 22);
            this.tabPage1.Name = "tabPage1";
            this.tabPage1.Padding = new System.Windows.Forms.Padding(3);
            this.tabPage1.Size = new System.Drawing.Size(852, 504);
            this.tabPage1.TabIndex = 0;
            this.tabPage1.Text = "订单";
            this.tabPage1.UseVisualStyleBackColor = true;
            // 
            // tabPage2
            // 
            this.tabPage2.Controls.Add(this.dataGridView2);
            this.tabPage2.Controls.Add(this.button6);
            this.tabPage2.Controls.Add(this.button4);
            this.tabPage2.Controls.Add(this.button5);
            this.tabPage2.Controls.Add(this.label22);
            this.tabPage2.Controls.Add(this.t成交价);
            this.tabPage2.Controls.Add(this.label21);
            this.tabPage2.Controls.Add(this.t折扣);
            this.tabPage2.Controls.Add(this.label20);
            this.tabPage2.Controls.Add(this.t单价);
            this.tabPage2.Controls.Add(this.label19);
            this.tabPage2.Controls.Add(this.t数量);
            this.tabPage2.Controls.Add(this.label18);
            this.tabPage2.Controls.Add(this.t产品编号);
            this.tabPage2.Controls.Add(this.label17);
            this.tabPage2.Controls.Add(this.t订单编号);
            this.tabPage2.Location = new System.Drawing.Point(4, 22);
            this.tabPage2.Name = "tabPage2";
            this.tabPage2.Padding = new System.Windows.Forms.Padding(3);
            this.tabPage2.Size = new System.Drawing.Size(852, 504);
            this.tabPage2.TabIndex = 1;
            this.tabPage2.Text = "订单明细";
            this.tabPage2.UseVisualStyleBackColor = true;
            this.tabPage2.Click += new System.EventHandler(this.tabPage2_Click);
            // 
            // dataGridView2
            // 
            this.dataGridView2.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dataGridView2.Location = new System.Drawing.Point(6, 156);
            this.dataGridView2.Name = "dataGridView2";
            this.dataGridView2.RowTemplate.Height = 23;
            this.dataGridView2.Size = new System.Drawing.Size(823, 342);
            this.dataGridView2.TabIndex = 45;
            this.dataGridView2.CellClick += new System.Windows.Forms.DataGridViewCellEventHandler(this.dataGridView2_CellClick);
            this.dataGridView2.CellContentClick += new System.Windows.Forms.DataGridViewCellEventHandler(this.dataGridView2_CellContentClick);
            // 
            // button6
            // 
            this.button6.Location = new System.Drawing.Point(754, 92);
            this.button6.Name = "button6";
            this.button6.Size = new System.Drawing.Size(75, 23);
            this.button6.TabIndex = 44;
            this.button6.Text = "删除";
            this.button6.UseVisualStyleBackColor = true;
            this.button6.Click += new System.EventHandler(this.button6_Click);
            // 
            // button4
            // 
            this.button4.Location = new System.Drawing.Point(496, 20);
            this.button4.Name = "button4";
            this.button4.Size = new System.Drawing.Size(75, 23);
            this.button4.TabIndex = 42;
            this.button4.Text = "修改并保存";
            this.button4.UseVisualStyleBackColor = true;
            this.button4.Click += new System.EventHandler(this.button4_Click);
            // 
            // button5
            // 
            this.button5.Enabled = false;
            this.button5.Location = new System.Drawing.Point(599, 20);
            this.button5.Name = "button5";
            this.button5.Size = new System.Drawing.Size(75, 23);
            this.button5.TabIndex = 43;
            this.button5.Text = "新增";
            this.button5.UseVisualStyleBackColor = true;
            this.button5.Click += new System.EventHandler(this.button5_Click);
            // 
            // label22
            // 
            this.label22.AutoSize = true;
            this.label22.Location = new System.Drawing.Point(240, 57);
            this.label22.Name = "label22";
            this.label22.Size = new System.Drawing.Size(53, 12);
            this.label22.TabIndex = 38;
            this.label22.Text = "成交价：";
            // 
            // t成交价
            // 
            this.t成交价.Location = new System.Drawing.Point(299, 54);
            this.t成交价.Name = "t成交价";
            this.t成交价.Size = new System.Drawing.Size(121, 21);
            this.t成交价.TabIndex = 39;
            // 
            // label21
            // 
            this.label21.AutoSize = true;
            this.label21.Location = new System.Drawing.Point(252, 25);
            this.label21.Name = "label21";
            this.label21.Size = new System.Drawing.Size(41, 12);
            this.label21.TabIndex = 36;
            this.label21.Text = "折扣：";
            // 
            // t折扣
            // 
            this.t折扣.Location = new System.Drawing.Point(299, 22);
            this.t折扣.Name = "t折扣";
            this.t折扣.Size = new System.Drawing.Size(121, 21);
            this.t折扣.TabIndex = 37;
            // 
            // label20
            // 
            this.label20.AutoSize = true;
            this.label20.Location = new System.Drawing.Point(40, 123);
            this.label20.Name = "label20";
            this.label20.Size = new System.Drawing.Size(41, 12);
            this.label20.TabIndex = 34;
            this.label20.Text = "单价：";
            // 
            // t单价
            // 
            this.t单价.Location = new System.Drawing.Point(87, 120);
            this.t单价.Name = "t单价";
            this.t单价.Size = new System.Drawing.Size(121, 21);
            this.t单价.TabIndex = 35;
            // 
            // label19
            // 
            this.label19.AutoSize = true;
            this.label19.Location = new System.Drawing.Point(40, 92);
            this.label19.Name = "label19";
            this.label19.Size = new System.Drawing.Size(41, 12);
            this.label19.TabIndex = 32;
            this.label19.Text = "数量：";
            // 
            // t数量
            // 
            this.t数量.Location = new System.Drawing.Point(87, 89);
            this.t数量.Name = "t数量";
            this.t数量.Size = new System.Drawing.Size(121, 21);
            this.t数量.TabIndex = 33;
            // 
            // label18
            // 
            this.label18.AutoSize = true;
            this.label18.Location = new System.Drawing.Point(16, 57);
            this.label18.Name = "label18";
            this.label18.Size = new System.Drawing.Size(65, 12);
            this.label18.TabIndex = 30;
            this.label18.Text = "产品编号：";
            // 
            // t产品编号
            // 
            this.t产品编号.Location = new System.Drawing.Point(87, 54);
            this.t产品编号.Name = "t产品编号";
            this.t产品编号.Size = new System.Drawing.Size(121, 21);
            this.t产品编号.TabIndex = 31;
            // 
            // label17
            // 
            this.label17.AutoSize = true;
            this.label17.Location = new System.Drawing.Point(16, 25);
            this.label17.Name = "label17";
            this.label17.Size = new System.Drawing.Size(65, 12);
            this.label17.TabIndex = 28;
            this.label17.Text = "订单编号：";
            // 
            // t订单编号
            // 
            this.t订单编号.Location = new System.Drawing.Point(87, 22);
            this.t订单编号.Name = "t订单编号";
            this.t订单编号.Size = new System.Drawing.Size(121, 21);
            this.t订单编号.TabIndex = 29;
            // 
            // 订单管理
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 12F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(881, 548);
            this.Controls.Add(this.tabControl1);
            this.Name = "订单管理";
            this.Text = "订单管理";
            this.Load += new System.EventHandler(this.订单管理_Load);
            ((System.ComponentModel.ISupportInitialize)(this.dataGridView1)).EndInit();
            this.groupBox1.ResumeLayout(false);
            this.groupBox1.PerformLayout();
            this.tabControl1.ResumeLayout(false);
            this.tabPage1.ResumeLayout(false);
            this.tabPage1.PerformLayout();
            this.tabPage2.ResumeLayout(false);
            this.tabPage2.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dataGridView2)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.DataGridView dataGridView1;
        private System.Windows.Forms.Button button3;
        private System.Windows.Forms.Button button2;
        private System.Windows.Forms.Button button1;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.TextBox text订单编号;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.ComboBox com客户名;
        private System.Windows.Forms.DateTimePicker date创建时间;
        private System.Windows.Forms.Label label客户名;
        private System.Windows.Forms.DateTimePicker date发货时间;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.DateTimePicker date最后更新时间;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.Label label6;
        private System.Windows.Forms.ComboBox com订单状态;
        private System.Windows.Forms.TextBox text快递单号;
        private System.Windows.Forms.Label label7;
        private System.Windows.Forms.TextBox text定金金额;
        private System.Windows.Forms.Label label8;
        private System.Windows.Forms.Label label9;
        private System.Windows.Forms.Label label10;
        private System.Windows.Forms.ComboBox com订金方式;
        private System.Windows.Forms.TextBox text收货地址;
        private System.Windows.Forms.Label label11;
        private System.Windows.Forms.Label label12;
        private System.Windows.Forms.ComboBox com收货联系人;
        private System.Windows.Forms.TextBox text收货电话;
        private System.Windows.Forms.Label label13;
        private System.Windows.Forms.ComboBox com创建人;
        private System.Windows.Forms.Label label14;
        private System.Windows.Forms.DateTimePicker dateTimePicker_down;
        private System.Windows.Forms.DateTimePicker dateTimePicker_up;
        private System.Windows.Forms.Label label15;
        private System.Windows.Forms.GroupBox groupBox1;
        private System.Windows.Forms.Label label16;
        private System.Windows.Forms.TabControl tabControl1;
        private System.Windows.Forms.TabPage tabPage1;
        private System.Windows.Forms.TabPage tabPage2;
        private System.Windows.Forms.Button button6;
        private System.Windows.Forms.Button button4;
        private System.Windows.Forms.Button button5;
        private System.Windows.Forms.Label label22;
        private System.Windows.Forms.TextBox t成交价;
        private System.Windows.Forms.Label label21;
        private System.Windows.Forms.TextBox t折扣;
        private System.Windows.Forms.Label label20;
        private System.Windows.Forms.TextBox t单价;
        private System.Windows.Forms.Label label19;
        private System.Windows.Forms.TextBox t数量;
        private System.Windows.Forms.Label label18;
        private System.Windows.Forms.TextBox t产品编号;
        private System.Windows.Forms.Label label17;
        private System.Windows.Forms.TextBox t订单编号;
        private System.Windows.Forms.DataGridView dataGridView2;
    }
}