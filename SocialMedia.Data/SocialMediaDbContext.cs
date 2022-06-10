using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;
using SocialMedia.Model;
using System;
using System.Collections.Generic;
using System.Text;

namespace SocialMedia.Data
{
    public class SocialMediaDbContext : IdentityDbContext

    {
        public SocialMediaDbContext(DbContextOptions options) : base(options)
        {
        }

        public DbSet<User> User { get; set; }

        public DbSet<Comment> Comment { get; set; }

        public DbSet<Friend> Friend { get; set; }

        public DbSet<LikeDislike> LikeDislike { get; set; }


        public DbSet<Message> Message { get; set; }

        public DbSet<Post> Post { get; set; }


       

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);

            modelBuilder.Entity<Friend>()
               .HasOne(m => m.ToUser)
               .WithMany(m => m.ToFriends)
               .HasForeignKey(m => m.ToUserId)
               .OnDelete(DeleteBehavior.Restrict);

            modelBuilder.Entity<Friend>()
                .HasOne(m => m.FromUser)
                .WithMany(m => m.FromFriends)
                .HasForeignKey(m => m.FromUserId)
                .OnDelete(DeleteBehavior.Restrict);

            modelBuilder.Entity<Message>()
                .HasOne(m => m.ToUser)
                .WithMany(m => m.ToMessages)
                 .HasForeignKey(m => m.ToUserId)
                .OnDelete(DeleteBehavior.Restrict);
            
            modelBuilder.Entity<Message>()
                .HasOne(m => m.FromUser)
                .WithMany(m => m.FromMessages)
                .HasForeignKey(m => m.FromUserId)
                .OnDelete(DeleteBehavior.Restrict);

            modelBuilder.Entity<Post>()
                .HasOne(c => c.User)
                .WithMany(m => m.Posts)
                .OnDelete(DeleteBehavior.Restrict);

            modelBuilder.Entity<Comment>()
                .HasOne(s => s.User)
                .WithMany(m => m.Comments)
                .OnDelete(DeleteBehavior.Restrict);
        }

    }
}
