using SupportTicketAPI.Dto;
using SupportTicketAPI.Models;
namespace SupportTicketAPI.Repositories
{
    public interface ITicketRepository
    {
        public  void AddTicketAndCommentAsync(TicketCommentDTO ticketDetails);
        public void AddComment(TicketCommentDTO ticketDetails);

        public List<Ticket> GetAll();

        public List<Ticket> GetByUserId(int userId);

        public Ticket GetById(int ticketId);
    }
}
