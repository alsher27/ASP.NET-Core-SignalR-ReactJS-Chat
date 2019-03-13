using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;

namespace AlexChat.Models
{
    public class Message
    {
        public int Id { get; set; }
        public string text { get; set; }
        public DateTime dateTime { get; set; }
        //[Required]
        //public int chatId { get; set; }
        // [ForeignKey("chatId")]
        public Chat chat { get; set; }
        
    }
}

