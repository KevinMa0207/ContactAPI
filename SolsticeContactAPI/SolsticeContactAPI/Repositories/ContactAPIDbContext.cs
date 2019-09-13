using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using SolsticeContactAPI.Entities;

namespace SolsticeContactAPI.Repositories
{
    public class ContactAPIDbContext : DbContext
    {
        public ContactAPIDbContext(DbContextOptions<ContactAPIDbContext> options)
            : base(options)
        {

        }

        public DbSet<Contact> contactItems { get; set; }
    }
}
