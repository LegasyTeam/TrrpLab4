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
        int GetCurrentCourse(int dollar);
        [OperationContract]
        string GetCurrenttCourse(DateTime from, DateTime to);
    }
}
