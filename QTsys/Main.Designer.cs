namespace QTsys
{
    partial class Main
    {
        /// <summary>
        /// 必需的设计器变量。
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// 清理所有正在使用的资源。
        /// </summary>
        /// <param name="disposing">如果应释放托管资源，为 true；否则为 false。</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows 窗体设计器生成的代码

        /// <summary>
        /// 设计器支持所需的方法 - 不要
        /// 使用代码编辑器修改此方法的内容。
        /// </summary>
        private void InitializeComponent()
        {
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(Main));
            this.statusStrip1 = new System.Windows.Forms.StatusStrip();
            this.toolStripStatusLabel1 = new System.Windows.Forms.ToolStripStatusLabel();
            this.toolStripStatusLabel2 = new System.Windows.Forms.ToolStripStatusLabel();
            this.toolStripStatusLabel3 = new System.Windows.Forms.ToolStripStatusLabel();
            this.toolStripStatusLabel4 = new System.Windows.Forms.ToolStripStatusLabel();
            this.groupBox5 = new System.Windows.Forms.GroupBox();
            this.button产品 = new System.Windows.Forms.Button();
            this.button原料 = new System.Windows.Forms.Button();
            this.button产品管理 = new System.Windows.Forms.Button();
            this.groupBox3 = new System.Windows.Forms.GroupBox();
            this.button新增订单 = new System.Windows.Forms.Button();
            this.button生产管理 = new System.Windows.Forms.Button();
            this.button订单管理 = new System.Windows.Forms.Button();
            this.button销售管理 = new System.Windows.Forms.Button();
            this.groupBox1 = new System.Windows.Forms.GroupBox();
            this.button员工管理 = new System.Windows.Forms.Button();
            this.button客户管理 = new System.Windows.Forms.Button();
            this.button预警统计 = new System.Windows.Forms.Button();
            this.menuStrip1 = new System.Windows.Forms.MenuStrip();
            this.批处理ToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.导入ToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.导出ToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.toolStripSeparator1 = new System.Windows.Forms.ToolStripSeparator();
            this.退出ToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.系统管理ToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.修改密码ToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.toolStripSeparator2 = new System.Windows.Forms.ToolStripSeparator();
            this.相关设置ToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.注销ToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.关于ToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.groupBox2 = new System.Windows.Forms.GroupBox();
            this.button审核 = new System.Windows.Forms.Button();
            this.statusStrip1.SuspendLayout();
            this.groupBox5.SuspendLayout();
            this.groupBox3.SuspendLayout();
            this.groupBox1.SuspendLayout();
            this.menuStrip1.SuspendLayout();
            this.groupBox2.SuspendLayout();
            this.SuspendLayout();
            // 
            // statusStrip1
            // 
            this.statusStrip1.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.toolStripStatusLabel1,
            this.toolStripStatusLabel2,
            this.toolStripStatusLabel3,
            this.toolStripStatusLabel4});
            this.statusStrip1.Location = new System.Drawing.Point(0, 619);
            this.statusStrip1.Name = "statusStrip1";
            this.statusStrip1.Padding = new System.Windows.Forms.Padding(2, 0, 23, 0);
            this.statusStrip1.Size = new System.Drawing.Size(667, 22);
            this.statusStrip1.TabIndex = 0;
            this.statusStrip1.Text = "statusStrip1";
            // 
            // toolStripStatusLabel1
            // 
            this.toolStripStatusLabel1.Name = "toolStripStatusLabel1";
            this.toolStripStatusLabel1.Size = new System.Drawing.Size(131, 17);
            this.toolStripStatusLabel1.Text = "toolStripStatusLabel1";
            // 
            // toolStripStatusLabel2
            // 
            this.toolStripStatusLabel2.Name = "toolStripStatusLabel2";
            this.toolStripStatusLabel2.Size = new System.Drawing.Size(11, 17);
            this.toolStripStatusLabel2.Text = ":";
            // 
            // toolStripStatusLabel3
            // 
            this.toolStripStatusLabel3.Name = "toolStripStatusLabel3";
            this.toolStripStatusLabel3.Size = new System.Drawing.Size(131, 17);
            this.toolStripStatusLabel3.Text = "toolStripStatusLabel3";
            // 
            // toolStripStatusLabel4
            // 
            this.toolStripStatusLabel4.Name = "toolStripStatusLabel4";
            this.toolStripStatusLabel4.Size = new System.Drawing.Size(104, 17);
            this.toolStripStatusLabel4.Text = "，目前已经登录！";
            // 
            // groupBox5
            // 
            this.groupBox5.Controls.Add(this.button产品);
            this.groupBox5.Controls.Add(this.button原料);
            this.groupBox5.Font = new System.Drawing.Font("宋体", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.groupBox5.Location = new System.Drawing.Point(12, 39);
            this.groupBox5.Name = "groupBox5";
            this.groupBox5.Size = new System.Drawing.Size(317, 181);
            this.groupBox5.TabIndex = 12;
            this.groupBox5.TabStop = false;
            this.groupBox5.Text = "仓库管理";
            // 
            // button产品
            // 
            this.button产品.Cursor = System.Windows.Forms.Cursors.Hand;
            this.button产品.Font = new System.Drawing.Font("黑体", 16F);
            this.button产品.Image = ((System.Drawing.Image)(resources.GetObject("button产品.Image")));
            this.button产品.Location = new System.Drawing.Point(165, 25);
            this.button产品.Name = "button产品";
            this.button产品.Size = new System.Drawing.Size(146, 150);
            this.button产品.TabIndex = 8;
            this.button产品.Text = "产品";
            this.button产品.TextAlign = System.Drawing.ContentAlignment.BottomCenter;
            this.button产品.UseVisualStyleBackColor = true;
            this.button产品.Click += new System.EventHandler(this.button3_Click_1);
            // 
            // button原料
            // 
            this.button原料.Cursor = System.Windows.Forms.Cursors.Hand;
            this.button原料.Font = new System.Drawing.Font("黑体", 16F);
            this.button原料.Image = ((System.Drawing.Image)(resources.GetObject("button原料.Image")));
            this.button原料.Location = new System.Drawing.Point(6, 25);
            this.button原料.Name = "button原料";
            this.button原料.Size = new System.Drawing.Size(146, 150);
            this.button原料.TabIndex = 7;
            this.button原料.Text = "原料";
            this.button原料.TextAlign = System.Drawing.ContentAlignment.BottomCenter;
            this.button原料.UseVisualStyleBackColor = true;
            this.button原料.Click += new System.EventHandler(this.button4_Click);
            // 
            // button产品管理
            // 
            this.button产品管理.Cursor = System.Windows.Forms.Cursors.Hand;
            this.button产品管理.Font = new System.Drawing.Font("黑体", 16F);
            this.button产品管理.Image = ((System.Drawing.Image)(resources.GetObject("button产品管理.Image")));
            this.button产品管理.Location = new System.Drawing.Point(15, 25);
            this.button产品管理.Name = "button产品管理";
            this.button产品管理.Size = new System.Drawing.Size(146, 150);
            this.button产品管理.TabIndex = 8;
            this.button产品管理.Text = "产品管理";
            this.button产品管理.TextAlign = System.Drawing.ContentAlignment.BottomCenter;
            this.button产品管理.UseVisualStyleBackColor = true;
            this.button产品管理.Click += new System.EventHandler(this.button5_Click);
            // 
            // groupBox3
            // 
            this.groupBox3.Controls.Add(this.button产品管理);
            this.groupBox3.Controls.Add(this.button新增订单);
            this.groupBox3.Controls.Add(this.button生产管理);
            this.groupBox3.Controls.Add(this.button订单管理);
            this.groupBox3.Font = new System.Drawing.Font("宋体", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.groupBox3.Location = new System.Drawing.Point(17, 227);
            this.groupBox3.Name = "groupBox3";
            this.groupBox3.Size = new System.Drawing.Size(636, 187);
            this.groupBox3.TabIndex = 11;
            this.groupBox3.TabStop = false;
            this.groupBox3.Text = "生产/销售";
            // 
            // button新增订单
            // 
            this.button新增订单.Cursor = System.Windows.Forms.Cursors.Hand;
            this.button新增订单.Font = new System.Drawing.Font("黑体", 16F);
            this.button新增订单.Image = ((System.Drawing.Image)(resources.GetObject("button新增订单.Image")));
            this.button新增订单.Location = new System.Drawing.Point(167, 25);
            this.button新增订单.Name = "button新增订单";
            this.button新增订单.Size = new System.Drawing.Size(146, 150);
            this.button新增订单.TabIndex = 12;
            this.button新增订单.Text = "新增订单";
            this.button新增订单.TextAlign = System.Drawing.ContentAlignment.BottomCenter;
            this.button新增订单.UseVisualStyleBackColor = true;
            this.button新增订单.Click += new System.EventHandler(this.button9_Click_1);
            // 
            // button生产管理
            // 
            this.button生产管理.Cursor = System.Windows.Forms.Cursors.Hand;
            this.button生产管理.Font = new System.Drawing.Font("黑体", 16F);
            this.button生产管理.Image = ((System.Drawing.Image)(resources.GetObject("button生产管理.Image")));
            this.button生产管理.Location = new System.Drawing.Point(476, 25);
            this.button生产管理.Name = "button生产管理";
            this.button生产管理.Size = new System.Drawing.Size(146, 150);
            this.button生产管理.TabIndex = 10;
            this.button生产管理.Text = "生产管理";
            this.button生产管理.TextAlign = System.Drawing.ContentAlignment.BottomCenter;
            this.button生产管理.UseVisualStyleBackColor = true;
            this.button生产管理.Click += new System.EventHandler(this.button6_Click);
            // 
            // button订单管理
            // 
            this.button订单管理.Cursor = System.Windows.Forms.Cursors.Hand;
            this.button订单管理.Font = new System.Drawing.Font("黑体", 16F);
            this.button订单管理.Image = ((System.Drawing.Image)(resources.GetObject("button订单管理.Image")));
            this.button订单管理.Location = new System.Drawing.Point(318, 25);
            this.button订单管理.Name = "button订单管理";
            this.button订单管理.Size = new System.Drawing.Size(146, 150);
            this.button订单管理.TabIndex = 6;
            this.button订单管理.Text = "订单管理";
            this.button订单管理.TextAlign = System.Drawing.ContentAlignment.BottomCenter;
            this.button订单管理.UseVisualStyleBackColor = true;
            this.button订单管理.Click += new System.EventHandler(this.button7_Click);
            // 
            // button销售管理
            // 
            this.button销售管理.Cursor = System.Windows.Forms.Cursors.Hand;
            this.button销售管理.Font = new System.Drawing.Font("黑体", 16F);
            this.button销售管理.Image = ((System.Drawing.Image)(resources.GetObject("button销售管理.Image")));
            this.button销售管理.Location = new System.Drawing.Point(165, 28);
            this.button销售管理.Name = "button销售管理";
            this.button销售管理.Size = new System.Drawing.Size(146, 150);
            this.button销售管理.TabIndex = 7;
            this.button销售管理.Text = "销售管理";
            this.button销售管理.TextAlign = System.Drawing.ContentAlignment.BottomCenter;
            this.button销售管理.UseVisualStyleBackColor = true;
            this.button销售管理.Click += new System.EventHandler(this.button8_Click);
            // 
            // groupBox1
            // 
            this.groupBox1.Controls.Add(this.button员工管理);
            this.groupBox1.Controls.Add(this.button客户管理);
            this.groupBox1.Font = new System.Drawing.Font("宋体", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.groupBox1.Location = new System.Drawing.Point(335, 39);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Size = new System.Drawing.Size(318, 182);
            this.groupBox1.TabIndex = 10;
            this.groupBox1.TabStop = false;
            this.groupBox1.Text = "客户/员工管理";
            this.groupBox1.Enter += new System.EventHandler(this.groupBox1_Enter);
            // 
            // button员工管理
            // 
            this.button员工管理.Cursor = System.Windows.Forms.Cursors.Hand;
            this.button员工管理.Font = new System.Drawing.Font("黑体", 16F);
            this.button员工管理.Image = ((System.Drawing.Image)(resources.GetObject("button员工管理.Image")));
            this.button员工管理.Location = new System.Drawing.Point(158, 26);
            this.button员工管理.Name = "button员工管理";
            this.button员工管理.Size = new System.Drawing.Size(146, 150);
            this.button员工管理.TabIndex = 5;
            this.button员工管理.Text = "员工管理";
            this.button员工管理.TextAlign = System.Drawing.ContentAlignment.BottomCenter;
            this.button员工管理.UseVisualStyleBackColor = true;
            this.button员工管理.Click += new System.EventHandler(this.button2_Click);
            // 
            // button客户管理
            // 
            this.button客户管理.Cursor = System.Windows.Forms.Cursors.Hand;
            this.button客户管理.Font = new System.Drawing.Font("黑体", 16F);
            this.button客户管理.Image = ((System.Drawing.Image)(resources.GetObject("button客户管理.Image")));
            this.button客户管理.Location = new System.Drawing.Point(6, 25);
            this.button客户管理.Name = "button客户管理";
            this.button客户管理.Size = new System.Drawing.Size(146, 150);
            this.button客户管理.TabIndex = 4;
            this.button客户管理.Text = "客户管理";
            this.button客户管理.TextAlign = System.Drawing.ContentAlignment.BottomCenter;
            this.button客户管理.UseVisualStyleBackColor = true;
            this.button客户管理.Click += new System.EventHandler(this.button1_Click);
            // 
            // button预警统计
            // 
            this.button预警统计.Cursor = System.Windows.Forms.Cursors.Hand;
            this.button预警统计.Font = new System.Drawing.Font("黑体", 16F);
            this.button预警统计.Image = ((System.Drawing.Image)(resources.GetObject("button预警统计.Image")));
            this.button预警统计.Location = new System.Drawing.Point(323, 27);
            this.button预警统计.Name = "button预警统计";
            this.button预警统计.Size = new System.Drawing.Size(146, 150);
            this.button预警统计.TabIndex = 6;
            this.button预警统计.Text = "预警/统计";
            this.button预警统计.TextAlign = System.Drawing.ContentAlignment.BottomCenter;
            this.button预警统计.UseVisualStyleBackColor = true;
            this.button预警统计.Click += new System.EventHandler(this.button11_Click);
            // 
            // menuStrip1
            // 
            this.menuStrip1.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.批处理ToolStripMenuItem,
            this.系统管理ToolStripMenuItem,
            this.关于ToolStripMenuItem});
            this.menuStrip1.Location = new System.Drawing.Point(0, 0);
            this.menuStrip1.Name = "menuStrip1";
            this.menuStrip1.Size = new System.Drawing.Size(667, 25);
            this.menuStrip1.TabIndex = 13;
            this.menuStrip1.Text = "menuStrip1";
            // 
            // 批处理ToolStripMenuItem
            // 
            this.批处理ToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.导入ToolStripMenuItem,
            this.导出ToolStripMenuItem,
            this.toolStripSeparator1,
            this.退出ToolStripMenuItem});
            this.批处理ToolStripMenuItem.Name = "批处理ToolStripMenuItem";
            this.批处理ToolStripMenuItem.Size = new System.Drawing.Size(56, 21);
            this.批处理ToolStripMenuItem.Text = "批处理";
            // 
            // 导入ToolStripMenuItem
            // 
            this.导入ToolStripMenuItem.Name = "导入ToolStripMenuItem";
            this.导入ToolStripMenuItem.Size = new System.Drawing.Size(100, 22);
            this.导入ToolStripMenuItem.Text = "导入";
            this.导入ToolStripMenuItem.Click += new System.EventHandler(this.导入ToolStripMenuItem_Click);
            // 
            // 导出ToolStripMenuItem
            // 
            this.导出ToolStripMenuItem.Name = "导出ToolStripMenuItem";
            this.导出ToolStripMenuItem.Size = new System.Drawing.Size(100, 22);
            this.导出ToolStripMenuItem.Text = "导出";
            // 
            // toolStripSeparator1
            // 
            this.toolStripSeparator1.Name = "toolStripSeparator1";
            this.toolStripSeparator1.Size = new System.Drawing.Size(97, 6);
            // 
            // 退出ToolStripMenuItem
            // 
            this.退出ToolStripMenuItem.Name = "退出ToolStripMenuItem";
            this.退出ToolStripMenuItem.Size = new System.Drawing.Size(100, 22);
            this.退出ToolStripMenuItem.Text = "退出";
            // 
            // 系统管理ToolStripMenuItem
            // 
            this.系统管理ToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.修改密码ToolStripMenuItem,
            this.toolStripSeparator2,
            this.相关设置ToolStripMenuItem,
            this.注销ToolStripMenuItem});
            this.系统管理ToolStripMenuItem.Name = "系统管理ToolStripMenuItem";
            this.系统管理ToolStripMenuItem.Size = new System.Drawing.Size(68, 21);
            this.系统管理ToolStripMenuItem.Text = "系统管理";
            // 
            // 修改密码ToolStripMenuItem
            // 
            this.修改密码ToolStripMenuItem.Name = "修改密码ToolStripMenuItem";
            this.修改密码ToolStripMenuItem.Size = new System.Drawing.Size(148, 22);
            this.修改密码ToolStripMenuItem.Text = "修改密码";
            this.修改密码ToolStripMenuItem.Click += new System.EventHandler(this.修改密码ToolStripMenuItem_Click);
            // 
            // toolStripSeparator2
            // 
            this.toolStripSeparator2.Name = "toolStripSeparator2";
            this.toolStripSeparator2.Size = new System.Drawing.Size(145, 6);
            // 
            // 相关设置ToolStripMenuItem
            // 
            this.相关设置ToolStripMenuItem.Name = "相关设置ToolStripMenuItem";
            this.相关设置ToolStripMenuItem.Size = new System.Drawing.Size(148, 22);
            this.相关设置ToolStripMenuItem.Text = "其他相关设置";
            this.相关设置ToolStripMenuItem.Click += new System.EventHandler(this.相关设置ToolStripMenuItem_Click);
            // 
            // 注销ToolStripMenuItem
            // 
            this.注销ToolStripMenuItem.Name = "注销ToolStripMenuItem";
            this.注销ToolStripMenuItem.Size = new System.Drawing.Size(148, 22);
            this.注销ToolStripMenuItem.Text = "注销";
            this.注销ToolStripMenuItem.Click += new System.EventHandler(this.注销ToolStripMenuItem_Click);
            // 
            // 关于ToolStripMenuItem
            // 
            this.关于ToolStripMenuItem.Name = "关于ToolStripMenuItem";
            this.关于ToolStripMenuItem.Size = new System.Drawing.Size(44, 21);
            this.关于ToolStripMenuItem.Text = "关于";
            this.关于ToolStripMenuItem.Click += new System.EventHandler(this.关于ToolStripMenuItem_Click);
            // 
            // groupBox2
            // 
            this.groupBox2.Controls.Add(this.button预警统计);
            this.groupBox2.Controls.Add(this.button审核);
            this.groupBox2.Controls.Add(this.button销售管理);
            this.groupBox2.Location = new System.Drawing.Point(18, 420);
            this.groupBox2.Name = "groupBox2";
            this.groupBox2.Size = new System.Drawing.Size(635, 183);
            this.groupBox2.TabIndex = 14;
            this.groupBox2.TabStop = false;
            this.groupBox2.Text = "财务";
            // 
            // button审核
            // 
            this.button审核.Cursor = System.Windows.Forms.Cursors.Hand;
            this.button审核.Font = new System.Drawing.Font("黑体", 16F);
            this.button审核.Image = ((System.Drawing.Image)(resources.GetObject("button审核.Image")));
            this.button审核.Location = new System.Drawing.Point(14, 27);
            this.button审核.Name = "button审核";
            this.button审核.Size = new System.Drawing.Size(146, 150);
            this.button审核.TabIndex = 13;
            this.button审核.Text = "审核";
            this.button审核.TextAlign = System.Drawing.ContentAlignment.BottomCenter;
            this.button审核.UseVisualStyleBackColor = true;
            this.button审核.Click += new System.EventHandler(this.button1_Click_1);
            // 
            // Main
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(10F, 19F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(667, 641);
            this.Controls.Add(this.groupBox2);
            this.Controls.Add(this.groupBox5);
            this.Controls.Add(this.groupBox3);
            this.Controls.Add(this.groupBox1);
            this.Controls.Add(this.statusStrip1);
            this.Controls.Add(this.menuStrip1);
            this.Font = new System.Drawing.Font("宋体", 14F);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedDialog;
            this.MainMenuStrip = this.menuStrip1;
            this.Margin = new System.Windows.Forms.Padding(5);
            this.Name = "Main";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "乔泰电子生产销售管理系统";
            this.Load += new System.EventHandler(this.Main_Load);
            this.statusStrip1.ResumeLayout(false);
            this.statusStrip1.PerformLayout();
            this.groupBox5.ResumeLayout(false);
            this.groupBox3.ResumeLayout(false);
            this.groupBox1.ResumeLayout(false);
            this.menuStrip1.ResumeLayout(false);
            this.menuStrip1.PerformLayout();
            this.groupBox2.ResumeLayout(false);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.StatusStrip statusStrip1;
        private System.Windows.Forms.GroupBox groupBox5;
        private System.Windows.Forms.Button button产品管理;
        private System.Windows.Forms.Button button原料;
        private System.Windows.Forms.GroupBox groupBox3;
        private System.Windows.Forms.Button button生产管理;
        private System.Windows.Forms.Button button订单管理;
        private System.Windows.Forms.Button button销售管理;
        private System.Windows.Forms.GroupBox groupBox1;
        private System.Windows.Forms.Button button预警统计;
        private System.Windows.Forms.Button button员工管理;
        private System.Windows.Forms.Button button客户管理;
        private System.Windows.Forms.MenuStrip menuStrip1;
        private System.Windows.Forms.ToolStripMenuItem 批处理ToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem 导入ToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem 导出ToolStripMenuItem;
        private System.Windows.Forms.ToolStripSeparator toolStripSeparator1;
        private System.Windows.Forms.ToolStripMenuItem 退出ToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem 系统管理ToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem 相关设置ToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem 关于ToolStripMenuItem;
        private System.Windows.Forms.ToolStripStatusLabel toolStripStatusLabel1;
        private System.Windows.Forms.ToolStripStatusLabel toolStripStatusLabel2;
        private System.Windows.Forms.ToolStripStatusLabel toolStripStatusLabel3;
        private System.Windows.Forms.ToolStripStatusLabel toolStripStatusLabel4;
        private System.Windows.Forms.Button button新增订单;
        private System.Windows.Forms.Button button产品;
        private System.Windows.Forms.ToolStripMenuItem 修改密码ToolStripMenuItem;
        private System.Windows.Forms.ToolStripSeparator toolStripSeparator2;
        private System.Windows.Forms.ToolStripMenuItem 注销ToolStripMenuItem;
        private System.Windows.Forms.GroupBox groupBox2;
        private System.Windows.Forms.Button button审核;
    }
}

