using MovieLibrary.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace MovieLibrary
{
    public interface IMovieAdapter
    {
        Movie AdaptSingleMovie(MovieDto movieDto);
        IEnumerable<Movie> AdaptMultipleMovies(IEnumerable<MovieDto> movieList);
        IEnumerable<Movie> AdaptMultipleMovies(IEnumerable<MovieDetailsDto> movieDetailsDtoList);
    }
}
