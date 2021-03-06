﻿using AlexChatRepo.Entities;
using Microsoft.EntityFrameworkCore;
using System.Collections.Generic;
using System.Threading.Tasks;
using System.Linq;
using System;
using Microsoft.AspNetCore.Identity;
using AlexChatRepo;

namespace AlexChatRepo.Repository
{
    public class MessageRepo : IMessageRepo
    {
        private readonly ChatContext _context; 
        public MessageRepo(ChatContext context)
        {
            _context = context;
        }

        public async Task<List<Message>> GetMessagesForChat(int id)
        {
            return await _context.Messages.Include(m=>m.User)
                                             .Where(mes=>mes.ChatId==id)
                                             .OrderByDescending(m=> m.DateTime)
                                             .Take(20)
                                             .ToListAsync(); 
            
        }

        public void SaveMessage(Message mes)
        {
            
             _context.Messages.Add(mes);
             _context.SaveChanges();
            
        }
    }
}