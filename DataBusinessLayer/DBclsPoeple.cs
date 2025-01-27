using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using DataAccessLayer;

namespace DataBusinessLayer
{
    public class DBclsPoeple
    {

        public static DataTable GitAllPoeple()
        {
            return DAclsPoeple.GitAllPoeple();
        }

        public static DataTable GitAllPoepleWithFilter(string ColumnName, string Value)
        {
            return DAclsPoeple.GitAllPoepleWithFilter(ColumnName, Value);
        }

    }
}
