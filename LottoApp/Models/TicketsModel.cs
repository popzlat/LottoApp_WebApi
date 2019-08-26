using System;
using System.Collections.Generic;
using System.Text;

namespace Models
{
     public class TicketsModel
    {
        public int Id { get; set; }
        public string Combination { get; set; }
        public int UserId { get; set; }
        public int Round { get; set; }
        public int Status { get; set; }
        public int AwardBalance { get; set; }

    }
}
