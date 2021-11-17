using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using TechZoneHRMS.Domain.ResponseInchange;
using TechZoneHRMS.Service.Interface;

namespace TechZoneHRMS.API.Controllers
{
    [Route("[controller]")]
    [ApiController]
    public class DapperInchangeController : Controller
    {
        private readonly IInchangeService inchangeService;

        public DapperInchangeController(IInchangeService inchangeService)
        {
            this.inchangeService = inchangeService;
        }

        [HttpPut]
        public async Task<InchangeMes> ChangePosition(InchangeDetail inchangeDetail)
        {
            return await inchangeService.ChangePosition(inchangeDetail);
        }
    }
}
