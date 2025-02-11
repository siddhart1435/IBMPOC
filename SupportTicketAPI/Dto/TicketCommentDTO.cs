using SupportTicketAPI.Models;
using System.ComponentModel.DataAnnotations.Schema;

namespace SupportTicketAPI.Dto
{
    public class TicketCommentDTO
    {
        public int TicketId { get; set; }        
        public int UserId { get; set; }

        public string Title { get; set; }
        public string Description { get; set; }
        
        public int StatusId { get; set; } // Open, In Progress, Resolved

        public string Content { get; set; }


    }
}
