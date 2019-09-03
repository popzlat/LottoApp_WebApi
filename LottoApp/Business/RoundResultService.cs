using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Business.Exceptions;
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
            var admin = _userRepository.GetAll().FirstOrDefault(x => x.Role ==0);
            if (admin.Role != 0)
            {
                throw new LotoExceptions("You are not administrator");
            }
            
            
            RoundResults newRound = new RoundResults();

            List<int> numbers = new List<int>();

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

            int roundId = 1;

            if (_roundResultsRepository.GetAll().Count() != 0)
                roundId = _roundResultsRepository.GetAll().Max(x => x.RoundId) + 1;

            //var allRounds = _roundResultsRepository.GetAll();
            //var lastRound = !allRounds.Any() ? 0 : allRounds.Max(x => x.RoundId);
            var tickets = _ticketRepository.GetAll().Where(x => x.Round == roundId).ToList();
           

            var numbersString = string.Join(",", numbers);

             newRound.Combination = numbersString;
            var winCommbinationSplited = numbersString.Split(',');
            var winCombInt = winCommbinationSplited.Select(x => Int32.Parse(x)).ToList();

            

            foreach (var tiket in tickets)
            {
                int count = 0;
                var tiketNumbers =  tiket.Combination.Split(',').Select(x => Int32.Parse(x)).ToList();

                foreach (var number in tiketNumbers)
                {
                    if (winCombInt.Contains(number))
                    {
                        count++;
                    }
                }
                var currentUser = _userRepository.GetById(tiket.UserId);
                if (count >= 4) {
                    switch (count)
                    {
                        case 4:
                            tiket.AwardBalance = 50 * 100;
                            tiket.Status = 2;
                            break;
                        case 5:
                            tiket.AwardBalance = 50 * 1000;
                            tiket.Status = 2;
                            break;
                        case 6:
                            tiket.AwardBalance = 50 * 10000;
                            tiket.Status = 2;
                            break;
                        case 7:
                            tiket.AwardBalance = 50 * 100000;
                            tiket.Status = 2;
                            break;
                        default:
                            tiket.Status = 3;
                            break;
                    }
                }
                currentUser.Ballance = currentUser.Ballance + tiket.AwardBalance;
                _ticketRepository.Update(tiket);
                _userRepository.Update(currentUser);
                _roundResultsRepository.Add(newRound);
            }


            





        }
    }
}
