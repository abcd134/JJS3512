using System;
using System.Collections.Generic;
using System.Security.Claims;
using System.Security.Principal;
using System.Web;
using System.Web.Security;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Data.SqlClient;
using Content.Business;

public partial class SiteMaster : MasterPage
{
    private const string AntiXsrfTokenKey = "__AntiXsrfToken";
    private const string AntiXsrfUserNameKey = "__AntiXsrfUserName";
    private string _antiXsrfTokenValue;

    protected void Page_Init(object sender, EventArgs e)
    {
        // The code below helps to protect against XSRF attacks
        var requestCookie = Request.Cookies[AntiXsrfTokenKey];
        Guid requestCookieGuidValue;
        if (requestCookie != null && Guid.TryParse(requestCookie.Value, out requestCookieGuidValue))
        {
            // Use the Anti-XSRF token from the cookie
            _antiXsrfTokenValue = requestCookie.Value;
            Page.ViewStateUserKey = _antiXsrfTokenValue;
        }
        else
        {
            // Generate a new Anti-XSRF token and save to the cookie
            _antiXsrfTokenValue = Guid.NewGuid().ToString("N");
            Page.ViewStateUserKey = _antiXsrfTokenValue;

            var responseCookie = new HttpCookie(AntiXsrfTokenKey)
            {
                HttpOnly = true,
                Value = _antiXsrfTokenValue
            };
            if (FormsAuthentication.RequireSSL && Request.IsSecureConnection)
            {
                responseCookie.Secure = true;
            }
            Response.Cookies.Set(responseCookie);
        }

        Page.PreLoad += master_Page_PreLoad;
    }

    protected void master_Page_PreLoad(object sender, EventArgs e)
    {
        if (!IsPostBack)
        {
            // Set Anti-XSRF token
            ViewState[AntiXsrfTokenKey] = Page.ViewStateUserKey;
            ViewState[AntiXsrfUserNameKey] = Context.User.Identity.Name ?? String.Empty;
        }
        else
        {
            // Validate the Anti-XSRF token
            if ((string)ViewState[AntiXsrfTokenKey] != _antiXsrfTokenValue
                || (string)ViewState[AntiXsrfUserNameKey] != (Context.User.Identity.Name ?? String.Empty))
            {
                throw new InvalidOperationException("Validation of Anti-XSRF token failed.");
            }
        }
    }

    protected void Page_Load(object sender, EventArgs e)
    {
        getGenres();
    }

    protected void getGenres()
    {
        Boolean top = true;
        Boolean bottom = false;
        GenreCollection genreTC = new GenreCollection();
        // get top ten genre names and bind
        genreTC.FetchTenGenreNames(top);
        Top10DB.DataSource = genreTC;
        Top10DB.DataBind();
        // Now get the bottom 10 genres and bind
        GenreCollection genreBC = new GenreCollection();
        genreBC.FetchTenGenreNames(bottom);
        Bot10DB.DataSource = genreBC;
        Bot10DB.DataBind();
    }
    protected void SearchList_SelectedItemChanged(object sender, EventArgs e)
    {
        string searchType = SearchList.SelectedItem.Value.ToString();
    }
    protected void Unnamed_LoggingOut(object sender, LoginCancelEventArgs e)
    {
        Context.GetOwinContext().Authentication.SignOut();
    }

    /// <summary>
    /// Method to pass search text box to the browse page
    /// </summary>
    /// <param name="sender">Object being sent</param>
    /// <param name="e">The event</param>
    protected void SearchButton_Click(object sender, EventArgs e)
    {
        string link = "";
        if (SearchBox.Text != null)
        {
            link = "~/Browse/Browse.aspx?search=" + SearchBox.Text
                  + "&SearchType=" + SearchList.SelectedItem.Value;

            // Creating query string on post back to maintain search/filter cohesion
            if (Request.QueryString["genre"] != null)
            {
                if (Request.QueryString["genreType"] != null)
                {
                    link += "&genre=" + Request.QueryString["genre"]
                          + "&genreType=" + Request.QueryString["genreType"];
                }
                else
                {
                    Response.Redirect("../Error.aspx?error=Invalid Query String on site Master");
                }
            }
            Response.Redirect(link);
        }
    }
    /// <summary>
    /// Method to Get and Set the SearchBox.Text
    /// Used to help maintain state
    /// </summary>
    public string SearchBx
    {
        get
        {
            return SearchBox.Text;
        }
        set
        {
            SearchBox.Text = value;
        }
    }

    public string SearchKind
    {
        get
        {
            return SearchList.SelectedItem.Value.ToString();
        }
        set 
        {
            SearchList.SelectedValue= value;
        }
    }
}