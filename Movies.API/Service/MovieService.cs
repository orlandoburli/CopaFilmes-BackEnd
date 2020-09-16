using System;
using System.Linq;
using System.Collections.Generic;
using Movies.API.Exceptions;
using Movies.API.Models;
using Movies.API.Repository;
using Movies.API.Utils;

namespace Movies.API.Service
{
    public class MovieService
    {
        private readonly MovieChampionService movieChampionService;
        private readonly MovieRepository movieRepository;

        public MovieService(MovieChampionService movieChampionService, MovieRepository movieRepository)
        {
            this.movieChampionService = movieChampionService;
            this.movieRepository = movieRepository;
        }

        public Champions CalculateChampions(List<String> idMovies)
        {
            var movieList = this.movieRepository.GetMovies();

            var movies = idMovies.Select(movieId => movieList.Find(movie => movie.Id == movieId)).ToList();

            movies.RemoveAll(item => item == null);

            return CalculateChampions(movies);
        }

        public Champions CalculateChampions(List<Movie> movies)
        {
            if (!MathUtils.IsSquare(movies.Count) || movies.Count == 0)
            {
                throw new InvalidNumberOfMoviesException($"Invalid number of movies! Should be a square of 2! Received: {movies.Count}");
            }

            List<Movie> localMovies = new List<Movie>();

            localMovies.AddRange(movies);

            while (localMovies.Count > 2)
            {
                List<Movie> newMovies = new List<Movie>();

                for (var i = 0; i < localMovies.Count / 2; i++)
                {
                    Movie movie1 = localMovies[i];
                    Movie movie2 = localMovies[localMovies.Count - i - 1];

                    var champions = this.movieChampionService.DeterminateChampions(movie1, movie2);

                    newMovies.Add(champions.FirstPlace);
                }

                localMovies = newMovies;
            }

            return this.movieChampionService.DeterminateChampions(localMovies[0], localMovies[1]);
        }
    }
}
