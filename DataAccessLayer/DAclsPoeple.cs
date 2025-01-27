using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Security.Cryptography.X509Certificates;
using System.Text;
using System.Threading.Tasks;
using System.Data.SqlClient;

namespace DataAccessLayer
{
    public static class DAclsPoeple
    {
        public static DataTable GitAllPoeple()
        {
            DataTable dt = new DataTable();

            SqlConnection connection = new SqlConnection(DAclsSettings.ConnectionString);

            string QueryString = @"SELECT Poeple.PersonID, Poeple.NationalNo, Poeple.FirstName, Poeple.SecondName, Poeple.ThirdName, Poeple.LastName, Poeple.ImagePath, Poeple.Address, Poeple.DateOfBirth, Poeple.Phone, Poeple.Email, Countries.CountryName
                                   FROM     Poeple INNER JOIN
                                   Countries ON Poeple.CountryID = Countries.CountryID";

            SqlCommand Command = new SqlCommand(QueryString, connection);

            

            try
            {
                connection.Open();

                SqlDataReader Reader = Command.ExecuteReader();

                if(Reader != null)
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


        public static DataTable GitAllPoepleWithFilter(string ColumnName, string Value)
        {
            DataTable dt = new DataTable();

            SqlConnection connection = new SqlConnection(DAclsSettings.ConnectionString);

            string QueryString = $@"SELECT Poeple.PersonID, Poeple.NationalNo, Poeple.FirstName, Poeple.SecondName, Poeple.ThirdName, Poeple.LastName, Poeple.ImagePath, Poeple.Address, Poeple.DateOfBirth, Poeple.Phone, Poeple.Email, Countries.CountryName
                                   FROM     Poeple INNER JOIN
                                   Countries ON Poeple.CountryID = Countries.CountryID
                                   where {ColumnName} like @Value ";

            SqlCommand Command = new SqlCommand(QueryString, connection);

            Command.Parameters.AddWithValue("Value", '%' + Value + '%');

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

    }
}
