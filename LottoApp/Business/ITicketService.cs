using DomainModels;
using System;
using System.Collections.Generic;
using System.Text;
using Models;


namespace Business
{
    public interface ITicketService
    {
        IEnumerable<TicketsModel> GetAllTicketsByUser(int userId);
        void CreateTicket(int userId, TicketsModel model);
        IEnumerable<TicketsModel> GetAllTickets();




    }
}
