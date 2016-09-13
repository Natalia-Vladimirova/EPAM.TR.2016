using System;
using System.Web;

namespace ToDoClient.Services
{
    public static class CookieService
    {
        public static string GetUserIdFromCookie()
        {
            return HttpContext.Current.Request.Cookies["user"]?.Value;
        }

        public static void SaveUserIdInCookie(int userId)
        {
            // Store the user in a cookie for later access
            var cookie = new HttpCookie("user", userId.ToString())
            {
                Expires = DateTime.Today.AddMonths(1)
            };

            HttpContext.Current.Response.SetCookie(cookie);
        }
    }
}