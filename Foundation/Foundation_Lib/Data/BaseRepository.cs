using Dapper;
using Microsoft.Data.SqlClient;
using System.Data;

namespace Foundation_Lib.Data;

public abstract class BaseRepository<T> : IRepository<T> where T : class
{
    protected readonly string _connectionString;
    protected abstract string TableName { get; }
    
    /// <summary>
    /// The name of the primary key column in the database table.
    /// Default is "Id", but can be overridden (e.g., "Id_Num" for legacy systems)
    /// </summary>
    protected virtual string IdColumnName => "Id";

    protected BaseRepository(string connectionString)
    {
        _connectionString = connectionString ?? throw new ArgumentNullException(nameof(connectionString));
    }

    protected IDbConnection CreateConnection()
    {
        return new SqlConnection(_connectionString);
    }

    /// <summary>
    /// Execute a database operation with automatic connection management
    /// </summary>
    protected async Task<TResult> ExecuteWithConnectionAsync<TResult>(
        Func<IDbConnection, Task<TResult>> operation,
        IDbConnection? connection = null)
    {
        var shouldCloseConnection = connection == null;
        var conn = connection ?? CreateConnection();

        try
        {
            return await operation(conn);
        }
        finally
        {
            if (shouldCloseConnection)
            {
                conn?.Dispose();
            }
        }
    }

    /// <summary>
    /// Get entity by integer ID (for legacy systems using int primary keys)
    /// </summary>
    public virtual async Task<T?> GetByIdAsync(int id, IDbConnection? connection = null)
    {
        return await ExecuteWithConnectionAsync(async conn =>
        {
            var query = $"SELECT * FROM {TableName} WHERE {IdColumnName} = @Id";
            return await conn.QueryFirstOrDefaultAsync<T>(query, new { Id = id });
        }, connection);
    }

    /// <summary>
    /// Get entity by GUID (for modern systems using Guid primary keys)
    /// This is the default/standard method for most United Education systems
    /// </summary>
    public virtual async Task<T?> GetByIdAsync(Guid id, IDbConnection? connection = null)
    {
        return await ExecuteWithConnectionAsync(async conn =>
        {
            var query = $"SELECT * FROM {TableName} WHERE {IdColumnName} = @Id";
            return await conn.QueryFirstOrDefaultAsync<T>(query, new { Id = id });
        }, connection);
    }

    /// <summary>
    /// Get entity by string ID (for systems using string-based identifiers)
    /// </summary>
    public virtual async Task<T?> GetByIdStringAsync(string id, IDbConnection? connection = null)
    {
        return await ExecuteWithConnectionAsync(async conn =>
        {
            var query = $"SELECT * FROM {TableName} WHERE {IdColumnName} = @Id";
            return await conn.QueryFirstOrDefaultAsync<T>(query, new { Id = id });
        }, connection);
    }

    public virtual async Task<IEnumerable<T>> GetAllAsync(IDbConnection? connection = null)
    {
        return await ExecuteWithConnectionAsync(async conn =>
        {
            var query = $"SELECT * FROM {TableName}";
            return await conn.QueryAsync<T>(query);
        }, connection);
    }

    public abstract Task<int> AddAsync(T entity, IDbConnection? connection = null);

    public abstract Task<bool> UpdateAsync(T entity, IDbConnection? connection = null);

    /// <summary>
    /// Delete entity by integer ID (for legacy systems using int primary keys)
    /// </summary>
    public virtual async Task<bool> DeleteAsync(int id, IDbConnection? connection = null)
    {
        return await ExecuteWithConnectionAsync(async conn =>
        {
            var query = $"DELETE FROM {TableName} WHERE {IdColumnName} = @Id";
            var rowsAffected = await conn.ExecuteAsync(query, new { Id = id });
            return rowsAffected > 0;
        }, connection);
    }

    /// <summary>
    /// Delete entity by GUID (for modern systems using Guid primary keys)
    /// This is the default/standard method for most United Education systems
    /// </summary>
    public virtual async Task<bool> DeleteAsync(Guid id, IDbConnection? connection = null)
    {
        return await ExecuteWithConnectionAsync(async conn =>
        {
            var query = $"DELETE FROM {TableName} WHERE {IdColumnName} = @Id";
            var rowsAffected = await conn.ExecuteAsync(query, new { Id = id });
            return rowsAffected > 0;
        }, connection);
    }
}
