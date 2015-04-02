﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Data;
using System.Data.Common;

using Content.DataAccess;

namespace Content.Business
{

/// <summary>
/// Summary description for Crew
/// </summary>
public class Crew : AbstractBusiness
    {
        private int _id;
        private int _movieId;
        private string _title;
        private string _department;
        private string _job;
        private CrewDA _crewDA;

        public Crew()
        {
            _crewDA = new CrewDA();
            base.DataAccess = _crewDA;
        }
        /// <summary>
        /// Method to obtain a row of validated data
        /// </summary>
        /// <param name="row"></param>
        public override void PopulateDataMembersFromDataRow(DataRow row)
        {
            // set the data members to the data retrieved from the database table/query
            ID = (int)row["person_id"];

            if (row["movie_id"] == DBNull.Value)
                MovieID = -1;  // Error flag set that the movie ID was not found (should be impossible)
            else
                MovieID = (int) Convert.ToInt32(row["movie_ID"]);

            if (row["title"] == DBNull.Value)
                Title = "";
            else
                Title = (string)row["title"];

            if (row["department"] == DBNull.Value)
            {
                Department = "";
            }
            else { Department = (string)row["department"]; }

            if (row["job"] == DBNull.Value)
            {
                Job = "";
            }
            else { Job = (string)row["job"]; }
        }

        public int ID
        {
            get { return _id; }
            set { _id = value; }
        }

        public string Department
        {
            get { return _department; }
            set { _department = value; }
        }

        public string Job
        {
            get { return _job; }
            set { _job = value; }
        }

        public string Title
        {
            get { return _title; }
            set { _title = value; }
        }
        public int MovieID
        {
            get { return _movieId; }
            set { _movieId = value; }
        }
    }
}