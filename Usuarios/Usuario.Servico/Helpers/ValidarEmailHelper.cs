using System;
using System.Collections.Generic;
using System.Text;
using System.Text.RegularExpressions;

namespace Usuario.Servico.Helpers
{
    public static class ValidarEmailHelper
    {
        public static bool ValidarEmail(string email)
        {
            Regex rg = new Regex(@"^[A-Za-z0-9](([_\.\-]?[a-zA-Z0-9]+)*)@([A-Za-z0-9]+)(([\.\-]?[a-zA-Z0-9]+)*)\.([A-Za-z]{2,})$");
            return rg.IsMatch(email);
        }
    }
}
