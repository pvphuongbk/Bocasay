using Bocasay.Core.Commands;
using Bocasay.Data.Dto.User;
using Bocasay.Domain.Commands.User;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Bocasay.Domain.Commands.UserCommands
{
	public class CreatedUserCommand : ICommand<CreateUserResponse>
	{
		public CreateUserDto CreateUserDto { get; set; }
	}
}
