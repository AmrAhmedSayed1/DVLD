using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Net;
using System.Security.Policy;
using System.Text;
using System.Threading.Tasks;
using DataAccessLayer;

namespace DataBusinessLayer
{
    public class DBclsUser : DBclsPerson
    {
        public int UserID { get; set; }

        public string UserName { get; set; }

        public string Password { get; set; }

        public int IsActive { get; set; }

        public DBclsUser()
        {
            PersonID = 0;
            UserName = "";
            Password = "";
            IsActive = 0;

            FillPersonWithEmptyData();
        }

        public DBclsUser(int UserID)
        {
            int    PersonID = 0;
            string UserName = "";
            string Password = "";
            int    IsActive = 0;


            if (DAclsUser.GetUserByID(UserID, ref PersonID, ref UserName, ref Password, ref IsActive))
            {
                this.UserID = UserID;
                this.PersonID = PersonID;
                this.UserName = UserName;
                this.Password = Password;
                this.IsActive = IsActive;

                FillPersonByPersonID(PersonID);
            }
        }

        public DBclsUser(string userName, string password)
        {
            int UserID = 0;
            int PersonID = 0;
            int IsActive = 0;


            if (DAclsUser.GetUserByUserNameAndPassword(ref UserID, ref PersonID, userName, password, ref IsActive))
            {
                this.UserID = UserID;
                
                this.UserName = userName;
                this.Password = password;
                this.IsActive = IsActive;
                _EnMode = _enMode.Update;

                FillPersonByPersonID(PersonID);
            }
        }

        public static DataTable GitAllUsers()
        {
            return DAclsUser.GitAllUsers();
        }

        public static DataTable GitAllUsersWithFilter(string ColumnName, string Value)
        {
            return DAclsUser.GitAllUsersWithFilter(ColumnName, Value);
        }

        private bool _UpdatedUser()
        {
            return DAclsUser.UpdateUser(UserID, UserName, Password, IsActive);
        }

        public static bool IsUserExist(int UserID)
        {
            return DAclsUser.IsValueExist("Users", "UserID", UserID.ToString());
        }

        public bool _AddNewUser()
        {
            int TempID ;
            if ((TempID = DAclsUser.AddNewUser(PersonID, UserName, Password, IsActive)) > 0)
            {
                UserID = TempID;
                FillPersonByPersonID(PersonID);
                return true;
            }
            else
                return false;

        }


        public bool SaveUser()
        {
            switch (_EnMode)
            {
                case _enMode.AddNew:
                    {
                        return _AddNewUser();
                    }
                default:
                    return _UpdatedUser();
            }
        }

        public static bool DeleteUser(int UserID)
        {
            return DAclsUser.DeleteRecord("Users", "UserID", UserID.ToString());
        }

        public static string GetUserNameByUserID(int UserID)
        {
            return clsCRUD.GetValueFromTable("UserName", "Users", "UserID", UserID.ToString());
        }

        public static bool IsValueExist(string ColumnName, string Value, bool InUsers = true)
        {
            return DAclsPerson.IsValueExist("Users", ColumnName, Value);
        }
    }
}
