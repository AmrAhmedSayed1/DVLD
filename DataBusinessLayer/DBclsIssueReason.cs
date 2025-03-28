using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using DataAccessLayer;

namespace DataBusinessLayer
{
    public class DBclsIssueReason
    {
        public static string GetIssueReasonNameByID(int IssueReasonID)
        {
            return clsCRUD.GetValueFromTable("IssueReasonName", "IssueReasons", "IssueReasonID", IssueReasonID.ToString());
        }
    }
}
