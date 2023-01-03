using AspektJob.Domain.Models;
using AspektJob.DTOs.ModelDTOs;
using AspektJob.Services.Interfaces;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace AspektJob.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class CompanyController : Controller
    {

        private ICompanyService _companyService;
        public CompanyController(ICompanyService companyService)
        {
            _companyService = companyService;
        }


        [HttpPost("create")]
        public ActionResult CreateCompany(CompanyDto company)
        {
            _companyService.CreateCompany(company);
            return StatusCode(StatusCodes.Status201Created, "Sucesfully Created New Company");
        }
        [HttpGet("all")]
        public ActionResult<List<CompanyDto>> GetAllCompanies()
        {
            var companies = _companyService.GetAll();
            return StatusCode(StatusCodes.Status200OK, companies);
        }
        [HttpDelete("delete/{companyId}")]
        
        public ActionResult DeleteCompany(int companyId)
        {
            _companyService.DeleteCompany(companyId);
            return StatusCode(StatusCodes.Status200OK, "Company Deleted!");
        }

        [HttpPost("update")]
        public ActionResult UpdateCompany(CompanyDto company)
        {
            _companyService.UpdateCompany(company);
            return StatusCode(StatusCodes.Status202Accepted, $"Company with id: {company.Id} updated!!!");
        }
    }
}
