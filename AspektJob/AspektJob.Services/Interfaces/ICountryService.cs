using AspektJob.DTOs.ModelDTOs;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AspektJob.Services.Interfaces
{
    public interface ICountryService
    {
        void CreateCountry(CountryDto country);
        List<CountryDto> GetAll();
        void UpdateCountry(CountryDto country);
        void DeleteCountry(int countryId);
    }
}
