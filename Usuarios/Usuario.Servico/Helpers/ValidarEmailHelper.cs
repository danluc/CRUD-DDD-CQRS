using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Text;
using System.Text.RegularExpressions;

namespace Usuario.Servico.Helpers
{
    public static class ValidarEmailHelper
    {
        public static bool ValidarEmail(string email) => new EmailAddressAttribute().IsValid(email);
    }
}
