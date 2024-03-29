﻿using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Net;
using System.Net.Sockets;
using System.IO.Ports;
using System.Timers;
using System.Configuration;
using System.ServiceModel;
using Newtonsoft.Json;
namespace WindowsFormsApp1
{
    public partial class MainForm : Form
    {
        private string Address { get; set; }
        private string login { get; set; }
        private string token { get; set; }
        private int usdRub;
        private int eurRub;
        //private System.Timers.Timer reconnecttimer;
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
            rbUSD.Tag = 1;
            rbEUR.Tag = 2;
            FullConnect();
            GetGraphic();
            cbBuy.SelectedIndex = 0;
            cbSell.SelectedIndex = 0;
            //MessageBox.Show(Address);
        }

        private void FullConnect()
        {
            bool fail=true;
            while (fail)
            {
                if (InitializeAddress())
                    if (InitializeCourses())
                        if (InitializeWallet())
                            fail = false;
                        else MsgBox.Show("Сервер недоступен!");
                    else MsgBox.Show("Сервер недоступен!");
                else MsgBox.Show("Невозможно получить сервер от диспетчера!");
            }
        }



        private bool InitializeCourses()
        {
            try
            {
                Uri address = new Uri(@"http://" + Address + @"/ICourseServer");
                BasicHttpBinding binding = new BasicHttpBinding();
                EndpointAddress ep = new EndpointAddress(address);
                ChannelFactory<ICourseServer> factory = new ChannelFactory<ICourseServer>(binding, ep);
                ICourseServer cs = factory.CreateChannel();
                var userTran = new UserTransaction() { Dollar = true, Count = int.Parse(tbSellValue.Text), Token = token };

                UsdRub = Convert.ToInt32(cs.GetCurrentCourse(true) * 100);
                EurRub = Convert.ToInt32(cs.GetCurrentCourse(false) * 100);
                return true;
            }
            catch
            {
                return false;
            }
        }
        private bool InitializeAddress()
        {
            try
            {
                IPEndPoint ipPoint = new IPEndPoint(IPAddress.Parse(ConfigurationManager.AppSettings["dispatcherAddress"]), int.Parse(ConfigurationManager.AppSettings["dispatcherPort"]));
                Socket socket = new Socket(AddressFamily.InterNetwork, SocketType.Stream, ProtocolType.Tcp);    
                // подключаемся к удаленному хосту
                socket.Connect(ipPoint);
                string message = "Client";
                byte[] data = Encoding.Unicode.GetBytes(message);
                socket.Send(data);    // получаем ответ
                data = new byte[256]; // буфер для ответа
                StringBuilder builder = new StringBuilder();
                int bytes = 0; // количество полученных байт
                do
                {
                    bytes = socket.Receive(data, data.Length, 0);
                    builder.Append(Encoding.Unicode.GetString(data, 0, bytes));
                }
                while (socket.Available > 0);
                Address = builder.ToString();            // закрываем сокет
                socket.Shutdown(SocketShutdown.Both);
                socket.Close();
                if (Address == "0")
                    return false;
                return true;
            }
            catch
            {
                return false;
            }
        }
        private bool InitializeWallet()
        {
            try
            {
                //имитация получения с сервера
                Uri address = new Uri(@"http://" + Address + @"/ICourseServer");
                BasicHttpBinding binding = new BasicHttpBinding();
                EndpointAddress ep = new EndpointAddress(address);
                ChannelFactory<ICourseServer> factory = new ChannelFactory<ICourseServer>(binding, ep);
                ICourseServer cs = factory.CreateChannel();
                var userTran = new UserTransaction() { Dollar = true, Count = int.Parse(tbSellValue.Text), Token = token };
                var list = JsonConvert.DeserializeObject<List<int>>(cs.GetBalance(token));
                int RubValue = list[0];
                int UsdValue = list[2];
                int EurValue = list[1];
                //получение с сервера
                RubWallet = RubValue;
                UsdWallet = UsdValue;
                EurWallet = EurValue;
                return true;
            }
            catch
            {
                return false;
            }
        }
        private void MainForm_Load(object sender, EventArgs e)
        {
            this.Text = "Программа для обмена валют - " + login;
            cbBuy.SelectedIndex = 0;
            cbSell.SelectedIndex = 1;
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

        }

        private void cbExchFrom_SelectedIndexChanged(object sender, EventArgs e)
        {

        }

        private void tbBuyValue_TextChanged(object sender, EventArgs e)
        {
            int temp;
            int.TryParse(tbBuyValue.Text, out temp);
            tbBuyValue.Text = temp.ToString();
            if (cbBuy.SelectedIndex == 0)
            {
                if (temp * UsdRub > RubWallet || temp == 0)
                    btnBuy.Enabled = false;
                else
                    btnBuy.Enabled = true;
            }
            else
            {
                if (temp * EurRub > RubWallet || temp == 0)
                    btnBuy.Enabled = false;
                else
                    btnBuy.Enabled = true;
            }
        }

        private void tbSellValue_TextChanged(object sender, EventArgs e)
        {
            int temp;
            int.TryParse(tbSellValue.Text, out temp);
            tbSellValue.Text = temp.ToString();
            if (cbSell.SelectedIndex == 0)
            {
                if (temp > UsdWallet || temp == 0)
                    btnSell.Enabled = false;
                else
                    btnSell.Enabled = true;
            }
            else
            {
                if (temp > EurWallet || temp == 0)
                    btnSell.Enabled = false;
                else
                    btnSell.Enabled = true;
            }
        }

        private void btnBuy_Click(object sender, EventArgs e)
        {
            try
            {
                Uri address = new Uri(@"http://" + Address + @"/ICourseServer");
                BasicHttpBinding binding = new BasicHttpBinding();
                EndpointAddress ep = new EndpointAddress(address);
                ChannelFactory<ICourseServer> factory = new ChannelFactory<ICourseServer>(binding, ep);
                ICourseServer cs = factory.CreateChannel();
                bool provValute = true;
                if (cbBuy.SelectedIndex == 1)
                    provValute = false;
                var userTran = new UserTransaction() { Dollar = provValute, Count = (int.Parse(tbBuyValue.Text) * 100), Token = token };
                string message = cs.BuyValute(JsonConvert.SerializeObject(userTran));
                if (message.Equals("Транзакция прошла успешно"))
                {
                    if (provValute)
                    {
                        RubWallet -= UsdRub * userTran.Count/100;
                        UsdWallet += userTran.Count;
                    }
                    else
                    {
                        RubWallet -= EurRub * userTran.Count/100;
                        EurWallet += userTran.Count ;
                    }
                }
                MessageBox.Show(message);

            }
             catch (Exception ex) { FullConnect(); }
        }

        private void btnSell_Click(object sender, EventArgs e)
        {
            try
            {
                Uri address = new Uri(@"http://" + Address + @"/ICourseServer");
                BasicHttpBinding binding = new BasicHttpBinding();
                EndpointAddress ep = new EndpointAddress(address);
                ChannelFactory<ICourseServer> factory = new ChannelFactory<ICourseServer>(binding, ep);
                ICourseServer cs = factory.CreateChannel();
                bool provValute = true;
                if (cbSell.SelectedIndex == 1)
                    provValute = false;
                var userTran = new UserTransaction() { Dollar = provValute, Count = (int.Parse(tbSellValue.Text) * 100), Token = token };
                string message = cs.SellValute(JsonConvert.SerializeObject(userTran));
                if (message.Equals("Транзакция прошла успешно"))
                {
                    if (provValute)
                    {
                        RubWallet += UsdRub * userTran.Count/100;
                        UsdWallet -= userTran.Count;
                    }
                    else
                    {
                        RubWallet += EurRub * userTran.Count/100;
                        EurWallet -= userTran.Count;
                    }
                }
                MessageBox.Show(message);
            }
            catch (Exception ex)
            {
                FullConnect();
            }
        }

        private void cbBuy_SelectedIndexChanged(object sender, EventArgs e)
        {
            tbBuyValue_TextChanged(sender, e);
        }
        private RadioButton rbchecked(GroupBox gb)
        {
            foreach (RadioButton r in gb.Controls)
                if (r.Checked)
                    return r;
            return null;
        }

        private void GetGraphic()
        {
            RadioButton rb = rbchecked(groupBox1);
            int valuteindex = (int)rbchecked(groupBox2).Tag;
            DateTime From = new DateTime(), To = new DateTime();
            switch (rb.Name)
            {
                case "rBWeek":
                    From = DateTime.Now.AddDays(-8);
                    To = DateTime.Now.AddDays(-1);

                    break;
                case "rBMonth":

                    From = DateTime.Now.AddDays(-32);
                    To = DateTime.Now.AddDays(-1);
                    break;
                case "rBYear":
                    From = DateTime.Now.AddDays(-365);
                    if (From < new DateTime(2019, 1, 1))
                    {
                        From = new DateTime(2019, 1, 1);
                    }
                    To = DateTime.Now.AddDays(-1);
                    break;
            }
            //MessageBox.Show(Address);
            Uri address = new Uri(@"http://" + Address + @"/ICourseServer");
            BasicHttpBinding binding = new BasicHttpBinding();
            EndpointAddress ep = new EndpointAddress(address);
            ChannelFactory<ICourseServer> factory = new ChannelFactory<ICourseServer>(binding, ep);
            ICourseServer cs = factory.CreateChannel();
            var res = JsonConvert.DeserializeObject<DataTable>(cs.GetCurrenttCourse(From, To));

            chartChanges.Series["USD"].Points.Clear();
            chartChanges.Series["EUR"].Points.Clear();
            double min = 999;
            double max = 0;
            for (int i = 0; i < res.Rows.Count; i++)
            {
                var row = res.Rows[i];
                if (row.ItemArray.GetValue(0).Equals("1") && valuteindex == 1)
                {
                    var date  = DateTime.Parse((string)row.ItemArray.GetValue(1)).ToString("MM-dd");
                    var curse = Math.Round(double.Parse((string)row.ItemArray.GetValue(2)),2);
                    if (curse < min)
                        min = curse;
                    else if (curse > max)
                        max = curse;
                    chartChanges.Series["USD"].Points.AddXY(date, curse);
                }
                if (row.ItemArray.GetValue(0).Equals("2") && valuteindex==2 )
                {
                    var date = DateTime.Parse((string)row.ItemArray.GetValue(1)).ToString("MM-dd");
                    var curse = Math.Round(double.Parse((string)row.ItemArray.GetValue(2)), 2);
                    if (curse < min)
                        min = curse;
                    else if (curse > max)
                        max = curse;
                    chartChanges.Series["EUR"].Points.AddXY(date, curse);
                }
            }
            chartChanges.ChartAreas[0].AxisY.Minimum = min-1;
            chartChanges.ChartAreas[0].AxisY.Maximum = max+1;
        }

        private void rBWeek_CheckedChanged(object sender, EventArgs e)
        {
            //var rb = (RadioButton)sender;
            try
            {
                GetGraphic();
            }
            catch
            {
                FullConnect();
            }

        }
    }
}
