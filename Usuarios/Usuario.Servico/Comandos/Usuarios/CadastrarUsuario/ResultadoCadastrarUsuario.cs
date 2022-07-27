using System;
using System.Collections.Generic;
using System.Text;
using Usuarios.Dominio.DTOs;
using Usuarios.Dominio.Global;

namespace Usuario.Servico.Comandos.Usuarios.CadastrarUsuario
{
    public class ResultadoCadastrarUsuario : ResultadoController
    {
        public UsuarioDTO Usuario { get; set; }
    }
}
