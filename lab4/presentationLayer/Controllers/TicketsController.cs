using BusinessLayer;
using BusinessLayer.ViewModels;
using DataAccessLayer.DomainModels;
using Microsoft.AspNetCore.Mvc;

namespace presentationLayer.Controllers
{
    public class TicketsController : Controller
    {
        private readonly ITicketsManager TicketsManager;

        public TicketsController(ITicketsManager _TicketsManager)
        {
            TicketsManager = _TicketsManager;
        }
        public IActionResult Index()
        {
            IEnumerable<EditTicketsVM> AllTickets = TicketsManager.GetAll();
            return View(AllTickets);
        }
        [HttpGet]
        public IActionResult Add() 
        {
            return View();
        }
        [HttpPost]
        public IActionResult Add(AddTicketsVM ticket) 
        {
            TicketsManager.Add(ticket);
            return View();
        }
        public IActionResult Details(Guid id)
        {
            EditTicketsVM? Ticket = TicketsManager.GetById(id);
            return View(Ticket);
        }
        [HttpGet]
        public IActionResult Edit(Guid id) 
        {
            EditTicketsVM? Ticket = TicketsManager.GetById(id);
            return View(Ticket);
        }
        [HttpPost]
        public IActionResult Edit(EditTicketsVM ticket) 
        {
            TicketsManager.Update(ticket);
            return RedirectToAction(nameof(Index));
        }
        public IActionResult Delete(Guid id) 
        {
            TicketsManager.Delete(id);
            return RedirectToAction(nameof(Index));
        }

    }
}
