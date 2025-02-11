using System.ComponentModel.DataAnnotations.Schema;

namespace SupportTicketAPI.Models
{
    public class Ticket
    {
        public int TicketId { get; set; }

        [ForeignKey("User")]
        public int UserId { get; set; }

        public string Title { get; set; }
        public string Description { get; set; }

        [ForeignKey("Status")]
        public int StatusId { get; set; } // Open, In Progress, Resolved
        public DateTime CreatedAt { get; set; }
        public DateTime UpdatedAt { get; set; }

        public Status Status { get; set; }
        public User User { get; set; }
        public List<Comment> Comments { get; set; }

    }
}
