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
    public class DBclsPerson
    {

        public int PersonID { get; set; }

        public string NationalNo { get; set; }

        public string FirstName { get; set; }

        public string SecondName { get; set; }

        public string ThirdName { get; set; }
        
        public string LastName { get; set; }

        public string Email {  get; set; }

        public string Phone { get; set; }

        public string Address { get; set; }


        public DBclsCountry Country { get; set; }

        public string ImagePath { get; set; }

        public DateTime DateOfBirth { get; set; }

        public byte Age { get; set; }

        public string Gender { get; set; }

        private enum _enMode { AddNew, Update}

        _enMode _EnMode;

        public DBclsPerson()
        {
            PersonID = 0;
            NationalNo = "";
            FirstName = "";
            SecondName = "";
            ThirdName = "";
            LastName = "";
            Email = "";
            Phone = "";
            Address = "";
            Country = new DBclsCountry();
            ImagePath = "";
            DateOfBirth = DateTime.Now;
            Gender = "";
            _EnMode = _enMode.AddNew;
        }

        public DBclsPerson(int personID, string nationalNo, string firstName, string secondName, string thirdName, string lastName, string email, string phone, string address, int CountryID, string imagePath, DateTime dateOfBirth, string gender)
        {
            int PersonID = personID;
            NationalNo = nationalNo;
            FirstName = firstName;
            SecondName = secondName;
            ThirdName = thirdName;
            LastName = lastName;
            Email = email;
            Phone = phone;
            Address = address;
            Country = new DBclsCountry(CountryID);
            ImagePath = imagePath;
            DateOfBirth = dateOfBirth;
            Gender = gender;
            _EnMode = _enMode.Update;
        }

        public static DataTable GitAllPoeple()
        {
            return DAclsPerson.GitAllPoeple();
        }

        public static DataTable GitAllPoepleWithFilter(string ColumnName, string Value)
        {
            return DAclsPerson.GitAllPoepleWithFilter(ColumnName, Value);
        }

        public static bool IsValueExist(string ColumnName, string Value)
        {
            return DAclsPerson.IsValueExist(ColumnName, Value);
        }

        public bool _AddNewPerson()
        {
            int TempID = DAclsPerson.AddNewPerson(NationalNo, FirstName, SecondName, ThirdName,
                LastName, Email, Phone, Address, Country.CountryID, ImagePath,
                DateOfBirth, Gender);
            if (TempID > 0)
            {
                PersonID = TempID;
                _EnMode = _enMode.Update;
                return true;
            }
            else
                return false;

        }


        public bool Save()
        {
            return _AddNewPerson();
        }


    }
}
