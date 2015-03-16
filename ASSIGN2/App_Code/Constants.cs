using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

/// <summary>
/// Summary description for QueryConstants
/// </summary>
public static class Constants
{
    public static string retrieveBio(int personID) 
    {
        return "SELECT * FROM person WHERE person_id=" + personID;
    }

    public static string retrieveMovies(int personId)
    {
        return "SELECT movie.movie_id, movie.title, movie_cast.role_name FROM ((movie INNER JOIN movie_cast ON movie.movie_id = movie_cast.movie_id) INNER JOIN " +
            "person ON movie_cast.person_id = person.person_id) WHERE (person.person_id = " + personId + ") GROUP BY movie.movie_id, movie.title, movie_cast.role_name";
    }

    public static string retrieveCrew(int personId)
    {
        return "SELECT movie.movie_id, movie.title, movie_crew.department, movie_crew.job FROM ((movie INNER JOIN movie_crew ON movie.movie_id = movie_crew.movie_id AND movie.title = movie_crew.department) " +
            "INNER JOIN person ON movie_crew.person_id = person.person_id) WHERE (movie_crew.person_id = " + personId + ") GROUP BY movie.movie_id, movie.title, movie_crew.department, movie_crew.job";
    }
}