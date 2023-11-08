using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using System.Collections.Generic;
using System.Threading.Tasks;
using WebApplication1.DTO;
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


        [HttpGet("ByFirstName/{firstName}")]
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

        [HttpGet("ByLastName/{lastName}")]
        public async Task<ActionResult<IEnumerable<Person>>> GetPeopleByLastName(string lastName)
        {
            // Retrieve records from the "Person" table where the FirstName matches the provided value
            var people = await _context.People
                .Where(p => p.LastName == lastName)
                .ToListAsync();

            if (people == null || people.Count == 0)
            {
                return NotFound(); // Return a 404 Not Found response if no records match the first name
            }

            return Ok(people); // Return a 200 OK response with the list of people matching the first name
        }

        // POST endpoint to create a new person
        [HttpPost("CreatePerson")]
        public async Task<ActionResult<Person>> CreatePerson([FromBody] CreatePersonDto personCreateDto)
        {
            if (personCreateDto == null)
            {
                return BadRequest("Invalid request body.");
            }

            // Create a new Person entity from the DTO
            var newPerson = new Person
            {
                FirstName = personCreateDto.FirstName,
                LastName = personCreateDto.LastName,
                Email = personCreateDto.Email,
                PhoneNumber = personCreateDto.PhoneNumber,
                Age = personCreateDto.Age,
                Height = personCreateDto.Height,
                Weight = personCreateDto.Weight,
                Birthday = personCreateDto.Birthday
            };

            try
            {
                // Add the new person to the database
                _context.People.Add(newPerson);
                await _context.SaveChangesAsync();

                return CreatedAtAction(nameof(CreatePerson), new { id = newPerson.PersonId }, newPerson);
            }
            catch (DbUpdateException)
            {
                // Handle database update error
                return StatusCode(500, "An error occurred while creating the person.");
            }
        }


    }
}
