﻿// <auto-generated />
using System;
using AlexChat.Models;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Migrations;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;

namespace AlexChat.Migrations
{
    [DbContext(typeof(ChatContext))]
    [Migration("20190312140629_fk_added")]
    partial class fk_added
    {
        protected override void BuildTargetModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("ProductVersion", "2.1.8-servicing-32085")
                .HasAnnotation("Relational:MaxIdentifierLength", 128)
                .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

            modelBuilder.Entity("AlexChat.Models.Chat", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.HasKey("Id");

                    b.ToTable("Chats");
                });

            modelBuilder.Entity("AlexChat.Models.Message", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<int>("chatId");

                    b.Property<DateTime>("dateTime");

                    b.Property<string>("text");

                    b.HasKey("Id");

                    b.HasIndex("chatId");

                    b.ToTable("Messages");
                });

            modelBuilder.Entity("AlexChat.Models.User", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<string>("Username");

                    b.HasKey("Id");

                    b.ToTable("Users");
                });

            modelBuilder.Entity("AlexChat.Models.UserChat", b =>
                {
                    b.Property<int>("UserId");

                    b.Property<int>("ChatId");

                    b.HasKey("UserId", "ChatId");

                    b.HasIndex("ChatId");

                    b.ToTable("UserChat");
                });

            modelBuilder.Entity("AlexChat.Models.Message", b =>
                {
                    b.HasOne("AlexChat.Models.Chat", "chat")
                        .WithMany()
                        .HasForeignKey("chatId")
                        .OnDelete(DeleteBehavior.Cascade);
                });

            modelBuilder.Entity("AlexChat.Models.UserChat", b =>
                {
                    b.HasOne("AlexChat.Models.Chat", "chat")
                        .WithMany("UserChats")
                        .HasForeignKey("ChatId")
                        .OnDelete(DeleteBehavior.Cascade);

                    b.HasOne("AlexChat.Models.User", "User")
                        .WithMany("UserChats")
                        .HasForeignKey("UserId")
                        .OnDelete(DeleteBehavior.Cascade);
                });
#pragma warning restore 612, 618
        }
    }
}
