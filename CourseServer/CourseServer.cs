using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Threading;
using System.Net;
using System.Net.Sockets;
using System.IO.Ports;
using System.Timers;
using System.ServiceModel;
using System.Data.SQLite;
using System.Data;

using Newtonsoft.Json;
using MySql.Data.MySqlClient;

namespace CourseServer
{
    class CourseServer : ICourseServer
    {
        // адрес и порт сервера, к которому будем подключаться
        private int dispatcherport = 7000; // порт диспатчера
        private string DispatcherAddress = "26.29.23.251";//адрес диспатчера
        private System.Timers.Timer ConnectToDispatcherTimer;//отсчитывает периоды в которые происходит связь с диспетчером
        private int DispatcherCallInterval = 5000;
        IPAddress myip;
        int myport;
        private IPEndPoint ipPoint;
        private Thread ListenThread;
        private string host = "remotemysql.com";
        public DailyInfo di;

        public CourseServer()
        {
            di = new DailyInfo();
            ConnectToDispatcherTimer = new System.Timers.Timer();
            ConnectToDispatcherTimer.Elapsed += ThreadHelloDispatcher;
            ConnectToDispatcherTimer.Interval = DispatcherCallInterval;
            myip = getmyip();
            myport = getmyport();
            //ipPoint = new IPEndPoint(getmyip(), getmyport());
        }
        private void ThreadHelloDispatcher(object sender, ElapsedEventArgs e)
        {
            //Console.WriteLine("Thread Hello Dispatcher started!");
            new Thread(HelloDispatcher).Start();
        }
        public void Start()
        {
            ClientServerInit();
            HelloDispatcher();
            ConnectToDispatcherTimer.Start();
        }
        private void ClientServerInit()
        {
            //string s = @"http://localhost:6789/ICourseServer";
            string s = @"http://" + myip.ToString() + @":" + myport + @"/ICourseServer"; 
            Console.WriteLine(s+ " started!");
            Uri address = new Uri(s);
            BasicHttpBinding binding = new BasicHttpBinding();
            Type contract = typeof(ICourseServer);
            ServiceHost host = new ServiceHost(typeof(CourseServer));
            host.AddServiceEndpoint(contract, binding, address);
            host.Open();
            //Console.WriteLine("Введите что-либо, чтобы закрыть хост");
            //Console.ReadLine();
            //host.Close();
        }
        private void HelloDispatcher()
        {
            //Console.WriteLine("Hello Dispatcher started!");
            try
            {
                IPEndPoint ipPoint = new IPEndPoint(IPAddress.Parse(DispatcherAddress), dispatcherport);

                Socket socket = new Socket(AddressFamily.InterNetwork, SocketType.Stream, ProtocolType.Tcp);
                // подключаемся к удаленному хосту
                socket.Connect(ipPoint);
                //Console.Write("Введите сообщение:");
                //string message = Console.ReadLine();
                string message = "CourseServer"+myport;
                byte[] data = Encoding.Unicode.GetBytes(message);
                socket.Send(data);

                // получаем ответ
                data = new byte[256]; // буфер для ответа
                StringBuilder builder = new StringBuilder();
                int bytes = 0; // количество полученных байт
               

                do
                {
                    bytes = socket.Receive(data, data.Length, 0);
                    builder.Append(Encoding.Unicode.GetString(data, 0, bytes));
                }
                while (socket.Available > 0);
                
                
                Console.WriteLine("ответ диспетчера: " + builder.ToString() );

                // закрываем сокет
                socket.Shutdown(SocketShutdown.Both);
                socket.Close();
            }
           
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
            }
        }

        private static string GetAddress()
        {
            return "http://test";
            //получаем у диспетчера адрес сервера авторизации
        }

        private SQLiteConnection createDB()
        {
            SQLiteConnection.CreateFile("currentCourse.db");
            var db = new SQLiteConnection("Data Source=currentCourse.db");
            db.Open();

            SQLiteCommand cmd = new SQLiteCommand(@"CREATE TABLE [Valute](
                                                    [id] INT PRIMARY KEY, 
                                                    [name] VARCHAR, 
                                                    [code] VARCHAR);
                                                    CREATE TABLE [Curses](
                                                    [id] INT PRIMARY KEY, 
                                                    [id_valute] INT, 
                                                    [date] DATETIME, 
                                                    [curse] DOUBLE);", db);
            cmd.ExecuteNonQuery();
            var data = di.EnumValutes(true).Tables[0];
            for (int i = 0; i < data.Rows.Count; i++)
            {
                var row = data.Rows[i];
                if (((string)row.ItemArray.GetValue(0)).Equals("R01235") || ((string)row.ItemArray.GetValue(0)).Equals("R01239"))
                {
                    cmd.CommandText = "Insert into Valute (name, code) (@name, @code)";
                    cmd.Parameters.Add(new SQLiteParameter("@name", (string)row.ItemArray.GetValue(1)));
                    cmd.Parameters.Add(new SQLiteParameter("@code", (string)row.ItemArray.GetValue(0)));
                    cmd.ExecuteNonQuery();
                }
            }
            return db;
        }
        
        private double GetCurrCurse(int cod)
        {
            var db = new SQLiteConnection("Data Source=currentCourse.db");
            db.Open();
            var  cmd = new SQLiteCommand("Select curse From Curses Where id_valute = '" + cod + 1 + "' AND date = (Select MAx(date) From Curses)", db);
            var d = cmd.ExecuteScalar();
            db.Clone();
            return (double)d;
        }

        private void SetCbrCurrentCurse(DateTime DateFrom, DateTime DateTo, string Code)
        {
            var data = di.GetCursDynamic(DateFrom, DateTo, Code).Tables[0];
            var db = new SQLiteConnection("Data Source=currentCourse.db");
            db.Open();
            for (int i = 0; i < data.Rows.Count; i++)
            {
                var row = data.Rows[i];
                SQLiteCommand cmd = new SQLiteCommand("Insert into Curses (id_valute, date, curse) Values ((Select rowid From Valute Where code = @code), @date, @curse)", db);
                cmd.Parameters.Add(new SQLiteParameter("@code", Code));
                cmd.Parameters.Add(new SQLiteParameter("@date", (DateTime)row.ItemArray.GetValue(0)));
                cmd.Parameters.Add(new SQLiteParameter("@curse", (decimal)row.ItemArray.GetValue(3)));
                cmd.ExecuteNonQuery();
            }
            db.Close();
        }

        private void check(string cod)
        {
            var db = new SQLiteConnection("Data Source=currentCourse.db");
            db.Open();
            
            var cmd = new SQLiteCommand("Select Max(date) as lastDate From Curses JOin Valute On Curses.id_valute = Valute.rowid WHERE Valute.code = '" + cod + "'", db);
            bool prov = true;
            bool prov1 = false;
            DateTime from = new DateTime();
            DateTime to = new DateTime();
            using (var reader = cmd.ExecuteReader())
            {
                if (reader.Read())
                {
                    var s = reader["lastDate"];
                    if (s is string)
                    {
                        from = DateTime.Parse((string)reader["lastDate"]).Date;
                        to = DateTime.Now.AddDays(-1).Date;
                        if (from < to)
                        {
                            prov1 = true;
                        }
                    }
                    else
                    {
                        prov = false;
                    }

                }
                else
                {
                    prov = false;
                }
            }
            db.Close();
            if (!prov)
            {
                SetCbrCurrentCurse(new DateTime(2019, 1, 1).Date, DateTime.Now.Date, cod);
            }
            else
            {
                if (prov1)
                {
                    SetCbrCurrentCurse(from, to, cod);
                }
            }
        }

        private void CheckCbrUpd()
        {
            SQLiteConnection db;
            try
            {
                db = new SQLiteConnection("Data Source=currentCourse.db");
            }
            catch {
                db = createDB();
            }
           
            db.Open();
            SQLiteCommand cmd = new SQLiteCommand("Select code From Valute", db);
            var list = new List<string>(); 
            using (var reader = cmd.ExecuteReader())
            {
                while (reader.Read())
                {
                    list.Add((string)(reader.GetValue(0)));
                    
                }
            }
            db.Close();
            foreach (var element in list)
            {
                check(element);
            }
        }



        public double GetCurrentCourse(bool dolar)//допилить
        {
            CheckCbrUpd();
            switch (dolar)
                {
                    case true:
                        return GetCurrCurse(0);
                    case false:
                        return GetCurrCurse(1);
            }

            return 1;
        }
        private IPAddress getmyip()//ищем IPv4
        {
            foreach (IPAddress a in Dns.GetHostAddresses(Dns.GetHostName()))
            {
                if (a.AddressFamily == AddressFamily.InterNetwork)
                {
                    return a;
                }
            }
            return null;
        }
        private int getmyport()
        {
            return 9998;
            //return int.Parse(SerialPort.GetPortNames().ElementAt(0));
        }

        // JsonConvert.DeserializeObject<DataTable>
        public string GetCurrenttCourse(DateTime from, DateTime to)
        {
            var dt = new DataTable();
            CheckCbrUpd();
            var db = new SQLiteConnection("Data Source=currentCourse.db");
            db.Open();
            SQLiteCommand cmd = new SQLiteCommand("Select Valute.name as name, Curses.date as date, Curses.curse as curse from Curses Join Valute On Valute.id = Curses.id_valute  Where date >= @dateFrom AND date <= @dateTo", db);
            cmd.Parameters.Add(new SQLiteParameter("@dateFrom", from));
            cmd.Parameters.Add(new SQLiteParameter("@dateTo", to));
            dt.Columns.Add("Название");
            dt.Columns.Add("Дата");
            dt.Columns.Add("Курс");
            using (var reader = cmd.ExecuteReader())
            {
                while (reader.Read())
                {
                    dt.Rows.Add(new string[] { Convert.ToString(reader["name"]), Convert.ToString(reader["date"]) , Convert.ToString(reader["curse"]) });
                }
            }

            db.Close();

            return JsonConvert.SerializeObject(dt);
        }


        // JsonConvert.DeserializeObject<List<int>>
        public string GetBalance(string token)
        {
            List<int> balance = new List<int>();
            MySqlConnection conn = new MySqlConnection("Server=" + host + ";Database=11ayOeNb9v;port=3306;User Id=11ayOeNb9v;password=0mI6sAI8oz");
            conn.Open();
            var cmd = new MySqlCommand("Select `rub`,`eur`, `usd` From `Users` Where token = '" + token + "'", conn);
           
            using (var reader = cmd.ExecuteReader())
            {
                if (reader.Read())
                {
                    balance.Add((int)reader["rub"]);
                    balance.Add((int)reader["eur"]);
                    balance.Add((int)reader["usd"]);
                }
            }
            conn.Close();
            return JsonConvert.SerializeObject(balance);
        }


        public string BuyValute(string mass)
        {
            //object ??
            CheckCbrUpd();
            string result = "";
            var obj = JsonConvert.DeserializeObject<UserTransaction>(mass);

            double curse = 0;
            string usdOrEur = "eur";
            int userRub = 0, userValute = 0;
            
           
            var list = JsonConvert.DeserializeObject<List<int>>(GetBalance(obj.Token));
            userRub = list[0];
            switch (obj.Dollar)
            {
                case true:
                    curse = GetCurrCurse(0);
                    usdOrEur = "usd";
                    userValute = list[2];
                    break;
                case false:
                    curse = GetCurrCurse(1);
                    userValute = list[1];
                    usdOrEur = "eur";
                    break;
            }
            var countValute = Convert.ToInt32(Math.Round(curse)) * obj.Count;
            if (userRub >= countValute)
            {
                userValute += obj.Count;
                userRub -= countValute;
                MySqlConnection conn = new MySqlConnection("Server=" + host + ";Database=11ayOeNb9v;port=3306;User Id=11ayOeNb9v;password=0mI6sAI8oz");
                conn.Open();
                var cmd = new MySqlCommand("Update `Users` Set `rub` = " + userRub + ", `" + usdOrEur + "` = " + userValute, conn);
                cmd.ExecuteNonQuery();
                conn.Close();
                result = "Транзакция прошла успешно";
            }
            else
            {
                result = "Транзакция не прошла";
            }
            //serialize object
            return result;
            
        }

        public string SellValute(string mass)
        {
            //object ??
            CheckCbrUpd();
            string result = "";
            var obj = JsonConvert.DeserializeObject<UserTransaction>(mass);
            
            double curse = 0;
            string usdOrEur = "eur";
            int userRub = 0, userValute = 0;
            var list = JsonConvert.DeserializeObject<List<int>>(GetBalance(obj.Token));
            userRub = list[0];
            switch (obj.Dollar)
            {
                case true:
                    curse = GetCurrCurse(0);
                    usdOrEur = "usd";
                    userValute = list[2];
                    break;
                case false:
                    curse = GetCurrCurse(1);
                    userValute = list[1];
                    usdOrEur = "eur";
                    break;
            }
            
            if (userValute >= obj.Count)
            {
                userValute -= obj.Count;
                userRub += Convert.ToInt32(Math.Round(curse)) * obj.Count;
                MySqlConnection conn = new MySqlConnection("Server=" + host + ";Database=11ayOeNb9v;port=3306;User Id=11ayOeNb9v;password=0mI6sAI8oz");
                conn.Open();
                var cmd = new MySqlCommand("Update `Users` Set `rub` = " + userRub + ", `" + usdOrEur + "` = " + userValute, conn);
                cmd.ExecuteNonQuery();
                conn.Close();
                result = "Транзакция прошла успешно";
            }
            else
            {
                result = "Транзакция не прошла";
            }
            
            //serialize object
            return result;
        }
    }
}
