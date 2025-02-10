using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataAccessLayer
{
    public class DAclsApplicationsTypes : clsCRUD
    {
        public static DataTable GetAllApplicationsTypes()
        {
            DataTable dt = new DataTable();

            SqlConnection connection = new SqlConnection(DAclsSettings.ConnectionString);

            string QueryString = @"select * from ApplicationsTypes";

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

        public static bool UpdateApplicationType(int ApplicationTypeID, string ApplicationTypeName, float ApplicationTypeFees)
        {

            bool IsUpdated = false;

            SqlConnection Connection = new SqlConnection(DAclsSettings.ConnectionString);

            string QueryString = @"update ApplicationsTypes
                                   set ApplicationTypeName = @ApplicationTypeName, Fees = @ApplicationTypeFees
                                   where ApplicationTypeID = @ApplicationTypeID;";

            SqlCommand Command = new SqlCommand(QueryString, Connection);

            Command.Parameters.AddWithValue("ApplicationTypeID", ApplicationTypeID);
            Command.Parameters.AddWithValue("ApplicationTypeName", ApplicationTypeName);
            Command.Parameters.AddWithValue("ApplicationTypeFees", ApplicationTypeFees);

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
