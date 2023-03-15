using DataAccessLayer.Context;
using DataAccessLayer.DomainModels;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataAccessLayer.Repositories;

public class TicketsRepo : ITicketsRepo
{
    private readonly myContext context;

    public TicketsRepo(myContext _context)
    {
        context = _context;
    }
    public IEnumerable<Ticket> GetAll()
    {
        return context.Set<Ticket>().AsNoTracking();
    }
    public Ticket? GetById(Guid id)
    {
        return context.Set<Ticket>().Find(id);
    }
    public void Add(Ticket ticket)
    {
        context.Set<Ticket>().Add(ticket);
    }
    public void Update(Ticket ticket)
    {
        context.Set<Ticket>().Update(ticket);
    }
    public void Delete(Guid id)
    {
        var ticket = GetById(id);
        if(ticket != null) { context.Set<Ticket>().Remove(ticket); }       
    }
    public int SaveChanges()
    {
        return context.SaveChanges();
    }
}
