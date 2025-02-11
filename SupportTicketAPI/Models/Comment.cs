using System.ComponentModel.DataAnnotations.Schema;

namespace SupportTicketAPI.Models
{
    public class Comment
    {
        public int Id { get; set; }
        public string Content { get; set; }

        // Foreign key and navigation property for User
        
        public int UserId { get; set; }
        public User User { get; set; }

        // Foreign key and navigation property for Ticket
        [ForeignKey("Ticket")]
        public int TicketId { get; set; }
        public Ticket Ticket { get; set; }

        public DateTime CreatedAt { get; set; }
    }
}