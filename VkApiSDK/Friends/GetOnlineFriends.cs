namespace VkApiSDK.Friends
{
    public class GetOnlineFriends : GetFriends
    {
        private int _onlineMobile = 0;

        public GetOnlineFriends(string AccessToken)
            :base(AccessToken)
        {
            VkApiMethodName = "friends.getOnline";
        }

        /// <summary>
        /// true — будет возвращено дополнительное поле online_mobile. 
        /// По умолчанию — false. 
        /// </summary>
        public bool OnlineMobile { get; set; }

        protected override string GetMethodApiParams()
        {
            return base.GetMethodApiParams() + string.Format("&online_mobile={0}", _onlineMobile);
        }
    }
}
