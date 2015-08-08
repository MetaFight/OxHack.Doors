using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Serialization;
using System.Text;
using System.Threading.Tasks;

namespace OxHack.Doors.Service.Exceptions
{
	// TODO: double check this is the correct implementation pattern for a customer exception
	[Serializable]
	public class BusinessRuleException : Exception
	{
		public BusinessRuleException(string message)
			: base(message)
		{
		}

		public BusinessRuleException(string message, Exception innerException)
			: base(message, innerException)
		{
		}

		public BusinessRuleException(SerializationInfo info, StreamingContext context) :
			base(info, context)
		{
		}
	}
}
