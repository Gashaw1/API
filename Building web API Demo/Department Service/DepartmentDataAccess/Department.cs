using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

using System.Data;
using System.Data.SqlClient;
using System.Configuration;

namespace DepartmentDataAccess
{

    public class Department
    {
        public int departmentID { get; set; }
        public string depName { get; set; }
        public string depManager { get; set; }
        public List<Employee> Employees { get; set; }

        //public virtual ICollection<Employee> Employees { get; set; }

    }

}