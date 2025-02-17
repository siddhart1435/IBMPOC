
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

        //public List<Ticket> GetAll() => _context.Ticket.ToList();

        public List<TicketDTO> GetAll()
        {
            List<TicketDTO> ticketsDto = new List<TicketDTO>();

            var tickets = (from user in _context.Users
                           join tkt in _context.Ticket on user.UserId equals tkt.UserId
                           join status in _context.Status on tkt.StatusId equals status.StatusId
                           select new
                           {
                               TicketId = tkt.TicketId,
                               UserId = tkt.UserId,
                               UserName = user.Name,
                               //UserEmail = user.Email,
                               Title = tkt.Title,
                               Description = tkt.Description,
                               StatusId = tkt.StatusId,
                               Status = status.StatusName,
                               CreatedAt = tkt.CreatedAt
                           }).ToList();
            TicketDTO ticket = new TicketDTO();

            foreach (var ticketDto in tickets)
            {
                ticket.TicketId = ticketDto.TicketId;
                ticket.UserId = ticketDto.UserId;
                ticket.UserName = ticketDto.UserName;
                ticket.Title = ticketDto.Title;
                ticket.Description = ticketDto.Description;
                ticket.StatusId = ticketDto.StatusId;
                ticket.StatusName = ticketDto.Status;
                ticket.CreatedAt = ticketDto.CreatedAt;
                ticketsDto.Add(ticket);

            }
            return ticketsDto;
        }

        public Ticket GetById(int tciketId) => _context.Ticket.FirstOrDefault(x => x.TicketId == tciketId);


        public List<Ticket> GetByUserId(int userId) => _context.Ticket.Where(x => x.UserId == userId).ToList();

        
    }
}
