namespace QTsys
{
    partial class 对账
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
            this.label5 = new System.Windows.Forms.Label();
            this.comboBox客户 = new System.Windows.Forms.ComboBox();
            this.dateTimePicker对账截止日 = new System.Windows.Forms.DateTimePicker();
            this.对账截止日 = new System.Windows.Forms.Label();
            this.dateTimePicker对账起始日 = new System.Windows.Forms.DateTimePicker();
            this.对账起始日 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.com客户联系人 = new System.Windows.Forms.ComboBox();
            this.label3 = new System.Windows.Forms.Label();
            this.text收货地址 = new System.Windows.Forms.TextBox();
            this.text联系电话 = new System.Windows.Forms.TextBox();
            this.label4 = new System.Windows.Forms.Label();
            this.dataGridView对账单 = new System.Windows.Forms.DataGridView();
            this.button生成 = new System.Windows.Forms.Button();
            this.button打印 = new System.Windows.Forms.Button();
            this.label1 = new System.Windows.Forms.Label();
            this.textBox传真 = new System.Windows.Forms.TextBox();
            this.label6 = new System.Windows.Forms.Label();
            this.textBox结算方式 = new System.Windows.Forms.TextBox();
            this.button1 = new System.Windows.Forms.Button();
            ((System.ComponentModel.ISupportInitialize)(this.dataGridView对账单)).BeginInit();
            this.SuspendLayout();
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Location = new System.Drawing.Point(36, 27);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(53, 12);
            this.label5.TabIndex = 78;
            this.label5.Text = "客户名称";
            // 
            // comboBox客户
            // 
            this.comboBox客户.DisplayMember = "客户编号";
            this.comboBox客户.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.comboBox客户.FormattingEnabled = true;
            this.comboBox客户.Location = new System.Drawing.Point(95, 24);
            this.comboBox客户.Name = "comboBox客户";
            this.comboBox客户.Size = new System.Drawing.Size(235, 20);
            this.comboBox客户.TabIndex = 76;
            this.comboBox客户.ValueMember = "客户编号";
            this.comboBox客户.SelectedIndexChanged += new System.EventHandler(this.comboBox客户_SelectedIndexChanged);
            // 
            // dateTimePicker对账截止日
            // 
            this.dateTimePicker对账截止日.Location = new System.Drawing.Point(535, 48);
            this.dateTimePicker对账截止日.Name = "dateTimePicker对账截止日";
            this.dateTimePicker对账截止日.Size = new System.Drawing.Size(121, 21);
            this.dateTimePicker对账截止日.TabIndex = 83;
            // 
            // 对账截止日
            // 
            this.对账截止日.AutoSize = true;
            this.对账截止日.Location = new System.Drawing.Point(464, 54);
            this.对账截止日.Name = "对账截止日";
            this.对账截止日.Size = new System.Drawing.Size(77, 12);
            this.对账截止日.TabIndex = 82;
            this.对账截止日.Text = "对账截止日：";
            // 
            // dateTimePicker对账起始日
            // 
            this.dateTimePicker对账起始日.Location = new System.Drawing.Point(535, 21);
            this.dateTimePicker对账起始日.Name = "dateTimePicker对账起始日";
            this.dateTimePicker对账起始日.Size = new System.Drawing.Size(121, 21);
            this.dateTimePicker对账起始日.TabIndex = 81;
            // 
            // 对账起始日
            // 
            this.对账起始日.AutoSize = true;
            this.对账起始日.Location = new System.Drawing.Point(464, 27);
            this.对账起始日.Name = "对账起始日";
            this.对账起始日.Size = new System.Drawing.Size(77, 12);
            this.对账起始日.TabIndex = 80;
            this.对账起始日.Text = "对账起始日：";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(24, 57);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(65, 12);
            this.label2.TabIndex = 84;
            this.label2.Text = "客户联系人";
            // 
            // com客户联系人
            // 
            this.com客户联系人.FormattingEnabled = true;
            this.com客户联系人.Location = new System.Drawing.Point(95, 54);
            this.com客户联系人.Name = "com客户联系人";
            this.com客户联系人.Size = new System.Drawing.Size(121, 20);
            this.com客户联系人.TabIndex = 85;
            this.com客户联系人.DropDown += new System.EventHandler(this.com客户联系人_DropDown);
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(36, 83);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(53, 12);
            this.label3.TabIndex = 86;
            this.label3.Text = "联系电话";
            // 
            // text收货地址
            // 
            this.text收货地址.Location = new System.Drawing.Point(95, 107);
            this.text收货地址.Name = "text收货地址";
            this.text收货地址.Size = new System.Drawing.Size(275, 21);
            this.text收货地址.TabIndex = 89;
            // 
            // text联系电话
            // 
            this.text联系电话.Location = new System.Drawing.Point(95, 80);
            this.text联系电话.Name = "text联系电话";
            this.text联系电话.Size = new System.Drawing.Size(121, 21);
            this.text联系电话.TabIndex = 87;
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Location = new System.Drawing.Point(36, 110);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(53, 12);
            this.label4.TabIndex = 88;
            this.label4.Text = "收货地址";
            // 
            // dataGridView对账单
            // 
            this.dataGridView对账单.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dataGridView对账单.Location = new System.Drawing.Point(12, 165);
            this.dataGridView对账单.Name = "dataGridView对账单";
            this.dataGridView对账单.RowTemplate.Height = 23;
            this.dataGridView对账单.Size = new System.Drawing.Size(965, 552);
            this.dataGridView对账单.TabIndex = 90;
            // 
            // button生成
            // 
            this.button生成.Location = new System.Drawing.Point(566, 110);
            this.button生成.Name = "button生成";
            this.button生成.Size = new System.Drawing.Size(90, 30);
            this.button生成.TabIndex = 91;
            this.button生成.Text = "生成对账数据";
            this.button生成.UseVisualStyleBackColor = true;
            this.button生成.Click += new System.EventHandler(this.button生成_Click);
            // 
            // button打印
            // 
            this.button打印.Location = new System.Drawing.Point(679, 110);
            this.button打印.Name = "button打印";
            this.button打印.Size = new System.Drawing.Size(86, 30);
            this.button打印.TabIndex = 92;
            this.button打印.Text = "打印对账单";
            this.button打印.UseVisualStyleBackColor = true;
            this.button打印.Click += new System.EventHandler(this.button打印_Click);
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(239, 83);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(29, 12);
            this.label1.TabIndex = 93;
            this.label1.Text = "传真";
            // 
            // textBox传真
            // 
            this.textBox传真.Location = new System.Drawing.Point(298, 80);
            this.textBox传真.Name = "textBox传真";
            this.textBox传真.Size = new System.Drawing.Size(121, 21);
            this.textBox传真.TabIndex = 94;
            // 
            // label6
            // 
            this.label6.AutoSize = true;
            this.label6.Location = new System.Drawing.Point(36, 141);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(53, 12);
            this.label6.TabIndex = 95;
            this.label6.Text = "结算方式";
            // 
            // textBox结算方式
            // 
            this.textBox结算方式.Location = new System.Drawing.Point(95, 138);
            this.textBox结算方式.Name = "textBox结算方式";
            this.textBox结算方式.Size = new System.Drawing.Size(121, 21);
            this.textBox结算方式.TabIndex = 96;
            // 
            // button1
            // 
            this.button1.Location = new System.Drawing.Point(787, 110);
            this.button1.Name = "button1";
            this.button1.Size = new System.Drawing.Size(90, 30);
            this.button1.TabIndex = 97;
            this.button1.Text = "导出到EXCEL";
            this.button1.UseVisualStyleBackColor = true;
            this.button1.Click += new System.EventHandler(this.button1_Click);
            // 
            // 对账
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 12F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1003, 729);
            this.Controls.Add(this.button1);
            this.Controls.Add(this.label6);
            this.Controls.Add(this.textBox结算方式);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.textBox传真);
            this.Controls.Add(this.button打印);
            this.Controls.Add(this.button生成);
            this.Controls.Add(this.dataGridView对账单);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.com客户联系人);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.text收货地址);
            this.Controls.Add(this.text联系电话);
            this.Controls.Add(this.label4);
            this.Controls.Add(this.dateTimePicker对账截止日);
            this.Controls.Add(this.对账截止日);
            this.Controls.Add(this.dateTimePicker对账起始日);
            this.Controls.Add(this.对账起始日);
            this.Controls.Add(this.label5);
            this.Controls.Add(this.comboBox客户);
            this.Name = "对账";
            this.Text = "对账";
            this.Load += new System.EventHandler(this.对账_Load);
            ((System.ComponentModel.ISupportInitialize)(this.dataGridView对账单)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label label5;
        public System.Windows.Forms.ComboBox comboBox客户;
        public System.Windows.Forms.DateTimePicker dateTimePicker对账截止日;
        private System.Windows.Forms.Label 对账截止日;
        public System.Windows.Forms.DateTimePicker dateTimePicker对账起始日;
        private System.Windows.Forms.Label 对账起始日;
        private System.Windows.Forms.Label label2;
        public System.Windows.Forms.ComboBox com客户联系人;
        private System.Windows.Forms.Label label3;
        public System.Windows.Forms.TextBox text收货地址;
        public System.Windows.Forms.TextBox text联系电话;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.DataGridView dataGridView对账单;
        private System.Windows.Forms.Button button生成;
        private System.Windows.Forms.Button button打印;
        private System.Windows.Forms.Label label1;
        public System.Windows.Forms.TextBox textBox传真;
        private System.Windows.Forms.Label label6;
        public System.Windows.Forms.TextBox textBox结算方式;
        private System.Windows.Forms.Button button1;
    }
}