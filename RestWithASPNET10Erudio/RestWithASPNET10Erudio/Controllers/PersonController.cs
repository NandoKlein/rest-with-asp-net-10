using Microsoft.AspNetCore.Mvc;
using RestWithASPNET10Erudio.Model;
using RestWithASPNET10Erudio.Services;

namespace RestWithASPNET10Erudio.Controllers
{
    [ApiController]
    [Route("api/[controller]")]

    public class PersonController : ControllerBase
    {
        private readonly IPersonServices _personService;
        private readonly ILogger<PersonController> _logger;
        public PersonController(IPersonServices sevice, ILogger<PersonController> logger)
        {
            _personService = sevice;
            _logger = logger;
        }

        [HttpGet]
        public IActionResult Get()
        {
            _logger.LogInformation("Fetching all people.");
            return Ok(_personService.FindAll());
        }

        [HttpGet("{id}")]
        public IActionResult Get(long id)
        {
            _logger.LogInformation("Fetching person with Id {id}.", id);
            var person = _personService.FindById(id);
            if (person == null)
            {
                _logger.LogWarning("Person with Id {id} not found", id);
                return NotFound();
            }
            return Ok(person);
        }

        [HttpPost]
        public IActionResult Post([FromBody] Person person)
        {
            _logger.LogInformation("Creating new person: {firstName}.", person.FirstName);
            var createdPerson = _personService.Create(person);
            if (createdPerson == null)
            {
                _logger.LogError("Failed to create person with name {firstName}", person.FirstName);
                return NotFound();
            }
            return Ok(createdPerson);
        }

        [HttpPut]
        public IActionResult Put([FromBody] Person person)
        {
            _logger.LogInformation("Updating person with Id {id}.", person.Id);
            var createdPerson = _personService.Update(person);
            if (createdPerson == null)
            {
                _logger.LogError("Failed to update person with Id {id} not found", person.Id);
                return NotFound();
            }
            _logger.LogDebug("Person updated successfully: {firstName} ", createdPerson.FirstName);
            return Ok(createdPerson);
        }

        [HttpDelete("{id}")]
        public IActionResult Delete(long id)
        {
            _logger.LogInformation("Deleting person with Id {id}.", id);
            _personService.Delete(id);
            _logger.LogDebug("Person with Id {id} deleted successfully ", id);
            return NoContent();
        }
    }
}
