using AspektJob.Domain;
using AspektJob.Domain.Models;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AspektJob.DataAccess.Repositories
{
    public class ContactRepository : IRepository<Contact>
    {
        private AspektDbContext _aspektDbContext;
        public ContactRepository(AspektDbContext aspektDbContext)
        {
            _aspektDbContext = aspektDbContext;
        }
        public void Create(Contact entity)
        {
            var company = _aspektDbContext.Companies.FirstOrDefault(x => x.Id.Equals(entity.CompanyId));
            var country = _aspektDbContext.Countries.FirstOrDefault(x => x.Id.Equals(entity.CountryId));
            entity.Company = company;
            entity.Country = country;
            if (company == null)
                throw new Exception("You are sending invalid company to the object!");

            if (country == null)
                throw new Exception("You are sending invalid country to the object!");

            if (entity.Id != 0)
                throw new Exception("Country ID is automatically incremented, please set it to zero!");

            _aspektDbContext.Contacts.Add(entity);
            _aspektDbContext.SaveChanges();
        }

        public void Delete(int id)
        {
            Contact contact = _aspektDbContext.Contacts.FirstOrDefault(x => x.Id.Equals(id));

            if (contact == null)
                throw new Exception($"Contact with ID: {id} not found!");


            _aspektDbContext.Contacts.Remove(contact);
            _aspektDbContext.SaveChanges();
        }

        public List<Contact> GetAll()
        {
            var contacts = _aspektDbContext.Contacts
                .Include(c=>c.Company)
                .Include(c => c.Country)
                .ToList();
            if (contacts.Count().Equals(0))
            {
                throw new Exception($"You dont have any companies!");
            }
            return contacts;
        }

        public void Update(Contact entity)
        {
            try
            {
                _aspektDbContext.Update(entity);
                _aspektDbContext.SaveChanges();
            }
            catch (Exception ex)
            {
                throw new Exception("You cannot update a contact that does not exist!");
            }
        }
    }
}
