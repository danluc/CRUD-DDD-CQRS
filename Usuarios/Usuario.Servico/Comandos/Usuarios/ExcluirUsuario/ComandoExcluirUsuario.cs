using MediatR;
using Microsoft.EntityFrameworkCore;
using System;
using System.Threading;
using System.Threading.Tasks;
using Usuario.Data.Context;
using Usuarios.Dominio.Global;

namespace Usuario.Servico.Comandos.Usuarios.ExcluirUsuario
{
    public class ComandoExcluirUsuario : IRequestHandler<ParametroExcluirUsuario, ResultadoController>
    {
        private readonly BancoDadosContext _bancoDBContext;

        public ComandoExcluirUsuario(BancoDadosContext bancoDBContext)
        {
            _bancoDBContext = bancoDBContext;
        }

        public async Task<ResultadoController> Handle(ParametroExcluirUsuario request, CancellationToken cancellationToken)
        {
            try
            {
                var usuario = await _bancoDBContext.Usuarios.FirstOrDefaultAsync(e => e.Id == request.Id);
                if (usuario is null)
                {
                    return new ResultadoController
                    {
                        Sucesso = false,
                        Mensagem = "Usuário não encontrado!"
                    };
                };

                _bancoDBContext.Usuarios.Remove(usuario);
                await _bancoDBContext.SaveChangesAsync();

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
