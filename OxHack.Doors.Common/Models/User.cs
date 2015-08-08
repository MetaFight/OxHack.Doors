using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Serialization;
using System.Text;
using System.Threading.Tasks;

namespace OxHack.Doors.Common.Models
{
	public class User
	{
		public User()
		{
		}

		public int Id
		{
			get;
			set;
		}

		public string FirstName
		{
			get;
			set;
		}

		public string Surname
		{
			get;
			set;
		}

		public string Department
		{
			get;
			set;
		}

		public IEnumerable<int> Cards
		{
			get;
			set;
		}
	}
}
