using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataAccessLayer
{
    public class DAclsTestsTypes
    {
        public static DataTable GetAllTestsTypes()
        {
            DataTable dt = new DataTable();

            SqlConnection connection = new SqlConnection(DAclsSettings.ConnectionString);

            string QueryString = @"select * from TestsTypes";

            SqlCommand Command = new SqlCommand(QueryString, connection);

            try
            {
                connection.Open();

                SqlDataReader Reader = Command.ExecuteReader();

                if (Reader != null)
                {
                    dt.Load(Reader);
                }

                Reader.Close();
            }
            catch (Exception ex)
            {
                dt = new DataTable();
            }
            finally
            {
                connection.Close();
            }

            return dt;
        }

        public static bool UpdateTestType(int TestTypeID, string TestTypeName, string TestTypeDescription, float Fees)
        {

            bool IsUpdated = false;

            SqlConnection Connection = new SqlConnection(DAclsSettings.ConnectionString);

            string QueryString = @"update TestsTypes
                                   set TestTypeName = @TestTypeName, TestTypeDescription = @TestTypeDescription, Fees = @Fees
                                   where TestTypeID = @TestTypeID;";

            SqlCommand Command = new SqlCommand(QueryString, Connection);

            Command.Parameters.AddWithValue("TestTypeID", TestTypeID);
            Command.Parameters.AddWithValue("TestTypeName", TestTypeName);
            Command.Parameters.AddWithValue("TestTypeDescription", TestTypeDescription);
            Command.Parameters.AddWithValue("Fees", Fees);

            try
            {
                Connection.Open();

                int NumOfAffectedRows = Command.ExecuteNonQuery();

                IsUpdated = (NumOfAffectedRows > 0) ? true : false;
            }
            catch
            {
                IsUpdated = false;
            }
            finally
            {
                Connection.Close();
            }

            return IsUpdated;
        }
    }
}
