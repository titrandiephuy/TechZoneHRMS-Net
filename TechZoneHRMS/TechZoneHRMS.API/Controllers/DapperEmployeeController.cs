using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using TechZoneHRMS.Domain.ResponseEmployees;
using TechZoneHRMS.Service.Interface;

namespace TechZoneHRMS.API.Controllers
{
    [Route("[controller]")]
    [ApiController]
    public class DapperEmployeeController : ControllerBase
    {
        private readonly IEmployeeService employeeService;

        public DapperEmployeeController(IEmployeeService employeeService)
        {
            this.employeeService = employeeService;
        }

        [HttpGet]
        public async Task<List<FullEmployeeDetail>> GetAllEmployee()
        {
            return await employeeService.GetAllEmployee();
        }

        [HttpGet]
        [Route("{employeeId}")]
        public async Task<FullEmployeeDetail> GetEmployeeById(int employeeId)
        {
            return await employeeService.GetEmployeeById(employeeId);
        }

        [HttpPost]
        public async Task<CreateEmployee> CreateEmployee(EmployeeDetail employeeDetail)
        {
            return await employeeService.CreateEmployee(employeeDetail);
        }

        [HttpPut]
        public async Task<EditEmployee> EditEmployee(EmployeeDetail employeeDetail)
        {
            return await employeeService.EditEmployee(employeeDetail);
        }

        [HttpPatch]
        [Route("{employeeId}")]
        public async Task<ChangeStatusEmployee> ChangeStatusEmployee(int employeeId)
        {
            return await employeeService.ChangeStatusEmployee(employeeId);
        }
    }
}
