using AutoMapper;
using CursoAluraFilmesAPI.Data.DTOs;
using CursoAluraFilmesAPI.Models;

namespace CursoAluraFilmesAPI.Profiles
{
    public class CinemaProfile : Profile
    {
        public CinemaProfile()
        {
            CreateMap<CreateCinemaDTO, Cinema>();
            CreateMap<Cinema, ReadCinemaDto>();
            CreateMap<UpdateCinemaDTO, Cinema>();
        }
    }
}
