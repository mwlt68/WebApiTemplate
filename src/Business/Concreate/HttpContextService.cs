using System.Security.Claims;
using Business.Abstract;
using Core.Consts;
using Microsoft.AspNetCore.Http;

namespace Business.Concreate
{
    public class HttpContextService:IHttpContextService
    {
        private readonly IHttpContextAccessor contextAccessor;
        public HttpContextService(IHttpContextAccessor contextAccessor)
        {
            this.contextAccessor = contextAccessor;
        }
        public int GetUserIdFromClaims()
        {
            var userId = contextAccessor?.HttpContext?.User.Claims.FirstOrDefault(x => x.Type == ClaimConsts.UserIdClaim)?.Value;
            if (userId == null)
                throw new KeyNotFoundException("User Not Found !");
            else return Int32.Parse(userId);
        }
    }
}