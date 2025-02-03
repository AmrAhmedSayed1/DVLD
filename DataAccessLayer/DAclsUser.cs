using System;
using System.Data;
using System.Data.SqlClient;

namespace DataAccessLayer
{
    public static class DAclsUser
    {

        public static DataTable GitAllUsers()
        {
            DataTable dt = new DataTable();

            SqlConnection connection = new SqlConnection(DAclsSettings.ConnectionString);

            string QueryString = @"select * from UsersView;";

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


        public static DataTable GitAllUsersWithFilter(string ColumnName, string Value)
        {
            DataTable dt = new DataTable();

            

            SqlConnection connection = new SqlConnection(DAclsSettings.ConnectionString);

            string QueryString = $@"select * from UsersView where [{ColumnName}] like @Value ";

            SqlCommand Command = new SqlCommand(QueryString, connection);

            if(ColumnName == "Is Active")
            {
                Command.Parameters.AddWithValue("Value", (Value == "Yes") ? 1 : 0 );
            }
            else
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

        public static bool IsUserExist(int UserID)
        {
            bool isuserexist = false;

            DataTable dt = new DataTable();

            SqlConnection connection = new SqlConnection(DAclsSettings.ConnectionString);

            string QueryString = $@"SELECT 1 from Users where UserID = @UserID ";

            SqlCommand Command = new SqlCommand(QueryString, connection);

            Command.Parameters.AddWithValue("UserID", UserID);

            try
            {
                connection.Open();

                object Result = Command.ExecuteScalar();

                if (Result != null)
                {
                    isuserexist = true;
                }


            }
            catch (Exception ex)
            {
                isuserexist = false;
            }
            finally
            {
                connection.Close();
            }

            return isuserexist;
        }

        public static int AddNewUser(int PersonID, string UserName, string Password, int IsActive)
        {
            int UserID = 0;

            SqlConnection Connection = new SqlConnection(DAclsSettings.ConnectionString);

            string QueryString = @"insert into Users
                                   values 
                                   (@PersonID, @UserName, @Password, @IsActive);                                       
                                   select scope_identity();";

            SqlCommand Command = new SqlCommand(QueryString, Connection);

            Command.Parameters.AddWithValue("PersonID", PersonID);
            Command.Parameters.AddWithValue("UserName", UserName);
            Command.Parameters.AddWithValue("Password", Password);
            Command.Parameters.AddWithValue("IsActive", IsActive);
            

            try
            {
                Connection.Open();

                object Result = Command.ExecuteScalar();

                if (Result != null)
                {
                    if (int.TryParse(Result.ToString(), out int val))
                        UserID = val;
                }

            }
            catch
            {
                UserID = 0;
            }
            finally
            {
                Connection.Close();
            }

            return UserID;
        }

        public static bool GetUserByID(int UserID, ref int PersonID, ref string UserName, ref string Password, ref int IsActive)
        {

            bool IsFound = false;

            SqlConnection Connection = new SqlConnection(DAclsSettings.ConnectionString);

            string QueryString = @"select PersonID, UserName, Password, IsActive from Users where UserID = @UserID";

            SqlCommand Command = new SqlCommand(QueryString, Connection);

            Command.Parameters.AddWithValue("UserID", UserID);


            try
            {
                Connection.Open();

                SqlDataReader Reader = Command.ExecuteReader();

                if (Reader.Read())
                {
                    PersonID = (int)Reader["PersonID"];
                    UserName = (string)Reader["UserName"];
                    Password = (string)Reader["Password"];
                    IsActive = ((bool)Reader["IsActive"] == true) ? 1 : 0;
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

        public static bool UpdateUser(int UserID, string UserName, string Password, int IsActive)
        {

            bool IsUpdated = false;

            SqlConnection Connection = new SqlConnection(DAclsSettings.ConnectionString);

            string QueryString = @"update Users
                                   set UserName = @UserName, @Password = @Password,
                                   IsActive = @IsActive
                                   where UserID = @UserID;";

            SqlCommand Command = new SqlCommand(QueryString, Connection);

            Command.Parameters.AddWithValue("UserID", UserID);
            Command.Parameters.AddWithValue("UserName", UserName);
            Command.Parameters.AddWithValue("Password", Password);
            Command.Parameters.AddWithValue("IsActive", IsActive);
            
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

        public static bool DeleteUser(int UserID)
        {
            bool IsDeleted = false;

            SqlConnection Connection = new SqlConnection(DAclsSettings.ConnectionString);

            string QueryString = @"delete from Users where UserID = @UserID;";

            SqlCommand Command = new SqlCommand(QueryString, Connection);

            Command.Parameters.AddWithValue("UserID", UserID);

            try
            {
                Connection.Open();

                int NumOfAffectedRows = Command.ExecuteNonQuery();

                IsDeleted = (NumOfAffectedRows > 0) ? true : false;
            }
            catch
            {
                IsDeleted = false;
            }
            finally
            {
                Connection.Close();
            }

            return IsDeleted;

        }


        public static bool IsValueExist(string ColumnName, string Value)
        {
            bool isvalueexist = false;

            DataTable dt = new DataTable();

            SqlConnection connection = new SqlConnection(DAclsSettings.ConnectionString);

            string QueryString = $@"SELECT 1 from Users where {ColumnName} = @Value ";

            SqlCommand Command = new SqlCommand(QueryString, connection);

            Command.Parameters.AddWithValue("Value", Value);

            try
            {
                connection.Open();

                object Result = Command.ExecuteScalar();

                if (Result != null)
                {
                    isvalueexist = true;
                }


            }
            catch (Exception ex)
            {
                isvalueexist = false;
            }
            finally
            {
                connection.Close();
            }

            return isvalueexist;
        }

    }
}
