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
        private int port = 7000; // порт для приема входящих запросов
        private IPEndPoint ipPoint;
        private Thread ListenThread;
        private int LifeTimeToDrop = 10;
        private int CleanUpPeriodMilliseconds=20000;
        private bool listening=true;//когда будет false, диспатчер перестанет слушать сообщения
        private System.Timers.Timer CleanUpTimer;
        private IPAddress getmyip()
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
            IPAddress adr = getmyip();
            ipPoint = new IPEndPoint(adr, port);
            ListenThread = new Thread(Listen);
            CleanUpTimer = new System.Timers.Timer();
            CleanUpTimer.Elapsed += RemoveNotRespondingServers;
            CleanUpTimer.Interval = CleanUpPeriodMilliseconds;
            Console.WriteLine("Dispatcher started: " + ipPoint.ToString());
        }
        public EndPoint getServ()
        {
            if (CourseServers.Count > 0)
                return CourseServers.First().Key;
            return null;
        }
        public void addServ(EndPoint ep)
        {
            if (CourseServers.ContainsKey(ep))
                CourseServers[ep] = DateTime.Now;
            else CourseServers.Add(ep, DateTime.Now);
        }

        private void RemoveNotRespondingServers(object sender, ElapsedEventArgs e)
        {
            foreach (var a in CourseServers)
            {
                if (a.Value.Second > LifeTimeToDrop)
                    CourseServers.Remove(a.Key);//так можно?
            }
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
            if (builder.ToString() == "CourseServer")
            {
                addServ(REP);
                Console.WriteLine(REP.ToString() + " inserted into CourseServerAdded");
                message = "Your ip added into";
            }
            else if (builder.ToString() == "Client")
            {
                //CourseServers.Add(handler.RemoteEndPoint, DateTime.Now);
                Console.WriteLine("NewClient");
                // отправляем ответ
                EndPoint ep = getServ();
                if (ep is null)
                    message = "0";
                else message = ep.ToString();
            }
            else
            {
                Console.WriteLine("Неизвестное подключение");
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
        public void Start()
        {
            ListenThread.Start();

        }
    }
}
