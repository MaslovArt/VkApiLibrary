using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using VkApiSDK.Abstraction;
using VkApiSDK.Auth;
using VkApiSDK.Requests;
using VkApiSDK.Utils;

namespace VkApiSDK.ApiBuilder
{
    public class VkApiBuiler
    {
        private int timeout;
        private IVkRequest request;
        private ILogger logger;
        private AuthData aData;
 
        public static VkApiBuiler CreateBuiler()
        {
            return new VkApiBuiler();
        }

        public VkApi Build()
        {
            if (aData == null)
                throw new ArgumentNullException("No api token");

            if (request == null)
                request = new VkRequest();

            if (timeout < 1)
                timeout = 20;

            return new VkApi(aData, request, logger, timeout);
        }

        public VkApiBuiler SetHttpRequestProcessor(IVkRequest requestProcessor)
        {
            request = requestProcessor;
            return this;
        }

        public VkApiBuiler SetToken(AuthData authData)
        {
            aData = authData;
            return this;
        }

        public VkApiBuiler SetLogger(ILogger logger)
        {
            this.logger = logger;
            return this;
        }

        public VkApiBuiler SetTimeout(int seconds)
        {
            timeout = seconds;
            return this;
        }
    }
}
