using Core_Web_Api.Data;
using Core_Web_Api.Model;
using Microsoft.AspNetCore.Components.Server;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using System.Net;
using System.Numerics;

namespace Core_Web_Api.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class ContactsController : Controller
    {
        ContactsAPIDbContext _context;
        public ContactsController(ContactsAPIDbContext _context)
        {
            this._context = _context;
        }
        [HttpGet]
        public async Task<IActionResult> GetContacts()
        {
            return Ok(await _context.Contacts.ToListAsync());

        }
        [HttpGet]
        [Route("{id}")]
        public async Task<IActionResult> GetContacById(int id)
        {
            var contact = await _context.Contacts.FindAsync(id);
            if (contact != null)
            {
                return Ok(contact);
            }
            return NotFound();
        }
        [HttpPost]
        public async Task<IActionResult> AddContact(AddContactRequest addContact)
        {
            var contact = new Contact()
            {
                Id = addContact.Id,
                Address = addContact.Address,
                Email = addContact.Email,
                FullName = addContact.FullName,
                Phone = addContact.Phone
            };
            await _context.Contacts.AddAsync(contact);
            await _context.SaveChangesAsync();
            return Ok(contact);
        }
        [HttpPut]
        [Route("{id}")]
        public async Task<IActionResult> UpdateContact(int id, UpdateContactRequest updateContact)
        {
            var contact = _context.Contacts.Find(id);
            if (contact != null)
            {
                contact.Address = updateContact.Address;
                contact.Email = updateContact.Email;
                contact.FullName = updateContact.FullName;
                contact.Phone = updateContact.Phone;
                await _context.SaveChangesAsync();
                return Ok(contact);
            }
              return NotFound();
        } 
        [HttpDelete]
        [Route("{id}")]
        public async Task<IActionResult> DeleteContact(int id)
        {
            var contact = _context.Contacts.Find(id);
            if (contact != null)
            {
                _context.Remove(contact);
                await _context.SaveChangesAsync();
                return Ok(contact);
            }
              return NotFound();
        }
    }
}
