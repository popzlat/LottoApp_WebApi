using Data;
using DomainModels;
using System;
using System.Collections.Generic;
using System.Text;

namespace LottoApp_Tests.FakeRepositories
{
    public class FakeTicketRepository : IRepository<Ticket>
    {
        private readonly List<Ticket> _tickets;

        public FakeTicketRepository()
        {
            _tickets = new List<Ticket>()
            {
                new Ticket() {Id = 1,Combination="1,2,3,4,5,6,7",Round =2 , UserId =1 },
                new Ticket() {Id =2 ,Combination="1,2,3,4,5,6,7",Round =2 , UserId =2 },

            };
        }
        public void Add(Ticket entity)
        {
            _tickets.Add(entity);
        }

        public void Delete(Ticket entity)
        {
            throw new NotImplementedException();
        }

        public IEnumerable<Ticket> GetAll()
        {
            throw new NotImplementedException();
        }

        public Ticket GetById(int id)
        {
            throw new NotImplementedException();
        }

        public void Update(Ticket entity)
        {
            throw new NotImplementedException();
        }
    }
}
