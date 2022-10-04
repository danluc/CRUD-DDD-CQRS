using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;

namespace Usuarios.Dominio.Contratos
{
    public interface IRepositorioConsulta<TEntidade> where TEntidade : class, IEntity
    {
        Task<TEntidade> FindById(int id, bool leitura = false, params string[] includes);
        Task<IEnumerable<TEntidade>> FindBy(Expression<Func<TEntidade, bool>> filtro, bool leitura = false, params string[] includes);
        Task<IEnumerable<TResult>> FindBy<TResult>(Expression<Func<TEntidade, TResult>> select, Expression<Func<TEntidade, bool>> filtro, bool leitura = false, params string[] includes);
        Task<TEntidade> FirstOrDefault(Expression<Func<TEntidade, bool>> filtro, bool leitura = false, params string[] includes);
        Task<TResult> FirstOrDefault<TResult>(Expression<Func<TEntidade, TResult>> select, Expression<Func<TEntidade, bool>> filtro, bool leitura = false, params string[] includes);
        Task<bool> Any(Expression<Func<TEntidade, bool>> filtro, params string[] includes);
        IQueryable<TEntidade> Query(bool leitura = false, params string[] includes);
        IQueryable<TEntidade> Query(Expression<Func<TEntidade, bool>> filtro, bool leitura = false, params string[] includes);
    }
}
