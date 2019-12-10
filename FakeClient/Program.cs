using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.ServiceModel;
using Newtonsoft.Json;

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
            //Console.WriteLine(cs.GetCurrentCourse(false));
            var userTran = new UserTransaction() { Dollar = true, Count = 10, Token = "c5a7c0d5_144e_11ea_bb7c_08606e6ce1c1" };
            Console.WriteLine(cs.SellValute(JsonConvert.SerializeObject(userTran)));
        }
    }
}
