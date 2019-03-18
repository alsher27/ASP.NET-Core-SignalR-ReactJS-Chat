using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using AlexChat.Models;
using AlexChat.Repository;

namespace AlexChat.Service
{
    public class ChatService : IChatService
    {
        private readonly IChatRepo _chatRepo;
        private readonly ChatContext _chatContext;
        public ChatService(IChatRepo chatRepo, ChatContext chatContext)
        {
            _chatRepo = chatRepo;
            _chatContext = chatContext;
        }
        public Task<int> CreateChat(List<string> usernames, string chatname)
        {
            var users = new List<User> { };
            foreach (string u in usernames)
            {
                users.Add(_chatContext.Users.FirstOrDefault(usr=>usr.UserName == u));
            }
            
            return _chatRepo.CreateChat(users, chatname);            
        }

        public async Task<List<Chat>> GetChatsForUser(string username)
        {
            return await _chatRepo.GetChatsForUser(username);
        }
    }
}
