using AlexChatModels;
using AlexChatServices.Service;
using AlexChatModels.ViewModels;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace AlexChat.Controllers
{
    [Authorize]
    [Route("api/[controller]")]
    public class ChatController
    {
        private readonly IChatService _chatService;
        public ChatController(IChatService chatService)
        {
            _chatService = chatService;
        }

        [HttpPost]
        [Route("createchat")]
        public async Task<ChatViewModel> CreateChat([FromBody] ChatViewModel model)
        {
             int chatId = await _chatService.CreateChat(model.Users, model.Chatname);
             return new ChatViewModel { Users = model.Users, Chatname = model.Chatname, Id = chatId };
        }
        
        [HttpGet]
        [Route("getchats")]
        public async Task<List<ChatViewModel>> GetChatsForUser(string username)
        {
            return await _chatService.GetChatsForUser(username);
        }

        [HttpGet]
        [Route("searchusers")]
        public async Task<List<string>> SearchUsers(string username)
        {
            return await _chatService.SearchUsers(username);
        }
    }
}
