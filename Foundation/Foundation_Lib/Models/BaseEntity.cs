namespace Foundation_Lib.Models;

/// <summary>
/// Base abstract class for entities with audit tracking.
/// Automatically tracks creation and modification timestamps and user IDs.
/// </summary>
public abstract class BaseEntity : IAuditableEntity
{
    /// <summary>
    /// Date and time when the entity was created (UTC)
    /// </summary>
    public DateTime CreatedAt { get; set; } = DateTime.UtcNow;
    
    /// <summary>
    /// Date and time when the entity was last modified (UTC)
    /// </summary>
    public DateTime? UpdatedAt { get; set; }
    
    /// <summary>
    /// User ID who created the entity
    /// </summary>
    public Guid? CreatedBy { get; set; }
    
    /// <summary>
    /// User ID who last modified the entity
    /// </summary>
    public Guid? UpdatedBy { get; set; }
}
