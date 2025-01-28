using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Security.Cryptography.X509Certificates;
using System.Text;
using System.Threading.Tasks;
using System.Data.SqlClient;
using System.Net;
using System.Security.Policy;

namespace DataAccessLayer
{
    public static class DAclsPerson
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

        public static bool IsValueExist(string ColumnName, string Value)
        {
            bool isvalueexist = false;

            DataTable dt = new DataTable();

            SqlConnection connection = new SqlConnection(DAclsSettings.ConnectionString);

            string QueryString = $@"SELECT 1 from Poeple where {ColumnName} = @Value ";

            SqlCommand Command = new SqlCommand(QueryString, connection);

            Command.Parameters.AddWithValue("Value",Value);

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
                isvalueexist= false;
            }
            finally
            {
                connection.Close();
            }

            return isvalueexist;
        }

        public static int AddNewPerson(string NationalNo, string FirstName, string SecondName, string ThirdName, string LastName, string Email, string Phone, string Address, int CountryID, string ImagePath, DateTime DateOfBirth, String Gender)
        {
            int PersonID = 0;

            SqlConnection Connection = new SqlConnection(DAclsSettings.ConnectionString);

            int BitGender = (Gender == "Male") ? 1 : 0;

            string QeryString = @"                                 
                                  INSERT INTO [dbo].[Poeple]
                                             ([NationalNo]
                                             ,[FirstName]
                                             ,[SecondName]
                                             ,[ThirdName]
                                             ,[LastName]
                                             ,[ImagePath]
                                             ,[Address]
                                             ,[DateOfBirth]
                                             ,[CountryID]
                                             ,[Phone]
                                             ,[Email]
                                             ,[Gender])
                                       VALUES
                                            (@NationalNo,  
                                             @FirstName,    
                                             @SecondName,   
                                             @ThirdName,    
                                             @LastName,     
                                             @ImagePath,    
                                             @Address,      
                                             @DateOfBirth,  
                                             @CountryID,    
                                             @Phone,        
                                             @Email,
                                             @Gender);
                                       
                                    select scope_identity();";

            SqlCommand Command = new SqlCommand(QeryString, Connection);

            Command.Parameters.AddWithValue("NationalNo", NationalNo);
            Command.Parameters.AddWithValue("FirstName", FirstName);
            Command.Parameters.AddWithValue("SecondName", SecondName);
            Command.Parameters.AddWithValue("ThirdName", ThirdName);
            Command.Parameters.AddWithValue("LastName", LastName);
            if(ImagePath == "")
                Command.Parameters.AddWithValue("ImagePath", DBNull.Value);
            else
                Command.Parameters.AddWithValue("ImagePath", ImagePath);
            Command.Parameters.AddWithValue("Address", Address);
            Command.Parameters.AddWithValue("DateOfBirth", DateOfBirth);
            Command.Parameters.AddWithValue("CountryID", CountryID);
            Command.Parameters.AddWithValue("Phone", Phone);
            Command.Parameters.AddWithValue("Email", Email);
            Command.Parameters.AddWithValue("Gender", BitGender);

            try
            {
                Connection.Open();

                object Result = Command.ExecuteScalar();

                if (Result != null)
                {
                    if (int.TryParse(Result.ToString(), out int val))
                        PersonID = val;
                }

            }
            catch
            {
                PersonID = 0;
            }
            finally
            {
                Connection.Close();
            }

            return PersonID;
        }

    }
}
