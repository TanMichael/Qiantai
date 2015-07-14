namespace QTsys
{
    partial class 打印送货单
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
            this.checkBox1 = new System.Windows.Forms.CheckBox();
            this.date_down = new System.Windows.Forms.DateTimePicker();
            this.label7 = new System.Windows.Forms.Label();
            this.date_up = new System.Windows.Forms.DateTimePicker();
            this.label6 = new System.Windows.Forms.Label();
            this.label5 = new System.Windows.Forms.Label();
            this.label4 = new System.Windows.Forms.Label();
            this.label3 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.text联系电话 = new System.Windows.Forms.TextBox();
            this.button2 = new System.Windows.Forms.Button();
            this.button1 = new System.Windows.Forms.Button();
            this.dataGridView1 = new System.Windows.Forms.DataGridView();
            this.text联系人 = new System.Windows.Forms.TextBox();
            this.text送货地址 = new System.Windows.Forms.TextBox();
            this.text客户名称 = new System.Windows.Forms.TextBox();
            this.label1 = new System.Windows.Forms.Label();
            this.comboBox1 = new System.Windows.Forms.ComboBox();
            this.webBrowser2 = new System.Windows.Forms.WebBrowser();
            this.label8 = new System.Windows.Forms.Label();
            this.button3 = new System.Windows.Forms.Button();
            this.textBox分页数量 = new System.Windows.Forms.TextBox();
            this.label13 = new System.Windows.Forms.Label();
            ((System.ComponentModel.ISupportInitialize)(this.dataGridView1)).BeginInit();
            this.SuspendLayout();
            // 
            // checkBox1
            // 
            this.checkBox1.AutoSize = true;
            this.checkBox1.Checked = true;
            this.checkBox1.CheckState = System.Windows.Forms.CheckState.Checked;
            this.checkBox1.Location = new System.Drawing.Point(14, 118);
            this.checkBox1.Name = "checkBox1";
            this.checkBox1.Size = new System.Drawing.Size(120, 16);
            this.checkBox1.TabIndex = 62;
            this.checkBox1.Text = "是否显示产品单价";
            this.checkBox1.UseVisualStyleBackColor = true;
            // 
            // date_down
            // 
            this.date_down.Location = new System.Drawing.Point(71, 181);
            this.date_down.Name = "date_down";
            this.date_down.Size = new System.Drawing.Size(121, 21);
            this.date_down.TabIndex = 61;
            this.date_down.Visible = false;
            // 
            // label7
            // 
            this.label7.AutoSize = true;
            this.label7.Location = new System.Drawing.Point(12, 187);
            this.label7.Name = "label7";
            this.label7.Size = new System.Drawing.Size(53, 12);
            this.label7.TabIndex = 60;
            this.label7.Text = "终止时间";
            this.label7.Visible = false;
            // 
            // date_up
            // 
            this.date_up.Location = new System.Drawing.Point(71, 150);
            this.date_up.Name = "date_up";
            this.date_up.Size = new System.Drawing.Size(121, 21);
            this.date_up.TabIndex = 59;
            this.date_up.Visible = false;
            this.date_up.ValueChanged += new System.EventHandler(this.date_up_ValueChanged);
            // 
            // label6
            // 
            this.label6.AutoSize = true;
            this.label6.Location = new System.Drawing.Point(12, 155);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(53, 12);
            this.label6.TabIndex = 58;
            this.label6.Text = "起始时间";
            this.label6.Visible = false;
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Location = new System.Drawing.Point(391, 20);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(41, 12);
            this.label5.TabIndex = 57;
            this.label5.Text = "label5";
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Location = new System.Drawing.Point(332, 20);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(65, 12);
            this.label4.TabIndex = 56;
            this.label4.Text = "出货日期：";
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(69, 20);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(41, 12);
            this.label3.TabIndex = 55;
            this.label3.Text = "label3";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(12, 20);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(53, 12);
            this.label2.TabIndex = 54;
            this.label2.Text = "流水号：";
            // 
            // text联系电话
            // 
            this.text联系电话.Enabled = false;
            this.text联系电话.Location = new System.Drawing.Point(332, 64);
            this.text联系电话.Name = "text联系电话";
            this.text联系电话.Size = new System.Drawing.Size(100, 21);
            this.text联系电话.TabIndex = 52;
            // 
            // button2
            // 
            this.button2.Location = new System.Drawing.Point(357, 176);
            this.button2.Name = "button2";
            this.button2.Size = new System.Drawing.Size(75, 23);
            this.button2.TabIndex = 51;
            this.button2.Text = "打印送货单";
            this.button2.UseVisualStyleBackColor = true;
            this.button2.Click += new System.EventHandler(this.button2_Click);
            // 
            // button1
            // 
            this.button1.Location = new System.Drawing.Point(357, 135);
            this.button1.Name = "button1";
            this.button1.Size = new System.Drawing.Size(75, 23);
            this.button1.TabIndex = 50;
            this.button1.Text = "生成送货单";
            this.button1.UseVisualStyleBackColor = true;
            this.button1.Click += new System.EventHandler(this.button1_Click);
            // 
            // dataGridView1
            // 
            this.dataGridView1.AllowUserToAddRows = false;
            this.dataGridView1.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dataGridView1.Location = new System.Drawing.Point(451, 38);
            this.dataGridView1.Name = "dataGridView1";
            this.dataGridView1.ReadOnly = true;
            this.dataGridView1.RowTemplate.Height = 23;
            this.dataGridView1.Size = new System.Drawing.Size(604, 175);
            this.dataGridView1.TabIndex = 49;
            // 
            // text联系人
            // 
            this.text联系人.Enabled = false;
            this.text联系人.Location = new System.Drawing.Point(213, 64);
            this.text联系人.Name = "text联系人";
            this.text联系人.Size = new System.Drawing.Size(100, 21);
            this.text联系人.TabIndex = 47;
            // 
            // text送货地址
            // 
            this.text送货地址.Enabled = false;
            this.text送货地址.Location = new System.Drawing.Point(14, 91);
            this.text送货地址.Name = "text送货地址";
            this.text送货地址.Size = new System.Drawing.Size(418, 21);
            this.text送货地址.TabIndex = 46;
            // 
            // text客户名称
            // 
            this.text客户名称.Enabled = false;
            this.text客户名称.Location = new System.Drawing.Point(14, 64);
            this.text客户名称.Name = "text客户名称";
            this.text客户名称.Size = new System.Drawing.Size(193, 21);
            this.text客户名称.TabIndex = 45;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(12, 41);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(53, 12);
            this.label1.TabIndex = 44;
            this.label1.Text = "客户编号";
            // 
            // comboBox1
            // 
            this.comboBox1.DisplayMember = "客户编号";
            this.comboBox1.Enabled = false;
            this.comboBox1.FormattingEnabled = true;
            this.comboBox1.Location = new System.Drawing.Point(71, 38);
            this.comboBox1.Name = "comboBox1";
            this.comboBox1.Size = new System.Drawing.Size(121, 20);
            this.comboBox1.TabIndex = 43;
            this.comboBox1.ValueMember = "客户编号";
            // 
            // webBrowser2
            // 
            this.webBrowser2.Location = new System.Drawing.Point(12, 219);
            this.webBrowser2.MinimumSize = new System.Drawing.Size(20, 20);
            this.webBrowser2.Name = "webBrowser2";
            this.webBrowser2.Size = new System.Drawing.Size(1043, 405);
            this.webBrowser2.TabIndex = 42;
            this.webBrowser2.Tag = "";
            this.webBrowser2.Url = new System.Uri("http://HTMLPage1.htm", System.UriKind.Absolute);
            // 
            // label8
            // 
            this.label8.AutoSize = true;
            this.label8.Location = new System.Drawing.Point(708, 20);
            this.label8.Name = "label8";
            this.label8.Size = new System.Drawing.Size(137, 12);
            this.label8.TabIndex = 63;
            this.label8.Text = "按订单显示出货产品情况";
            // 
            // button3
            // 
            this.button3.Location = new System.Drawing.Point(213, 176);
            this.button3.Name = "button3";
            this.button3.Size = new System.Drawing.Size(111, 23);
            this.button3.TabIndex = 119;
            this.button3.Text = "生成快递单数据";
            this.button3.UseVisualStyleBackColor = true;
            this.button3.Click += new System.EventHandler(this.button3_Click);
            // 
            // textBox分页数量
            // 
            this.textBox分页数量.Location = new System.Drawing.Point(207, 137);
            this.textBox分页数量.Name = "textBox分页数量";
            this.textBox分页数量.Size = new System.Drawing.Size(49, 21);
            this.textBox分页数量.TabIndex = 124;
            this.textBox分页数量.Text = "10";
            // 
            // label13
            // 
            this.label13.AutoSize = true;
            this.label13.Location = new System.Drawing.Point(262, 140);
            this.label13.Name = "label13";
            this.label13.Size = new System.Drawing.Size(89, 12);
            this.label13.TabIndex = 125;
            this.label13.Text = "条数据进行分页";
            // 
            // 打印送货单
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 12F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1071, 643);
            this.Controls.Add(this.textBox分页数量);
            this.Controls.Add(this.label13);
            this.Controls.Add(this.button3);
            this.Controls.Add(this.label8);
            this.Controls.Add(this.checkBox1);
            this.Controls.Add(this.date_down);
            this.Controls.Add(this.label7);
            this.Controls.Add(this.date_up);
            this.Controls.Add(this.label6);
            this.Controls.Add(this.label5);
            this.Controls.Add(this.label4);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.text联系电话);
            this.Controls.Add(this.button2);
            this.Controls.Add(this.button1);
            this.Controls.Add(this.dataGridView1);
            this.Controls.Add(this.text联系人);
            this.Controls.Add(this.text送货地址);
            this.Controls.Add(this.text客户名称);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.comboBox1);
            this.Controls.Add(this.webBrowser2);
            this.Name = "打印送货单";
            this.Text = "送货单";
            this.Load += new System.EventHandler(this.送货单_Load);
            ((System.ComponentModel.ISupportInitialize)(this.dataGridView1)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.CheckBox checkBox1;
        private System.Windows.Forms.DateTimePicker date_down;
        private System.Windows.Forms.Label label7;
        private System.Windows.Forms.DateTimePicker date_up;
        private System.Windows.Forms.Label label6;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.TextBox text联系电话;
        private System.Windows.Forms.Button button2;
        private System.Windows.Forms.Button button1;
        private System.Windows.Forms.DataGridView dataGridView1;
        private System.Windows.Forms.TextBox text联系人;
        private System.Windows.Forms.TextBox text送货地址;
        private System.Windows.Forms.TextBox text客户名称;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.ComboBox comboBox1;
        private System.Windows.Forms.WebBrowser webBrowser2;
        private System.Windows.Forms.Label label8;
        private System.Windows.Forms.Button button3;
        public System.Windows.Forms.TextBox textBox分页数量;
        private System.Windows.Forms.Label label13;
    }
}