using Movies.Domain.Entities;
using System.Threading.Tasks;

namespace Movies.Domain.Interfaces
{
    public interface IMoviesRepository
    {
        Task<ResultNowPlayingEntity> GetNowPlaying(int page);
        Task<MovieEntity> GetDetails(int movieId);
    }
}
