using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace CountryDBModels
{
    public class Countries
    {
        public int countryID { get; set; }
        public int contentID { get; set; }
        public string countryName { get; set; }
        public string countryFlag { get; set; }

    }
}