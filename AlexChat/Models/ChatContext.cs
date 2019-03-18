using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;

namespace AlexChat.Models
{
    public class ChatContext : IdentityDbContext<User>
    {
       
        public ChatContext()
            : base()
        {
            Chat c = new Chat { Id = 1 };
            Database.Migrate();
        }

        public DbSet<Chat> Chats { get; set; }
        public DbSet<Message> Messages { get; set; }

        public DbSet<UserChat> UserChats { get; set; }
        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);
            modelBuilder.Entity<UserChat>().HasKey(uc => new { uc.UserId, uc.ChatId });
            modelBuilder.Entity<Chat>().HasData(new Chat {  Id = 1 });
        }
        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            optionsBuilder.UseSqlServer("Server=localhost\\SQLEXPRESS;Database=chat;Trusted_Connection=True;");
        }
    }
}
