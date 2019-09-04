using Data;
using DomainModels;
using System;
using System.Collections.Generic;
using System.Text;

namespace LottoApp_Tests.FakeRepositories
{
    public class FakeRoundResultRepository : IRepository<RoundResults>
    {
        private readonly List<RoundResults> _rounds;

        public FakeRoundResultRepository()
        {
            _rounds = new List<RoundResults>
            {
                new RoundResults{ Combination= "1,2,3,4,5,6,7",RoundId=1},
                new RoundResults{ Combination= "11,12,13,14,15,16,17",RoundId=2}
        };

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
            return _rounds;
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
