using System.Collections.Generic;
using Microsoft.AspNetCore.Mvc;
using AlexChat.Models;
using AlexChat.Service;
using AutoMapper;
using AlexChat.ViewModels;
using Microsoft.AspNetCore.Authorization;
using System.Threading.Tasks;

namespace AlexChat.Controllers
{
    [Authorize]
    [Route("api/[controller]")]
    public class MessageController : Controller
    {
        private readonly IMessageService _messageService;
        
        public MessageController(IMessageService messageService)
        {
            _messageService = messageService;
            
        }

       
        [HttpGet]    
        [Route("all")]
        public async Task<List<MessageViewModel>> GetMessagesForChat(int id)
        {
            return await _messageService.GetMessagesForChat(id);
        }

        public IActionResult Index()
        {
            return View();
        }
    }
}