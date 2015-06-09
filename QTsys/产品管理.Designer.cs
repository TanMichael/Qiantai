namespace QTsys
{
    partial class 产品管理
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
            this.text搜索内容 = new System.Windows.Forms.TextBox();
            this.button4 = new System.Windows.Forms.Button();
            this.button3 = new System.Windows.Forms.Button();
            this.button2 = new System.Windows.Forms.Button();
            this.button1 = new System.Windows.Forms.Button();
            this.dataGridView1 = new System.Windows.Forms.DataGridView();
            this.label1 = new System.Windows.Forms.Label();
            this.label搜索栏目 = new System.Windows.Forms.Label();
            this.text产品名称 = new System.Windows.Forms.TextBox();
            this.label3 = new System.Windows.Forms.Label();
            this.text产品编号 = new System.Windows.Forms.TextBox();
            this.label5 = new System.Windows.Forms.Label();
            this.text材质 = new System.Windows.Forms.TextBox();
            this.label6 = new System.Windows.Forms.Label();
            this.text规格 = new System.Windows.Forms.TextBox();
            this.label7 = new System.Windows.Forms.Label();
            this.button5 = new System.Windows.Forms.Button();
            this.button6 = new System.Windows.Forms.Button();
            this.webBrowser1 = new System.Windows.Forms.WebBrowser();
            ((System.ComponentModel.ISupportInitialize)(this.dataGridView1)).BeginInit();
            this.SuspendLayout();
            // 
            // text搜索内容
            // 
            this.text搜索内容.Location = new System.Drawing.Point(671, 65);
            this.text搜索内容.Name = "text搜索内容";
            this.text搜索内容.Size = new System.Drawing.Size(277, 21);
            this.text搜索内容.TabIndex = 11;
            // 
            // button4
            // 
            this.button4.Location = new System.Drawing.Point(954, 65);
            this.button4.Name = "button4";
            this.button4.Size = new System.Drawing.Size(105, 23);
            this.button4.TabIndex = 10;
            this.button4.Text = "产品信息搜索";
            this.button4.UseVisualStyleBackColor = true;
            this.button4.Click += new System.EventHandler(this.button4_Click);
            // 
            // button3
            // 
            this.button3.Location = new System.Drawing.Point(707, 4);
            this.button3.Name = "button3";
            this.button3.Size = new System.Drawing.Size(100, 23);
            this.button3.TabIndex = 9;
            this.button3.Text = "产品数据修改";
            this.button3.UseVisualStyleBackColor = true;
            this.button3.Click += new System.EventHandler(this.button3_Click);
            // 
            // button2
            // 
            this.button2.Location = new System.Drawing.Point(581, 4);
            this.button2.Name = "button2";
            this.button2.Size = new System.Drawing.Size(100, 23);
            this.button2.TabIndex = 8;
            this.button2.Text = "增加新产品";
            this.button2.UseVisualStyleBackColor = true;
            this.button2.Click += new System.EventHandler(this.button2_Click);
            // 
            // button1
            // 
            this.button1.Location = new System.Drawing.Point(830, 4);
            this.button1.Name = "button1";
            this.button1.Size = new System.Drawing.Size(100, 23);
            this.button1.TabIndex = 7;
            this.button1.Text = "删除该产品";
            this.button1.UseVisualStyleBackColor = true;
            this.button1.Click += new System.EventHandler(this.button1_Click);
            // 
            // dataGridView1
            // 
            this.dataGridView1.AllowUserToAddRows = false;
            this.dataGridView1.AllowUserToDeleteRows = false;
            this.dataGridView1.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dataGridView1.Location = new System.Drawing.Point(12, 94);
            this.dataGridView1.Name = "dataGridView1";
            this.dataGridView1.ReadOnly = true;
            this.dataGridView1.RowTemplate.Height = 23;
            this.dataGridView1.Size = new System.Drawing.Size(1216, 534);
            this.dataGridView1.TabIndex = 6;
            this.dataGridView1.CellClick += new System.Windows.Forms.DataGridViewCellEventHandler(this.dataGridView1_CellClick);
            this.dataGridView1.CellContentClick += new System.Windows.Forms.DataGridViewCellEventHandler(this.dataGridView1_CellContentClick);
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(573, 68);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(29, 12);
            this.label1.TabIndex = 12;
            this.label1.Text = "搜索";
            // 
            // label搜索栏目
            // 
            this.label搜索栏目.AutoSize = true;
            this.label搜索栏目.Font = new System.Drawing.Font("宋体", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.label搜索栏目.ForeColor = System.Drawing.Color.Red;
            this.label搜索栏目.Location = new System.Drawing.Point(608, 68);
            this.label搜索栏目.Name = "label搜索栏目";
            this.label搜索栏目.Size = new System.Drawing.Size(57, 12);
            this.label搜索栏目.TabIndex = 13;
            this.label搜索栏目.Text = "产品编号";
            // 
            // text产品名称
            // 
            this.text产品名称.Enabled = false;
            this.text产品名称.Location = new System.Drawing.Point(284, 6);
            this.text产品名称.Name = "text产品名称";
            this.text产品名称.Size = new System.Drawing.Size(227, 21);
            this.text产品名称.TabIndex = 19;
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(225, 9);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(53, 12);
            this.label3.TabIndex = 18;
            this.label3.Text = "产品名称";
            // 
            // text产品编号
            // 
            this.text产品编号.Enabled = false;
            this.text产品编号.Location = new System.Drawing.Point(71, 4);
            this.text产品编号.Name = "text产品编号";
            this.text产品编号.Size = new System.Drawing.Size(146, 21);
            this.text产品编号.TabIndex = 15;
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Location = new System.Drawing.Point(12, 8);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(53, 12);
            this.label5.TabIndex = 14;
            this.label5.Text = "产品编号";
            // 
            // text材质
            // 
            this.text材质.Enabled = false;
            this.text材质.Location = new System.Drawing.Point(284, 31);
            this.text材质.Name = "text材质";
            this.text材质.Size = new System.Drawing.Size(146, 21);
            this.text材质.TabIndex = 25;
            // 
            // label6
            // 
            this.label6.AutoSize = true;
            this.label6.Location = new System.Drawing.Point(249, 34);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(29, 12);
            this.label6.TabIndex = 24;
            this.label6.Text = "材质";
            // 
            // text规格
            // 
            this.text规格.Enabled = false;
            this.text规格.Location = new System.Drawing.Point(71, 31);
            this.text规格.Name = "text规格";
            this.text规格.Size = new System.Drawing.Size(146, 21);
            this.text规格.TabIndex = 23;
            // 
            // label7
            // 
            this.label7.AutoSize = true;
            this.label7.Location = new System.Drawing.Point(36, 36);
            this.label7.Name = "label7";
            this.label7.Size = new System.Drawing.Size(29, 12);
            this.label7.TabIndex = 22;
            this.label7.Text = "规格";
            // 
            // button5
            // 
            this.button5.Location = new System.Drawing.Point(716, 36);
            this.button5.Name = "button5";
            this.button5.Size = new System.Drawing.Size(91, 23);
            this.button5.TabIndex = 54;
            this.button5.Text = "产品原料关系";
            this.button5.UseVisualStyleBackColor = true;
            this.button5.Click += new System.EventHandler(this.button5_Click);
            // 
            // button6
            // 
            this.button6.Location = new System.Drawing.Point(1078, 23);
            this.button6.Name = "button6";
            this.button6.Size = new System.Drawing.Size(106, 23);
            this.button6.TabIndex = 55;
            this.button6.Text = "打印产品工程单";
            this.button6.UseVisualStyleBackColor = true;
            this.button6.Click += new System.EventHandler(this.button6_Click);
            // 
            // webBrowser1
            // 
            this.webBrowser1.Location = new System.Drawing.Point(978, 377);
            this.webBrowser1.MinimumSize = new System.Drawing.Size(20, 20);
            this.webBrowser1.Name = "webBrowser1";
            this.webBrowser1.Size = new System.Drawing.Size(250, 250);
            this.webBrowser1.TabIndex = 56;
            this.webBrowser1.Visible = false;
            // 
            // 产品管理
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 12F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1240, 639);
            this.Controls.Add(this.webBrowser1);
            this.Controls.Add(this.button6);
            this.Controls.Add(this.button5);
            this.Controls.Add(this.text材质);
            this.Controls.Add(this.label6);
            this.Controls.Add(this.text规格);
            this.Controls.Add(this.label7);
            this.Controls.Add(this.text产品名称);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.text产品编号);
            this.Controls.Add(this.label5);
            this.Controls.Add(this.label搜索栏目);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.text搜索内容);
            this.Controls.Add(this.button4);
            this.Controls.Add(this.button3);
            this.Controls.Add(this.button2);
            this.Controls.Add(this.button1);
            this.Controls.Add(this.dataGridView1);
            this.Name = "产品管理";
            this.Text = "产品管理";
            this.Load += new System.EventHandler(this.产品管理_Load);
            ((System.ComponentModel.ISupportInitialize)(this.dataGridView1)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.TextBox text搜索内容;
        private System.Windows.Forms.Button button4;
        private System.Windows.Forms.Button button3;
        private System.Windows.Forms.Button button2;
        private System.Windows.Forms.Button button1;
        public System.Windows.Forms.DataGridView dataGridView1;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label label搜索栏目;
        private System.Windows.Forms.TextBox text产品名称;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.TextBox text产品编号;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.TextBox text材质;
        private System.Windows.Forms.Label label6;
        private System.Windows.Forms.TextBox text规格;
        private System.Windows.Forms.Label label7;
        private System.Windows.Forms.Button button5;
        private System.Windows.Forms.Button button6;
        private System.Windows.Forms.WebBrowser webBrowser1;
    }
}