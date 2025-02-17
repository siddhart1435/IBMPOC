using SupportTicketAPI.Data;
using SupportTicketAPI.Models;

namespace SupportTicketAPI.Repositories
{
    public class CommentRepository : ICommentRepository
    {
        private readonly ApplicationDBContext _context;
        public CommentRepository(ApplicationDBContext context)
        {
            _context = context;
        }
        public List<Comment> GetAllComments(int ticketId) => _context.Comments.Where(x=>x.TicketId == ticketId).ToList();
        
    }
}
