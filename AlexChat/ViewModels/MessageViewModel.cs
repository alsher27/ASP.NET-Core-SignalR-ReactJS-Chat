using AlexChat.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace AlexChat.ViewModels
{
    public class MessageViewModel
    {
        public string text { get; set; }
        public string dateTime { get; set; }
        public int chat { get; set; }
    }
}
