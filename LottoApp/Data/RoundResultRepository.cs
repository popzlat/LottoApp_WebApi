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
            throw new NotImplementedException();
        }

        public void Delete(RoundResults entity)
        {
            throw new NotImplementedException();
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
            throw new NotImplementedException();
        }

        public void Update(RoundResults entity)
        {
            throw new NotImplementedException();
        }
    }
}
