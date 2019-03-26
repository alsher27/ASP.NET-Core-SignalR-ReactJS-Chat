using AlexChat.Models;
using AlexChat.ViewModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace AlexChat.Service
{
    public interface IChatService
    {
        Task<int> CreateChat(List<string> users, string chatname);
        Task<List<ChatViewModel>> GetChatsForUser(string username);
        Task<List<string>> SearchUsers(string username);
    }
}
