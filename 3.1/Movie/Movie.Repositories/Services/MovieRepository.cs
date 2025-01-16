using Movie.DataAccess.Entities;
using System.Text.Json;

namespace Movie.Repositories.Services;

public class MovieRepository : IMovieRepository
{
    private readonly string _path;
    private readonly string _pathExtensionFiles; // qo'shimcha
    private readonly List<MovieEntity> _movies;

    public MovieRepository()
    {
        //_pathExtension = Path.Combine(Directory.GetDirectories("D:\\"));
        //_pathExtensionFiles = Path.Combine(Directory.GetCurrentDirectory(), "files.txt");
        _path = Path.Combine(Directory.GetCurrentDirectory(), "Movies.json");
        if (!File.Exists(_path))
        {
            File.WriteAllText(_path, "[]");
        }
        //if (!File.Exists(_pathExtensionFiles))
        //{
        //    var directory = @"D:\";
        //    File.WriteAllText(directory,  Path.Combine(Directory.GetFiles(directory)).ToString());
        //}
        
        _movies = GetAllMovies();
    }

    public Guid AddMovie(MovieEntity movie)
    {
        _movies.Add(movie);
        SaveData();
        return movie.Id;
    }

    public void DeleteMovie(Guid id)
    {
        var movie = GetMovieById(id);
        _movies.Remove(movie);
        SaveData();
    }

    public List<MovieEntity> GetAllMovies()
    {
        var movieJson = File.ReadAllText(_path);
        var movieList = JsonSerializer.Deserialize<List<MovieEntity>>(movieJson);
        return movieList;
    }

    public MovieEntity GetMovieById(Guid id)
    {
        var movie = _movies.FirstOrDefault(x => x.Id == id);
        if (movie == null)
        {
            throw new Exception($"{id}: Bunday id mavjud emas");
        }
        return movie;
    }

    public void UpdateMovie(MovieEntity updatedMovie)
    {
        var movie = GetMovieById(updatedMovie.Id);
        var index = _movies.IndexOf(movie);
        _movies[index] = updatedMovie;
        SaveData();
    }

    private void SaveData()
    {
        var movieJson = JsonSerializer.Serialize(_movies);
        File.WriteAllText(_path, movieJson);
    }
}
