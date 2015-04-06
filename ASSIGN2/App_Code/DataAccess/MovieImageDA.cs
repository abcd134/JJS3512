using Content.DataAccess;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Data;
using System.Data.Common;

/// <summary>
/// fetch the images
/// </summary>
/// 

namespace Content.DataAccess
{
    public class MovieImageDA : AbstractDA
    {
        private const string fields = " movie_image.movie_id, movie_image_id, is_poster, file_path"; 
        protected override string SelectStatement  
        {
            get
            {
                string sql = "SELECT " + fields + " FROM movie, movie_image " +
                    " WHERE movie.movie_id = movie_image.movie_id ";
                return sql;
            }
        }

        protected override string OrderFields
        {
            get
            {
                return "movie_image_id";
            }
        }

        protected override string KeyFieldName
        {
            get
            {
                return "movie_image_id";
            }
        }

        /// <summary>
        /// Grabs the images based on the movies id and IF it is a poster or a backdrop
        /// Poster = 1, Backdrop = 0
        /// </summary>
        public DataTable GetByMovieImage(int movieId, bool IsMoviePoster)
        {
            int moviePoster = 0;
            if (IsMoviePoster)
                moviePoster = 1;

            // set up parameterized query statement
            string sql = SelectStatement + " AND (movie.movie_id =@movie_id) AND (movie_image.is_poster = " + moviePoster + ")"; // need to clean this up
            // construct array of parameters
            DbParameter[] parameters = new DbParameter[] {
                DataHelper.MakeParameter("@movie_id", movieId, DbType.Int32)
            };
            // return result
            return DataHelper.GetDataTable(sql, parameters);
        }

        public DataTable GetByImageID(int imageID)
        {
            // set up parameterized query statement
            string sql = "Select " + fields +" FROM movie_image WHERE movie_image.movie_image_id=" + imageID; 
            // return result
            return DataHelper.GetDataTable(sql, null);
        }
    }
}