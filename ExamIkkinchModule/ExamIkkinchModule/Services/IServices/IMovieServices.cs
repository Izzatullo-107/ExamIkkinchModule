using ExamIkkinchModule.Dtos;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ExamIkkinchModule.Services.IServices;

public interface IMovieServices
{
    //{C}
    public Guid AddMovie(CreatedMovieDto createdMovieDto);
    
    //{R}
    public MovieDto? GetMovieById(Guid movieId);
    public List<MovieDto> GetMovies();
    
    //{U}
    public bool UpdateMovie(Guid updateId,UpdateMovieDto updateMovieDto);
    
    //{D}
    public bool DeletMovie(Guid deletId);

    //{1}
    public List<MovieDto> GetAllMovieByDirector(string director);

    //{2}
    public MovieDto GetTopRatedMovie();

    //{3}
    public List<MovieDto> GetMoviesReleasedAfterYear(int year);

    //{4}
    public MovieDto GetHighestGrossingMovie();

    //{5}
    public List<MovieDto> SearchMoviesByTitle (string keyword);

    //{6}
    public List<MovieDto> GetMoviesWithinDurationRange(int minMinutes,int maxMinutes);

    //{7}
    public long GetTotalBoxOfficeEarningsByDirector(string director);

    //{8}
    public List<MovieDto> GetMoviesSortedByRating();

    //{9}
    public List<MovieDto> GetRecentMovies(int years);

   


}
