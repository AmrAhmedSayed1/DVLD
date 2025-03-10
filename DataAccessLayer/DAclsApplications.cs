using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Net;
using System.Security.Policy;
using System.Text;
using System.Threading.Tasks;
using static System.Net.Mime.MediaTypeNames;

namespace DataAccessLayer
{
    public class DAclsApplications : clsCRUD
    {
        public static int IsPersonHasNewApplicationFromThisClass(int PersonID, int ClassID)
        {

            int AppID = 0;

            SqlConnection Connection = new SqlConnection(DAclsSettings.ConnectionString);

            string QueryString = @"SELECT NewLDLApps.ApplicationID
                  FROM     NewLDLApps FULL OUTER JOIN
                  Applications ON NewLDLApps.ApplicationID = Applications.ApplicationID FULL OUTER JOIN
                  LicensesClasses ON NewLDLApps.ClassID = LicensesClasses.ClassID FULL OUTER JOIN
                  Applications_Appointments_Status ON Applications.ApplicationStatusID = Applications_Appointments_Status.StatusID
				  WHERE Applications.PersonID = @PersonID AND Applications_Appointments_Status.StatusID = 1 AND LicensesClasses.ClassID = @ClassID;";

            SqlCommand Command = new SqlCommand(QueryString, Connection);

            Command.Parameters.AddWithValue("ClassID", ClassID);
            Command.Parameters.AddWithValue("PersonID", PersonID);

            try
            {
                Connection.Open();

                object Result = Command.ExecuteScalar();

                if (Result != null)
                {
                    if (int.TryParse(Result.ToString(), out int val))
                        AppID = val;
                }

            }
            catch
            {
                AppID = 0;
            }
            finally
            {
                Connection.Close();
            }

            return AppID;
        }

        public static int AddNewApplication(int PersonID, int ByUserID, int ApplicationTypeID, int ApplicationStatusID, DateTime ApplicationDate)
        {
            int AppID = 0;

            SqlConnection Connection = new SqlConnection(DAclsSettings.ConnectionString);

            string QueryString = @"INSERT INTO [dbo].[Applications]
                                      ([PersonID]
                                      ,[ByUserID]
                                      ,[ApplicationTypeID]
                                      ,[ApplicationStatusID]
                                      ,[ApplicationDate])
                                  VALUES
                                      (@PersonID,
                                       @ByUserID,
                                       @ApplicationTypeID,
                                       @ApplicationStatusID,
                                       @ApplicationDate);
                              
                                  SELECT SCOPE_IDENTITY();";
            
            SqlCommand Command = new SqlCommand(QueryString, Connection);

            Command.Parameters.AddWithValue("@PersonID", PersonID);
            Command.Parameters.AddWithValue("@ByUserID", ByUserID);
            Command.Parameters.AddWithValue("@ApplicationTypeID", ApplicationTypeID);
            Command.Parameters.AddWithValue("@ApplicationStatusID", ApplicationStatusID);
            Command.Parameters.AddWithValue("@ApplicationDate", ApplicationDate);

            try
            {
                Connection.Open();

                object Result = Command.ExecuteScalar();

                if (Result != null)
                {
                    if (int.TryParse(Result.ToString(), out int val))
                        AppID = val;
                }

            }
            catch
            {
                AppID = 0;
            }
            finally
            {
                Connection.Close();
            }

            return AppID;
        }

        public static bool GetApplicationByID(int ApplicationID, ref int PersonID, ref int ByUserID,
        ref int ApplicationTypeID, ref int ApplicationStatusID, ref DateTime ApplicationDate)
        {
            bool IsFound = false;

            using (SqlConnection Connection = new SqlConnection(DAclsSettings.ConnectionString))
            {
                string QueryString = @"
            SELECT 
                ApplicationID,
                PersonID,
                ByUserID,
                ApplicationTypeID,
                ApplicationStatusID,
                ApplicationDate
            FROM 
                Applications
            WHERE 
                ApplicationID = @ApplicationID";

                SqlCommand Command = new SqlCommand(QueryString, Connection);
                Command.Parameters.AddWithValue("@ApplicationID", ApplicationID);

                try
                {
                    Connection.Open();
                    SqlDataReader Reader = Command.ExecuteReader();

                    if (Reader.Read())
                    {
                        PersonID = (int)Reader["PersonID"];
                        ByUserID = (int)Reader["ByUserID"];
                        ApplicationTypeID = (int)Reader["ApplicationTypeID"];
                        ApplicationStatusID = (int)Reader["ApplicationStatusID"];
                        ApplicationDate = (DateTime)Reader["ApplicationDate"];

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
            }

            return IsFound;
        }

        public static bool UpdateApplication(int ApplicationID, int PersonID, int ByUserID,
        int ApplicationTypeID, int ApplicationStatusID, DateTime ApplicationDate)
        {
            bool IsUpdated = false;

            using (SqlConnection Connection = new SqlConnection(DAclsSettings.ConnectionString))
            {
                string QueryString = @"
            UPDATE [dbo].[Applications]
            SET 
                [PersonID] = @PersonID,
                [ByUserID] = @ByUserID,
                [ApplicationTypeID] = @ApplicationTypeID,
                [ApplicationStatusID] = @ApplicationStatusID,
                [ApplicationDate] = @ApplicationDate
            WHERE 
                ApplicationID = @ApplicationID";

                SqlCommand Command = new SqlCommand(QueryString, Connection);

                Command.Parameters.AddWithValue("@ApplicationID", ApplicationID);
                Command.Parameters.AddWithValue("@PersonID", PersonID);
                Command.Parameters.AddWithValue("@ByUserID", ByUserID);
                Command.Parameters.AddWithValue("@ApplicationTypeID", ApplicationTypeID);
                Command.Parameters.AddWithValue("@ApplicationStatusID", ApplicationStatusID);
                Command.Parameters.AddWithValue("@ApplicationDate", ApplicationDate);

                try
                {
                    Connection.Open();

                    int NumOfAffectedRows = Command.ExecuteNonQuery();

                    IsUpdated = (NumOfAffectedRows > 0);
                }
                catch
                {
                    IsUpdated = false;
                }
                finally
                {
                    Connection.Close();
                }
            }

            return IsUpdated;
        }
        

    }
}
