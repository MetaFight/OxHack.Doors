using System.Collections.Generic;
using System.Threading.Tasks;
using OxHack.Doors.Common.Models;

namespace OxHack.Doors.Common.Services
{
	public interface IUserService
	{
		Task AssignCardToUser(int userId, int cardNumber);
		Task CreateUser(User user);
		Task DeleteUser(int userId);
		Task<User> GetUserById(int id);
		Task<IEnumerable<User>> GetUsers();
		Task RemoveCardFromUser(int userId, int cardNumber);
		Task UpdateUser(User user);
	}
}