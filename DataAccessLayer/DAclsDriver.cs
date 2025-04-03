using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataAccessLayer
{
    public class DAclsDriver
    {
        public static int AddNewDriver(int PersonID)
        {
            int DriverID = 0;

            SqlConnection Connection = new SqlConnection(DAclsSettings.ConnectionString);

            string QueryString = @"
                          INSERT INTO [dbo].[Drivers] ([PersonID])
                          VALUES (@PersonID);
                          SELECT SCOPE_IDENTITY();";

            SqlCommand Command = new SqlCommand(QueryString, Connection);

            Command.Parameters.AddWithValue("@PersonID", PersonID);

            try
            {
                Connection.Open();

                object Result = Command.ExecuteScalar();

                if (Result != null)
                {
                    if (int.TryParse(Result.ToString(), out int val))
                        DriverID = val;
                }
            }
            catch
            {
                DriverID = 0;
            }
            finally
            {
                Connection.Close();
            }

            return DriverID;
        }

        public static bool GetDriverByID(int DriverID, ref int PersonID)
        {
            bool IsFound = false;

            SqlConnection Connection = new SqlConnection(DAclsSettings.ConnectionString);

            string QueryString = @"
                          SELECT DriverID, PersonID
                          FROM Drivers
                          WHERE DriverID = @DriverID";

            SqlCommand Command = new SqlCommand(QueryString, Connection);

            Command.Parameters.AddWithValue("@DriverID", DriverID);

            try
            {
                Connection.Open();

                SqlDataReader Reader = Command.ExecuteReader();

                if (Reader.Read())
                {
                    PersonID = (int)Reader["PersonID"];
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

        public static DataTable GetAllDriversWithFilter(string ColumnName, string Value)
        {
            DataTable dt = new DataTable();

            SqlConnection connection = new SqlConnection(DAclsSettings.ConnectionString);

            string QueryString = $@"SELECT * from DriversView where [{ColumnName}] like @Value";

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

        public static DataTable GetAllDrivers()
        {
            DataTable dt = new DataTable();

            SqlConnection connection = new SqlConnection(DAclsSettings.ConnectionString);

            string QueryString = $@"SELECT * from DriversView;";

            SqlCommand Command = new SqlCommand(QueryString, connection);

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

    }
}
