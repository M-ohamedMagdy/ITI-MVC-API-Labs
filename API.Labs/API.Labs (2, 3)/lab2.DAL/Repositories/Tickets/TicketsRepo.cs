using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace lab2.DAL;

public class TicketsRepo : GenericRepo<Ticket>, ITicketsRepo
{
    private readonly myContext context;
    public TicketsRepo(myContext _context) : base(_context)
    {
        context = _context;
    }
    public IQueryable<Ticket> GetTicketsDetails()
    {
        return context.Set<Ticket>().Include(t => t.Department).Include(t => t.Developers);
    }
    public Ticket? GetTicketById(int id)
    {
        return context.Set<Ticket>().Include(t => t.Department).Include(t => t.Developers).FirstOrDefault(t => t.Id == id);
    }
    public void Add(Ticket item)
    {
        context.Set<Ticket>().Add(item);
    }
    public Ticket? GetTicketForUpdate(int id)
    {
        return context.Set<Ticket>().Include(t => t.Developers).FirstOrDefault(t => t.Id == id);
    }
    public void Update(Ticket item)
    {
        // Useless as Tracking is ON
    }
    public void Delete(Ticket item)
    {
        context.Set<Ticket>().Remove(item);
    }

    
}
