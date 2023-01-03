using AspektJob.DTOs.ModelDTOs;
using AspektJob.Services.Interfaces;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace AspektJob.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ContactController : ControllerBase
    {
        private IContactService _contactService;

        public ContactController(IContactService contactService)
        {
            _contactService = contactService;
        }

        [HttpPost("create")]
        public ActionResult CreateContact(ContactDto contactDto)
        {
            _contactService.CreateContact(contactDto);
            return StatusCode(StatusCodes.Status201Created, "Successfully Added New Contact!");
        }

        [HttpGet("getAll")]
        public ActionResult<List<ContactDto>> GetAllContacts()
        {
            List<ContactDto> contacts = _contactService.GetAllContacts();
            return StatusCode(StatusCodes.Status200OK, contacts);
        }

        [HttpDelete("delete/{id}")]
        public ActionResult DeleteContact(int id)
        {
            _contactService.DeleteContact(id);
            return StatusCode(StatusCodes.Status200OK, "Contact Successfully Deleted");
        }

        [HttpPost("update")]
        public ActionResult UpdateContact(ContactDto contactDto)
        {
            _contactService.UpdateContact(contactDto);
            return StatusCode(StatusCodes.Status202Accepted, $"Successfully Updated Contact with ID: {contactDto.Id}");
        }

        [HttpGet("filter")]
        public ActionResult<List<ContactDto>> FilterContacts(int? countryId, int? companyId)
        {
            List<ContactDto> filteredContacts = _contactService.FilterContact(countryId, companyId);
            return StatusCode(StatusCodes.Status202Accepted, filteredContacts);
        }

    }
}
