using System;
using System.Collections.Generic;
using System.Text;
using Data;
using DomainModels;
using Models;
using System.Linq;
namespace Business
{
    public class TicketService : ITicketService
    {

        private readonly IRepository<Ticket> _ticketRepository;
        private readonly IRepository<RoundResults> _roundResultRepository;


        public TicketService(IRepository<Ticket> ticketRepository, IRepository<RoundResults> roundResultRepository)
        {
            _ticketRepository = ticketRepository;
            _roundResultRepository = roundResultRepository;

        }



        public void CreateTicket(int userId, TicketsModel model)
        {
            var allRounds = _roundResultRepository.GetAll();
            var lastRound = !allRounds.Any() ? 0 : allRounds.Max(x => x.RoundId);
            var ticket = new Ticket
            {
                Combination = model.Combination,
                UserId = model.UserId,
                Status = 1,
                AwardBalance = 0,
                Round = lastRound+1

            };

            _ticketRepository.Add(ticket);


        }

        public IEnumerable<TicketsModel> GetAllTickets()
        {
            throw new NotImplementedException();
        }

        public IEnumerable<TicketsModel> GetAllTicketsByUser(int userId)
        {
            return _ticketRepository
                .GetAll()
                .Where(x => x.UserId == userId)
                .Select(x => new TicketsModel
                {
                    Id = x.Id,
                    UserId = x.UserId,
                    AwardBalance = x.AwardBalance,
                    Combination = x.Combination,
                    Round = x.Round,
                    Status = x.Status
                }).ToList();
        }
    }
}
