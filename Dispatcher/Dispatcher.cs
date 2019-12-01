using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Net;
using System.Net.Sockets;
using System.Threading;
using System.Timers;

namespace Dispatcher
{
    class Dispatcher
    {
        private  Dictionary<EndPoint, DateTime> CourseServers = new Dictionary<EndPoint, DateTime>();
        private IPEndPoint ipPoint;
        private Thread ListenThread;
        private int currentservnumber = 0;//индекс сервера из списка серверов, ip которого диспетчер вернет следующему клиенту
        private bool listening=true;//когда будет false, диспатчер перестанет слушать сообщения
        private System.Timers.Timer CleanUpTimer;
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
        public Dispatcher()
        {
            ipPoint = new IPEndPoint(getmyip(), Properties.Settings.Default.port);
            ListenThread = new Thread(Listen);
            CleanUpTimer = new System.Timers.Timer();
            CleanUpTimer.Elapsed += RemoveNotRespondingServers;
            CleanUpTimer.Interval = Properties.Settings.Default.CleanUpPeriodMilliseconds;
            Console.WriteLine("Dispatcher started: " + ipPoint.ToString());
        }
        public EndPoint getServ()
        {
            if (currentservnumber == int.MaxValue)
                currentservnumber = 0;//на случай переполнения
            if (CourseServers.Count > 0)
                return CourseServers.ElementAt(currentservnumber++ % CourseServers.Count).Key;
            else return null;
        }
        public string addServ(IPEndPoint ep)
        {
            if (CourseServers.ContainsKey(ep))
            {
                CourseServers[ep] = DateTime.Now;
                return "updated";
            }
            else
            {
                CourseServers.Add(ep, DateTime.Now);
                return "added into server list";
            }
        }

        private void RemoveNotRespondingServers(object sender, ElapsedEventArgs e)
        {
            List<EndPoint> eplist = new List<EndPoint>();
            foreach (var a in CourseServers)
            {
                if ((DateTime.Now-a.Value).TotalSeconds > Properties.Settings.Default.LifeTimeToDrop)
                {
                    eplist.Add(a.Key);
                    Console.WriteLine(a.Key.ToString()+ " time out "+ (DateTime.Now - a.Value).Seconds);
                }
            }
            foreach (EndPoint ep in eplist)
                CourseServers.Remove(ep);
        }

        private void AcceptConnection(Object ohandler)
        {
            Socket handler=(Socket)ohandler;//может исправить?
            // получаем сообщение
            StringBuilder builder = new StringBuilder();
            int bytes = 0; // количество полученных байтов
            byte[] data = new byte[256]; // буфер для получаемых данных
            do
            {
                bytes = handler.Receive(data);
                //Console.WriteLine(data[0]);
                builder.Append(Encoding.Unicode.GetString(data, 0, bytes));
            }
            while (handler.Available > 0);
            EndPoint REP = handler.RemoteEndPoint;
            Console.WriteLine("(" + DateTime.Now.ToShortTimeString() + ")(" + REP.ToString() + ")" + ": " + builder.ToString());
            string message;
            if (builder.ToString().StartsWith("CourseServer"))
            {
                IPEndPoint IEP=null;
                if (getIEP(REP, builder.ToString(), ref IEP))
                    message = addServ(IEP);
                else message = "incorrect data";
                //Console.WriteLine(REP.ToString() + " inserted into CourseServerAdded");
            }
            else if (builder.ToString() == "Client")
            {
                //CourseServers.Add(handler.RemoteEndPoint, DateTime.Now);
                //Console.WriteLine("NewClient");
                // отправляем ответ
                EndPoint ep = getServ();
                if (ep is null)
                    message = "0";
                else message = ep.ToString();
            }
            else
            {
                //Console.WriteLine("Неизвестное подключение");
                message = "invalid request";
            }
            data = Encoding.Unicode.GetBytes(message);
            handler.Send(data);

            // закрываем сокет
            handler.Shutdown(SocketShutdown.Both);
            handler.Close();
        }
        private void Listen()
        {
            // создаем сокет
            Socket listenSocket = new Socket(AddressFamily.InterNetwork, SocketType.Stream, ProtocolType.Tcp);
            try
            {
                // связываем сокет с локальной точкой, по которой будем принимать данные
                listenSocket.Bind(ipPoint);

                // начинаем прослушивание
                listenSocket.Listen(10);

                Console.WriteLine("Сервер запущен. Ожидание подключений...");

                while (listening)
                {
                    new Thread(new ParameterizedThreadStart(AcceptConnection)).Start(listenSocket.Accept());            
                }
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
            }
        }

        private bool getIEP(EndPoint ep,string message, ref IPEndPoint IEP)
        {
            try
            {
                IEP=new IPEndPoint(IPAddress.Parse(ep.ToString().Split(':')[0]), int.Parse(message.Remove(0, 12)));
                return true; 
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
                return false;
            }
        }
        public void Start()
        {
            ListenThread.Start();
            CleanUpTimer.Start();
        }
    }
}
