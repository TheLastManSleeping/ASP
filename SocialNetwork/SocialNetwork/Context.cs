using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;
using SocialNetwork.Models;

namespace SocialNetwork
{
    public class ApplicationContext : IdentityDbContext<User>
    {
        public DbSet<Friend> Friend { get; set; }
        public DbSet<Dialog> Dialog { get; set; }
        public DbSet<Message> Message { get; set; }
        public ApplicationContext(DbContextOptions<ApplicationContext> options)
            : base(options)
        {
            Database.EnsureCreated();
        }
    }
}