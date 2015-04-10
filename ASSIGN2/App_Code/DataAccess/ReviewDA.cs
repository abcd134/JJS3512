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
			   DataHelper.MakeParameter("@id", movie_id, DbType.Int16)
        };
            return DataHelper.GetDataTable(sql, parameters);
        }
    }
}
