using SolsticeContactAPI.Entities;
using SolsticeContactAPI.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace SolsticeContactAPI.Repositories
{
    public interface IContactRepository
    {
        Task<Contact> GetById(int id);
        Task<List<Contact>> GetAll(ContactQueryModel query);
        Task<Contact> AddContact(Contact item);
        Contact UpdateContact(Contact item);
        Task DeleteContact(int id);
    }
}
