using AlexChat.Models;
using AlexChat.Service;
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
        public async Task<int> CreateChat([FromBody] List<string> users, string chatname)
        {
            int ChatId = await _chatService.CreateChat(users, chatname);
            
            return ChatId;
        }

        public async Task<List<Chat>> GetChatsForUser(string username)
        {
            return await _chatService.GetChatsForUser(username);
        }
    }
}
