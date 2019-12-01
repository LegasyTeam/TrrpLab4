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

namespace CourseServer
{
    class CourseServer : ICourseServer
    {
        // адрес и порт сервера, к которому будем подключаться
        private int dispatcherport = 7000; // порт диспатчера
        private string DispatcherAddress = "192.168.100.6";//адрес диспатчера
        private System.Timers.Timer ConnectToDispatcherTimer;//отсчитывает периоды в которые происходит связь с диспетчером
        private int DispatcherCallInterval = 5000;
        IPAddress myip;
        int myport;
        private IPEndPoint ipPoint;
        private Thread ListenThread;
        public CourseServer()
        {
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
                Console.WriteLine("ответ диспетчера: " + builder.ToString());

                // закрываем сокет
                socket.Shutdown(SocketShutdown.Both);
                socket.Close();
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
            }
        }
        public int GetCurrentCourse()//допилить
        {
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
    }
}
