
using SupportTicketAPI.Data;
using SupportTicketAPI.Dto;
using SupportTicketAPI.Models;

namespace SupportTicketAPI.Repositories
{
    public class TicketRepository : ITicketRepository
    {
        private readonly ApplicationDBContext _context;

        public TicketRepository(ApplicationDBContext  context)
        {
            _context = context;
        }
        public void AddComment(TicketCommentDTO ticketComment)
        {
            // Create a new ticket
            var ticket = new Ticket
            {
                UserId = ticketComment.UserId,
                Title = ticketComment.Title,
                Description = ticketComment.Description,
                StatusId = ticketComment.StatusId,
                CreatedAt = DateTime.UtcNow,
                UpdatedAt = DateTime.UtcNow

            };

            _context.Ticket.Add(ticket);
             _context.SaveChanges();  // Save changes to generate TicketId

            // Create a new comment associated with the ticket
            //var comment = new Comment
            //{
            //    UserId = ticketComment.UserId,
            //    TicketId = ticket.TicketId,
            //    Content = ticketComment.Content,
            //    CreatedAt = DateTime.UtcNow

            //};

            //_context.Comments.Add(comment);
            // _context.SaveChanges();


        }

        public void AddTicketAndCommentAsync(TicketCommentDTO ticketComment)
        {
            // Update the ticket
            var ticket = new Ticket
            {
                TicketId = ticketComment.TicketId,
                //UserId = ticketComment.UserId,
                StatusId = ticketComment.StatusId,
                UpdatedAt = DateTime.UtcNow

            };

            _context.Ticket.Update(ticket);
            _context.SaveChangesAsync();  // Save changes to generate TicketId

            // Create a new comment associated with the ticket
            var comment = new Comment
            {
                UserId = ticketComment.UserId,
                TicketId = ticket.TicketId,
                Content = ticketComment.Content,
                CreatedAt = DateTime.UtcNow

            };

            _context.Comments.Add(comment);
            _context.SaveChangesAsync();
        }

        public List<Ticket> GetAll() => _context.Ticket.ToList();

        public Ticket GetById(int tciketId) => _context.Ticket.FirstOrDefault(x => x.TicketId == tciketId);


        public List<Ticket> GetByUserId(int userId) => _context.Ticket.Where(x => x.UserId == userId).ToList();
        
    }
}
