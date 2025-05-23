﻿using System;
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

        public string Gender { get; set; }

        public enum _enMode { AddNew, Update}

        public _enMode _EnMode;

        public DBclsPerson()
        {
            FillPersonWithEmptyData();
        }

        
        public DBclsPerson(int personID)
        {
            FillPersonByPersonID(personID);
        }

        public void FillPersonByPersonID(int PersonID)
        {
            string nationalNo = "";
            string firstName = "";
            string secondName = "";
            string thirdName = "";
            string lastName = "";
            string email = "";
            string phone = "";
            string address = "";
            int CountryID = 0;
            string imagePath = "";
            DateTime dateOfBirth = DateTime.Now;
            string gender = "";

            if (DAclsPerson.GetPersonByID(PersonID, ref nationalNo, ref firstName,
                ref secondName, ref thirdName, ref lastName, ref email, ref phone,
                ref address, ref CountryID, ref imagePath, ref dateOfBirth, ref gender))
            {
                this.PersonID = PersonID;
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
        }

        public void FillPersonWithEmptyData()
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

        public static DataTable GitAllPoeple()
        {
            return DAclsPerson.GetAllPoeple();
        }

        public static DataTable GitAllPoepleWithFilter(string ColumnName, string Value)
        {
            return DAclsPerson.GetAllPoepleWithFilter(ColumnName, Value);
        }

        private bool _UpdatedPerson()
        {
            return DAclsPerson.UpdatePerson(PersonID, NationalNo, FirstName, SecondName, ThirdName, LastName, Email, Phone, Address, Country.CountryID, ImagePath, DateOfBirth, Gender);
        }

        public static bool IsValueExist(string ColumnName, string Value)
        {
            return DAclsPerson.IsValueExist("Poeple", ColumnName, Value);
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
            switch (_EnMode)
            {
                case _enMode.AddNew:
                    {
                        return _AddNewPerson();
                    }
                default:
                    return _UpdatedPerson();
            }
        }

        public static bool DeletePerson(int PersonID)
        {
            return DAclsPerson.DeleteRecord("Poeple", "PersonID", PersonID.ToString());
        }

        public string FullName()
        {
            return FirstName + " " + SecondName + " " + ThirdName + " " + LastName;
        }

    }
}
