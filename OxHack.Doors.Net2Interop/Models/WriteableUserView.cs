using Paxton.Net2.OemClientLibrary;
using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OxHack.Doors.Net2Interop.Models
{
	internal class WriteableUserView : IUserView
	{
		public WriteableUserView(IUserView readonlyUserView)
		{
			this.AccessLevel = readonlyUserView.AccessLevel;
			this.AccessLevelId = readonlyUserView.AccessLevelId;
			this.ActivationDate = readonlyUserView.ActivationDate;
			this.Active = readonlyUserView.Active;
			this.AlarmUser = readonlyUserView.AlarmUser;
			this.AntiPassbackUser = readonlyUserView.AntiPassbackUser;
			this.Department = readonlyUserView.Department;
			this.DepartmentId = readonlyUserView.DepartmentId;
			this.DisplayName = readonlyUserView.DisplayName;
			this.ExpiryDate = readonlyUserView.ExpiryDate;
			this.Extension = readonlyUserView.Extension;
			this.Fax = readonlyUserView.Fax;
			this.Field10_50 = readonlyUserView.Field10_50;
			this.Field11_50 = readonlyUserView.Field11_50;
			this.Field12_50 = readonlyUserView.Field12_50;
			this.Field13_Memo = readonlyUserView.Field13_Memo;
			this.Field14_50 = readonlyUserView.Field14_50;
			this.Field1_100 = readonlyUserView.Field1_100;
			this.Field2_100 = readonlyUserView.Field2_100;
			this.Field3_50 = readonlyUserView.Field3_50;
			this.Field4_50 = readonlyUserView.Field4_50;
			this.Field5_50 = readonlyUserView.Field5_50;
			this.Field6_50 = readonlyUserView.Field6_50;
			this.Field7_50 = readonlyUserView.Field7_50;
			this.Field8_50 = readonlyUserView.Field8_50;
			this.Field9_50 = readonlyUserView.Field9_50;
			this.FirstName = readonlyUserView.FirstName;
			this.Global = readonlyUserView.Global;
			this.LastAccessTime = readonlyUserView.LastAccessTime;
			this.LastArea = readonlyUserView.LastArea;
			this.LastAreaId = readonlyUserView.LastAreaId;
			this.LastUpdated = readonlyUserView.LastUpdated;
			this.MiddleName = readonlyUserView.MiddleName;
			this.Picture = readonlyUserView.Picture;
			this.PIN = readonlyUserView.PIN;
			this.Surname = readonlyUserView.Surname;
			this.Telephone = readonlyUserView.Telephone;
			this.UserGuid = readonlyUserView.UserGuid;
			this.UserId = readonlyUserView.UserId;
			this.UserImage = readonlyUserView.UserImage;
		}

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
