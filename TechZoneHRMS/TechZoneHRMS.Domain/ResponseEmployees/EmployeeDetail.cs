﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TechZoneHRMS.Domain.ResponseEmployees
{
    public class EmployeeDetail
    {
        public int EmployeeId { get; set; }
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public bool Gender { get; set; }
        public string EmployeePhoneNumber { get; set; }
        public string Email { get; set; }
        public string EmployeeAddress { get; set; }
        public DateTime DateOfBirth { get; set; }
        public string PlaceOfOrigin { get; set; }
        public string Ethnicity { get; set; }
        public string EmployeeAvatar { get; set; }
        public int DepartmentId { get; set; }
        public int SalaryId { get; set; }
        public int EducationLevelId { get; set; }
        public bool EmployeeStatus { get; set; }

    }
}
