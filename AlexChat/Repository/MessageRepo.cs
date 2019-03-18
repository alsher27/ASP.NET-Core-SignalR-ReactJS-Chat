using AlexChat.Models;
using Microsoft.EntityFrameworkCore;
using System.Collections.Generic;
using System.Threading.Tasks;
using System.Linq;

namespace AlexChat.Repository
{
    public class MessageRepo : IMessageRepo
    {

        public async Task<List<Message>> GetMessagesForChat(int id)
        {
            //var optionsBuilder = new DbContextOptionsBuilder<ChatContext>().UseSqlServer("Server=localhost\\SQLEXPRESS;Database=chat;Trusted_Connection=True;");

            using (var context = new ChatContext(/*optionsBuilder.Options*/))
            {
                return await context.Messages.Include(m=>m.User.UserName) 
                                             .Where(mes=>mes.Chat.Id==id)
                                             .Take(20)
                                             .ToListAsync(); 
            }
        }

        public async Task<List<User>> ProcessMessage(Message mes)
        {
            //var optionsBuilder = new DbContextOptionsBuilder<ChatContext>().UseSqlServer("Server=localhost\\SQLEXPRESS;Database=chat;Trusted_Connection=True;");

            using (var context = new ChatContext())
            {
                context.Messages.Add(mes);
                context.SaveChanges();

                var usersForChat = await context.UserChats.Where(uc => uc.Chat == mes.Chat).Select(uc => uc.User).ToListAsync();
                return usersForChat;

            }
        }
    }
}