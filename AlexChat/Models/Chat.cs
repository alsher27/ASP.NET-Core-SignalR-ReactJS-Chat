using System.Collections.Generic;

namespace AlexChat.Models
{
    public class Chat
    {
            public int Id { get; set; }
            public ICollection<UserChat> UserChats { get; set; }
    }
}