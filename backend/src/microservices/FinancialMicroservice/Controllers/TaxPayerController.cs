
using FinancialMicroservice.Repository;
using Microsoft.AspNetCore.Mvc;
using System;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace FinancialMicroservice.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class TaxPayerController : ControllerBase
    {
        private readonly ITaxPayerRepository _taxPayerRepository;

        public TaxPayerController(ITaxPayerRepository taxPayerRepository)
        {
            _taxPayerRepository = taxPayerRepository;
        }

        // GET: api/<FinancialController>
        [HttpGet]
        public ActionResult Get([FromQuery(Name = "u")] Guid userId)
        {
            var tax = _taxPayerRepository.GetTaxpayer(userId);
            return Ok(tax);
        }      
    }
}
