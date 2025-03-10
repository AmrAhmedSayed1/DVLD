using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using DataAccessLayer;

namespace DataBusinessLayer
{
    public class DBclsNewLDLApp
    {
        public int NewLDLAppID { get; set; }

        public int AppID { get; set; }

        public int ClassID { get; set; }

        public int PassedTests { get; set; }

        private enum _enmode { AddNew, Update}

        private _enmode _EnMode;

        public DBclsNewLDLApp()
        {
            PassedTests = 0;
            NewLDLAppID = 0;
            AppID = 0;
            ClassID = 0;
            _EnMode = _enmode.AddNew;
        }

        public DBclsNewLDLApp (int newldlappid)
        {
            int appid = 0;
            int classid = 0;
            int passedTests = 0;
            if (DAclsNewLDLApps.GetNewLDLAppByID(newldlappid, ref appid, ref classid, ref passedTests))
            {
                PassedTests = passedTests;
                NewLDLAppID = newldlappid;
                AppID = appid;
                ClassID = classid;
                _EnMode = _enmode.Update;
            }
        }

        public DBclsNewLDLApp(int OriginAppID, bool ByOriginAppID = true)
        {
            int newldlappid = 0;
            int classid = 0;
            int passedTests = 0;
            if (DAclsNewLDLApps.GetNewLDLAppByOriginAppID(OriginAppID, ref newldlappid, ref classid, ref passedTests))
            {
                PassedTests = passedTests;
                NewLDLAppID = newldlappid;
                AppID = Convert.ToInt32(OriginAppID);
                ClassID = classid;
                _EnMode = _enmode.Update;
            }
        }

        private bool _AddNewLDLApp()
        {
            int TempID = 0;
            if((TempID = DAclsNewLDLApps.AddNewLDLApp(AppID, ClassID)) > 0)
            {
                NewLDLAppID = TempID;
                return true;
            }
            return false;
        }

        private bool _UpdateNewLDLApp()
        {
            return DAclsNewLDLApps.UpdateNewLDLApp(NewLDLAppID, AppID, ClassID);
        }

        public bool Save()
        {
            switch (_EnMode)
            {
                case _enmode.AddNew:
                    {
                        return _AddNewLDLApp();
                    }
                default:
                    return _UpdateNewLDLApp();
            }
        }

        public static DataTable GetAllNewLDLApps()
        {
            return DAclsNewLDLApps.GetAllNewLDLApps();
        }

        public static DataTable GetAllNewLDLAppsWithFilter(string ColumnName, string Value)
        {
            return DAclsNewLDLApps.GetAllNewLDLAppsWithFilter(ColumnName, Value);
        }

    }
}
