using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Movie.Services.DTOs;
using Movie.Services.Sevices;

namespace Movie.Api.Controllers;

[Route("api/movie")]
[ApiController]
public class MovieController : ControllerBase
{
    private readonly IMovieService _movieService;

    public MovieController()
    {
        _movieService = new MovieService();
    }

    [HttpPost("addMovie")]
    public Guid AddMovie(MovieDto movieDto)
    {
        var id = _movieService.AddMovie(movieDto);
        return id;
    }

    [HttpGet("getAllMovies")]
    public List<MovieDto> GetAllMovies()
    {
        return _movieService.GetAllMovies();
    }

    [HttpDelete("deleteMovie")]
    public void DeleteMovie(Guid id)
    {
        _movieService.DeleteMovie(id);
    }

    [HttpPut("updateMovie")]
    public void UpdateMovie(MovieDto movieDto)
    {
        _movieService.UpdateMovie(movieDto);
    }

    [HttpGet("getMovieById")]
    public MovieDto GetMovieById(Guid id)
    {
        return _movieService.GetMovieById(id);
    }
}
