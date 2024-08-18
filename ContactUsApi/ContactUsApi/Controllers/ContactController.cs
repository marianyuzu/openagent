using ContactUsApi.Models;
using ContactUsApi.Services;
using Microsoft.AspNetCore.Mvc;

namespace ContactUsApi.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class ContactController : ControllerBase
    {
        private readonly ContactService _contactService;

        public ContactController(ContactService contactService)
        {
            _contactService = contactService;
        }

        [HttpGet("contactinfo")]
        public IActionResult GetContactInfo()
        {
            var contactInfo = new ContactInfo
            {
                Header = "Contact us, we love to hear from you",
                Body = "Welcome to OpenAgent. We've been around since 2013, and our vision is to make it easy for people to buy, sell, and own property. Here are the different ways you can contact us",
                Phone = "13 24 34",
                Email = "support@openagent.com.au",
                Address = "PO Box 419, Alexandria NSW 1435",
                Hours = "Monday - Friday 8:30 - 5:00"
            };

            return Ok(contactInfo);
        }

        [HttpPost("submitform")]
        public async Task<IActionResult> SubmitForm([FromBody] ContactSubmission formSubmission)
        {
            if (formSubmission == null)
            {
                return BadRequest("Form submission is null.");
            }

            await _contactService.CreateAsync(formSubmission);
            return Ok(new { message = "Form submitted successfully" });
        }
    }
}
