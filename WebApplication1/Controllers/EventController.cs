using EventSystem.Models;
using Microsoft.EntityFrameworkCore;
using EventSystem.Helpers;
using Microsoft.AspNetCore.Mvc;


namespace EventSystem.Controllers

{
    [Route("api[controller]")]
    [ApiController]
    public class EventController : ControllerBase
    {
        private readonly DataContext Context;

        public EventController(DataContext dataContext) {
            Context = dataContext;
        }
        [HttpGet]
        public async Task<ActionResult<List<Event>>> Get() {
            return Ok(await Context.Events.ToListAsync());
        }
        [HttpGet("{id}")]
        public async Task<ActionResult<Event>> Get(int id)
        {
            var currEvent = await Context.Events.FindAsync(id);
            if(currEvent == null) 
            {
                return BadRequest("Event not found.");
            }
            return Ok(currEvent);
        }

        [HttpPost]
        public async Task<ActionResult<List<Event>>> AddEvent(Event currEvent)
        {
            Context.Events.Add(currEvent);
            await Context.SaveChangesAsync();
            return Ok(await Context.Events.ToListAsync());

        }

    }
}
