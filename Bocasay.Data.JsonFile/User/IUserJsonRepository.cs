using Bocasay.Data.Dto.User;
using Bocasay.Data.JsonFile.Base;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Bocasay.Data.JsonFile.User
{
	public interface IUserJsonRepository : IJsonBase<UserDto>
	{
	}
}
