using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace VkApiSDK.Friends
{
    public static class ApiFriends
    {
        public static GetFriends GetFriens(string AccessToken, string UserID, string[] Fields = null, string Order = FriendOrder.Hints, int Count = 5000, int Offset = 0)
        {
            return new GetFriends(AccessToken, UserID, Fields, Order, Count, Offset);
        }

        public static GetOnlineFriends GetOnlineFriends(string AccessToken, string UserID, string[] Fields = null, string Order = FriendOrder.Hints, int Count = 5000, int Offset = 0, bool OnlineMobile = false)
        {
            return new GetOnlineFriends(AccessToken, UserID, Fields, Order, Count, Offset, OnlineMobile);
        }
    }
}
