using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Data;
using System.Data.Common;
using Content.DataAccess;


/// <summary>
/// Summary description for Review
/// </summary>
namespace Content.Business
{
    public class Review : AbstractBusiness
    {
        private ReviewDA _reviewDa;
        public Review()
        {
            _reviewDa = new ReviewDA();
            base.DataAccess = _reviewDa;
        }



        /// <summary>
        /// Method to obtain a row of validated data
        /// </summary>
        /// <param name="row"></param>
        public override void PopulateDataMembersFromDataRow(DataRow row)
        {
            Movie_ID = (int)row["movie_id"];

            if (row["first_name"] == DBNull.Value)
                first_name = null;
            else
                first_name = (string)row["first_name"] + " ";

            if (row["last_name"] == DBNull.Value)
                last_name = null;
            else
                last_name = (string)row["last_name"];

            if (row["review_text"] == DBNull.Value)
                review_text = null;
            else
                review_text = (string)row["review_text"];

            if (row["review_date"] == DBNull.Value)
                date = "Date Not Available";
            else
                date = Convert.ToDateTime(row["review_date"]).ToString().Substring(0, 10);

            if (row["rating"] == DBNull.Value)
                rating = 0;
            else
                rating = (int)row["rating"];

            if (row["review_title"] == DBNull.Value)
                review_title = null;
            else
                review_title = (string)row["review_title"];
            
        }
        #region

        public string review_title
        {
            get;
            set;
        }
        public int Movie_ID
        {
            get;
            set;
        }

        public string first_name
        {
            get;
            set;
        }
        public string last_name
        {
            get;
            set;
        }

        public string review_text
        {
            get;
            set;
        }
        public string date
        {
            get;
            set;
        }

        public int rating
        {
            get;
            set;
        }
        #endregion 
    }
}
