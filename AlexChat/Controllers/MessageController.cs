using System.Collections.Generic;
using System.Threading.Tasks;
using AlexChatModels;
using AlexChatServices.Service;
using AlexChatModels.ViewModels;
using AutoMapper;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace AlexChat.Controllers
{
    [Authorize]
    [Route("api/[controller]")]
    public class MessageController : Controller
    {
        private readonly IMapper _mapper;
        private readonly IMessageService _messageService;

        public MessageController(IMessageService messageService, IMapper mapper)
        {
            _messageService = messageService;
            _mapper = mapper;
        }


        [HttpGet]
        [Route("all")]
        public async Task<List<MessageViewModel>> GetMessagesForChat(int id)
        {
            var messages = await _messageService.GetMessagesForChat(id);

            var messagesViewModel = new List<MessageViewModel>();
            foreach (var mes in messages)
            {
                var temp = _mapper.Map<Message, MessageViewModel>(mes);
                temp.FromUsername = mes.User.UserName;
                messagesViewModel.Add(temp);
            }

            return messagesViewModel;
        }
    }
}