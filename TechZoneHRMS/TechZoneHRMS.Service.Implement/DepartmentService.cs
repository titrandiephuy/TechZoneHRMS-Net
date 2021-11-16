using Dapper;
using Microsoft.Extensions.Configuration;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TechZoneHRMS.Domain.Response;
using TechZoneHRMS.Service.Interface;

namespace TechZoneHRMS.Service.Implement
{
    public class DepartmentService : BaseService, IDepartmentService
    {
        public DepartmentService(IConfiguration configuration) : base(configuration)
        {

        }

        public async Task<ChangeStatusDepartment> ChangeStatusDepartment(int departementId)
        {
            var result = new ChangeStatusDepartment()
            {
                Success = false,
                Message = "Error"
            };
            try
            {
                DynamicParameters parameters = new DynamicParameters();
                parameters.Add("@DepartmentId", departementId);
                var ChangeStatus = await SqlMapper.ExecuteScalarAsync<int>(
                    cnn: connect,
                    sql: "SP_ChangeStatus",
                    param: parameters,
                    commandType: CommandType.StoredProcedure
                    );
                if (ChangeStatus > 0)
                {
                    result.Success = true;
                    result.Message = "Department ChangeStatus Successfully";
                }
                return result;
            }
            catch (Exception ex)
            {

                return result;
            }
        }

        public async Task<CreateDepartment> CreateDepartment(Department department)
        {
            var result = new CreateDepartment()
            {
                Success = false,
                Message = "Error"
            };
            try
            {
                DynamicParameters parameters = new DynamicParameters();
                parameters.Add("@DepartmentName", department.DepartmentName);
                parameters.Add("@DepartmentPhoneNumber", department.DepartmentPhoneNumber);
                parameters.Add("@DepartmentLocation", department.DepartmentLocation);
                parameters.Add("@DepartmentStatus", department.DepartmentStatus);
                var createResult = await SqlMapper.ExecuteScalarAsync<int>
                    (
                        cnn: connect,
                        sql: "Sp_CreateDepartmentId",
                        param: parameters,
                        commandType: CommandType.StoredProcedure
                    );
                if (createResult > 0)
                {
                    result.Success = true;
                    result.Message = "Departement create successfully";
                }
                return result;
            }
            catch (Exception ex)
            {
                return result;
            }
        }

        public async Task<List<DepartmentInformation>> Departmentinformation(int departmentId)
        {
            DynamicParameters parameters = new DynamicParameters();
            parameters.Add("@DepartmentId", departmentId);
            var result = await SqlMapper.QueryAsync<DepartmentInformation>
                (cnn: connect, sql: "SP_DepartmentInformation", param: parameters, commandType: CommandType.StoredProcedure);
            return result.ToList();
        }

        public async Task<EditDepartment> EditDepartment(Department department)
        {
            var result = new EditDepartment()
            {
                Success = false,
                Message = "Error"
            };
            try
            {
                DynamicParameters parameters = new DynamicParameters();
                parameters.Add("DepartmentId", department.DepartmentId);
                parameters.Add("@DepartmentName", department.DepartmentName);
                parameters.Add("@DepartmentPhoneNumber", department.DepartmentPhoneNumber);
                parameters.Add("@DepartmentLocation", department.DepartmentLocation);
                parameters.Add("@DepartmentStatus", department.DepartmentStatus);
                var editResult = await SqlMapper.ExecuteScalarAsync<int>(
                    cnn: connect,
                    sql: "SP_EditDepartment",
                    param: parameters,
                    commandType: CommandType.StoredProcedure
                    );
                if (editResult > 0)
                {
                    result.Success = true;
                    result.Message = "Department Edit Successfully";
                }
                return result;
            }
            catch (Exception ex)
            {

                return result;
            }
        }

        public async Task<List<Department>> Get()
        {
            var result = await SqlMapper.QueryAsync<Department>
                (cnn: connect, sql: "Sp_GetDepartement", commandType: CommandType.StoredProcedure);
            return result.ToList();
        }

        public async Task<Department> GetById(int departementId)
        {
            DynamicParameters dynamicParameters = new DynamicParameters();
            dynamicParameters.Add("@id", departementId);
            return await SqlMapper.QueryFirstOrDefaultAsync<Department>
                (
                cnn: connect, sql: "Sp_GetById", param: dynamicParameters, commandType: CommandType.StoredProcedure
                );

        }
    }
}
