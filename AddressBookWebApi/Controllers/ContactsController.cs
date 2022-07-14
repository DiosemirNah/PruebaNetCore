using AddressBookWebApi.IServices;
using AddressBookWebApi.Model;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using System.Collections.Generic;

namespace AddressBookWebApi.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class ContactsController : Controller
    {
        private readonly IContactoService _contactoService;
        public ContactsController(IContactoService contactoService)
        {
            _contactoService = contactoService;
        }

        /// <summary>
        /// Get the list contacts with phrase filter
        /// </summary>
        /// <param name="phrase">Filter contact name</param>
        /// <returns>Returns 200 when exists values</returns>
        [HttpGet]
        [Route("~/api/contacts")]
        [Produces("application/json")]
        [ProducesResponseType(typeof(List<ContactoModel>), 200)]
        public ActionResult<List<ContactoModel>> GetContacts([FromQuery]string phrase)
        {
            if (string.IsNullOrEmpty(phrase))
            {
                return BadRequest();
            }
            var result = _contactoService.GetContactos(phrase);
            if (result.Count == 0)
            {
                return StatusCode(204, result);
            }
            return Ok(result);
        }

        /// <summary>
        /// Get a contact with id
        /// </summary>
        /// <param name="contact_id">Search contact id</param>
        /// <returns>Returns 200 when exists values</returns>
        [HttpGet]
        [Route("~/api/contact")]
        [Produces("application/json")]
        [ProducesResponseType(typeof(List<ContactoModel>), 200)]
        public ActionResult<List<ContactoModel>> GetContact([FromQuery] string contact_id)
        {
            if(string.IsNullOrEmpty(contact_id))
            {
                return NotFound();
            }
            var result = _contactoService.GetContacto(contact_id);
            return Ok(result);
        }

        /// <summary>
        /// Delete contacts with a contact id in the JS FILE
        /// </summary>
        /// <returns></returns>
        [HttpDelete]
        [Route("~/api/contact/{contact_id}")]
        [Produces("application/json")]
        [ProducesResponseType(typeof(StatusCodeResult),204)]
        public ActionResult<List<ContactoModel>> DeleteContact(string contact_id)
        {
            var result = _contactoService.DeleteContacto(contact_id);
            if(!result)
            {
                return NotFound();
            }
            return StatusCode(204);
        }
    }
}
