﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace PayrollSystem.Models
{
    public class SD
    {
        public enum Roles
        {
            HR,
            Admin,
            PayrollSpecalist,
            Worker,
            DepartmentHead
        }
        public const string HR = "HR";
        public const string Admin = "Admin";
        public const string PayrollSpecalist = "PayrollSpecalist";
        public const string DepartmentHead = "DepartmentHead";
        public const string Worker = "Worker";
    }
}
