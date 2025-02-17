using System.ComponentModel.DataAnnotations.Schema;

namespace SupportTicketAPI.Models
{
    public class Comment
    {
        public int Id { get; set; }
        public string Content { get; set; }
        public int UserId { get; set; }
        public int TicketId { get; set; }
        public DateTime CreatedAt { get; set; }
    }
}