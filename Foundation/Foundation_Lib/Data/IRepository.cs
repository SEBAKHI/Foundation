using System.Data;

namespace Foundation_Lib.Data;

public interface IRepository<T> where T : class
{
    /// <summary>
    /// Get entity by integer ID (for legacy systems)
    /// </summary>
    Task<T?> GetByIdAsync(int id, IDbConnection? connection = null);
    
    /// <summary>
    /// Get entity by GUID (standard for most United Education systems)
    /// </summary>
    Task<T?> GetByIdAsync(Guid id, IDbConnection? connection = null);
    
    /// <summary>
    /// Get entity by string ID
    /// </summary>
    Task<T?> GetByIdStringAsync(string id, IDbConnection? connection = null);
    
    Task<IEnumerable<T>> GetAllAsync(IDbConnection? connection = null);
    Task<int> AddAsync(T entity, IDbConnection? connection = null);
    Task<bool> UpdateAsync(T entity, IDbConnection? connection = null);
    
    /// <summary>
    /// Delete entity by integer ID (for legacy systems)
    /// </summary>
    Task<bool> DeleteAsync(int id, IDbConnection? connection = null);
    
    /// <summary>
    /// Delete entity by GUID (standard for most United Education systems)
    /// </summary>
    Task<bool> DeleteAsync(Guid id, IDbConnection? connection = null);
}
