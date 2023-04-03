using lab2.DAL;
using System;
using System.Collections.Generic;
using System.ComponentModel.Design;
using System.Linq;
using System.Net.Sockets;
using System.Text;
using System.Threading.Tasks;

namespace lab2.BL;

public class TicketsManager : ITicketsManager
{
    private readonly ITicketsRepo ticketsRepo;
    private readonly IDevelopersRepo devRepo;
    public TicketsManager(ITicketsRepo _ticketsRepo, IDevelopersRepo _DevRepo)
    {
        ticketsRepo = _ticketsRepo;
        devRepo = _DevRepo;
    }
    public void AddNewTicket(TicketAddVM ticket)
    {
        var devs = devRepo.GetAll().Where(d => ticket.Developers.Contains(d.Id)).ToHashSet();
        Ticket newTicket = new()
        {
            Description = ticket.Description,
            EstimationCost = ticket.EstimationCost,
            DeptId = ticket.Department,
            Developers = devs
        };
        ticketsRepo.SaveChanges();
    }

    public TicketDetailsVM? GetTicketById(int id)
    {
        Ticket? ticket = ticketsRepo.GetTicketById(id);
        if (ticket == null) return null;
        TicketDetailsVM ticketToView = new TicketDetailsVM(
            ticket.Description,
            ticket.Severity.ToString() ?? "",
            ticket.Department?.Name ?? "",
            ticket.Developers.Count
            );

        return ticketToView;
    }

    public IQueryable<TicketDetailsVM> GetTicketsDetails()
    {
        return ticketsRepo.GetTicketsDetails().Select(t => new TicketDetailsVM(
            t.Description,
            t.Severity.ToString() ?? "",
            t.Department.Name,
            t.Developers.Count
            ));
    }

    public TicketUpdateVM? GetTicketForUpdate(int id)
    {
        Ticket? ticket = ticketsRepo.GetTicketForUpdate(id);
        if (ticket == null) return null;
        TicketUpdateVM ticketToUpdate = new TicketUpdateVM(
            id,
            ticket.Description,
            ticket.EstimationCost,
            ticket.Department?.Id ?? -1,
            ticket.Developers.Select(d => d.Id).ToHashSet()
            );

        return ticketToUpdate;
    }

    public void RemoveTicket(int id)
    {
        Ticket? ticketToRemove = ticketsRepo.GetTicketById(id);
        if(ticketToRemove == null) return;
        ticketsRepo.Delete(ticketToRemove);
        ticketsRepo.SaveChanges();
    }

    public void UpdateTicket(TicketUpdateVM ticket)
    {
        Ticket? ticketToUpdate = ticketsRepo.GetTicketForUpdate(ticket.Id);
        if (ticketToUpdate == null) return;
        
        var devs = devRepo.GetAll().Where(d => ticket.Developers.Contains(d.Id)).ToHashSet();

        ticketToUpdate.Description = ticket.Description;
        ticketToUpdate.EstimationCost = ticket.EstimationCost;
        ticketToUpdate.DeptId = ticket.Department;
        
        if (devs == null) return;
        ticketToUpdate.Developers = devs;

        ticketsRepo.SaveChanges();
    }
}
