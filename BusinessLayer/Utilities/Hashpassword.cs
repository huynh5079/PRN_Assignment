using System.Security.Cryptography;
using System.Text;

namespace BusinessLayer.Utilities
{
    public static class PasswordHasher
    {
        public static string HashPassword(string password)
        {
            using var sha256 = SHA256.Create();
            byte[] hashBytes = sha256.ComputeHash(Encoding.UTF8.GetBytes(password));

            // Convert to lowercase hex string
            return BitConverter.ToString(hashBytes).Replace("-", "").ToLower();
        }
    }
}
