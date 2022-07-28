using System;
using System.Collections.Generic;
using System.Text;
using Usuarios.Dominio.DTOs;
using Usuarios.Dominio.Global;

namespace Usuario.Servico.Consultas.Usuarios.SelecionarUsuarioPorId
{
    public class ResultadoSelecionarUsuarioPorId : ResultadoController
    {
        public UsuarioDTO Usuario { get; set; }
    }
}
