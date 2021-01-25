using Movies.Domain.Entities;
using System.Threading.Tasks;

namespace Movies.Domain.Interfaces
{
    public interface ISearchRespository
    {
        Task<ResultEntity> SearchMovies(string textToSearch, int page);
    }
}
