using Bocasay.Core.Base;
using Bocasay.Data.Dto.User;
using Bocasay.Domain.Commands.User;
using Bocasay.Service.Interface;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Bocasay.Api.Controllers
{
	[ApiController]
	[Route("api/[controller]")]
	public class UsersController : ControllerBase
	{
		private IUserService _userService;

		public UsersController(IUserService userService)
		{
			_userService = userService;
		}

		[HttpGet]
		public async Task<ResponseBase> GetUsers()
		{
			var users = await _userService.GetAll();

			return users;
		}

		[HttpGet("{id}")]
		public async Task<ResponseBase> GetUserDetail(Guid id)
		{
			var users = await _userService.GetDetail(id);

			return users;
		}

		[HttpPost]
		public async Task<CreateUserResponse> CreateUsers([FromBody] CreateUserDto createUserDto)
		{
			var users = await _userService.Create(createUserDto);

			return users;
		}

		[HttpPut("{id}")]
		public async Task<UpdateUserResponse> UpdateUser(Guid id, [FromBody] UpdateUserDto createUserDto)
		{
			var users = await _userService.Update(id, createUserDto);

			return users;
		}

		[HttpDelete("{id}")]
		public async Task<DeleteUserResponse> DeleteUser(Guid id)
		{
			var users = await _userService.Delete(id);

			return users;
		}
	}
}