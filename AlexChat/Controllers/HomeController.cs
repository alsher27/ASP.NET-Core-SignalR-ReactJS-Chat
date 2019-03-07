using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using AlexChat.Models;

namespace AlexChat.Controllers
{
    public class HomeController : Controller
    {
        private ChatContext db;
        public HomeController(ChatContext context)
        {
            db = context;
        }

        public IActionResult Index()
        {
            return View();
        }
    }
}