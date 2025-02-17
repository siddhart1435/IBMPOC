using Microsoft.EntityFrameworkCore;
using SupportTicketAPI.Models;

namespace SupportTicketAPI.Data
{
    public class ApplicationDBContext : DbContext
    {
        public ApplicationDBContext(DbContextOptions<ApplicationDBContext> options) : base(options) { } 
        public DbSet<User> Users { get; set; }
        public DbSet<Ticket> Ticket { get; set; }
        public DbSet<Comment> Comments { get; set; }

        public DbSet<Status> Status { get; set; }
    }
}
