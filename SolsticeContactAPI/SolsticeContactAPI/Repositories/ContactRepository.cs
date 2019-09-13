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
            var result = await _contactDbContext.ContactItems.AddAsync(item);
            await _contactDbContext.SaveChangesAsync();
            return result.Entity;
        }

        public async Task DeleteContact(int id)
        {
            var item = await GetById(id);            
            _contactDbContext.Remove(item);
            await _contactDbContext.SaveChangesAsync();
        }

        public Task<List<Contact>> GetAll(ContactQueryModel query)
        {
            var contacts = _contactDbContext.ContactItems.Include("Address");
            if (query.Id != null) contacts = contacts.Where(x => x.Id == query.Id);
            if (query.Birthdate != null) contacts = contacts.Where(x => x.Birthdate == query.Birthdate);
            if (query.AddressId != null) contacts = contacts.Where(x => x.Address.AddressId == query.AddressId);
            if (!String.IsNullOrEmpty(query.Name)) contacts = contacts.Where(x => x.Name == query.Name);
            if (!String.IsNullOrEmpty(query.Company)) contacts = contacts.Where(x => x.Company == query.Company);
            if (!String.IsNullOrEmpty(query.ProfileImageUrl)) contacts = contacts.Where(x => x.ProfileImageUrl == query.ProfileImageUrl);
            if (!String.IsNullOrEmpty(query.Email)) contacts = contacts.Where(x => x.Email == query.Email);
            if (!String.IsNullOrEmpty(query.WorkPhoneNumber)) contacts = contacts.Where(x => x.WorkPhoneNumber == query.WorkPhoneNumber);
            if (!String.IsNullOrEmpty(query.PersonalPhoneNumber)) contacts = contacts.Where(x => x.PersonalPhoneNumber == query.PersonalPhoneNumber);
            if (!String.IsNullOrEmpty(query.StreetAddress)) contacts = contacts.Where(x => x.Address.StreetAddress == query.StreetAddress);
            if (!String.IsNullOrEmpty(query.City)) contacts = contacts.Where(x => x.Address.City == query.City);
            if (!String.IsNullOrEmpty(query.State)) contacts = contacts.Where(x => x.Address.State == query.State);
            if (!String.IsNullOrEmpty(query.Country)) contacts = contacts.Where(x => x.Address.Country == query.Country);
            if (!String.IsNullOrEmpty(query.ZipCode)) contacts = contacts.Where(x => x.Address.ZipCode == query.ZipCode);

            return contacts.ToListAsync();
        }

        public Task<Contact> GetById(int id)
        {
            return _contactDbContext.ContactItems.Include("Address").FirstOrDefaultAsync(c => c.Id == id);
        }

        public Contact UpdateContact(Contact item)
        {
            var result = _contactDbContext.ContactItems.Update(item);
            _contactDbContext.SaveChanges();
            return result.Entity;
        }
    }
}
