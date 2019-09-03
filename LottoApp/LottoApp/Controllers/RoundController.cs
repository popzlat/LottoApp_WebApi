using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Business;
using DomainModels;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Models;

namespace LottoApp.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class RoundController : ControllerBase
    {
        private readonly IRoundResultService _roundResultService;
        private readonly ITicketService _ticketService;
        private readonly IUserService _userService;

        public RoundController(ITicketService ticketService, IUserService userService, IRoundResultService roundResultService)
        {
            _roundResultService = roundResultService;
            _userService = userService;
            _ticketService = ticketService;

        }


      
        [Route("drawround")]
        [HttpPost]
        public IActionResult DrawRound()
        {
            _roundResultService.StartNewDraw();
            return Ok($"A new round has started!");
        }

       
        [Route("getresult")]
        [HttpGet]
        public IEnumerable<RoundResults> GetResults()
        {
            return _roundResultService.GetAll();
        }
    }

}
