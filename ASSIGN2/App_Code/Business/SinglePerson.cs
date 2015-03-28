using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Data;
using System.Data.Common;

using Content.DataAccess;

namespace Content.Business
{

    /// <summary>
    /// Summary description for SinglePerson
    /// Business Object for a person
    /// </summary>
    public class SinglePerson : AbstractBusiness
    {
        private int _id;
        private string _biography;
        private string _name;
        private DateTime _birthDay;
        private DateTime _deathDay;
        private string _birthPlace;
        private string _homePage;
        private string _profilePath;
        private string _profilePic;
        private Portfolio _folio;
        private PersonDA _personDA;

        public SinglePerson()
        {
            _personDA = new PersonDA();
            base.DataAccess = _personDA;
        }
        /// <summary>
        /// Method to obtain a row of validated data
        /// </summary>
        /// <param name="row"></param>
        public override void PopulateDataMembersFromDataRow(DataRow row)
        {
            // set the data members to the data retrieved from the database table/query
            ID = (int)row["id"];

            if (row["name"] == DBNull.Value)
                Name = "";
            else
                Name = (string)row["name"];

            if (row["biography"] == DBNull.Value)
                Biography = "";
            else
                Biography = (string)row["biography"];

            BirthDay = Convert.ToDateTime(row["YearOfBirth"]);
            DeathDay = Convert.ToDateTime(row["YearOfDeath"]);

            if (row["birthPlace"] == DBNull.Value)
                BirthPlace = "";
            else
                BirthPlace = (string)row["birthPlace"];

            if (row["profile_path"] == DBNull.Value)
            {
                ProfilePath = "../images/";
                ProfilePic = ProfilePath + "Not_available.jpg";
            }
            else 
            {
                ProfilePic = "http://image.tmdb.org/t/p/w300/" + ProfilePath;    
            }

            if (row["home_page"] == DBNull.Value) HomePage = "";
            else HomePage = (string)row["home_page"];

            Folio = new Portfolio(ID);
        }
        
        public int ID
        {
            get { return _id; }
            set { _id = value; }
        }
  
        public string Biography
        {
            get { return _biography; }
            set { _biography = value; }
        }

        public string Name
        {
            get { return _name; }
            set { _name = value; }
        }
        public DateTime BirthDay
        {
            get { return _birthDay; }
            set { _birthDay = value; }
        }
        public DateTime DeathDay
        {
            get { return _deathDay; }
            set { _deathDay = value; }
        }
        public string BirthPlace
        {
            get { return _birthPlace; }
            set { _birthPlace = value; }
        }
        public string HomePage
        {
            get { return _homePage; }
            set { _homePage = value; }
        }
        public string ProfilePath
        {
            get { return _profilePath; }
            set { _profilePath = value; }
        }
        public string ProfilePic
        {
            get { return _profilePic; }
            set { _profilePic = value; }
        }
        public Portfolio Folio
        {
            get { return _folio; }
            set { _folio = value; }
        }
    }	
}