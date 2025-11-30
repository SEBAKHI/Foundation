namespace Foundation_Lib.Constants;

/// <summary>
/// Common error codes shared across all United Education services and applications.
/// These codes are domain-agnostic and can be used by any microservice.
/// </summary>
public static class CommonErrorCodes
{
    // Validation Errors (2000-2999)
    /// <summary>General validation error</summary>
    public const string VALIDATION_ERROR = "VAL_2001";

    /// <summary>Invalid email format provided</summary>
    public const string INVALID_EMAIL_FORMAT = "VAL_2002";

    /// <summary>Password does not meet complexity requirements</summary>
    public const string WEAK_PASSWORD = "VAL_2003";

    /// <summary>Password and confirmation password do not match</summary>
    public const string PASSWORD_MISMATCH = "VAL_2004";

    /// <summary>A required field is missing in the request</summary>
    public const string REQUIRED_FIELD_MISSING = "VAL_2005";

    // Authorization Errors (3000-3999)
    /// <summary>User is not authenticated</summary>
    public const string UNAUTHORIZED = "AUTHZ_3001";

    /// <summary>User lacks permission to access this resource</summary>
    public const string FORBIDDEN = "AUTHZ_3002";

    /// <summary>User has insufficient permissions for this operation</summary>
    public const string INSUFFICIENT_PERMISSIONS = "AUTHZ_3003";

    // System Errors (5000-5999)
    /// <summary>Internal server error occurred</summary>
    public const string INTERNAL_SERVER_ERROR = "SYS_5001";

    /// <summary>Database operation failed</summary>
    public const string DATABASE_ERROR = "SYS_5002";

    /// <summary>Failed to send email</summary>
    public const string EMAIL_SEND_FAILED = "SYS_5003";

    /// <summary>External service call failed</summary>
    public const string EXTERNAL_SERVICE_ERROR = "SYS_5004";

    /// <summary>Resource not found</summary>
    public const string NOT_FOUND = "SYS_5005";

    /// <summary>Operation timed out</summary>
    public const string TIMEOUT = "SYS_5006";

    /// <summary>Service temporarily unavailable</summary>
    public const string SERVICE_UNAVAILABLE = "SYS_5007";
}
