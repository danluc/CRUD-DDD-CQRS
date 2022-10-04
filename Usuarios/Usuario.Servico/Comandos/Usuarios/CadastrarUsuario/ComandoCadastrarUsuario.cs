using AutoMapper;
using MediatR;
using System;
using System.Threading;
using System.Threading.Tasks;
using Usuarios.Dominio.Contratos;
using Usuarios.Dominio.DTOs;
using Dominio = Usuarios.Dominio.Models;

namespace Usuario.Servico.Comandos.Usuarios.CadastrarUsuario
{
    public class ComandoCadastrarUsuario : IRequestHandler<ParametroCadastrarUsuario, ResultadoCadastrarUsuario>
    {
        private readonly IMapper _mapper;
        private readonly IRepositorioComando<Dominio.Usuario> _repositorioComandoUsuario;

        public ComandoCadastrarUsuario(IMapper mapper,
            IRepositorioComando<Dominio.Usuario> repositorioComandoUsuario)
        {
            _mapper = mapper;
            _repositorioComandoUsuario = repositorioComandoUsuario;
        }

        public async Task<ResultadoCadastrarUsuario> Handle(ParametroCadastrarUsuario request, CancellationToken cancellationToken)
        {
            try
            {
                var dados = _mapper.Map<Dominio.Usuario>(request.Dados);
                var result = await _repositorioComandoUsuario.Insert(dados);
                await _repositorioComandoUsuario.SaveChangesAsync();

                return new ResultadoCadastrarUsuario
                {
                    Sucesso = true,
                    Usuario = _mapper.Map<UsuarioDTO>(result)
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
