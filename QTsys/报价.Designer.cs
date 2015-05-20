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
            this.Column订单编号 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Column客户名称 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Column创建时间 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Column创建人 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.label样品订单表 = new System.Windows.Forms.Label();
            this.label产品列表 = new System.Windows.Forms.Label();
            this.dataGridView产品 = new System.Windows.Forms.DataGridView();
            this.Column产品编号 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Column产品名称 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Column规格 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Column单位 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.checkBox所有没有报价 = new System.Windows.Forms.CheckBox();
            ((System.ComponentModel.ISupportInitialize)(this.dataGridView样品)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.dataGridView产品)).BeginInit();
            this.SuspendLayout();
            // 
            // label产品
            // 
            this.label产品.AutoSize = true;
            this.label产品.Location = new System.Drawing.Point(38, 37);
            this.label产品.Name = "label产品";
            this.label产品.Size = new System.Drawing.Size(29, 12);
            this.label产品.TabIndex = 0;
            this.label产品.Text = "产品";
            // 
            // label产品Value
            // 
            this.label产品Value.AutoSize = true;
            this.label产品Value.Location = new System.Drawing.Point(98, 37);
            this.label产品Value.Name = "label产品Value";
            this.label产品Value.Size = new System.Drawing.Size(0, 12);
            this.label产品Value.TabIndex = 1;
            // 
            // label报价
            // 
            this.label报价.AutoSize = true;
            this.label报价.Location = new System.Drawing.Point(38, 68);
            this.label报价.Name = "label报价";
            this.label报价.Size = new System.Drawing.Size(29, 12);
            this.label报价.TabIndex = 2;
            this.label报价.Text = "报价";
            // 
            // textBox报价
            // 
            this.textBox报价.Location = new System.Drawing.Point(100, 68);
            this.textBox报价.Name = "textBox报价";
            this.textBox报价.Size = new System.Drawing.Size(100, 21);
            this.textBox报价.TabIndex = 3;
            // 
            // button报价
            // 
            this.button报价.Location = new System.Drawing.Point(583, 46);
            this.button报价.Name = "button报价";
            this.button报价.Size = new System.Drawing.Size(75, 23);
            this.button报价.TabIndex = 4;
            this.button报价.Text = "报价";
            this.button报价.UseVisualStyleBackColor = true;
            // 
            // dataGridView样品
            // 
            this.dataGridView样品.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dataGridView样品.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.Column订单编号,
            this.Column客户名称,
            this.Column创建时间,
            this.Column创建人});
            this.dataGridView样品.Location = new System.Drawing.Point(40, 117);
            this.dataGridView样品.Name = "dataGridView样品";
            this.dataGridView样品.RowTemplate.Height = 23;
            this.dataGridView样品.Size = new System.Drawing.Size(504, 150);
            this.dataGridView样品.TabIndex = 5;
            // 
            // Column订单编号
            // 
            this.Column订单编号.HeaderText = "订单编号";
            this.Column订单编号.Name = "Column订单编号";
            // 
            // Column客户名称
            // 
            this.Column客户名称.HeaderText = "客户名称";
            this.Column客户名称.Name = "Column客户名称";
            // 
            // Column创建时间
            // 
            this.Column创建时间.HeaderText = "创建时间";
            this.Column创建时间.Name = "Column创建时间";
            // 
            // Column创建人
            // 
            this.Column创建人.HeaderText = "创建人";
            this.Column创建人.Name = "Column创建人";
            // 
            // label样品订单表
            // 
            this.label样品订单表.AutoSize = true;
            this.label样品订单表.Location = new System.Drawing.Point(40, 99);
            this.label样品订单表.Name = "label样品订单表";
            this.label样品订单表.Size = new System.Drawing.Size(113, 12);
            this.label样品订单表.TabIndex = 6;
            this.label样品订单表.Text = "已完成样品订单列表";
            // 
            // label产品列表
            // 
            this.label产品列表.AutoSize = true;
            this.label产品列表.Location = new System.Drawing.Point(40, 297);
            this.label产品列表.Name = "label产品列表";
            this.label产品列表.Size = new System.Drawing.Size(53, 12);
            this.label产品列表.TabIndex = 7;
            this.label产品列表.Text = "产品列表";
            // 
            // dataGridView产品
            // 
            this.dataGridView产品.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dataGridView产品.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.Column产品编号,
            this.Column产品名称,
            this.Column规格,
            this.Column单位});
            this.dataGridView产品.Location = new System.Drawing.Point(42, 329);
            this.dataGridView产品.Name = "dataGridView产品";
            this.dataGridView产品.RowTemplate.Height = 23;
            this.dataGridView产品.Size = new System.Drawing.Size(502, 150);
            this.dataGridView产品.TabIndex = 8;
            // 
            // Column产品编号
            // 
            this.Column产品编号.HeaderText = "产品编号";
            this.Column产品编号.Name = "Column产品编号";
            // 
            // Column产品名称
            // 
            this.Column产品名称.HeaderText = "产品名称";
            this.Column产品名称.Name = "Column产品名称";
            // 
            // Column规格
            // 
            this.Column规格.HeaderText = "规格";
            this.Column规格.Name = "Column规格";
            // 
            // Column单位
            // 
            this.Column单位.HeaderText = "单位";
            this.Column单位.Name = "Column单位";
            // 
            // checkBox所有没有报价
            // 
            this.checkBox所有没有报价.AutoSize = true;
            this.checkBox所有没有报价.Location = new System.Drawing.Point(281, 292);
            this.checkBox所有没有报价.Name = "checkBox所有没有报价";
            this.checkBox所有没有报价.Size = new System.Drawing.Size(132, 16);
            this.checkBox所有没有报价.TabIndex = 9;
            this.checkBox所有没有报价.Text = "所有没有报价的产品";
            this.checkBox所有没有报价.UseVisualStyleBackColor = true;
            // 
            // 报价
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 12F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(780, 614);
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
        private System.Windows.Forms.DataGridViewTextBoxColumn Column订单编号;
        private System.Windows.Forms.DataGridViewTextBoxColumn Column客户名称;
        private System.Windows.Forms.DataGridViewTextBoxColumn Column创建时间;
        private System.Windows.Forms.DataGridViewTextBoxColumn Column创建人;
        private System.Windows.Forms.Label label样品订单表;
        private System.Windows.Forms.Label label产品列表;
        private System.Windows.Forms.DataGridView dataGridView产品;
        private System.Windows.Forms.DataGridViewTextBoxColumn Column产品编号;
        private System.Windows.Forms.DataGridViewTextBoxColumn Column产品名称;
        private System.Windows.Forms.DataGridViewTextBoxColumn Column规格;
        private System.Windows.Forms.DataGridViewTextBoxColumn Column单位;
        private System.Windows.Forms.CheckBox checkBox所有没有报价;
    }
}