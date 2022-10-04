using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using Usuarios.Dominio.Global.Enum;

namespace Usuarios.Dominio.DTOs
{
    public class UsuarioDTO : IValidatableObject
    {
        public int Id { get; set; }
        public string Nome { get; set; }
        public string Sobrenome { get; set; }
        public string Email { get; set; }
        public EscolaridadeEnum Escolaridade { get; set; }
        public string EscolaridadeDescricao { get; set; }
        public DateTime DataNascimento { get; set; }

        public IEnumerable<ValidationResult> Validate(ValidationContext validationContext)
        {
            if (string.IsNullOrEmpty(this.Nome))
                yield return new ValidationResult("O nome é obrigatório.", new[] { "erro" });

            if (string.IsNullOrEmpty(this.Email))
                yield return new ValidationResult("O E-mail é obrigatório.", new[] { "erro" });

            if (this.DataNascimento < DateTime.Now.Date)
                yield return new ValidationResult("Data nascimento não permitida.", new[] { "erro" });
            
            if (new EmailAddressAttribute().IsValid(this.Email))
                yield return new ValidationResult("E-mail inválido.", new[] { "erro" });
            
            if (!Enum.IsDefined(typeof(EscolaridadeEnum), this.Escolaridade))
                yield return new ValidationResult("Escolaridade inválida.", new[] { "erro" });
        }
    }
}
