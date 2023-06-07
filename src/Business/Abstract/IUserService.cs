using DataAccess.Dtos;
using static Core.Models.BaseResponseModel;

namespace Business.Abstract
{
    public interface IUserService
    {
        public Task<ServiceResponse<UserLoginResponseDto>> InsertAsync(UserInsertDto userInsertDto);
    }
}
