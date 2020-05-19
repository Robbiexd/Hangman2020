using System;
using System.Collections.Generic;
using System.Text;
using Hangman2020.Data.Models;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;

namespace Hangman2020.Data
{
    public class ApplicationDbContext : IdentityDbContext
    {
        public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options) : base(options)
        {

        }

        public DbSet<User> ApplicationUsers { get; set; }
        public DbSet<Category> Categories { get; set; }
        public DbSet<Word> Words { get; set; }
        public DbSet<GuessedWord> GuessedWords { get; set; }

        protected override void OnModelCreating(ModelBuilder builder)
        {
            base.OnModelCreating(builder);

            builder.Entity<Category>().HasData(new Category { Id = 1, Name = "weby"});
            builder.Entity<Category>().HasData(new Category { Id = 2, Name = "prg" });

            builder.Entity<Word>().HasData(new Word { Id = 1, Text = "Doména", CategoryId = 1 });
            builder.Entity<Word>().HasData(new Word { Id = 2, Text = "Dependency Injection", CategoryId = 1 });
            builder.Entity<Word>().HasData(new Word { Id = 3, Text = "AddTransient", CategoryId = 1 });
            builder.Entity<Word>().HasData(new Word { Id = 4, Text = "AddSingleton", CategoryId = 1 });
            builder.Entity<Word>().HasData(new Word { Id = 5, Text = "react", CategoryId = 1 });

            builder.Entity<Word>().HasData(new Word { Id = 6, Text = "xamarin", CategoryId = 2 });
            builder.Entity<Word>().HasData(new Word { Id = 7, Text = "c#", CategoryId = 2 });

            //builder.Entity<IdentityUserRole<string>>().HasData(new IdentityUserRole<string> { RoleId = "user1", UserId = "user1" });
            var hasher = new PasswordHasher<User>();

            builder.Entity<User>().HasData(new User
            {
                Id = "user1",
                UserName = "player1@pslib.cz",
                Email = "player1@pslib.cz",
                NormalizedEmail = "player1@pslib.cz".ToUpper(),
                NormalizedUserName = "player1@pslib.cz".ToUpper(),
                TwoFactorEnabled = false,
                EmailConfirmed = true,
                LockoutEnabled = true,
                PhoneNumberConfirmed = false,
                PasswordHash = hasher.HashPassword(null, "hangmyself123."),
                SecurityStamp = string.Empty
            });
        }
    }
}
