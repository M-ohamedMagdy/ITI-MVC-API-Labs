using lab2.Models.Domain;
using lab2.Models.View;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;

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
        var Departments = Department.GetDepartments();
        var DepartmentsList = Departments.Select(x => new SelectListItem (x.Name, x.Id.ToString()));
        ViewData["Departments"] = DepartmentsList;

        var Developers = Developer.GetDevelopers();
        var DevelopersList = Developers.Select(d => new SelectListItem($"{d.FirstName} {d.LastName}", d.Id.ToString()));
        ViewData["Developers"] = DevelopersList;

        return View();
    }

    [HttpPost]
    public IActionResult AddTicket(TicketVM ticketVM) 
    {
        var AddedDept = Department.GetDepartments().First(d => d.Id == ticketVM.Department);

        var developers = Developer.GetDevelopers().Where(d => ticketVM.Developers.Contains(d.Id)).ToHashSet();

        var AddNewTicket = new Ticket()
        {
            CreatedDate= ticketVM.CreatedDate,
            IsClosed= ticketVM.IsClosed,
            Description=ticketVM.Description,
            severity=ticketVM.severity,
            Department = AddedDept,
            Developers = developers
        };

        Ticket.TicketList.Add(AddNewTicket);

        return RedirectToAction(nameof(Index));
    }
    [HttpGet]
    public IActionResult EditTicketForm(Guid id)
    {
        var Departments = Department.GetDepartments();
        var DepartmentsList = Departments.Select(x => new SelectListItem(x.Name, x.Id.ToString()));
        ViewData["Departments"] = DepartmentsList;

        var Developers = Developer.GetDevelopers();
        var DevelopersList = Developers.Select(d => new SelectListItem($"{d.FirstName} {d.LastName}", d.Id.ToString()));
        ViewData["Developers"] = DevelopersList;

        var TicketToEdit = Ticket.TicketList.Single(t => t.Id == id);

        var EditTicket = new EditTicketVM
        {
            Id = id,
            CreatedDate = TicketToEdit.CreatedDate,
            IsClosed = TicketToEdit.IsClosed,
            Description = TicketToEdit.Description,
            severity = TicketToEdit.severity,
            Department = TicketToEdit.Department.Id,
            Developers = TicketToEdit.Developers.Select(d => d.Id).ToHashSet(),
        };

        return View(EditTicket);
    }

    [HttpPost]
    public IActionResult EditTicketForm(EditTicketVM editTicketVM)
    {
        var developers = Developer.GetDevelopers().Where(d => editTicketVM.Developers.Contains(d.Id)).ToHashSet();

        var ticket = Ticket.TicketList.Single(t => t.Id == editTicketVM.Id);

        ticket.CreatedDate = editTicketVM.CreatedDate;
        ticket.IsClosed = editTicketVM.IsClosed;
        ticket.Description = editTicketVM.Description;
        ticket.severity = editTicketVM.severity;
        ticket.Department = Department.GetDepartments().First(d => d.Id == editTicketVM.Department);
        ticket.Developers = developers;

        return RedirectToAction(nameof(Index));
    }
    public IActionResult DeleteTicket(Guid id)
    {
        var TicketToRemove = Ticket.TicketList.Single(d => d.Id == id);
        Ticket.TicketList.Remove(TicketToRemove);

        return RedirectToAction(nameof(Index));
    }
}

