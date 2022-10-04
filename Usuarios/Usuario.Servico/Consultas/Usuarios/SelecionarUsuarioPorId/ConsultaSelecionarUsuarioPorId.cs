using AutoMapper;
using MediatR;
using System;
using System.Threading;
using System.Threading.Tasks;
using Usuarios.Dominio.Contratos;
using Usuarios.Dominio.DTOs;
using Dominio = Usuarios.Dominio.Models;

namespace Usuario.Servico.Consultas.Usuarios.SelecionarUsuarioPorId
{
    public class ConsultaSelecionarUsuarioPorId : IRequestHandler<ParametroSelecionarUsuarioPorId, ResultadoSelecionarUsuarioPorId>
    {
        private readonly IMapper _mapper;
        private readonly IRepositorioConsulta<Dominio.Usuario> _repositorioConsultaUsuario;

        public ConsultaSelecionarUsuarioPorId(IMapper mapper,
            IRepositorioConsulta<Dominio.Usuario> repositorioConsultaUsuario)
        {
            _mapper = mapper;
            _repositorioConsultaUsuario = repositorioConsultaUsuario;
        }

        public async Task<ResultadoSelecionarUsuarioPorId> Handle(ParametroSelecionarUsuarioPorId request, CancellationToken cancellationToken)
        {
            try
            {
                var usuario = await _repositorioConsultaUsuario.FindById(request.Id);
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
