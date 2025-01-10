using Movie.Services.DTOs;

namespace Movie.Services.Extensions;

public static class MovieExtensions
{
    public static double DurationMinutesToHour(this MovieDto movieDto)
    {
        return movieDto.DurationMinutes / 60;
    }

    public static long TotalBoxOfficeEarningsAllMovies(this List<MovieDto> movies)
    {
        return movies.Sum(m => m.BoxOfficeEarnings);
    }
}
