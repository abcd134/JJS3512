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
    private string _profilePath;
	public PeopleFavorites(int personId, string name, string profilePath)
	{
        PersonID = personId;
        Name = name;
        ProfilePath = profilePath;
	}
    public override void PopulateDataMembersFromDataRow(DataRow row)
    {
        PersonID = (int) row["personId"];
        Name = (string) row["name"];
        ProfilePath = (string) row["profilePath"];
    }
    /// <summary>
    /// Getter and Setter section for th instance variables
    /// </summary>
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
    public string ProfilePath
    {
        get { return _profilePath; }
        set { _profilePath = value; }
    }
}