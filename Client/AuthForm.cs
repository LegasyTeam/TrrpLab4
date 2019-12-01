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
    public partial class AuthForm : Form
    {
        public string RegLogin;
        public AuthForm()
        {
            InitializeComponent();
        }

        private void loginTb_TextChanged(object sender, EventArgs e)
        {
            if (string.IsNullOrWhiteSpace(loginTb.Text) || loginTb.Text.Length < 6 || string.IsNullOrWhiteSpace(passwordTb.Text) || passwordTb.Text.Length < 6)
                loginBtn.Enabled = false;
            else
                loginBtn.Enabled = true;
        }

        private void regBtn_Click(object sender, EventArgs e)
        {
            RegForm regForm = new RegForm();
            regForm.Owner = this;
            regForm.ShowDialog();
            if (!string.IsNullOrWhiteSpace(RegLogin))
            {
                loginTb.Text = RegLogin;
                passwordTb.Text = "";
                RegLogin = "";
            }
        }

        private void loginBtn_Click(object sender, EventArgs e)
        {
            string token = AuthReg.Auth(loginTb.Text, passwordTb.Text);
            if (token != "")
            {
                if (token == "auth_not_succ" || token == "incorrect_login")
                {
                    MessageBox.Show("Неправильный логин или пароль");
                }
                else if (token == "no_server")
                {
                    MessageBox.Show("Сервер недоступен, проверьте соединение");
                }
                else
                {
                    //MessageBox.Show(token);
                    MainForm mainForm = new MainForm(token, loginTb.Text);
                    this.Hide();
                    mainForm.ShowDialog();
                    this.Close();
                }
            }
  
            else
            {
                MessageBox.Show("Ошибка авторизации. Попробуйте войти позже.");
            }
        }
    }
}
