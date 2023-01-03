using AspektJob.Domain;
using AspektJob.Domain.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AspektJob.DataAccess.Repositories
{
    public class CountryRepository : IRepository<Country>
    {
        private AspektDbContext _aspektDbContext;
        public CountryRepository(AspektDbContext aspektDbContext)
        {
            _aspektDbContext = aspektDbContext;
        }
        public void Create(Country entity)
        {
            if (entity.Id != 0)
            {
                throw new Exception("Id is automatically incremented,please leave it to zero!");
            }
            _aspektDbContext.Countries.Add(entity);
            _aspektDbContext.SaveChanges();
        }

        public void Delete(int id)
        {
            var country = _aspektDbContext.Countries.FirstOrDefault(c => c.Id.Equals(id));
            if (country == null)
            {
                throw new Exception($"Country with Id: {country.Id} not found!");

            }
            _aspektDbContext.Countries.Remove(country);
            _aspektDbContext.SaveChanges();
        }

        public List<Country> GetAll()
        {
            var countries = _aspektDbContext.Countries.ToList();
            if (countries.Count().Equals(0))
            {
                throw new Exception($"No Country in the database!!!");
            }
            return countries;
        }

        public void Update(Country entity)
        {
            try
            {
                _aspektDbContext.Countries.Update(entity);
                _aspektDbContext.SaveChanges();
            }
            catch (Exception)
            {

                throw new Exception("Can not update a non exiistic country!");
            }
        }
    }
}
