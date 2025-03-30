using System;
using System.Data;
using DataAccessLayer;

namespace DataBusinessLayer
{
    public class DBclsI_License
    {
        public int I_LicenseID { get; set; }
        public int DriverID { get; set; }
        public int LocalLicenseID { get; set; }
        public int ApplicationID { get; set; }
        public DateTime IssueDate { get; set; }
        public DateTime ExpirationDate { get; set; }
        public bool IsActive { get; set; }

        private enum _enMode { AddNew, Update }
        private _enMode _EnMode;

        public DBclsI_License()
        {
            I_LicenseID = 0;
            DriverID = 0;
            LocalLicenseID = 0;
            ApplicationID = 0;
            IssueDate = DateTime.Now;
            ExpirationDate = DateTime.Now;
            IsActive = true;
            _EnMode = _enMode.AddNew;
        }

        public DBclsI_License(int licenseID)
        {
            int driverID = 0, localLicenseID = 0, applicationID = 0;
            DateTime issueDate = DateTime.Now, expirationDate = DateTime.Now;
            bool isActive = true;

            if (DAclsI_License.GetLicenseByID(licenseID, ref driverID, ref localLicenseID, ref applicationID, ref issueDate, ref expirationDate, ref isActive))
            {
                I_LicenseID = licenseID;
                DriverID = driverID;
                LocalLicenseID = localLicenseID;
                ApplicationID = applicationID;
                IssueDate = issueDate;
                ExpirationDate = expirationDate;
                IsActive = isActive;
                _EnMode = _enMode.Update;
            }
        }

        private bool _UpdateLicense()
        {
            return DAclsI_License.UpdateLicense(I_LicenseID, DriverID, LocalLicenseID, ApplicationID, IssueDate, ExpirationDate, IsActive);
        }

        private bool _AddNewLicense()
        {
            int tempID = DAclsI_License.AddNewLicense(DriverID, LocalLicenseID, ApplicationID, IssueDate, ExpirationDate, IsActive);
            if (tempID > 0)
            {
                I_LicenseID = tempID;
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
            return DAclsI_License.GetAllLicensesWithFilter(PersonID);
        }

        public static bool IsValueExist(string TableName, string ColumnName, string Value)
        {
            return clsCRUD.IsValueExist(TableName, ColumnName, Value);
        }

        public static int GetDriverIDByPersonID(int PersonID)
        {
            return Convert.ToInt32(clsCRUD.GetValueFromTable("DriverID", "Drivers", "PersonID", PersonID.ToString()));
        }

        public static DataTable GetAllApplications()
        {
            return DAclsI_License.GetAllApplications();
        }

        public static DataTable GetAllApplicationsWithFilter(string ColumnName, string Value)
        {
            return DAclsI_License.GetAllApplicationsWithFilter(ColumnName, Value);
        }
    }
}
