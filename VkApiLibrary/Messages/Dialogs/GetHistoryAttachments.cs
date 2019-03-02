using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using VkApiSDK.Requests;

namespace VkApiSDK.Messages.Dialogs
{
    /// <summary>
    /// Возвращает материалы диалога или беседы.
    /// </summary>
    public class GetHistoryAttachments : VkApiMethod
    {
        public GetHistoryAttachments(string AccessToken, string MediaType, string StartFrom, int Count = 30, bool PhotoSizes = false, string[] Fields = null)
            : base(AccessToken, Fields)
        {
            VkApiMethodName = "messages.getHistoryAttachments";
            this.MediaType = MediaType;
            this.StartFrom = StartFrom;
            this.Count = Count;
            this.PhotoSizes = PhotoSizes;
        }

        /// <summary>
        /// Идентификатор назначения.
        /// </summary>
        public string PeedID { get; set; }

        /// <summary>
        /// Тип материалов, который необходимо вернуть
        /// </summary>
        public string MediaType { get; set; }

        /// <summary>
        /// Смещение, необходимое для выборки определенного подмножества объектов.
        /// </summary>
        public string StartFrom { get; set; }

        /// <summary>
        /// Количество объектов, которое необходимо получить (но не более 200).
        /// </summary>
        public int Count { get; set; }

        /// <summary>
        /// Параметр, указывающий нужно ли возвращать ли доступные размеры фотографии в специальном формате. 
        /// </summary>
        public bool PhotoSizes { get; set; }

        protected override string GetMethodApiParams()
        {
            return string.Format("&peer_id={0}&media_type={1}&start_from={2}&count={3}&photo_sizes={4}", PeedID,
                                                                                                         MediaType,
                                                                                                         StartFrom,
                                                                                                         Count,
                                                                                                         PhotoSizes ? 1 : 0);
        }
    }
}
