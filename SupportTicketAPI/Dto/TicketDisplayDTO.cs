using SupportTicketAPI.Models;
using System.ComponentModel.DataAnnotations.Schema;

namespace SupportTicketAPI.Dto
{
    public class TicketDisplayDTO
    {
        public int TicketId { get; set; }

        
        public int UserId { get; set; }
        public string UserName { get; set; }

        public string Title { get; set; }
        public string Description { get; set; }

        
        public int StatusId { get; set; } // Open, In Progress, Resolved
        public string StatusName { get; set; }

        public DateTime CreatedAt { get; set; }

        public List<CommentDTO> Comments { get; set; }
        

    }
}
