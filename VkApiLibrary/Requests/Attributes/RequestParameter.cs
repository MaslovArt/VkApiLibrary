using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace VkApiSDK.Requests.Attributes
{
    [AttributeUsage(AttributeTargets.Property, Inherited = false)]
    public class RequestParamAttr : Attribute
    {
        public RequestParamAttr(string ParamName)
        {
            this.ParamName = ParamName;
        }

        public string ParamName
        {
            get; private set;
        }

    }
}
