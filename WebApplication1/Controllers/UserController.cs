using EventSystem.Models;
using Microsoft.EntityFrameworkCore;
using EventSystem.Helpers;
using Microsoft.AspNetCore.Mvc;

namespace EventSystem.Controllers
{
    [Route("api[controller]")]
    [ApiController]
    public class UserController : ControllerBase
    {


        public UserController(DataContext context)
        {
            Context = context;
        }

        private readonly DataContext Context;

        [HttpGet]
        public async Task<ActionResult<List<User>>> Get()
        {
            return Ok(await Context.Users.ToListAsync());
        }

        [HttpGet("{id}")]
        public async Task<ActionResult<User>> Get(int id)
        {
            var user = await Context.Users.FindAsync(id);
            if(user == null)
            {
                return BadRequest("User Not Found");
            }
            return Ok(user);
        }

        [HttpPost]
        public async Task<ActionResult<List<User>>> AddUser(User user)
        {
            Context.Users.Add(user);
            await Context.SaveChangesAsync();
            return Ok(await Context.Users.ToListAsync());
        }

        [HttpPut("{id}")]
        public async Task<ActionResult<List<User>>> UpdateUser(int id, string first, string last, string email)
        {
            var dbUser = await Context.Users.FindAsync(id);
            
            if(dbUser == null)
            {
                return BadRequest("User Not Found");
            }
            
            dbUser.FirstName = first;
            dbUser.LastName = last;
            dbUser.Email = email;

            await Context.SaveChangesAsync();

            return Ok(dbUser);
        }

        [HttpDelete("{id}")]
        public async Task<ActionResult<List<User>>> Delete (int id)
        {
            var user = await Context.Users.FindAsync (id);
            if(user == null)
            {
                return BadRequest("User Not Found");
            }

            Context.Users.Remove(user);
            await Context.SaveChangesAsync();
            return Ok(user.FirstName + " successfully removed");
        }
    }
}
