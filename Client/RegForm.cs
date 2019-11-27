using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace WindowsFormsApp1
{
    public partial class RegForm : Form
    {
        public RegForm()
        {
            InitializeComponent();
        }

        private void regBtn_Click(object sender, EventArgs e)
        {
            string action = AuthReg.Reg(loginTb.Text, passwordTb.Text);
            if (action == "1")
            {
                AuthForm authForm = this.Owner as AuthForm;
                if (authForm != null)
                {
                    authForm.RegLogin = loginTb.Text;
                }
                this.Close();
            }
            else if (action == "")
                MessageBox.Show("Ошибка регистрации");
            else if (action == "login_exists")
                MessageBox.Show("Такой логин уже существует");
        }

        private void loginTb_TextChanged(object sender, EventArgs e)
        {
            
            if (string.IsNullOrWhiteSpace(loginTb.Text) || 
                loginTb.Text.Length < 6 || 
                string.IsNullOrWhiteSpace(passwordTb2.Text) ||
                passwordTb2.Text.Length < 6 ||
                string.IsNullOrWhiteSpace(passwordTb.Text) ||
                passwordTb.Text.Length < 6 ||
                passwordTb.Text != passwordTb2.Text)
                confirmBtn.Enabled = false;
            else
                confirmBtn.Enabled = true;
        }

        private void cancelBtn_Click(object sender, EventArgs e)
        {
            this.Close();
        }
    }
}
