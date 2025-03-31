using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using DataAccessLayer;

namespace DataBusinessLayer
{
    public class DBclsLicensesClasses
    {
        public static string[] GetAllClassesNames()
        {
            return DAclsLicensesClasses.GetAllClassesNames();
        }
        public static int GetLicenseClassIDByClassName(string className)
        {
            return Convert.ToInt32(DAclsLicensesClasses.GetValueFromTable("ClassID", "LicensesClasses", "ClassName", className));
        }

        public static string GetLicenseClassNameByClassID(int ClassID)
        {
            return DAclsLicensesClasses.GetValueFromTable("ClassName", "LicensesClasses", "ClassID", ClassID.ToString());
        }

        public static int GetValidityDate(int ClassID)
        {
            return Convert.ToInt32(clsCRUD.GetValueFromTable("Validity", "LicensesClasses", "ClassID", ClassID.ToString()));
        }

        public static float GetClassFeesByID(int ClassID)
        {
            return Convert.ToSingle(clsCRUD.GetValueFromTable("Fees", "LicensesClasses", "ClassID", ClassID.ToString()));
        }
    }
}