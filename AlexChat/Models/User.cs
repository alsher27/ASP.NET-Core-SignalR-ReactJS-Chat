

using System.Collections.Generic;

namespace AlexChat.Models
{
    public class User
    {
        public int Id { get; set; }
        public string Username { get; set; }
        public string Password { get; set; }
        public ICollection<UserChat> UserChats{ get; set; }
        
    }
}