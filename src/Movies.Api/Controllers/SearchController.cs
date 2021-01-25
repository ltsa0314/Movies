using AutoMapper;
using Microsoft.AspNetCore.Mvc;
using Movies.Api.Dtos;
using Movies.Domain.Interfaces;
using System;
using System.Linq;
using System.Threading.Tasks;

namespace Movies.Api.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class SearchController : ControllerBase
    {
        private ISearchRespository _searchrepository;
        private IGenresRepository _genresRepository;
        private readonly IMapper _mapper;

        public SearchController(ISearchRespository repository, IGenresRepository genresRepository, IMapper mapper)
        {

            _searchrepository = repository ?? throw new ArgumentNullException(nameof(repository));
            _genresRepository = genresRepository ?? throw new ArgumentNullException(nameof(genresRepository));
            _mapper = mapper ?? throw new ArgumentNullException(nameof(mapper));
        }

        [HttpGet("Movies")]
        public async Task<IActionResult> SearchMovies(string textToSearch, int page = 1)
        {
            try
            {
                var resultRepository = await _searchrepository.SearchMovies(textToSearch, page);
                var response = _mapper.Map<ResultDto>(resultRepository);

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
    }
}
