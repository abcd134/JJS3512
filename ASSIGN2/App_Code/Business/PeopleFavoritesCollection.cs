using System;
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
    /// Represents a collection of Person objects.
    /// </summary>
    public class PeopleFavoritesCollection : AbstractBusinessCollection<PeopleFavorites>
    {
        private DataTable _dt;
        public PeopleFavoritesCollection()
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