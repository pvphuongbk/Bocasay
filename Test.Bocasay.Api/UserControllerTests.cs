using Bocasay.Api.Controllers;
using Bocasay.Core.Base;
using Bocasay.Data.Dto.User;
using Bocasay.Domain.Commands.User;
using Bocasay.Service.Interface;
using FakeItEasy;
using System;
using System.Threading.Tasks;
using Xunit;

namespace Test.Bocasay.Api
{
	public class UserControllerTests
	{
		[Fact]
		public async Task Test_CreateUser()
		{
			// Mock
			CreateUserDto newUser = new CreateUserDto();
			var fakseRecipes = A.Fake<CreateUserResponse>();

			var dataService = A.Fake<IUserService>();
			A.CallTo(() => dataService.Create(newUser)).Returns(Task.FromResult(fakseRecipes));
			var userController = new UsersController(dataService);

			// Act
			var testResult = await userController.CreateUsers(newUser);

			// Assert
			Assert.Equal(fakseRecipes.Code, testResult.Code);
		}

		[Fact]
		public async Task Test_UpdateUser()
		{
			// Mock
			UpdateUserDto updateUser = new UpdateUserDto();
			var fakseRecipes = A.Fake<UpdateUserResponse>();

			var dataService = A.Fake<IUserService>();
			A.CallTo(() => dataService.Update(updateUser)).Returns(Task.FromResult(fakseRecipes));
			var userController = new UsersController(dataService);

			// Act
			var testResult = await userController.UpdateUser(updateUser);

			// Assert
			Assert.Equal(fakseRecipes.Code, testResult.Code);
		}

		[Fact]
		public async Task Test_GetUsers()
		{
			// Mock
			var fakseRecipes = A.Fake<ResponseBase>();

			var dataService = A.Fake<IUserService>();
			A.CallTo(() => dataService.GetAll()).Returns(Task.FromResult(fakseRecipes));
			var userController = new UsersController(dataService);

			// Act
			var testResult = await userController.GetUsers();

			// Assert
			Assert.Equal(fakseRecipes.Code, testResult.Code);
		}

		[Fact]
		public async Task Test_DeleteUser()
		{
			// Mock
			Guid userId = Guid.NewGuid();
			var fakseRecipes = A.Fake<DeleteUserResponse>();

			var dataService = A.Fake<IUserService>();
			A.CallTo(() => dataService.Delete(userId)).Returns(Task.FromResult(fakseRecipes));
			var userController = new UsersController(dataService);

			// Act
			var testResult = await userController.DeleteUser(userId);

			// Assert
			Assert.Equal(fakseRecipes.Code, testResult.Code);
		}

		[Fact]
		public async Task Test_Detail()
		{
			// Mock
			Guid userId = Guid.NewGuid();
			var fakseRecipes = A.Fake<ResponseBase>();

			var dataService = A.Fake<IUserService>();
			A.CallTo(() => dataService.GetDetail(userId)).Returns(Task.FromResult(fakseRecipes));
			var userController = new UsersController(dataService);

			// Act
			var testResult = await userController.GetUserDetail(userId);

			// Assert
			Assert.Equal(fakseRecipes.Code, testResult.Code);
		}
	}
}
