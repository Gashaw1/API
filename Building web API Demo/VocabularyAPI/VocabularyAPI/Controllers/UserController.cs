using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;
using System.Web.Http.Cors;
using VocBusinessLayer;
namespace VocabularyAPI.Controllers
{
  
    [RoutePrefix("api/vocabulary")]
    public class UserController : ApiController
    {
        Object obj;
        BusinessLayers bus;
        VocDbContext.Users ur;     
        Object ar;

        public HttpResponseMessage Get()
        {
            BusinessLayers bus = new BusinessLayers();
            ar = bus.UserLogin();
            return ControllerContext.Request.CreateResponse(HttpStatusCode.OK, new { ar });
        }
        //user login
        public HttpResponseMessage get(string username, string password)
        {
            Array myArray;
            bus = new BusinessLayers();
            myArray = bus.userLogin(username, password).ToArray();
            return ControllerContext.Request.CreateResponse(HttpStatusCode.OK, new { myArray });

        }
        //user signup
        [HttpPost]
        public HttpResponseMessage Post([FromBody]VocDbContext.Users ob)
        {
            bus = new BusinessLayers();
            obj = bus.UserSignUp(ob);
           
            return ControllerContext.Request.CreateResponse(HttpStatusCode.OK, new { obj });
        }
        
    }
}

