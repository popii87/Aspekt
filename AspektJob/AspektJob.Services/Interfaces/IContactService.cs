using AspektJob.DTOs.ModelDTOs;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AspektJob.Services.Interfaces
{
    public interface IContactService
    {
        void CreateContact(ContactDto contact);
        List<ContactDto> GetAllContacts();
        void UpdateContact(ContactDto contact);
        void DeleteContact(int contactId);
       
        List<ContactDto> FilterContact(int? countryId, int? companyId);
    }
}
