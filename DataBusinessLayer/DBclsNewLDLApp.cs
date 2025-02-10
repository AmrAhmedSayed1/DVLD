using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using DataAccessLayer;

namespace DataBusinessLayer
{
    public class DBclsNewLDLApp
    {
        public int NewLDLAppID { get; set; }

        public int AppID { get; set; }

        public int ClassID { get; set; }

        private enum _enmode { AddNew, Update}

        private _enmode _EnMode;

        public DBclsNewLDLApp()
        {
            
            NewLDLAppID = 0;
            AppID = 0;
            ClassID = 0;
            _EnMode = _enmode.AddNew;
        }

        public DBclsNewLDLApp (int newldlappid)
        {
            int appid = 0;
            int classid = 0;
            if (DAclsNewLDLApps.GetNewLDLAppByID(newldlappid, ref appid, ref classid))
            {
                NewLDLAppID = newldlappid;
                AppID = appid;
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

    }
}
