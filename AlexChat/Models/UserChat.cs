using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace AlexChat.Models
{
    public class UserChat
    {

        public string UserId { get; set; }
        [ForeignKey("UserId")]
        public User User { get; set; }
        
        public int ChatId { get; set; }
        [ForeignKey("ChatId")]
        public Chat Chat { get; set; }
    }
}
