using OxHack.Doors.Common.Services;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OxHack.Doors.Service
{
	public class EventService : IEventService
	{
		private readonly IDoorAccessService doorAccessService;

		public EventService(IDoorAccessService doorAccessService)
		{
			this.doorAccessService = doorAccessService;
        }

		public async Task<IEnumerable<dynamic>> GetEventsInDateRange(DateTime inclusiveStartTime, DateTime? exclusiveEndTime, int? maxResultCount)
		{
			return await
				this.doorAccessService.GetEventsInDateRange(
					inclusiveStartTime,
					exclusiveEndTime ?? DateTime.Now,
					maxResultCount);
		}
	}
}
