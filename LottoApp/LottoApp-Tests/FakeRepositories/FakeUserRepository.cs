using Data;
using DomainModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace LottoApp_Tests.FakeRepositories
{
    public class FakeUserRepository : IRepository<User>
    {
        private readonly List<User> _users;

        public FakeUserRepository()
        {

            _users = new List<User>
            {
                new User {Id = 1, FirstName = "Test", LastName = "Test", Password = "Test", Ballance= 200 , Username = "Test",UserTickets = new List<Ticket>() ,Role =1},
                new User {Id = 2, FirstName = "Test", LastName = "Test", Password = "Test", Ballance= 200 , Username = "Test",UserTickets = new List<Ticket>(),Role =0}

            };
        }
        public void Add(User entity)
        {
            entity.Id = _users.Max(x => x.Id) + 1;
            _users.Add(entity);
        }

        public void Delete(User entity)
        {
            throw new NotImplementedException();
        }

        public IEnumerable<User> GetAll()
        {
            throw new NotImplementedException();
        }

        public User GetById(int id)
        {
            throw new NotImplementedException();
        }

        public void Update(User entity)
        {
            throw new NotImplementedException();
        }
    }
}
