namespace QTsys
{
    partial class 生产管理
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
            this.label1 = new System.Windows.Forms.Label();
            this.text编号 = new System.Windows.Forms.TextBox();
            this.label2 = new System.Windows.Forms.Label();
            this.com产品编号 = new System.Windows.Forms.ComboBox();
            this.com客户编号 = new System.Windows.Forms.ComboBox();
            this.label3 = new System.Windows.Forms.Label();
            this.date下单日期 = new System.Windows.Forms.DateTimePicker();
            this.label4 = new System.Windows.Forms.Label();
            this.text产品数量 = new System.Windows.Forms.TextBox();
            this.label5 = new System.Windows.Forms.Label();
            this.date交付时间 = new System.Windows.Forms.DateTimePicker();
            this.label6 = new System.Windows.Forms.Label();
            this.date实际完成时间 = new System.Windows.Forms.DateTimePicker();
            this.label7 = new System.Windows.Forms.Label();
            this.com计划类型 = new System.Windows.Forms.ComboBox();
            this.label8 = new System.Windows.Forms.Label();
            this.text相关订单编号 = new System.Windows.Forms.TextBox();
            this.label9 = new System.Windows.Forms.Label();
            this.com负责人 = new System.Windows.Forms.ComboBox();
            this.label10 = new System.Windows.Forms.Label();
            this.button1 = new System.Windows.Forms.Button();
            this.button2 = new System.Windows.Forms.Button();
            this.button3 = new System.Windows.Forms.Button();
            this.text搜索内容 = new System.Windows.Forms.TextBox();
            this.button4 = new System.Windows.Forms.Button();
            this.date_down = new System.Windows.Forms.DateTimePicker();
            this.label11 = new System.Windows.Forms.Label();
            this.date_up = new System.Windows.Forms.DateTimePicker();
            this.label12 = new System.Windows.Forms.Label();
            this.label搜索栏目 = new System.Windows.Forms.Label();
            this.label13 = new System.Windows.Forms.Label();
            this.button5 = new System.Windows.Forms.Button();
            ((System.ComponentModel.ISupportInitialize)(this.dataGridView1)).BeginInit();
            this.SuspendLayout();
            // 
            // dataGridView1
            // 
            this.dataGridView1.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dataGridView1.Location = new System.Drawing.Point(12, 163);
            this.dataGridView1.Name = "dataGridView1";
            this.dataGridView1.RowTemplate.Height = 23;
            this.dataGridView1.Size = new System.Drawing.Size(863, 429);
            this.dataGridView1.TabIndex = 0;
            this.dataGridView1.CellClick += new System.Windows.Forms.DataGridViewCellEventHandler(this.dataGridView1_CellClick);
            this.dataGridView1.CellContentClick += new System.Windows.Forms.DataGridViewCellEventHandler(this.dataGridView1_CellContentClick);
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(38, 15);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(41, 12);
            this.label1.TabIndex = 1;
            this.label1.Text = "编号：";
            // 
            // text编号
            // 
            this.text编号.Enabled = false;
            this.text编号.Location = new System.Drawing.Point(85, 12);
            this.text编号.Name = "text编号";
            this.text编号.Size = new System.Drawing.Size(121, 21);
            this.text编号.TabIndex = 2;
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(17, 42);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(65, 12);
            this.label2.TabIndex = 3;
            this.label2.Text = "产品编号：";
            // 
            // com产品编号
            // 
            this.com产品编号.FormattingEnabled = true;
            this.com产品编号.Location = new System.Drawing.Point(85, 39);
            this.com产品编号.Name = "com产品编号";
            this.com产品编号.Size = new System.Drawing.Size(121, 20);
            this.com产品编号.TabIndex = 4;
            // 
            // com客户编号
            // 
            this.com客户编号.FormattingEnabled = true;
            this.com客户编号.Location = new System.Drawing.Point(85, 65);
            this.com客户编号.Name = "com客户编号";
            this.com客户编号.Size = new System.Drawing.Size(121, 20);
            this.com客户编号.TabIndex = 6;
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(17, 68);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(65, 12);
            this.label3.TabIndex = 5;
            this.label3.Text = "客户编号：";
            // 
            // date下单日期
            // 
            this.date下单日期.Location = new System.Drawing.Point(85, 91);
            this.date下单日期.Name = "date下单日期";
            this.date下单日期.Size = new System.Drawing.Size(121, 21);
            this.date下单日期.TabIndex = 32;
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Location = new System.Drawing.Point(17, 97);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(65, 12);
            this.label4.TabIndex = 31;
            this.label4.Text = "下单日期：";
            // 
            // text产品数量
            // 
            this.text产品数量.Location = new System.Drawing.Point(85, 118);
            this.text产品数量.Name = "text产品数量";
            this.text产品数量.Size = new System.Drawing.Size(121, 21);
            this.text产品数量.TabIndex = 34;
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Location = new System.Drawing.Point(17, 121);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(65, 12);
            this.label5.TabIndex = 33;
            this.label5.Text = "产品数量：";
            // 
            // date交付时间
            // 
            this.date交付时间.Location = new System.Drawing.Point(333, 14);
            this.date交付时间.Name = "date交付时间";
            this.date交付时间.Size = new System.Drawing.Size(121, 21);
            this.date交付时间.TabIndex = 36;
            // 
            // label6
            // 
            this.label6.AutoSize = true;
            this.label6.Location = new System.Drawing.Point(262, 20);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(65, 12);
            this.label6.TabIndex = 35;
            this.label6.Text = "交付时间：";
            // 
            // date实际完成时间
            // 
            this.date实际完成时间.Location = new System.Drawing.Point(333, 41);
            this.date实际完成时间.Name = "date实际完成时间";
            this.date实际完成时间.Size = new System.Drawing.Size(121, 21);
            this.date实际完成时间.TabIndex = 38;
            // 
            // label7
            // 
            this.label7.AutoSize = true;
            this.label7.Location = new System.Drawing.Point(238, 47);
            this.label7.Name = "label7";
            this.label7.Size = new System.Drawing.Size(89, 12);
            this.label7.TabIndex = 37;
            this.label7.Text = "实际完成时间：";
            // 
            // com计划类型
            // 
            this.com计划类型.FormattingEnabled = true;
            this.com计划类型.Location = new System.Drawing.Point(333, 68);
            this.com计划类型.Name = "com计划类型";
            this.com计划类型.Size = new System.Drawing.Size(121, 20);
            this.com计划类型.TabIndex = 40;
            // 
            // label8
            // 
            this.label8.AutoSize = true;
            this.label8.Location = new System.Drawing.Point(262, 71);
            this.label8.Name = "label8";
            this.label8.Size = new System.Drawing.Size(65, 12);
            this.label8.TabIndex = 39;
            this.label8.Text = "计划类型：";
            // 
            // text相关订单编号
            // 
            this.text相关订单编号.Location = new System.Drawing.Point(333, 97);
            this.text相关订单编号.Name = "text相关订单编号";
            this.text相关订单编号.Size = new System.Drawing.Size(121, 21);
            this.text相关订单编号.TabIndex = 42;
            // 
            // label9
            // 
            this.label9.AutoSize = true;
            this.label9.Location = new System.Drawing.Point(238, 100);
            this.label9.Name = "label9";
            this.label9.Size = new System.Drawing.Size(89, 12);
            this.label9.TabIndex = 41;
            this.label9.Text = "相关订单编号：";
            // 
            // com负责人
            // 
            this.com负责人.FormattingEnabled = true;
            this.com负责人.Location = new System.Drawing.Point(333, 121);
            this.com负责人.Name = "com负责人";
            this.com负责人.Size = new System.Drawing.Size(121, 20);
            this.com负责人.TabIndex = 44;
            // 
            // label10
            // 
            this.label10.AutoSize = true;
            this.label10.Location = new System.Drawing.Point(274, 124);
            this.label10.Name = "label10";
            this.label10.Size = new System.Drawing.Size(53, 12);
            this.label10.TabIndex = 43;
            this.label10.Text = "负责人：";
            // 
            // button1
            // 
            this.button1.Location = new System.Drawing.Point(482, 9);
            this.button1.Name = "button1";
            this.button1.Size = new System.Drawing.Size(75, 23);
            this.button1.TabIndex = 45;
            this.button1.Text = "修改并保存";
            this.button1.UseVisualStyleBackColor = true;
            this.button1.Click += new System.EventHandler(this.button1_Click);
            // 
            // button2
            // 
            this.button2.Location = new System.Drawing.Point(482, 46);
            this.button2.Name = "button2";
            this.button2.Size = new System.Drawing.Size(75, 23);
            this.button2.TabIndex = 46;
            this.button2.Text = "新增";
            this.button2.UseVisualStyleBackColor = true;
            this.button2.Click += new System.EventHandler(this.button2_Click);
            // 
            // button3
            // 
            this.button3.Location = new System.Drawing.Point(482, 84);
            this.button3.Name = "button3";
            this.button3.Size = new System.Drawing.Size(75, 23);
            this.button3.TabIndex = 47;
            this.button3.Text = "删除计划";
            this.button3.UseVisualStyleBackColor = true;
            this.button3.Click += new System.EventHandler(this.button3_Click);
            // 
            // text搜索内容
            // 
            this.text搜索内容.Location = new System.Drawing.Point(610, 120);
            this.text搜索内容.Name = "text搜索内容";
            this.text搜索内容.Size = new System.Drawing.Size(159, 21);
            this.text搜索内容.TabIndex = 48;
            // 
            // button4
            // 
            this.button4.Location = new System.Drawing.Point(775, 119);
            this.button4.Name = "button4";
            this.button4.Size = new System.Drawing.Size(100, 23);
            this.button4.TabIndex = 49;
            this.button4.Text = "查询生产计划";
            this.button4.UseVisualStyleBackColor = true;
            this.button4.Click += new System.EventHandler(this.button4_Click);
            // 
            // date_down
            // 
            this.date_down.Location = new System.Drawing.Point(702, 39);
            this.date_down.Name = "date_down";
            this.date_down.Size = new System.Drawing.Size(121, 21);
            this.date_down.TabIndex = 53;
            this.date_down.ValueChanged += new System.EventHandler(this.date_down_ValueChanged);
            // 
            // label11
            // 
            this.label11.AutoSize = true;
            this.label11.Location = new System.Drawing.Point(607, 45);
            this.label11.Name = "label11";
            this.label11.Size = new System.Drawing.Size(89, 12);
            this.label11.TabIndex = 52;
            this.label11.Text = "下单截止时间：";
            // 
            // date_up
            // 
            this.date_up.Location = new System.Drawing.Point(702, 12);
            this.date_up.Name = "date_up";
            this.date_up.Size = new System.Drawing.Size(121, 21);
            this.date_up.TabIndex = 51;
            this.date_up.ValueChanged += new System.EventHandler(this.dateTimePicker5_ValueChanged);
            // 
            // label12
            // 
            this.label12.AutoSize = true;
            this.label12.Location = new System.Drawing.Point(607, 18);
            this.label12.Name = "label12";
            this.label12.Size = new System.Drawing.Size(89, 12);
            this.label12.TabIndex = 50;
            this.label12.Text = "下单起始时间：";
            // 
            // label搜索栏目
            // 
            this.label搜索栏目.AutoSize = true;
            this.label搜索栏目.Font = new System.Drawing.Font("宋体", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.label搜索栏目.ForeColor = System.Drawing.Color.Red;
            this.label搜索栏目.Location = new System.Drawing.Point(526, 123);
            this.label搜索栏目.Name = "label搜索栏目";
            this.label搜索栏目.Size = new System.Drawing.Size(31, 12);
            this.label搜索栏目.TabIndex = 55;
            this.label搜索栏目.Text = "编号";
            // 
            // label13
            // 
            this.label13.AutoSize = true;
            this.label13.Location = new System.Drawing.Point(491, 123);
            this.label13.Name = "label13";
            this.label13.Size = new System.Drawing.Size(29, 12);
            this.label13.TabIndex = 54;
            this.label13.Text = "检索";
            // 
            // button5
            // 
            this.button5.Location = new System.Drawing.Point(649, 71);
            this.button5.Name = "button5";
            this.button5.Size = new System.Drawing.Size(137, 23);
            this.button5.TabIndex = 56;
            this.button5.Text = "产品原料关系设定";
            this.button5.UseVisualStyleBackColor = true;
            this.button5.Click += new System.EventHandler(this.button5_Click);
            // 
            // 生产管理
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 12F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(887, 604);
            this.Controls.Add(this.button5);
            this.Controls.Add(this.label搜索栏目);
            this.Controls.Add(this.label13);
            this.Controls.Add(this.date_down);
            this.Controls.Add(this.label11);
            this.Controls.Add(this.date_up);
            this.Controls.Add(this.label12);
            this.Controls.Add(this.button4);
            this.Controls.Add(this.text搜索内容);
            this.Controls.Add(this.button3);
            this.Controls.Add(this.button2);
            this.Controls.Add(this.button1);
            this.Controls.Add(this.com负责人);
            this.Controls.Add(this.label10);
            this.Controls.Add(this.text相关订单编号);
            this.Controls.Add(this.label9);
            this.Controls.Add(this.com计划类型);
            this.Controls.Add(this.label8);
            this.Controls.Add(this.date实际完成时间);
            this.Controls.Add(this.label7);
            this.Controls.Add(this.date交付时间);
            this.Controls.Add(this.label6);
            this.Controls.Add(this.text产品数量);
            this.Controls.Add(this.label5);
            this.Controls.Add(this.date下单日期);
            this.Controls.Add(this.label4);
            this.Controls.Add(this.com客户编号);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.com产品编号);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.text编号);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.dataGridView1);
            this.Name = "生产管理";
            this.Text = "生产管理";
            this.Load += new System.EventHandler(this.生产管理_Load);
            ((System.ComponentModel.ISupportInitialize)(this.dataGridView1)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.DataGridView dataGridView1;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.TextBox text编号;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.ComboBox com产品编号;
        private System.Windows.Forms.ComboBox com客户编号;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.DateTimePicker date下单日期;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.TextBox text产品数量;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.DateTimePicker date交付时间;
        private System.Windows.Forms.Label label6;
        private System.Windows.Forms.DateTimePicker date实际完成时间;
        private System.Windows.Forms.Label label7;
        private System.Windows.Forms.ComboBox com计划类型;
        private System.Windows.Forms.Label label8;
        private System.Windows.Forms.TextBox text相关订单编号;
        private System.Windows.Forms.Label label9;
        private System.Windows.Forms.ComboBox com负责人;
        private System.Windows.Forms.Label label10;
        private System.Windows.Forms.Button button1;
        private System.Windows.Forms.Button button2;
        private System.Windows.Forms.Button button3;
        private System.Windows.Forms.TextBox text搜索内容;
        private System.Windows.Forms.Button button4;
        private System.Windows.Forms.DateTimePicker date_down;
        private System.Windows.Forms.Label label11;
        private System.Windows.Forms.DateTimePicker date_up;
        private System.Windows.Forms.Label label12;
        private System.Windows.Forms.Label label搜索栏目;
        private System.Windows.Forms.Label label13;
        private System.Windows.Forms.Button button5;
    }
}