using System;
using System.Data;
using System.Data.SqlClient;

namespace DataAccessLayer
{
    public class DAclsDetainedLicense
    {
        public static int AddNewDetainedLicense(int LicenseID, DateTime DetainDate, float FineFees, int ByUserID,
                                              bool IsReleased, int? ReleaseAppID, int? ReleasedByUserID, DateTime? ReleaseDate)
        {
            int DetainID = 0;
            using (SqlConnection Connection = new SqlConnection(DAclsSettings.ConnectionString))
            {
                string QueryString = @"INSERT INTO DetainedLicenses 
                                     (LicenseID, DetainDate, FineFees, ByUserID, IsReleased, ReleaseAppID, ReleasedByUserID, ReleaseDate) 
                                     VALUES (@LicenseID, @DetainDate, @FineFees, @ByUserID, @IsReleased, 
                                             @ReleaseAppID, @ReleasedByUserID, @ReleaseDate);
                                     SELECT SCOPE_IDENTITY();";

                SqlCommand Command = new SqlCommand(QueryString, Connection);
                Command.Parameters.AddWithValue("@LicenseID", LicenseID);
                Command.Parameters.AddWithValue("@DetainDate", DetainDate);
                Command.Parameters.AddWithValue("@FineFees", FineFees);
                Command.Parameters.AddWithValue("@ByUserID", ByUserID);
                Command.Parameters.AddWithValue("@IsReleased", IsReleased);
                Command.Parameters.AddWithValue("@ReleaseAppID", ReleaseAppID.HasValue ? (object)ReleaseAppID : DBNull.Value);
                Command.Parameters.AddWithValue("@ReleasedByUserID", ReleasedByUserID.HasValue ? (object)ReleasedByUserID : DBNull.Value);
                Command.Parameters.AddWithValue("@ReleaseDate", ReleaseDate.HasValue ? (object)ReleaseDate : DBNull.Value);

                try
                {
                    Connection.Open();
                    object Result = Command.ExecuteScalar();
                    if (Result != null && int.TryParse(Result.ToString(), out int val))
                        DetainID = val;
                }
                catch
                {
                    DetainID = 0;
                }
                finally
                {
                    Connection.Close();
                }
            }
            return DetainID;
        }

        public static bool UpdateDetainedLicense(int DetainID, int LicenseID, DateTime DetainDate, float FineFees,
                                               int ByUserID, bool IsReleased, int? ReleaseAppID, int? ReleasedByUserID, DateTime? ReleaseDate)
        {
            bool IsUpdated = false;
            using (SqlConnection Connection = new SqlConnection(DAclsSettings.ConnectionString))
            {
                string QueryString = @"UPDATE DetainedLicenses 
                                     SET LicenseID = @LicenseID, DetainDate = @DetainDate, FineFees = @FineFees, 
                                         ByUserID = @ByUserID, IsReleased = @IsReleased, ReleaseAppID = @ReleaseAppID,
                                         ReleasedByUserID = @ReleasedByUserID, ReleaseDate = @ReleaseDate
                                     WHERE DetainID = @DetainID";

                SqlCommand Command = new SqlCommand(QueryString, Connection);
                Command.Parameters.AddWithValue("@DetainID", DetainID);
                Command.Parameters.AddWithValue("@LicenseID", LicenseID);
                Command.Parameters.AddWithValue("@DetainDate", DetainDate);
                Command.Parameters.AddWithValue("@FineFees", FineFees);
                Command.Parameters.AddWithValue("@ByUserID", ByUserID);
                Command.Parameters.AddWithValue("@IsReleased", IsReleased);
                Command.Parameters.AddWithValue("@ReleaseAppID", ReleaseAppID.HasValue ? (object)ReleaseAppID : DBNull.Value);
                Command.Parameters.AddWithValue("@ReleasedByUserID", ReleasedByUserID.HasValue ? (object)ReleasedByUserID : DBNull.Value);
                Command.Parameters.AddWithValue("@ReleaseDate", ReleaseDate.HasValue ? (object)ReleaseDate : DBNull.Value);

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

        public static bool GetDetainedLicenseByID(int DetainID, ref int LicenseID, ref DateTime DetainDate,
                                                ref float FineFees, ref int ByUserID, ref bool IsReleased,
                                                ref int? ReleaseAppID, ref int? ReleasedByUserID, ref DateTime? ReleaseDate)
        {
            bool IsFound = false;
            using (SqlConnection Connection = new SqlConnection(DAclsSettings.ConnectionString))
            {
                string QueryString = @"SELECT LicenseID, DetainDate, FineFees, ByUserID, IsReleased, 
                                             ReleaseAppID, ReleasedByUserID, ReleaseDate
                                      FROM DetainedLicenses
                                      WHERE DetainID = @DetainID";

                SqlCommand Command = new SqlCommand(QueryString, Connection);
                Command.Parameters.AddWithValue("@DetainID", DetainID);

                try
                {
                    Connection.Open();
                    SqlDataReader Reader = Command.ExecuteReader();
                    if (Reader.Read())
                    {
                        LicenseID = (int)Reader["LicenseID"];
                        DetainDate = (DateTime)Reader["DetainDate"];
                        FineFees = (float)Reader["FineFees"];
                        ByUserID = (int)Reader["ByUserID"];
                        IsReleased = (bool)Reader["IsReleased"];
                        ReleaseAppID = Reader["ReleaseAppID"] != DBNull.Value ? (int?)Reader["ReleaseAppID"] : null;
                        ReleasedByUserID = Reader["ReleasedByUserID"] != DBNull.Value ? (int?)Reader["ReleasedByUserID"] : null;
                        ReleaseDate = Reader["ReleaseDate"] != DBNull.Value ? (DateTime?)Reader["ReleaseDate"] : null;
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

        public static bool GetDetainedLicenseByLicenseID(ref int DetainID, int LicenseID, ref DateTime DetainDate,
                                                       ref float FineFees, ref int ByUserID, ref bool IsReleased,
                                                       ref int? ReleaseAppID, ref int? ReleasedByUserID, ref DateTime? ReleaseDate)
        {
            bool IsFound = false;
            using (SqlConnection Connection = new SqlConnection(DAclsSettings.ConnectionString))
            {
                string QueryString = @"SELECT DetainID, LicenseID, DetainDate, FineFees, ByUserID, 
                                             IsReleased, ReleaseAppID, ReleasedByUserID, ReleaseDate
                                      FROM DetainedLicenses
                                      WHERE LicenseID = @LicenseID and IsReleased = 0";

                SqlCommand Command = new SqlCommand(QueryString, Connection);
                Command.Parameters.AddWithValue("@LicenseID", LicenseID);

                try
                {
                    Connection.Open();
                    SqlDataReader Reader = Command.ExecuteReader();
                    if (Reader.Read())
                    {
                        LicenseID = (int)Reader["LicenseID"];
                        DetainID = (int)Reader["DetainID"];
                        DetainDate = (DateTime)Reader["DetainDate"];
                        FineFees = Convert.ToSingle(Reader["FineFees"]);
                        ByUserID = (int)Reader["ByUserID"];
                        IsReleased = (bool)Reader["IsReleased"];
                        ReleaseAppID = Reader["ReleaseAppID"] != DBNull.Value ? (int?)Reader["ReleaseAppID"] : null;
                        ReleasedByUserID = Reader["ReleasedByUserID"] != DBNull.Value ? (int?)Reader["ReleasedByUserID"] : null;
                        ReleaseDate = Reader["ReleaseDate"] != DBNull.Value ? (DateTime?)Reader["ReleaseDate"] : null;
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

        public static DataTable GetAllDetainedLicenses()
        {
            DataTable dt = new DataTable();
            using (SqlConnection Connection = new SqlConnection(DAclsSettings.ConnectionString))
            {
                string QueryString = @"SELECT * FROM DetainedLicenseView";

                SqlCommand Command = new SqlCommand(QueryString, Connection);

                try
                {
                    Connection.Open();
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
                    Connection.Close();
                }
            }
            return dt;
        }

        public static DataTable GetAllDetainedLicensesWithFilter(string ColumnName, string Value)
        {
            if(ColumnName == "Is Released")
            {
                Value = (Value == "Yes") ? "1" : "0";
            }
            
            DataTable dt = new DataTable();
            using (SqlConnection Connection = new SqlConnection(DAclsSettings.ConnectionString))
            {
                string QueryString = $@"SELECT * FROM DetainedLicenseView where [{ColumnName}] like @Value";

                SqlCommand Command = new SqlCommand(QueryString, Connection);

                Command.Parameters.AddWithValue("Value", "%" +  Value + "%");

                try
                {
                    Connection.Open();
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
                    Connection.Close();
                }
            }
            return dt;
        }

        public static int GetDetainIDByLicenseID(int LicenseID)
        {
            int DetainID = 0;
            using (SqlConnection Connection = new SqlConnection(DAclsSettings.ConnectionString))
            {
                string QueryString = @"SELECT DetainID FROM DetainedLicenses 
                                      WHERE LicenseID = @LicenseID AND IsReleased = 0;";

                SqlCommand Command = new SqlCommand(QueryString, Connection);
                Command.Parameters.AddWithValue("@LicenseID", LicenseID);

                try
                {
                    Connection.Open();
                    object Result = Command.ExecuteScalar();
                    if (Result != null && int.TryParse(Result.ToString(), out int val))
                        DetainID = val;
                }
                catch
                {
                    DetainID = 0;
                }
                finally
                {
                    Connection.Close();
                }
            }
            return DetainID;
        }
    }
}