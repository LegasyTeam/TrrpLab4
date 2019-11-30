using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Threading;

namespace Dispatcher
{
    class DispatcherProgram
    {
        

        static void Main(string[] args)
        {
            // получаем адреса для запуска сокета
            //IPEndPoint ipPoint = new IPEndPoint(IPAddress.Parse("127.0.0.1"), port); 
            //IPEndPoint ipPoint = new IPEndPoint(IPAddress.Parse("192.168.0.0"), port);
            Dispatcher dispatcher = new Dispatcher();
            dispatcher.Start();
           
        }
    }
}
