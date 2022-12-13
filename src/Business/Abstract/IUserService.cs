using Core.Utilities.Responses;
using DataAccess.Dtos;

namespace Business.Abstract
{
    public interface IUserService
    {
        public Task<DataResponseModel<UserLoginResponseDto>> InsertAsync(UserInsertDto userInsertDto);
    }
}
