using AlexChat.Models;
using Microsoft.EntityFrameworkCore;
using System.Collections.Generic;
using System.Threading.Tasks;
using System.Linq;
using System;
using Microsoft.AspNetCore.Identity;

namespace AlexChat.Repository
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

        public async Task<List<User>> ProcessMessage(Message mes)
        {
            
            _context.Messages.Add(mes);
            _context.SaveChanges();

            var usersForChat = await _context.UserChats.Where(uc => uc.ChatId == mes.ChatId).Select(uc => uc.User).ToListAsync();
            Console.WriteLine(usersForChat);
            return usersForChat;
            
        }
    }
}