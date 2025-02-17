using SupportTicketAPI.Data;
using SupportTicketAPI.Models;

namespace SupportTicketAPI.Repositories
{
    public class StatusRepository : IStatusRepository
    {
        ApplicationDBContext _context;

        public StatusRepository(ApplicationDBContext context)
        {
            _context = context;
        }
        public List<Status> GetAll() => _context.Status.ToList();


        public Status GetById(int statusId) => _context.Status.FirstOrDefault(x => x.StatusId == statusId);
        
    }
}
