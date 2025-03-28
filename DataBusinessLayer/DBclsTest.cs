using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using DataAccessLayer;

namespace DataBusinessLayer
{
    public class DBclsTest
    {
        public int TestID { get; set; }
        public int TestAppointmentID { get; set; }
        public bool IsPassed { get; set; }
        public string Note { get; set; }

        private enum _enMode { AddNew, Update }

        private _enMode _EnMode;

        public DBclsTest()
        {
            TestID = 0;
            TestAppointmentID = 0;
            IsPassed = false;
            Note = "";
            _EnMode = _enMode.AddNew;
        }

        public bool _AddNewTest()
        {
            int TempID = DAclsTest.AddNewTest(TestAppointmentID, IsPassed, Note);
            if (TempID > 0)
            {
                TestID = TempID;
                _EnMode = _enMode.Update;
                return true;
            }
            else
                return false;
        }

        public bool Save()
        {
            return _AddNewTest();
        }
    }
}
