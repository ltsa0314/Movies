using AutoMapper;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.PlatformAbstractions;
using Microsoft.OpenApi.Models;
using Movies.Api.Mappers;
using Movies.Domain.Interfaces;
using Movies.Infraestructure.Repositories;
using System;
using System.IO;

namespace Movies.Api
{
    public static class Ioc
    {
        public static void AddSwagger(this IServiceCollection services)
        {
            // Swagger
            var basePath = PlatformServices.Default.Application.ApplicationBasePath;
            var xmlPath = Path.Combine(basePath, "Movies.Api.xml");

            services.AddSwaggerGen(config =>
            {
                config.SwaggerDoc("v1", new OpenApiInfo()
                {
                    Title = "Movies Api",
                    Version = "v1",
                    Contact = new OpenApiContact()
                    {
                        Email = "ltsa0314@gmail.com",
                        Name = "Leidy Tatiana Sanchez ",
                    },
                });

                config.IncludeXmlComments(xmlPath);
            });
        }

        public static void AddRepositories(this IServiceCollection services, IConfiguration configuration)
        {
            // Transient , Scope , Singleton---- se resulven las instancias de los repositories
            services.AddHttpClient<ISearchRespository, SearchRespository>((provider, client) =>
            {
                client.BaseAddress = new Uri(configuration.GetSection("apiMovies:urlBase").Value);
            });

            services.AddHttpClient<IGenresRepository, GenresRepository>((provider, client) =>
            {
                client.BaseAddress = new Uri(configuration.GetSection("apiMovies:urlBase").Value);
            });

            services.AddHttpClient<IMoviesRepository, MoviesRepository>((provider, client) =>
            {
                client.BaseAddress = new Uri(configuration.GetSection("apiMovies:urlBase").Value);
            });
        }

        public static void AddAutoMapperSetup(this IServiceCollection services)
        {
            services.AddAutoMapper(AutoMapperConfig.RegisterMappings());
        }

    }
}
