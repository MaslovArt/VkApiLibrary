using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace VkApiSDK.Friends
{
    public static class FriendOrder
    {
        /// <summary>
        /// Cортировать по рейтингу, аналогично тому, как друзья сортируются в разделе Мои друзья.
        /// </summary>
        public const string Hints = "hints";
        /// <summary>
        /// Возвращает друзей в случайном порядке.
        /// </summary>
        public const string Random = "random";
        /// <summary>
        /// Возвращает выше тех друзей, у которых установлены мобильные приложения.
        /// </summary>
        public const string Mobile = "mobile";
        /// <summary>
        /// Сортировать по имени. Данный тип сортировки работает медленно, так как сервер будет получать 
        /// всех друзей а не только указанное количество count. (работает только при переданном параметре fields).
        /// </summary>
        public const string Name = "name";
    }
}
