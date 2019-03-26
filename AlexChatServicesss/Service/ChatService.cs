using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using AlexChatModels;
using AlexChatRepo.Repository;
using AlexChatModels.ViewModels;

using AlexChatRepo;
using AutoMapper;
using Microsoft.EntityFrameworkCore;

namespace AlexChatServices.Service
{
    public class ChatService : IChatService
    {
        private readonly IChatRepo _chatRepo;
        private readonly ChatContext _chatContext;
        private readonly IMapper _mapper;

        public ChatService(IChatRepo chatRepo, ChatContext chatContext, IMapper mapper)
        {
            _chatRepo = chatRepo;
            _chatContext = chatContext;
            _mapper = mapper;
        }
        public async Task<int> CreateChat(List<string> usernames, string chatname)
        {
            var users = new List<User> { };
            foreach (string u in usernames)
            {
                users.Add(_chatContext.Users?.FirstOrDefault(usr => usr.UserName == u));
            }
            var chat = await _chatRepo.CreateChat(users, chatname);

            return chat.Id;
        }

        public async Task<List<ChatViewModel>> GetChatsForUser(string username)
        {
            return await _chatRepo.GetChatsForUser(username);
        }

        public async Task<List<User>> GetUsersForChat(int chatId)
        {
            return await _chatRepo.GetUsersForChat(chatId);
        }

        public async Task<List<string>> SearchUsers(string username)
        {
            return await _chatRepo.SearchUsers(username);
        }
    }
}
