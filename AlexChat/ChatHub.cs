using Microsoft.AspNetCore.SignalR;
using System;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using AlexChat.Models;
using AlexChat.Service;
using AlexChat.ViewModels;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Identity;
using System.Collections.Generic;
//using System.Security.Principal;

namespace AlexChat
{
    [Authorize]
    public class ChatHub : Hub
    {
        private readonly UserManager<User> _userManager;
        private readonly IMessageService _messageService;
        public ChatHub(IMessageService messageService, UserManager<User> userManager)
        {
            _userManager = userManager;
            _messageService = messageService;
        }
        public async Task Transfer(string username, string message, int chatid)
        {
                
            var mes = new MessageViewModel { Text = message, DateTime = DateTime.Now.ToString("u"),
                Chat = chatid, FromUsername = username };

            var temp = await _messageService.ProcessMessage(mes);
            var targetUsers = temp.Select(u=>u.UserName).ToList();
            
            await Clients.Users(targetUsers).SendAsync("Receive", mes);
            //await Clients.All.SendAsync("Receive", mes);
            
        }
    }
}
