using AlexChat.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace AlexChat.ViewModels
{
    public class MessageViewModel
    {
        public string Text { get; set; }
        public string DateTime { get; set; }
        public int ChatId { get; set; }
        public string FromUsername { get; set; }
    }
}
