using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;
using CountryDBModels;
namespace CountryListsAPI.Controllers
{
    public class ContentController : ApiController
    {
        CountryDataAccessLayer dataLayer;
        Contents content;
        Countries countrie;
        List<Contents> contenets;
        List<Countries> countries;

        public HttpResponseMessage Get()
        {
            dataLayer = new CountryDataAccessLayer();

            contenets = new List<Contents>();

            contenets = dataLayer.returnContentWithCountry().ToList();

            return ControllerContext.Request.CreateResponse(HttpStatusCode.OK, new { contenets });
        }
        public HttpResponseMessage Get(string cons)
        {
            dataLayer = new CountryDataAccessLayer();

            content = new Contents();

            content = dataLayer.returnContentWithCountry(cons);

            return ControllerContext.Request.CreateResponse(HttpStatusCode.OK, new { content });
        }
        public void Post([FromBody] string values, Countries countrie)
        {

            dataLayer = new CountryDataAccessLayer();      

            dataLayer.insertNewCountry(values, countrie);
        }

    }
}
