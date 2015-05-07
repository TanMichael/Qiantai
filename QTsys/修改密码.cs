using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using QTsys.Common;
using QTsys.Manager;
using QTsys.DataObjects;

namespace QTsys
{
    public partial class 修改密码 : Form
    {
        private string ID;
        private string Type;
     //   private UserManager userMgr;

        public 修改密码(string 账户名, string 账户类型)
        {
            InitializeComponent();
            //userMgr = new UserManager();
            ID = 账户名;
            Type = 账户类型;
        }

        private void 修改密码_Load(object sender, EventArgs e)
        {
            text账户名.Text = ID;
            text账户类型.Text = Type;
        }

        private void button1_Click(object sender, EventArgs e)
        {
            if (text新密码.Text != text确定新密码.Text)
            { MessageBox.Show("新密码前后输入不一致！"); }
            else
            {
                if (Utils.GetCurrentPWD().ToString() == Utils.GetMD5String(text原密码.Text))
                {
                    //修改密码
                    Utils.SetLogonToken(text账户名.Text, text账户类型.Text, Utils.GetMD5String(text新密码.Text));
                    UserManager userMgr = new UserManager();
                    if (userMgr.AltUserPwd(text账户名.Text, Utils.GetMD5String(text新密码.Text)))
                    {
                        MessageBox.Show("修改密码成功！");
                        this.Close();
                    }
                    else
                        MessageBox.Show("密码修改失败！");
                }
                else
                    MessageBox.Show("密码修改失败！");
            }
        }

        private void button2_Click(object sender, EventArgs e)
        {
            this.Close();
        }
    }
}
