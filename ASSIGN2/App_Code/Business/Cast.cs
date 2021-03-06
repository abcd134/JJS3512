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
    /// Summary description for Cast
    /// </summary>
    public class Cast : AbstractBusiness
    {
        private int _actorID;
        private int _movieId;
        private string _title;
        private string _actorName;
        private string _roleName;
        private string _profilePath;
        private CastDA _castDA;

        public Cast()
        {
            _castDA = new CastDA();
            base.DataAccess = _castDA;
        }
        /// <summary>
        /// Method to obtain a row of validated data
        /// </summary>
        /// <param name="row"></param>
        public override void PopulateDataMembersFromDataRow(DataRow row)
        {
            // set the data members to the data retrieved from the database table/query
            ActorID = (int)row["person_id"];

            if (row["movie_id"] == DBNull.Value)
                MovieID = -1;  // Error flag set that the movie ID was not found (should be impossible)
            else
                MovieID = (int) Convert.ToInt32(row["movie_ID"]);

            if (row["title"] == DBNull.Value)
                Title = "";
            else
                Title = (string)row["title"];

            if (row["name"] == DBNull.Value)
                ActorName = "";
            else
                ActorName = (string)row["name"];

            if (row["role_name"] == DBNull.Value)
            {
                RoleName = "";
            }
            else { RoleName = (string)row["role_name"]; }

            if (row["profile_path"] == DBNull.Value)
            {
                ProfilePath = "../images/Not_available.jpg";
            }
            else
            {
                ProfilePath = "http://image.tmdb.org/t/p/w154" + row["profile_path"];
            }
        }

        public int ActorID
        {
            get { return _actorID; }
            set { _actorID = value; }
        }

        public string RoleName
        {
            get { return _roleName; }
            set { _roleName = value; }
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
        public string ProfilePath
        {
            get { return _profilePath; }
            set { _profilePath = value; }
        }
        public string ActorName
        {
            get { return _actorName; }
            set { _actorName = value; }
        }
    }
}