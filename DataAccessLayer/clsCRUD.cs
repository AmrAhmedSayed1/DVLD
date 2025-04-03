using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataAccessLayer
{
    public class clsCRUD
    {
        public static bool IsValueExist(string TableName, string ColumnName, string Value)
        {
            bool isvalueexist = false;

            DataTable dt = new DataTable();

            SqlConnection connection = new SqlConnection(DAclsSettings.ConnectionString);

            string QueryString = $@"SELECT 1 from {TableName} where {ColumnName} = @Value ";

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

        public static bool DeleteRecord(string From, string Where, string Value)
        {
            bool IsDeleted = false;

            SqlConnection Connection = new SqlConnection(DAclsSettings.ConnectionString);

            string QueryString = $@"delete from {From} where {Where} = @Value;";

            SqlCommand Command = new SqlCommand(QueryString, Connection);

            Command.Parameters.AddWithValue("Value", Value);

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

        public static string GetValueFromTable(string ColumnName, string From, string Where, string Value)
        {
            string Res = null;

            SqlConnection Connection = new SqlConnection(DAclsSettings.ConnectionString);

            string QueryString = $@"select {ColumnName} from {From} where {Where} = @Value";

            SqlCommand Command = new SqlCommand(QueryString, Connection);

            Command.Parameters.AddWithValue("Value", Value);

            try
            {
                Connection.Open();

                object Result = Command.ExecuteScalar();

                if (Result != null)
                {
                    Res = Result.ToString();
                }
            }
            catch
            {
                Res = null;
            }
            finally
            {
                Connection.Close();
            }

            return Res;
        }
    }
}
