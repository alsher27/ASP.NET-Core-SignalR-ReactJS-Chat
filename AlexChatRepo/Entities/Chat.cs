using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;

namespace AlexChatRepo.Entities
{
    public class Chat
    {
        public Chat()
        {
            Messages = new List<Message>();
        }
        public int Id { get; set; }
        public string Name { get; set; }
        public ICollection<Message> Messages { get; set; }
        public ICollection<UserChat> UserChats { get; set; }
    }
}