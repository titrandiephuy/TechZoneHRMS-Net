using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TechZoneHRMS.Domain.ResponseInchange;

namespace TechZoneHRMS.Service.Interface
{
    public interface IInchangeService
    {
        public Task<InchangeMes> ChangePosition(InchangeDetail inchangeDetail);
    }
}
