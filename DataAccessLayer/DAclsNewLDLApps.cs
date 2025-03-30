using System;
using System.Collections.Generic;
using System.Data;
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

            string QueryString = @"insert into NewLDLApps Values (@ApplicationID, @ClassID, 0, 0, 0, 0)
                                    select scope_identity();";

            SqlCommand Command = new SqlCommand(QueryString, Connection);

            Command.Parameters.AddWithValue("ApplicationID", AppID);
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

        public static bool GetNewLDLAppByID(int NewLDLAppID, ref int AppID, ref int ClassID, ref int PassedTests, ref int VisionTrial, ref int WrittenTrial, ref int StreetTrial)
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
                    PassedTests = (int)Reader["PassedTests"];
                    VisionTrial = (int)Reader["VisionTrial"];
                    WrittenTrial = (int)Reader["WrittenTrial"];
                    StreetTrial = (int)Reader["StreetTrial"];

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

        public static bool GetNewLDLAppByOriginAppID(int OriginAppID, ref int NewLDLAppID, ref int ClassID, ref int PassedTests, ref int VisionTrial, ref int WrittenTrial, ref int StreetTrial)
        {


            bool IsFound = false;

            SqlConnection Connection = new SqlConnection(DAclsSettings.ConnectionString);

            string QueryString = @"select * from NewLDLApps
                                   where ApplicationID = @OriginAppID";

            SqlCommand Command = new SqlCommand(QueryString, Connection);

            Command.Parameters.AddWithValue("OriginAppID", OriginAppID);

            try
            {
                Connection.Open();

                SqlDataReader Reader = Command.ExecuteReader();

                if (Reader.Read())
                {
                    NewLDLAppID = (int)Reader["NewLDLAppID"];
                    ClassID = (int)Reader["ClassID"];
                    PassedTests = (int)Reader["PassedTests"];
                    VisionTrial = (int)Reader["VisionTrial"];
                    WrittenTrial = (int)Reader["WrittenTrial"];
                    StreetTrial = (int)Reader["StreetTrial"];

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

        public static bool UpdateNewLDLApp(int NewLDLAppID, int AppID, int ClassID, int PassedTest, int VisionTrial, int WrittenTrial, int StreetTrial)
        {

            bool IsUpdated = false;

            SqlConnection Connection = new SqlConnection(DAclsSettings.ConnectionString);

            string QueryString = @"UPDATE [dbo].[NewLDLApps]
                                  SET [ApplicationID] = @AppID
                                     ,[ClassID] = @ClassID
                                     ,[PassedTests] = @PassedTest
                                     ,[VisionTrial] = @VisionTrial
                                     ,[WrittenTrial] = @WrittenTrial
                                     ,[StreetTrial] = @StreetTrial
                                     WHERE NewLDLAppID = @NewLDLAppID";

            SqlCommand Command = new SqlCommand(QueryString, Connection);

            Command.Parameters.AddWithValue("NewLDLAppID", NewLDLAppID);
            Command.Parameters.AddWithValue("ClassID", ClassID);
            Command.Parameters.AddWithValue("AppID", AppID);
            Command.Parameters.AddWithValue("PassedTest", PassedTest);
            Command.Parameters.AddWithValue("VisionTrial", VisionTrial);
            Command.Parameters.AddWithValue("WrittenTrial", WrittenTrial);
            Command.Parameters.AddWithValue("StreetTrial", StreetTrial);

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

        public static DataTable GetAllNewLDLAppsWithFilter(string ColumnName, string Value)
        {
            DataTable dt = new DataTable();

            using (SqlConnection connection = new SqlConnection(DAclsSettings.ConnectionString))
            {
                string QueryString = $@"select Applications.ApplicationID as [L.D.LApp ID], LicensesClasses.ClassName as [Class Name], Poeple.NationalNo as [National No],
                                        (Poeple.FirstName + ' ' + Poeple.SecondName + ' ' + Poeple.ThirdName + ' ' + ' ' + Poeple.LastName) as [Full Name],
                                        Applications.ApplicationDate as [Application Date], NewLDLApps.PassedTests as [Passed Test],
                                        Applications_Appointments_Status.statusName as [Status] from Applications join Poeple on Applications.PersonID =Poeple.PersonID
                                        join NewLDLApps on Applications.ApplicationID = NewLDLApps.ApplicationID
                                        join LicensesClasses on NewLDLApps.classID = LicensesClasses.ClassID join
                                        Applications_Appointments_Status on Applications.ApplicationStatusID = Applications_Appointments_Status.StatusID
                                        where Applications.ApplicationTypeID = (select ApplicationsTypes.ApplicationTypeID from ApplicationsTypes where ApplicationsTypes.ApplicationTypeName = 'New Local Driving License Service')
                                        and 
                                        {ColumnName} LIKE @Value";

                SqlCommand Command = new SqlCommand(QueryString, connection);

                Command.Parameters.AddWithValue("Value", "%" + Value + "%");

                try
                {
                    connection.Open();
                    SqlDataReader Reader = Command.ExecuteReader();

                    if (Reader.HasRows)
                    {
                        dt.Load(Reader);
                    }

                    Reader.Close();
                }
                catch
                {
                    dt = new DataTable();
                }
                finally
                {
                    connection.Close();
                }
            }

            return dt;
        }
        public static DataTable GetAllNewLDLApps()
        {
            DataTable dt = new DataTable();

            SqlConnection connection = new SqlConnection(DAclsSettings.ConnectionString);

            string QueryString = @"select Applications.ApplicationID as [L.D.LApp ID], LicensesClasses.ClassName as [Class Name], Poeple.NationalNo as [National No],
                                   (Poeple.FirstName + ' ' + Poeple.SecondName + ' ' + Poeple.ThirdName + ' ' + ' ' + Poeple.LastName) as [Full Name],
                                   Applications.ApplicationDate as [Application Date], NewLDLApps.PassedTests as [Passed Test],
                                   Applications_Appointments_Status.statusName as [Status] from Applications join Poeple on Applications.PersonID =Poeple.PersonID
                                   join NewLDLApps on Applications.ApplicationID = NewLDLApps.ApplicationID
                                   join LicensesClasses on NewLDLApps.classID = LicensesClasses.ClassID join
                                   Applications_Appointments_Status on Applications.ApplicationStatusID = Applications_Appointments_Status.StatusID
                                   where Applications.ApplicationTypeID = (select ApplicationsTypes.ApplicationTypeID from ApplicationsTypes where ApplicationsTypes.ApplicationTypeName = 'New Local Driving License Service')";

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
            catch
            {
                dt = new DataTable();
            }
            finally
            {
                connection.Close();
            }


            return dt;
        }

        public static bool DeleteNewLDLAPP(int NewLDLAppID)
        {
            bool IsDeleted = false;

            using (SqlConnection Connection = new SqlConnection(DAclsSettings.ConnectionString))
            {
                string QueryString = @"delete from NewLDLApps where NewLDLAppID = @NewLDLAppID;";

                SqlCommand Command = new SqlCommand(QueryString, Connection);

                Command.Parameters.AddWithValue("@NewLDLAppID", NewLDLAppID);


                try
                {
                    Connection.Open();

                    int NumOfAffectedRows = Command.ExecuteNonQuery();

                    IsDeleted = (NumOfAffectedRows > 0);
                }
                catch
                {
                    IsDeleted = false;
                }
                finally
                {
                    Connection.Close();
                }
            }

            return IsDeleted;
        }
    }
}