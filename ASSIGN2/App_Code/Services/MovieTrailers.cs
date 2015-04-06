using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using Newtonsoft.Json;
using Content.Services;
/// <summary>
///  Data Transfer Object for MoviesTrailers
/// The movie.cs class is class used to store the data after parsing the Json Object
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