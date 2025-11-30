namespace Foundation_Lib.Models;

/// <summary>
/// Interface for entities that track creation and modification metadata.
/// Provides audit trail capabilities for all entities across United Education systems.
/// </summary>
public interface IAuditableEntity
{
    /// <summary>
    /// Date and time when the entity was created (UTC)
    /// </summary>
    DateTime CreatedAt { get; set; }
    
    /// <summary>
    /// Date and time when the entity was last modified (UTC)
    /// </summary>
    DateTime? UpdatedAt { get; set; }
    
    /// <summary>
    /// User ID who created the entity
    /// </summary>
    Guid? CreatedBy { get; set; }
    
    /// <summary>
    /// User ID who last modified the entity
    /// </summary>
    Guid? UpdatedBy { get; set; }
}
