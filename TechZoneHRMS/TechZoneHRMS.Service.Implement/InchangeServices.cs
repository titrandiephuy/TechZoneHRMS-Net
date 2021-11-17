using Dapper;
using Microsoft.Extensions.Configuration;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TechZoneHRMS.Domain.ResponseInchange;
using TechZoneHRMS.Service.Interface;

namespace TechZoneHRMS.Service.Implement
{
    public class InchangeServices : BaseService, IInchangeService
    {
        public InchangeServices(IConfiguration configuration) : base(configuration)
        {

        }
        public async Task<InchangeMes> ChangePosition(InchangeDetail inchangeDetail)
        {
            var result = new InchangeMes()
            {
                Success = false,
                Message = "wrong"
            };
            try
            {
                DynamicParameters parameters = new DynamicParameters();
                parameters.Add("@employeeId", inchangeDetail.EmployeeId);
                parameters.Add("@positionId", inchangeDetail.PositionId);
                var ChangeResult = await SqlMapper.ExecuteAsync
                (
                    cnn: connect,
                    sql: "Sp_ChangePosition",
                    param: parameters,
                    commandType: CommandType.StoredProcedure
                 );
                if (ChangeResult > 0)
                {
                    result.Success = true;
                    result.Message = "Position change successfully";
                }
                return result;
            }
            catch (Exception ex)
            {

                return result;
            }
        }
    }
}
