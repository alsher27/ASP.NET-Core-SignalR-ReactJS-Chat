using AlexChatRepo.Entities;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace AlexChatRepo.Repository
{
    public interface IChatRepo
    {
        Task<Chat> CreateChat(List<User> users, string chatname);
        Task<List<Chat>> GetChatsForUser(string username);

        Task<List<User>> GetUsersForChat(int chatId);
        Task<List<string>> SearchUsers(string username);
    }
}
