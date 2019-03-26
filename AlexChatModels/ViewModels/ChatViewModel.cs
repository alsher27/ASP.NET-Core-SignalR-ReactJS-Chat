using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace AlexChatModels.ViewModels
{
    public class ChatViewModel
    {
        public List<string> Users { get; set; }
        public string Chatname { get; set; }
        public int Id { get; set; }
    }
}
