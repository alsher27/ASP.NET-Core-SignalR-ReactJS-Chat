using Microsoft.AspNetCore.SignalR;
using System;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using AlexChat.Models;
using AlexChat.Service;
using AlexChat.ViewModels;

namespace AlexChat
{
    public class ChatHub : Hub
    {
        private readonly IMessageService _messageService;
        public ChatHub(IMessageService messageService)
        {
            _messageService = messageService;
        }
        public async Task Send(string username, string message, int chatid)
        {
                var mes = new MessageViewModel { text = message, dateTime = DateTime.Now.ToString("u"), chat = chatid };
                _messageService.SendMessage(mes);
                
                await Clients.All.SendAsync("Send", mes);
            
        }
    }
}
