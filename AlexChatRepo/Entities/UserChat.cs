﻿using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace AlexChatRepo.Entities
{
    public class UserChat
    {

        public string UserId { get; set; }
        [ForeignKey(nameof(UserId))]
        public User User { get; set; }
        
        public int ChatId { get; set; }
        [ForeignKey(nameof(ChatId))]
        public Chat Chat { get; set; }
    }
}
