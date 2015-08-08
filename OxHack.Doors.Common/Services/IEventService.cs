using System;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace OxHack.Doors.Common.Services
{
	public interface IEventService
	{
		Task<IEnumerable<dynamic>> GetEventsInDateRange(DateTime inclusiveStartTime, DateTime? exclusiveEndTime, int? maxResultCount);
	}
}