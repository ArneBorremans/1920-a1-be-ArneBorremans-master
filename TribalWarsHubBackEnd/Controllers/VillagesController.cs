using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Authentication.JwtBearer;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using TribalWarsHubBackEnd.Data;
using TribalWarsHubBackEnd.Models;

namespace TribalWarsHubBackEnd.Controllers
{
    [ApiConventionType(typeof(DefaultApiConventions))]
    [Produces("application/json")]
    [Route("api/[controller]")]
    [Authorize(AuthenticationSchemes = JwtBearerDefaults.AuthenticationScheme)]
    [ApiController]
    public class VillagesController : ControllerBase
    {
        private readonly IVillageRepository _villageRepository;

        public VillagesController(IVillageRepository context)
        {
            _villageRepository = context;
        }

        [HttpGet]
        [AllowAnonymous]
        public IEnumerable<Village> GetVillages()
        {
            return _villageRepository.GetAll().OrderBy(r => r.Village_Id);
        }
    }
}
