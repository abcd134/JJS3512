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
        private const string fields = " review.review_id, review.first_name, review.last_name, review.review_text, review.rating, review.review_date, movie_review.movie_id";
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
        
        public DataTable fetchReviewByMovieID(int movie_id)
        {
            string sql = SelectStatement + " AND movie_id=@id ORDER BY " + OrderFields;
            DbParameter[] parameters = new DbParameter[] {
			   DataHelper.MakeParameter("@id", movie_id, DbType.Int32)
        };
            return DataHelper.GetDataTable(sql, parameters);
        }

        public void InsertReview (int movie_id, string first_name, string last_name, string review_text, DateTime date, int rating)
        {
            DbParameter[] parameters = new DbParameter[] 
            {
                DataHelper.MakeParameter("@fname" , first_name),
                DataHelper.MakeParameter("@lname" , last_name),
                DataHelper.MakeParameter("@review" , review_text),
                DataHelper.MakeParameter("@rate" , rating, DbType.Int16),
                DataHelper.MakeParameter("@date" , date, DbType.Date)

            };

            string sql = "INSERT INTO review (first_name, last_name, review_text, rating, review_date) VALUES (@fname, @lname, @review, @rate, @date)";
            int reviewID = DataHelper.RunNonQuery(sql, parameters, CommandType.Text, true); 

            DbParameter[] MovieReviewParam = new DbParameter[] 
            {
                DataHelper.MakeParameter("@mid" , movie_id),
                DataHelper.MakeParameter("@rid" , reviewID)
  
            };

            string MovieReviewSql = "INSERT INTO movie_review (movie_id, review_id) VALUES (@mid, @rid)";
            DataHelper.RunNonQuery(MovieReviewSql, MovieReviewParam, CommandType.Text, true);
                
    
        }
    }
}


