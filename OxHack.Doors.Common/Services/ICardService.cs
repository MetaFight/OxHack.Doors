using System.Collections.Generic;
using System.Threading.Tasks;

namespace OxHack.Doors.Common.Services
{
	public interface ICardService
	{
		Task<IEnumerable<int>> GetUserCards(int userId);
		Task SetUserCards(int userId, IEnumerable<int> cards);
	}
}