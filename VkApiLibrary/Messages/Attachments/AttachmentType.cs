using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace VkApiSDK.Messages.Attachments
{
    /// <summary>
    /// Тип медиавложения.
    /// </summary>
    public class AttachmentType
    {
        public const string Photo = "photo",
                            Video = "video",
                            Audio = "audio",
                            Doc = "doc",
                            Wall = "wall",
                            Market = "market",
                            Poll = "poll";
    }
}
