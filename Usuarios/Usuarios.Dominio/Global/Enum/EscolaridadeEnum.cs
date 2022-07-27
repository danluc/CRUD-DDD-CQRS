using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Text;

namespace Usuarios.Dominio.Global.Enum
{
    public enum EscolaridadeEnum
    {
        [Description("Infantil")]
        Infantil = 1,
        [Description("Fundamental")]
        Fundamental = 2,
        [Description("Médio")]
        Medio = 3,
        [Description("Superior")]
        Superior = 4,
    }
}
