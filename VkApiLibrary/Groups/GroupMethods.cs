using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using VkApiSDK.Abstraction;
using VkApiSDK.Groups.Methods;
using VkApiSDK.Models.LongPoll;
using VkApiSDK.Models.Response;

namespace VkApiSDK.Groups
{
    class GroupMethods : VkApiMethodGroup
    {
        public GroupMethods(AuthData AuthData, IVkRequest Request)
            : base(AuthData, Request)
        { }

        public async Task<LongPollConnectionData> GetLongPollServer(int GroupID)
        {
            var result = await _vkRequest.Dispath<VkResponse<LongPollConnectionData>>(
                new GetGroupLongPollServer(
                    AccessToken: AuthData.AccessToken,
                    GroupID: GroupID
                ));

            return result?.Response;
        }
    }
}
