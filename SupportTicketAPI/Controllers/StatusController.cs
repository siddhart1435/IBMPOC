using Microsoft.AspNetCore.Cors;
using Microsoft.AspNetCore.Mvc;
using SupportTicketAPI.Models;
using SupportTicketAPI.Repositories;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace SupportTicketAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    [EnableCors("AngularProject")]
    public class StatusController : ControllerBase
    {
        private IStatusRepository _statusRepository;
        public StatusController(IStatusRepository statusRepository)
        {
            _statusRepository = statusRepository;
        }

        // GET: api/<StatusController>
        [HttpGet]
        public IEnumerable<Status> Get()
        {
            return _statusRepository.GetAll();
        }

        // GET api/<StatusController>/5
        [HttpGet("{id}")]
        public Status Get(int id)
        {
            return _statusRepository.GetById(id);
        }

        // POST api/<StatusController>
        [HttpPost]
        public void Post([FromBody] string value)
        {
        }

        // PUT api/<StatusController>/5
        [HttpPut("{id}")]
        public void Put(int id, [FromBody] string value)
        {
        }

        // DELETE api/<StatusController>/5
        [HttpDelete("{id}")]
        public void Delete(int id)
        {
        }
    }
}
