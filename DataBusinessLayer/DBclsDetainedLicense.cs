using System;
using System.Data;
using DataAccessLayer;

namespace DataBusinessLayer
{
    public class DBclsDetainedLicense
    {
        public int DetainID { get; private set; }
        public int LicenseID { get; set; }
        public DateTime DetainDate { get; set; }
        public float FineFees { get; set; }
        public int ByUserID { get; set; }
        public bool IsReleased { get; set; }
        public int? ReleaseAppID { get; set; }
        public int? ReleasedByUserID { get; set; }
        public DateTime? ReleaseDate { get; set; }

        private enum _enMode { AddNew, Update }
        private _enMode _EnMode;

        public DBclsDetainedLicense()
        {
            DetainID = 0;
            LicenseID = 0;
            DetainDate = DateTime.Now;
            FineFees = 0;
            ByUserID = 0;
            IsReleased = false;
            ReleaseAppID = null;
            ReleasedByUserID = null;
            ReleaseDate = null;
            _EnMode = _enMode.AddNew;
        }

        public DBclsDetainedLicense(int detainID)
        {
            int licenseID = 0, byUserID = 0;
            DateTime detainDate = DateTime.Now;
            float fineFees = 0;
            bool isReleased = false;
            int? releaseAppID = null;
            int? releasedByUserID = null;
            DateTime? releaseDate = null;

            if (DAclsDetainedLicense.GetDetainedLicenseByID(detainID, ref licenseID, ref detainDate, ref fineFees, ref byUserID,
                ref isReleased, ref releaseAppID, ref releasedByUserID, ref releaseDate))
            {
                DetainID = detainID;
                LicenseID = licenseID;
                DetainDate = detainDate;
                FineFees = fineFees;
                ByUserID = byUserID;
                IsReleased = isReleased;
                ReleaseAppID = releaseAppID;
                ReleasedByUserID = releasedByUserID;
                ReleaseDate = releaseDate;
                _EnMode = _enMode.Update;
            }
        }

        public DBclsDetainedLicense(int licenseID, bool ByLicenseID)
        {
            int detainID = 0;
            DateTime detainDate = DateTime.Now;
            float fineFees = 0;
            bool isReleased = false;
            int? releaseAppID = null;
            int byUserID = 0;
            int? releasedByUserID = null;
            DateTime? releaseDate = null;

            if (DAclsDetainedLicense.GetDetainedLicenseByLicenseID(ref detainID, licenseID, ref detainDate, ref fineFees,
                ref byUserID, ref isReleased, ref releaseAppID, ref releasedByUserID, ref releaseDate))
            {
                DetainID = detainID;
                LicenseID = licenseID;
                DetainDate = detainDate;
                FineFees = fineFees;
                ByUserID = byUserID;
                IsReleased = isReleased;
                ReleaseAppID = releaseAppID;
                ReleasedByUserID = releasedByUserID;
                ReleaseDate = releaseDate;
                _EnMode = _enMode.Update;
            }
        }

        private bool _AddNewDetainedLicense()
        {
            int tempID = DAclsDetainedLicense.AddNewDetainedLicense(LicenseID, DetainDate, FineFees, ByUserID,
                IsReleased, ReleaseAppID, ReleasedByUserID, ReleaseDate);
            if (tempID > 0)
            {
                DetainID = tempID;
                _EnMode = _enMode.Update;
                return true;
            }
            return false;
        }

        private bool _UpdateDetainedLicense()
        {
            return DAclsDetainedLicense.UpdateDetainedLicense(DetainID, LicenseID, DetainDate, FineFees,
                ByUserID, IsReleased, ReleaseAppID, ReleasedByUserID, ReleaseDate);
        }

        public bool Save()
        {
            return _EnMode == _enMode.AddNew ? _AddNewDetainedLicense() : _UpdateDetainedLicense();
        }

        public static DataTable GetAllDetainedLicenses()
        {
            return DAclsDetainedLicense.GetAllDetainedLicenses();
        }

        public static DataTable GetAllDetainedLicensesWithFilter(string ColumnName, string Value)
        {
            return DAclsDetainedLicense.GetAllDetainedLicensesWithFilter(ColumnName, Value);
        }

        public static int GetDetainIDByLicenseID(int LicenseID)
        {
            return DAclsDetainedLicense.GetDetainIDByLicenseID(LicenseID);
        }
    }
}