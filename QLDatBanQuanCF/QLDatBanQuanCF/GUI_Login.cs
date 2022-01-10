using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using BUS_SMS;

namespace QLDatBanQuanCF
{
    public partial class GUI_Login : Form
    {
        public GUI_Login()
        {
            InitializeComponent();
        }

        private void btnLogin_Click(object sender, EventArgs e)
        {
            BUS_Login busLogin = new BUS_Login();
            if(busLogin.checkUser(txtUsername.Text, txtPassword.Text) == true)
            {
                //this.Hide();
                GUI_TABLE x = new GUI_TABLE();               
                x.Show();
                //this.Close();
            }
            else
                MessageBox.Show("Tài khoản hoặc mật khẩu không đúng!","Thông báo");
        }

        private void btnLogin_Enter(object sender, EventArgs e)
        {
        }
    }
}
