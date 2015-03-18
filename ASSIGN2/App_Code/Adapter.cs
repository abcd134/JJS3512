using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Data;
using System.Data.OleDb;
using System.Web.Configuration;
using System.Data.Common;

/// <summary>
/// This class is used to generate data tables
/// </summary>
public class Adapter
{
    /// <summary>
    /// This constructor takes in the connection string to be used for data table creations
    /// </summary>
    /// <param name="connectionString"></param> - Parameter is used to take in the connection string
	public Adapter(string connectionString)
	{
        ConnectionString = connectionString;
	}

    /// <summary>
    /// createDataTable is used to create a Data Table using SQL Query and the Connection String.
    /// It initializes the Data Adapter and Fills a Data Table and returns\ a DataTable object
    /// </summary>
    /// <param name="sqlQuery"></param> -- SQL Query Used
    /// <returns>Object Returns a DataTable object that has been filled by the data adapter</returns>
    public DataTable createDataTable (string sqlQuery)
    {
        OleDbDataAdapter adapter = new OleDbDataAdapter(sqlQuery, ConnectionString);
        DataTable outputTable = new DataTable();
        adapter.Fill(outputTable);
        return outputTable;
    }

    /// <summary>
    /// createDataTable is used to create a Data Table using SQL Query and using a user specified Connection String.
    /// It initializes the Data Adapter and Fills a Data Table and returns a DataTable object
    /// </summary>
    /// <param name="sqlQuery"></param>  -- SQL Query Used
    /// <param name="connectionString"></param>  -- Users custom connection string
    /// <returns></returns>
    public DataTable createDataTable(string sqlQuery, string connectionString)
    {
        OleDbDataAdapter adapter = new OleDbDataAdapter(sqlQuery, connectionString);
        DataTable outputTable = new DataTable();
        adapter.Fill(outputTable);
        return outputTable;
    }

    /// <summary>
    /// Getter and Seter for Connection String used in this class
    /// </summary>
    public string ConnectionString { get; private set; }
}