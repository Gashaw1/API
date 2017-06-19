using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Data;
using System.Data.SqlClient;
using System.Configuration;

namespace DepartmentDataAccess
{
    public class CustomeConnection
    {
        string conString = ConfigurationManager.ConnectionStrings["DatabaseAConnectionString"].ConnectionString;

        public SqlConnection MyConnection()
        {
            SqlConnection con = new SqlConnection(conString);

            con.Open();
            return con;


        }
    }
}