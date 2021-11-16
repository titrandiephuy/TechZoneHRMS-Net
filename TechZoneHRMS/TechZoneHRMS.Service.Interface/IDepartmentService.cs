using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TechZoneHRMS.Domain.Response;

namespace TechZoneHRMS.Service.Interface
{
    public interface IDepartmentService
    {
        Task<List<Department>> Get();
        Task<Department> GetById(int departementId);
        Task<CreateDepartment> CreateDepartment(Department department);
        Task<EditDepartment> EditDepartment(Department department);
        Task<ChangeStatusDepartment> ChangeStatusDepartment(int departementId);
        Task<List<DepartmentInformation>> Departmentinformation(int departmentId);
    }
}
