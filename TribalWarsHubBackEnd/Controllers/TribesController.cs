using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Authentication.JwtBearer;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using TribalWarsHubBackEnd.Data;
using TribalWarsHubBackEnd.Models;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace TribalWarsHubBackEnd.Controllers
{
    [ApiConventionType(typeof(DefaultApiConventions))]
    [Produces("application/json")]
    [Route("api/[controller]")]
    [Authorize(AuthenticationSchemes = JwtBearerDefaults.AuthenticationScheme)]
    [ApiController]
    public class TribesController : ControllerBase
    {
        private readonly ITribeRepository _tribeRepository;

        public TribesController(ITribeRepository context)
        {
            _tribeRepository = context;
        }

        // GET: api/<controller>
        [HttpGet("{world}")]
        [AllowAnonymous]
        public IEnumerable<Tribe> GetTribes(int world)
        {
            return _tribeRepository.GetAll(world).OrderBy(r => r.Name);
        }

        // GET api/<controller>/5
        [HttpGet("{world}/{id}")]
        [AllowAnonymous]
        public Tribe GetById(int world, int id)
        {
            return _tribeRepository.GetBy(world, id);
        }

        // POST api/<controller>
        [HttpPost]
        public void Post([FromBody]string value)
        {
        }

        // PUT api/<controller>/5
        [HttpPut("{id}")]
        public void Put(int id, [FromBody]string value)
        {
        }

        // DELETE api/<controller>/5
        [HttpDelete("{id}")]
        public void Delete(int id)
        {
        }
    }
}
