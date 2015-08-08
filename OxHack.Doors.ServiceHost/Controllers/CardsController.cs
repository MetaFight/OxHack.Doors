using Autofac.Integration.WebApi;
using OxHack.Doors.Common.Services;
using System.Collections.Generic;
using System.Threading.Tasks;
using System.Web.Http;

namespace OxHack.Doors.ServiceHost.Controllers
{
	//[Authorize]
	[AutofacControllerConfiguration]
	public class CardsController : ApiController
	{
		private readonly ICardService service;

		public CardsController(ICardService service)
		{
			this.service = service;
		}

		public async Task<IEnumerable<int>> Get([FromUri] int userId)
		{
			try
			{
				return await this.service.GetUserCards(userId);
			}
			catch
			{
				// TODO: return appropriate error, log error
				throw;
			}
		}

		public async Task Put([FromUri] int userId, [FromBody]IEnumerable<int> value)
		{
			try
			{
				await this.service.SetUserCards(userId, value);
			}
			catch
			{
				// TODO: return appropriate error, log error
				throw;
			}
		}

		//public void Post([FromBody]string value)
		//{
		//}

		//public void Delete(int id)
		//{
		//}
	}
}
