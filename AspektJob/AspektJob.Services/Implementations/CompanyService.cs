using AspektJob.DataAccess;
using AspektJob.Domain.Models;
using AspektJob.DTOs.ModelDTOs;
using AspektJob.Services.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using AspektJob.Mappers;


namespace AspektJob.Services.Implementations
{
    public class CompanyService : ICompanyService
    {
        private IRepository<Company> _companyRepository;
        public CompanyService(IRepository<Company> companyRepository)
        {
            _companyRepository = companyRepository;
        }
        public void CreateCompany(CompanyDto company)
        {
            _companyRepository.Create(company.ToDomain());
        }

        public void DeleteCompany(int companyId)
        {
            _companyRepository.Delete(companyId);
        }

        public List<CompanyDto> GetAll()
        {
            var companies = _companyRepository.GetAll();
            var companiesDto = new List<CompanyDto>();
            foreach (var item in companies)
            {
                companiesDto.Add(item.ToDto());

            }
            return companiesDto;

        }



        public void UpdateCompany(CompanyDto company)
        {
            _companyRepository.Update(company.ToDomain());
        }





    }
}

