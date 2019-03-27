using AlexChatRepo.Entities;
using AlexChatServices.ViewModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;


namespace AlexChatServices.Service
{
    public interface IMessageService
    {
        Task<List<Message>> GetMessagesForChat(int id);
        void SaveMessage(MessageViewModel message);
    }
}
