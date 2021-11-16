using Microsoft.Extensions.Configuration;
using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TechZoneHRMS.Service.Implement
{
    public class BaseService
    {
        private readonly IConfiguration configuration;
        protected IDbConnection connect;
        public BaseService(IConfiguration configuration)
        {
            connect = new SqlConnection(configuration.GetConnectionString("EmployeesManagementDbConnection"));
            this.configuration = configuration;
        }
    }
}
