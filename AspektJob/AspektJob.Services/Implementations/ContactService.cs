using AspektJob.DataAccess;
using AspektJob.Domain.Models;
using AspektJob.DTOs.ModelDTOs;
using AspektJob.Mappers;
using AspektJob.Services.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AspektJob.Services.Implementations
{
    public class ContactService : IContactService
    {
        private  IRepository<Contact>  _contactRepository;
        public ContactService(IRepository<Contact> contactReposotory)
        {
            _contactRepository = contactReposotory;
        }

        public void CreateContact(ContactDto contact)
        {
            _contactRepository.Create(contact.ToDomain());
        }

        public void DeleteContact(int contactId)
        {
            _contactRepository.Delete(contactId);
        }

        public List<ContactDto> FilterContact(int? countryId, int? companyId)
        {
            List<ContactDto> contactsDto = new List<ContactDto>();
            List<Contact> filteredContacts = new List<Contact>();
            try
            {

                if (companyId == null)
                {
                    filteredContacts = _contactRepository.GetAll().Where(x => x.CountryId.Equals(countryId)).ToList();
                }
                else if (countryId == null)
                {
                    filteredContacts = _contactRepository.GetAll().Where(x => x.CompanyId.Equals(companyId)).ToList();
                }
                else
                {
                    filteredContacts = _contactRepository.GetAll().Where(x => x.CountryId.Equals(countryId) && x.CompanyId.Equals(companyId)).ToList();
                }


                foreach (Contact item in filteredContacts)
                {
                    contactsDto.Add(item.ToDto());
                }
            }
            catch (Exception ex)
            {
                throw new Exception("Please set a filter!");
            }

            return contactsDto;
        }

        public List<ContactDto> GetAllContacts()
        {
            List<Contact> contacts = _contactRepository.GetAll();

            List<ContactDto> contactsDto = new List<ContactDto>();

            foreach (Contact item in contacts)
            {
                contactsDto.Add(item.ToDto());
            }

            return contactsDto;
        }

        public void UpdateContact(ContactDto contact)
        {
            _contactRepository.Update(contact.ToDomain());
        }
    }
}
