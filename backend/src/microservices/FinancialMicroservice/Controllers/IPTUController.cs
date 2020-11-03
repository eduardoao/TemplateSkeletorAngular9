
using FinancialMicroservice.Model;
using FinancialMicroservice.Repository;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace FinancialMicroservice.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class IPTUController : ControllerBase
    {
        private readonly IIPTURepository _iptuRepository;

        public IPTUController(IIPTURepository iptuRepository)
        {
            _iptuRepository = iptuRepository;
        }

        // GET: api/<FinancialController>
        [HttpGet]
        public ActionResult<IEnumerable<IPTU>> Get([FromQuery(Name = "u")] Guid userId)
        {
            var iptus = _iptuRepository.GetIPTUByTaxPayerId(userId);
            return Ok(iptus);
        }

        // POST api/<FinancialController>
        [HttpPost]
        public ActionResult Post([FromBody] Taxpayer taxpayer)
        {
            _iptuRepository.InsertIPTU(taxpayer, taxpayer.GetIPTUs[0]);
            return Ok();
        }

        // PUT api/<FinancialController>
        [HttpPut]
        public ActionResult Put([FromQuery(Name = "u")] Guid userId, [FromBody] IPTU iptu)
        {
            _iptuRepository.UpdateIPTU(userId, iptu);
            return Ok();
        }

        // DELETE api/<FinancialController>
        [HttpDelete]
        public ActionResult Delete([FromQuery(Name = "u")] Guid userId, [FromBody] IPTU iptu)
        {
            _iptuRepository.DeleteIPTU(userId, iptu);
            return Ok();
        }
    }
}
