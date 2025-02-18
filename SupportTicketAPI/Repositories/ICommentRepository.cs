using SupportTicketAPI.Dto;
using SupportTicketAPI.Models;

namespace SupportTicketAPI.Repositories
{
    public interface ICommentRepository
    {
        public List<CommentDTO> GetAllComments(int ticketId);
    }
}
