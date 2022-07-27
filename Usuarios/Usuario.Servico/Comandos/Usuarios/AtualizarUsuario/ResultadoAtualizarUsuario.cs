using System;
using System.Collections.Generic;
using System.Text;
using Usuarios.Dominio.DTOs;
using Usuarios.Dominio.Global;

namespace Usuario.Servico.Comandos.Usuarios.AtualizarUsuario
{
    public class ResultadoAtualizarUsuario : ResultadoController
    {
        public UsuarioDTO Usuario { get; set; }
    }
}
