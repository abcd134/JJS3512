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
    public class SingleMovie : AbstractBusiness
    {
        private int _movieId;
        private string _title;
        private string _releaseDate;
        private string _runTime;
        private string _overview;
        private string _imdbId;
        private string _imdbLink;
        private string _budget;
        private string _revenue;
        private string _average;
        private string _voteCount;
        private string _imgPoster500;
        private string _imgPoster780;
        private string _posterPath;
        private string _backdropPath;
        private string _tagline;
        private string _name;
        private string _roleName;
        private MovieDA _movieDA;

        public SingleMovie()
        {
            _movieDA = new MovieDA();
            base.DataAccess = _movieDA;
        }

        public override void PopulateDataMembersFromDataRow(DataRow row)
        {
            MovieId = (int)row["id"];

            if (row["title"] == DBNull.Value)
                Title = "";
            else
                Title = (string)row["title"];

            if (row["release_date"] == DBNull.Value)
                ReleaseDate = "";
            else
                ReleaseDate = (string)row["release_date"];

            if (row["runtime"] == DBNull.Value)
                RunTime = "";
            else
                RunTime = (string)row["runtime"];

            if (row["overview"] == DBNull.Value)
                Overview = "";
            else
                Overview = (string)row["overview"];

            if (row["imbd_id"] == DBNull.Value)
                ImdbId = "";
            else
                ImdbId = (string)row["imdb_id"];

            if (row["imdb_link"] == DBNull.Value)
                ImdbLink = "";
            else
                ImdbLink = (string)row["imdb_link"];

            if (row["budget"] == DBNull.Value)
                Budget = "";
            else
                Budget = (string)row["budget"];

            if (row["revenue"] == DBNull.Value)
                Revenue = "";
            else
                Revenue = (string)row["revenue"];

            if (row["vote_average"] == DBNull.Value)
                Average = "";
            else
                Average = (string)row["vote_average"];

            if (row["vote_count"] == DBNull.Value)
                VoteCount = "";
            else
                VoteCount = (string)row["vote_count"];

            if (row["poster_path"] == DBNull.Value)
            {
                ImgPoster500 = "";
                ImgPoster780 = "";
                PosterPath = "";
            }
            else
            {
                ImgPoster500 = "http://image.tmdb.org/t/p/w500" + (string)row["poster_path"];
                ImgPoster780 = "http://image.tmdb.org/t/p/w780" + (string)row["poster_path"];
                PosterPath = (string) row["poster_path"];
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
                RoleName = (string)row["roel_name"];

        }

        public int MovieId
        {
            get { return _movieId; }
            set { _movieId = value; }
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
        public string RunTime
        {
            get { return _runTime; }
            set { _runTime = value; }
        }
        public string Overview
        {
            get { return _overview; }
            set { _overview = value; }
        }
        public string ImdbId
        {
            get { return _imdbId; }
            set { _imdbId = value; }
        }
        public string ImdbLink
        {
            get { return _imdbLink; }
            set { _imdbLink = value; }
        }
        public string Budget
        {
            get { return _budget; }
            set { _budget = value; }
        }
        public string Revenue
        {
            get { return _revenue; }
            set { _revenue = value; }
        }
        public string Average
        {
            get { return _average; }
            set { _average = value; }
        }
        public string VoteCount
        {
            get { return _voteCount; }
            set { _voteCount = value; }
        }
        public string ImgPoster500
        {
            get { return _imgPoster500; }
            set { _imgPoster500 = value; }
        }
        public string ImgPoster780
        {
            get { return _imgPoster780; }
            set { _imgPoster780 = value; }
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
        public string RoleName
        {
            get { return _roleName; }
            set { _roleName = value; }
        }
        public MovieDA MovieDA
        {
            get { return _movieDA; }
            set { _movieDA = value; }
        }
    }
}