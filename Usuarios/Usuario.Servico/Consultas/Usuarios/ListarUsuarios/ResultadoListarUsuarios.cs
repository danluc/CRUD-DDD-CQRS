using System.Collections.Generic;
using Usuarios.Dominio.DTOs;
using Usuarios.Dominio.Global;

namespace Usuario.Servico.Consultas.Usuarios.ListarUsuarios
{
    public class ResultadoListarUsuarios : ResultadoController
    {
        public IEnumerable<UsuarioDTO> Usuarios { get; set; }
    }
}
