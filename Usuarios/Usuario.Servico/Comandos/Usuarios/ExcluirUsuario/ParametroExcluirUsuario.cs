using MediatR;
using Usuarios.Dominio.Global;

namespace Usuario.Servico.Comandos.Usuarios.ExcluirUsuario
{
    public class ParametroExcluirUsuario : IRequest<ResultadoController>
    {
        public ParametroExcluirUsuario(int id)
        {
            Id = id;
        }
        public int Id { get; set; }
    }
}
