using MyStatusSoftware.Common.Enums;
using MyStatusSoftware.WebAdministrator.Models.Users;
using System;
using System.Security.Claims;

namespace MyStatusSoftware.WebAdministrator.Extensions
{
    public static class ClaimsPrincipalExtension
    {
        public static CurrentUserViewModel GetCurrentUser(this ClaimsPrincipal claimsPrincipal)
        {
            CurrentUserViewModel result = new CurrentUserViewModel
            {
                Email = claimsPrincipal.FindFirstValue(ClaimTypes.Email),
                FirstName = claimsPrincipal.FindFirstValue(ClaimTypes.GivenName),
                LastName = claimsPrincipal.FindFirstValue(ClaimTypes.Surname),
                Id = Convert.ToInt32(claimsPrincipal.FindFirstValue(ClaimTypes.NameIdentifier)),
                UserType = EnumHelper.GetStringValueEnumUserType(EnumHelper.GetEnumValue<UserType>(claimsPrincipal.FindFirstValue(ClaimTypes.Role)))
            };
            return result;
        }
    }

}
