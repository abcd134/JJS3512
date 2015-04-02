using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using content.Services;

public partial class Test : System.Web.UI.Page
{
    protected void Page_Load(object sender, EventArgs e)
    {
        APIMovieDA asd = new APIMovieDA();

        Repeater1.DataSource = asd.fetchData();
        Repeater1.DataBind();
        
    }
}