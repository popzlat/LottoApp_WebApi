using Models;
using System;
using System.Collections.Generic;
using System.Text;

namespace Business
{
    public interface IRoundResultService
    {

        IEnumerable<RoundResultModel> GetAll();
        void StartNewDraw();
    }
}
