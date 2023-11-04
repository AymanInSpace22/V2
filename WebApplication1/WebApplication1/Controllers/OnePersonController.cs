using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using System.Collections.Generic;
using System.Threading.Tasks;
using WebApplication1.Models;

namespace WebApplication1.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class OnePersonController : ControllerBase
    {
        private readonly TestContext _context;

        public OnePersonController(TestContext context)
        {
            _context = context;
        }


        [HttpGet("{firstName}")]
        public async Task<ActionResult<IEnumerable<Person>>> GetPeopleByFirstName(string firstName)
        {
            // Retrieve records from the "Person" table where the FirstName matches the provided value
            var people = await _context.People
                .Where(p => p.FirstName == firstName)
                .ToListAsync();

            if (people == null || people.Count == 0)
            {
                return NotFound(); // Return a 404 Not Found response if no records match the first name
            }

            return Ok(people); // Return a 200 OK response with the list of people matching the first name
        }

    }
}
