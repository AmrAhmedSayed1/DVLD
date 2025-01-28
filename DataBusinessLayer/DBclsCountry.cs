using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using DataAccessLayer;

namespace DataBusinessLayer
{
    public class DBclsCountry
    {
        public int CountryID { get; set; }

        public string CountryName { get; set; }

        public static DataTable GitAllCountries()
        {
            return DAclsCountry.GitAllCountries();
        }

        public DBclsCountry(int CountryID, string CountryName)
        {
            this.CountryID = CountryID;
            this.CountryName = CountryName;
        }

        public DBclsCountry(int CountryID)
        {
            this.CountryName = DAclsCountry.GitCountryNameByCountryID(CountryID);
            this.CountryID = CountryID;
        }

        public DBclsCountry(string CountryName)
        {
            this.CountryID = DAclsCountry.GitCountryIDByCountryName(CountryName);
            this.CountryName = CountryName;
        }

        public DBclsCountry()
        {
            CountryID = 0;
            CountryName = "";
        }

    }
}
