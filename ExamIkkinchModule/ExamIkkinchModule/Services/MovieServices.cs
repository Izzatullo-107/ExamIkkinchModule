using ExamIkkinchModule.Dtos;
using ExamIkkinchModule.Models;
using ExamIkkinchModule.Services.IServices;
using System.Linq;

namespace ExamIkkinchModule.Services;

public class MovieServices : IMovieServices
{
    #region
    private List<Movie> Movies;
    public MovieServices()
    {
        Movies = new List<Movie>();
    }
    private MovieDto MovieDtoo(Movie movie)
    {
        var movieDto = new MovieDto();
        movieDto.Id = movie.Id;
        movieDto.Title = movie.Title;
        movieDto.Director = movie.Director;
        movieDto.DurationMinutes = movie.DurationMinutes;
        movieDto.Rating = movie.Rating;
        movieDto.BoxOfficeEarnings = movie.BoxOfficeEarnings;
        movieDto.ReleaseDate = movie.ReleaseDate;

        return movieDto;
    }
    #endregion


    //{C}
    public Guid AddMovie(CreatedMovieDto createdMovieDto)
    {
        var movie = new Movie()
        {
            Id = Guid.NewGuid(),
            Title = createdMovieDto.Title,
            Director = createdMovieDto.Director,
            DurationMinutes = createdMovieDto.DurationMinutes,
            Rating = createdMovieDto.Rating,
            BoxOfficeEarnings = createdMovieDto.BoxOfficeEarnings,
            ReleaseDate = DateTime.UtcNow

        };
        Movies.Add(movie);
        return movie.Id;
    }

    //{R}
    public List<MovieDto> GetMovies()
    {
        var movies = new List<MovieDto>();
        foreach (var movie in Movies)
        {
            movies.Add(MovieDtoo(movie));
        }

        return movies;

    }
    public MovieDto? GetMovieById(Guid movieId)
    {
        foreach(var movie in Movies)
        {
            if(movie.Id == movieId)
            {
                return MovieDtoo(movie);
            }
        }
        return null;
    }

    //{U}
    public bool UpdateMovie(Guid updateId, UpdateMovieDto updateMovieDto)
    {
        foreach (var movie in Movies)
        {
            if (movie.Id == updateId)
            {
                movie.Title = updateMovieDto.Title;
                movie.Director = updateMovieDto.Director;
                movie.DurationMinutes = updateMovieDto.DurationMinutes;
                movie.Rating = updateMovieDto.Rating;
                movie.BoxOfficeEarnings = updateMovieDto.BoxOfficeEarnings;
                return true;
            }
        }
        return false;
    }

    //{D}
    public bool DeletMovie(Guid deletId)
    {
        foreach (var movie in Movies)
        {
            if (movie.Id == deletId)
            {
                Movies.Remove(movie);
                return true;
            }
        }
        return false;

    }

    //{1}
    public List<MovieDto> GetAllMovieByDirector(string director)
    {
        var movieDto = new List<MovieDto>();

        foreach(var movie in Movies)
        {
            if (movie.Director == director)
            {
                movieDto.Add(MovieDtoo(movie));
            }
        }
        return movieDto;


    }

    //{2}
    public MovieDto GetTopRatedMovie()
    {
       var movieDto = new MovieDto();
        var maxRated = Movies[0];
        foreach(var movie in Movies)
        {
            if(maxRated.Rating < movie.Rating)
            {
                maxRated= movie;
            }
        }
        return MovieDtoo(maxRated);
    }

    //{3}
    public List<MovieDto> GetMoviesReleasedAfterYear(int year)
    {
        var movieDto = new List<MovieDto>();

        foreach(var movie in Movies)
        {
            if(movie.ReleaseDate.Year > year)
            {
                movieDto.Add(MovieDtoo(movie));
            }
        }
        return movieDto;

    }

    //{4}
    public MovieDto GetHighestGrossingMovie()
    {
        var movieDto = new MovieDto();
        var maxSumms = Movies[0];
        foreach (var movie in Movies)
        {
            if (maxSumms.BoxOfficeEarnings < movie.BoxOfficeEarnings)
            {
                maxSumms = movie;
            }
        }
        return MovieDtoo(maxSumms);
    }

    //{5}
    public List<MovieDto> SearchMoviesByTitle(string keyword)
    {
        var movieDto = new List<MovieDto>();
        
        foreach (var movie in Movies)
        {
            if (movie.Title.IndexOf(keyword)!= -1)
            {
                movieDto.Add(MovieDtoo(movie));
            }
        }
        return movieDto;
    }

    //{6}
    public List<MovieDto> GetMoviesWithinDurationRange(int minMinutes, int maxMinutes)
    {
        var movieDto = new List<MovieDto>();

        foreach(var movie in Movies)
        {
            if(minMinutes < movie.DurationMinutes && movie.DurationMinutes < maxMinutes)
            {
                movieDto.Add(MovieDtoo(movie));
            }
        }
        return movieDto;
    }

    //{7}
    public long GetTotalBoxOfficeEarningsByDirector(string director)
    {
        var movieSumm = 0l;

        foreach (var movie in Movies)
        {
            if (movie.Title.IndexOf(director) != -1)
            {
                movieSumm += movie.BoxOfficeEarnings;
            }
        }
        return movieSumm;
    }

    //{8} to'liqmas
    public List<MovieDto> GetMoviesSortedByRating()
    {
        var movieDto = new List<MovieDto>();
        Movies.Sort();
        foreach (var movie in Movies)
        {
            movieDto.Add(MovieDtoo(movie));
        }

        return movieDto;

    }

    //{9}
    public List<MovieDto> GetRecentMovies(int years)
    {
        var movieDto = new List<MovieDto>();

        foreach (var movie in Movies)
        {
            if (movie.ReleaseDate.Year < years)
            {
                movieDto.Add(MovieDtoo(movie));
            }
        }
        return movieDto;
    }

    

   
    

    
}
