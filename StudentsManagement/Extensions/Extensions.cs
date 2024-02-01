using System.Security.Claims;

namespace StudentsManagement.Extensions
{
    public static partial class ExtensionsServices
    {
        private static IHttpContextAccessor _httpContextAccessor;

        public static  void SetHttpContextAcessor(this IHttpContextAccessor httpContextAccessor) 
        { 
             _httpContextAccessor = httpContextAccessor;
        }

        public static string GetUserId(this ClaimsPrincipal user)
        {
            if (!user.Identity.IsAuthenticated)
                return null;

                    ClaimsPrincipal currentuser  = user;
            return currentuser.FindFirst(ClaimTypes.NameIdentifier).Value;
        }

        public static string GetDisplayName(this ClaimsPrincipal user)
        {
            if (!user.Identity.IsAuthenticated)
                return null;

            ClaimsPrincipal currentuser = user;
            var fullname = currentuser.FindFirstValue("FullName");

            return fullname;
        }
    }
}
