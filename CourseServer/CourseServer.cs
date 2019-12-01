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
        SQLiteConnection db;
        private IPEndPoint ipPoint;
        private Thread ListenThread;
        
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

        private void SetCbrCurrentCurse(DateTime DateFrom, DateTime DateTo, string Code)
        {
            var data = di.GetCursDynamic(DateFrom, DateTo, Code).Tables[0];
            db = new SQLiteConnection("Data Source=currentCourse.db");
            db.Open();
            for (int i = 0; i < data.Rows.Count; i++)
            {
                var row = data.Rows[i];
                SQLiteCommand cmd = new SQLiteCommand("Insert into Curses (id_valute, date, curse) Values ((Select id From Valute Where code = @code), @date, @curse)", db);
                cmd.Parameters.Add(new SQLiteParameter("@code", Code));
                cmd.Parameters.Add(new SQLiteParameter("@date", (DateTime)row.ItemArray.GetValue(0)));
                cmd.Parameters.Add(new SQLiteParameter("@curse", (decimal)row.ItemArray.GetValue(3)));
                cmd.ExecuteNonQuery();
            }
            db.Close();
        }

        private double CheckCbrUpd(int cod)
        {
            db = new SQLiteConnection("Data Source=currentCourse.db");
            db.Open();

            SQLiteCommand cmd = new SQLiteCommand("Select code From Valute Where id = '"+ cod+1+ "'", db);
            var res = cmd.ExecuteScalar();
            string valCode = "R01235";
            if (res != null && res is string)
            {
                valCode = (string)res;
            }
             cmd = new SQLiteCommand("Select Max(date) as lastDate From Curses", db);
            bool prov = true;
            using (var reader = cmd.ExecuteReader())
            {
                if (reader.Read())
                {
                    var s =  reader["lastDate"];
                    if (s is string)
                    {
                        var from = DateTime.Parse((string)reader["lastDate"]).Date;
                        var to = DateTime.Now.AddDays(-1).Date;
                        if (from < to)
                        {
                            SetCbrCurrentCurse(from, to, valCode);
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
            if (!prov)
            {
                SetCbrCurrentCurse(new DateTime(2019, 1,1).Date, DateTime.Now.Date, valCode);
            }

            cmd = new SQLiteCommand("Select curse From Curses Where id_valute = '" + cod + 1 + "' AND date = (Select MAx(date) From Curses)", db);
            var d = cmd.ExecuteScalar();


            db.Close();
            return (double)d;
        }



        public int GetCurrentCourse(int dolar)//допилить
        {
            return Convert.ToInt32(CheckCbrUpd(0));
            switch (dolar)
                {
                    case 0:
                        break;
                    case 1:
                        break;

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

        public string GetCurrenttCourse(DateTime from, DateTime to)
        {
            var dt = new DataTable();
            CheckCbrUpd(0);
            db = new SQLiteConnection("Data Source=currentCourse.db");
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
    }
}
