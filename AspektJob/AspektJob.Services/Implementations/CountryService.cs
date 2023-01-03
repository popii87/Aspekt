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
    public class CountryService : ICountryService
    {
        private IRepository<Country> _countryRepository;
        public CountryService(IRepository<Country> countryRepository)
        {
            _countryRepository = countryRepository;
        }
        public void CreateCountry(CountryDto country)
        {
            _countryRepository.Create(country.ToDomain());
        }

        public void DeleteCountry(int countryId)
        {
            _countryRepository.Delete(countryId);
        }

        public List<CountryDto> GetAll()
        {

            var countries = _countryRepository.GetAll().ToList();
            var countriesDto = new List<CountryDto>();
            foreach (var item in countries)
            {
                countriesDto.Add(item.ToDto());
            }
            return countriesDto;
        }

        public void UpdateCountry(CountryDto country)
        {
            _countryRepository.Update(country.ToDomain());
        }
    }
}
