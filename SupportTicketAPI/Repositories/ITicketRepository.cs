using SupportTicketAPI.Dto;
namespace SupportTicketAPI.Repositories
{
    public interface ITicketRepository
    {
        public  void AddTicketAndCommentAsync(TicketCommentDTO ticketDetails);
        public void AddComment(TicketCommentDTO ticketDetails);
    }
}
