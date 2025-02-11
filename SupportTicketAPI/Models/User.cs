using System.ComponentModel.DataAnnotations.Schema;

namespace SupportTicketAPI.Models
{
    public class User
    {
        public int UserId { get; set; }
        public string Name { get; set; }
        [ForeignKey("Role")]
        public int RoleId { get; set; } // Customer, Support
        public string Email { get; set; }

        public string Password { get; set; }

        public Role Role { get; set; }

    }
}
