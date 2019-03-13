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
        List<MessageViewModel> GetMessagesFor(int id);
        void SendMessage(MessageViewModel message);
    }
}
