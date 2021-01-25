using AutoMapper;
using Microsoft.AspNetCore.Mvc;
using Movies.Api.Dtos;
using Movies.Domain.Entities;
using Movies.Domain.Interfaces;
using System;
using System.Linq;
using System.Threading.Tasks;

namespace Movies.Api.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class MoviesController : ControllerBase
    {
        private IMoviesRepository _moviesRepository;
        private IGenresRepository _genresRepository;
        private readonly IMapper _mapper;

        public MoviesController(IMoviesRepository moviesRepository, IGenresRepository genresRepository, IMapper mapper)
        {

            _moviesRepository = moviesRepository ?? throw new ArgumentNullException(nameof(moviesRepository));
            _genresRepository = genresRepository ?? throw new ArgumentNullException(nameof(genresRepository));
            _mapper = mapper ?? throw new ArgumentNullException(nameof(mapper));
        }

        [HttpGet("NowPlaying")]
        public async Task<IActionResult> GetNowPlaying(int page = 1)
        {
            try
            {
                var resultRepository = await _moviesRepository.GetNowPlaying(page);
                var response = _mapper.Map<ResultNowPlayingDto>(resultRepository);

                var genres = await _genresRepository.GetMovieList();
                response.Movies.ForEach(movie =>
                {
                    resultRepository.Results.FirstOrDefault(x => x.Id == movie.Id).Genre_Ids
                    .ForEach(genre =>
                    {
                        movie.Genres.Add(genres.Genres.FirstOrDefault(x => x.Id == genre).Name);
                    });
                });

                return Ok(response);
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }


        }

        [HttpGet("GetDetails")]
        public async Task<IActionResult> GetDetails(int movieId)
        {
            try
            {
                var response = await _moviesRepository.GetDetails(movieId);
                return Ok(response);
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }


        }

    }
}
