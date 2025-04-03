using System;
using System.Data;
using DataAccessLayer;

namespace DataBusinessLayer
{
    public class DBclsLicense
    {
        public int LicenseID { get; set; }
        public int DriverID { get; set; }
        public int ClassID { get; set; }
        public int ApplicationID { get; set; }
        public DateTime IssueDate { get; set; }
        public DateTime ExpirationDate { get; set; }
        public int IssueReasonID { get; set; }
        public bool IsActive { get; set; }
        public bool IsDetained { get; set; }
        public string Note { get; set; }

        private enum _enMode { AddNew, Update }
        private _enMode _EnMode;

        public DBclsLicense()
        {
            LicenseID = 0;
            DriverID = 0;
            ClassID = 0;
            ApplicationID = 0;
            IssueDate = DateTime.Now;
            ExpirationDate = DateTime.Now;
            IssueReasonID = 0;
            IsActive = true;
            IsDetained = false;
            Note = "";
            _EnMode = _enMode.AddNew;
        }

        public DBclsLicense(int licenseID)
        {
            int driverID = 0, classID = 0, applicationID = 0, issueReasonID = 0;
            DateTime issueDate = DateTime.Now, expirationDate = DateTime.Now;
            bool isActive = true, isDetained = false;
            string note = "";

            if (DAclsLicense.GetLicenseByID(licenseID, ref driverID, ref classID, ref applicationID, ref issueDate, ref expirationDate, ref issueReasonID, ref isActive, ref isDetained, ref note))
            {
                LicenseID = licenseID;
                DriverID = driverID;
                ClassID = classID;
                ApplicationID = applicationID;
                IssueDate = issueDate;
                ExpirationDate = expirationDate;
                IssueReasonID = issueReasonID;
                IsActive = isActive;
                IsDetained = isDetained;
                Note = note;
                _EnMode = _enMode.Update;
            }
        }

        public DBclsLicense(int appid, bool ByAppID)
        {
            int licenseID = 0, driverID = 0, classID = 0, issueReasonID = 0;
            DateTime issueDate = DateTime.Now, expirationDate = DateTime.Now;
            bool isActive = true, isDetained = false;
            string note = "";

            if (DAclsLicense.GetLicenseByAppID(ref licenseID, ref driverID, ref classID, appid, ref issueDate, ref expirationDate, ref issueReasonID, ref isActive, ref isDetained, ref note))
            {
                LicenseID = licenseID;
                DriverID = driverID;
                ClassID = classID;
                ApplicationID = appid;
                IssueDate = issueDate;
                ExpirationDate = expirationDate;
                IssueReasonID = issueReasonID;
                IsActive = isActive;
                IsDetained = isDetained;
                Note = note;
                _EnMode = _enMode.Update;
            }
        }

        private bool _UpdateLicense()
        {
            return DAclsLicense.UpdateLicense(LicenseID, DriverID, ClassID, ApplicationID, IssueDate, ExpirationDate, IssueReasonID, IsActive, IsDetained, Note);
        }

        private bool _AddNewLicense()
        {
            int tempID = DAclsLicense.AddNewLicense(DriverID, ClassID, ApplicationID, IssueDate, ExpirationDate, IssueReasonID, IsActive, IsDetained, Note);
            if (tempID > 0)
            {
                LicenseID = tempID;
                _EnMode = _enMode.Update;
                return true;
            }
            return false;
        }

        public bool Save()
        {
            return _EnMode == _enMode.AddNew ? _AddNewLicense() : _UpdateLicense();
        }

        public static DataTable GetAllLicenseWithFilter(int PersonID)
        {
            return DAclsLicense.GetAllLicensesWithFilter(PersonID);
        }

        public static bool IsValueExist(string TableName, string ColumnName, string Value)
        {
            return clsCRUD.IsValueExist(TableName, ColumnName, Value);
        }

        public static int GetDriverIDByPersonID(int PersonID)
        {
            return Convert.ToInt32(clsCRUD.GetValueFromTable("DriverID", "Drivers", "PersonID", PersonID.ToString()));
        }
    }
}
