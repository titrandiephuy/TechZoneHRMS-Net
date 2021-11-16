using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using TechZoneHRMS.Domain.Response;
using TechZoneHRMS.Service.Interface;

namespace TechZoneHRMS.API.Controllers
{
    [Route("[controller]")]
    [ApiController]
    public class DapperDepartmentController : ControllerBase
    {
        private readonly IDepartmentService departmentService;

        public DapperDepartmentController(IDepartmentService departmentService)
        {
            this.departmentService = departmentService;
        }
        [HttpGet]
        public async Task<List<Department>> Get()
        {
            return await departmentService.Get();
        }
        [HttpGet]
        [Route("{id}")]
        public async Task<Department> GetById(int id)
        {
            return await departmentService.GetById(id);
        }
        [HttpPost]
        public async Task<CreateDepartment> CreateDepartment(Department department)
        {
            return await departmentService.CreateDepartment(department);
        }
        [HttpPut]
        [Route("Edit")]
        public async Task<EditDepartment> EditDepartment(Department department)
        {
            return await departmentService.EditDepartment(department);
        }
        [HttpPatch]
        [Route("ChangeStatus/{id}")]
        public async Task<ChangeStatusDepartment> ChangeStatus(int id)
        {
            return await departmentService.ChangeStatusDepartment(id);
        }
        [HttpGet]
        [Route("Departmentinformation/{departmentId}")]
        public async Task<List<DepartmentInformation>> Departmentinformation(int departmentId)
        {
            return await departmentService.Departmentinformation(departmentId);
        }
    }
}
