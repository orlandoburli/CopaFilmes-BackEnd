using System.Collections.Generic;
using Movies.API.Exceptions;
using Movies.API.Models;
using Movies.API.Repository;
using Movies.API.Service;
using NUnit.Framework;

namespace Movies.Tests.UnitTests
{
    public class MovieChampionTest
    {
        private List<Movie> movies;

        private MovieService movieService;

        [SetUp]
        public void Setup()
        {
            this.movies = new List<Movie>();
            this.movies.Add(new Movie() { Ano = 2017, Titulo = "A", Id = "a", Nota = 1 });
            this.movies.Add(new Movie() { Ano = 2017, Titulo = "B", Id = "b", Nota = 2 });
            this.movies.Add(new Movie() { Ano = 2017, Titulo = "C", Id = "c", Nota = 3 });
            this.movies.Add(new Movie() { Ano = 2017, Titulo = "D", Id = "d", Nota = 4 });
            this.movies.Add(new Movie() { Ano = 2017, Titulo = "E", Id = "e", Nota = 5 });
            this.movies.Add(new Movie() { Ano = 2017, Titulo = "F", Id = "f", Nota = 6 });
            this.movies.Add(new Movie() { Ano = 2017, Titulo = "G", Id = "g", Nota = 7 });
            this.movies.Add(new Movie() { Ano = 2017, Titulo = "H", Id = "h", Nota = 8 });

            this.movieService = new MovieService(new MovieChampionService(), new MovieRepository());
        }

        [Test]
        public void ShouldReturnTheChampion()
        {
            var champions = this.movieService.CalculateChampions(this.movies);

            Assert.AreEqual("h", champions.FirstPlace.Id);
            Assert.AreEqual("g", champions.SecondPlace.Id);
        }

        [Test]
        public void ShouldReturnTheChampionWith4Movies()
        {
            this.movies = new List<Movie>();
            this.movies.Add(new Movie() { Ano = 2017, Titulo = "A", Id = "a", Nota = 1 });
            this.movies.Add(new Movie() { Ano = 2017, Titulo = "B", Id = "b", Nota = 2 });
            this.movies.Add(new Movie() { Ano = 2017, Titulo = "C", Id = "c", Nota = 3 });
            this.movies.Add(new Movie() { Ano = 2017, Titulo = "D", Id = "d", Nota = 4 });

            var champions = this.movieService.CalculateChampions(this.movies);

            Assert.AreEqual("d", champions.FirstPlace.Id);
            Assert.AreEqual("c", champions.SecondPlace.Id);
        }

        [Test]
        public void ShouldThrowExceptionWhenPass7Movies()
        {
            this.movies = new List<Movie>();
            this.movies.Add(new Movie() { Ano = 2017, Titulo = "A", Id = "a", Nota = 1 });
            this.movies.Add(new Movie() { Ano = 2017, Titulo = "B", Id = "b", Nota = 2 });
            this.movies.Add(new Movie() { Ano = 2017, Titulo = "C", Id = "c", Nota = 3 });
            this.movies.Add(new Movie() { Ano = 2017, Titulo = "D", Id = "d", Nota = 4 });
            this.movies.Add(new Movie() { Ano = 2017, Titulo = "E", Id = "e", Nota = 5 });
            this.movies.Add(new Movie() { Ano = 2017, Titulo = "F", Id = "f", Nota = 6 });
            this.movies.Add(new Movie() { Ano = 2017, Titulo = "G", Id = "g", Nota = 7 });
            Assert.Throws<InvalidNumberOfMoviesException>(() => this.movieService.CalculateChampions(this.movies));
        }


        [Test]
        public void ShouldThrowExceptionWhenPass6Movies()
        {
            this.movies = new List<Movie>();
            this.movies.Add(new Movie() { Ano = 2017, Titulo = "A", Id = "a", Nota = 1 });
            this.movies.Add(new Movie() { Ano = 2017, Titulo = "B", Id = "b", Nota = 2 });
            this.movies.Add(new Movie() { Ano = 2017, Titulo = "C", Id = "c", Nota = 3 });
            this.movies.Add(new Movie() { Ano = 2017, Titulo = "D", Id = "d", Nota = 4 });
            this.movies.Add(new Movie() { Ano = 2017, Titulo = "E", Id = "e", Nota = 5 });
            this.movies.Add(new Movie() { Ano = 2017, Titulo = "F", Id = "f", Nota = 6 });
            
            Assert.Throws<InvalidNumberOfMoviesException>(() => this.movieService.CalculateChampions(this.movies));
        }

        [Test]
        public void ShouldDetermineChampionByNameWhenScoreIsTheSame()
        {
            this.movies = new List<Movie>();
            this.movies.Add(new Movie() { Ano = 2017, Titulo = "A", Id = "a", Nota = 9 });
            this.movies.Add(new Movie() { Ano = 2017, Titulo = "B", Id = "b", Nota = 2 });
            this.movies.Add(new Movie() { Ano = 2017, Titulo = "C", Id = "c", Nota = 3 });
            this.movies.Add(new Movie() { Ano = 2017, Titulo = "D", Id = "d", Nota = 4 });
            this.movies.Add(new Movie() { Ano = 2017, Titulo = "E", Id = "e", Nota = 5 });
            this.movies.Add(new Movie() { Ano = 2017, Titulo = "F", Id = "f", Nota = 6 });
            this.movies.Add(new Movie() { Ano = 2017, Titulo = "G", Id = "g", Nota = 9 });
            this.movies.Add(new Movie() { Ano = 2017, Titulo = "H", Id = "h", Nota = 8 });

            var champions = this.movieService.CalculateChampions(this.movies);

            Assert.AreEqual("a", champions.FirstPlace.Id);
            Assert.AreEqual("g", champions.SecondPlace.Id);
        }
    }
}
