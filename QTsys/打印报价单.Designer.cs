namespace QTsys
{
    partial class 打印报价单
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
            this.webBrowser预览 = new System.Windows.Forms.WebBrowser();
            this.button打印 = new System.Windows.Forms.Button();
            this.label1 = new System.Windows.Forms.Label();
            this.SuspendLayout();
            // 
            // webBrowser预览
            // 
            this.webBrowser预览.Location = new System.Drawing.Point(28, 62);
            this.webBrowser预览.MinimumSize = new System.Drawing.Size(20, 20);
            this.webBrowser预览.Name = "webBrowser预览";
            this.webBrowser预览.Size = new System.Drawing.Size(876, 614);
            this.webBrowser预览.TabIndex = 5;
            // 
            // button打印
            // 
            this.button打印.Location = new System.Drawing.Point(787, 15);
            this.button打印.Name = "button打印";
            this.button打印.Size = new System.Drawing.Size(75, 34);
            this.button打印.TabIndex = 4;
            this.button打印.Text = "打印";
            this.button打印.UseVisualStyleBackColor = true;
            this.button打印.Click += new System.EventHandler(this.button打印_Click);
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(26, 26);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(53, 12);
            this.label1.TabIndex = 3;
            this.label1.Text = "打印预览";
            // 
            // 打印报价单
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 12F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(919, 717);
            this.Controls.Add(this.webBrowser预览);
            this.Controls.Add(this.button打印);
            this.Controls.Add(this.label1);
            this.Name = "打印报价单";
            this.Text = "打印报价单";
            this.Load += new System.EventHandler(this.打印报价单_Load);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.WebBrowser webBrowser预览;
        private System.Windows.Forms.Button button打印;
        private System.Windows.Forms.Label label1;
    }
}