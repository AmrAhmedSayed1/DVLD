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

        public static float GetAppFees(int  AppTypeID)
        {
            return Convert.ToSingle(DAclsApplicationsTypes.GetValueFromTable("Fees", "ApplicationsTypes", "ApplicationTypeID", AppTypeID.ToString()));
        }

        public static int GetAppTypeID(string AppTypeName)
        {
            return Convert.ToInt32(DAclsApplicationsTypes.GetValueFromTable("ApplicationTypeID", "ApplicationsTypes", "ApplicationTypeName", AppTypeName));
        }

        public static string GetAppTypeName(int AppTypeID)
        {
            return DAclsApplicationsTypes.GetValueFromTable("ApplicationTypeName", "ApplicationsTypes", "ApplicationTypeID", AppTypeID.ToString());
        }
    }
}
