using lab2.DAL;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace lab2.BL;

public interface ITicketsManager
{
    IQueryable<TicketDetailsVM> GetTicketsDetails();
    TicketDetailsVM? GetTicketById(int id);
    TicketUpdateVM? GetTicketForUpdate(int id);
    void AddNewTicket (TicketAddVM ticket);
    void UpdateTicket (TicketUpdateVM ticket);
    void RemoveTicket (int id);
}
