﻿namespace QTsys
{
    partial class 领料生产
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
            this.dataGrid未生产 = new System.Windows.Forms.DataGridView();
            this.label1 = new System.Windows.Forms.Label();
            this.label3 = new System.Windows.Forms.Label();
            this.button3 = new System.Windows.Forms.Button();
            this.textBox原料数量 = new System.Windows.Forms.TextBox();
            this.textBox原料 = new System.Windows.Forms.TextBox();
            this.label29 = new System.Windows.Forms.Label();
            this.textBox产品 = new System.Windows.Forms.TextBox();
            this.label30 = new System.Windows.Forms.Label();
            this.dataGrid产品原料关系 = new System.Windows.Forms.DataGridView();
            this.label7 = new System.Windows.Forms.Label();
            this.dataGrid原料 = new System.Windows.Forms.DataGridView();
            this.label6 = new System.Windows.Forms.Label();
            this.date完成时间 = new System.Windows.Forms.DateTimePicker();
            this.label5 = new System.Windows.Forms.Label();
            this.date交付时间 = new System.Windows.Forms.DateTimePicker();
            this.button1 = new System.Windows.Forms.Button();
            this.dataGrid产品 = new System.Windows.Forms.DataGridView();
            this.label2 = new System.Windows.Forms.Label();
            this.button2 = new System.Windows.Forms.Button();
            this.button4 = new System.Windows.Forms.Button();
            this.textBox领料产品 = new System.Windows.Forms.TextBox();
            this.groupBox1 = new System.Windows.Forms.GroupBox();
            this.textBox订单编号 = new System.Windows.Forms.TextBox();
            this.label9 = new System.Windows.Forms.Label();
            this.label8 = new System.Windows.Forms.Label();
            this.textBox产品数量 = new System.Windows.Forms.TextBox();
            this.label4 = new System.Windows.Forms.Label();
            ((System.ComponentModel.ISupportInitialize)(this.dataGrid未生产)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.dataGrid产品原料关系)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.dataGrid原料)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.dataGrid产品)).BeginInit();
            this.groupBox1.SuspendLayout();
            this.SuspendLayout();
            // 
            // dataGrid未生产
            // 
            this.dataGrid未生产.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dataGrid未生产.Location = new System.Drawing.Point(12, 24);
            this.dataGrid未生产.Name = "dataGrid未生产";
            this.dataGrid未生产.RowTemplate.Height = 23;
            this.dataGrid未生产.Size = new System.Drawing.Size(954, 150);
            this.dataGrid未生产.TabIndex = 0;
            this.dataGrid未生产.CellClick += new System.Windows.Forms.DataGridViewCellEventHandler(this.dataGridView1_CellClick);
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(12, 9);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(65, 12);
            this.label1.TabIndex = 1;
            this.label1.Text = "未生产产品";
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(364, 196);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(41, 12);
            this.label3.TabIndex = 120;
            this.label3.Text = "个单位";
            // 
            // button3
            // 
            this.button3.Location = new System.Drawing.Point(406, 191);
            this.button3.Name = "button3";
            this.button3.Size = new System.Drawing.Size(106, 23);
            this.button3.TabIndex = 121;
            this.button3.Text = "修改";
            this.button3.UseVisualStyleBackColor = true;
            this.button3.Click += new System.EventHandler(this.button3_Click);
            // 
            // textBox原料数量
            // 
            this.textBox原料数量.Location = new System.Drawing.Point(283, 193);
            this.textBox原料数量.Name = "textBox原料数量";
            this.textBox原料数量.Size = new System.Drawing.Size(75, 21);
            this.textBox原料数量.TabIndex = 119;
            // 
            // textBox原料
            // 
            this.textBox原料.Enabled = false;
            this.textBox原料.Location = new System.Drawing.Point(209, 193);
            this.textBox原料.Name = "textBox原料";
            this.textBox原料.Size = new System.Drawing.Size(68, 21);
            this.textBox原料.TabIndex = 118;
            // 
            // label29
            // 
            this.label29.AutoSize = true;
            this.label29.Location = new System.Drawing.Point(114, 196);
            this.label29.Name = "label29";
            this.label29.Size = new System.Drawing.Size(89, 12);
            this.label29.TabIndex = 117;
            this.label29.Text = "生产一件须原料";
            // 
            // textBox产品
            // 
            this.textBox产品.Enabled = false;
            this.textBox产品.Location = new System.Drawing.Point(50, 193);
            this.textBox产品.Name = "textBox产品";
            this.textBox产品.Size = new System.Drawing.Size(58, 21);
            this.textBox产品.TabIndex = 116;
            // 
            // label30
            // 
            this.label30.AutoSize = true;
            this.label30.Location = new System.Drawing.Point(15, 196);
            this.label30.Name = "label30";
            this.label30.Size = new System.Drawing.Size(29, 12);
            this.label30.TabIndex = 115;
            this.label30.Text = "产品";
            // 
            // dataGrid产品原料关系
            // 
            this.dataGrid产品原料关系.AllowUserToAddRows = false;
            this.dataGrid产品原料关系.AllowUserToDeleteRows = false;
            this.dataGrid产品原料关系.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dataGrid产品原料关系.Location = new System.Drawing.Point(14, 224);
            this.dataGrid产品原料关系.Name = "dataGrid产品原料关系";
            this.dataGrid产品原料关系.RowTemplate.Height = 23;
            this.dataGrid产品原料关系.Size = new System.Drawing.Size(366, 145);
            this.dataGrid产品原料关系.TabIndex = 114;
            this.dataGrid产品原料关系.CellClick += new System.Windows.Forms.DataGridViewCellEventHandler(this.dataGridView3_CellClick);
            // 
            // label7
            // 
            this.label7.AutoSize = true;
            this.label7.Location = new System.Drawing.Point(15, 373);
            this.label7.Name = "label7";
            this.label7.Size = new System.Drawing.Size(29, 12);
            this.label7.TabIndex = 123;
            this.label7.Text = "原料";
            // 
            // dataGrid原料
            // 
            this.dataGrid原料.AllowUserToAddRows = false;
            this.dataGrid原料.AllowUserToDeleteRows = false;
            this.dataGrid原料.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dataGrid原料.Location = new System.Drawing.Point(14, 388);
            this.dataGrid原料.Name = "dataGrid原料";
            this.dataGrid原料.RowTemplate.Height = 23;
            this.dataGrid原料.Size = new System.Drawing.Size(515, 75);
            this.dataGrid原料.TabIndex = 122;
            // 
            // label6
            // 
            this.label6.AutoSize = true;
            this.label6.Location = new System.Drawing.Point(605, 343);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(89, 12);
            this.label6.TabIndex = 127;
            this.label6.Text = "实际完成时间：";
            // 
            // date完成时间
            // 
            this.date完成时间.Location = new System.Drawing.Point(700, 337);
            this.date完成时间.Name = "date完成时间";
            this.date完成时间.Size = new System.Drawing.Size(200, 21);
            this.date完成时间.TabIndex = 126;
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Location = new System.Drawing.Point(629, 310);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(65, 12);
            this.label5.TabIndex = 125;
            this.label5.Text = "交付时间：";
            // 
            // date交付时间
            // 
            this.date交付时间.Location = new System.Drawing.Point(700, 304);
            this.date交付时间.Name = "date交付时间";
            this.date交付时间.Size = new System.Drawing.Size(200, 21);
            this.date交付时间.TabIndex = 124;
            // 
            // button1
            // 
            this.button1.Location = new System.Drawing.Point(261, 67);
            this.button1.Name = "button1";
            this.button1.Size = new System.Drawing.Size(119, 23);
            this.button1.TabIndex = 128;
            this.button1.Text = "领料";
            this.button1.UseVisualStyleBackColor = true;
            this.button1.Click += new System.EventHandler(this.button1_Click);
            // 
            // dataGrid产品
            // 
            this.dataGrid产品.AllowUserToAddRows = false;
            this.dataGrid产品.AllowUserToDeleteRows = false;
            this.dataGrid产品.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dataGrid产品.Location = new System.Drawing.Point(532, 206);
            this.dataGrid产品.Name = "dataGrid产品";
            this.dataGrid产品.ReadOnly = true;
            this.dataGrid产品.RowTemplate.Height = 23;
            this.dataGrid产品.Size = new System.Drawing.Size(434, 72);
            this.dataGrid产品.TabIndex = 129;
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(543, 191);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(29, 12);
            this.label2.TabIndex = 130;
            this.label2.Text = "产品";
            // 
            // button2
            // 
            this.button2.Location = new System.Drawing.Point(406, 343);
            this.button2.Name = "button2";
            this.button2.Size = new System.Drawing.Size(106, 23);
            this.button2.TabIndex = 132;
            this.button2.Text = "增加一种原料";
            this.button2.UseVisualStyleBackColor = true;
            this.button2.Click += new System.EventHandler(this.button2_Click);
            // 
            // button4
            // 
            this.button4.Location = new System.Drawing.Point(406, 286);
            this.button4.Name = "button4";
            this.button4.Size = new System.Drawing.Size(106, 23);
            this.button4.TabIndex = 131;
            this.button4.Text = "删除此种原料";
            this.button4.UseVisualStyleBackColor = true;
            this.button4.Click += new System.EventHandler(this.button4_Click);
            // 
            // textBox领料产品
            // 
            this.textBox领料产品.Enabled = false;
            this.textBox领料产品.Location = new System.Drawing.Point(74, 69);
            this.textBox领料产品.Name = "textBox领料产品";
            this.textBox领料产品.Size = new System.Drawing.Size(56, 21);
            this.textBox领料产品.TabIndex = 134;
            // 
            // groupBox1
            // 
            this.groupBox1.Controls.Add(this.textBox订单编号);
            this.groupBox1.Controls.Add(this.label9);
            this.groupBox1.Controls.Add(this.label8);
            this.groupBox1.Controls.Add(this.textBox产品数量);
            this.groupBox1.Controls.Add(this.button1);
            this.groupBox1.Controls.Add(this.textBox领料产品);
            this.groupBox1.Controls.Add(this.label4);
            this.groupBox1.Location = new System.Drawing.Point(545, 373);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Size = new System.Drawing.Size(421, 100);
            this.groupBox1.TabIndex = 135;
            this.groupBox1.TabStop = false;
            this.groupBox1.Text = "确认领料";
            // 
            // textBox订单编号
            // 
            this.textBox订单编号.Enabled = false;
            this.textBox订单编号.Location = new System.Drawing.Point(74, 20);
            this.textBox订单编号.Name = "textBox订单编号";
            this.textBox订单编号.Size = new System.Drawing.Size(65, 21);
            this.textBox订单编号.TabIndex = 138;
            // 
            // label9
            // 
            this.label9.AutoSize = true;
            this.label9.Location = new System.Drawing.Point(39, 23);
            this.label9.Name = "label9";
            this.label9.Size = new System.Drawing.Size(29, 12);
            this.label9.TabIndex = 137;
            this.label9.Text = "订单";
            // 
            // label8
            // 
            this.label8.AutoSize = true;
            this.label8.Location = new System.Drawing.Point(131, 72);
            this.label8.Name = "label8";
            this.label8.Size = new System.Drawing.Size(53, 12);
            this.label8.TabIndex = 136;
            this.label8.Text = "本次数量";
            // 
            // textBox产品数量
            // 
            this.textBox产品数量.Enabled = false;
            this.textBox产品数量.Location = new System.Drawing.Point(186, 69);
            this.textBox产品数量.Name = "textBox产品数量";
            this.textBox产品数量.Size = new System.Drawing.Size(59, 21);
            this.textBox产品数量.TabIndex = 135;
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Location = new System.Drawing.Point(39, 72);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(29, 12);
            this.label4.TabIndex = 133;
            this.label4.Text = "产品";
            // 
            // 领料生产
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 12F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(978, 480);
            this.Controls.Add(this.groupBox1);
            this.Controls.Add(this.button2);
            this.Controls.Add(this.button4);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.dataGrid产品);
            this.Controls.Add(this.label6);
            this.Controls.Add(this.date完成时间);
            this.Controls.Add(this.label5);
            this.Controls.Add(this.date交付时间);
            this.Controls.Add(this.label7);
            this.Controls.Add(this.dataGrid原料);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.button3);
            this.Controls.Add(this.textBox原料数量);
            this.Controls.Add(this.textBox原料);
            this.Controls.Add(this.label29);
            this.Controls.Add(this.textBox产品);
            this.Controls.Add(this.label30);
            this.Controls.Add(this.dataGrid产品原料关系);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.dataGrid未生产);
            this.Name = "领料生产";
            this.Text = "领料生产";
            this.Load += new System.EventHandler(this.领料生产_Load);
            ((System.ComponentModel.ISupportInitialize)(this.dataGrid未生产)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.dataGrid产品原料关系)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.dataGrid原料)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.dataGrid产品)).EndInit();
            this.groupBox1.ResumeLayout(false);
            this.groupBox1.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.DataGridView dataGrid未生产;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Button button3;
        private System.Windows.Forms.TextBox textBox原料数量;
        private System.Windows.Forms.TextBox textBox原料;
        private System.Windows.Forms.Label label29;
        private System.Windows.Forms.TextBox textBox产品;
        private System.Windows.Forms.Label label30;
        private System.Windows.Forms.DataGridView dataGrid产品原料关系;
        private System.Windows.Forms.Label label7;
        private System.Windows.Forms.DataGridView dataGrid原料;
        private System.Windows.Forms.Label label6;
        private System.Windows.Forms.DateTimePicker date完成时间;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.DateTimePicker date交付时间;
        private System.Windows.Forms.Button button1;
        private System.Windows.Forms.DataGridView dataGrid产品;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Button button2;
        private System.Windows.Forms.Button button4;
        private System.Windows.Forms.TextBox textBox领料产品;
        private System.Windows.Forms.GroupBox groupBox1;
        private System.Windows.Forms.Label label8;
        private System.Windows.Forms.TextBox textBox产品数量;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.TextBox textBox订单编号;
        private System.Windows.Forms.Label label9;
    }
}