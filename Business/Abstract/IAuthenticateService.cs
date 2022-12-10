using Core.Utilities.Responses;
using DataAccess.Dtos;

namespace Business.Abstract
{
    public interface IAuthenticationService
    {
        public Task<BaseResponseModel<UserLoginResponseDto>> AuthenticateAsync(string username, string password);
    }
}
