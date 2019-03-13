using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;

namespace AlexChat.Models
{
    public class ChatContext : DbContext
    {

        public ChatContext(DbContextOptions<ChatContext> options)
            : base(options)
        {
            Chat c = new Chat { Id = 1 };
            Database.Migrate();
        }

        public DbSet<Chat> Chats { get; set; }
        public DbSet<Message> Messages { get; set; }
        public DbSet<User> Users { get; set; }
        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<UserChat>().HasKey(sc => new { sc.UserId, sc.ChatId });
            modelBuilder.Entity<Chat>().HasData(new Chat {  Id = 1 });
        }
        
    }
}
