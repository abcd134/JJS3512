using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using Content.Business;
using System.Data;
using System.Data.Common;


/// <summary>
/// Summary description for PeopleFavorites
/// </summary>
public class PeopleFavorites : AbstractBusiness
{
    private int _personID;
    private string _name;
    private string _profilePic;
    
    //people favorties taking id, name and picture and creating an object
	public PeopleFavorites(int personId, string name, string profilePic)
	{
        PersonID = personId;
        Name = name;
        ProfilePic = profilePic;
	}
    public override void PopulateDataMembersFromDataRow(DataRow row)
    {
        PersonID = (int) row["personId"];
        Name = (string) row["name"];
        ProfilePic = (string) row["profilePic"];
    }
    /// <summary>
    /// Getter and Setter section for th instance variables
    /// </summary>
    #region
    public int PersonID 
    {
        get {return _personID;}
        set { _personID = value; } 
    }
    public string Name
    {
        get { return _name; }
        set { _name = value; }
    }
    public string ProfilePic
    {
        get { return _profilePic; }
        set { _profilePic = value; }
    }
    #endregion
}