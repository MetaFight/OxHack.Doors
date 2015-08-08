using Paxton.Net2.OemClientLibrary;
using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OxHack.Doors.Net2Interop.Tests.Dummies
{
	internal class DummyUserView : IUserView
	{
		public string AccessLevel
		{
			get;
			set;
		}

		public int AccessLevelId
		{
			get;
			set;
		}

		public DateTime ActivationDate
		{
			get;
			set;
		}

		public bool Active
		{
			get;
			set;
		}

		public bool AlarmUser
		{
			get;
			set;
		}

		public bool AntiPassbackUser
		{
			get;
			set;
		}

		public string Department
		{
			get;
			set;
		}

		public int DepartmentId
		{
			get;
			set;
		}

		public string DisplayName
		{
			get;
			set;
		}

		public DateTime ExpiryDate
		{
			get;
			set;
		}

		public string Extension
		{
			get;
			set;
		}

		public string Fax
		{
			get;
			set;
		}

		public string Field10_50
		{
			get;
			set;
		}

		public string Field11_50
		{
			get;
			set;
		}

		public string Field12_50
		{
			get;
			set;
		}

		public string Field13_Memo
		{
			get;
			set;
		}

		public string Field14_50
		{
			get;
			set;
		}

		public string Field1_100
		{
			get;
			set;
		}

		public string Field2_100
		{
			get;
			set;
		}

		public string Field3_50
		{
			get;
			set;
		}

		public string Field4_50
		{
			get;
			set;
		}

		public string Field5_50
		{
			get;
			set;
		}

		public string Field6_50
		{
			get;
			set;
		}

		public string Field7_50
		{
			get;
			set;
		}

		public string Field8_50
		{
			get;
			set;
		}

		public string Field9_50
		{
			get;
			set;
		}

		public string FirstName
		{
			get;
			set;
		}

		public bool Global
		{
			get;
			set;
		}

		public DateTime LastAccessTime
		{
			get;
			set;
		}

		public string LastArea
		{
			get;
			set;
		}

		public int LastAreaId
		{
			get;
			set;
		}

		public DateTime LastUpdated
		{
			get;
			set;
		}

		public string MiddleName
		{
			get;
			set;
		}

		public string Picture
		{
			get;
			set;
		}

		public string PIN
		{
			get;
			set;
		}

		public string Surname
		{
			get;
			set;
		}

		public string Telephone
		{
			get;
			set;
		}

		public Guid UserGuid
		{
			get;
			set;
		}

		public int UserId
		{
			get;
			set;
		}

		public Image UserImage
		{
			get;
			set;
		}
	}
}
