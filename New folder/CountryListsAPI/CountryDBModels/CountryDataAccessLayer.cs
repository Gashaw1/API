using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Data;
using System.Data.SqlClient;
using System.Configuration;

namespace CountryDBModels
{
    public class CountryDataAccessLayer
    {
        Contents content;
        Countries countrie;
        List<Contents> contenets;
        List<Countries> countries;

        SqlConnection con;
        SqlCommand cmd;
        SqlParameter param;

        string connStr = ConfigurationManager.ConnectionStrings["DatabaseAConnectionString3"].ConnectionString;
        //Retrurn all content with its countries
        public List<Contents> returnContentWithCountry()
        {
            contenets = new List<Contents>();
            using (con = new SqlConnection(connStr))
            {
                con.Open();
                cmd = new SqlCommand("SP_RETURN_ALL_CONTENT_NAME_AND_ID", con);
                cmd.CommandType = CommandType.StoredProcedure;
                SqlDataReader rdr = cmd.ExecuteReader();
                while (rdr.Read())
                {
                    content = new Contents();
                    content.contentID = Convert.ToInt32(rdr["CONTENTID#"]);
                    content.contentName = rdr["contentName"].ToString();
                    content.countriesss = returnCountries(content.contentID);
                    contenets.Add(content);
                }
            }
            return contenets;
        }
        //Return single content with countries
        public Contents returnContentWithCountry(string contentName)
        {
            content = new Contents();
            countries = new List<Countries>();
            using (con = new SqlConnection(connStr))
            {
                con.Open();
                cmd = new SqlCommand("SP_RETURN_CONTENTNAMEANDITSID_BY_CONTENTNAME", con);
                cmd.CommandType = CommandType.StoredProcedure;
                param = new SqlParameter("@CONTENTNAME", contentName);
                cmd.Parameters.Add(param);
                SqlDataReader rdr = cmd.ExecuteReader();

                while (rdr.Read())
                {
                    content = new Contents();

                    content.contentID = Convert.ToInt32(rdr["CONTENTID#"]);
                    content.contentName = rdr["contentName"].ToString();
                    content.countriesss = returnCountries(content.contentID);
                }
            }
            return content;
        }
        //return country by contentid which reference primay key in content
        public List<Countries> returnCountries(int contentID)
        {
            countries = new List<Countries>();
            using (con = new SqlConnection(connStr))
            {
                con.Open();
                cmd = new SqlCommand("SP_RETURN_COUNTRIES_BY_CONTENTID", con);
                cmd.CommandType = CommandType.StoredProcedure;
                param = new SqlParameter("@CONTENTID#", contentID);
                cmd.Parameters.Add(param);

                SqlDataReader rdr = cmd.ExecuteReader();
                while (rdr.Read())
                {
                    countrie = new Countries();
                    countrie.countryID = Convert.ToInt32(rdr["countryID#"]);
                    countrie.contentID = Convert.ToInt32(rdr["contentID#"]);
                    countrie.countryName = rdr["countryName"].ToString();
                    countrie.countryFlag = rdr["countryFlag"].ToString();
                    countries.Add(countrie);
                }

            }
            return countries;
        }
        //return country by countryname
        public Countries returnCountry(string countryName)
        {
            countrie = new Countries();
            using (con = new SqlConnection(connStr))
            {
                con.Open();
                cmd = new SqlCommand("SP_RETURN_COUNTRY_bY_COUNTRYNAME", con);
                cmd.CommandType = CommandType.StoredProcedure;
                param = new SqlParameter("@COUNTRYNAME", countryName);
                cmd.Parameters.Add(param);

                SqlDataReader rdr = cmd.ExecuteReader();
                while (rdr.Read())
                {
                    countrie.countryID = Convert.ToInt32(rdr["countryID#"]);
                    countrie.countryName = rdr["countryName"].ToString();
                    countrie.countryFlag = rdr["countryFlag"].ToString();
                }

            }
            return countrie;
        }      
        //add country
        public void insertNewCountry(string contentName, Countries country)
        {
            content = new Contents();
            content = returnContentWithCountry(contentName);    

            if (content.contentID != null)
            {
                countrie = new Countries();
                
                countrie = returnCountry(country.countryName);
                if (countrie.countryName == null)
                {
                    using (con = new SqlConnection(connStr))
                    {
                        con.Open();
                        cmd = new SqlCommand("SP_ADD_COUNTRY", con);
                        cmd.CommandType = CommandType.StoredProcedure;

                        SqlParameter paramCountryID = new SqlParameter("@COUNTRYID#", country.countryID);
                        cmd.Parameters.Add(paramCountryID);

                        SqlParameter paramContentID = new SqlParameter("@CONTENTID#", content.contentID);
                        cmd.Parameters.Add(paramContentID);

                        SqlParameter paramCountryName = new SqlParameter("@COUNTRYNAME", country.countryName);
                        cmd.Parameters.Add(paramCountryName);

                        SqlParameter paramCountryFlag = new SqlParameter("@COUNTRYFLAG", country.countryFlag);
                        cmd.Parameters.Add(paramCountryFlag);

                        cmd.ExecuteReader();
                    }
                }
            }

        }

    }
}