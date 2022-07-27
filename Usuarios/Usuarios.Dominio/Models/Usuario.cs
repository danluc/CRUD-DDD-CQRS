using System;
using Usuarios.Dominio.Global.Enum;

namespace Usuarios.Dominio.Models
{
    public class Usuario : ModelBase
    {
        public string Nome { get; set; }
        public string Sobrenome { get; set; }
        public string Email { get; set; }
        public EscolaridadeEnum Escolaridade { get; set; }
        public DateTime DataNascimento { get; set; }
    }
}
