using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using AlexChat.Models;
using AlexChat.ViewModels;
using Microsoft.EntityFrameworkCore;

namespace AlexChat.Repository
{
    public class ChatRepo : IChatRepo
    {
        private readonly ChatContext _context;
        public ChatRepo(ChatContext context)
        {
            _context = context;
        }

        public async Task<Chat> CreateChat(List<User> users, string chatname)
        {

                var chat = new Chat { Name = chatname};
                _context.Add(chat);
                foreach (User u in users)
                {
                    await _context.AddAsync(new UserChat { Chat = chat, UserId = u.Id });
                }
                await _context.SaveChangesAsync();
                return chat;
            
        }

        public async Task<List<ChatViewModel>> GetChatsForUser(string username)
        {
            
            var cwm = new List<ChatViewModel> { };
          
            foreach (Chat c in _context.Chats)
            {   
                var users = _context.UserChats.Where(uc => uc.Chat == c)
                                              .Select(uc => uc.User.UserName)
                                              .ToList();

                var temp = new ChatViewModel
                {
                    Chatname = c.Name,
                    Users = users,
                    Id = c.Id
                };
                cwm.Add(temp);
            }
            var result = cwm.Where(x => x.Users.Contains(username)).ToList();

            return result;
            }

        public async Task<List<string>> SearchUsers(string username)
        {
            
                return await _context.Users.Where(u => u.UserName.Contains(username))
                                                                .Take(5)
                                                                .Select(u=>u.UserName)
                                                                .ToListAsync();
            
        }
    }
}
