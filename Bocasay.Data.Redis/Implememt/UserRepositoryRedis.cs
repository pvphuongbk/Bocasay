using Bocasay.Data.Dto.User;
using Bocasay.Data.Redis.BaseDatabase;
using Bocasay.Data.Redis.Interface;
using Bocasay.Data.SqlServer.Etities;
using StackExchange.Redis;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Bocasay.Data.Redis.Implememt
{
    public class UserRepositoryRedis : BaseRepositoryRedis<UserDto>, IUserRepositoryRedis
    {

        public UserRepositoryRedis(IConnectionMultiplexer redisConnection, IDatabase database) : base(redisConnection, database, "UserDto") { }

    }
}
