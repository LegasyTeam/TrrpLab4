using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CourseServer
{
    [System.CodeDom.Compiler.GeneratedCodeAttribute("System.Web.Services", "4.8.3752.0")]
    [System.Diagnostics.DebuggerStepThroughAttribute()]
    [System.ComponentModel.DesignerCategoryAttribute("code")]
    [System.Web.Services.WebServiceBindingAttribute(Name = "DailyInfoSoap", Namespace = "http://web.cbr.ru/")]
    public class DailyInfo: System.Web.Services.Protocols.SoapHttpClientProtocol
    {
        private bool useDefaultCredentialsSetExplicitly;
        public DailyInfo()
        {
            this.Url = "http://www.cbr.ru/DailyInfoWebServ/DailyInfo.asmx";
            if ((this.IsLocalFileSystemWebService(this.Url) == true))
            {
                this.UseDefaultCredentials = true;
                this.useDefaultCredentialsSetExplicitly = false;
            }
            else
            {
                this.useDefaultCredentialsSetExplicitly = true;
            }
        }

        public new bool UseDefaultCredentials
        {
            get
            {
                return base.UseDefaultCredentials;
            }
            set
            {
                base.UseDefaultCredentials = value;
                this.useDefaultCredentialsSetExplicitly = true;
            }
        }

        private bool IsLocalFileSystemWebService(string url)
        {
            if (((url == null)
                        || (url == string.Empty)))
            {
                return false;
            }
            System.Uri wsUri = new System.Uri(url);
            if (((wsUri.Port >= 1024)
                        && (string.Compare(wsUri.Host, "localHost", System.StringComparison.OrdinalIgnoreCase) == 0)))
            {
                return true;
            }
            return false;
        }

        [System.Web.Services.Protocols.SoapDocumentMethodAttribute("http://web.cbr.ru/EnumValutes", RequestNamespace = "http://web.cbr.ru/", ResponseNamespace = "http://web.cbr.ru/", Use = System.Web.Services.Description.SoapBindingUse.Literal, ParameterStyle = System.Web.Services.Protocols.SoapParameterStyle.Wrapped)]
        public System.Data.DataSet EnumValutes(bool Seld)
        {
            object[] results = Invoke("EnumValutes", new object[] {
                        Seld});
            return ((System.Data.DataSet)(results[0]));
        }

        [System.Web.Services.Protocols.SoapDocumentMethodAttribute("http://web.cbr.ru/GetCursDynamic", RequestNamespace = "http://web.cbr.ru/", ResponseNamespace = "http://web.cbr.ru/", Use = System.Web.Services.Description.SoapBindingUse.Literal, ParameterStyle = System.Web.Services.Protocols.SoapParameterStyle.Wrapped)]
        public System.Data.DataSet GetCursDynamic(System.DateTime FromDate, System.DateTime ToDate, string ValutaCode)
        {
            object[] results = this.Invoke("GetCursDynamic", new object[] {
                        FromDate,
                        ToDate,
                        ValutaCode});
            return ((System.Data.DataSet)(results[0]));
        }
    }
}
