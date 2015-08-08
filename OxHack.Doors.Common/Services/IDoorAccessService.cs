using OxHack.Doors.Common.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OxHack.Doors.Common.Services
{
	public interface IDoorAccessService
	{
		Task<IEnumerable<User>> GetUsers();
		Task<IEnumerable<User>> GetUsersByDepartment(string department);
		Task<User> GetUserById(int id);
		Task AssociateCardWithUser(int cardNumber, int userId);
		Task DisassociateCardFromUser(int cardNumber, int userId);
		Task CreateUser(User user);
		Task DeleteUser(int id);
		Task UpdateUser(User existingUser);
		Task<IEnumerable<dynamic>> GetEventsInDateRange(DateTime inclusiveStartTime, DateTime exclusiveEndTime, int? maxResultCount = null);
	}
}
