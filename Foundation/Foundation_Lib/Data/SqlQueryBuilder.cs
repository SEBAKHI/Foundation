using System.Text;

namespace Foundation_Lib.Data;

public class SqlQueryBuilder
{
    private readonly StringBuilder _query;
    private readonly List<string> _whereClauses;
    private readonly Dictionary<string, object> _parameters;

    public SqlQueryBuilder()
    {
        _query = new StringBuilder();
        _whereClauses = new List<string>();
        _parameters = new Dictionary<string, object>();
    }

    public SqlQueryBuilder Select(string columns, string tableName)
    {
        _query.Append($"SELECT {columns} FROM {tableName}");
        return this;
    }

    public SqlQueryBuilder Where(string condition, object? value = null, string? parameterName = null)
    {
        _whereClauses.Add(condition);
        if (value != null && parameterName != null)
        {
            _parameters[parameterName] = value;
        }
        return this;
    }

    public SqlQueryBuilder AndWhere(string condition, object? value = null, string? parameterName = null)
    {
        return Where(condition, value, parameterName);
    }

    public SqlQueryBuilder OrderBy(string orderClause)
    {
        if (!string.IsNullOrWhiteSpace(orderClause))
        {
            _query.Append($" {orderClause}");
        }
        return this;
    }

    public SqlQueryBuilder Pagination(int skip, int take)
    {
        _query.Append($" OFFSET {skip} ROWS FETCH NEXT {take} ROWS ONLY");
        return this;
    }

    public string Build()
    {
        if (_whereClauses.Any())
        {
            _query.Append($" WHERE {string.Join(" AND ", _whereClauses)}");
        }
        return _query.ToString();
    }

    public Dictionary<string, object> GetParameters() => _parameters;
}
