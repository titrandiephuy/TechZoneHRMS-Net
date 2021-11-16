using Dapper;
using Microsoft.Extensions.Configuration;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TechZoneHRMS.Domain.ResponseEmployees;
using TechZoneHRMS.Service.Interface;

namespace TechZoneHRMS.Service.Implement
{
     public class EmployeeService : BaseService, IEmployeeService
    {
        public EmployeeService(IConfiguration configuration) : base(configuration)
        {

        }

        public async Task<ChangeStatusEmployee> ChangeStatusEmployee(int employeeId)
        {
            var result = new ChangeStatusEmployee()
            {
                Success = false,
                Message = "wrong"
            };
            try
            {
                DynamicParameters parameters = new DynamicParameters();
                parameters.Add("@EmployeeId", employeeId);
                var findResult = await SqlMapper.ExecuteAsync
                    (
                        cnn: connect,
                        sql: "Sp_ChangeStatusEmployeeId",
                        param: parameters,
                        commandType: CommandType.StoredProcedure
                    );
                if (findResult > 0)
                {
                    result.Success = true;
                    result.Message = "Employee create successfully";
                }
                return result;
            }
            catch (Exception ex)
            {

                return result;
            }
        }

        public async Task<CreateEmployee> CreateEmployee(EmployeeDetail employeeDetail)
        {
            var result = new CreateEmployee()
            {
                Success = false,
                Message = "wrong"
            };
            try
            {
                DynamicParameters parameters = new DynamicParameters();
                parameters.Add("@FirstName", employeeDetail.FirstName);
                parameters.Add("@LastName", employeeDetail.LastName);
                parameters.Add("@Gender", employeeDetail.Gender);
                parameters.Add("@EmployeePhoneNumber", employeeDetail.EmployeePhoneNumber);
                parameters.Add("@Email", employeeDetail.Email);
                parameters.Add("@EmployeeAddress", employeeDetail.EmployeeAddress);
                parameters.Add("@DateOfBirth", employeeDetail.DateOfBirth);
                parameters.Add("@PlaceOfOrigin", employeeDetail.PlaceOfOrigin);
                parameters.Add("@Ethnicity", employeeDetail.Ethnicity);
                parameters.Add("@EmployeeAvatar", employeeDetail.EmployeeAvatar);
                parameters.Add("@DepartmentId", employeeDetail.DepartmentId);
                parameters.Add("@SalaryId", employeeDetail.SalaryId);
                parameters.Add("@EducationLevelId", employeeDetail.EducationLevelId);
                parameters.Add("@EmployeeStatus", employeeDetail.EmployeeStatus);
                var createResult = await SqlMapper.ExecuteScalarAsync<int>
                    (
                        cnn: connect,
                        sql: "Sp_CreateEmployee",
                        param: parameters,
                        commandType: CommandType.StoredProcedure
                    );
                if (createResult > 0)
                {
                    result.Success = true;
                    result.Message = "Employee create successfully";
                }
                return result;
            }
            catch (Exception ex)
            {

                return result;
            }
        }

        public async Task<EditEmployee> EditEmployee(EmployeeDetail employeeDetail)
        {
            var result = new EditEmployee()
            {
                Success = false,
                Message = "wrong"
            };
            try
            {
                DynamicParameters parameters = new DynamicParameters();
                parameters.Add("@EmployeeId", employeeDetail.EmployeeId);
                parameters.Add("@FirstName", employeeDetail.FirstName);
                parameters.Add("@LastName", employeeDetail.LastName);
                parameters.Add("@Gender", employeeDetail.Gender);
                parameters.Add("@EmployeePhoneNumber", employeeDetail.EmployeePhoneNumber);
                parameters.Add("@Email", employeeDetail.Email);
                parameters.Add("@EmployeeAddress", employeeDetail.EmployeeAddress);
                parameters.Add("@DateOfBirth", employeeDetail.DateOfBirth);
                parameters.Add("@PlaceOfOrigin", employeeDetail.PlaceOfOrigin);
                parameters.Add("@Ethnicity", employeeDetail.Ethnicity);
                parameters.Add("@EmployeeAvatar", employeeDetail.EmployeeAvatar);
                parameters.Add("@DepartmentId", employeeDetail.DepartmentId);
                parameters.Add("@SalaryId", employeeDetail.SalaryId);
                parameters.Add("@EducationLevelId", employeeDetail.EducationLevelId);
                parameters.Add("@EmployeeStatus", employeeDetail.EmployeeStatus);
                var EditResult = await SqlMapper.ExecuteAsync
                    (
                        cnn: connect,
                        sql: "Sp_EditEmployee",
                        param: parameters,
                        commandType: CommandType.StoredProcedure
                    );
                if (EditResult > 0)
                {
                    result.Success = true;
                    result.Message = "Employee create successfully";
                }
                return result;
            }
            catch (Exception ex)
            {

                return result;
            }
        }

        public async Task<List<FullEmployeeDetail>> GetAllEmployee()
        {

                var result = await SqlMapper.QueryAsync<FullEmployeeDetail>
                (
                    cnn: connect, sql: "Sp_GetAllEmployee", commandType: CommandType.StoredProcedure
                );
                return result.ToList();
        }

        public async Task<EmployeeDetail> GetEmployeeById(int employeeId)
        {
            DynamicParameters dynamicParameters = new DynamicParameters();
            dynamicParameters.Add("@EmployeeId", employeeId);
            return await SqlMapper.QueryFirstOrDefaultAsync<EmployeeDetail>
                (
                    cnn: connect, sql: "Sp_GetEmployeeById",param: dynamicParameters, commandType: CommandType.StoredProcedure
                );
        }
    }
}
