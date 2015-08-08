using OxHack.Doors.Common.Models;
using OxHack.Doors.Common.Services;
using OxHack.Doors.Service.Exceptions;
using System;
using System.Collections.Generic;
using System.Configuration;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OxHack.Doors.Service
{
	public class UserService : IUserService
	{
		private readonly string oxhackDepartmentName;
		private readonly IDoorAccessService doorAccessService;

		public UserService(IDoorAccessService doorAccessService)
		{
			this.doorAccessService = doorAccessService;

			this.oxhackDepartmentName = ConfigurationManager.AppSettings["oxhackDepartmentName"];
			if (String.IsNullOrWhiteSpace(this.oxhackDepartmentName))
			{
				throw new ConfigurationErrorsException("App setting 'oxhackDepartmentName' must be specified.");
			}
		}

		public async Task<IEnumerable<User>> GetUsers()
		{
			return await this.doorAccessService.GetUsersByDepartment(this.oxhackDepartmentName);
		}

		public async Task<User> GetUserById(int id)
		{
			return await this.GetUserByIdInner(id);
		}

		private async Task<User> GetUserByIdInner(int id)
		{
			User result = null;

			var match = await this.doorAccessService.GetUserById(id);

			if (match != null && match.Department == this.oxhackDepartmentName)
			{
				result = match;
			}

			return result;
		}

		public async Task DeleteUser(int userId)
		{
			var user = await this.doorAccessService.GetUserById(userId);

			if (user == null)
			{
				throw new InvalidOperationException("Could not find User with Id " + userId);
			}

			if (user.Cards.Any())
			{
				throw new BusinessRuleException("Deleting a User is not permitted if the user still has Cards.");
			}

			await this.doorAccessService.DeleteUser(userId);
		}

		public async Task UpdateUser(User user)
		{
			var existingUser = await this.GetUserByIdInner(user.Id);

			if (existingUser == null)
			{
				throw new ArgumentException("Could not locate User with Id " + user.Id);
			}

			UserService.MergeUserInstances(sourceUser: user, targetUser: existingUser);

			await this.doorAccessService.UpdateUser(existingUser);
		}

		private static void MergeUserInstances(User sourceUser, User targetUser)
		{
			targetUser.FirstName = sourceUser.FirstName ?? targetUser.FirstName;
			targetUser.Surname = sourceUser.Surname ?? targetUser.Surname;
			targetUser.Cards = sourceUser.Cards ?? targetUser.Cards;
		}

		public async Task AssignCardToUser(int userId, int cardNumber)
		{
			await this.doorAccessService.AssociateCardWithUser(cardNumber, userId);
		}

		public async Task RemoveCardFromUser(int userId, int cardNumber)
		{
			await this.doorAccessService.DisassociateCardFromUser(cardNumber, userId);
		}

		public async Task CreateUser(User user)
		{
			if (String.IsNullOrWhiteSpace(user.FirstName) && String.IsNullOrWhiteSpace(user.Surname))
			{
				throw new BusinessRuleException("User must have at least a FirstName or a Surname.");
			}

			user.Department = this.oxhackDepartmentName;

			await this.doorAccessService.CreateUser(user);
		}
	}
}
