using System.Linq;
using System.Threading.Tasks;

namespace MyStatusSoftware.Data.Repositories.IRepositories
{
    /// <summary>
    /// Nombre de la interfaz : IGenericRepository
    /// </summary>
    /// <typeparam name="T">Clase Generica</typeparam>
    public interface IGenericRepository<T> where T : class
    {
        /// <summary>
        /// Firma de metodo para consultar todos las entidades
        /// </summary>
        /// <returns></returns>
        IQueryable<T> GetAll();

        /// <summary>
        /// Firma de metodo para consultar una entidad por id
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        Task<T> GetByIdAsync(int id);

        /// <summary>
        /// Firma de metodo para crear una entidad
        /// </summary>
        /// <param name="entity"></param>
        /// <returns></returns>
        Task<T> CreateAsync(T entity);

        /// <summary>
        /// Firma de metodo para modificar una entidad
        /// </summary>
        /// <param name="entity"></param>
        /// <returns></returns>
        Task<T> UpdateAsync(T entity);

        /// <summary>
        /// Firma de metodo para eliminar una entidad
        /// </summary>
        /// <param name="entity"></param>
        /// <returns></returns>
        Task DeleteAsync(T entity);

        /// <summary>
        /// Metodo para saber si existe una entidad
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        Task<bool> ExistAsync(int id);
    }
}
