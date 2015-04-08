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
    /// Summary description for MovieImages
    /// </summary>
    public class MovieImage : AbstractBusiness
    {
        private int _id;
        private int _movieID;
        private int _movieImageID;
        private string _filePath154;
        private string _filePath300;
        private string _filePath500;
        private string _filePath780;
        private string _filePath1920;
        private bool _isPoster;
        private MovieImageDA _movieImageDA;

        public MovieImage()
        {
            _movieImageDA = new MovieImageDA();
            base.DataAccess = _movieImageDA;
        }
        /// <summary>
        /// Method to obtain a row of validated data
        /// </summary>
        /// <param name="row"></param>
        public override void PopulateDataMembersFromDataRow(DataRow row)
        {
            // set the data members to the data retrieved from the database table/query
            MovieID = (int)row["movie_id"];

            if (row["is_poster"] == DBNull.Value || Convert.ToInt32(row["is_poster"]) == 0)
            {
                IsPoster = false;
            }
            else
            {
                IsPoster = true;
            }

            if (row["movie_image_id"] == DBNull.Value)
            {
                MovieImageID = -1;  // Error flag set that the movie ID was not found (should be impossible)
                Id = -1;
            }
            else
            {
                MovieImageID = (int)Convert.ToInt32(row["movie_image_id"]);
                Id = MovieImageID;
            }
                

            if (row["file_path"] == DBNull.Value)
            {
                FilePath500 = "../images/Not_available.jpg";
                FilePath154 = "../images/Not_available.jpg";
                FilePath300 = "../images/Not_available.jpg";
                FilePath780 = "../images/Not_available.jpg";
                FilePath1920 ="../images/Not_available.jpg";
            }
            else
            {
                FilePath1920 = "http://image.tmdb.org/t/p/w1920" + row["file_path"];
                FilePath500 = "http://image.tmdb.org/t/p/w500" + row["file_path"];
                if (_isPoster)
                {
                    FilePath154  = "http://image.tmdb.org/t/p/w154" + row["file_path"];         
                }
                else
                {
                    FilePath300 = "http://image.tmdb.org/t/p/w300" + row["file_path"];
                    FilePath780 = "http://image.tmdb.org/t/p/w780" + row["file_path"];
                }                
            }            
        }

        public int MovieID
        {
            get { return _movieID; }
            set { _movieID = value; }
        }

        public bool IsPoster
        {
            get { return _isPoster; }
            set { _isPoster = value; }
        }

        public int MovieImageID
        {
            get { return _movieImageID; }
            set { _movieImageID = value; }
        }

        public string FilePath300
        {
            get { return _filePath300; }
            set { _filePath300 = value; }
        }
        public string FilePath1920
        {
            get { return _filePath1920; }
            set { _filePath1920 = value; }
        }
        public string FilePath500
        {
            get { return _filePath500; }
            set { _filePath500 = value; }
        }
        public string FilePath780
        {
            get { return _filePath780; }
            set { _filePath780 = value; }
        }
        public string FilePath154
        {
            get { return _filePath154; }
            set { _filePath154 = value; }
        }
        public int Id
        {
            get { return _id; }
            set { _id = value; }
        }
   }
}