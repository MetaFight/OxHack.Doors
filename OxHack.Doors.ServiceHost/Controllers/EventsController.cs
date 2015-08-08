using Autofac.Integration.WebApi;
using OxHack.Doors.Service;
using System;
using System.Linq;
using System.Collections.Generic;
using System.Threading.Tasks;
using System.Web.Http;
using OxHack.Doors.Common.Services;

namespace OxHack.Doors.ServiceHost.Controllers
{
	//[Authorize]
	[AutofacControllerConfiguration]
	public class EventsController : ApiController
	{
		private readonly IEventService service;

		public EventsController(IEventService service)
		{
			this.service = service;
		}

		public async Task<IEnumerable<dynamic>> Get(
			[FromUri] DateTime startTime,
			[FromUri] DateTime? endTime = null,
			[FromUri] int? maxResultCount = null)
		{
			try
			{
				var result = await this.service.GetEventsInDateRange(inclusiveStartTime: startTime, exclusiveEndTime: endTime, maxResultCount: maxResultCount);

				return result;
			}
			catch
			{
				// TODO: return appropriate error, log error
				throw;
			}
		}
	}
}
