using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Configuration;
using System.Security.Cryptography;
using System.IO;
using System.Net;
using System.Net.NetworkInformation;

namespace WindowsFormsApp1
{
    static class AuthReg
    {
        private static string GetAddress()
        {
            string host = ConfigurationManager.AppSettings["mainAuthHost"];
            try
            {
                WebRequest request = WebRequest.Create(host + "/handle.php");
                request.Method = "GET";
                WebResponse response = request.GetResponse();
                string res = "";
                using (Stream stream = response.GetResponseStream())
                {
                    using (StreamReader reader = new StreamReader(stream))
                    {
                        res = reader.ReadToEnd();
                    }
                }
                response.Close();
                if (res == "0")
                    return host;
            }
            catch { return "host:nohost"; }
            return "host:nohost";   
        }
        private static string CalcHash(string path)
        {
            using (var cp = new SHA1CryptoServiceProvider())
            {
                var enc = Encoding.UTF8;//Получает кодировку для формата UTF-8.
                return BitConverter.ToString(cp.ComputeHash(enc.GetBytes(path))).Replace("-", "");
            }
        }
        public static string Auth(string login, string password)
        {
            string host = GetAddress();
            if (host != "host:nohost")
            {
                Guid prefix;
                try
                {
                    WebRequest request = WebRequest.Create(host + "/handle.php?action=getprefix&login=" + login);
                    request.Method = "GET";
                    WebResponse response = request.GetResponse();
                    string res = "";
                    using (Stream stream = response.GetResponseStream())
                    {
                        using (StreamReader reader = new StreamReader(stream))
                        {
                            res = reader.ReadToEnd();
                        }
                    }
                    response.Close();
                    if (res == "incorrect_login")
                        return "incorrect_login";
                    else if (res == "0")
                        return "";
                    else
                        prefix = Guid.Parse(res);
                }
                catch
                {
                    return "";
                }
                try
                {
                    string hash = CalcHash(password + prefix.ToString());
                    WebRequest request = WebRequest.Create(host + "/handle.php?action=auth&login=" + login + "&prefix=" + prefix + "&hash=" + hash);
                    request.Method = "GET";
                    WebResponse response = request.GetResponse();
                    string res = "";
                    using (Stream stream = response.GetResponseStream())
                    {
                        using (StreamReader reader = new StreamReader(stream))
                        {
                            res = reader.ReadToEnd();
                        }
                    }
                    response.Close();
                    if (res == "auth_not_succ")
                        return "auth_not_succ";
                    else if (res == "auth_error")
                        return "";
                    else
                        return res;
                }
                catch
                {
                    return "";
                }
            }
            else
                return "no_server";
        }
        public static string Reg(string login, string password)
        {
            string host = GetAddress();
            Guid prefix = Guid.NewGuid();
            string hash = CalcHash(password + prefix.ToString());
            try
            {
                WebRequest request = WebRequest.Create(host + "/handle.php?action=reg&login=" + login + "&prefix=" + prefix + "&hash=" + hash);
                request.Method = "GET";
                WebResponse response = request.GetResponse();
                string res = "";
                using (Stream stream = response.GetResponseStream())
                {
                    using (StreamReader reader = new StreamReader(stream))
                    {
                        res = reader.ReadToEnd();
                    }
                }
                response.Close();
                if (res == "login_exists")
                    return "login_exists";
                else if (res == "0")
                    return "";
                else
                    return "1";
            }
            catch
            {
                return "";
            }
        }
    }
}
