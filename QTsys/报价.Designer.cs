namespace QTsys
{
    partial class 报价
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
            this.label产品 = new System.Windows.Forms.Label();
            this.label产品Value = new System.Windows.Forms.Label();
            this.label报价 = new System.Windows.Forms.Label();
            this.textBox报价 = new System.Windows.Forms.TextBox();
            this.button报价 = new System.Windows.Forms.Button();
            this.dataGridView样品 = new System.Windows.Forms.DataGridView();
            this.label样品订单表 = new System.Windows.Forms.Label();
            this.label产品列表 = new System.Windows.Forms.Label();
            this.dataGridView产品 = new System.Windows.Forms.DataGridView();
            this.checkBox所有没有报价 = new System.Windows.Forms.CheckBox();
            this.button1 = new System.Windows.Forms.Button();
            ((System.ComponentModel.ISupportInitialize)(this.dataGridView样品)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.dataGridView产品)).BeginInit();
            this.SuspendLayout();
            // 
            // label产品
            // 
            this.label产品.AutoSize = true;
            this.label产品.Location = new System.Drawing.Point(8, 13);
            this.label产品.Name = "label产品";
            this.label产品.Size = new System.Drawing.Size(29, 12);
            this.label产品.TabIndex = 0;
            this.label产品.Text = "产品";
            // 
            // label产品Value
            // 
            this.label产品Value.AutoSize = true;
            this.label产品Value.Location = new System.Drawing.Point(68, 13);
            this.label产品Value.Name = "label产品Value";
            this.label产品Value.Size = new System.Drawing.Size(0, 12);
            this.label产品Value.TabIndex = 1;
            // 
            // label报价
            // 
            this.label报价.AutoSize = true;
            this.label报价.Location = new System.Drawing.Point(8, 44);
            this.label报价.Name = "label报价";
            this.label报价.Size = new System.Drawing.Size(29, 12);
            this.label报价.TabIndex = 2;
            this.label报价.Text = "报价";
            // 
            // textBox报价
            // 
            this.textBox报价.Location = new System.Drawing.Point(70, 44);
            this.textBox报价.Name = "textBox报价";
            this.textBox报价.Size = new System.Drawing.Size(100, 21);
            this.textBox报价.TabIndex = 3;
            // 
            // button报价
            // 
            this.button报价.Location = new System.Drawing.Point(427, 35);
            this.button报价.Name = "button报价";
            this.button报价.Size = new System.Drawing.Size(75, 27);
            this.button报价.TabIndex = 4;
            this.button报价.Text = "报价";
            this.button报价.UseVisualStyleBackColor = true;
            this.button报价.Click += new System.EventHandler(this.button报价_Click);
            // 
            // dataGridView样品
            // 
            this.dataGridView样品.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dataGridView样品.Location = new System.Drawing.Point(10, 93);
            this.dataGridView样品.Name = "dataGridView样品";
            this.dataGridView样品.RowTemplate.Height = 23;
            this.dataGridView样品.Size = new System.Drawing.Size(577, 150);
            this.dataGridView样品.TabIndex = 5;
            this.dataGridView样品.CellClick += new System.Windows.Forms.DataGridViewCellEventHandler(this.dataGridView样品_CellClick);
            // 
            // label样品订单表
            // 
            this.label样品订单表.AutoSize = true;
            this.label样品订单表.Location = new System.Drawing.Point(10, 75);
            this.label样品订单表.Name = "label样品订单表";
            this.label样品订单表.Size = new System.Drawing.Size(113, 12);
            this.label样品订单表.TabIndex = 6;
            this.label样品订单表.Text = "已完成样品订单列表";
            // 
            // label产品列表
            // 
            this.label产品列表.AutoSize = true;
            this.label产品列表.Location = new System.Drawing.Point(10, 273);
            this.label产品列表.Name = "label产品列表";
            this.label产品列表.Size = new System.Drawing.Size(53, 12);
            this.label产品列表.TabIndex = 7;
            this.label产品列表.Text = "产品列表";
            // 
            // dataGridView产品
            // 
            this.dataGridView产品.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dataGridView产品.Location = new System.Drawing.Point(12, 305);
            this.dataGridView产品.Name = "dataGridView产品";
            this.dataGridView产品.RowTemplate.Height = 23;
            this.dataGridView产品.Size = new System.Drawing.Size(575, 218);
            this.dataGridView产品.TabIndex = 8;
            this.dataGridView产品.CellClick += new System.Windows.Forms.DataGridViewCellEventHandler(this.dataGridView产品_CellClick);
            // 
            // checkBox所有没有报价
            // 
            this.checkBox所有没有报价.AutoSize = true;
            this.checkBox所有没有报价.Location = new System.Drawing.Point(251, 268);
            this.checkBox所有没有报价.Name = "checkBox所有没有报价";
            this.checkBox所有没有报价.Size = new System.Drawing.Size(132, 16);
            this.checkBox所有没有报价.TabIndex = 9;
            this.checkBox所有没有报价.Text = "所有没有报价的产品";
            this.checkBox所有没有报价.UseVisualStyleBackColor = true;
            this.checkBox所有没有报价.CheckedChanged += new System.EventHandler(this.checkBox所有没有报价_CheckedChanged);
            // 
            // button1
            // 
            this.button1.Location = new System.Drawing.Point(398, 542);
            this.button1.Name = "button1";
            this.button1.Size = new System.Drawing.Size(189, 23);
            this.button1.TabIndex = 10;
            this.button1.Text = "导出须报价产品列表到EXCEL";
            this.button1.UseVisualStyleBackColor = true;
            this.button1.Click += new System.EventHandler(this.button1_Click);
            // 
            // 报价
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 12F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(599, 577);
            this.Controls.Add(this.button1);
            this.Controls.Add(this.checkBox所有没有报价);
            this.Controls.Add(this.dataGridView产品);
            this.Controls.Add(this.label产品列表);
            this.Controls.Add(this.label样品订单表);
            this.Controls.Add(this.dataGridView样品);
            this.Controls.Add(this.button报价);
            this.Controls.Add(this.textBox报价);
            this.Controls.Add(this.label报价);
            this.Controls.Add(this.label产品Value);
            this.Controls.Add(this.label产品);
            this.Name = "报价";
            this.Text = "报价";
            this.Load += new System.EventHandler(this.报价_Load);
            ((System.ComponentModel.ISupportInitialize)(this.dataGridView样品)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.dataGridView产品)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label label产品;
        private System.Windows.Forms.Label label产品Value;
        private System.Windows.Forms.Label label报价;
        private System.Windows.Forms.TextBox textBox报价;
        private System.Windows.Forms.Button button报价;
        private System.Windows.Forms.DataGridView dataGridView样品;
        private System.Windows.Forms.Label label样品订单表;
        private System.Windows.Forms.Label label产品列表;
        private System.Windows.Forms.DataGridView dataGridView产品;
        private System.Windows.Forms.CheckBox checkBox所有没有报价;
        private System.Windows.Forms.Button button1;
    }
}