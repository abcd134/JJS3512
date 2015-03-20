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

    /// <summary>
    /// This method retrives the list of movies a person was involved in
    /// </summary>
    /// <param name="personId"></param>
    /// <returns>List of movies</returns>
    public static string retrieveMoviesByPersonID(int personId)
    {
        return "SELECT movie.movie_id, movie.title, movie_cast.role_name FROM ((movie INNER JOIN movie_cast ON movie.movie_id = movie_cast.movie_id) INNER JOIN " +
            "person ON movie_cast.person_id = person.person_id) WHERE (person.person_id = " + personId + ") GROUP BY movie.movie_id, movie.title, movie_cast.role_name";
    }

    public static string retrieveCrew(int personId)
    {
        return "SELECT movie.movie_id, movie.title, movie_crew.department, movie_crew.job FROM ((movie INNER JOIN movie_crew ON movie.movie_id = movie_crew.movie_id AND movie.title = movie_crew.department) " +
            "INNER JOIN person ON movie_crew.person_id = person.person_id) WHERE (movie_crew.person_id = " + personId + ") GROUP BY movie.movie_id, movie.title, movie_crew.department, movie_crew.job";
    }

    public static string retrieveMoviesByMovieID(int movieId)
    {
        return "SELECT movie_id, title, overview, poster_path FROM movie WHERE movie_id=" + movieId;
    }

    /// <summary>
    /// This query is used in the SMovie Page and retrieves the poster images for the movie
    /// </summary>
    /// <param name="movieID"></param>
    /// <returns></returns>
    public static string retrievePosterImages(int movieID)
    {
        return "SELECT movie_image.is_poster, movie_image.file_path FROM (movie INNER JOIN movie_image"+ 
        " ON movie.movie_id = movie_image.movie_id) WHERE (movie.movie_id = " + movieID + ") AND (movie_image.is_poster = 1)";
    }

    /// <summary>
    /// This query is used in the SMovie Page and retrieves the backdrop images for the movie
    /// </summary>
    /// <param name="movieID"></param>
    /// <returns></returns>
    public static string retrieveBackDropImages(int movieID)
    {

        return "SELECT movie_image.is_poster, movie_image.file_path, movie_image.movie_image_id FROM (movie INNER JOIN movie_image" +
            " ON movie.movie_id = movie_image.movie_id) WHERE (movie.movie_id = "+movieID+") AND (movie_image.is_poster = 0)";
    }


    //public static string retrieveBackDropModal(int movieID, int backDropID)
    //{

    //    return "SELECT movie_image.is_poster, movie_image.file_path, movie_image.movie_image_id FROM (movie INNER JOIN movie_image" +
    //        " ON movie.movie_id = movie_image.movie_id) WHERE (movie.movie_id = " + movieID + ") AND (movie_image.is_poster = 0)" +
    //        " and (movie_image.movie_image_id ="+backDropID+")";
    //}


    /// <summary>
    /// This query is used in the SMovie Page and retrieves the crew of the movie
    /// </summary>
    /// <param name="movieID"></param>
    /// <returns></returns>
    public static string retrieveMovieCrew(int movieID)
    {
        return "SELECT movie.movie_id, movie_crew.movie_crew_id, person.person_id, person.profile_path AS path, "+
        "movie_crew.department, person.name FROM person INNER JOIN (movie INNER JOIN movie_crew ON movie.movie_id = movie_crew.movie_id) ON person.person_id = movie_crew.person_id" +
        " WHERE (((movie.movie_id)=" + movieID + ")) order by movie_crew.department";

    }

    /// <summary>
    /// This query is used in the SMovie Page and retrieves the cast of the movie 
    /// </summary>
    /// <param name="movieID"></param>
    /// <returns></returns>
    public static string retrieveMovieCast(int movieID)
    {
        return "select person.name, person.person_id, movie_cast.ordering, movie_cast.role_name, person.profile_path AS pathcast"+
        " from person, movie_cast, movie"+
        " where movie.movie_id = movie_cast.movie_id and movie_cast.person_id = person.person_id"+
        " and movie.movie_id = "+movieID+" order by movie_cast.ordering";
    }

    /// <summary>
    /// This query is used in the SMovie page and retrieves the company of the movie
    /// </summary>
    /// <param name="movieID"></param>
    /// <returns></returns>
    public static string retrieveMovieCompany(int movieID)
    {
        return "SELECT company.company_name FROM ((movie_company INNER JOIN movie ON movie_company.movie_id = movie.movie_id)"+
        " INNER JOIN company ON movie_company.company_id = company.company_id) WHERE (movie.movie_id =" + movieID + ")";
    }

    /// <summary>
    /// This query is used in SMovie Page and retrieves the keywords of the movie
    /// </summary>
    /// <param name="movieID"></param>
    /// <returns></returns>
    public static string retrieveMovieKeyword(int movieID)
    {
        return "SELECT keyword.name FROM ((movie_keyword INNER JOIN movie ON movie_keyword.movie_id = movie.movie_id)"+
        " INNER JOIN keyword ON movie_keyword.keyword_id = keyword.keyword_id) WHERE (movie.movie_id ="+movieID+")";
    }

    /// <summary>
    /// This query is used in SMovie Page and retrieves the genres of the movie
    /// </summary>
    /// <param name="movieID"></param>
    /// <returns></returns>
    public static string retrieveMovieGenre(int movieID)
    {
        return "SELECT genre.name FROM ((genre INNER JOIN movie_genre ON genre.genre_id = movie_genre.genre_id)"+ 
        " INNER JOIN movie ON movie_genre.movie_id = movie.movie_id) WHERE (movie.movie_id = "+movieID+")";
    }

    /// <summary>
    /// this query retrieves the movie tagline when it is not null
    /// </summary>
    /// <param name="movieID"></param>
    /// <returns></returns>
    public static string retrieveMovieTagline(int movieID)
    {
        return "SELECT tagline from movie as a where a.movie_id = "+movieID+" and tagline is not null";
    }

    public static string retrieveThreeActors(int x, int y, int z)
    {
        return "SELECT * FROM person Where person_id=" + x  + " OR person_id=" + y + " OR person_id=" + z;
    }

    public static string retrieveFeaturedMovies()
    {
        return "SELECT TOP 3 movie_id, title FROM movie ORDER BY revenue DESC";
    }
}