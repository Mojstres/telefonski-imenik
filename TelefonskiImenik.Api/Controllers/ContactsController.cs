using Microsoft.AspNetCore.Mvc;
using TelefonskiImenik.DataAccess;
using TelefonskiImenik.Logic;

namespace TelefonskiImenik.Api.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class ContactsController(ContactService contactService) : ControllerBase
    {
        [HttpGet("search")]
        public IActionResult Search([FromQuery] string query)
        {
            var results = contactService.SearchContacts(query);
            return Ok(results);
        }

        [HttpGet]
        public IActionResult GetAll()
        {
            var results = contactService.GetAllContacts();
            return Ok(results);
        }
    }
}
