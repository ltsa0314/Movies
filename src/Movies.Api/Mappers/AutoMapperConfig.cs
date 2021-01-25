using System;

namespace Movies.Api.Mappers
{
    public class AutoMapperConfig
    {
        public static Type[] RegisterMappings()
        {

            return new Type[] {
                typeof(DomainToDtoMappingProfile),
                typeof(DtoToDomainMappingProfile),
        };
        }
    }
}
