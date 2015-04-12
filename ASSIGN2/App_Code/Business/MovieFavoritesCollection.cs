using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Data;
using System.Data.SqlTypes;
using System.Web;

using Content.DataAccess;

namespace Content.Business
{

    /// <summary>
    /// Represents a collection of Movie objects
    /// </summary>
    public class MovieFavoritesCollection : AbstractBusinessCollection<MovieFavorites>
    {
        private DataTable _dt;
        public MovieFavoritesCollection()
        {
            //
        }
        public DataTable dt
        {
            get { return _dt; }
            set { _dt = value; }
        }
    }
}