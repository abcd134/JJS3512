using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using Newtonsoft.Json;

/// <summary>
/// Summary description for MovieTrailers
/// </summary>
public class MovieTrailers
{
    [JsonProperty("key")]
    public string Key
    {
        get;
        set;
    }
}