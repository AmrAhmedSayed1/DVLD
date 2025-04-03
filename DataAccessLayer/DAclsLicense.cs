using System;
using System.Data;
using System.Data.SqlClient;

namespace DataAccessLayer
{
    public class DAclsLicense : clsCRUD
    {
        public static int AddNewLicense(int DriverID, int ClassID, int ApplicationID, DateTime IssueDate, DateTime ExpirationDate, int IssueReasonID, bool IsActive, bool IsDetained, string Note)
        {
            int LicenseID = 0;
            SqlConnection Connection = new SqlConnection(DAclsSettings.ConnectionString);
            string QueryString = @"INSERT INTO Licenses (DriverID, ClassID, ApplicationID, IssueDate, ExpirationDate, IssueReasonID, IsActive, IsDetained, Note) 
                                   VALUES (@DriverID, @ClassID, @ApplicationID, @IssueDate, @ExpirationDate, @IssueReasonID, @IsActive, @IsDetained, @Note); 
                                   SELECT SCOPE_IDENTITY();";

            SqlCommand Command = new SqlCommand(QueryString, Connection);
            Command.Parameters.AddWithValue("@DriverID", DriverID);
            Command.Parameters.AddWithValue("@ClassID", ClassID);
            Command.Parameters.AddWithValue("@ApplicationID", ApplicationID);
            Command.Parameters.AddWithValue("@IssueDate", IssueDate);
            Command.Parameters.AddWithValue("@ExpirationDate", ExpirationDate);
            Command.Parameters.AddWithValue("@IssueReasonID", IssueReasonID);
            Command.Parameters.AddWithValue("@IsActive", IsActive);
            Command.Parameters.AddWithValue("@IsDetained", IsDetained);
            Command.Parameters.AddWithValue("@Note", string.IsNullOrEmpty(Note) ? DBNull.Value : (object)Note);

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
            finally
            {
                Connection.Close();
            }
            return LicenseID;
        }

        public static bool UpdateLicense(int LicenseID, int DriverID, int ClassID, int ApplicationID, DateTime IssueDate, DateTime ExpirationDate, int IssueReasonID, bool IsActive, bool IsDetained, string Note)
        {
            bool IsUpdated = false;
            SqlConnection Connection = new SqlConnection(DAclsSettings.ConnectionString);
            string QueryString = @"UPDATE Licenses 
                                   SET DriverID=@DriverID, ClassID=@ClassID, ApplicationID=@ApplicationID, IssueDate=@IssueDate, ExpirationDate=@ExpirationDate, 
                                       IssueReasonID=@IssueReasonID, IsActive=@IsActive, IsDetained=@IsDetained, Note=@Note 
                                   WHERE LicenseID=@LicenseID";

            SqlCommand Command = new SqlCommand(QueryString, Connection);
            Command.Parameters.AddWithValue("@LicenseID", LicenseID);
            Command.Parameters.AddWithValue("@DriverID", DriverID);
            Command.Parameters.AddWithValue("@ClassID", ClassID);
            Command.Parameters.AddWithValue("@ApplicationID", ApplicationID);
            Command.Parameters.AddWithValue("@IssueDate", IssueDate);
            Command.Parameters.AddWithValue("@ExpirationDate", ExpirationDate);
            Command.Parameters.AddWithValue("@IssueReasonID", IssueReasonID);
            Command.Parameters.AddWithValue("@IsActive", IsActive);
            Command.Parameters.AddWithValue("@IsDetained", IsDetained);
            Command.Parameters.AddWithValue("@Note", string.IsNullOrEmpty(Note) ? DBNull.Value : (object)Note);

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

        public static bool GetLicenseByID(int LicenseID, ref int DriverID, ref int ClassID, ref int ApplicationID,
            ref DateTime IssueDate, ref DateTime ExpirationDate, ref int IssueReasonID, ref bool IsActive, ref bool IsDetained, ref string Note)
        {
            bool IsFound = false;

            SqlConnection Connection = new SqlConnection(DAclsSettings.ConnectionString);
            string QueryString = @"SELECT LicenseID, DriverID, ClassID, ApplicationID, IssueDate, ExpirationDate, IssueReasonID, IsActive, IsDetained,
                                   CASE 
                                       WHEN Note IS NULL THEN '' 
                                       ELSE Note 
                                   END AS Note
                                   FROM Licenses
                                   WHERE LicenseID = @LicenseID";

            SqlCommand Command = new SqlCommand(QueryString, Connection);
            Command.Parameters.AddWithValue("@LicenseID", LicenseID);

            try
            {
                Connection.Open();
                SqlDataReader Reader = Command.ExecuteReader();
                if (Reader.Read())
                {
                    DriverID = (int)Reader["DriverID"];
                    ClassID = (int)Reader["ClassID"];
                    ApplicationID = (int)Reader["ApplicationID"];
                    IssueDate = (DateTime)Reader["IssueDate"];
                    ExpirationDate = (DateTime)Reader["ExpirationDate"];
                    IssueReasonID = (int)Reader["IssueReasonID"];
                    IsActive = (bool)Reader["IsActive"];
                    IsDetained = (bool)Reader["IsDetained"];
                    Note = (string)Reader["Note"];
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

        public static bool GetLicenseByAppID(ref int LicenseID, ref int DriverID, ref int ClassID, int ApplicationID,
            ref DateTime IssueDate, ref DateTime ExpirationDate, ref int IssueReasonID, ref bool IsActive, ref bool IsDetained, ref string Note)
        {
            bool IsFound = false;

            SqlConnection Connection = new SqlConnection(DAclsSettings.ConnectionString);
            string QueryString = @"SELECT LicenseID, DriverID, ClassID, ApplicationID, IssueDate, ExpirationDate, IssueReasonID, IsActive, IsDetained,
                                   CASE 
                                       WHEN Note IS NULL THEN '' 
                                       ELSE Note 
                                   END AS Note
                                   FROM Licenses
                                   WHERE ApplicationID = @ApplicationID";

            SqlCommand Command = new SqlCommand(QueryString, Connection);
            Command.Parameters.AddWithValue("@ApplicationID", ApplicationID);

            try
            {
                Connection.Open();
                SqlDataReader Reader = Command.ExecuteReader();
                if (Reader.Read())
                {
                    LicenseID = (int)Reader["LicenseID"];
                    DriverID = (int)Reader["DriverID"];
                    ClassID = (int)Reader["ClassID"];
                    ApplicationID = (int)Reader["ApplicationID"];
                    IssueDate = (DateTime)Reader["IssueDate"];
                    ExpirationDate = (DateTime)Reader["ExpirationDate"];
                    IssueReasonID = (int)Reader["IssueReasonID"];
                    IsActive = (bool)Reader["IsActive"];
                    IsDetained = (bool)Reader["IsDetained"];
                    Note = (string)Reader["Note"];
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

        public static DataTable GetAllLicensesWithFilter(int PersonID)
        {
            DataTable dt = new DataTable();

            SqlConnection connection = new SqlConnection(DAclsSettings.ConnectionString);

            string QueryString = $@"select LicenseID as [LDL ID], ApplicationID as [App ID], ClassName as [Class Name], IssueDate as [Issue Date],
                                    ExpirationDate as [Expiration Date], IsActive as [Is Active]
                                    from Licenses join LicensesClasses on Licenses.ClassID = LicensesClasses.ClassID
                                    where DriverID = (select DriverID from Drivers where PersonID = @PersonID)";

            SqlCommand Command = new SqlCommand(QueryString, connection);

            Command.Parameters.AddWithValue("PersonID", PersonID);


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
