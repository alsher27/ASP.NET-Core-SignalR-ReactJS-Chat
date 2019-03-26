using Microsoft.AspNetCore.SignalR;
using System;

using System.Threading.Tasks;

using AlexChatServices.Service;
using AlexChatModels.ViewModels;
using Microsoft.AspNetCore.Authorization;
using System.Linq;

namespace AlexChat
{
    [Authorize]
    public class ChatHub : Hub
    {
        private readonly IMessageService _messageService;
        private readonly IChatService _chatService;
        public ChatHub(IMessageService messageService, IChatService chatService)
        {
            _messageService = messageService;
            _chatService = chatService;
        }
        public async Task Transfer(string username, string message, int chatid)
        {


            var users = await _chatService.GetUsersForChat(chatid);
            var targetUsers = users.Select(u => u.Id).ToList();

            IClientProxy clientProxy = Clients.Users(targetUsers);
            await clientProxy.SendAsync("Receive", message);


            var mes = new MessageViewModel
            {
                Text = message,
                DateTime = DateTime.Now.ToString("u"),
                ChatId = chatid,
                FromUsername = username
            };

            _messageService.SaveMessage(mes);

        }
    }
}
