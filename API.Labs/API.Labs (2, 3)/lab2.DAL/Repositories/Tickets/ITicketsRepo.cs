using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace lab2.DAL;

public interface ITicketsRepo : IGenericRepo<Ticket>
{
    IQueryable<Ticket> GetTicketsDetails();
    Ticket? GetTicketById(int id);
    void Add(Ticket item);
    Ticket? GetTicketForUpdate(int id);
    void Update(Ticket item);
    void Delete(Ticket item);
}
