using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using SolsticeContactAPI.Entities;
using SolsticeContactAPI.Models;
using SolsticeContactAPI.Repositories;

namespace SolsticeContactAPI.Controllers
{
    [Produces("application/json")]
    [Route("api/Contact")]
    public class ContactController : Controller
    {
        private readonly IContactRepository _contactRepository;
      
        public ContactController(IContactRepository contactRepository)
        {
            _contactRepository = contactRepository;
        }

        [HttpGet]
        [AllowAnonymous]
        [Route("GetContactByIdAsync")]
        public async Task<JsonResult> GetContactByIdAsync(int id)
        {
            var contact = await _contactRepository.GetById(id);
            if (contact == null) return new JsonResult("Contact not found");
            return new JsonResult(PopulateContactViewModel(contact));
        }

        [HttpPost]
        [AllowAnonymous]
        [Route("GetAllContactAsync")]
        public async Task<JsonResult> GetAllContactAsync([FromBody] ContactQueryModel query)
        {
            var contactList = await  _contactRepository.GetAll(query);
            if (contactList == null || contactList.Count == 0) return new JsonResult("Contacts not found");
            var contactViewModelList = new List<ContactViewModel>();
            foreach(Contact c in contactList)
            {
                contactViewModelList.Add(PopulateContactViewModel(c));
            }
            return new JsonResult(contactViewModelList);
        }

        [HttpPost]
        [AllowAnonymous]
        [Route("CreateContactAsync")]
        public async Task<JsonResult> CreateContactAsync([FromBody] ContactCreateModel model)
        {
            Address address = new Address()
            {
                StreetAddress = model.StreetAddress,
                City = model.City,
                State = model.State,
                Country = model.Country,
                ZipCode = model.ZipCode
            };

            Contact contact = new Contact()
            {
                Name = model.Name,
                Company = model.Company,
                ProfileImageUrl = model.ProfileImageUrl,
                Email = model.Email,
                Birthdate = Convert.ToDateTime(model.Birthdate),
                WorkPhoneNumber = model.WorkPhoneNumber,
                PersonalPhoneNumber = model.PersonalPhoneNumber,
                Address = address
            };
            var createdContact = await _contactRepository.AddContact(contact);

            return new JsonResult(PopulateContactViewModel(createdContact));
        }

        [HttpPut]
        [AllowAnonymous]
        public async Task<JsonResult> UpdateContact([FromBody] ContactViewModel model)
        {
            try
            {
                if (model.Id == null) return new JsonResult("Contact does not exist");
                var contact = await _contactRepository.GetById((int)model.Id);
                if (contact == null) return new JsonResult("Contact does not exist");
                contact.Name = model.Name;
                contact.Company = model.Company;
                contact.ProfileImageUrl = model.ProfileImageUrl;
                contact.Email = model.Email;
                contact.Birthdate = (DateTime)model.Birthdate;
                contact.WorkPhoneNumber = model.WorkPhoneNumber;
                contact.PersonalPhoneNumber = model.PersonalPhoneNumber;
                contact.Address.StreetAddress = model.StreetAddress;
                contact.Address.City = model.City;
                contact.Address.State = model.State;
                contact.Address.Country = model.Country;
                contact.Address.ZipCode = model.ZipCode;
                Contact updateContact = _contactRepository.UpdateContact(contact);
                return new JsonResult(PopulateContactViewModel(updateContact));
            }
            catch (Exception e)
            {
                //log exception here
                return new JsonResult("Contact info update failed, contact id: " + model.Id.ToString());
            }
            
            
        }

        [HttpDelete]
        [AllowAnonymous]
        [Route("DeleteContact")]
        public async Task DeleteContact(int id)
        {
            await _contactRepository.DeleteContact(id);
        }

        [NonAction]
        public ContactViewModel PopulateContactViewModel(Contact model)
        {
            return new ContactViewModel()
            {
                Id = model.Id,
                Name = model.Name,
                Company = model.Company,
                ProfileImageUrl = model.ProfileImageUrl,
                Email = model.Email,
                Birthdate = model.Birthdate,
                WorkPhoneNumber = model.WorkPhoneNumber,
                PersonalPhoneNumber = model.PersonalPhoneNumber,
                AddressId = model.Address.AddressId,
                StreetAddress = model.Address.StreetAddress,
                City = model.Address.City,
                State = model.Address.State,
                Country = model.Address.Country,
                ZipCode = model.Address.ZipCode
            };
        }
    }
}