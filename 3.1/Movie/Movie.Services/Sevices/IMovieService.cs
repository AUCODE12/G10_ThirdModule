using Movie.Services.DTOs;

namespace Movie.Services.Sevices;

public interface IMovieService
{
    Guid AddMovie(MovieDto movieDto);

    List<MovieDto> GetAllMovies();

    MovieDto GetMovieById(Guid id);

    void DeleteMovie(Guid id);

    void UpdateMovie(MovieDto updatedMovieDto);

    List<MovieDto> GetAllMoviesByDirector(string director);

    MovieDto GetTopRatedMovie();

    List<MovieDto> GetMoviesReleasedAfterYear(int year);

    MovieDto GetHighestGrossingMovie();

    List<MovieDto> SearchMoviesByTitle(string keyword);

    List<MovieDto> GetMoviesWithinDurationRange(int minMinutes, int maxMinutes);

    long GetTotalBoxOfficeEarningsByDirector(string director);

    List<MovieDto> GetMoviesSortedByRating();

    List<MovieDto> GetRecentMovies(int years);
}