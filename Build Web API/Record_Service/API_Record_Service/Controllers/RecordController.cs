using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;
using RecordDataAccess;

namespace API_Record_Service.Controllers
{
    public class RecordController : ApiController
    {
        Record redord;
        List<Record> records;
        DatabaseAEntities databaseEntities;
        //Retrurn entire record
        public HttpResponseMessage GetRecord()  
        {
            records = new List<Record>();
            using (databaseEntities = new DatabaseAEntities())            
            {
                var recordResult = (from result in databaseEntities.Records
                                   select result).ToArray();
                foreach (Record earchRecord in recordResult)
                {
                    redord = new Record()
                    {
                        ID = earchRecord.ID,
                        Name = earchRecord.Name,
                        City = earchRecord.country,
                        country = earchRecord.country
                    };                                      
                    records.Add(redord);
                }
            }
            return ControllerContext.Request.CreateResponse(HttpStatusCode.OK, new { records });
        }
        //Return single record
        public HttpResponseMessage GetRecordByID(int id)  
        {
            records = new List<Record>();
            using (databaseEntities = new DatabaseAEntities())
            {
                var recordResult = (from result in databaseEntities.Records
                                    where result.ID == id
                                    select result).ToArray();
                foreach (Record earchRecord in recordResult)
                {
                    redord = new Record()
                    {
                        ID = earchRecord.ID,
                        Name = earchRecord.Name,
                        City = earchRecord.country,
                        country = earchRecord.country
                    };
                    records.Add(redord);
                }
            }
            return ControllerContext.Request.CreateResponse(HttpStatusCode.OK, new { records });
        }
        //Add new record 
        public HttpResponseMessage Post([FromBody]Record newRecord)
        {
            redord = new Record();
            using (databaseEntities = new DatabaseAEntities())
            {

                redord.Name = newRecord.Name;
                redord.country = newRecord.country;
                redord.City = newRecord.City;
                databaseEntities.SaveChanges();
            }
            var message = Request.CreateResponse(HttpStatusCode.Created, redord);
            message.Headers.Location = new Uri(Request.RequestUri + redord.ID.ToString());
            return message;
        }
    }
}
