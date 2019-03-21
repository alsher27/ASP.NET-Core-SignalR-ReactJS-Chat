using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using AlexChat.Models;
using AlexChat.Repository;
using AlexChat.ViewModels;
using AutoMapper;
using Microsoft.EntityFrameworkCore;

namespace AlexChat.Service
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
        public async Task<ChatViewModel> CreateChat(List<string> usernames, string chatname)
        {
            var users = new List<User> { };
            foreach (string u in usernames)
            {
                users.Add(_chatContext.Users.FirstOrDefault(usr => usr.UserName == u));
            }
            var chat = await _chatRepo.CreateChat(users, chatname);

            return new ChatViewModel { Users = usernames, Chatname = chatname, Id = chat.Id };
        }

        public async Task<List<ChatViewModel>> GetChatsForUser(string username)
        {
            return await _chatRepo.GetChatsForUser(username);
        }

        public async Task<List<string>> SearchUsers(string username)
        {
            return await _chatRepo.SearchUsers(username);
        }
    }
}
