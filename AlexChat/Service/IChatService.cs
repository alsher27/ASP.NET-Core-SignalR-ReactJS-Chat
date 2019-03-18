using AlexChat.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace AlexChat.Service
{
    public interface IChatService
    {
        Task<int> CreateChat(List<string> users, string chatname);
        Task<List<Chat>> GetChatsForUser(string username);
    }
}
