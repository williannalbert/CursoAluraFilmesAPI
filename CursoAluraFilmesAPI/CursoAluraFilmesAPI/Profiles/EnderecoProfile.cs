using AutoMapper;
using CursoAluraFilmesAPI.Data.DTOs;
using CursoAluraFilmesAPI.Models;

namespace CursoAluraFilmesAPI.Profiles
{
    public class EnderecoProfile : Profile
    {
        public EnderecoProfile()
        {
            CreateMap<CreateEnderecoDTO, Endereco>();
            CreateMap<Endereco, ReadEnderecoDTO>();
            CreateMap<UpdateEnderecoDTO, Endereco>();
        }
    }
}
