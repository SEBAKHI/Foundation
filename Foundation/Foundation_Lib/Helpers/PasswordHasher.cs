namespace Foundation_Lib.Helpers;

public static class PasswordHasher
{
    /// <summary>
    /// Hashes a password using BCrypt
    /// </summary>
    public static string HashPassword(string password)
    {
        return BCrypt.Net.BCrypt.HashPassword(password, BCrypt.Net.BCrypt.GenerateSalt(12));
    }

    /// <summary>
    /// Verifies a password against a hash
    /// </summary>
    public static bool VerifyPassword(string password, string passwordHash)
    {
        try
        {
            return BCrypt.Net.BCrypt.Verify(password, passwordHash);
        }
        catch
        {
            return false;
        }
    }

    /// <summary>
    /// Generates a random 6-digit OTP
    /// </summary>
    public static string GenerateOtp()
    {
        return Random.Shared.Next(100000, 999999).ToString();
    }

    /// <summary>
    /// Generates a secure random token
    /// </summary>
    public static string GenerateSecureToken()
    {
        return Convert.ToBase64String(Guid.NewGuid().ToByteArray()) +
          Convert.ToBase64String(Guid.NewGuid().ToByteArray());
    }
}
