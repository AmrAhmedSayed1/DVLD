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
    public class DBclsUser
    {
        public int UserID { get; set; }

        public int PersonID { get; set; }

        public string UserName { get; set; }

        public string Password { get; set; }

        public int IsActive { get; set; }

        public DBclsPerson Person { get; set; }
        
        private enum _enMode { AddNew, Update }

        private _enMode _EnMode;

        public DBclsUser()
        {
            PersonID = 0;
            UserName = "";
            Password = "";
            IsActive = 0;
            _EnMode = _enMode.AddNew;
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
                Person = new DBclsPerson(PersonID);
                _EnMode = _enMode.Update;
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
                this.PersonID = PersonID;
                this.UserName = userName;
                this.Password = password;
                this.IsActive = IsActive;
                Person = new DBclsPerson(PersonID);
                _EnMode = _enMode.Update;
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
            return DAclsUser.IsUserExist(UserID);
        }

        public bool _AddNewUser()
        {
            int TempID ;
            if ((TempID = DAclsUser.AddNewUser(PersonID, UserName, Password, IsActive)) > 0)
            {
                UserID = TempID;
                _EnMode = _enMode.Update;
                return true;
            }
            else
                return false;

        }


        public bool Save()
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
            return DAclsUser.DeleteUser(UserID);
        }


        public static bool IsValueExist(string ColumnName, string Value)
        {
            return DAclsUser.IsValueExist(ColumnName, Value);
        }


    }
}
