using SupportTicketAPI.Models;

namespace SupportTicketAPI.Repositories
{
    public interface IUserRepository
    {
        public User GetUserById(int id);
        
    }
}
