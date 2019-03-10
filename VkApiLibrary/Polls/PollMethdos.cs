using System.Collections.Generic;
using System.Threading.Tasks;
using System.Linq;
using VkApiSDK.Abstraction;
using VkApiSDK.Models.Attachments;
using VkApiSDK.Polls.Methods;
using VkApiSDK.Models.Response;
using VkApiSDK.Models.Polls;

namespace VkApiSDK.Polls
{
    /// <summary>
    /// Методы для работы с голосованием
    /// </summary>
    public class PollMethdos : VkApiMethodGroup
    {
        /// <summary>
        /// Инициализирует новый экземпляр класса <c>PollMethdos</c>
        /// </summary>
        /// <param name="AuthData">Токен доступа</param>
        /// <param name="VkRequest">Класс для отправки запросов</param>
        public PollMethdos(AuthData AuthData, IVkRequest VkRequest)
            : base(AuthData, VkRequest)
        { }

        /// <summary>
        /// Отдает голос
        /// </summary>
        /// <param name="Poll">Опрос</param>
        /// <param name="Answers">Ответы</param>
        /// <returns></returns>
        public async Task<int> AddVote(Poll Poll, IEnumerable<VoteAnswer> Answers)
        {
            var result = await _vkRequest.Dispath<VkResponse<int>>(
                new AddVote(
                    AccessToken: AuthData.AccessToken,
                    OwnerID: Poll.OwnerID,
                    PollID: Poll.ID,
                    AnswerIDs: Answers.Select(ans => ans.ID)
                ));

            return result != null ? result.Response : -1;
        }

        /// <summary>
        /// Удаляет голос
        /// </summary>
        /// <param name="Poll">Опрос</param>
        /// <param name="Answers">Ответ для отмены</param>
        /// <returns></returns>
        public async Task<int> DeleteVote(Poll Poll, VoteAnswer Answer)
        {
            var result = await _vkRequest.Dispath<VkResponse<int>>(
                new DeleteVote(
                    AccessToken: AuthData.AccessToken,
                    OwnerID: Poll.OwnerID,
                    PollID: Poll.ID,
                    AnswerID: Answer.ID
                ));

            return result != null ? result.Response : -1;
        }

        /// <summary>
        /// Получает список идентификаторов пользователей, которые выбрали определенные варианты ответа в опросе.
        /// </summary>
        /// <param name="Poll">Опрос</param>
        /// <param name="Answer">Ответы</param>
        /// <param name="Offset">Смещение</param>
        /// <param name="Count">Кол-во ответов</param>
        /// <param name="FriendsOnly">Только для друзей</param>
        /// <param name="IsBoard"></param>
        /// <returns></returns>
        public async Task<VotersData[]> GetVotes(Poll Poll, IEnumerable<VoteAnswer> Answer, int Offset = 0, int Count = 40, bool FriendsOnly = false, bool IsBoard = false)
        {
            var result = await _vkRequest.Dispath<VkResponse<VotersData[]>>(
                new GetVoters(
                    AccessToken: AuthData.AccessToken,
                    OwnerID: Poll.OwnerID,
                    PollID: Poll.ID,
                    AnswerIDs: Answer.Select(ans => ans.ID),
                    Offset: Offset,
                    Count: Count,
                    FriendsOnly: FriendsOnly,
                    IsBoard: IsBoard
                ));

            return result?.Response;
        }

        /// <summary>
        /// Инициализирует новый экземпляр класса<c>CreateVote</c>
        /// </summary>
        /// <param name="QuestionText">Tекст вопроса</param>
        /// <param name="Answers">Список вариантов ответов</param>
        /// <param name="IsAnanimus">Aнонимный опрос</param>
        /// <param name="IsMultipleVote">Cоздания опроса с мультивыбором</param>
        /// <param name="EndDate">Дата завершения опроса в Unixtime</param>
        /// <param name="BackgroundID">Идентификатор стандартного фона для сниппета</param>
        public async Task<Poll> CreateVote(string QuestionText, IEnumerable<string> Answers, bool IsAnanimus = false, bool IsMultipleVote = false, long EndDate = 0, int BackgroundID = 1)
        {
            var result = await _vkRequest.Dispath<VkResponse<Poll>>(
                new CreateVote(
                    AccessToken: AuthData.AccessToken,
                    OwnerID: AuthData.UserID,
                    QuestionText: QuestionText,
                    Answers: Answers,
                    IsAnanimus: IsAnanimus,
                    IsMultipleVote: IsMultipleVote,
                    EndDate: EndDate,
                    BackgroundID: BackgroundID
                ));

            return result?.Response;
        }
    }
}
