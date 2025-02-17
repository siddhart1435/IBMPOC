using SupportTicketAPI.Models;

namespace SupportTicketAPI.Repositories
{
    public interface ICommentRepository
    {
        public List<Comment> GetAllComments(int ticketId);
    }
}
