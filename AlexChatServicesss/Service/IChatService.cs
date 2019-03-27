using AlexChatRepo.Entities;
using AlexChatServices.ViewModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace AlexChatServices.Service
{
    public interface IChatService
    {
        Task<int> CreateChat(List<string> users, string chatname);
        Task<List<ChatViewModel>> GetChatsForUser(string username);
        Task<List<User>> GetUsersForChat(int chatId);
        Task<List<string>> SearchUsers(string username);
    }
}
