using BusinessLayer.ViewModels;
using DataAccessLayer.DomainModels;
using DataAccessLayer.Repositories;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Sockets;
using System.Text;
using System.Threading.Tasks;

namespace BusinessLayer;

public class TicketsManager : ITicketsManager
{
    private readonly ITicketsRepo TicketsRepo;

    public TicketsManager(ITicketsRepo _TicketsRepo)
    {
        TicketsRepo = _TicketsRepo;
    }
    public IEnumerable<EditTicketsVM> GetAll()
    {
        IEnumerable<Ticket> _AllTickets = TicketsRepo.GetAll();
        IEnumerable<EditTicketsVM> AllTickets = _AllTickets.Select(t => new EditTicketsVM(t.Id, t.Title, t.Description, t.Severity));
        return AllTickets;
    }
    public EditTicketsVM? GetById(Guid id)
    {
        Ticket? _ticket = TicketsRepo.GetById(id);
        if (_ticket == null) return null;
        EditTicketsVM ticket = new EditTicketsVM(_ticket.Id, _ticket.Title, _ticket.Description, _ticket.Severity);
        return ticket;
    }
    public void Add(AddTicketsVM ticket)
    {
        Ticket TicketToAdd = new Ticket(ticket.Title, ticket.Description, ticket.Severity);
        TicketsRepo.Add(TicketToAdd);
        TicketsRepo.SaveChanges();
    }
    public void Update(EditTicketsVM ticket)
    {
        Ticket? TicketToUpdate = TicketsRepo.GetById(ticket.Id);
        if (TicketToUpdate == null) return;

        TicketToUpdate.Title = ticket.Title;
        TicketToUpdate.Description = ticket.Description;
        TicketToUpdate.Severity = ticket.Severity;
        TicketsRepo.SaveChanges();
    }
    public void Delete(Guid id)
    {
        TicketsRepo.Delete(id);
        TicketsRepo.SaveChanges();
    }
}

