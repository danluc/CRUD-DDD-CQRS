using MediatR;
using System;
using System.Collections.Generic;
using System.Text;
using Usuarios.Dominio.DTOs;

namespace Usuario.Servico.Comandos.Usuarios.CadastrarUsuario
{
    public class ParametroCadastrarUsuario : IRequest<ResultadoCadastrarUsuario>
    {
        public ParametroCadastrarUsuario(UsuarioDTO dados)
        {
            Dados = dados;
        }
        public UsuarioDTO Dados { get; set; }
    }
}
