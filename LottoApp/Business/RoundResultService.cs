using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Data;
using DomainModels;
using Models;

namespace Business
{
    public class RoundResultService : IRoundResultService
    {
        private readonly IRepository<Ticket> _ticketRepository;
        private readonly IRepository<User> _userRepository;
        private readonly IRepository<RoundResults> _roundResultsRepository;

        public RoundResultService(IRepository<Ticket> ticketRepository, IRepository<User> userRepository, IRepository<RoundResults> roundResultsRepository)
        {
            _ticketRepository = ticketRepository;
            _userRepository = userRepository;
            _roundResultsRepository = roundResultsRepository;
        }

        public IEnumerable<RoundResults> GetAll()
        {
           return _roundResultsRepository.GetAll().ToList();
        }

        public void StartNewDraw()
        {
            //ako ne e admin a admin e 1 
            if (_userRepository.GetById(1).Id != 1  )
            {
                throw new Exception("Only administrator can start new draw");
            }

            RoundResults newRound = new RoundResults();

            ArrayList numbers = new ArrayList();

            Random RandomClass = new Random();

            int randomNumber;

            for (int i = 0; i < 7; i++)
            {
                do
                {
                    randomNumber = RandomClass.Next(1, 37);
                }
                while (numbers.Contains(randomNumber));

                numbers.Add(randomNumber);
            }
            numbers.Sort();

            var allRounds = _roundResultsRepository.GetAll();
            var lastRound = !allRounds.Any() ? 0 : allRounds.Max(x => x.RoundId);
            var tickets = _ticketRepository.GetAll().Select(x => x.Round == lastRound).ToList();

            var numbersString = string.Join(",", numbers);

             newRound.Combination = numbersString;



        }
    }
}
