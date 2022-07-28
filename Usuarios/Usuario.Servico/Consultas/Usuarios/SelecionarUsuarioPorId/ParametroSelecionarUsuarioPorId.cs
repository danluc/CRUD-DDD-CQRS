using MediatR;
using System;
using System.Collections.Generic;
using System.Text;

namespace Usuario.Servico.Consultas.Usuarios.SelecionarUsuarioPorId
{
    public class ParametroSelecionarUsuarioPorId : IRequest<ResultadoSelecionarUsuarioPorId>
    {
        public ParametroSelecionarUsuarioPorId(int id)
        {
            Id = id;
        }
        public int Id { get; set; }
    }
}
