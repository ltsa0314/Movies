using Microsoft.Extensions.Configuration;
using Movies.Domain.Entities;
using Movies.Domain.Interfaces;
using Newtonsoft.Json;
using System;
using System.Net.Http;
using System.Threading.Tasks;

namespace Movies.Infraestructure.Repositories
{
    public class MoviesRepository : IMoviesRepository
    {
        private readonly HttpClient _http;
        private readonly IConfiguration _configuration;
        public MoviesRepository(HttpClient http, IConfiguration configuration)
        {
            _http = http ?? throw new ArgumentNullException(nameof(http));
            _configuration = configuration ?? throw new ArgumentNullException(nameof(configuration));
        }

        public async Task<MovieEntity> GetDetails(int movieId)
        {
            string routeApi = $"{_http.BaseAddress}/movie/{movieId}?language=es-ES&api_key={_configuration.GetSection("apiMovies:key").Value}";
            var httpResponse = await _http.GetAsync(routeApi);
            var content = await httpResponse.Content.ReadAsStringAsync();

            if (!httpResponse.IsSuccessStatusCode)
            {
                throw new HttpRequestException(content.ToString());
            }
            var response = JsonConvert.DeserializeObject<MovieEntity>(content);

            return response;
        }

        public async Task<ResultNowPlayingEntity> GetNowPlaying(int page)
        {
            string routeApi = $"{_http.BaseAddress}/movie/now_playing?page={page}&language=es-ES&api_key={_configuration.GetSection("apiMovies:key").Value}";
            var httpResponse = await _http.GetAsync(routeApi);
            var content = await httpResponse.Content.ReadAsStringAsync();

            if (!httpResponse.IsSuccessStatusCode)
            {
                throw new HttpRequestException(content.ToString());
            }
            var response = JsonConvert.DeserializeObject<ResultNowPlayingEntity>(content);

            return response;
        }
    }
}
