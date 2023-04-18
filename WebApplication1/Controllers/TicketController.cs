using EventSystem.Models;
using Microsoft.EntityFrameworkCore;
using EventSystem.Helpers;
using Microsoft.AspNetCore.Mvc;
using System.Diagnostics;

namespace EventSystem.Controllers
{
    [Route("api[controller]")]
    [ApiController]    
    public class TicketController : ControllerBase
    {
        private readonly DataContext Context;

        public TicketController(DataContext dataContext) {
            Context = dataContext;
        }

        [HttpGet]
        public async Task<ActionResult<List<Ticket>>> Get() {
            return Ok(await Context.Tickets.ToListAsync());
        }
        [HttpPost]
        public async Task<ActionResult<List<Ticket>>> AddTicket(Ticket ticket)
        {
            Context.Tickets.Add(ticket);

            //var currEvents = Context.Events;
            Event thisEvent = Context.Events.FirstOrDefault(e => e.Id == ticket.EventId);
            if (thisEvent == null) 
            {
                return BadRequest("Event not found");
            }
   
            //thisEvent.TicketsAvailable -= ticket.Quantity;
            if(thisEvent.TicketsAvailable - ticket.Quantity < 0)
            {
                return BadRequest("Not enough tickets availble only " + thisEvent.TicketsAvailable + " left");
            }
            else
            {
                thisEvent.TicketsAvailable -= ticket.Quantity;
            }
            //Debug.WriteLine(thisEvent.Price);

            await Context.SaveChangesAsync();
            return Ok(ticket);
        }
    }
}
