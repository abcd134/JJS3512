﻿using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Data;
using System.Data.SqlTypes;
using System.Web;
using System.Data.Common;

using Content.DataAccess;

namespace Content.Business
{

    /// <summary>
    /// Represents a collection of Movie objects.
    /// 
    /// This collection is a bit unique in that we need to use it within an
    /// Person (since each person has their own list of miovies) and use
    /// it byself, say for searches (in that case it contains all movies)
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