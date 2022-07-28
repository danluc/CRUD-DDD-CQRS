using AutoMapper;
using MediatR;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using Usuario.Data.Context;
using Usuarios.Dominio.DTOs;

namespace Usuario.Servico.Consultas.Usuarios.SelecionarUsuarioPorId
{
    public class ConsultaSelecionarUsuarioPorId : IRequestHandler<ParametroSelecionarUsuarioPorId, ResultadoSelecionarUsuarioPorId>
    {
        private readonly BancoDadosContext _bancoDBContext;
        private readonly IMapper _mapper;

        public ConsultaSelecionarUsuarioPorId(BancoDadosContext bancoDBContext, IMapper mapper)
        {
            _bancoDBContext = bancoDBContext;
            _mapper = mapper;
        }

        public async Task<ResultadoSelecionarUsuarioPorId> Handle(ParametroSelecionarUsuarioPorId request, CancellationToken cancellationToken)
        {
            try
            {
                var usuario = await _bancoDBContext.Usuarios.FindAsync(request.Id);
                return new ResultadoSelecionarUsuarioPorId
                {
                    Sucesso = true,
                    Usuario = _mapper.Map<UsuarioDTO>(usuario)
                };
            }
            catch (Exception ex)
            {
                return new ResultadoSelecionarUsuarioPorId
                {
                    Sucesso = false,
                    Mensagem = ex.Message
                };
            }
        }
    }
}
