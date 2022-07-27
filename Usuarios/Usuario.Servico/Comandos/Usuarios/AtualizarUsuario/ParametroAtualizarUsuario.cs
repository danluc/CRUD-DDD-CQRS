using MediatR;
using System;
using System.Collections.Generic;
using System.Text;
using Usuarios.Dominio.DTOs;

namespace Usuario.Servico.Comandos.Usuarios.AtualizarUsuario
{
    public class ParametroAtualizarUsuario : IRequest<ResultadoAtualizarUsuario>
    {
        public ParametroAtualizarUsuario(UsuarioDTO dados, int id)
        {
            Dados = dados;
            Id = id;
        }
        public UsuarioDTO Dados { get; set; }
        public int Id { get; set; }
    }
}
