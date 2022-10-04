using Usuarios.Dominio.Contratos;

namespace Usuarios.Dominio.Models
{
    public class ModelBase : IEntity
    {
        public int Id { get; set; }
    }
}
