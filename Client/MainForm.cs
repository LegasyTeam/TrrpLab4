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
    public partial class MainForm : Form
    {
        private string login { get; set; }
        private string token { get; set; }
        private int usdRub;
        private int eurRub;
        public int UsdRub
        {
            get { return usdRub; }
            set
            {
                usdRub = value;
                labelUsdVal.Text = value.ToString().Substring(0, value.ToString().Length - 2) + "," + value.ToString().Substring(value.ToString().Length - 2, 2);
            }
        }
        public int EurRub
        {
            get { return eurRub; }
            set
            {
                eurRub = value;
                labelEurVal.Text = value.ToString().Substring(0, value.ToString().Length - 2) + "," + value.ToString().Substring(value.ToString().Length - 2, 2);
            }
        }
        private int rubWallet;
        private int usdWallet;
        private int eurWallet;
        public int RubWallet
        {
            get { return rubWallet; }
            set
            {
                rubWallet = value;
                if (value.ToString().Length > 2)
                    labelWalRubValue.Text = value.ToString().Substring(0, value.ToString().Length - 2) + "," + value.ToString().Substring(value.ToString().Length - 2, 2);
                else
                    labelWalRubValue.Text = "0," + (value.ToString().Length == 2 ? value.ToString() : "0" + value.ToString());
            }
        }
        public int UsdWallet
        {
            get { return usdWallet; }
            set
            {
                usdWallet = value;
                if (value.ToString().Length > 2)
                    labelWalUsdValue.Text = value.ToString().Substring(0, value.ToString().Length - 2) + "," + value.ToString().Substring(value.ToString().Length - 2, 2);
                else
                    labelWalUsdValue.Text = "0," + (value.ToString().Length == 2 ? value.ToString() : "0" + value.ToString());
            }
        }
        public int EurWallet
        {
            get { return eurWallet; }
            set
            {
                eurWallet = value;
                if (value.ToString().Length > 2)
                    labelWalEurValue.Text = value.ToString().Substring(0, value.ToString().Length - 2) + "," + value.ToString().Substring(value.ToString().Length - 2, 2);
                else
                    labelWalEurValue.Text = "0," + (value.ToString().Length == 2 ? value.ToString() : "0" + value.ToString());
            }
        }
        public MainForm(string _token, string _login)
        {
            InitializeComponent();
            this.login = _login;
            this.token = _token;
            InitializeCourses();
            InitializeWallet();
        }

        private void InitializeCourses()
        {
            UsdRub = 3550;
            EurRub = 4325;
        }

        private void InitializeWallet()
        {
            //имитация получения с сервера
            int RubValue = 2000000;
            int UsdValue = 0;
            int EurValue = 0;
            //получение с сервера
            RubWallet = RubValue;
            UsdWallet = UsdValue;
            EurWallet = EurValue;
        }
        private void MainForm_Load(object sender, EventArgs e)
        {
            this.Text = "Программа для обмена валют - " + login;
            cbExchFrom.SelectedIndex = 0;
            cbExchTo.SelectedIndex = 1;
        }

        private void tbExchFrom_KeyPress(object sender, KeyPressEventArgs e)
        {
            char l = e.KeyChar;
            if ((l < '0' || l > '9') && l != '\b')
            {
                e.Handled = true;
            }
        }

        private void tbExchFrom_TextChanged(object sender, EventArgs e)
        {
            int temp;
            int.TryParse(tbExchFrom.Text, out temp);
            if (cbExchFrom.SelectedIndex == 0)
            {
                if (temp > RubWallet / 100)
                    temp = RubWallet / 100;
            }
            else if (cbExchFrom.SelectedIndex == 1)
            {
                if (temp > UsdWallet / 100)
                    temp = UsdWallet;
            }
            else
            {
                if (temp > EurWallet / 100)
                    temp = EurWallet;
            }
            tbExchFrom.Text = temp.ToString();

            if (cbExchFrom.SelectedIndex == 0)
            {
                if (cbExchTo.SelectedIndex == 1)
                {
                    tbExchTo.Text = (temp * 100 / usdRub).ToString();
                }
                else if (cbExchTo.SelectedIndex == 2)
                {
                    tbExchTo.Text = (temp * 100 / eurRub ).ToString();
                }
            }
            else if (cbExchFrom.SelectedIndex == 1)
            {
                if (cbExchTo.SelectedIndex == 0)
                {
                    tbExchTo.Text = (temp * usdRub).ToString();
                    if (tbExchTo.Text.Length > 2)
                        tbExchTo.Text = tbExchTo.Text.Substring(0, tbExchTo.Text.Length - 2) + "," + tbExchTo.Text.Substring(tbExchTo.Text.Length - 2, 2);
                }
                else if (cbExchTo.SelectedIndex == 2)
                {
                    tbExchTo.Text = (temp * usdRub / eurRub).ToString();
                }
            }
            else
            {
                if (cbExchTo.SelectedIndex == 0)
                {
                    tbExchTo.Text = (temp * eurRub).ToString();
                    if (tbExchTo.Text.Length > 2)
                        tbExchTo.Text = tbExchTo.Text.Substring(0, tbExchTo.Text.Length - 2) + "," + tbExchTo.Text.Substring(tbExchTo.Text.Length - 2, 2);
                }
                else if (cbExchTo.SelectedIndex == 1)
                {
                    tbExchTo.Text = (temp * eurRub / usdRub).ToString();
                }
            }
        }

        private void cbExchFrom_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (cbExchFrom.SelectedIndex == cbExchTo.SelectedIndex)
                btnExch.Enabled = false;
            else
                btnExch.Enabled = true;
            tbExchFrom_TextChanged(sender, e);
        }
    }
}
