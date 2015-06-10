namespace QTsys
{
    partial class 原料入仓
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
            this.text库存数量 = new System.Windows.Forms.TextBox();
            this.label4 = new System.Windows.Forms.Label();
            this.label5 = new System.Windows.Forms.Label();
            this.text供应单价 = new System.Windows.Forms.TextBox();
            this.label6 = new System.Windows.Forms.Label();
            this.com原料编号 = new System.Windows.Forms.ComboBox();
            this.dataGridView1 = new System.Windows.Forms.DataGridView();
            this.label8 = new System.Windows.Forms.Label();
            this.label搜索栏目 = new System.Windows.Forms.Label();
            this.text搜索内容 = new System.Windows.Forms.TextBox();
            this.button1 = new System.Windows.Forms.Button();
            this.button2 = new System.Windows.Forms.Button();
            this.com供应商 = new System.Windows.Forms.ComboBox();
            this.dataGridView2 = new System.Windows.Forms.DataGridView();
            this.button3 = new System.Windows.Forms.Button();
            this.text单位 = new System.Windows.Forms.TextBox();
            this.label10 = new System.Windows.Forms.Label();
            this.label1 = new System.Windows.Forms.Label();
            this.textBox进出数量 = new System.Windows.Forms.TextBox();
            this.label2 = new System.Windows.Forms.Label();
            this.textBoxNewName = new System.Windows.Forms.TextBox();
            this.textBox出入仓列搜索 = new System.Windows.Forms.TextBox();
            this.label出入仓列名 = new System.Windows.Forms.Label();
            this.label7 = new System.Windows.Forms.Label();
            this.dateTimePicker入仓截止日 = new System.Windows.Forms.DateTimePicker();
            this.入仓截止日 = new System.Windows.Forms.Label();
            this.dateTimePicker入仓起始日 = new System.Windows.Forms.DateTimePicker();
            this.入仓起始日 = new System.Windows.Forms.Label();
            ((System.ComponentModel.ISupportInitialize)(this.dataGridView1)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.dataGridView2)).BeginInit();
            this.SuspendLayout();
            // 
            // text库存数量
            // 
            this.text库存数量.Enabled = false;
            this.text库存数量.Location = new System.Drawing.Point(71, 139);
            this.text库存数量.Name = "text库存数量";
            this.text库存数量.Size = new System.Drawing.Size(119, 21);
            this.text库存数量.TabIndex = 7;
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Location = new System.Drawing.Point(12, 142);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(53, 12);
            this.label4.TabIndex = 6;
            this.label4.Text = "库存数量";
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Location = new System.Drawing.Point(12, 195);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(41, 12);
            this.label5.TabIndex = 8;
            this.label5.Text = "供应商";
            // 
            // text供应单价
            // 
            this.text供应单价.Location = new System.Drawing.Point(71, 218);
            this.text供应单价.Name = "text供应单价";
            this.text供应单价.Size = new System.Drawing.Size(119, 21);
            this.text供应单价.TabIndex = 11;
            // 
            // label6
            // 
            this.label6.AutoSize = true;
            this.label6.Location = new System.Drawing.Point(12, 221);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(53, 12);
            this.label6.TabIndex = 10;
            this.label6.Text = "供应单价";
            // 
            // com原料编号
            // 
            this.com原料编号.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.com原料编号.FormattingEnabled = true;
            this.com原料编号.Location = new System.Drawing.Point(71, 63);
            this.com原料编号.Name = "com原料编号";
            this.com原料编号.Size = new System.Drawing.Size(119, 20);
            this.com原料编号.TabIndex = 14;
            this.com原料编号.SelectedIndexChanged += new System.EventHandler(this.com原料编号_SelectedIndexChanged);
            // 
            // dataGridView1
            // 
            this.dataGridView1.AllowUserToAddRows = false;
            this.dataGridView1.AllowUserToDeleteRows = false;
            this.dataGridView1.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dataGridView1.Enabled = false;
            this.dataGridView1.Location = new System.Drawing.Point(210, 63);
            this.dataGridView1.Name = "dataGridView1";
            this.dataGridView1.ReadOnly = true;
            this.dataGridView1.RowTemplate.Height = 23;
            this.dataGridView1.Size = new System.Drawing.Size(785, 143);
            this.dataGridView1.TabIndex = 15;
            this.dataGridView1.CellClick += new System.Windows.Forms.DataGridViewCellEventHandler(this.dataGridView1_CellClick);
            this.dataGridView1.CellContentClick += new System.Windows.Forms.DataGridViewCellEventHandler(this.dataGridView1_CellContentClick);
            // 
            // label8
            // 
            this.label8.AutoSize = true;
            this.label8.Location = new System.Drawing.Point(250, 21);
            this.label8.Name = "label8";
            this.label8.Size = new System.Drawing.Size(29, 12);
            this.label8.TabIndex = 16;
            this.label8.Text = "搜索";
            this.label8.Visible = false;
            // 
            // label搜索栏目
            // 
            this.label搜索栏目.AutoSize = true;
            this.label搜索栏目.Location = new System.Drawing.Point(285, 21);
            this.label搜索栏目.Name = "label搜索栏目";
            this.label搜索栏目.Size = new System.Drawing.Size(29, 12);
            this.label搜索栏目.TabIndex = 17;
            this.label搜索栏目.Text = "编号";
            this.label搜索栏目.Visible = false;
            // 
            // text搜索内容
            // 
            this.text搜索内容.Location = new System.Drawing.Point(344, 18);
            this.text搜索内容.Name = "text搜索内容";
            this.text搜索内容.Size = new System.Drawing.Size(207, 21);
            this.text搜索内容.TabIndex = 18;
            this.text搜索内容.Visible = false;
            // 
            // button1
            // 
            this.button1.Location = new System.Drawing.Point(578, 16);
            this.button1.Name = "button1";
            this.button1.Size = new System.Drawing.Size(113, 23);
            this.button1.TabIndex = 19;
            this.button1.Text = "搜索仓库";
            this.button1.UseVisualStyleBackColor = true;
            this.button1.Visible = false;
            this.button1.Click += new System.EventHandler(this.button1_Click);
            // 
            // button2
            // 
            this.button2.Location = new System.Drawing.Point(46, 349);
            this.button2.Name = "button2";
            this.button2.Size = new System.Drawing.Size(104, 23);
            this.button2.TabIndex = 20;
            this.button2.Text = "确认原料入仓";
            this.button2.UseVisualStyleBackColor = true;
            this.button2.Click += new System.EventHandler(this.button2_Click);
            // 
            // com供应商
            // 
            this.com供应商.FormattingEnabled = true;
            this.com供应商.Location = new System.Drawing.Point(71, 192);
            this.com供应商.Name = "com供应商";
            this.com供应商.Size = new System.Drawing.Size(119, 20);
            this.com供应商.TabIndex = 21;
            // 
            // dataGridView2
            // 
            this.dataGridView2.AllowUserToAddRows = false;
            this.dataGridView2.AllowUserToDeleteRows = false;
            this.dataGridView2.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dataGridView2.Location = new System.Drawing.Point(210, 273);
            this.dataGridView2.Name = "dataGridView2";
            this.dataGridView2.ReadOnly = true;
            this.dataGridView2.RowTemplate.Height = 23;
            this.dataGridView2.Size = new System.Drawing.Size(785, 215);
            this.dataGridView2.TabIndex = 24;
            this.dataGridView2.CellClick += new System.Windows.Forms.DataGridViewCellEventHandler(this.dataGridView2_CellClick);
            this.dataGridView2.CellContentClick += new System.Windows.Forms.DataGridViewCellEventHandler(this.dataGridView2_CellContentClick);
            // 
            // button3
            // 
            this.button3.Location = new System.Drawing.Point(578, 230);
            this.button3.Name = "button3";
            this.button3.Size = new System.Drawing.Size(113, 23);
            this.button3.TabIndex = 25;
            this.button3.Text = "搜索入仓";
            this.button3.UseVisualStyleBackColor = true;
            this.button3.Click += new System.EventHandler(this.button3_Click);
            // 
            // text单位
            // 
            this.text单位.Location = new System.Drawing.Point(71, 112);
            this.text单位.Name = "text单位";
            this.text单位.Size = new System.Drawing.Size(119, 21);
            this.text单位.TabIndex = 27;
            // 
            // label10
            // 
            this.label10.AutoSize = true;
            this.label10.Location = new System.Drawing.Point(12, 115);
            this.label10.Name = "label10";
            this.label10.Size = new System.Drawing.Size(29, 12);
            this.label10.TabIndex = 26;
            this.label10.Text = "单位";
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(12, 66);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(53, 12);
            this.label1.TabIndex = 29;
            this.label1.Text = "原料名称";
            // 
            // textBox进出数量
            // 
            this.textBox进出数量.Location = new System.Drawing.Point(71, 167);
            this.textBox进出数量.Name = "textBox进出数量";
            this.textBox进出数量.Size = new System.Drawing.Size(119, 21);
            this.textBox进出数量.TabIndex = 31;
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(12, 170);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(53, 12);
            this.label2.TabIndex = 30;
            this.label2.Text = "进出数量";
            // 
            // textBoxNewName
            // 
            this.textBoxNewName.Location = new System.Drawing.Point(71, 89);
            this.textBoxNewName.Name = "textBoxNewName";
            this.textBoxNewName.Size = new System.Drawing.Size(119, 21);
            this.textBoxNewName.TabIndex = 32;
            // 
            // textBox出入仓列搜索
            // 
            this.textBox出入仓列搜索.Location = new System.Drawing.Point(344, 232);
            this.textBox出入仓列搜索.Name = "textBox出入仓列搜索";
            this.textBox出入仓列搜索.Size = new System.Drawing.Size(207, 21);
            this.textBox出入仓列搜索.TabIndex = 35;
            // 
            // label出入仓列名
            // 
            this.label出入仓列名.AutoSize = true;
            this.label出入仓列名.Location = new System.Drawing.Point(285, 235);
            this.label出入仓列名.Name = "label出入仓列名";
            this.label出入仓列名.Size = new System.Drawing.Size(29, 12);
            this.label出入仓列名.TabIndex = 34;
            this.label出入仓列名.Text = "编号";
            // 
            // label7
            // 
            this.label7.AutoSize = true;
            this.label7.Location = new System.Drawing.Point(250, 235);
            this.label7.Name = "label7";
            this.label7.Size = new System.Drawing.Size(29, 12);
            this.label7.TabIndex = 33;
            this.label7.Text = "搜索";
            // 
            // dateTimePicker入仓截止日
            // 
            this.dateTimePicker入仓截止日.Location = new System.Drawing.Point(828, 239);
            this.dateTimePicker入仓截止日.Name = "dateTimePicker入仓截止日";
            this.dateTimePicker入仓截止日.Size = new System.Drawing.Size(121, 21);
            this.dateTimePicker入仓截止日.TabIndex = 87;
            // 
            // 入仓截止日
            // 
            this.入仓截止日.AutoSize = true;
            this.入仓截止日.Location = new System.Drawing.Point(757, 245);
            this.入仓截止日.Name = "入仓截止日";
            this.入仓截止日.Size = new System.Drawing.Size(77, 12);
            this.入仓截止日.TabIndex = 86;
            this.入仓截止日.Text = "入仓截止日：";
            // 
            // dateTimePicker入仓起始日
            // 
            this.dateTimePicker入仓起始日.Location = new System.Drawing.Point(828, 212);
            this.dateTimePicker入仓起始日.Name = "dateTimePicker入仓起始日";
            this.dateTimePicker入仓起始日.Size = new System.Drawing.Size(121, 21);
            this.dateTimePicker入仓起始日.TabIndex = 85;
            // 
            // 入仓起始日
            // 
            this.入仓起始日.AutoSize = true;
            this.入仓起始日.Location = new System.Drawing.Point(757, 218);
            this.入仓起始日.Name = "入仓起始日";
            this.入仓起始日.Size = new System.Drawing.Size(77, 12);
            this.入仓起始日.TabIndex = 84;
            this.入仓起始日.Text = "入仓起始日：";
            // 
            // 原料入仓
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 12F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1065, 503);
            this.Controls.Add(this.dateTimePicker入仓截止日);
            this.Controls.Add(this.入仓截止日);
            this.Controls.Add(this.dateTimePicker入仓起始日);
            this.Controls.Add(this.入仓起始日);
            this.Controls.Add(this.textBox出入仓列搜索);
            this.Controls.Add(this.label出入仓列名);
            this.Controls.Add(this.label7);
            this.Controls.Add(this.textBoxNewName);
            this.Controls.Add(this.textBox进出数量);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.text单位);
            this.Controls.Add(this.label10);
            this.Controls.Add(this.button3);
            this.Controls.Add(this.dataGridView2);
            this.Controls.Add(this.com供应商);
            this.Controls.Add(this.button2);
            this.Controls.Add(this.button1);
            this.Controls.Add(this.text搜索内容);
            this.Controls.Add(this.label搜索栏目);
            this.Controls.Add(this.label8);
            this.Controls.Add(this.dataGridView1);
            this.Controls.Add(this.com原料编号);
            this.Controls.Add(this.text供应单价);
            this.Controls.Add(this.label6);
            this.Controls.Add(this.label5);
            this.Controls.Add(this.text库存数量);
            this.Controls.Add(this.label4);
            this.Name = "原料入仓";
            this.Text = "原料入仓";
            this.Load += new System.EventHandler(this.原料入仓_Load);
            ((System.ComponentModel.ISupportInitialize)(this.dataGridView1)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.dataGridView2)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.TextBox text库存数量;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.TextBox text供应单价;
        private System.Windows.Forms.Label label6;
        private System.Windows.Forms.ComboBox com原料编号;
        private System.Windows.Forms.DataGridView dataGridView1;
        private System.Windows.Forms.Label label8;
        private System.Windows.Forms.Label label搜索栏目;
        private System.Windows.Forms.TextBox text搜索内容;
        private System.Windows.Forms.Button button1;
        private System.Windows.Forms.Button button2;
        private System.Windows.Forms.ComboBox com供应商;
        private System.Windows.Forms.DataGridView dataGridView2;
        private System.Windows.Forms.Button button3;
        private System.Windows.Forms.TextBox text单位;
        private System.Windows.Forms.Label label10;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.TextBox textBox进出数量;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.TextBox textBoxNewName;
        private System.Windows.Forms.TextBox textBox出入仓列搜索;
        private System.Windows.Forms.Label label出入仓列名;
        private System.Windows.Forms.Label label7;
        public System.Windows.Forms.DateTimePicker dateTimePicker入仓截止日;
        private System.Windows.Forms.Label 入仓截止日;
        public System.Windows.Forms.DateTimePicker dateTimePicker入仓起始日;
        private System.Windows.Forms.Label 入仓起始日;
    }
}