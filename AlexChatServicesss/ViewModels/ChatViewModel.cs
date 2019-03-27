using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace AlexChatServices.ViewModels
{
    public class ChatViewModel
    {
        public int Id { get; set; }
        public string Chatname { get; set; }
        public List<string> Users { get; set; }
        
        public bool MessagesGot = false;
    }
}
