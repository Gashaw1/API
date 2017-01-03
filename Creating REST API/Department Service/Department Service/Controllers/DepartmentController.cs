using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;
using DepartmentDataAccess;

namespace Department_Service.Controllers
{
    public class DepartmentController : ApiController
    {

        DataAccessClass dataAccessClas;
        List<Department> departments;

        public HttpResponseMessage getDeperatment()
        {
            departments = new List<Department>();

            dataAccessClas = new DataAccessClass();

            departments = dataAccessClas.GetDepartmentWithEmployee().ToList();

            return ControllerContext.Request.CreateResponse(HttpStatusCode.OK, new { departments });
        }

    }
}
