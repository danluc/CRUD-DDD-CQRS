using AutoMapper;
using MediatR;
using System;
using System.Threading;
using System.Threading.Tasks;
using Usuario.Data.Context;
using Usuario.Servico.Helpers;
using Usuarios.Dominio.DTOs;
using Dominio = Usuarios.Dominio.Models;

namespace Usuario.Servico.Comandos.Usuarios.CadastrarUsuario
{
    public class ComandoCadastrarUsuario : IRequestHandler<ParametroCadastrarUsuario, ResultadoCadastrarUsuario>
    {
        private readonly BancoDadosContext _bancoDBContext;
        private readonly IMapper _mapper;

        public ComandoCadastrarUsuario(BancoDadosContext bancoDBContext, IMapper mapper)
        {
            _bancoDBContext = bancoDBContext;
            _mapper = mapper;
        }

        public async Task<ResultadoCadastrarUsuario> Handle(ParametroCadastrarUsuario request, CancellationToken cancellationToken)
        {
            try
            {
                ValidarUsuarioHelper.Validar(request.Dados);
                var dados = _mapper.Map<Dominio.Usuario>(request.Dados);
                var result = await _bancoDBContext.Usuarios.AddAsync(dados);
                await _bancoDBContext.SaveChangesAsync();

                return new ResultadoCadastrarUsuario
                {
                    Sucesso = true,
                    Usuario = _mapper.Map<UsuarioDTO>(result.Entity)
                };
            }
            catch (Exception ex)
            {
                return new ResultadoCadastrarUsuario
                {
                    Mensagem = ex.Message,
                    Sucesso = false
                };
            }
        }
    }
}
