using Core.Utilities.Responses;
using DataAccess.Dtos.User;

namespace Business.Abstract
{
    public interface IAuthenticationService
    {
        public Task<DataResponseModel<UserLoginResponseDto>> AuthenticateAsync(string username, string password);
    }
}
