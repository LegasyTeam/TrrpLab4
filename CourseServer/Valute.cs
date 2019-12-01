using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CourseServer
{
    
    public class Valute
    {
        private string str_ValuteCode;
        private string str_ValuteName;
        private string str_ValuteCurse;

        public Valute(string ValuteNameStr, string ValuteCodeStr, string ValuteCurseStr)
        {

            this.str_ValuteCode = ValuteCodeStr;
            this.str_ValuteName = ValuteNameStr;
            this.str_ValuteCurse = ValuteCurseStr;
        }

        public string ValuteCode
        {
            get
            {
                return str_ValuteCode;
            }
        }

        public string ValuteName
        {

            get
            {
                return str_ValuteName;
            }
        }

        public string ValuteCurse
        {

            get
            {
                return str_ValuteCurse;
            }
        }
        public override string ToString()
        {
            return this.str_ValuteName + " - " + this.str_ValuteCode;
        }


    }
}
