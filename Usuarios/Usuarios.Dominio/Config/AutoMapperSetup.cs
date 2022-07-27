using AutoMapper;
using Usuarios.Dominio.DTOs;
using Usuarios.Dominio.Models;

namespace Usuarios.Dominio.Config
{
    public class AutoMapperSetup : Profile
    {
        public AutoMapperSetup()
        {
            CreateMap<Usuario, UsuarioDTO>().ReverseMap();
            CreateMap<UsuarioDTO, Usuario>().ReverseMap();
        }
    }
}
