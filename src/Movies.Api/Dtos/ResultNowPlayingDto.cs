using Movies.Domain.Entities;

namespace Movies.Api.Dtos
{
    public class ResultNowPlayingDto : ResultDto
    {
        public DatesEntity Dates { get; set; }
    }
}
