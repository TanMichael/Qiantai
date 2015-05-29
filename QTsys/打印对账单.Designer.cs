namespace QTsys
{
    partial class 打印对账单
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
            this.label1 = new System.Windows.Forms.Label();
            this.button打印 = new System.Windows.Forms.Button();
            this.webBrowser预览 = new System.Windows.Forms.WebBrowser();
            this.SuspendLayout();
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(28, 28);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(53, 12);
            this.label1.TabIndex = 0;
            this.label1.Text = "打印预览";
            // 
            // button打印
            // 
            this.button打印.Location = new System.Drawing.Point(789, 17);
            this.button打印.Name = "button打印";
            this.button打印.Size = new System.Drawing.Size(75, 34);
            this.button打印.TabIndex = 1;
            this.button打印.Text = "打印";
            this.button打印.UseVisualStyleBackColor = true;
            this.button打印.Click += new System.EventHandler(this.button打印_Click);
            // 
            // webBrowser预览
            // 
            this.webBrowser预览.Location = new System.Drawing.Point(30, 64);
            this.webBrowser预览.MinimumSize = new System.Drawing.Size(20, 20);
            this.webBrowser预览.Name = "webBrowser预览";
            this.webBrowser预览.Size = new System.Drawing.Size(876, 628);
            this.webBrowser预览.TabIndex = 2;
            // 
            // 打印对账单
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 12F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(918, 704);
            this.Controls.Add(this.webBrowser预览);
            this.Controls.Add(this.button打印);
            this.Controls.Add(this.label1);
            this.Name = "打印对账单";
            this.Text = "打印对账单";
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Button button打印;
        private System.Windows.Forms.WebBrowser webBrowser预览;
    }
}