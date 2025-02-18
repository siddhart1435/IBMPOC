using SupportTicketAPI.Data;
using SupportTicketAPI.Dto;
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
        //public List<Comment> GetAllComments(int ticketId) => _context.Comments.Where(x=>x.TicketId == ticketId).ToList();

        public List<CommentDTO> GetAllComments(int ticketId)
        {
            List<CommentDTO> comments = new List<CommentDTO>();
            var coms = (from comment in _context.Comments
                        join user in _context.Users on comment.UserId equals user.UserId
                        select new
                        {
                            Id = comment.Id,
                            TicketId = comment.TicketId,
                            UserName = user.Name,
                            UserId = comment.UserId,
                            Content = comment.Content,
                            CreatedAt = comment.CreatedAt
                        }).OrderByDescending(x => x.CreatedAt).ToList();

            CommentDTO comment1 ;
            foreach (var item in coms)
            {
                comment1 = new CommentDTO();
                comment1.Id = item.Id;
                comment1.TicketId = item.TicketId;
                comment1.UserId = item.UserId;
                comment1.Content = item.Content;
                comment1.CreatedAt = item.CreatedAt;
                comment1.UserName = item.UserName;
                comments.Add(comment1);
            }
            return comments;
        }


    }
}
