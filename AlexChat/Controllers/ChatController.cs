using AlexChatModels;
using AlexChatServices.Service;
using AlexChatModels.ViewModels;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.SignalR;

namespace AlexChat.Controllers
{
    [Authorize]
    [Route("api/[controller]")]
    public class ChatController
    {
        private readonly IChatService _chatService;
        private readonly ChatHub _chatHub;
        public ChatController(IChatService chatService, ChatHub chatHub)
        {
            _chatService = chatService;
            _chatHub = chatHub;

        }

        [HttpPost]
        [Route("createchat")]
        public async Task<ChatViewModel> CreateChat([FromBody] ChatViewModel model)
        {
             int chatId = await _chatService.CreateChat(model.Users, model.Chatname);
             return new ChatViewModel { Users = model.Users, Chatname = model.Chatname, Id = chatId };

             //var users = await _chatService.GetUsersForChat(model.Id);
             //var targetUsers = users.Select(u=>u.Id).ToList();
             //IClientProxy clientProxy = _chatHub.Clients.Users(targetUsers);
             //await clientProxy.SendAsync("ChatCreated", chat);
 
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
