﻿using System.ComponentModel.DataAnnotations.Schema;

namespace SupportTicketAPI.Dto
{
    public class TicketDTO
    {
        public int TicketId { get; set; }        
        public int UserId { get; set; }
        public string Title { get; set; }
        public string Description { get; set; }        
        public int StatusId { get; set; } // Open, In Progress, Resolved
        public DateTime CreatedAt { get; set; }
        public DateTime UpdatedAt { get; set; }
    }
}
