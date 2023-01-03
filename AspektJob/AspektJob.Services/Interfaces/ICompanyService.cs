using AspektJob.Domain.Models;
using AspektJob.DTOs.ModelDTOs;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AspektJob.Services.Interfaces
{
    public  interface ICompanyService
    {
        void CreateCompany(CompanyDto company);
        List<CompanyDto> GetAll();
        void UpdateCompany(CompanyDto company);
        void DeleteCompany(int companyId);
    }
}
