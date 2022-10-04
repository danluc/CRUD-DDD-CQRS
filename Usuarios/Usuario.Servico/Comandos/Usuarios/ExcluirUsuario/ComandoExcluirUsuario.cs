using MediatR;
using System;
using System.Threading;
using System.Threading.Tasks;
using Usuarios.Dominio.Contratos;
using Usuarios.Dominio.Global;
using Dominio = Usuarios.Dominio.Models;

namespace Usuario.Servico.Comandos.Usuarios.ExcluirUsuario
{
    public class ComandoExcluirUsuario : IRequestHandler<ParametroExcluirUsuario, ResultadoController>
    {
        private readonly IRepositorioComando<Dominio.Usuario> _repositorioComandoUsuario;
        private readonly IRepositorioConsulta<Dominio.Usuario> _repositorioConsultaUsuario;

        public ComandoExcluirUsuario(
            IRepositorioComando<Dominio.Usuario> repositorioComandoUsuario,
            IRepositorioConsulta<Dominio.Usuario> repositorioConsultaUsuario)
        {
            _repositorioComandoUsuario = repositorioComandoUsuario;
            _repositorioConsultaUsuario = repositorioConsultaUsuario;
        }

        public async Task<ResultadoController> Handle(ParametroExcluirUsuario request, CancellationToken cancellationToken)
        {
            try
            {
                var usuario = await _repositorioConsultaUsuario.FirstOrDefault(leitura: true, filtro: e => e.Id == request.Id);
                if (usuario is null)
                {
                    return new ResultadoController
                    {
                        Sucesso = false,
                        Mensagem = "Usuário não encontrado!"
                    };
                };

                _repositorioComandoUsuario.Delete(usuario);
                await _repositorioComandoUsuario.SaveChangesAsync();

                return new ResultadoController
                {
                    Sucesso = true,
                };
            }
            catch (Exception ex)
            {
                return new ResultadoController
                {
                    Mensagem = ex.Message,
                    Sucesso = false
                };
            }
        }
    }
}
