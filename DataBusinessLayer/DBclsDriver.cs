using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using DataAccessLayer;

namespace DataBusinessLayer
{
    public class DBclsDriver
    {
        public int DriverID { get; set; }
        public int PersonID { get; set; }

        public DBclsDriver()
        {
            DriverID = 0;
            PersonID = 0;
        }

        public DBclsDriver(int driverID)
        {
            int personID = 0;

            if(DAclsDriver.GetDriverByID(driverID, ref personID))
            {
                DriverID = driverID;
                PersonID = personID;
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

    }
}
