using AutoMapper;
using MediatR;
using System;
using System.Threading;
using System.Threading.Tasks;
using Usuarios.Dominio.Contratos;
using Usuarios.Dominio.DTOs;
using Dominio = Usuarios.Dominio.Models;

namespace Usuario.Servico.Comandos.Usuarios.AtualizarUsuario
{
    public class ComandoAtualizarUsuario : IRequestHandler<ParametroAtualizarUsuario, ResultadoAtualizarUsuario>
    {
        private readonly IMapper _mapper;
        private readonly IRepositorioComando<Dominio.Usuario> _repositorioComandoUsuario;
        private readonly IRepositorioConsulta<Dominio.Usuario> _repositorioConsultaUsuario;

        public ComandoAtualizarUsuario(IMapper mapper,
            IRepositorioComando<Dominio.Usuario> repositorioComandoUsuario,
            IRepositorioConsulta<Dominio.Usuario> repositorioConsultaUsuario)
        {
            _mapper = mapper;
            _repositorioComandoUsuario = repositorioComandoUsuario;
            _repositorioConsultaUsuario = repositorioConsultaUsuario;
        }

        public async Task<ResultadoAtualizarUsuario> Handle(ParametroAtualizarUsuario request, CancellationToken cancellationToken)
        {
            try
            {
                var usuario = await _repositorioConsultaUsuario.FirstOrDefault(leitura: true, filtro: e => e.Id == request.Id);
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

                _repositorioComandoUsuario.Update(usuario);
                await _repositorioComandoUsuario.SaveChangesAsync();

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
    }
}
