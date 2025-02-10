using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataAccessLayer
{
    public class DAclsLicensesClasses : clsCRUD
    {
        public static string[] GetAllClassesNames()
        {
            List<string> ClassesNames = new List<string>();

            SqlConnection connection = new SqlConnection(DAclsSettings.ConnectionString);

            string QueryString = "select ClassName from LicensesClasses";

            SqlCommand Command = new SqlCommand(QueryString, connection);



            try
            {
                connection.Open();

                SqlDataReader Reader = Command.ExecuteReader();

                while (Reader.Read())
                {
                    ClassesNames.Add((string)Reader["ClassName"]);
                }

                Reader.Close();
            }
            catch (Exception ex)
            {
                ClassesNames = new List<string>();
            }
            finally
            {
                connection.Close();
            }

            return ClassesNames.ToArray();
        }
    }
}
