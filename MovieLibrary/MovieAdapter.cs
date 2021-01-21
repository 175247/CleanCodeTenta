using MovieLibrary.Models;
using System.Collections.Generic;

namespace MovieLibrary
{
    public class MovieAdapter : IMovieAdapter
    {
        public Movie AdaptSingleMovie(MovieDto movieDto)
        {
            Movie movie = new Movie
            {
                Title = movieDto.title,
                Id = movieDto.id,
                Rated = double.Parse(movieDto.rated)
            };

            return movie;
        }

        public Movie AdaptSingleMovie(MovieDetailsDto movieDetailsDto)
        {
            Movie movie = new Movie
            {
                Title = movieDetailsDto.title,
                Id = movieDetailsDto.id,
                Rated = movieDetailsDto.imdbRating
            };

            return movie;
        }

        public IEnumerable<Movie> AdaptMultipleMovies(IEnumerable<MovieDto> movieDtoList)
        {
            var movieList = new List<Movie>();
            foreach (var movieDto in movieDtoList)
            {
                movieList.Add(AdaptSingleMovie(movieDto));
            }

            return movieList;
        }

        public IEnumerable<Movie> AdaptMultipleMovies(IEnumerable<MovieDetailsDto> movieDetailsDtoList)
        {
            var movieList = new List<Movie>();
            foreach (var movieDetailsDto in movieDetailsDtoList)
            {
                movieList.Add(AdaptSingleMovie(movieDetailsDto));
            }

            return movieList;
        }
    }
}
