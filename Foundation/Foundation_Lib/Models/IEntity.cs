namespace Foundation_Lib.Models;

/// <summary>
/// Interface for entities with both numeric and string identifiers.
/// Used in systems where legacy numeric IDs are maintained alongside string-based IDs.
/// </summary>
public interface IEntity
{
    /// <summary>
    /// Numeric identifier (legacy support)
    /// </summary>
    int Id_Num { get; }
    
    /// <summary>
    /// String-based identifier
    /// </summary>
    string Id { get; }
}
