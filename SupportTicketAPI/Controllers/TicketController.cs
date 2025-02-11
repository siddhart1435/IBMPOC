using Microsoft.AspNetCore.Cors;
using Microsoft.AspNetCore.Mvc;
using SupportTicketAPI.Dto;
using SupportTicketAPI.Repositories;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace SupportTicketAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    [EnableCors("AngularProject")]
    public class TicketController : ControllerBase
    {
        private ITicketRepository _ticketRepository;
        public TicketController(ITicketRepository ticketRepository)
        {
            _ticketRepository = ticketRepository;   
        }

        // GET: api/<TicketController>
        [HttpGet]
        public IEnumerable<string> Get()
        {
            return new string[] { "value1", "value2" };
        }

        // GET api/<TicketController>/5
        [HttpGet("{id}")]
        public string Get(int id)
        {
            return "value";
        }

        // POST api/<TicketController>
        [HttpPost]
        public  ActionResult Post(TicketCommentDTO tcDto)
        {
            if (tcDto != null)
            {
                _ticketRepository.AddComment(tcDto);
                return NoContent();
            }
            return NotFound();
        }

        // PUT api/<TicketController>/5
        [HttpPut("{id}")]
        public void Put(int id, [FromBody] string value)
        {
        }

        // DELETE api/<TicketController>/5
        [HttpDelete("{id}")]
        public void Delete(int id)
        {
        }
    }
}
