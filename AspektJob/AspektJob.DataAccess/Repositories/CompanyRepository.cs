using AspektJob.Domain;
using AspektJob.Domain.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AspektJob.DataAccess.Repositories
{
    public class CompanyRepository : IRepository<Company>
    {

        private AspektDbContext _aspektDbContext;

        public CompanyRepository(AspektDbContext aspektDbContext)
        {
            _aspektDbContext = aspektDbContext;
        }
        public void Create(Company entity)
        {
            if (entity.Id != 0)
            {
                throw new Exception("Company ID is automatically incremented, please set it to zero!");
            }
            _aspektDbContext.Companies.Add(entity);
            
            _aspektDbContext.SaveChanges();    
        }

        public void Delete(int id)
        {
            var company = _aspektDbContext.Companies.FirstOrDefault(c => c.Id.Equals(id));
            if (company == null)
            {
                throw new Exception($"Company with ID: {id} not found!");

            }
            _aspektDbContext.Companies.Remove(company);
            
            _aspektDbContext.SaveChanges();
        }

        public List<Company> GetAll()
        {
            var companies = _aspektDbContext.Companies.ToList();
            if (companies.Count().Equals(0))
            {
                throw new Exception($"You dont have any companies!");
            }
            return companies;
        }

        public void Update(Company entity)
        {
            try
            {
                _aspektDbContext.Companies.Update(entity);
                _aspektDbContext.SaveChanges();
            }
            catch (Exception)
            {

                throw new Exception("Cannot update a compnay that does not exist!");
            }
        }
    }
}
