using lab2.BL;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace lab2.APIs;

[Route("api/[controller]")]
[ApiController]
public class TicketsController : ControllerBase
{
    private readonly ITicketsManager ticketsManager;
    public TicketsController(ITicketsManager _ticketsManager)
    {
        ticketsManager = _ticketsManager;
    }
    [HttpGet]
    public ActionResult<IQueryable<TicketDetailsVM>> GetAll()
    {
        IQueryable<TicketDetailsVM> tickets = ticketsManager.GetTicketsDetails();
        return Ok(tickets);
    }
    [HttpGet]
    [Route("{id}")]
    public ActionResult<TicketDetailsVM> GetOne(int id)
    {
        TicketDetailsVM? ticket = ticketsManager.GetTicketById(id);
        if (ticket == null) return NotFound();
        return Ok(ticket);
    }
    [HttpPost]
    public IActionResult Add(TicketAddVM ticket)
    {
        ticketsManager.AddNewTicket(ticket);
        return NoContent();
    }
    [HttpPut]
    [Route("{id}")]
    public IActionResult Update(TicketUpdateVM ticket, int id)
    {
        if(ticket.Id != id) return BadRequest();
        ticketsManager.UpdateTicket(ticket);
        return CreatedAtAction(
            actionName: nameof(GetOne),
            routeValues: new { id = ticket.Id },
            value: "Successfully Updated");
    }
    [HttpDelete]
    public IActionResult Delete(int id) 
    { 
        ticketsManager.RemoveTicket(id);
        return NoContent();
    }
}
