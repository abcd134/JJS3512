using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Data;
using System.Data.Common;

/// <summary>
/// Summary description for ReviewDA
/// </summary>

namespace Content.DataAccess
{
    public class ReviewDA : AbstractDA
    {
        private const string fields = " review.review_id, review.first_name, review.last_name, review.review_text, review.rating, review.review_date, movie_review.movie_id, review.review_title";
        protected override string SelectStatement
        {
            get
            {
                return "SELECT " + KeyFieldName + "," + fields
                    + " FROM review, movie_review WHERE review.review_id = movie_review.review_id";
            }
        }

        protected override string OrderFields
        {
            get
            {
                return " review.review_date ";
            }
        }

        protected override string KeyFieldName
        {
            get
            {
                return "review.review_id";
            }
        }
        /// <summary>
        /// returns the reviews based on the movie id
        /// </summary>
        /// <param name="movie_id"></param>
        /// <returns></returns>
        public DataTable fetchReviewByMovieID(int movie_id)
        {
            string sql = SelectStatement + " AND movie_id=@id ORDER BY " + OrderFields;
            DbParameter[] parameters = new DbParameter[] {
			   DataHelper.MakeParameter("@id", movie_id, DbType.Int32)
        };
            return DataHelper.GetDataTable(sql, parameters);
        }
        /// <summary>
        /// used to insert data to the database
        /// </summary>
        /// <param name="movie_id"></param>
        /// <param name="first_name"></param>
        /// <param name="last_name"></param>
        /// <param name="review_text"></param>
        /// <param name="date"></param>
        /// <param name="rating"></param>
        /// <param name="review_title"></param>
        public void InsertReview (int movie_id, string first_name, string last_name, string review_text, DateTime date, int rating, string review_title)
        {
            DbParameter[] parameters = new DbParameter[] 
            {
                DataHelper.MakeParameter("@fname" , first_name),
                DataHelper.MakeParameter("@lname" , last_name),
                DataHelper.MakeParameter("@review" , review_text),
                DataHelper.MakeParameter("@rate" , rating, DbType.Int16),
                DataHelper.MakeParameter("@date" , date, DbType.Date),
                DataHelper.MakeParameter("@review_title" , review_title)

            };
            //inserts to the review class
            string sql = "INSERT INTO review (first_name, last_name, review_text, rating, review_date, review_title) VALUES (@fname, @lname, @review, @rate, @date, @review_title)";
            int reviewID = DataHelper.RunNonQuery(sql, parameters, CommandType.Text, true); 

            DbParameter[] MovieReviewParam = new DbParameter[] 
            {
                DataHelper.MakeParameter("@mid" , movie_id),
                DataHelper.MakeParameter("@rid" , reviewID)
  
            };
            //inserts to the movie_review class
            string MovieReviewSql = "INSERT INTO movie_review (movie_id, review_id) VALUES (@mid, @rid)";
            DataHelper.RunNonQuery(MovieReviewSql, MovieReviewParam, CommandType.Text, true);
                
    
        }
    }
}


