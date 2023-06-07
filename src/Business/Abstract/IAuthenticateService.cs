using DataAccess.Dtos;
using static Core.Models.BaseResponseModel;

namespace Business.Abstract
{
    public interface IAuthenticationService
    {
        public Task<ServiceResponse<UserLoginResponseDto>> AuthenticateAsync(string username, string password);
    }
}
