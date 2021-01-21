using Microsoft.AspNetCore.Mvc;
using MovieLibrary.Models;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Text.Json;
using System.Threading.Tasks;

namespace MovieLibrary.Controllers
{

    [ApiController]
    [Route("[controller]")]
    public class MovieController
    {
        static HttpClient client = new HttpClient();
        IMovieAdapter movieAdapter = new MovieAdapter();
         
        [HttpGet]
        [Route("/toplist")]
        public async Task<IEnumerable<string>> Toplist([FromQuery] bool isOrderByAscending)
        {
            List<string> result = new List<string>();
            var fullMovieList = await RetrieveList();
            result = SortMovieList(fullMovieList, isOrderByAscending);
            return result;
        }

        [HttpGet]
        [Route("/movie")]
        public async Task<Movie> GetMovieById([FromQuery] string id) 
        {
            var movieList = await RetrieveList();
            var movieIndex = movieList.FindIndex(p => p.Id == id);
            Movie selectedMovie = movieList[movieIndex];
            return selectedMovie;
        }

        private async Task<List<Movie>> RetrieveList()
        {
            List<Movie> moviesList = await GetMovieList();
            List<Movie> movieDetailsList = await GetDetails();
            var fullMovieList = JoinLists(movieDetailsList, moviesList);
            return fullMovieList;
        }

        private async Task<List<Movie>> GetMovieList()
        {
            var requestUri = "https://ithstenta2020.s3.eu-north-1.amazonaws.com/topp100.json";
            var response = await client.GetAsync(requestUri);
            var content = await response.Content.ReadAsStringAsync();
            var movieDtoList = JsonSerializer.Deserialize<List<MovieDto>>(content);
            var adaptedDtoList = movieAdapter.AdaptMultipleMovies(movieDtoList).ToList();
            return adaptedDtoList;
        }

        public async Task<List<Movie>> GetDetails()
        {
            var requestUri = "https://ithstenta2020.s3.eu-north-1.amazonaws.com/detailedMovies.json";
            var response = await client.GetAsync(requestUri);
            var content = await response.Content.ReadAsStringAsync();
            var movieDetailsDtoList = JsonSerializer.Deserialize<List<MovieDetailsDto>>(content);
            var adaptedDetailsDtoList = movieAdapter.AdaptMultipleMovies(movieDetailsDtoList).ToList();
            return adaptedDetailsDtoList;
        }

        public List<string> SortMovieList(List<Movie> movieList, bool isAscendingWanted)
        {
            List<string> result = new List<string>();
            if (isAscendingWanted)
            {
                result = movieList.OrderBy(r => r.Rated).Select(t => t.Title).ToList();
            }
            else
            {
                result = movieList.OrderByDescending(r => r.Rated).Select(t => t.Title).ToList();
            }

            return result;
        }

        private List<Movie> JoinLists(List<Movie> movieDetailsList, List<Movie> existingMoviesList)
        {
            List<Movie> joinedList = existingMoviesList.Union(movieDetailsList).ToList();
            return joinedList;
        }
    }
}