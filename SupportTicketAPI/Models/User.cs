namespace SupportTicketAPI.Models
{
    public class User
    {
        public int UserId { get; set; }
        public string Name { get; set; }
        public string Role { get; set; } // Customer, Support
        public string Email { get; set; }

    }
}
