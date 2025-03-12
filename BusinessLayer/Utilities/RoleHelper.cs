using System.Security.Claims;

namespace BusinessLayer.Utilities
{
    public static class RoleHelper
    {
        public static int GetUserRole(ClaimsPrincipal? user)
        {
            if (user == null || !user.Identity.IsAuthenticated)
                return -1; // Not logged in

            var roleClaim = user.Claims.FirstOrDefault(c => c.Type == "AccountRole");

            if (roleClaim == null)
            {
                Console.WriteLine("Role claim not found! User is logged in but has no role.");
                return -1;
            }

            Console.WriteLine($"Role Found: {roleClaim.Value}");

            return int.TryParse(roleClaim.Value, out int role) ? role : -1;
        }
    }
}
