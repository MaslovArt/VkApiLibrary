using System.Collections.Generic;

namespace VkApiSDK.Users
{
    public static class ApiUsers
    {
        public static GetUsers Get(string AccessToken, IEnumerable<int> UserIDs, IEnumerable<string> Fields = null)
        {
            return new GetUsers(AccessToken, UserIDs, Fields);
        }
    }
}
