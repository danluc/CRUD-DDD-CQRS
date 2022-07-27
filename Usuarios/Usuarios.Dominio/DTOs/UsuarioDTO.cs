using System;
using Usuarios.Dominio.Global.Enum;

namespace Usuarios.Dominio.DTOs
{
    public class UsuarioDTO
    {
        public int Id { get; set; }
        public string Nome { get; set; }
        public string Sobrenome { get; set; }
        public string Email { get; set; }
        public EscolaridadeEnum Escolaridade { get; set; }
        public string EscolaridadeDescricao { get; set; }
        public DateTime DataNascimento { get; set; }
    }
}
