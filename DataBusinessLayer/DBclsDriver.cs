using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using DataAccessLayer;

namespace DataBusinessLayer
{
    public class DBclsDriver : DBclsPerson
    {
        public int DriverID { get; set; }

        public DBclsDriver(int personID, bool IsNew = true)
        {
            DriverID = 0;
            FillPersonByPersonID(personID);
        }

        public DBclsDriver(int driverID)
        {
            int personID = 0;

            if(DAclsDriver.GetDriverByID(driverID, ref personID))
            {
                DriverID = driverID;
                
                FillPersonByPersonID(personID);
            }
        }

        public bool AddNew()
        {
            int Temp = 0;
            if((Temp = DAclsDriver.AddNewDriver(PersonID)) > 0)
            {
                DriverID = Temp;
                return true;
            }
            return false;
        }

        public static DataTable GetAllDrivers()
        {
            return DAclsDriver.GetAllDrivers();
        }

        public static DataTable GetAllDriversWithFilter(string ColumnName, string Value)
        {
            return DAclsDriver.GetAllDriversWithFilter(ColumnName, Value);
        }

        public static bool IsValueExist(string ColumnName, string Value, bool Dirvers = true)
        {
            return DAclsPerson.IsValueExist("Drivers", ColumnName, Value);
        }

    }
}
