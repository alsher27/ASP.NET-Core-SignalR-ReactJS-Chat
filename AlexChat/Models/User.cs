using Microsoft.AspNetCore.Identity;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace AlexChat.Models
{
    public class User : IdentityUser
    {
        //public int Id { get; set; }
        //public string ID { get; set; }
        //public string Username { get; set; }
        //public string Password { get; set; }
        public ICollection<UserChat> UserChats { get; set; }

    }
}