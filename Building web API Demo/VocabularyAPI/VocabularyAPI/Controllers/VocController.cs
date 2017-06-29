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

    public class VocController : ApiController
    {
        Object ar;
        ArrayList ars;
        BusinessLayers bus;
        //Test purp
        //get all voc
        public HttpResponseMessage Get()
        {
            bus = new BusinessLayers();
            //ar = bus.VocPointAsiOrder();
            // ar = bus.ReturnVocublarys()
            ar = bus.RturnAllVocublarys();
            return ControllerContext.Request.CreateResponse(HttpStatusCode.OK, new { ar });
        }
        public HttpResponseMessage Get(int userID, string username)
        {
            bus = new BusinessLayers();
            //ar = bus.VocPointAsiOrder();
            // ar = bus.ReturnVocublarys()
            ar = bus.RturnAllVocublarys(userID, username);
            return ControllerContext.Request.CreateResponse(HttpStatusCode.OK, new { ar });
        }
        //return voc by user id   

        //user add vocublary
        public HttpResponseMessage post([FromBody] VocDbContext.Vocabularys vocs)
        {
            bus = new BusinessLayers();
            ars = bus.AddMyVocublary(vocs);
            return ControllerContext.Request.CreateResponse(HttpStatusCode.OK, new { ars });
        }
        [HttpPut]
        public void put(int id, [FromBody] VocDbContext.Vocabularys newVocs)
        {
            bus = new BusinessLayers();
            bus.UpdateVocublarys(id, newVocs.vocabulary);
            var newDef = newVocs.Definitions[0].definition;

            //var newDef = from def in (newVocs.Definitions[0].vocabularyID == id)
            bus.UpdateDefinations(id, newDef.ToString());
            
            //  return ControllerContext.Request.CreateResponse(HttpStatusCode.OK, new { ars });  
        }

    }
}
