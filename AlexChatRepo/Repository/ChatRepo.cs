using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using AlexChatRepo.Entities;
using Microsoft.EntityFrameworkCore;

namespace AlexChatRepo.Repository
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
                _context.SaveChanges();
                return chat;
            
        }

        public async Task<List<Chat>> GetChatsForUser(string username)
        {

            //var res =_context.UserChats.Where(uc => uc.User.UserName == username)
            //                           .Select(o => new { o.Chat, Users = o.Chat.UserChats.Select(oo => oo.User).ToArray() })
            //                           .ToList();

            //return res.Select(o => (o.Chat, o.Users)).ToList();

            var res = _context.UserChats.Where(uc => uc.User.UserName == username)
                .Select(uc => uc.Chat).ToList();
            return res;

            }
        public async Task<List<User>> GetUsersForChat(int chatId)
        {
            var usersForChat = await _context.UserChats.Where(uc => uc.ChatId == chatId).Select(uc => uc.User).ToListAsync();
            
            return usersForChat;
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
