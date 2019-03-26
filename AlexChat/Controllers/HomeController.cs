using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using AlexChatModels;
using AlexChatRepo;

namespace AlexChat.Controllers
{
    public class HomeController : Controller
    {
        public HomeController(ChatContext context)
        {
        }

        public IActionResult Index()
        {
            return View();
        }
    }
}