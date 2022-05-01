using Bocasay.Core.Base;
using Bocasay.Data.Dto.User;
using Bocasay.Domain.Commands.User;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Bocasay.Service.Interface
{
	public interface IUserService : IBaseService
	{
		Task<CreateUserResponse> Create(CreateUserDto item);
		Task<ResponseBase> GetAll();
		Task<ResponseBase> GetDetail(Guid id);
		Task<UpdateUserResponse> Update(Guid userId, UpdateUserDto item);
		Task<DeleteUserResponse> Delete(Guid id);
	}
}
