using AutoMapper;
using Movies.Api.Dtos;
using Movies.Domain.Entities;

namespace Movies.Api.Mappers
{
    public class DomainToDtoMappingProfile : Profile
    {
        public DomainToDtoMappingProfile()
        {
            CreateMap<MovieSummaryEntity, MovieSummaryDto>();
            CreateMap<ResultEntity, ResultDto>().ForMember(dest => dest.Movies, opt => opt.MapFrom(src => src.Results));
            CreateMap<ResultNowPlayingEntity, ResultNowPlayingDto>().ForMember(dest => dest.Movies, opt => opt.MapFrom(src => src.Results));

        }
    }
}
