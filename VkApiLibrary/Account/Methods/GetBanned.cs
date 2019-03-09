using System;
using VkApiSDK.Abstraction;

namespace VkApiSDK.Account.Methods
{
    /// <summary>
    /// Возвращает список пользователей, находящихся в черном списке.
    /// </summary>
    public class GetBanned : VkApiMethod
    {
        private int count;

        /// <summary>
        /// Инициализирует новый экземпляр класса <c>GetBanned</c>
        /// </summary>
        /// <param name="AccessToken">Токен доступа</param>
        /// <param name="Offset">Cмещение, необходимое для выборки определенного подмножества черного списка.</param>
        /// <param name="Count">Kоличество объектов, информацию о которых необходимо вернуть.</param>
        public GetBanned(string AccessToken, int Offset = 0, int Count = 20)
            :base(AccessToken)
        {
            VkApiMethodName = "account.getBanned";
            this.Offset = Offset;
            this.Count = Count;
        }

        /// <summary>
        /// Cмещение, необходимое для выборки определенного подмножества черного списка. 
        /// </summary>
        public int Offset { get; set; }

        /// <summary>
        /// Kоличество объектов, информацию о которых необходимо вернуть. 
        /// </summary>
        /// <exception cref="ArgumentException"></exception>
        public int Count
        {
            get { return count; }
            set
            {
                if (value > 200)
                    throw new ArgumentException("максимальное значение 200");
                count = value;
            }
        }

        protected override string GetMethodApiParams()
        {
            return string.Format("&offset={0}&count={1}", Offset,
                                                          Count);
        }
    }
}
