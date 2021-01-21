using MovieLibrary.Models;
using System.Collections.Generic;

namespace MovieLibrary
{
    public interface IMovieAdapter
    {
        Movie AdaptSingleMovie(MovieDto movieDto);
        IEnumerable<Movie> AdaptMultipleMovies(IEnumerable<MovieDto> movieList);
        IEnumerable<Movie> AdaptMultipleMovies(IEnumerable<MovieDetailsDto> movieDetailsDtoList);
    }
}
