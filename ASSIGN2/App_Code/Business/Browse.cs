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
    /// Summary description for SingleMovie
    /// </summary>
    public class Browse : AbstractBusiness
    {
        private int _movieId;
        private int _personID;
        private string _title;
        private string _releaseDate;
        private string _overview;
        private string _average;
        private string _posterPath;
        private string _backdropPath;
        private string _tagline;
        private string _name;
        private string _roleName;
        private BrowseDA _browseDA;

        public Browse()
        {
            _browseDA = new BrowseDA();
            base.DataAccess = _browseDA;
        }

        public override void PopulateDataMembersFromDataRow(DataRow row)
        {
            MovieId = (int)row["movie_id"];

            PersonID = (int)row["person_id"];

            if (row["title"] == DBNull.Value)
                Title = "";
            else
                Title = (string)row["title"];

            if (row["release_date"] == DBNull.Value)
                ReleaseDate = "";
            else
                ReleaseDate = (string)row["release_date"];

            if (row["overview"] == DBNull.Value)
                Overview = "";
            else
                Overview = (string)row["overview"];

            if (row["vote_average"] == DBNull.Value)
                Average = "N/A";
            else
                Average = Convert.ToDecimal(row["vote_average"]).ToString();

            if (row["poster_path"] == DBNull.Value)
            {
                PosterPath = "";
            }
            else
            {
                PosterPath = (string)row["poster_path"];
            }

            if (row["backdrop_path"] == DBNull.Value)
                BackDropPath = "";
            else
                BackDropPath = (string)row["backdrop_path"];

            if (row["tagline"] == DBNull.Value)
                Tagline = "";
            else
                Tagline = (string)row["tagline"];

            if (row["name"] == DBNull.Value)
                Name = "";
            else
                Name = (string)row["name"];

            if (row["role_name"] == DBNull.Value)
                RoleName = "";
            else
                RoleName = (string)row["role_name"];

        }

        public int MovieId
        {
            get { return _movieId; }
            set { _movieId = value; }
        }
        public int PersonID
        {
            get { return _personID; }
            set { _personID = value; }
        }
        public string Title
        {
            get { return _title; }
            set { _title = value; }
        }
        public string ReleaseDate
        {
            get { return _releaseDate; }
            set { _releaseDate = value; }
        }
 
        public string Average
        {
            get { return _average; }
            set { _average = value; }
        }
 
        public string PosterPath
        {
            get { return _posterPath; }
            set { _posterPath = value; }
        }
        public string BackDropPath
        {
            get { return _backdropPath; }
            set { _backdropPath = value; }
        }
        public string Tagline
        {
            get { return _tagline; }
            set { _tagline = value; }
        }
        public string Name
        {
            get { return _name; }
            set { _name = value; }
        }

        public string Overview
        {
            get { return _overview; }
            set { _overview = value; }
        }

        public string RoleName
        {
            get { return _roleName; }
            set { _roleName = value; }
        }
        public BrowseDA BrowseDA
        {
            get { return _browseDA; }
            set { _browseDA = value; }
        }
    }
}