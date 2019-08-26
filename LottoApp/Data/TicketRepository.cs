using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using DomainModels;
using Microsoft.Extensions.Configuration;

namespace Data
{
    public class TicketRepository : IRepository<Ticket>
    {
        private readonly string _connectionString;

        public TicketRepository(IConfiguration configuration)
        {
            _connectionString = configuration.GetConnectionString("LottoDatabase");

        }

        public void Add(Ticket entity)
        {
            using (var dbContext = new LottoDbContext(_connectionString))
            {
                dbContext.Tickets.Add(entity);
                dbContext.SaveChanges();
            }
        }

        public void Delete(Ticket entity)
        {
            using (var dbContext = new LottoDbContext(_connectionString))
            {
                dbContext.Tickets.Add(entity);
                dbContext.SaveChanges();
            }
        }

        public IEnumerable<Ticket> GetAll()
        {
            using (var dbContext = new LottoDbContext(_connectionString))
            {
                return dbContext.Tickets.ToList();
            }
        }

        public Ticket GetById(int id)
        {
            using (var dbContext = new LottoDbContext(_connectionString))
            {
                return dbContext.Tickets.FirstOrDefault(x => x.Id == id);
            }
        }

        public void Update(Ticket entity)
        {
            using (var dbContext = new LottoDbContext(_connectionString))
            {
                dbContext.Tickets.Update(entity);
                dbContext.SaveChanges();
            }
        }
    }
}
