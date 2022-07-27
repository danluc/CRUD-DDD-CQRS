using AutoMapper;
using MediatR;
using System;
using System.Threading.Tasks;
using System.Threading;
using Usuario.Data.Context;
using Usuarios.Dominio.DTOs;
using Dominio = Usuarios.Dominio.Models;
using Microsoft.EntityFrameworkCore;
using Usuario.Servico.Helpers;
using Usuario.Servico.Comandos.Usuarios.CadastrarUsuario;

namespace Usuario.Servico.Comandos.Usuarios.AtualizarUsuario
{
    public class ComandoAtualizarUsuario : IRequestHandler<ParametroAtualizarUsuario, ResultadoAtualizarUsuario>
    {
        private readonly BancoDadosContext _bancoDBContext;
        private readonly IMapper _mapper;

        public ComandoAtualizarUsuario(BancoDadosContext bancoDBContext, IMapper mapper)
        {
            _bancoDBContext = bancoDBContext;
            _mapper = mapper;
        }

        public async Task<ResultadoAtualizarUsuario> Handle(ParametroAtualizarUsuario request, CancellationToken cancellationToken)
        {
            try
            {
                ValidarDados(request.Dados);
                var usuario = await _bancoDBContext.Usuarios.FirstOrDefaultAsync(e => e.Id == request.Id);
                if (usuario is null)
                {
                    return new ResultadoAtualizarUsuario
                    {
                        Sucesso = false,
                        Mensagem = "Usuário não encontrado!"
                    };
                };

                usuario.Nome = request.Dados.Nome;
                usuario.Email = request.Dados.Email;
                usuario.DataNascimento = request.Dados.DataNascimento;
                usuario.Escolaridade = request.Dados.Escolaridade;
                usuario.Sobrenome = request.Dados.Sobrenome;

                _bancoDBContext.Usuarios.Update(usuario);
                await _bancoDBContext.SaveChangesAsync();

                return new ResultadoAtualizarUsuario
                {
                    Sucesso = true,
                    Usuario = _mapper.Map<UsuarioDTO>(usuario)
                };
            }
            catch (Exception ex)
            {
                return new ResultadoAtualizarUsuario
                {
                    Mensagem = ex.Message,
                    Sucesso = false
                };
            }
        }

        private void ValidarDados(UsuarioDTO dados)
        {
            if (!ValidarDataNascimentoHelper.ValidarDataMaiorAtual(dados.DataNascimento))
                throw new Exception("Data nascimento não permitida!");


            if (!ValidarEmailHelper.ValidarEmail(dados.Email))
                throw new Exception("E-mail inválido!");
        }
    }
}
