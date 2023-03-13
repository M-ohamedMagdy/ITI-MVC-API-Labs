using lab2.Models.Domain;
using lab2.Models.View;
using Microsoft.AspNetCore.Mvc;

namespace lab2.Controllers;

public class TicketsController : Controller
{
    public IActionResult Index()
    {
        return View(Ticket.TicketList);
    }

    [HttpGet]
    public IActionResult TicketForm()
    {
        return View();
    }

    [HttpPost]
    public IActionResult AddTicket(TicketVM ticketVM) 
    {
        var AddNewTicket = new Ticket()
        {
            CreatedDate= ticketVM.CreatedDate,
            IsClosed= ticketVM.IsClosed,
            Description=ticketVM.Description,
            Severity=ticketVM.Severity,
        };

        Ticket.TicketList?.Add(AddNewTicket);

        return RedirectToAction(nameof(Index));
    }
}
