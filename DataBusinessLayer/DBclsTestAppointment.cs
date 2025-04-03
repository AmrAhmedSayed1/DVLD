using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using DataAccessLayer;

namespace DataBusinessLayer
{
    public class DBclsTestAppointment
    {
        public int TestAppointmentID { get; set; }
        public int ApplicationID { get; set; }
        public int NewLDLAppID { get; set; }
        public int ByUserID { get; set; }
        public DateTime TestDate { get; set; }
        public int StatusID { get; set; }
        public int TestTypeID { get; set; }
        public int PersonID { get; set; }
        public int OldAppID { get; set; }

        private enum _enmode { AddNew, Update, Delete };
        private _enmode _EnMode;

        public DBclsTestAppointment()
        {
            TestAppointmentID = 0;
            ApplicationID = 0;
            NewLDLAppID = 0;
            ByUserID = 0;
            TestDate = DateTime.Now;
            StatusID = 1;
            TestTypeID = 0;
            PersonID = 0;
            OldAppID = 0;
            _EnMode = _enmode.AddNew;
        }

        public DBclsTestAppointment(int testAppointmentID)
        {
            int applicationID = 0;
            int newLDLAppID = 0;
            int byUserID = 0;
            DateTime testDate = DateTime.Now;
            int appointmentStatusID = 0;
            int testTypeID = 0;
            int personID = 0;
            int oldAppID = 0;

            if (DAclsTestAppointment.GetTestAppointmentByID(testAppointmentID, ref applicationID, ref newLDLAppID,
                ref byUserID, ref testDate, ref appointmentStatusID, ref testTypeID, ref personID, ref oldAppID))
            {
                TestAppointmentID = testAppointmentID;
                ApplicationID = applicationID;
                NewLDLAppID = newLDLAppID;
                ByUserID = byUserID;
                TestDate = testDate;
                StatusID = appointmentStatusID;
                TestTypeID = testTypeID;
                PersonID = personID;
                OldAppID = oldAppID;
                _EnMode = _enmode.Update;
            }
        }

        public static DataTable GitAllTestsAppointmentsWithFilter(int NewLDLAppID, int TestTypeID)
        {
            return DAclsTestAppointment.GetAllTestAppointmentsWithFilter(NewLDLAppID, TestTypeID);
        }

        public bool _AddNewTestAppointment()
        {
            int TempID = DAclsTestAppointment.AddNewTestAppointment(ApplicationID, NewLDLAppID, ByUserID,
                TestDate, StatusID, TestTypeID, PersonID, OldAppID);

            if (TempID > 0)
            {
                TestAppointmentID = TempID;
                return true;
            }
            else
            {
                return false;
            }
        }

        private bool _UpdatedTestAppointment()
        {
            return DAclsTestAppointment.UpdateTestAppointment(TestAppointmentID, ApplicationID, NewLDLAppID,
                ByUserID, TestDate, StatusID, TestTypeID, PersonID, OldAppID);
        }

        public bool Save()
        {
            switch (_EnMode)
            {
                case _enmode.AddNew:
                    return _AddNewTestAppointment();
                default:
                    return _UpdatedTestAppointment();
            }
        }
    }
}
