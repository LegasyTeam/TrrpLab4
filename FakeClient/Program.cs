using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.ServiceModel;

namespace FakeClient
{
    class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("введите ip:port, полученный от диспатчера");
            string s = Console.ReadLine();
            Uri address = new Uri(@"http://" + s + @"/ICourseServer");
            BasicHttpBinding binding = new BasicHttpBinding();
            EndpointAddress ep = new EndpointAddress(address);
            ChannelFactory<ICourseServer> factory = new ChannelFactory<ICourseServer>(binding, ep);
            ICourseServer cs = factory.CreateChannel();
            Console.WriteLine(cs.GetCurrenttCourse(DateTime.Now.AddDays(-3).Date, DateTime.Now.AddDays(-1).Date));
        }
    }
}
