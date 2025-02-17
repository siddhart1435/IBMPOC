using SupportTicketAPI.Dto;
using SupportTicketAPI.Models;
namespace SupportTicketAPI.Repositories
{
    public interface ITicketRepository
    {
        public  void AddTicketAndCommentAsync(TicketCommentDTO ticketDetails);
        public void AddComment(TicketCommentDTO ticketDetails);

        public List<TicketDTO> GetAll();

        public List<Ticket> GetByUserId(int userId);

        public Ticket GetById(int ticketId);
    }
}
