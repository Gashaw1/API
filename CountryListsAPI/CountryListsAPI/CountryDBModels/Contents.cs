using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace CountryDBModels
{
    public class Contents
    {
        public int contentID { get; set; }
        public string contentName { get; set; }
        public List<Countries> countriesss { get; set; }

        //constructer
        //public Contents();
        //public Contents(int contentID)
        //{
        //    this.contentID = contentID;
        //}
        //public Contents(int contentID, string contentName)
        //{
        //    this.contentID = contentID;
        //    this.contentName = contentName;
        //}
    }
}