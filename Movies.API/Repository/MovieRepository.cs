using System.Collections.Generic;
using RestSharp;
using Newtonsoft.Json;
using Movies.API.Models;
using Movies.API.Exceptions;

namespace Movies.API.Repository
{
    public class MovieRepository
    {
        public List<Movie> GetMovies()
        {
            var client = new RestClient($"{Config.baseUrl}/api/filmes");

            var request = new RestRequest(Method.GET);

            var response = client.Execute(request);

            if (response.IsSuccessful)
            {
                var content = response.Content;

                return JsonConvert.DeserializeObject<List<Movie>>(content);
            }
            else
            {
                throw new MovieAPINotAvailableException($"Movies API not Available. StatusCode: {response.StatusCode}, Response: {response.Content}");
            }
        }
    }
}