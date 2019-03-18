using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using AlexChat.Models;
using Microsoft.EntityFrameworkCore;

namespace AlexChat.Repository
{
    public class ChatRepo : IChatRepo
    {
        public async Task<int> CreateChat(List<User> users, string chatname)
        {
            //var optionsBuilder = new DbContextOptionsBuilder<ChatContext>().UseSqlServer("Server=localhost\\SQLEXPRESS;Database=chat;Trusted_Connection=True;");
            using (var context = new ChatContext())
            {
                var chat = new Chat { Name = chatname};
                context.Add(chat);
                foreach (User u in users)
                {
                    await context.AddAsync(new UserChat { Chat = chat, UserId = u.Id });
                }
                await context.SaveChangesAsync();
                return chat.Id;
            }
        }

        public async Task<List<Chat>> GetChatsForUser(string username)
        {
            using (var context = new ChatContext())
            {
                return await context.UserChats.Where(uc => uc.User.UserName == username)
                                              .Select(uc => uc.Chat)
                                              .ToListAsync();
            }
        }
    }
}
