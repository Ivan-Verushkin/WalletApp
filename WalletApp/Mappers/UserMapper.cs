using WalletAppApi.Dtos;
using WalletAppApi.Models;

namespace WalletAppApi.Mappers
{
    public static class UserMapper
    {
        public static UserDto ToUserDto (this User user)
        {
            return new UserDto
            {
                UserId = user.Id,
                Email = user.Email,
                UserName = user.UserName,
                Created = user.Created,
            };
        }
    }
}
