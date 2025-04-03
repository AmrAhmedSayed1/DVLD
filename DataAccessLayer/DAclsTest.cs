using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataAccessLayer
{
    public class DAclsTest
    {
        public static int AddNewTest(int TestAppointmentID, bool IsPassed, string Note)
        {
            int TestResultID = 0;

            using (SqlConnection Connection = new SqlConnection(DAclsSettings.ConnectionString))
            {
                string QueryString = @"
                                       INSERT INTO [dbo].[TestsResults] 
                                       ([TestAppointmentID], [IsPassed], [Note])
                                       VALUES 
                                       (@TestAppointmentID, @IsPassed, @Note);
                                       SELECT SCOPE_IDENTITY();";

                using (SqlCommand Command = new SqlCommand(QueryString, Connection))
                {
                    Command.Parameters.AddWithValue("@TestAppointmentID", TestAppointmentID);
                    Command.Parameters.AddWithValue("@IsPassed", IsPassed);

                    if (string.IsNullOrEmpty(Note))
                        Command.Parameters.AddWithValue("@Note", DBNull.Value);
                    else
                        Command.Parameters.AddWithValue("@Note", Note);

                    try
                    {
                        Connection.Open();
                        object Result = Command.ExecuteScalar();

                        if (Result != null && int.TryParse(Result.ToString(), out int val))
                        {
                            TestResultID = val;
                        }
                    }
                    catch (Exception ex)
                    {
                        TestResultID = 0;
                    }
                    finally
                    {
                        Connection.Close();
                    }
                }
            }

            return TestResultID;
        }
    }
}
