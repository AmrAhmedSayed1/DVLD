using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataAccessLayer
{
    public class DAclsTestAppointment
    {
        public static DataTable GetAllTestAppointmentsWithFilter(int NewLDLAppID, int TestTypeID)
        {
            DataTable dt = new DataTable();

            SqlConnection connection = new SqlConnection(DAclsSettings.ConnectionString);

            string QueryString = $@"select TestAppointmentID as [Appointment ID], TestDate as [Appointment Date],
                                    Fees as [Paid Fees], 
                                    case
                                    when AppointmentStatusID = 1 then cast(0 as bit)
                                    else cast(1 as bit)
                                    end as [Is Locked]
                                    from TestsAppointments join TestsTypes on TestsAppointments.TestTypeID = TestsTypes.TestTypeID
                                    where NewLDLAppID = @NewLDLAppID and TestsAppointments.TestTypeID = @TestTypeID
                                    ";

            SqlCommand Command = new SqlCommand(QueryString, connection);
            Command.Parameters.AddWithValue("NewLDLAppID", NewLDLAppID);
            Command.Parameters.AddWithValue("TestTypeID", TestTypeID);

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

        public static int AddNewTestAppointment(int ApplicationID, int NewLDLAppID, int ByUserID, DateTime TestDate,
                                        int AppointmentStatusID, int TestTypeID, int PersonID, int OldAppID)
        {
            int TestAppointmentID = 0;
            SqlConnection Connection = new SqlConnection(DAclsSettings.ConnectionString);

            string QueryString = @"
        INSERT INTO [dbo].[TestsAppointments]
            ([ApplicationID], [NewLDLAppID], [ByUserID], [TestDate], 
             [AppointmentStatusID], [TestTypeID], [PersonID], [OldAppID])
        VALUES
            (@ApplicationID, @NewLDLAppID, @ByUserID, @TestDate, 
             @AppointmentStatusID, @TestTypeID, @PersonID, @OldAppID);
        SELECT SCOPE_IDENTITY();";

            SqlCommand Command = new SqlCommand(QueryString, Connection);

            Command.Parameters.AddWithValue("ApplicationID", ApplicationID);
            Command.Parameters.AddWithValue("NewLDLAppID", NewLDLAppID);
            Command.Parameters.AddWithValue("ByUserID", ByUserID);
            Command.Parameters.AddWithValue("TestDate", TestDate);
            Command.Parameters.AddWithValue("AppointmentStatusID", AppointmentStatusID);
            Command.Parameters.AddWithValue("TestTypeID", TestTypeID);
            Command.Parameters.AddWithValue("PersonID", PersonID);
            Command.Parameters.AddWithValue("OldAppID", OldAppID);

            try
            {
                Connection.Open();
                object Result = Command.ExecuteScalar();
                if (Result != null && int.TryParse(Result.ToString(), out int val))
                    TestAppointmentID = val;
            }
            catch
            {
                TestAppointmentID = 0;
            }
            finally
            {
                Connection.Close();
            }

            return TestAppointmentID;
        }


        public static bool UpdateTestAppointment(int TestAppointmentID, int ApplicationID, int NewLDLAppID, int ByUserID,
                                         DateTime TestDate, int AppointmentStatusID, int TestTypeID,
                                         int PersonID, int OldAppID)
        {
            bool IsUpdated = false;
            SqlConnection Connection = new SqlConnection(DAclsSettings.ConnectionString);

            string QueryString = @"
        UPDATE [dbo].[TestsAppointments]
        SET [ApplicationID] = @ApplicationID,
            [NewLDLAppID] = @NewLDLAppID,
            [ByUserID] = @ByUserID,
            [TestDate] = @TestDate,
            [AppointmentStatusID] = @AppointmentStatusID,
            [TestTypeID] = @TestTypeID,
            [PersonID] = @PersonID,
            [OldAppID] = @OldAppID
        WHERE TestAppointmentID = @TestAppointmentID";

            SqlCommand Command = new SqlCommand(QueryString, Connection);

            Command.Parameters.AddWithValue("TestAppointmentID", TestAppointmentID);
            Command.Parameters.AddWithValue("ApplicationID", ApplicationID);
            Command.Parameters.AddWithValue("NewLDLAppID", NewLDLAppID);
            Command.Parameters.AddWithValue("ByUserID", ByUserID);
            Command.Parameters.AddWithValue("TestDate", TestDate);
            Command.Parameters.AddWithValue("AppointmentStatusID", AppointmentStatusID);
            Command.Parameters.AddWithValue("TestTypeID", TestTypeID);
            Command.Parameters.AddWithValue("PersonID", PersonID);
            Command.Parameters.AddWithValue("OldAppID", OldAppID);

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

            return IsUpdated;
        }


        public static bool GetTestAppointmentByID(int TestAppointmentID, ref int ApplicationID, ref int NewLDLAppID,
                                          ref int ByUserID, ref DateTime TestDate, ref int AppointmentStatusID,
                                          ref int TestTypeID, ref int PersonID, ref int OldAppID)
        {
            bool IsFound = false;
            SqlConnection Connection = new SqlConnection(DAclsSettings.ConnectionString);

            string QueryString = @"
        SELECT [ApplicationID], [NewLDLAppID], [ByUserID], [TestDate], 
               [AppointmentStatusID], [TestTypeID], [PersonID], [OldAppID]
        FROM [dbo].[TestsAppointments]
        WHERE TestAppointmentID = @TestAppointmentID";

            SqlCommand Command = new SqlCommand(QueryString, Connection);
            Command.Parameters.AddWithValue("TestAppointmentID", TestAppointmentID);

            try
            {
                Connection.Open();
                SqlDataReader Reader = Command.ExecuteReader();

                if (Reader.Read())
                {
                    ApplicationID = (int)Reader["ApplicationID"];
                    NewLDLAppID = (int)Reader["NewLDLAppID"];
                    ByUserID = (int)Reader["ByUserID"];
                    TestDate = (DateTime)Reader["TestDate"];
                    AppointmentStatusID = (int)Reader["AppointmentStatusID"];
                    TestTypeID = (int)Reader["TestTypeID"];
                    PersonID = (int)Reader["PersonID"];

                    OldAppID = (int)Reader["OldAppID"];

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

    }
}