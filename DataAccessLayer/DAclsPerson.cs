﻿using System;
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
    public class DAclsPerson : clsCRUD
    {
        public static DataTable GetAllPoeple()
        {
            DataTable dt = new DataTable();

            SqlConnection connection = new SqlConnection(DAclsSettings.ConnectionString);

            string QueryString = @"SELECT Poeple.PersonID, Poeple.NationalNo,
                                   Poeple.FirstName, Poeple.SecondName, Poeple.ThirdName,
                                   Poeple.LastName,
                                   case 
                                   when Gender = 1 then 'Male'
                                   else 'Female'
                                   end as Gender ,case 
                                   when ImagePath is NULL then ''
                                   else ImagePath
                                   end as ImagePath,
                                   Poeple.Address, Poeple.DateOfBirth, Poeple.Phone,
                                   Poeple.Email, Countries.CountryName
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

        public static DataTable GetAllPoepleWithFilter(string ColumnName, string Value)
        {
            DataTable dt = new DataTable();

            SqlConnection connection = new SqlConnection(DAclsSettings.ConnectionString);

            string QueryString = $@"SELECT Poeple.PersonID, Poeple.NationalNo,
                                   Poeple.FirstName, Poeple.SecondName, Poeple.ThirdName,
                                   Poeple.LastName, case 
                                   when Gender = 1 then 'Male'
                                   else 'Female'
                                   end as Gender,case 
                                   when ImagePath is NULL then ''
                                   else ImagePath
                                   end as ImagePath, Poeple.Address,
                                   Poeple.DateOfBirth, Poeple.Phone, Poeple.Email,
                                   Countries.CountryName
                                   FROM     Poeple INNER JOIN
                                   Countries ON Poeple.CountryID = Countries.CountryID
                                   where {ColumnName} like @Value ";

            SqlCommand Command = new SqlCommand(QueryString, connection);

            if (ColumnName == "Gender")
            {
                if (Value.ToLower() == "male")
                    Command.Parameters.AddWithValue("Value", "%" +  1 + "%");
                else if (Value.ToLower() == "female")
                    Command.Parameters.AddWithValue("Value", "%" + 0 + "%");
                else
                    return new DataTable();
            }
            else
                Command.Parameters.AddWithValue("Value", "%" +  Value + "%");


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

        public static int AddNewPerson(string NationalNo, string FirstName, string SecondName, string ThirdName, string LastName, string Email, string Phone, string Address, int CountryID, string ImagePath, DateTime DateOfBirth, String Gender)
        {
            int PersonID = 0;

            SqlConnection Connection = new SqlConnection(DAclsSettings.ConnectionString);

            int BitGender = (Gender == "Male") ? 1 : 0;

            string QueryString = @"                                 
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

            SqlCommand Command = new SqlCommand(QueryString, Connection);

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

        public static bool GetPersonByID(int  PersonID, ref  string NationalNo, ref string FirstName,
            ref string SecondName, ref string ThirdName, ref string LastName, ref string Email,
            ref string Phone, ref string Address, ref int CountryID, ref string ImagePath,
            ref DateTime DateOfBirth, ref String Gender)
        {

            bool IsFound = false;

            SqlConnection Connection = new SqlConnection(DAclsSettings.ConnectionString);

            string QueryString = @"SELECT Poeple.PersonID, Poeple.NationalNo,
                                   Poeple.FirstName, Poeple.SecondName, Poeple.ThirdName,
                                   Poeple.LastName,
                                   case 
                                   when Gender = 1 then 'Male'
                                   else 'Female'
                                   end as Gender , case 
                                   when ImagePath is NULL then ''
                                   else ImagePath
                                   end as ImagePath,
                                   Poeple.Address, Poeple.DateOfBirth, Poeple.Phone,
                                   Poeple.Email, Countries.CountryID
                                   FROM     Poeple INNER JOIN
                                   Countries ON Poeple.CountryID = Countries.CountryID
                                   where PersonID = @PersonID";

            SqlCommand Command = new SqlCommand(QueryString, Connection);

            Command.Parameters.AddWithValue("PersonID", PersonID);
            

            try
            {
                Connection.Open();

                SqlDataReader Reader = Command.ExecuteReader();

                if (Reader.Read())
                {
                    NationalNo = (string)Reader["NationalNo"];
                    FirstName = (string)Reader["FirstName"];
                    SecondName = (string)Reader["SecondName"];
                    ThirdName = (string)Reader["ThirdName"];
                    LastName = (string)Reader["LastName"];
                    Phone = (string)Reader["Phone"];
                    Email = (string)Reader["Email"];
                    Address = (string)Reader["Address"];
                    ImagePath = (string)Reader["ImagePath"];
                    CountryID = (int)Reader["CountryID"];
                    Gender = (string)Reader["Gender"];
                    DateOfBirth = (DateTime)Reader["DateOfBirth"];
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

        public static bool UpdatePerson(int PersonID, string NationalNo, string FirstName,
             string SecondName,  string ThirdName,  string LastName, string Email,
             string Phone,  string Address,  int CountryID, string ImagePath,
             DateTime DateOfBirth,  String Gender)
        {

            bool IsUpdated = false;

            int BitGender = (Gender == "Male") ? 1 : 0;

            SqlConnection Connection = new SqlConnection(DAclsSettings.ConnectionString);

            string QueryString = @"UPDATE [dbo].[Poeple]
                                  SET [NationalNo] = @NationalNo
                                     ,[FirstName] = @FirstName 
                                     ,[SecondName] = @SecondName
                                     ,[ThirdName] = @ThirdName 
                                     ,[LastName] = @LastName
                                     ,[ImagePath] = @ImagePath
                                     ,[Address] = @Address
                                     ,[DateOfBirth] = @DateOfBirth
                                     ,[CountryID] = @CountryID
                                     ,[Phone] = @Phone
                                     ,[Email] = @Email
                                     ,[Gender] = @Gender
                                     WHERE PersonID = @PersonID";

            SqlCommand Command = new SqlCommand(QueryString, Connection);

            Command.Parameters.AddWithValue("PersonID", PersonID);
            Command.Parameters.AddWithValue("NationalNo", NationalNo);
            Command.Parameters.AddWithValue("FirstName", FirstName);
            Command.Parameters.AddWithValue("SecondName", SecondName);
            Command.Parameters.AddWithValue("ThirdName", ThirdName);
            Command.Parameters.AddWithValue("LastName", LastName);
            if (ImagePath == "")
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
    }
}