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
            var optionsBuilder = new DbContextOptionsBuilder<ChatContext>().UseSqlServer("Server=localhost\\SQLEXPRESS;Database=chat;Trusted_Connection=True;");

            using (var context = new ChatContext(optionsBuilder.Options))
            {
                return await context.Messages.Where(mes=>mes.chat.Id==id).ToListAsync();
            }
        }

        public void SaveMessage(Message mes)
        {
            var optionsBuilder = new DbContextOptionsBuilder<ChatContext>().UseSqlServer("Server=localhost\\SQLEXPRESS;Database=chat;Trusted_Connection=True;");

            using (var context = new ChatContext(optionsBuilder.Options))
            {
                var chat = context.Chats.Include(x => x.Messages).FirstOrDefault(x => x.Id == 1);
                chat.Messages.Add(mes);
               
                context.SaveChanges();
            }
        }
      
    }
}