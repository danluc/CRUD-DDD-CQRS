using AutoMapper;
using EnumsNET;
using Usuarios.Dominio.DTOs;
using Usuarios.Dominio.Global.Enum;
using Usuarios.Dominio.Models;
using System.Collections.Generic;
using System.Threading.Tasks;


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
