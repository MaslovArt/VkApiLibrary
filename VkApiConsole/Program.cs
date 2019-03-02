using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using VkApiSDK;
using VkApiSDK.Requests;

namespace VkApiConsole
{
    class Program
    {
        static void Main(string[] args)
        {
            string appID = "";
            string scope = "";
            string testUserID = "137886598";

            VkClient cv = new VkClient(appID, scope);
            cv.Auth((a, b, c) =>
            {
                return new AuthData()
                {
                    AccessToken = "37c4504d68ebcffa2813f89d4d8e5eef66992db530a2fea7748395e875701992038bd8cd1c53ef811618c",
                    Expires = "0",
                    UserID = "181216176"
                };
            });

            var dialogs = cv.GetDialogsDataAsync(10);

            var friends = cv.GetFriendsAsync();

            var userInfo = cv.GetUsersAsync(
                Fields: new string[]
                {
                    ApiField.Photo50,
                    ApiField.LastOnline,
                    ApiField.IsOnline
                },
                userIDs: testUserID);

            var t = 0;
        }
    }
}
