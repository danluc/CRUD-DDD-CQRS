using System;
using Usuarios.Dominio.DTOs;
using Usuarios.Dominio.Global.Enum;

namespace Usuario.Servico.Helpers
{
    public static class ValidarUsuarioHelper
    {
        public static void Validar(UsuarioDTO dados)
        {
            if (!ValidarDataNascimentoHelper.ValidarDataMaiorAtual(dados.DataNascimento))
                throw new Exception("Data nascimento não permitida!");

            if (!ValidarEmailHelper.ValidarEmail(dados.Email))
                throw new Exception("E-mail inválido!");

            if (!Enum.IsDefined(typeof(EscolaridadeEnum), dados.Escolaridade))
                throw new Exception("Escolaridade inválido!");
        }
    }
}
