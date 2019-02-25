using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace VkApiSDK.Users
{
    public static class ApiUsers
    {
        public static GetUsers Get(string AccessToken, string[] UserIDs, string[] Fields = null)
        {
            return new GetUsers(AccessToken, UserIDs, Fields);
        }
    }
}
