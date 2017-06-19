using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace DepartmentDataAccess
{
    public class Employee
    {
        public int employeeID { get; set; }
        public string empFirstName { get; set; }
        public string empLastName { get; set; }
        public string empDateBirth { get; set; }
        public Nullable<int> empSalary { get; set; }
        public Nullable<int> departmentID_fk { get; set; }

       // public virtual Department Department { get; set; }
    }
}