using AlexChat.Models;
using AlexChat.ViewModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace AlexChat.Service
{
    public interface IMessageService
    {
        Task<List<Message>> GetMessagesForChat(int id);
        Task ProcessMessage(MessageViewModel message);
    }
}
