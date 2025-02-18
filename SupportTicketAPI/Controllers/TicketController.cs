﻿using Microsoft.AspNetCore.Cors;
using Microsoft.AspNetCore.Mvc;
using SupportTicketAPI.Dto;
using SupportTicketAPI.Models;
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
        private ICommentRepository _commentRepository;
        public TicketController(ITicketRepository ticketRepository, ICommentRepository commentRepository)
        {
            _ticketRepository = ticketRepository;   
            _commentRepository = commentRepository;
        }

        // GET: api/<TicketController>
        [HttpGet]
        public  IEnumerable<TicketDTO> GetAll()
        {
            List<TicketDTO> tckets = _ticketRepository.GetAll();            
            return tckets;
           
        }

        // GET api/<TicketController>/5
        [HttpGet("{userId}")]
        public IEnumerable<Ticket> GetByUserId(int userId)
        {
            List<Ticket> tckets = _ticketRepository.GetByUserId(userId);
            return tckets;

        }

        [HttpGet("GetById/{ticketId}")]
        public ActionResult<TicketDTO> GetById(int ticketId)
        {
            TicketDTO tckets = _ticketRepository.GetById(ticketId);
            return tckets;

        }

        [HttpGet("GetTicketDetails/{ticketId}")]
        public ActionResult<TicketDTO> GetTicketDetails(int ticketId)
        {
            TicketDTO ticket = new TicketDTO();
            List<CommentDTO> comments = new List<CommentDTO>();
            ticket = _ticketRepository.GetById(ticketId);
            comments = _commentRepository.GetAllComments(ticketId);
            if(comments.Count > 0)
            {
                ticket.Comments = comments;
            }
            
            return ticket;

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
        [HttpPut("ticketId")]
        public ActionResult Put(int ticketId, TicketCommentDTO tcDto)
        {
            try
            {
                if (ticketId != tcDto.TicketId)
                    return BadRequest("Ticket ID mismatch");

                var ticketToUpdate = _ticketRepository.GetById(ticketId);

                if (ticketToUpdate == null)
                    return NotFound($"Ticket with Id = {ticketId} not found");

                _ticketRepository.AddTicketAndComment(tcDto);
                return NoContent();

            }
            catch (Exception)
            {
                return StatusCode(StatusCodes.Status500InternalServerError,
                    "Error updating data");
            }

            
        }

        // DELETE api/<TicketController>/5
        [HttpDelete("{id}")]
        public void Delete(int id)
        {
        }
    }
}
