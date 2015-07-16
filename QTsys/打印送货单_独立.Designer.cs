namespace QTsys
{
    partial class 打印送货单_独立
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
            this.dataGridView订单 = new System.Windows.Forms.DataGridView();
            this.dataGridView生产计划 = new System.Windows.Forms.DataGridView();
            this.label1 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.label3 = new System.Windows.Forms.Label();
            this.label6 = new System.Windows.Forms.Label();
            this.textBox结算方式 = new System.Windows.Forms.TextBox();
            this.label4 = new System.Windows.Forms.Label();
            this.textBox传真 = new System.Windows.Forms.TextBox();
            this.label5 = new System.Windows.Forms.Label();
            this.com客户联系人 = new System.Windows.Forms.ComboBox();
            this.label7 = new System.Windows.Forms.Label();
            this.text收货地址 = new System.Windows.Forms.TextBox();
            this.text联系电话 = new System.Windows.Forms.TextBox();
            this.label8 = new System.Windows.Forms.Label();
            this.checkBox是否单价 = new System.Windows.Forms.CheckBox();
            this.textBox客户名称 = new System.Windows.Forms.TextBox();
            this.label9 = new System.Windows.Forms.Label();
            this.textBox当前生产数 = new System.Windows.Forms.TextBox();
            this.button打印送货单 = new System.Windows.Forms.Button();
            this.button生成送货单 = new System.Windows.Forms.Button();
            this.webBrowser2 = new System.Windows.Forms.WebBrowser();
            this.textBox订单数量 = new System.Windows.Forms.TextBox();
            this.label10 = new System.Windows.Forms.Label();
            this.textBox已发货数 = new System.Windows.Forms.TextBox();
            this.label11 = new System.Windows.Forms.Label();
            this.button1 = new System.Windows.Forms.Button();
            this.label1订单编号 = new System.Windows.Forms.Label();
            this.textBox已完成生产数 = new System.Windows.Forms.TextBox();
            this.label12 = new System.Windows.Forms.Label();
            this.textBox分页数量 = new System.Windows.Forms.TextBox();
            this.label13 = new System.Windows.Forms.Label();
            ((System.ComponentModel.ISupportInitialize)(this.dataGridView订单)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.dataGridView生产计划)).BeginInit();
            this.SuspendLayout();
            // 
            // dataGridView订单
            // 
            this.dataGridView订单.AllowUserToAddRows = false;
            this.dataGridView订单.AllowUserToDeleteRows = false;
            this.dataGridView订单.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dataGridView订单.Location = new System.Drawing.Point(12, 33);
            this.dataGridView订单.Name = "dataGridView订单";
            this.dataGridView订单.ReadOnly = true;
            this.dataGridView订单.RowTemplate.Height = 23;
            this.dataGridView订单.Size = new System.Drawing.Size(431, 169);
            this.dataGridView订单.TabIndex = 0;
            this.dataGridView订单.CellClick += new System.Windows.Forms.DataGridViewCellEventHandler(this.dataGridView订单_CellClick);
            // 
            // dataGridView生产计划
            // 
            this.dataGridView生产计划.AllowUserToAddRows = false;
            this.dataGridView生产计划.AllowUserToDeleteRows = false;
            this.dataGridView生产计划.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dataGridView生产计划.Location = new System.Drawing.Point(449, 34);
            this.dataGridView生产计划.Name = "dataGridView生产计划";
            this.dataGridView生产计划.ReadOnly = true;
            this.dataGridView生产计划.RowTemplate.Height = 23;
            this.dataGridView生产计划.Size = new System.Drawing.Size(949, 168);
            this.dataGridView生产计划.TabIndex = 1;
            this.dataGridView生产计划.CellClick += new System.Windows.Forms.DataGridViewCellEventHandler(this.dataGridView生产计划_CellClick);
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(13, 15);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(77, 12);
            this.label1.TabIndex = 2;
            this.label1.Text = "生产中的订单";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(449, 15);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(113, 12);
            this.label2.TabIndex = 3;
            this.label2.Text = "选中订单的生产计划";
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Enabled = false;
            this.label3.Location = new System.Drawing.Point(1144, 225);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(53, 12);
            this.label3.TabIndex = 4;
            this.label3.Text = "客户名称";
            // 
            // label6
            // 
            this.label6.AutoSize = true;
            this.label6.Location = new System.Drawing.Point(1145, 306);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(53, 12);
            this.label6.TabIndex = 105;
            this.label6.Text = "结算方式";
            // 
            // textBox结算方式
            // 
            this.textBox结算方式.Location = new System.Drawing.Point(1204, 303);
            this.textBox结算方式.Name = "textBox结算方式";
            this.textBox结算方式.Size = new System.Drawing.Size(121, 21);
            this.textBox结算方式.TabIndex = 106;
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Enabled = false;
            this.label4.Location = new System.Drawing.Point(1166, 333);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(29, 12);
            this.label4.TabIndex = 103;
            this.label4.Text = "传真";
            // 
            // textBox传真
            // 
            this.textBox传真.Enabled = false;
            this.textBox传真.Location = new System.Drawing.Point(1203, 330);
            this.textBox传真.Name = "textBox传真";
            this.textBox传真.Size = new System.Drawing.Size(121, 21);
            this.textBox传真.TabIndex = 104;
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Enabled = false;
            this.label5.Location = new System.Drawing.Point(1133, 252);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(65, 12);
            this.label5.TabIndex = 97;
            this.label5.Text = "客户联系人";
            // 
            // com客户联系人
            // 
            this.com客户联系人.Enabled = false;
            this.com客户联系人.FormattingEnabled = true;
            this.com客户联系人.Location = new System.Drawing.Point(1204, 249);
            this.com客户联系人.Name = "com客户联系人";
            this.com客户联系人.Size = new System.Drawing.Size(121, 20);
            this.com客户联系人.TabIndex = 98;
            // 
            // label7
            // 
            this.label7.AutoSize = true;
            this.label7.Enabled = false;
            this.label7.Location = new System.Drawing.Point(1145, 278);
            this.label7.Name = "label7";
            this.label7.Size = new System.Drawing.Size(53, 12);
            this.label7.TabIndex = 99;
            this.label7.Text = "联系电话";
            // 
            // text收货地址
            // 
            this.text收货地址.Enabled = false;
            this.text收货地址.Location = new System.Drawing.Point(1203, 357);
            this.text收货地址.Multiline = true;
            this.text收货地址.Name = "text收货地址";
            this.text收货地址.Size = new System.Drawing.Size(189, 55);
            this.text收货地址.TabIndex = 102;
            // 
            // text联系电话
            // 
            this.text联系电话.Enabled = false;
            this.text联系电话.Location = new System.Drawing.Point(1204, 275);
            this.text联系电话.Name = "text联系电话";
            this.text联系电话.Size = new System.Drawing.Size(121, 21);
            this.text联系电话.TabIndex = 100;
            // 
            // label8
            // 
            this.label8.AutoSize = true;
            this.label8.Enabled = false;
            this.label8.Location = new System.Drawing.Point(1141, 360);
            this.label8.Name = "label8";
            this.label8.Size = new System.Drawing.Size(53, 12);
            this.label8.TabIndex = 101;
            this.label8.Text = "收货地址";
            // 
            // checkBox是否单价
            // 
            this.checkBox是否单价.AutoSize = true;
            this.checkBox是否单价.Checked = true;
            this.checkBox是否单价.CheckState = System.Windows.Forms.CheckState.Checked;
            this.checkBox是否单价.Location = new System.Drawing.Point(934, 11);
            this.checkBox是否单价.Name = "checkBox是否单价";
            this.checkBox是否单价.Size = new System.Drawing.Size(120, 16);
            this.checkBox是否单价.TabIndex = 107;
            this.checkBox是否单价.Text = "是否显示产品单价";
            this.checkBox是否单价.UseVisualStyleBackColor = true;
            // 
            // textBox客户名称
            // 
            this.textBox客户名称.Enabled = false;
            this.textBox客户名称.Location = new System.Drawing.Point(1203, 222);
            this.textBox客户名称.Name = "textBox客户名称";
            this.textBox客户名称.Size = new System.Drawing.Size(122, 21);
            this.textBox客户名称.TabIndex = 108;
            // 
            // label9
            // 
            this.label9.AutoSize = true;
            this.label9.Location = new System.Drawing.Point(1120, 503);
            this.label9.Name = "label9";
            this.label9.Size = new System.Drawing.Size(77, 12);
            this.label9.TabIndex = 109;
            this.label9.Text = "本次发货数量";
            // 
            // textBox当前生产数
            // 
            this.textBox当前生产数.Location = new System.Drawing.Point(1203, 499);
            this.textBox当前生产数.Name = "textBox当前生产数";
            this.textBox当前生产数.Size = new System.Drawing.Size(85, 21);
            this.textBox当前生产数.TabIndex = 110;
            this.textBox当前生产数.Text = "0";
            this.textBox当前生产数.TextChanged += new System.EventHandler(this.textBox当前生产数_TextChanged);
            // 
            // button打印送货单
            // 
            this.button打印送货单.Enabled = false;
            this.button打印送货单.Location = new System.Drawing.Point(1121, 526);
            this.button打印送货单.Name = "button打印送货单";
            this.button打印送货单.Size = new System.Drawing.Size(167, 23);
            this.button打印送货单.TabIndex = 112;
            this.button打印送货单.Text = "打印送货单--更新数据库";
            this.button打印送货单.UseVisualStyleBackColor = true;
            this.button打印送货单.Click += new System.EventHandler(this.button打印送货单_Click);
            // 
            // button生成送货单
            // 
            this.button生成送货单.Enabled = false;
            this.button生成送货单.Location = new System.Drawing.Point(1323, 437);
            this.button生成送货单.Name = "button生成送货单";
            this.button生成送货单.Size = new System.Drawing.Size(75, 23);
            this.button生成送货单.TabIndex = 111;
            this.button生成送货单.Text = "生成送货单";
            this.button生成送货单.UseVisualStyleBackColor = true;
            this.button生成送货单.Click += new System.EventHandler(this.button生成送货单_Click);
            // 
            // webBrowser2
            // 
            this.webBrowser2.Location = new System.Drawing.Point(12, 206);
            this.webBrowser2.MinimumSize = new System.Drawing.Size(20, 20);
            this.webBrowser2.Name = "webBrowser2";
            this.webBrowser2.Size = new System.Drawing.Size(1097, 378);
            this.webBrowser2.TabIndex = 113;
            this.webBrowser2.Tag = "";
            this.webBrowser2.Url = new System.Uri("", System.UriKind.Relative);
            // 
            // textBox订单数量
            // 
            this.textBox订单数量.Enabled = false;
            this.textBox订单数量.Location = new System.Drawing.Point(1203, 472);
            this.textBox订单数量.Name = "textBox订单数量";
            this.textBox订单数量.Size = new System.Drawing.Size(85, 21);
            this.textBox订单数量.TabIndex = 115;
            // 
            // label10
            // 
            this.label10.AutoSize = true;
            this.label10.Enabled = false;
            this.label10.Location = new System.Drawing.Point(1144, 476);
            this.label10.Name = "label10";
            this.label10.Size = new System.Drawing.Size(53, 12);
            this.label10.TabIndex = 114;
            this.label10.Text = "订单数量";
            // 
            // textBox已发货数
            // 
            this.textBox已发货数.Enabled = false;
            this.textBox已发货数.Location = new System.Drawing.Point(1203, 445);
            this.textBox已发货数.Name = "textBox已发货数";
            this.textBox已发货数.Size = new System.Drawing.Size(85, 21);
            this.textBox已发货数.TabIndex = 117;
            // 
            // label11
            // 
            this.label11.AutoSize = true;
            this.label11.Location = new System.Drawing.Point(1144, 448);
            this.label11.Name = "label11";
            this.label11.Size = new System.Drawing.Size(53, 12);
            this.label11.TabIndex = 116;
            this.label11.Text = "已发货数";
            // 
            // button1
            // 
            this.button1.Enabled = false;
            this.button1.Location = new System.Drawing.Point(1300, 555);
            this.button1.Name = "button1";
            this.button1.Size = new System.Drawing.Size(111, 23);
            this.button1.TabIndex = 118;
            this.button1.Text = "生成快递单数据";
            this.button1.UseVisualStyleBackColor = true;
            this.button1.Click += new System.EventHandler(this.button1_Click);
            // 
            // label1订单编号
            // 
            this.label1订单编号.AutoSize = true;
            this.label1订单编号.Location = new System.Drawing.Point(1340, 225);
            this.label1订单编号.Name = "label1订单编号";
            this.label1订单编号.Size = new System.Drawing.Size(53, 12);
            this.label1订单编号.TabIndex = 119;
            this.label1订单编号.Text = "订单编号";
            // 
            // textBox已完成生产数
            // 
            this.textBox已完成生产数.Enabled = false;
            this.textBox已完成生产数.Location = new System.Drawing.Point(1203, 418);
            this.textBox已完成生产数.Name = "textBox已完成生产数";
            this.textBox已完成生产数.Size = new System.Drawing.Size(85, 21);
            this.textBox已完成生产数.TabIndex = 121;
            // 
            // label12
            // 
            this.label12.AutoSize = true;
            this.label12.Location = new System.Drawing.Point(1120, 421);
            this.label12.Name = "label12";
            this.label12.Size = new System.Drawing.Size(77, 12);
            this.label12.TabIndex = 120;
            this.label12.Text = "已完成生产数";
            // 
            // textBox分页数量
            // 
            this.textBox分页数量.Location = new System.Drawing.Point(1123, 563);
            this.textBox分页数量.Name = "textBox分页数量";
            this.textBox分页数量.Size = new System.Drawing.Size(49, 21);
            this.textBox分页数量.TabIndex = 122;
            this.textBox分页数量.Text = "10";
            // 
            // label13
            // 
            this.label13.AutoSize = true;
            this.label13.Location = new System.Drawing.Point(1178, 566);
            this.label13.Name = "label13";
            this.label13.Size = new System.Drawing.Size(89, 12);
            this.label13.TabIndex = 123;
            this.label13.Text = "条数据进行分页";
            // 
            // 打印送货单_独立
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 12F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1414, 594);
            this.Controls.Add(this.textBox分页数量);
            this.Controls.Add(this.label13);
            this.Controls.Add(this.textBox已完成生产数);
            this.Controls.Add(this.label12);
            this.Controls.Add(this.label1订单编号);
            this.Controls.Add(this.button1);
            this.Controls.Add(this.textBox已发货数);
            this.Controls.Add(this.label11);
            this.Controls.Add(this.textBox订单数量);
            this.Controls.Add(this.label10);
            this.Controls.Add(this.webBrowser2);
            this.Controls.Add(this.button打印送货单);
            this.Controls.Add(this.button生成送货单);
            this.Controls.Add(this.textBox当前生产数);
            this.Controls.Add(this.label9);
            this.Controls.Add(this.textBox客户名称);
            this.Controls.Add(this.checkBox是否单价);
            this.Controls.Add(this.label6);
            this.Controls.Add(this.textBox结算方式);
            this.Controls.Add(this.label4);
            this.Controls.Add(this.textBox传真);
            this.Controls.Add(this.label5);
            this.Controls.Add(this.com客户联系人);
            this.Controls.Add(this.label7);
            this.Controls.Add(this.text收货地址);
            this.Controls.Add(this.text联系电话);
            this.Controls.Add(this.label8);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.dataGridView生产计划);
            this.Controls.Add(this.dataGridView订单);
            this.Name = "打印送货单_独立";
            this.Text = "打印送货单_独立";
            this.Load += new System.EventHandler(this.打印送货单_独立_Load);
            ((System.ComponentModel.ISupportInitialize)(this.dataGridView订单)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.dataGridView生产计划)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.DataGridView dataGridView订单;
        private System.Windows.Forms.DataGridView dataGridView生产计划;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Label label6;
        public System.Windows.Forms.TextBox textBox结算方式;
        private System.Windows.Forms.Label label4;
        public System.Windows.Forms.TextBox textBox传真;
        private System.Windows.Forms.Label label5;
        public System.Windows.Forms.ComboBox com客户联系人;
        private System.Windows.Forms.Label label7;
        public System.Windows.Forms.TextBox text收货地址;
        public System.Windows.Forms.TextBox text联系电话;
        private System.Windows.Forms.Label label8;
        private System.Windows.Forms.CheckBox checkBox是否单价;
        public System.Windows.Forms.TextBox textBox客户名称;
        private System.Windows.Forms.Label label9;
        public System.Windows.Forms.TextBox textBox当前生产数;
        private System.Windows.Forms.Button button打印送货单;
        private System.Windows.Forms.Button button生成送货单;
        private System.Windows.Forms.WebBrowser webBrowser2;
        public System.Windows.Forms.TextBox textBox订单数量;
        private System.Windows.Forms.Label label10;
        public System.Windows.Forms.TextBox textBox已发货数;
        private System.Windows.Forms.Label label11;
        private System.Windows.Forms.Button button1;
        private System.Windows.Forms.Label label1订单编号;
        public System.Windows.Forms.TextBox textBox已完成生产数;
        private System.Windows.Forms.Label label12;
        public System.Windows.Forms.TextBox textBox分页数量;
        private System.Windows.Forms.Label label13;
    }
}