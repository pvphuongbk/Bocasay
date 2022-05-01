using Bocasay.Data.Dto.Base;
using Bocasay.Data.Dto.User;
using Bocasay.Data.Redis.BaseDatabase;
namespace Bocasay.Data.Redis.Interface
{
    public interface IUserRepositoryRedis : IBaseRepositoryRedis<UserDto>
    {
    }
}
