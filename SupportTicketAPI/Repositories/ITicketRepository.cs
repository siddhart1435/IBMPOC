using SupportTicketAPI.Dto;
using SupportTicketAPI.Models;
namespace SupportTicketAPI.Repositories
{
    public interface ITicketRepository
    {
        public  void AddTicketAndComment(TicketCommentDTO ticketDetails);
        public void AddTicket(TicketDTO ticket);

        public List<TicketDisplayDTO> GetAll();

        public List<TicketDisplayDTO> GetByUserId(int userId);

        public TicketDisplayDTO GetById(int ticketId);
    }
}
