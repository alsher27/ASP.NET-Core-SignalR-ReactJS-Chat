using Microsoft.AspNetCore.Identity;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace AlexChatModels
{
    public class User : IdentityUser
    {
        public ICollection<UserChat> UserChats { get; set; }
    }
}