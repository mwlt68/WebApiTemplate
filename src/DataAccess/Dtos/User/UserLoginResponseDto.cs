using Core.BaseModels.DtoModels;

namespace DataAccess.Dtos.User
{
    public class UserLoginResponseDto : BaseDto
    {
        public string Username { get; set; }
        public string Token { get; set; }
    }
}
