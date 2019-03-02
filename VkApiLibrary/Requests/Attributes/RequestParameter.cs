using System;

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
