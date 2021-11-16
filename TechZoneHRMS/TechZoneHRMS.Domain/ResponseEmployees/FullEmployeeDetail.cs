using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TechZoneHRMS.Domain.ResponseEmployees
{
    public class FullEmployeeDetail : EmployeeDetail
    {
        public string DepartmentName { get; set; }
        public string BasicSalary { get; set; }
        public string Degree { get; set; }
    }
}
