using System;
using System.Collections.Generic;
using System.Data;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using DataAccessLayer;

namespace DataBusinessLayer
{
    public class DBclsApplicationType
    {
        public static bool UpateApplicationType(int AppTypeID, string AppTypeName, float AppTypeFees)
        {
            return DAclsApplicationsTypes.UpdateApplicationType(AppTypeID, AppTypeName, AppTypeFees);
        }

        public static DataTable GetAllApplicationsTypes()
        {
            return DAclsApplicationsTypes.GetAllApplicationsTypes();
        }

        public static float GetAppFees(string  AppTypeName)
        {
            return Convert.ToSingle(DAclsApplicationsTypes.GetValueFromTable("Fees", "ApplicationsTypes", "ApplicationTypeName", AppTypeName));
        }

        public static int GetAppTypeID(string AppTypeName)
        {
            return Convert.ToInt32(DAclsApplicationsTypes.GetValueFromTable("ApplicationTypeID", "ApplicationsTypes", "ApplicationTypeName", AppTypeName));
        }
    }
}
