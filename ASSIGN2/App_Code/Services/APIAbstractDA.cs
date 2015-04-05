using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using Newtonsoft.Json;
using System.Net;
using System.Data;
using System.Reflection;

/// <summary>
/// This abstract file is used as a blueprint for all API Data Access files in the services folder
/// </summary>
namespace content.Services
{
    public abstract class APIAbstractDA
    {
        /// <summary>
        /// This method's a type of an object and must therefore must be editted
        /// </summary>
        /// <returns></returns>
        public abstract DataTable fetchData();

        /// <summary>
        /// Used to Download API Data from the URL string provided
        /// This method also Deserializes the object
        /// </summary>
        /// <typeparam name="T"></typeparam>
        /// <param name="url"></param>
        /// <returns></returns>
        protected T DownloadFromAPI<T>(string url) where T : new()
        {
            using (var w = new WebClient())
            {
                var json_data = string.Empty;
                // attempt to download JSON data as a string
                try
                {
                    json_data = w.DownloadString(url);
                }
                catch (Exception ex)
                {
                }
                // serialize the object
                T serializedObject = JsonConvert.DeserializeObject<T>(json_data);
                return serializedObject;
            }
        }
    }
}