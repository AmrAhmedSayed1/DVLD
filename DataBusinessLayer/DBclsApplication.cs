using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Net;
using System.Security.Policy;
using System.Text;
using System.Threading.Tasks;
using DataAccessLayer;
using static System.Net.Mime.MediaTypeNames;

namespace DataBusinessLayer
{
    public class DBclsApplication
    {
        public int AppID { get; set; }
        public int PersonID { get; set; }
        public int ByUserID { get; set; }
        public int AppTypeID {  get; set; }
        public int AppStatusID { get; set; }
        public int PassedTests { get; set; }
        public DateTime AppDate { get; set; }

        private enum _enmode { AddNew, Update}

        private _enmode _EnMode;

        public DBclsApplication()
        {
            AppID = 0;
            PersonID = 0;
            ByUserID = 0;
            AppTypeID = 0;
            AppStatusID = 0;
            PassedTests = 0;
            AppDate = new DateTime();
            _EnMode = _enmode.AddNew;
        }

        public DBclsApplication(int AppID)
        {
            int applicationID = 0;
            int personID = 0;
            int byUserID = 0;
            int applicationTypeID = 0;
            int applicationStatusID = 0;
            DateTime applicationDate = DateTime.Now;

            if (DAclsApplications.GetApplicationByID(applicationID, ref personID, ref byUserID,
                ref applicationTypeID, ref applicationStatusID, ref applicationDate, PassedTests))
            {
                AppID = applicationID;
                PersonID = personID;
                ByUserID = byUserID;
                AppTypeID = applicationTypeID;
                AppStatusID = applicationStatusID;
                AppDate = applicationDate;
                _EnMode = _enmode.Update;
            }
        }

        public static int IsPersonHasNewApplicationFromThisClass(int PersonID, int  ClassID)
        {
            return DAclsApplications.IsPersonHasNewApplicationFromThisClass(PersonID, ClassID); ;
        }

        public static DataTable GetAllApps()
        {
            return DAclsApplications.GitAllApplications();
        }

        private bool _AddNewApp()
        {
            int TempID = DAclsApplications.AddNewApplication(PersonID, ByUserID, AppTypeID, AppStatusID, AppDate, PassedTests);
            if (TempID > 0)
            {
                AppID = TempID;
                _EnMode = _enmode.Update;
                return true;
            }
            else
                return false;

        }

        private bool _UpdateApp()
        {
            return DAclsApplications.UpdateApplication(AppID, PersonID, ByUserID, AppTypeID, AppStatusID, AppDate);
        }

        public bool Save()
        {
            switch (_EnMode)
            {
                case _enmode.AddNew:
                    {
                        return _AddNewApp();
                    }
                default:
                    return _UpdateApp();
            }
        }

    }
}
