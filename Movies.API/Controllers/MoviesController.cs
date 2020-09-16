using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Movies.API.Models;
using Movies.API.Repository;
using Movies.API.Service;

// For more information on enabling MVC for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace MoviesAPI.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class MoviesController : ControllerBase
    {
        readonly MovieRepository repository;
        readonly MovieService service;

        public MoviesController(MovieRepository repository, MovieService service)
        {
            this.repository = repository;
            this.service = service;
        }

        [HttpGet]
        public List<Movie> Index()
        {
            return repository.GetMovies();
        }

        [HttpPost]
        public Champions DeterminateChampions([FromBody] List<string> idMovies)
        {
            return this.service.CalculateChampions(idMovies);
        }
    }
}
