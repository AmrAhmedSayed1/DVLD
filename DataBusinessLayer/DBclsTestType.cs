using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using DataAccessLayer;

namespace DataBusinessLayer
{
    public class DBclsTestType
    {
        public static bool UpateTestType(int TestTypeID, string TestTypeName, string TestTypeDescription, float Fees)
        {
            return DAclsTestsTypes.UpdateTestType(TestTypeID, TestTypeName, TestTypeDescription, Fees);
        }

        public static DataTable GetAllTestsTypes()
        {
            return DAclsTestsTypes.GetAllTestsTypes();
        }
    }
}
