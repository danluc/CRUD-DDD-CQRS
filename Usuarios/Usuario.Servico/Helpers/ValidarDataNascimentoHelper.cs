using System;
using System.Collections.Generic;
using System.Text;

namespace Usuario.Servico.Helpers
{
    public static class ValidarDataNascimentoHelper
    {
        public static bool ValidarDataMaiorAtual(DateTime data)
        {
            return data.Date < DateTime.Now.Date;
        }
    }
}
