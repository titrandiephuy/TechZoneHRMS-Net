using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TechZoneHRMS.Domain.ResponseEmployees;

namespace TechZoneHRMS.Service.Interface
{
    public interface IEmployeeService
    {
        Task<List<FullEmployeeDetail>> GetAllEmployee();
        Task<CreateEmployee> CreateEmployee(EmployeeDetail employeeDetail);
        Task<EditEmployee> EditEmployee(EmployeeDetail employeeDetail);
        Task<FullEmployeeDetail> GetEmployeeById(int employeeId);
        Task<ChangeStatusEmployee> ChangeStatusEmployee(int employeeId);
    }
}
