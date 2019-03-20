using AlexChat.Models;
using AlexChat.ViewModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace AlexChat.Repository
{
    public interface IChatRepo
    {
        Task<Chat> CreateChat(List<User> users, string chatname);
        Task<List<ChatViewModel>> GetChatsForUser(string username);
        Task<List<string>> SearchUsers(string username);
    }
}
