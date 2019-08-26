using DomainModels;
using Models;
using System;
using System.Collections.Generic;
using System.Text;

namespace Business
{
    public interface IRoundResultService
    {

        IEnumerable<RoundResults> GetAll();
        void StartNewDraw();
    }
}
