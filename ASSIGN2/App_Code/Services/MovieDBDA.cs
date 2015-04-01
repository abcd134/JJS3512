using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using Newtonsoft.Json;
using System.Net;

/// <summary>
/// Summary description for MovieDBDA
/// </summary>
public class MovieDBDA
{
	public MovieDBDA()
	{
       
	}
    public string fetchinfo ()
    {
        return _download_serialized_json_data(MovieDBServices.FetchMovie(550));
    }
    private static T _download_serialized_json_data<T>(string url) where T : new()
    {
        using (var w = new WebClient())
        {
            var json_data = string.Empty;
            // attempt to download JSON data as a string
            try
            {
                json_data = w.DownloadString(url);
            }
            catch (Exception) { }
            // if string with JSON data is not empty, deserialize it to class and return its instance 
            return !string.IsNullOrEmpty(json_data) ? JsonConvert.DeserializeObject<T>(json_data) : new T();
        }
    }
    private static string _download_serialized_json_data(string url)
    {
        using (var w = new WebClient())
        {
            var json_data = string.Empty;
            // attempt to download JSON data as a string
            try
            {
                json_data = w.DownloadString(url);

            }
            catch (Exception) { }
            // if string with JSON data is not empty, deserialize it to class and return its instance 
           string asd =  JsonConvert.DeserializeObject(json_data).ToString();
           return asd;
        }
    }

    //private static string _download_serialized_json_data(string url)
    //{
    //    using (var w = new WebClient())
    //    {
    //        var json_data = string.Empty;
    //        // attempt to download JSON data as a string
    //        try
    //        {
    //            json_data = w.DownloadString(url);
    //        }
    //        catch (Exception) { }
    //        // if string with JSON data is not empty, deserialize it to class and return its instance 
    //        return !string.IsNullOrEmpty(json_data) ? JsonConvert.DeserializeObject<string>(json_data): new T;
    //    }
    //}
}