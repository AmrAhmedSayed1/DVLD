using System;
using System.Data;
using System.Data.SqlClient;

namespace DataAccessLayer
{
    public class DAclsI_License
    {
        public static int AddNewLicense(int DriverID, int LocalLicenseID, int ApplicationID, DateTime IssueDate, DateTime ExpirationDate, bool IsActive)
        {
            int LicenseID = 0;
            using (SqlConnection Connection = new SqlConnection(DAclsSettings.ConnectionString))
            {
                string QueryString = @"INSERT INTO I_Licenses (DriverID, ApplicationID, LocalLicenseID, IssueDate, ExpirationDate, IsActive) 
                                       VALUES (@DriverID, @ApplicationID, @LocalLicenseID, @IssueDate, @ExpirationDate, @IsActive); 
                                       SELECT SCOPE_IDENTITY();";

                using (SqlCommand Command = new SqlCommand(QueryString, Connection))
                {
                    Command.Parameters.AddWithValue("@DriverID", DriverID);
                    Command.Parameters.AddWithValue("@ApplicationID", ApplicationID);
                    Command.Parameters.AddWithValue("@LocalLicenseID", LocalLicenseID);
                    Command.Parameters.AddWithValue("@IssueDate", IssueDate);
                    Command.Parameters.AddWithValue("@ExpirationDate", ExpirationDate);
                    Command.Parameters.AddWithValue("@IsActive", IsActive);

                    try
                    {
                        Connection.Open();
                        object Result = Command.ExecuteScalar();
                        if (Result != null && int.TryParse(Result.ToString(), out int val))
                            LicenseID = val;
                    }
                    catch
                    {
                        LicenseID = 0;
                    }
                }
            }
            return LicenseID;
        }

        public static bool UpdateLicense(int LicenseID, int DriverID, int ApplicationID, int LocalLicenseID, DateTime IssueDate, DateTime ExpirationDate, bool IsActive)
        {
            bool IsUpdated = false;
            using (SqlConnection Connection = new SqlConnection(DAclsSettings.ConnectionString))
            {
                string QueryString = @"UPDATE I_Licenses 
                                       SET DriverID=@DriverID, ApplicationID=@ApplicationID, LocalLicenseID=@LocalLicenseID, IssueDate=@IssueDate, ExpirationDate=@ExpirationDate, 
                                           IsActive=@IsActive 
                                       WHERE I_LicenseID=@LicenseID";

                using (SqlCommand Command = new SqlCommand(QueryString, Connection))
                {
                    Command.Parameters.AddWithValue("@LicenseID", LicenseID);
                    Command.Parameters.AddWithValue("@DriverID", DriverID);
                    Command.Parameters.AddWithValue("@ApplicationID", ApplicationID);
                    Command.Parameters.AddWithValue("@LocalLicenseID", LocalLicenseID);
                    Command.Parameters.AddWithValue("@IssueDate", IssueDate);
                    Command.Parameters.AddWithValue("@ExpirationDate", ExpirationDate);
                    Command.Parameters.AddWithValue("@IsActive", IsActive);

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
                }
            }
            return IsUpdated;
        }

        public static bool GetLicenseByID(int LicenseID, ref int DriverID, ref int ApplicationID, ref int LocalLicenseID, ref DateTime IssueDate, ref DateTime ExpirationDate, ref bool IsActive)
        {
            bool IsFound = false;
            using (SqlConnection Connection = new SqlConnection(DAclsSettings.ConnectionString))
            {
                string QueryString = @"SELECT * FROM I_Licenses WHERE I_LicenseID = @LicenseID";

                using (SqlCommand Command = new SqlCommand(QueryString, Connection))
                {
                    Command.Parameters.AddWithValue("@LicenseID", LicenseID);
                    try
                    {
                        Connection.Open();
                        SqlDataReader Reader = Command.ExecuteReader();
                        if (Reader.Read())
                        {
                            DriverID = (int)Reader["DriverID"];
                            ApplicationID = (int)Reader["ApplicationID"];
                            LocalLicenseID = (int)Reader["LocalLicenseID"];
                            IssueDate = (DateTime)Reader["IssueDate"];
                            ExpirationDate = (DateTime)Reader["ExpirationDate"];
                            IsActive = (bool)Reader["IsActive"];
                            IsFound = true;
                        }
                        Reader.Close();
                    }
                    catch
                    {
                        IsFound = false;
                    }
                }
            }
            return IsFound;
        }

        public static DataTable GetAllLicensesWithFilter(int PersonID)
        {
            DataTable dt = new DataTable();
            using (SqlConnection connection = new SqlConnection(DAclsSettings.ConnectionString))
            {
                string QueryString = @"SELECT I_LicenseID as [Int License ID], ApplicationID as [Application ID], LocalLicenseID as [L LicenseID], IssueDate as [Issue Date], ExpirationDate as [Exp Date], IsActive as [Is Active] 
                                       FROM I_Licenses 
                                       WHERE DriverID = (SELECT DriverID FROM Drivers WHERE PersonID = @PersonID)";

                using (SqlCommand Command = new SqlCommand(QueryString, connection))
                {
                    Command.Parameters.AddWithValue("@PersonID", PersonID);
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
                }
            }
            return dt;
        }

        public static DataTable GetAllApplications()
        {
            DataTable dt = new DataTable();

            SqlConnection connection = new SqlConnection(DAclsSettings.ConnectionString);

            string QueryString = @"select I_Licenses.I_LicenseID as [Int License ID], Applications.ApplicationID as [App ID],
                                   Drivers.DriverID as [Driver ID], Licenses.LicenseID as [License ID],
                                   I_Licenses.IssueDate as [Issue Date], I_Licenses.ExpirationDate as [Exp Date],
                                   I_Licenses.IsActive as [Is Active]
                                   from I_Licenses join Applications on I_Licenses.ApplicationID = Applications.ApplicationID
                                   join Drivers on I_Licenses.DriverID = Drivers.DriverID join Licenses on I_Licenses.LocalLicenseID = Licenses.LicenseID";

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


        public static DataTable GetAllApplicationsWithFilter(string ColumnName, string Value)
        {
            DataTable dt = new DataTable();

            SqlConnection connection = new SqlConnection(DAclsSettings.ConnectionString);

            string QueryString = $@"select I_Licenses.I_LicenseID as [Int License ID], Applications.ApplicationID as [App ID],
                                   Drivers.DriverID as [Driver ID], Licenses.LicenseID as [License ID],
                                   I_Licenses.IssueDate as [Issue Date], I_Licenses.ExpirationDate as [Exp Date],
                                   I_Licenses.IsActive as [Is Active]
                                   from I_Licenses join Applications on I_Licenses.ApplicationID = Applications.ApplicationID
                                   join Drivers on I_Licenses.DriverID = Drivers.DriverID join Licenses on I_Licenses.LocalLicenseID = Licenses.LicenseID
                                   where {ColumnName} like @Value ";

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

    }
}