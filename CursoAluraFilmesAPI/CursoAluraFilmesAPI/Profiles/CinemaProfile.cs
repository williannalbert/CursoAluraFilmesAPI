﻿using AutoMapper;
using CursoAluraFilmesAPI.Data.DTOs;
using CursoAluraFilmesAPI.Models;

namespace CursoAluraFilmesAPI.Profiles
{
    public class CinemaProfile : Profile
    {
        public CinemaProfile()
        {
            CreateMap<CreateCinemaDTO, Cinema>();
            CreateMap<Cinema, ReadCinemaDto>()
                .ForMember(cinemaDTO => cinemaDTO.Endereco,
                    opt => opt.MapFrom(cinema => cinema.Endereco))
                .ForMember(cinemaDTO => cinemaDTO.Sessoes,
                    opt => opt.MapFrom(cinema => cinema.Sessoes));
            CreateMap<UpdateCinemaDTO, Cinema>();
        }
    }
}
