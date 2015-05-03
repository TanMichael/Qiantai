namespace QTsys
{
    partial class 原料库管理
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
            this.button1 = new System.Windows.Forms.Button();
            this.button2 = new System.Windows.Forms.Button();
            this.button3 = new System.Windows.Forms.Button();
            this.button4 = new System.Windows.Forms.Button();
            this.text搜索内容 = new System.Windows.Forms.TextBox();
            this.label1 = new System.Windows.Forms.Label();
            this.text原料编号 = new System.Windows.Forms.TextBox();
            this.text原料名称 = new System.Windows.Forms.TextBox();
            this.label2 = new System.Windows.Forms.Label();
            this.text单位 = new System.Windows.Forms.TextBox();
            this.label3 = new System.Windows.Forms.Label();
            this.text库存数量 = new System.Windows.Forms.TextBox();
            this.label4 = new System.Windows.Forms.Label();
            this.label搜索栏目 = new System.Windows.Forms.Label();
            this.label6 = new System.Windows.Forms.Label();
            ((System.ComponentModel.ISupportInitialize)(this.dataGridView1)).BeginInit();
            this.SuspendLayout();
            // 
            // dataGridView1
            // 
            this.dataGridView1.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dataGridView1.Location = new System.Drawing.Point(12, 116);
            this.dataGridView1.Name = "dataGridView1";
            this.dataGridView1.RowTemplate.Height = 23;
            this.dataGridView1.Size = new System.Drawing.Size(804, 505);
            this.dataGridView1.TabIndex = 0;
            this.dataGridView1.CellClick += new System.Windows.Forms.DataGridViewCellEventHandler(this.dataGridView1_CellClick);
            this.dataGridView1.CellContentClick += new System.Windows.Forms.DataGridViewCellEventHandler(this.dataGridView1_CellContentClick);
            // 
            // button1
            // 
            this.button1.Location = new System.Drawing.Point(12, 41);
            this.button1.Name = "button1";
            this.button1.Size = new System.Drawing.Size(75, 23);
            this.button1.TabIndex = 1;
            this.button1.Text = "原料出仓";
            this.button1.UseVisualStyleBackColor = true;
            this.button1.Visible = false;
            this.button1.Click += new System.EventHandler(this.button1_Click);
            // 
            // button2
            // 
            this.button2.Location = new System.Drawing.Point(12, 12);
            this.button2.Name = "button2";
            this.button2.Size = new System.Drawing.Size(75, 23);
            this.button2.TabIndex = 2;
            this.button2.Text = "原料入仓";
            this.button2.UseVisualStyleBackColor = true;
            this.button2.Click += new System.EventHandler(this.button2_Click);
            // 
            // button3
            // 
            this.button3.Location = new System.Drawing.Point(107, 12);
            this.button3.Name = "button3";
            this.button3.Size = new System.Drawing.Size(75, 23);
            this.button3.TabIndex = 3;
            this.button3.Text = "数据修正";
            this.button3.UseVisualStyleBackColor = true;
            this.button3.Click += new System.EventHandler(this.button3_Click);
            // 
            // button4
            // 
            this.button4.Location = new System.Drawing.Point(684, 76);
            this.button4.Name = "button4";
            this.button4.Size = new System.Drawing.Size(117, 23);
            this.button4.TabIndex = 4;
            this.button4.Text = "原料信息搜索";
            this.button4.UseVisualStyleBackColor = true;
            this.button4.Click += new System.EventHandler(this.button4_Click);
            // 
            // text搜索内容
            // 
            this.text搜索内容.Location = new System.Drawing.Point(491, 76);
            this.text搜索内容.Name = "text搜索内容";
            this.text搜索内容.Size = new System.Drawing.Size(187, 21);
            this.text搜索内容.TabIndex = 5;
            this.text搜索内容.TextChanged += new System.EventHandler(this.text搜索内容_TextChanged);
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(231, 17);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(53, 12);
            this.label1.TabIndex = 6;
            this.label1.Text = "原料编号";
            // 
            // text原料编号
            // 
            this.text原料编号.Enabled = false;
            this.text原料编号.Location = new System.Drawing.Point(290, 12);
            this.text原料编号.Name = "text原料编号";
            this.text原料编号.Size = new System.Drawing.Size(100, 21);
            this.text原料编号.TabIndex = 7;
            // 
            // text原料名称
            // 
            this.text原料名称.Location = new System.Drawing.Point(464, 12);
            this.text原料名称.Name = "text原料名称";
            this.text原料名称.Size = new System.Drawing.Size(174, 21);
            this.text原料名称.TabIndex = 9;
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(405, 17);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(53, 12);
            this.label2.TabIndex = 8;
            this.label2.Text = "原料名称";
            // 
            // text单位
            // 
            this.text单位.Location = new System.Drawing.Point(290, 47);
            this.text单位.Name = "text单位";
            this.text单位.Size = new System.Drawing.Size(100, 21);
            this.text单位.TabIndex = 11;
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(255, 50);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(29, 12);
            this.label3.TabIndex = 10;
            this.label3.Text = "单位";
            // 
            // text库存数量
            // 
            this.text库存数量.Location = new System.Drawing.Point(464, 45);
            this.text库存数量.Name = "text库存数量";
            this.text库存数量.Size = new System.Drawing.Size(100, 21);
            this.text库存数量.TabIndex = 13;
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Location = new System.Drawing.Point(405, 50);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(53, 12);
            this.label4.TabIndex = 12;
            this.label4.Text = "库存数量";
            // 
            // label搜索栏目
            // 
            this.label搜索栏目.AutoSize = true;
            this.label搜索栏目.Location = new System.Drawing.Point(432, 81);
            this.label搜索栏目.Name = "label搜索栏目";
            this.label搜索栏目.Size = new System.Drawing.Size(53, 12);
            this.label搜索栏目.TabIndex = 14;
            this.label搜索栏目.Text = "原料名称";
            this.label搜索栏目.Click += new System.EventHandler(this.label搜索栏目_Click);
            // 
            // label6
            // 
            this.label6.AutoSize = true;
            this.label6.Location = new System.Drawing.Point(397, 81);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(29, 12);
            this.label6.TabIndex = 15;
            this.label6.Text = "搜索";
            this.label6.Click += new System.EventHandler(this.label6_Click);
            // 
            // 原料库管理
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 12F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(828, 633);
            this.Controls.Add(this.label6);
            this.Controls.Add(this.label搜索栏目);
            this.Controls.Add(this.text库存数量);
            this.Controls.Add(this.label4);
            this.Controls.Add(this.text单位);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.text原料名称);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.text原料编号);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.text搜索内容);
            this.Controls.Add(this.button4);
            this.Controls.Add(this.button3);
            this.Controls.Add(this.button2);
            this.Controls.Add(this.button1);
            this.Controls.Add(this.dataGridView1);
            this.Name = "原料库管理";
            this.Text = "原料管理";
            this.Load += new System.EventHandler(this.原料管理_Load);
            ((System.ComponentModel.ISupportInitialize)(this.dataGridView1)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.DataGridView dataGridView1;
        private System.Windows.Forms.Button button1;
        private System.Windows.Forms.Button button2;
        private System.Windows.Forms.Button button3;
        private System.Windows.Forms.Button button4;
        private System.Windows.Forms.TextBox text搜索内容;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.TextBox text原料编号;
        private System.Windows.Forms.TextBox text原料名称;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.TextBox text单位;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.TextBox text库存数量;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.Label label搜索栏目;
        private System.Windows.Forms.Label label6;
    }
}