using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CourseServer
{
    public class CurrentCurse
    {
        public List<Valute> Valutes { get; set; }
        public TimeSpan TimeSpan { get; set; }
        public CurrentCurse()
        {
            Valutes = new List<Valute>();
            TimeSpan = new TimeSpan();
        }

        
    }
}
