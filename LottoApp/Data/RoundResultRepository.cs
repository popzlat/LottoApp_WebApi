using DomainModels;
using Microsoft.Extensions.Configuration;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Data
{
    public class RoundResultRepository : IRepository<RoundResults>
    {

        private readonly string _connectionString;

        public RoundResultRepository(IConfiguration configuration)
        {
            _connectionString = configuration.GetConnectionString("LottoDatabase");

        }
        public void Add(RoundResults entity)
        {
            using (var dbContext = new LottoDbContext(_connectionString))
            {
                dbContext.RoundResults.Add(entity);
                dbContext.SaveChanges();
            }
        }

        public void Delete(RoundResults entity)
        {
            using (var dbContext = new LottoDbContext(_connectionString))
            {
                dbContext.RoundResults.Add(entity);
                dbContext.SaveChanges();
            }
        }

        public IEnumerable<RoundResults> GetAll()
        {
            using (var dbContext = new LottoDbContext(_connectionString))
            {
                return dbContext.RoundResults.ToList();
            }
        }

        public RoundResults GetById(int id)
        {
            using (var dbContext = new LottoDbContext(_connectionString))
            {
                return dbContext.RoundResults.FirstOrDefault(x => x.RoundId == id);
            }
        }

        public void Update(RoundResults entity)
        {
            using (var dbContext = new LottoDbContext(_connectionString))
            {
                dbContext.RoundResults.Update(entity);
                dbContext.SaveChanges();
            }
        }
    }
}
