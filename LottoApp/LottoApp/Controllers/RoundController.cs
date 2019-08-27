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

        public RoundController(ITicketService ticketService, IUserService userService, IRoundResultService roundResultService)
        {
            _roundResultService = roundResultService;
        }

        public RoundController(IRoundResultService roundResultService)
        {
            _roundResultService = roundResultService;
        }

        [Authorize(Roles = "Administrator")]
        [Route("drawround")]
        [HttpPost]
        public IActionResult DrawRound()
        {
            _roundResultService.StartNewDraw();
            return Ok($"A new round has started!");
        }

        [Authorize]
        [Route("getresult")]
        [HttpGet]
        public IEnumerable<RoundResults> GetResults()
        {
            return _roundResultService.GetAll();
        }
    }

}
