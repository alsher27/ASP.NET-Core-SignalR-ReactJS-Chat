using System.Collections.Generic;
using Microsoft.AspNetCore.Mvc;
using AlexChat.Models;
using AlexChat.Service;
using AutoMapper;
using AlexChat.ViewModels;

namespace AlexChat.Controllers
{
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
        public List<MessageViewModel> Get(int id)
        {
            return _messageService.GetMessagesFor(id);
        }

        public IActionResult Index()
        {
            return View();
        }
    }
}