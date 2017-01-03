using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Data;
using System.Data.SqlClient;
using System.Configuration;
namespace DepartmentDataAccess
{
    public class DataAccessClass : Employee
    {
        List<Department> departments;
        List<Employee> employees;
        Employee employee;
        Department department;

        SqlConnection con;
        //SqlDataReader sqlDataReader;
        SqlCommand cmd;
        SqlParameter sqlParam;

        string conString = ConfigurationManager.ConnectionStrings["DatabaseAConnectionString"].ConnectionString;

        //return all 
        public List<Department> GetDepartmentWithEmployee()
        {
            departments = new List<DepartmentDataAccess.Department>();
           

            using (con = new SqlConnection(conString))
            {
                con.Open();               
                cmd = new SqlCommand("SP_GetDepartment", con);
                cmd.CommandType = CommandType.StoredProcedure;
               
               
               SqlDataReader sqlDataReader = cmd.ExecuteReader();
                while (sqlDataReader.Read())
                {
                    department = new Department();
                    department.departmentID = Convert.ToInt32(sqlDataReader["departmentID"]);
                    department.depManager = sqlDataReader["depManager"].ToString();
                    department.depName = sqlDataReader["depName"].ToString();
                    //invocked getEmp fun
                    department.Employees = getEmployeeByDepartment(department.departmentID);
                    departments.Add(department);

                };

            }
            return departments;
        }
        public List<Employee> getEmployeeByDepartment(int departmentID)
        {
            employees = new List<Employee>();
          

            using (con = new SqlConnection(conString))
            {
                con.Open();
                cmd = new SqlCommand("SP_GetEmployeeByDepartment", con);
                cmd.CommandType = CommandType.StoredProcedure;
                sqlParam = new SqlParameter("@departmentID", departmentID);
                cmd.Parameters.Add(sqlParam);

                SqlDataReader sqlDataReader = cmd.ExecuteReader();

                while (sqlDataReader.Read())
                {
                    employee = new Employee();
                    employee.employeeID = Convert.ToInt32(sqlDataReader["employeeID"]);
                    employee.departmentID_fk = Convert.ToInt32(sqlDataReader["departmentID_fk"]);
                    employee.empFirstName = sqlDataReader["empFirstName"].ToString();
                    employee.empLastName = sqlDataReader["empLastName"].ToString();
                    employee.empSalary = Convert.ToInt32(sqlDataReader["empSalary"]);
                    employees.Add(employee);

                }
               
            }
            return employees;
        }
    }

}