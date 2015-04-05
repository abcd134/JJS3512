using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using Newtonsoft.Json;
using Content.Services;
/// <summary>
/// Summary description for MovieTrailers
/// </summary>

namespace Content.Services
{
    public class MovieTrailers
    {
        [JsonProperty("key")]
        public string Key
        {
            get;
            set;
        }
    }
}