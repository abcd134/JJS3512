using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using Newtonsoft.Json;
using System.Data;
using System.Reflection;
using Content.Services;

/// <summary>
/// Used to store the store a collection of  movies and information of upcoming movies
/// </summary>

namespace Content.Services
{
    public class MoviesCollection
    {
        /// <summary>
        /// Creates a list of movies
        /// </summary>
        [JsonProperty("results")]
        public List<Movie> Movies
        {
            get;
            set;
        }
        /// <summary>
        /// Returns a data table of List<movies>>
        /// </summary>
        /// <returns></returns>
        public DataTable getDataTable()
        {
            return ToDataTable<Movie>(Movies);
        }

        //REFERENCE: http://stackoverflow.com/questions/18100783/how-to-convert-a-list-into-data-table
        /// <summary>
        /// method converts List to data table
        /// </summary>
        /// <typeparam name="T"></typeparam>
        /// <param name="items"></param>
        /// <returns></returns>
        private static DataTable ToDataTable<T>(List<T> items)
        {
            DataTable dataTable = new DataTable(typeof(T).Name);

            //Get all the properties
            PropertyInfo[] Props = typeof(T).GetProperties(BindingFlags.Public | BindingFlags.Instance);
            foreach (PropertyInfo prop in Props)
            {
                //Setting column names as Property names
                dataTable.Columns.Add(prop.Name);
            }
            foreach (T item in items)
            {
                var values = new object[Props.Length];
                for (int i = 0; i < Props.Length; i++)
                {
                    //inserting property values to datatable rows
                    values[i] = Props[i].GetValue(item, null);
                }
                dataTable.Rows.Add(values);
            }
            //put a breakpoint here and check datatable
            return dataTable;
        }

    }
}