using AutoMapper;
using CursoAluraFilmesAPI.Data.DTOs;
using CursoAluraFilmesAPI.Models;

namespace CursoAluraFilmesAPI.Profiles
{
    public class FilmeProfile : Profile
    {
        public FilmeProfile()
        {
            CreateMap<CreateFilmeDTO, Filme>();
        }
    }
}
