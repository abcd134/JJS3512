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
        private int _id;
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
        private MovieDA _movieDA;

        public SingleMovie()
        {
            _movieDA = new MovieDA();
            base.DataAccess = _movieDA;
        }

        //public override void PopulateDataMembersFromDataRow(DataRow row)
        //{
        //    try
        //    {
        //        MovieId = (int)row["id"];

        //        if (row["title"] == DBNull.Value)
        //            Title = "";
        //        else
        //            Title = (string)row["title"];

        //    }
        //    catch (Exception)
        //    {
        //        throw new NotImplementedException();
        //    }           
        //}

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

    }
}