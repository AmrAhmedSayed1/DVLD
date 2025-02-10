using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Net;
using System.Security.Policy;
using System.Text;
using System.Threading.Tasks;

namespace DataAccessLayer
{
    public class DAclsNewLDLApps : clsCRUD
    {
        public static int AddNewLDLApp(int AppID, int ClassID)
        {
            int NewLDLAppsID = 0;

            SqlConnection Connection = new SqlConnection(DAclsSettings.ConnectionString);

            string QueryString = @"insert into NewLDLApps Values (@AppID, @ClassID)
                                    select scope_identity();";

            SqlCommand Command = new SqlCommand(QueryString, Connection);

            Command.Parameters.AddWithValue("AppID", AppID);
            Command.Parameters.AddWithValue("ClassID", ClassID);
            

            try
            {
                Connection.Open();

                object Result = Command.ExecuteScalar();

                if (Result != null)
                {
                    if (int.TryParse(Result.ToString(), out int val))
                        NewLDLAppsID = val;
                }

            }
            catch
            {
                NewLDLAppsID = 0;
            }
            finally
            {
                Connection.Close();
            }

            return NewLDLAppsID;
        }

        public static bool GetNewLDLAppByID(int NewLDLAppID, ref int AppID, ref int ClassID)
        {


            bool IsFound = false;

            SqlConnection Connection = new SqlConnection(DAclsSettings.ConnectionString);

            string QueryString = @"select * from NewLDLApps
                                   where NewLDLAppID = @NewLDLAppID";

            SqlCommand Command = new SqlCommand(QueryString, Connection);

            Command.Parameters.AddWithValue("NewLDLAppID", NewLDLAppID);

            try
            {
                Connection.Open();

                SqlDataReader Reader = Command.ExecuteReader();

                if (Reader.Read())
                {
                    AppID = (int)Reader["ApplicationID"];
                    ClassID = (int)Reader["ClassID"];
                    
                    IsFound = true;
                }
                Reader.Close();
            }
            catch
            {
                IsFound = false;
            }
            finally
            {
                Connection.Close();
            }

            return IsFound;
        }

        public static bool UpdateNewLDLApp(int NewLDLAppID, int AppID, int ClassID)
        {

            bool IsUpdated = false;

            SqlConnection Connection = new SqlConnection(DAclsSettings.ConnectionString);

            string QueryString = @"UPDATE [dbo].[NewLDLApps]
                                  SET [AppID] = @AppID
                                     ,[ClassID] = @ClassID
                                     WHERE NewLDLAppID = @NewLDLAppID";

            SqlCommand Command = new SqlCommand(QueryString, Connection);

            Command.Parameters.AddWithValue("NewLDLAppID", NewLDLAppID);
            Command.Parameters.AddWithValue("ClassID", ClassID);
            Command.Parameters.AddWithValue("AppID", AppID);


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