using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Business;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Models;

namespace LottoApp.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class TicketController : ControllerBase
    {


        private readonly ITicketService _ticketService;

        public TicketController(ITicketService ticketService)
        {
            _ticketService = ticketService;
        }
        // GET: api/Ticket
        [Route("byUser/{id}")]
        [HttpGet]
        public IEnumerable<TicketsModel> Get( int id)
        {
            return _ticketService.GetAllTicketsByUser(id);
        }

        
        // POST: api/Ticket
        [HttpPost]
        public void Post([FromBody] TicketsModel model)
        {
            _ticketService.CreateTicket(model.UserId, model);
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
    }
}
