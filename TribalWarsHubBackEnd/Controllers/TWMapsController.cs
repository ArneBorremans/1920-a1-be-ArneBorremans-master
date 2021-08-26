using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Authentication.JwtBearer;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using TribalWarsHubBackEnd.Models;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace TribalWarsHubBackEnd.Controllers
{
    [ApiConventionType(typeof(DefaultApiConventions))]
    [Produces("application/json")]
    [Route("api/[controller]")]
    [Authorize(AuthenticationSchemes = JwtBearerDefaults.AuthenticationScheme)]
    [ApiController]
    public class TWMapsController : ControllerBase
    {
        private readonly ITWMapRepository _twMapRepository;
        
        public TWMapsController(ITWMapRepository context)
        {
            _twMapRepository = context;
        }

        // GET: api/TWMaps
        /// <summary>
        /// Get all the TWMaps
        /// </summary>
        /// <returns>List of all the TWMaps</returns>
        [HttpGet]
        [AllowAnonymous]
        public IEnumerable<TWMap> GetTWMaps()
        {
            return _twMapRepository.GetAll().OrderBy(r => r.Name);
        }

        [HttpGet("{id}")]
        [AllowAnonymous]
        public ActionResult<TWMap> GetTWMap(int id)
        {
            TWMap tWMap = _twMapRepository.GetBy(id);
            if (tWMap == null) return NotFound();
            return tWMap;
        }

        [HttpPost]
        public ActionResult<TWMap> PostTWMap(TWMap tWMap)
        {
            _twMapRepository.Add(tWMap);
            _twMapRepository.SaveChanges();

            return CreatedAtAction(nameof(GetTWMap), new { id = tWMap.Id }, tWMap);
        }

        [HttpPut("{id}")]
        public IActionResult PutTWMap(int id, TWMap tWMap)
        {
            if(id != tWMap.Id)
            {
                return BadRequest();
            }
            _twMapRepository.Update(tWMap);
            _twMapRepository.SaveChanges();
            return NoContent();
        }
    }
}
