namespace QTsys
{
    partial class 批量导入
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
            this.groupBox1 = new System.Windows.Forms.GroupBox();
            this.radio原料 = new System.Windows.Forms.RadioButton();
            this.radio产品 = new System.Windows.Forms.RadioButton();
            this.radio客户 = new System.Windows.Forms.RadioButton();
            this.radio员工 = new System.Windows.Forms.RadioButton();
            this.richTextBox1 = new System.Windows.Forms.RichTextBox();
            this.label1 = new System.Windows.Forms.Label();
            this.button1 = new System.Windows.Forms.Button();
            this.groupBox1.SuspendLayout();
            this.SuspendLayout();
            // 
            // groupBox1
            // 
            this.groupBox1.Controls.Add(this.radio原料);
            this.groupBox1.Controls.Add(this.radio产品);
            this.groupBox1.Controls.Add(this.radio客户);
            this.groupBox1.Controls.Add(this.radio员工);
            this.groupBox1.Location = new System.Drawing.Point(12, 12);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Size = new System.Drawing.Size(153, 197);
            this.groupBox1.TabIndex = 0;
            this.groupBox1.TabStop = false;
            this.groupBox1.Text = "导入类型";
            // 
            // radio原料
            // 
            this.radio原料.AutoSize = true;
            this.radio原料.Location = new System.Drawing.Point(15, 86);
            this.radio原料.Name = "radio原料";
            this.radio原料.Size = new System.Drawing.Size(71, 16);
            this.radio原料.TabIndex = 3;
            this.radio原料.TabStop = true;
            this.radio原料.Text = "原料信息";
            this.radio原料.UseVisualStyleBackColor = true;
            // 
            // radio产品
            // 
            this.radio产品.AutoSize = true;
            this.radio产品.Location = new System.Drawing.Point(15, 64);
            this.radio产品.Name = "radio产品";
            this.radio产品.Size = new System.Drawing.Size(71, 16);
            this.radio产品.TabIndex = 2;
            this.radio产品.TabStop = true;
            this.radio产品.Text = "产品信息";
            this.radio产品.UseVisualStyleBackColor = true;
            // 
            // radio客户
            // 
            this.radio客户.AutoSize = true;
            this.radio客户.Location = new System.Drawing.Point(15, 42);
            this.radio客户.Name = "radio客户";
            this.radio客户.Size = new System.Drawing.Size(71, 16);
            this.radio客户.TabIndex = 1;
            this.radio客户.TabStop = true;
            this.radio客户.Text = "客户信息";
            this.radio客户.UseVisualStyleBackColor = true;
            // 
            // radio员工
            // 
            this.radio员工.AutoSize = true;
            this.radio员工.Location = new System.Drawing.Point(15, 20);
            this.radio员工.Name = "radio员工";
            this.radio员工.Size = new System.Drawing.Size(71, 16);
            this.radio员工.TabIndex = 0;
            this.radio员工.TabStop = true;
            this.radio员工.Text = "员工信息";
            this.radio员工.UseVisualStyleBackColor = true;
            // 
            // richTextBox1
            // 
            this.richTextBox1.Location = new System.Drawing.Point(184, 32);
            this.richTextBox1.Name = "richTextBox1";
            this.richTextBox1.Size = new System.Drawing.Size(715, 523);
            this.richTextBox1.TabIndex = 1;
            this.richTextBox1.Text = "";
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(184, 12);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(77, 12);
            this.label1.TabIndex = 2;
            this.label1.Text = "导入结果显示";
            // 
            // button1
            // 
            this.button1.Location = new System.Drawing.Point(47, 229);
            this.button1.Name = "button1";
            this.button1.Size = new System.Drawing.Size(75, 23);
            this.button1.TabIndex = 3;
            this.button1.Text = "选择文件";
            this.button1.UseVisualStyleBackColor = true;
            this.button1.Click += new System.EventHandler(this.button1_Click);
            // 
            // 批量导入
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 12F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(911, 567);
            this.Controls.Add(this.button1);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.richTextBox1);
            this.Controls.Add(this.groupBox1);
            this.Name = "批量导入";
            this.Text = "批量导入";
            this.Load += new System.EventHandler(this.批量导入_Load);
            this.groupBox1.ResumeLayout(false);
            this.groupBox1.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.GroupBox groupBox1;
        private System.Windows.Forms.RadioButton radio客户;
        private System.Windows.Forms.RadioButton radio员工;
        private System.Windows.Forms.RadioButton radio原料;
        private System.Windows.Forms.RadioButton radio产品;
        private System.Windows.Forms.RichTextBox richTextBox1;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Button button1;
    }
}