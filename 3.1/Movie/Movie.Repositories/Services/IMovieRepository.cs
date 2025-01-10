using Movie.DataAccess.Entities;

namespace Movie.Repositories.Services;

public interface IMovieRepository
{
    Guid AddMovie(MovieEntity movie);

    List<MovieEntity> GetAllMovies();

    MovieEntity GetMovieById(Guid id);
    
    void DeleteMovie(Guid id);

    void UpdateMovie(MovieEntity updatedMovie);
}