using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Net;
using System.IO;


namespace useless
{
    class Program
    {
        static string GetResponseSoap(string _url, string _method, string _soapEnvelope)
        {

            WebRequest request = HttpWebRequest.Create(_url);
            request.Method = _method;
            request.ContentType = "application/soap+xml; charset=utf-8";
            request.ContentLength = _soapEnvelope.Length;
            request.Headers.Add("SOAPAction", _url + @"/" + _method);
            StreamWriter sw = new StreamWriter(request.GetRequestStream());
            sw.Write(_soapEnvelope);
            sw.Close();
            WebResponse response = request.GetResponse();
            StreamReader sr = new StreamReader(response.GetResponseStream());
            string result = sr.ReadToEnd();
            return result;
        }
        static void Main(string[] args)
        {
            string apiurl = @"http://www.cbr.ru/DailyInfoWebServ/DailyInfo.asmx";
            //Console.WriteLine(apiurl);
            string _soapEnvelope = File.ReadAllText(@"../../1.xml");
            Console.WriteLine(GetResponseSoap(apiurl, "EnumValutes", _soapEnvelope));
        }
    }
}
