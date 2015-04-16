using System;
using System.Configuration;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Security;
using System.Web.UI;
using System.Web.UI.HtmlControls;
using System.Web.UI.WebControls;
using System.Web.UI.WebControls.WebParts;

/// <summary>
/// Summary description for ConfigurationInformation
/// Used to fetch URL and API key in Webconfig
/// </summary>
public static class ConfigurationInformation
{
	public static string MovieDBURL
    {
        get { return ConfigurationManager.AppSettings["MovieDB"]; }
    }

    public static string MovieDBAPI
    {
        get { return ConfigurationManager.AppSettings["MovieDBAPI"]; }
    }

}