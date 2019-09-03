using System;
using System.Collections.Generic;
using System.Text;
using Data;
using DomainModels;
using Models;
using System.Linq;
using Business.Exceptions;

namespace Business
{
    public class TicketService : ITicketService
    {

        private readonly IRepository<Ticket> _ticketRepository;
        private readonly IRepository<RoundResults> _roundResultRepository;
        private readonly IRepository<User> _userRepository;


        public TicketService(IRepository<Ticket> ticketRepository, IRepository<RoundResults> roundResultRepository, IRepository<User> userRepository)
        {
            _ticketRepository = ticketRepository;
            _roundResultRepository = roundResultRepository;
            _userRepository = userRepository;

        }

        public void CreateTicket(int userId, TicketsModel model)
        {
            var allRounds = _roundResultRepository.GetAll();
            var lastRound = !allRounds.Any() ? 0 : allRounds.Max(x => x.RoundId);

            var currentUser = _userRepository.GetAll().FirstOrDefault(x => x.Id == userId);

            var ticket = new Ticket
            {
                Combination = model.Combination,
                UserId = currentUser.Id,
                Status = 1,
                AwardBalance = 0,
                Round = lastRound+1
               
            };

            if (currentUser.Ballance >= 50)
            {
                currentUser.Ballance = currentUser.Ballance - 50;
            }
            else
            {
                throw new LotoExceptions("You dont have money for ticket , wait until you get salary");
            }

            _ticketRepository.Add(ticket);
            _userRepository.Update(currentUser);

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
