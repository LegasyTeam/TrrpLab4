using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.ServiceModel;
using System.Data;

namespace CourseServer
{
    [ServiceContract]
    interface ICourseServer
    {
        [OperationContract]
        double GetCurrentCourse(bool dollar);
        [OperationContract]
        string GetCurrenttCourse(DateTime from, DateTime to);
        [OperationContract]
        string BuyValute(string mass);
        [OperationContract]
        string SellValute(string mass);
        [OperationContract]
        string GetBalance(string token);
    }
}
