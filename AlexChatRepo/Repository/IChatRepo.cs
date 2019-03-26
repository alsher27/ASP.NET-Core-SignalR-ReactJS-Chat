using AlexChatModels;
using AlexChatModels.ViewModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace AlexChatRepo.Repository
{
    public interface IChatRepo
    {
        Task<Chat> CreateChat(List<User> users, string chatname);
        Task<List<ChatViewModel>> GetChatsForUser(string username);

        Task<List<User>> GetUsersForChat(int chatId);
        Task<List<string>> SearchUsers(string username);
    }
}
