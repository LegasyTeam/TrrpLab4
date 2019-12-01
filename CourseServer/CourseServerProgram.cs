using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Net;
using System.Net.Sockets;

namespace CourseServer
{
    class CourseServerProgram
    {
        static void Main(string[] args)
        {
            CourseServer serv = new CourseServer();
            serv.Start();
            Console.Read();
        }
    }
}
