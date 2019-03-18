using AlexChat.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace AlexChat.Repository
{
    public interface IChatRepo
    {
        Task<int> CreateChat(List<User> users, string chatname);
        Task<List<Chat>> GetChatsForUser(string username);
    }
}
