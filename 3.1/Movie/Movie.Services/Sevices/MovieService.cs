using Movie.DataAccess.Entities;
using Movie.Repositories.Services;
using Movie.Services.DTOs;

namespace Movie.Services.Sevices;

public class MovieService : IMovieService
{
    private readonly IMovieRepository _movieRepository;

    public MovieService()
    {
        _movieRepository = new MovieRepository();
    }

    public Guid AddMovie(MovieDto movieDto)
    {
        var movieId = _movieRepository.AddMovie(ConvertToMovieEntity(movieDto));
        return movieId;
    }

    public List<MovieDto> GetAllMovies()
    {
        var movieDtoList = _movieRepository.GetAllMovies()
            .Select(m => ConvertToMovieDto(m))
            .ToList();
        return movieDtoList;
    }

    public MovieDto GetMovieById(Guid id)
    {
        var movieDto = ConvertToMovieDto(_movieRepository.GetMovieById(id));
        return movieDto;
    }

    public void DeleteMovie(Guid id)
    {
        _movieRepository.DeleteMovie(id);
    }

    public void UpdateMovie(MovieDto updatedMovieDto)
    {
        _movieRepository.UpdateMovie(ConvertToMovieEntity(updatedMovieDto));
    }

    public List<MovieDto> GetAllMoviesByDirector(string director)
    {
        return _movieRepository.GetAllMovies()
            .Where(m => m.Director == director)
            .Select(mDto => ConvertToMovieDto(mDto))
            .ToList();
    }

    public MovieDto GetTopRatedMovie()
    {
        var maxRating = _movieRepository.GetAllMovies()
            .Max(m => m.Rating);
        var movieTopRating = _movieRepository.GetAllMovies()
            .First(m => m.Rating == maxRating);
        return ConvertToMovieDto(movieTopRating);
    }

    public List<MovieDto> GetMoviesReleasedAfterYear(int year)
    {
        return _movieRepository.GetAllMovies()
            .Where(m => m.ReleaseDate.Year >= year)
            .Select(mDto => ConvertToMovieDto(mDto))
            .ToList(); 
    }

    public MovieDto GetHighestGrossingMovie()
    {
        var highestGrossing = _movieRepository.GetAllMovies()
            .Max(m => m.BoxOfficeEarnings);
        var highestGrossingMovie = _movieRepository.GetAllMovies()
            .First(m => m.BoxOfficeEarnings == highestGrossing);
        return ConvertToMovieDto(highestGrossingMovie);
    }

    public List<MovieDto> SearchMoviesByTitle(string keyword)
    {
        return _movieRepository.GetAllMovies()
            .Where(m => m.Title.Contains(keyword))
            .Select(mDto => ConvertToMovieDto(mDto))
            .ToList();
    }

    public List<MovieDto> GetMoviesWithinDurationRange(int minMinutes, int maxMinutes)
    {
        return _movieRepository.GetAllMovies()
            .Where(m => m.DurationMinutes >= minMinutes && m.DurationMinutes <= maxMinutes)
            .Select(mDto => ConvertToMovieDto(mDto))
            .ToList();
    }

    public long GetTotalBoxOfficeEarningsByDirector(string director)
    {
        return _movieRepository.GetAllMovies()
            .Where(m => m.Director == director)
            .Sum(m => m.BoxOfficeEarnings);
    }

    public List<MovieDto> GetMoviesSortedByRating()
    {
        return _movieRepository.GetAllMovies()
            .OrderByDescending(m => m.Rating)
            .Select(m => ConvertToMovieDto(m))
            .ToList();
    }

    public List<MovieDto> GetRecentMovies(int years)
    {
        return _movieRepository.GetAllMovies()
            .Where(m => m.ReleaseDate.Year == years)
            .Select (m => ConvertToMovieDto(m))
            .ToList();
    }

    private MovieEntity ConvertToMovieEntity(MovieDto movieDto)
    {
        return new MovieEntity()
        {
            BoxOfficeEarnings = movieDto.BoxOfficeEarnings,
            Director = movieDto.Director,
            DurationMinutes = movieDto.DurationMinutes,
            Id = movieDto.Id ?? Guid.NewGuid(),
            Rating = movieDto.Rating,
            ReleaseDate = movieDto.ReleaseDate,
            Title = movieDto.Title,
        };
    }

    private MovieDto ConvertToMovieDto(MovieEntity movieEntity)
    {
        return new MovieDto()
        {
            Title = movieEntity.Title,
            ReleaseDate = movieEntity.ReleaseDate,
            Rating = movieEntity.Rating,
            Id = movieEntity.Id,
            BoxOfficeEarnings = movieEntity.BoxOfficeEarnings,
            Director = movieEntity.Director,
            DurationMinutes = movieEntity.DurationMinutes,
        };
    }
}
