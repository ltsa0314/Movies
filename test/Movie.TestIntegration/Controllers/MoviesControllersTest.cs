using Microsoft.AspNetCore;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.TestHost;
using Movies.Api;
using Movies.Api.Dtos;
using Movies.Domain.Entities;
using Newtonsoft.Json;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using Xunit;


namespace Movie.TestIntegration.Controllers
{

    public class MoviesControllersTest
    {

        [Fact]
        public void GetNowPlaying()
        {
            // Arrange
            TestServer server;
            HttpClient client;

            server = new TestServer(WebHost.CreateDefaultBuilder().UseStartup<Startup>().UseEnvironment("Development"));
            client = server.CreateClient();

            // Act
            var result = client.GetAsync($"/api/Movies/NowPlaying?page=1").Result;
            ResultNowPlayingDto resultNowplaying = null;

            if (result.StatusCode == HttpStatusCode.OK)
            {
                resultNowplaying = JsonConvert.DeserializeObject<ResultNowPlayingDto>(result.Content.ReadAsStringAsync().Result);
            }

            // Assert
            Assert.True(result.StatusCode == HttpStatusCode.OK);
            Assert.True(resultNowplaying != null);
            Assert.True(resultNowplaying.Page == 1);
            Assert.True(resultNowplaying.Movies != null);
            Assert.True(resultNowplaying.Movies.Count == 20);

        }



        [Fact]
        public void GetDetails()
        {
            // Arrange
            TestServer server;
            HttpClient client;


            server = new TestServer(WebHost.CreateDefaultBuilder().UseStartup<Startup>().UseEnvironment("Development"));
            client = server.CreateClient();

            var movieId = 0;

            var resultNowplaying = client.GetAsync($"/api/Movies/NowPlaying?page=1").Result;
            if (resultNowplaying.StatusCode == HttpStatusCode.OK)
            {
                ResultNowPlayingDto nowplaying = JsonConvert.DeserializeObject<ResultNowPlayingDto>(resultNowplaying.Content.ReadAsStringAsync().Result);
                movieId = nowplaying.Movies.FirstOrDefault().Id;
            }

            
            // Act


            var result = client.GetAsync($"api/movies/getdetails?movieId={movieId}").Result;
            MovieEntity movie = null;

            if (result.StatusCode == HttpStatusCode.OK)
            {
                movie = JsonConvert.DeserializeObject<MovieEntity>(result.Content.ReadAsStringAsync().Result);
            }

            // Assert
            Assert.True(result.StatusCode == HttpStatusCode.OK);
            Assert.True(movie != null);
            Assert.True(movie.Id == movieId);
        

        }
    }
}
