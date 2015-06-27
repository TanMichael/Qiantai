namespace QTsys
{
    partial class 根据订单生成计划
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
            this.label3 = new System.Windows.Forms.Label();
            this.button修改 = new System.Windows.Forms.Button();
            this.textBox原料数量 = new System.Windows.Forms.TextBox();
            this.groupBox1 = new System.Windows.Forms.GroupBox();
            this.textBox原料 = new System.Windows.Forms.TextBox();
            this.label29 = new System.Windows.Forms.Label();
            this.text订单编号 = new System.Windows.Forms.TextBox();
            this.textBox产品 = new System.Windows.Forms.TextBox();
            this.label8 = new System.Windows.Forms.Label();
            this.label30 = new System.Windows.Forms.Label();
            this.label7 = new System.Windows.Forms.Label();
            this.dataGridView7 = new System.Windows.Forms.DataGridView();
            this.dataGridView产品原料关系 = new System.Windows.Forms.DataGridView();
            this.button加入生产计划 = new System.Windows.Forms.Button();
            this.dataGridView参数修正 = new System.Windows.Forms.DataGridView();
            this.label2 = new System.Windows.Forms.Label();
            this.label1 = new System.Windows.Forms.Label();
            this.dataGridView产品订单数据 = new System.Windows.Forms.DataGridView();
            this.textBox1 = new System.Windows.Forms.TextBox();
            this.label4 = new System.Windows.Forms.Label();
            this.date交付时间 = new System.Windows.Forms.DateTimePicker();
            this.label5 = new System.Windows.Forms.Label();
            this.label6 = new System.Windows.Forms.Label();
            this.date完成时间 = new System.Windows.Forms.DateTimePicker();
            this.label9 = new System.Windows.Forms.Label();
            this.textBox库存件数 = new System.Windows.Forms.TextBox();
            this.checkBox1 = new System.Windows.Forms.CheckBox();
            this.label库存数 = new System.Windows.Forms.Label();
            this.label10 = new System.Windows.Forms.Label();
            this.groupBox1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dataGridView7)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.dataGridView产品原料关系)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.dataGridView参数修正)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.dataGridView产品订单数据)).BeginInit();
            this.SuspendLayout();
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(364, 293);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(41, 12);
            this.label3.TabIndex = 111;
            this.label3.Text = "个单位";
            // 
            // button修改
            // 
            this.button修改.Location = new System.Drawing.Point(406, 288);
            this.button修改.Name = "button修改";
            this.button修改.Size = new System.Drawing.Size(37, 23);
            this.button修改.TabIndex = 113;
            this.button修改.Text = "修改";
            this.button修改.UseVisualStyleBackColor = true;
            this.button修改.Visible = false;
            // 
            // textBox原料数量
            // 
            this.textBox原料数量.Location = new System.Drawing.Point(283, 290);
            this.textBox原料数量.Name = "textBox原料数量";
            this.textBox原料数量.Size = new System.Drawing.Size(75, 21);
            this.textBox原料数量.TabIndex = 110;
            // 
            // groupBox1
            // 
            this.groupBox1.Controls.Add(this.label10);
            this.groupBox1.Controls.Add(this.label库存数);
            this.groupBox1.Controls.Add(this.checkBox1);
            this.groupBox1.Controls.Add(this.textBox库存件数);
            this.groupBox1.Controls.Add(this.label9);
            this.groupBox1.Location = new System.Drawing.Point(459, 156);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Size = new System.Drawing.Size(519, 246);
            this.groupBox1.TabIndex = 112;
            this.groupBox1.TabStop = false;
            this.groupBox1.Text = "产品库存";
            // 
            // textBox原料
            // 
            this.textBox原料.Enabled = false;
            this.textBox原料.Location = new System.Drawing.Point(209, 290);
            this.textBox原料.Name = "textBox原料";
            this.textBox原料.Size = new System.Drawing.Size(68, 21);
            this.textBox原料.TabIndex = 109;
            // 
            // label29
            // 
            this.label29.AutoSize = true;
            this.label29.Location = new System.Drawing.Point(114, 293);
            this.label29.Name = "label29";
            this.label29.Size = new System.Drawing.Size(89, 12);
            this.label29.TabIndex = 108;
            this.label29.Text = "生产一件须原料";
            // 
            // text订单编号
            // 
            this.text订单编号.Enabled = false;
            this.text订单编号.Location = new System.Drawing.Point(875, 5);
            this.text订单编号.Name = "text订单编号";
            this.text订单编号.Size = new System.Drawing.Size(100, 21);
            this.text订单编号.TabIndex = 105;
            // 
            // textBox产品
            // 
            this.textBox产品.Enabled = false;
            this.textBox产品.Location = new System.Drawing.Point(50, 290);
            this.textBox产品.Name = "textBox产品";
            this.textBox产品.Size = new System.Drawing.Size(58, 21);
            this.textBox产品.TabIndex = 107;
            // 
            // label8
            // 
            this.label8.AutoSize = true;
            this.label8.Location = new System.Drawing.Point(820, 9);
            this.label8.Name = "label8";
            this.label8.Size = new System.Drawing.Size(53, 12);
            this.label8.TabIndex = 104;
            this.label8.Text = "订单号：";
            // 
            // label30
            // 
            this.label30.AutoSize = true;
            this.label30.Location = new System.Drawing.Point(15, 293);
            this.label30.Name = "label30";
            this.label30.Size = new System.Drawing.Size(29, 12);
            this.label30.TabIndex = 106;
            this.label30.Text = "产品";
            // 
            // label7
            // 
            this.label7.AutoSize = true;
            this.label7.Location = new System.Drawing.Point(15, 469);
            this.label7.Name = "label7";
            this.label7.Size = new System.Drawing.Size(29, 12);
            this.label7.TabIndex = 103;
            this.label7.Text = "原料";
            // 
            // dataGridView7
            // 
            this.dataGridView7.AllowUserToAddRows = false;
            this.dataGridView7.AllowUserToDeleteRows = false;
            this.dataGridView7.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dataGridView7.Location = new System.Drawing.Point(14, 484);
            this.dataGridView7.Name = "dataGridView7";
            this.dataGridView7.RowTemplate.Height = 23;
            this.dataGridView7.Size = new System.Drawing.Size(515, 86);
            this.dataGridView7.TabIndex = 102;
            // 
            // dataGridView产品原料关系
            // 
            this.dataGridView产品原料关系.AllowUserToAddRows = false;
            this.dataGridView产品原料关系.AllowUserToDeleteRows = false;
            this.dataGridView产品原料关系.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dataGridView产品原料关系.Location = new System.Drawing.Point(14, 321);
            this.dataGridView产品原料关系.Name = "dataGridView产品原料关系";
            this.dataGridView产品原料关系.RowTemplate.Height = 23;
            this.dataGridView产品原料关系.Size = new System.Drawing.Size(434, 145);
            this.dataGridView产品原料关系.TabIndex = 101;
            this.dataGridView产品原料关系.CellClick += new System.Windows.Forms.DataGridViewCellEventHandler(this.dataGridView产品原料关系_CellClick);
            // 
            // button加入生产计划
            // 
            this.button加入生产计划.Location = new System.Drawing.Point(677, 536);
            this.button加入生产计划.Name = "button加入生产计划";
            this.button加入生产计划.Size = new System.Drawing.Size(119, 23);
            this.button加入生产计划.TabIndex = 100;
            this.button加入生产计划.Text = "加入生产计划";
            this.button加入生产计划.UseVisualStyleBackColor = true;
            this.button加入生产计划.Click += new System.EventHandler(this.button加入生产计划_Click);
            // 
            // dataGridView参数修正
            // 
            this.dataGridView参数修正.AllowUserToAddRows = false;
            this.dataGridView参数修正.AllowUserToDeleteRows = false;
            this.dataGridView参数修正.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dataGridView参数修正.Location = new System.Drawing.Point(12, 141);
            this.dataGridView参数修正.Name = "dataGridView参数修正";
            this.dataGridView参数修正.ReadOnly = true;
            this.dataGridView参数修正.RowTemplate.Height = 23;
            this.dataGridView参数修正.Size = new System.Drawing.Size(434, 141);
            this.dataGridView参数修正.TabIndex = 99;
            this.dataGridView参数修正.CellClick += new System.Windows.Forms.DataGridViewCellEventHandler(this.dataGridView参数修正_CellClick);
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(12, 122);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(77, 12);
            this.label2.TabIndex = 98;
            this.label2.Text = "产品参数校正";
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(12, 9);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(77, 12);
            this.label1.TabIndex = 97;
            this.label1.Text = "产品订单数据";
            // 
            // dataGridView产品订单数据
            // 
            this.dataGridView产品订单数据.AllowUserToAddRows = false;
            this.dataGridView产品订单数据.AllowUserToDeleteRows = false;
            this.dataGridView产品订单数据.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dataGridView产品订单数据.Location = new System.Drawing.Point(8, 32);
            this.dataGridView产品订单数据.Name = "dataGridView产品订单数据";
            this.dataGridView产品订单数据.ReadOnly = true;
            this.dataGridView产品订单数据.RowTemplate.Height = 23;
            this.dataGridView产品订单数据.Size = new System.Drawing.Size(970, 85);
            this.dataGridView产品订单数据.TabIndex = 96;
            this.dataGridView产品订单数据.CellClick += new System.Windows.Forms.DataGridViewCellEventHandler(this.dataGridView产品订单数据_CellClick);
            // 
            // textBox1
            // 
            this.textBox1.Enabled = false;
            this.textBox1.Location = new System.Drawing.Point(714, 6);
            this.textBox1.Name = "textBox1";
            this.textBox1.Size = new System.Drawing.Size(100, 21);
            this.textBox1.TabIndex = 115;
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Location = new System.Drawing.Point(649, 9);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(65, 12);
            this.label4.TabIndex = 114;
            this.label4.Text = "订单类型：";
            // 
            // date交付时间
            // 
            this.date交付时间.Location = new System.Drawing.Point(650, 422);
            this.date交付时间.Name = "date交付时间";
            this.date交付时间.Size = new System.Drawing.Size(200, 21);
            this.date交付时间.TabIndex = 116;
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Location = new System.Drawing.Point(579, 428);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(65, 12);
            this.label5.TabIndex = 117;
            this.label5.Text = "交付时间：";
            // 
            // label6
            // 
            this.label6.AutoSize = true;
            this.label6.Location = new System.Drawing.Point(555, 461);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(89, 12);
            this.label6.TabIndex = 119;
            this.label6.Text = "实际完成时间：";
            // 
            // date完成时间
            // 
            this.date完成时间.Location = new System.Drawing.Point(650, 455);
            this.date完成时间.Name = "date完成时间";
            this.date完成时间.Size = new System.Drawing.Size(200, 21);
            this.date完成时间.TabIndex = 118;
            // 
            // label9
            // 
            this.label9.AutoSize = true;
            this.label9.Location = new System.Drawing.Point(28, 56);
            this.label9.Name = "label9";
            this.label9.Size = new System.Drawing.Size(53, 12);
            this.label9.TabIndex = 0;
            this.label9.Text = "当前库存";
            // 
            // textBox库存件数
            // 
            this.textBox库存件数.Enabled = false;
            this.textBox库存件数.Location = new System.Drawing.Point(141, 106);
            this.textBox库存件数.Name = "textBox库存件数";
            this.textBox库存件数.Size = new System.Drawing.Size(53, 21);
            this.textBox库存件数.TabIndex = 1;
            this.textBox库存件数.TextChanged += new System.EventHandler(this.textBox库存件数_TextChanged);
            // 
            // checkBox1
            // 
            this.checkBox1.AutoSize = true;
            this.checkBox1.Location = new System.Drawing.Point(30, 109);
            this.checkBox1.Name = "checkBox1";
            this.checkBox1.Size = new System.Drawing.Size(96, 16);
            this.checkBox1.TabIndex = 2;
            this.checkBox1.Text = "优先从库存发";
            this.checkBox1.UseVisualStyleBackColor = true;
            this.checkBox1.CheckedChanged += new System.EventHandler(this.checkBox1_CheckedChanged);
            // 
            // label库存数
            // 
            this.label库存数.AutoSize = true;
            this.label库存数.Location = new System.Drawing.Point(96, 56);
            this.label库存数.Name = "label库存数";
            this.label库存数.Size = new System.Drawing.Size(23, 12);
            this.label库存数.TabIndex = 3;
            this.label库存数.Text = "...";
            // 
            // label10
            // 
            this.label10.AutoSize = true;
            this.label10.Location = new System.Drawing.Point(200, 109);
            this.label10.Name = "label10";
            this.label10.Size = new System.Drawing.Size(17, 12);
            this.label10.TabIndex = 4;
            this.label10.Text = "件";
            // 
            // 根据订单生成计划
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 12F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(986, 571);
            this.Controls.Add(this.label6);
            this.Controls.Add(this.date完成时间);
            this.Controls.Add(this.label5);
            this.Controls.Add(this.date交付时间);
            this.Controls.Add(this.textBox1);
            this.Controls.Add(this.label4);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.button修改);
            this.Controls.Add(this.textBox原料数量);
            this.Controls.Add(this.groupBox1);
            this.Controls.Add(this.textBox原料);
            this.Controls.Add(this.label29);
            this.Controls.Add(this.text订单编号);
            this.Controls.Add(this.textBox产品);
            this.Controls.Add(this.label8);
            this.Controls.Add(this.label30);
            this.Controls.Add(this.label7);
            this.Controls.Add(this.dataGridView7);
            this.Controls.Add(this.dataGridView产品原料关系);
            this.Controls.Add(this.button加入生产计划);
            this.Controls.Add(this.dataGridView参数修正);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.dataGridView产品订单数据);
            this.Name = "根据订单生成计划";
            this.Text = "根据订单生成计划";
            this.Load += new System.EventHandler(this.样品库存自动生成_Load);
            this.groupBox1.ResumeLayout(false);
            this.groupBox1.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dataGridView7)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.dataGridView产品原料关系)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.dataGridView参数修正)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.dataGridView产品订单数据)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Button button修改;
        private System.Windows.Forms.TextBox textBox原料数量;
        private System.Windows.Forms.GroupBox groupBox1;
        private System.Windows.Forms.TextBox textBox原料;
        private System.Windows.Forms.Label label29;
        private System.Windows.Forms.TextBox text订单编号;
        private System.Windows.Forms.TextBox textBox产品;
        private System.Windows.Forms.Label label8;
        private System.Windows.Forms.Label label30;
        private System.Windows.Forms.Label label7;
        private System.Windows.Forms.DataGridView dataGridView7;
        private System.Windows.Forms.DataGridView dataGridView产品原料关系;
        private System.Windows.Forms.Button button加入生产计划;
        private System.Windows.Forms.DataGridView dataGridView参数修正;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.DataGridView dataGridView产品订单数据;
        private System.Windows.Forms.TextBox textBox1;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.DateTimePicker date交付时间;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.Label label6;
        private System.Windows.Forms.DateTimePicker date完成时间;
        private System.Windows.Forms.Label label10;
        private System.Windows.Forms.Label label库存数;
        private System.Windows.Forms.CheckBox checkBox1;
        private System.Windows.Forms.TextBox textBox库存件数;
        private System.Windows.Forms.Label label9;

    }
}