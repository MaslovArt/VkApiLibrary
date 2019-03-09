namespace VkApiSDK.Friends.Methods
{
    public class GetOnlineFriends : GetFriends
    {
        private int _onlineMobile = 0;

        public GetOnlineFriends(string AccessToken, int UserID, string[] Fields = null, string Order = FriendOrder.Hints, int Count = 5000, int Offset = 0, bool OnlineMobile = false)
            :base(AccessToken, UserID, Fields, Order, Count, Offset)
        {
            VkApiMethodName = "friends.getOnline";
            this.OnlineMobile = OnlineMobile;
        }

        /// <summary>
        /// true — будет возвращено дополнительное поле online_mobile. 
        /// По умолчанию — false. 
        /// </summary>
        public bool OnlineMobile
        {
            get { return _onlineMobile == 0; }
            set { _onlineMobile = value ? 1 : 0; }
        }

        protected override string GetMethodApiParams()
        {
            return base.GetMethodApiParams() + string.Format("&online_mobile={0}", _onlineMobile);
        }
    }
}
