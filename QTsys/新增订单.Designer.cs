namespace QTsys
{
    partial class 新增订单
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
            this.com客户名 = new System.Windows.Forms.ComboBox();
            this.com客户联系人 = new System.Windows.Forms.ComboBox();
            this.label2 = new System.Windows.Forms.Label();
            this.label3 = new System.Windows.Forms.Label();
            this.text联系电话 = new System.Windows.Forms.TextBox();
            this.text收货地址 = new System.Windows.Forms.TextBox();
            this.label4 = new System.Windows.Forms.Label();
            this.label5 = new System.Windows.Forms.Label();
            this.check样品 = new System.Windows.Forms.CheckBox();
            this.label6 = new System.Windows.Forms.Label();
            this.groupBox1 = new System.Windows.Forms.GroupBox();
            this.com结算方式 = new System.Windows.Forms.ComboBox();
            this.groupBox2 = new System.Windows.Forms.GroupBox();
            this.textBox总金额 = new System.Windows.Forms.TextBox();
            this.label8 = new System.Windows.Forms.Label();
            this.button4 = new System.Windows.Forms.Button();
            this.dataGridView2 = new System.Windows.Forms.DataGridView();
            this.产品编号 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.产品名称 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.数量 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.单价 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.折扣 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.成交价 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.label7 = new System.Windows.Forms.Label();
            this.numericUpDown1 = new System.Windows.Forms.NumericUpDown();
            this.text折扣 = new System.Windows.Forms.TextBox();
            this.button1 = new System.Windows.Forms.Button();
            this.button2 = new System.Windows.Forms.Button();
            this.groupBox3 = new System.Windows.Forms.GroupBox();
            this.checkBoxHistory = new System.Windows.Forms.CheckBox();
            this.button5 = new System.Windows.Forms.Button();
            this.button3 = new System.Windows.Forms.Button();
            this.dataGridView1 = new System.Windows.Forms.DataGridView();
            this.textBox产品名称搜索 = new System.Windows.Forms.TextBox();
            this.button新产品 = new System.Windows.Forms.Button();
            this.groupBox1.SuspendLayout();
            this.groupBox2.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dataGridView2)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.numericUpDown1)).BeginInit();
            this.groupBox3.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dataGridView1)).BeginInit();
            this.SuspendLayout();
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(44, 28);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(29, 12);
            this.label1.TabIndex = 0;
            this.label1.Text = "客户";
            // 
            // com客户名
            // 
            this.com客户名.FormattingEnabled = true;
            this.com客户名.Location = new System.Drawing.Point(79, 25);
            this.com客户名.Name = "com客户名";
            this.com客户名.Size = new System.Drawing.Size(275, 20);
            this.com客户名.TabIndex = 1;
            this.com客户名.DropDown += new System.EventHandler(this.comboBox1_DropDown);
            this.com客户名.SelectedIndexChanged += new System.EventHandler(this.com客户名_SelectedIndexChanged);
            // 
            // com客户联系人
            // 
            this.com客户联系人.FormattingEnabled = true;
            this.com客户联系人.Location = new System.Drawing.Point(79, 51);
            this.com客户联系人.Name = "com客户联系人";
            this.com客户联系人.Size = new System.Drawing.Size(121, 20);
            this.com客户联系人.TabIndex = 3;
            this.com客户联系人.DropDown += new System.EventHandler(this.com客户联系人_DragDrop);
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(8, 54);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(65, 12);
            this.label2.TabIndex = 2;
            this.label2.Text = "客户联系人";
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(20, 80);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(53, 12);
            this.label3.TabIndex = 4;
            this.label3.Text = "联系电话";
            // 
            // text联系电话
            // 
            this.text联系电话.Location = new System.Drawing.Point(79, 77);
            this.text联系电话.Name = "text联系电话";
            this.text联系电话.Size = new System.Drawing.Size(121, 21);
            this.text联系电话.TabIndex = 5;
            // 
            // text收货地址
            // 
            this.text收货地址.Location = new System.Drawing.Point(79, 104);
            this.text收货地址.Name = "text收货地址";
            this.text收货地址.Size = new System.Drawing.Size(275, 21);
            this.text收货地址.TabIndex = 7;
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Location = new System.Drawing.Point(20, 107);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(53, 12);
            this.label4.TabIndex = 6;
            this.label4.Text = "收货地址";
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Location = new System.Drawing.Point(20, 134);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(53, 12);
            this.label5.TabIndex = 8;
            this.label5.Text = "结算方式";
            // 
            // check样品
            // 
            this.check样品.AutoSize = true;
            this.check样品.Checked = true;
            this.check样品.CheckState = System.Windows.Forms.CheckState.Checked;
            this.check样品.Location = new System.Drawing.Point(441, 31);
            this.check样品.Name = "check样品";
            this.check样品.Size = new System.Drawing.Size(108, 16);
            this.check样品.TabIndex = 10;
            this.check样品.Text = "是否为样品订单";
            this.check样品.UseVisualStyleBackColor = true;
            // 
            // label6
            // 
            this.label6.AutoSize = true;
            this.label6.Location = new System.Drawing.Point(20, 41);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(53, 12);
            this.label6.TabIndex = 11;
            this.label6.Text = "产品数量";
            // 
            // groupBox1
            // 
            this.groupBox1.Controls.Add(this.com结算方式);
            this.groupBox1.Controls.Add(this.label1);
            this.groupBox1.Controls.Add(this.com客户名);
            this.groupBox1.Controls.Add(this.check样品);
            this.groupBox1.Controls.Add(this.label2);
            this.groupBox1.Controls.Add(this.com客户联系人);
            this.groupBox1.Controls.Add(this.label5);
            this.groupBox1.Controls.Add(this.label3);
            this.groupBox1.Controls.Add(this.text收货地址);
            this.groupBox1.Controls.Add(this.text联系电话);
            this.groupBox1.Controls.Add(this.label4);
            this.groupBox1.Location = new System.Drawing.Point(12, 12);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Size = new System.Drawing.Size(568, 169);
            this.groupBox1.TabIndex = 12;
            this.groupBox1.TabStop = false;
            this.groupBox1.Text = "客户";
            // 
            // com结算方式
            // 
            this.com结算方式.FormattingEnabled = true;
            this.com结算方式.Location = new System.Drawing.Point(79, 131);
            this.com结算方式.Name = "com结算方式";
            this.com结算方式.Size = new System.Drawing.Size(121, 20);
            this.com结算方式.TabIndex = 11;
            // 
            // groupBox2
            // 
            this.groupBox2.Controls.Add(this.textBox总金额);
            this.groupBox2.Controls.Add(this.label8);
            this.groupBox2.Controls.Add(this.button4);
            this.groupBox2.Controls.Add(this.dataGridView2);
            this.groupBox2.Controls.Add(this.label7);
            this.groupBox2.Controls.Add(this.numericUpDown1);
            this.groupBox2.Controls.Add(this.text折扣);
            this.groupBox2.Controls.Add(this.label6);
            this.groupBox2.Location = new System.Drawing.Point(12, 191);
            this.groupBox2.Name = "groupBox2";
            this.groupBox2.Size = new System.Drawing.Size(699, 290);
            this.groupBox2.TabIndex = 13;
            this.groupBox2.TabStop = false;
            this.groupBox2.Text = "产品";
            // 
            // textBox总金额
            // 
            this.textBox总金额.Enabled = false;
            this.textBox总金额.Font = new System.Drawing.Font("宋体", 18F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.textBox总金额.Location = new System.Drawing.Point(519, 40);
            this.textBox总金额.Name = "textBox总金额";
            this.textBox总金额.RightToLeft = System.Windows.Forms.RightToLeft.No;
            this.textBox总金额.Size = new System.Drawing.Size(169, 35);
            this.textBox总金额.TabIndex = 15;
            // 
            // label8
            // 
            this.label8.AutoSize = true;
            this.label8.Location = new System.Drawing.Point(422, 54);
            this.label8.Name = "label8";
            this.label8.Size = new System.Drawing.Size(101, 12);
            this.label8.TabIndex = 14;
            this.label8.Text = "订单总金额（￥）";
            // 
            // button4
            // 
            this.button4.Location = new System.Drawing.Point(298, 261);
            this.button4.Name = "button4";
            this.button4.Size = new System.Drawing.Size(107, 23);
            this.button4.TabIndex = 3;
            this.button4.Text = "删除选择项》";
            this.button4.UseVisualStyleBackColor = true;
            this.button4.Click += new System.EventHandler(this.button4_Click);
            // 
            // dataGridView2
            // 
            this.dataGridView2.AllowUserToAddRows = false;
            this.dataGridView2.AllowUserToDeleteRows = false;
            this.dataGridView2.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dataGridView2.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.产品编号,
            this.产品名称,
            this.数量,
            this.单价,
            this.折扣,
            this.成交价});
            this.dataGridView2.Location = new System.Drawing.Point(10, 106);
            this.dataGridView2.Name = "dataGridView2";
            this.dataGridView2.ReadOnly = true;
            this.dataGridView2.RowTemplate.Height = 23;
            this.dataGridView2.Size = new System.Drawing.Size(678, 150);
            this.dataGridView2.TabIndex = 13;
            this.dataGridView2.CellClick += new System.Windows.Forms.DataGridViewCellEventHandler(this.dataGridView2_CellClick);
            // 
            // 产品编号
            // 
            this.产品编号.HeaderText = "产品编号";
            this.产品编号.Name = "产品编号";
            this.产品编号.ReadOnly = true;
            // 
            // 产品名称
            // 
            this.产品名称.HeaderText = "产品名称";
            this.产品名称.Name = "产品名称";
            this.产品名称.ReadOnly = true;
            // 
            // 数量
            // 
            this.数量.HeaderText = "数量";
            this.数量.Name = "数量";
            this.数量.ReadOnly = true;
            // 
            // 单价
            // 
            this.单价.HeaderText = "单价";
            this.单价.Name = "单价";
            this.单价.ReadOnly = true;
            // 
            // 折扣
            // 
            this.折扣.HeaderText = "折扣";
            this.折扣.Name = "折扣";
            this.折扣.ReadOnly = true;
            // 
            // 成交价
            // 
            this.成交价.HeaderText = "成交价";
            this.成交价.Name = "成交价";
            this.成交价.ReadOnly = true;
            // 
            // label7
            // 
            this.label7.AutoSize = true;
            this.label7.Location = new System.Drawing.Point(44, 81);
            this.label7.Name = "label7";
            this.label7.Size = new System.Drawing.Size(29, 12);
            this.label7.TabIndex = 11;
            this.label7.Text = "折扣";
            // 
            // numericUpDown1
            // 
            this.numericUpDown1.Font = new System.Drawing.Font("宋体", 15F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.numericUpDown1.Location = new System.Drawing.Point(91, 32);
            this.numericUpDown1.Maximum = new decimal(new int[] {
            100000,
            0,
            0,
            0});
            this.numericUpDown1.Name = "numericUpDown1";
            this.numericUpDown1.Size = new System.Drawing.Size(120, 30);
            this.numericUpDown1.TabIndex = 12;
            this.numericUpDown1.ValueChanged += new System.EventHandler(this.numericUpDown1_ValueChanged);
            // 
            // text折扣
            // 
            this.text折扣.Location = new System.Drawing.Point(90, 78);
            this.text折扣.Name = "text折扣";
            this.text折扣.RightToLeft = System.Windows.Forms.RightToLeft.No;
            this.text折扣.Size = new System.Drawing.Size(121, 21);
            this.text折扣.TabIndex = 12;
            this.text折扣.TextChanged += new System.EventHandler(this.textBox4_TextChanged);
            this.text折扣.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.textBox4_KeyPress);
            // 
            // button1
            // 
            this.button1.Location = new System.Drawing.Point(393, 496);
            this.button1.Name = "button1";
            this.button1.Size = new System.Drawing.Size(94, 37);
            this.button1.TabIndex = 14;
            this.button1.Text = "确定";
            this.button1.UseVisualStyleBackColor = true;
            this.button1.Click += new System.EventHandler(this.button1_Click);
            // 
            // button2
            // 
            this.button2.Location = new System.Drawing.Point(549, 496);
            this.button2.Name = "button2";
            this.button2.Size = new System.Drawing.Size(93, 37);
            this.button2.TabIndex = 15;
            this.button2.Text = "取消";
            this.button2.UseVisualStyleBackColor = true;
            this.button2.Click += new System.EventHandler(this.button2_Click);
            // 
            // groupBox3
            // 
            this.groupBox3.Controls.Add(this.button新产品);
            this.groupBox3.Controls.Add(this.checkBoxHistory);
            this.groupBox3.Controls.Add(this.button5);
            this.groupBox3.Controls.Add(this.button3);
            this.groupBox3.Controls.Add(this.dataGridView1);
            this.groupBox3.Controls.Add(this.textBox产品名称搜索);
            this.groupBox3.Location = new System.Drawing.Point(717, 12);
            this.groupBox3.Name = "groupBox3";
            this.groupBox3.Size = new System.Drawing.Size(417, 469);
            this.groupBox3.TabIndex = 16;
            this.groupBox3.TabStop = false;
            this.groupBox3.Text = "选择产品";
            // 
            // checkBoxHistory
            // 
            this.checkBoxHistory.AutoSize = true;
            this.checkBoxHistory.Location = new System.Drawing.Point(20, 54);
            this.checkBoxHistory.Name = "checkBoxHistory";
            this.checkBoxHistory.Size = new System.Drawing.Size(120, 16);
            this.checkBoxHistory.TabIndex = 15;
            this.checkBoxHistory.Text = "从曾经购买中选择";
            this.checkBoxHistory.UseVisualStyleBackColor = true;
            this.checkBoxHistory.CheckedChanged += new System.EventHandler(this.checkBoxHistory_CheckedChanged);
            // 
            // button5
            // 
            this.button5.Location = new System.Drawing.Point(20, 441);
            this.button5.Name = "button5";
            this.button5.Size = new System.Drawing.Size(136, 23);
            this.button5.TabIndex = 14;
            this.button5.Text = "《选择产品加入订单";
            this.button5.UseVisualStyleBackColor = true;
            this.button5.Click += new System.EventHandler(this.button5_Click);
            // 
            // button3
            // 
            this.button3.Location = new System.Drawing.Point(233, 24);
            this.button3.Name = "button3";
            this.button3.Size = new System.Drawing.Size(107, 23);
            this.button3.TabIndex = 2;
            this.button3.Text = "按产品名称搜索";
            this.button3.UseVisualStyleBackColor = true;
            this.button3.Click += new System.EventHandler(this.button3_Click);
            // 
            // dataGridView1
            // 
            this.dataGridView1.AllowUserToAddRows = false;
            this.dataGridView1.AllowUserToDeleteRows = false;
            this.dataGridView1.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dataGridView1.Location = new System.Drawing.Point(20, 77);
            this.dataGridView1.Name = "dataGridView1";
            this.dataGridView1.ReadOnly = true;
            this.dataGridView1.RowTemplate.Height = 23;
            this.dataGridView1.Size = new System.Drawing.Size(386, 358);
            this.dataGridView1.TabIndex = 1;
            this.dataGridView1.CellClick += new System.Windows.Forms.DataGridViewCellEventHandler(this.dataGridView1_CellClick);
            // 
            // textBox产品名称搜索
            // 
            this.textBox产品名称搜索.Location = new System.Drawing.Point(20, 24);
            this.textBox产品名称搜索.Name = "textBox产品名称搜索";
            this.textBox产品名称搜索.Size = new System.Drawing.Size(196, 21);
            this.textBox产品名称搜索.TabIndex = 0;
            // 
            // button新产品
            // 
            this.button新产品.Location = new System.Drawing.Point(271, 442);
            this.button新产品.Name = "button新产品";
            this.button新产品.Size = new System.Drawing.Size(115, 23);
            this.button新产品.TabIndex = 16;
            this.button新产品.Text = "从选中增加新产品";
            this.button新产品.UseVisualStyleBackColor = true;
            this.button新产品.Click += new System.EventHandler(this.button新产品_Click);
            // 
            // 新增订单
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 12F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1141, 554);
            this.Controls.Add(this.groupBox3);
            this.Controls.Add(this.button2);
            this.Controls.Add(this.button1);
            this.Controls.Add(this.groupBox2);
            this.Controls.Add(this.groupBox1);
            this.Name = "新增订单";
            this.Text = "新增订单";
            this.Load += new System.EventHandler(this.新增订单_Load);
            this.groupBox1.ResumeLayout(false);
            this.groupBox1.PerformLayout();
            this.groupBox2.ResumeLayout(false);
            this.groupBox2.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dataGridView2)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.numericUpDown1)).EndInit();
            this.groupBox3.ResumeLayout(false);
            this.groupBox3.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dataGridView1)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.ComboBox com客户名;
        private System.Windows.Forms.ComboBox com客户联系人;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.TextBox text联系电话;
        private System.Windows.Forms.TextBox text收货地址;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.CheckBox check样品;
        private System.Windows.Forms.Label label6;
        private System.Windows.Forms.GroupBox groupBox1;
        private System.Windows.Forms.GroupBox groupBox2;
        private System.Windows.Forms.Button button4;
        private System.Windows.Forms.DataGridView dataGridView2;
        private System.Windows.Forms.Label label7;
        private System.Windows.Forms.NumericUpDown numericUpDown1;
        private System.Windows.Forms.TextBox text折扣;
        private System.Windows.Forms.Button button1;
        private System.Windows.Forms.Button button2;
        private System.Windows.Forms.GroupBox groupBox3;
        private System.Windows.Forms.Button button3;
        private System.Windows.Forms.DataGridView dataGridView1;
        private System.Windows.Forms.TextBox textBox产品名称搜索;
        private System.Windows.Forms.Button button5;
        private System.Windows.Forms.DataGridViewTextBoxColumn 产品编号;
        private System.Windows.Forms.DataGridViewTextBoxColumn 产品名称;
        private System.Windows.Forms.DataGridViewTextBoxColumn 数量;
        private System.Windows.Forms.DataGridViewTextBoxColumn 单价;
        private System.Windows.Forms.DataGridViewTextBoxColumn 折扣;
        private System.Windows.Forms.DataGridViewTextBoxColumn 成交价;
        private System.Windows.Forms.TextBox textBox总金额;
        private System.Windows.Forms.Label label8;
        private System.Windows.Forms.ComboBox com结算方式;
        private System.Windows.Forms.CheckBox checkBoxHistory;
        private System.Windows.Forms.Button button新产品;
    }
}