using Microsoft.VisualStudio.TestTools.UnitTesting;
using MovieLibrary.Controllers;
using MovieLibrary.Models;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace MovieLibraryTests
{
    [TestClass]
    public class MovieLibraryTests
    {
        private readonly MovieController _sut;
        public MovieLibraryTests()
        {
            _sut = new MovieController();
        }

        [TestMethod]
        public async Task attempting_to_get_movie_by_id_should_return_correct_movie()
        {
            // Arrange
            var expected = new Movie
            {
                Id = "tt0068646",
                Title = "The Godfather",
                Rated = 91
            };

            // Act
            var actual = await _sut.GetMovieById("tt0068646");

            // Assert
            Assert.AreEqual(expected.Title, actual.Title);
        }

        [TestMethod]
        public async Task when_getting_toplist_a_list_of_movies_should_be_returned()
        {
            // Arrange
            var expected = new List<string>
            {
                "Xiyouji zhi Nü'erguo",
                "Fifty Shades Freed",
                "Aiyaary"
            };

            // Act
            var retrievedList = await _sut.Toplist(true);
            List<string> actual = retrievedList.Take(3).ToList();

            // Assert
            CollectionAssert.AreEqual(expected, actual);
        }

        [TestMethod]
        public async Task calling_to_sort_list_ascending_should_sort_it_in_an_ascending_manner()
        {
            // Arrange
            List<Movie> unsortedMovieList = new List<Movie>
            {
                new Movie { Title = "The Godfather: Part II", Id = "tt0071562", Rated = 90 },
                new Movie { Title = "The Shawshank Redemption", Id = "tt0111161", Rated = 92 },
                new Movie { Title = "The Godfather", Id = "tt0068646", Rated = 91 }
            };

            var expected = new List<string>
            {
                "The Shawshank Redemption",
                "The Godfather",
                "The Godfather: Part II"
            };

            // Act
            var retrievedList = _sut.SortMovieList(unsortedMovieList, false);
            var actual = retrievedList;

            // Assert
            CollectionAssert.AreEqual(expected, actual);
        }

        //[TestMethod]
        //public void joining_two_arrays_should_exclude_duplicates()
        //{
        //    // Arrange
        //    var listOne = new List<Movie>
        //    {
        //        new Movie { Title = "CleanCode", Id = "1", Rated = 100 },
        //        new Movie { Title = "Kanelbullar", Id = "2", Rated = 90 },
        //        new Movie { Title = "Gifflar", Id = "3", Rated = 90 }
        //    };
        //
        //    var listTwo = new List<Movie>
        //    {
        //        new Movie { Title = "CleanCode", Id = "1", Rated = 100 },
        //        new Movie { Title = "Gifflar", Id = "3", Rated = 90 }
        //    };
        //
        //    var expected = new List<Movie>
        //    {
        //        new Movie { Title = "CleanCode", Id = "1", Rated = 100 },
        //        new Movie { Title = "Kanelbullar", Id = "2", Rated = 90 },
        //        new Movie { Title = "Gifflar", Id = "3", Rated = 90 }
        //    };
        //
        //    // Act
        //    var actual = _sut.JoinLists(listTwo, listOne);
        //
        //    // Assert
        //    CollectionAssert.AreEqual(expected, actual);
        //}
    }
}
