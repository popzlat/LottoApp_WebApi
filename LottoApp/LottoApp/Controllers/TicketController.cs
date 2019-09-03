using System;
using System.Collections.Generic;
using System.Security.Claims;
using Business;
using Business.Exceptions;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Models;

namespace LottoApp.Controllers
{
    [Authorize]
    [Route("api/[controller]")]
    [ApiController]
    public class TicketController : ControllerBase
    {


        private readonly ITicketService _ticketService;
        private readonly IUserService _userService;
        private readonly IRoundResultService _roundResultService;

        public TicketController(ITicketService ticketService , IUserService userService, IRoundResultService roundResultService)
        {
            _ticketService = ticketService;
            _userService = userService;
            _roundResultService = roundResultService;
        }
        // GET: api/Ticket
        [Route("byUser/{id}")]
        [HttpGet]
        public IEnumerable<TicketsModel> Get( int id)
        {
            var userId = GetUserId();
            return _ticketService.GetAllTicketsByUser(userId);
        }

        
        // POST: api/Ticket
        [HttpPost]
        public void Post([FromBody] TicketsModel model)
        {
            var userId = GetUserId();
            _ticketService.CreateTicket(userId, model);
        }


        

        // PUT: api/Ticket/5
        [HttpPut("{id}")]
        public void Put(int id, [FromBody] string value)
        {

        }

        // DELETE: api/ApiWithActions/5
        [HttpDelete("{id}")]
        public void Delete(int id)
        {
        }

        private int GetUserId()
        {
            if (!int.TryParse(User.FindFirst(ClaimTypes.NameIdentifier).Value, out var userId))
                throw new LotoExceptions("Invalid user Id");

            return userId;
        }
    }
}
