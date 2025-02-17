using SupportTicketAPI.Models;

namespace SupportTicketAPI.Repositories
{
    public interface IStatusRepository
    {
        public List<Status> GetAll();
        public Status GetById(int statusId);
    }
}
