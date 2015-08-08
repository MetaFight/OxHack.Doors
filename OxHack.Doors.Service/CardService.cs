using OxHack.Doors.Common.Services;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OxHack.Doors.Service
{
	public class CardService : ICardService
	{
		private readonly IUserService userService;
		private readonly IDoorAccessService doorAccessService;

		public CardService(IUserService userService, IDoorAccessService doorAccessService)
		{
			this.userService = userService;
			this.doorAccessService = doorAccessService;
        }

		public async Task<IEnumerable<int>> GetUserCards(int userId)
		{
			IEnumerable<int> result = null;

			var user = await this.userService.GetUserById(userId);

			if (user != null)
			{
				result = user.Cards;
			}

			return result;
		}

		public async Task SetUserCards(int userId, IEnumerable<int> cards)
		{
			var user = await this.userService.GetUserById(userId);

			if (user == null)
			{
				throw new ArgumentException("userId");
			}

			var oldCards = user.Cards;
			var newCards = cards;

			var added = newCards.Except(oldCards);
			var removed = oldCards.Except(newCards);

			foreach (var cardNumber in added)
			{
				await this.userService.AssignCardToUser(userId, cardNumber);
			}

			foreach (var cardNumber in removed)
			{
				await this.userService.RemoveCardFromUser(userId, cardNumber);
			}
		}
	}
}
