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
    /// Summary description for Portfolio
    /// </summary>
    public class Portfolio : AbstractBusiness
    {
        public Portfolio(int id)
        {
            //
            // TODO: Add constructor logic here
            //   
        }
        public override void PopulateDataMembersFromDataRow(DataRow table)
        {
            throw new NotImplementedException();          
        }
    }
}