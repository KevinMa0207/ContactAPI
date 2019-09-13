using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using SolsticeContactAPI.Entities;
using SolsticeContactAPI.Models;

namespace SolsticeContactAPI.Repositories
{
    public class ContactRepository : IContactRepository
    {
        private readonly ContactAPIDbContext _contactDbContext;

        public ContactRepository(ContactAPIDbContext context)
        {
            _contactDbContext = context;
        }

        public async Task<Contact> AddContact(Contact item)
        {
            var result = await _contactDbContext.contactItems.AddAsync(item);
            return result.Entity;
        }

        public async Task DeleteContact(int id)
        {
            var item = await GetById(id);
            _contactDbContext.Remove(item);
        }

        public Task<List<Contact>> GetAll(ContactQueryModel query)
        {           
            var contacts = _contactDbContext.contactItems.AsQueryable();
            if (query.Id != null) contacts.Where(x => x.Id == query.Id);
            if (query.Birthdate != null) contacts.Where(x => x.Birthdate == query.Birthdate);
            if (query.AddressId != null) contacts.Where(x => x.Address.Id == query.AddressId);
            if (!String.IsNullOrEmpty(query.Name)) contacts.Where(x => x.Name == query.Name);
            if (!String.IsNullOrEmpty(query.Company)) contacts.Where(x => x.Company == query.Company);
            if (!String.IsNullOrEmpty(query.ProfileImageUrl)) contacts.Where(x => x.ProfileImageUrl == query.ProfileImageUrl);
            if (!String.IsNullOrEmpty(query.Email)) contacts.Where(x => x.Email == query.Email);
            if (!String.IsNullOrEmpty(query.WorkPhoneNumber)) contacts.Where(x => x.WorkPhoneNumber == query.WorkPhoneNumber);
            if (!String.IsNullOrEmpty(query.PersonalPhoneNumber)) contacts.Where(x => x.PersonalPhoneNumber == query.PersonalPhoneNumber);
            if (!String.IsNullOrEmpty(query.StreetAddress)) contacts.Where(x => x.Address.StreetAddress == query.StreetAddress);
            if (!String.IsNullOrEmpty(query.City)) contacts.Where(x => x.Address.City == query.City);
            if (!String.IsNullOrEmpty(query.State)) contacts.Where(x => x.Address.State == query.State);
            if (!String.IsNullOrEmpty(query.Country)) contacts.Where(x => x.Address.Country == query.Country);
            if (!String.IsNullOrEmpty(query.ZipCode)) contacts.Where(x => x.Address.ZipCode == query.ZipCode);

            return contacts.ToListAsync();
        }

        public Task<Contact> GetById(int id)
        {
            return _contactDbContext.contactItems.FirstOrDefaultAsync(c => c.Id == id);
        }

        public Contact UpdateContact(Contact item)
        {
            var result = _contactDbContext.contactItems.Update(item);
            return result.Entity;
        }
    }
}
