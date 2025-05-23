﻿using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.ComponentModel.Design;

namespace DataAccessLayer
{
    public static class DAclsCountry
    {
        public static string[] GitAllCountries()
        {
            List<string> Countries = new List<string>();

            SqlConnection connection = new SqlConnection(DAclsSettings.ConnectionString);

            string QueryString = "select CountryName from Countries";

            SqlCommand Command = new SqlCommand(QueryString, connection);



            try
            {
                connection.Open();

                SqlDataReader Reader = Command.ExecuteReader();

                while (Reader.Read())
                {
                    Countries.Add((string)Reader["CountryName"]);
                }

                Reader.Close();
            }
            catch (Exception ex)
            {
                Countries = new List<string>();
            }
            finally
            {
                connection.Close();
            }

            return Countries.ToArray();
        }

        public static string GitCountryNameByCountryID(int CountryID)
        {
            string CountryName = "";
            DataTable dt = new DataTable();
            SqlConnection connection = new SqlConnection(DAclsSettings.ConnectionString);

            string QeryString = @"select CountryName from Countries where CountryID = @CountryID";

            SqlCommand Command = new SqlCommand(QeryString, connection);

            Command.Parameters.AddWithValue("CountryID", CountryID);

            try
            {
                connection.Open();

                object Result = Command.ExecuteScalar();

                if (Result != null)
                {
                    CountryName = (string)Result;
                }
            }
            catch (Exception ex)
            {
                CountryName = "";
            }
            finally
            {
                connection.Close();
            }
            return CountryName;
        }

        public static int GitCountryIDByCountryName(string CountryName)
        {
            int CountryID = 0;
            DataTable dt = new DataTable();
            SqlConnection connection = new SqlConnection(DAclsSettings.ConnectionString);

            string QeryString = @"select CountryID from Countries where CountryName = @CountryName";

            SqlCommand Command = new SqlCommand(QeryString, connection);

            Command.Parameters.AddWithValue("CountryName", CountryName);

            try
            {
                connection.Open();

                object Result = Command.ExecuteScalar();

                if (Result != null)
                {
                    CountryID = (int)Result;
                }
            }
            catch (Exception ex)
            {
                CountryID = 0;
            }
            finally
            {
                connection.Close();
            }
            return CountryID;
        }

    }
}
