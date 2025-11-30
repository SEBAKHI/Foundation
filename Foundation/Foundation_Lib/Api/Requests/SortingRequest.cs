namespace Foundation_Lib.Api.Requests;

public class SortingRequest
{
    public string? SortBy { get; set; }
    public bool SortDescending { get; set; } = false;

    public string GetOrderByClause(Dictionary<string, string> allowedSortFields)
    {
        if (string.IsNullOrWhiteSpace(SortBy) || !allowedSortFields.ContainsKey(SortBy))
        {
            return string.Empty;
        }

        var columnName = allowedSortFields[SortBy];
        return $"ORDER BY {columnName} {(SortDescending ? "DESC" : "ASC")}";
    }
}
