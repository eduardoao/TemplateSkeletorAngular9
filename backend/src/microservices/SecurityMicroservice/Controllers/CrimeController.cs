
using CatalogMicroservice.Repository;
using SecurityMicroservice.Model;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace SecurityMicroservice.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class CrimeController : ControllerBase
    {
        private readonly ICrimeRepository _crimeRepository;

        public CrimeController(ICrimeRepository cartRepository)
        {
            _crimeRepository = cartRepository;
        }

        // GET: api/<CrimeController>
        [HttpGet]
        [Route("GetAll")]
        public ActionResult<Crime> GetAll()
        {
            var cartItems = _crimeRepository.GetAllCrime();
            if (cartItems == null) BadRequest();
            return Ok(cartItems);
        }

        // GET: api/<CrimeController>
        [HttpGet]
        public ActionResult<Crime> Get([FromQuery(Name = "crimeId")] Guid crimeId)
        {
            var cartItems = _crimeRepository.GetCrime(crimeId);
            if (cartItems == null) BadRequest();
            return Ok(cartItems);
        }

        // POST api/<CrimeController>
        [HttpPost]
        public ActionResult Post([FromQuery(Name = "crimeId")] Guid crimeId, [FromBody] Crime crime)
        {
            _crimeRepository.InsertCrime(crimeId, crime);
            return Ok();
        }

        // PUT api/<CrimeController>
        [HttpPut]
        public ActionResult Put([FromQuery(Name = "crimeId")] Guid crimeId, [FromBody] CrimeLocalization cartItem)
        {
            _crimeRepository.UpdateCrimeLocalizationItem(crimeId, cartItem);
            return Ok();
        }

        // DELETE api/<CrimeController>
        [HttpDelete]
        public ActionResult Delete([FromQuery(Name = "crimeId")] Guid userId, [FromQuery(Name = "crimeItem")] Guid crimeItem)
        {
            _crimeRepository.DeleteCrimeLocalizationItem(userId, crimeItem);
            return Ok();
        }
    }
}
