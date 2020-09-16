using System.Collections.Generic;
using Movies.API.Models;
using System.Linq;
using Movies.API.Comparators;

namespace Movies.API.Service
{
    public class MovieChampionService
    {
        public Champions DeterminateChampions(Movie movie1, Movie movie2)
        {
            if (movie1 == null || movie2 == null)
            {
                return null;
            }

            var movies = this.toArray(movie1, movie2);

            movies.Sort(MovieChampionComparator.sortChampion());


            return new Champions()
            {
                FirstPlace = movies[0],
                SecondPlace = movies[1]
            };
        }

        public List<Movie> toArray(Movie movie1, Movie movie2)
        {
            Movie[] arrayMovies = { movie1, movie2 };
            return arrayMovies.ToList();
        }
    }
}
