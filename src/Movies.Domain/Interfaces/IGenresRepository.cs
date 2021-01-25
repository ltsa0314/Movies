using Movies.Domain.Entities;
using System.Threading.Tasks;

namespace Movies.Domain.Interfaces
{
    public interface IGenresRepository
    {
        Task<ResultGenreEntity> GetMovieList();


    }
}
