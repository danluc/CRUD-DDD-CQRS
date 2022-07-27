using AutoMapper;
using MediatR;
using System;
using System.Threading.Tasks;
using System.Threading;
using Usuario.Data.Context;
using Usuarios.Dominio.DTOs;
using Dominio = Usuarios.Dominio.Models;
using Microsoft.EntityFrameworkCore;
using System.Collections.Generic;

namespace Usuario.Servico.Consultas.Usuarios.ListarUsuarios
{
    public class ConsultaListarUsuarios : IRequestHandler<ParametroListarUsuarios, ResultadoListarUsuarios>
    {
        private readonly BancoDadosContext _bancoDBContext;
        private readonly IMapper _mapper;

        public ConsultaListarUsuarios(BancoDadosContext bancoDBContext, IMapper mapper)
        {
            _bancoDBContext = bancoDBContext;
            _mapper = mapper;
        }

        public async Task<ResultadoListarUsuarios> Handle(ParametroListarUsuarios request, CancellationToken cancellationToken)
        {
            try
            {
                var usuarios = await _bancoDBContext.Usuarios.ToListAsync();
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
