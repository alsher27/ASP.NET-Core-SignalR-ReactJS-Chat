using AlexChatModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace AlexChatRepo.Repository
{
    public interface IMessageRepo
    {
        Task<List<Message>> GetMessagesForChat(int id);
        void SaveMessage(Message message);
    }
}
