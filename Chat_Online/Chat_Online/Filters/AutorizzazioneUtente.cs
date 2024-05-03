using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Filters;
using System.Net;

namespace Chat_Online.Filters
{
    public class AutorizzazioneUtente : Attribute, IAuthorizationFilter
    {

        private readonly string _userRequest;

        public AutorizzazioneUtente(string tipoUtente)
        {
            _userRequest = tipoUtente;
        }
        public void OnAuthorization(AuthorizationFilterContext context)
        {
            var claims = context.HttpContext.User.Claims;
            var userType = claims.FirstOrDefault(c => c.Type == "UserType")?.Value;

            if (userType == null || userType != _userRequest)
            {
                context.Result = new StatusCodeResult((int)HttpStatusCode.Forbidden);
            }
        }
    }
}
