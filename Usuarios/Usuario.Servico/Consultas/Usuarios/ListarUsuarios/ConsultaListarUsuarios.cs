using AutoMapper;
using MediatR;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Threading;
using System.Threading.Tasks;
using Usuarios.Dominio.Contratos;
using Usuarios.Dominio.DTOs;
using Dominio = Usuarios.Dominio.Models;

namespace Usuario.Servico.Consultas.Usuarios.ListarUsuarios
{
    public class ConsultaListarUsuarios : IRequestHandler<ParametroListarUsuarios, ResultadoListarUsuarios>
    {
        private readonly IMapper _mapper;
        private readonly IRepositorioConsulta<Dominio.Usuario> _repositorioConsultaUsuario;

        public ConsultaListarUsuarios(IMapper mapper,
            IRepositorioConsulta<Dominio.Usuario> repositorioConsultaUsuario)
        {
            _mapper = mapper;
            _repositorioConsultaUsuario = repositorioConsultaUsuario;
        }

        public async Task<ResultadoListarUsuarios> Handle(ParametroListarUsuarios request, CancellationToken cancellationToken)
        {
            try
            {
                var usuarios = await _repositorioConsultaUsuario.Query().ToListAsync();
                return new ResultadoListarUsuarios
                {
                    Sucesso = true,
                    Usuarios = _mapper.Map<IEnumerable<UsuarioDTO>>(usuarios)
                };
            }
            catch (Exception ex)
            {
                return new ResultadoListarUsuarios
                {
                    Sucesso = false,
                    Mensagem = ex.Message
                };
            }
        }
    }
}
