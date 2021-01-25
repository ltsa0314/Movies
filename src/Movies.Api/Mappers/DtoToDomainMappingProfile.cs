using AutoMapper;
using Movies.Api.Dtos;
using Movies.Domain.Entities;

namespace Movies.Api.Mappers
{
    public class DtoToDomainMappingProfile : Profile
    {
        public DtoToDomainMappingProfile()
        {
            CreateMap<MovieSummaryDto, MovieSummaryEntity>();
            CreateMap<ResultDto, ResultEntity>().ForMember(dest => dest.Results, opt => opt.MapFrom(src => src.Movies));
            CreateMap<ResultNowPlayingDto, ResultNowPlayingEntity>().ForMember(dest => dest.Results, opt => opt.MapFrom(src => src.Movies));
        }

    }
}
