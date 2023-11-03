using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using System.Collections.Generic;
using System.Threading.Tasks;
using WebApplication1.Models;

namespace WebApplication1.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class PersonController : ControllerBase
    {
        private readonly TestContext _context;

        public PersonController(TestContext context)
        {
            _context = context;
        }

        [HttpGet]
        public async Task<ActionResult<IEnumerable<Person>>> GetPeople()
        {
            // Retrieve all records from the "Person" table
            var people = await _context.People.ToListAsync();

            if (people == null || people.Count == 0)
            {
                return NotFound(); // Return a 404 Not Found response if no records are found
            }

            return Ok(people); // Return a 200 OK response with the list of people
        }
    }
}
