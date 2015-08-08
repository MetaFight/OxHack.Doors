using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Paxton.Net2.OemClientLibrary;

namespace OxHack.Doors.Net2Interop
{
	public class OemClientWrapper : IOemClient
	{
		private bool isDisposed = false;
		private readonly OemClient inner;

		public OemClientWrapper(string remotingHost, int remotingPort)
		{
			this.inner = new OemClient(remotingHost, remotingPort);
		}

		public IUsers ViewUserRecords()
		{
			return this.inner.ViewUserRecords();
		}

		public IUsers ViewUserRecords(string sqlWhereClause)
		{
			return this.inner.ViewUserRecords(sqlWhereClause);
		}

		public Dictionary<string, int> AuthenticateUser(int userIdent, string password)
		{
			return this.inner.AuthenticateUser(userIdent, password);
		}

		public List<int> ViewCards(int userId)
		{
			return this.inner.ViewCards(userId);
		}

		public bool AddCard(int cardNo, int cardTypeId, int userId)
		{
			return this.inner.AddCard(cardNo, cardTypeId, userId);
		}

		public bool DeleteCard(int cardNo)
		{
			return this.inner.DeleteCard(cardNo);
		}

		public IDepartments ViewDepartments()
		{
			return this.inner.ViewDepartments();
		}

		public bool AddUserRecord(int accessLevelId, int departmentId, bool antiPassbackInd, bool alarmUserInd, string firstName, string middleName, string surname, string telephoneNo, string telephoneExtension, string pinCode, string pictureFileName, DateTime activationDate, int cardNumber, int cardTypeId, bool active, string faxNo, DateTime expiryDate, string[] customFields)
		{
			return this.inner.AddUserRecord(accessLevelId, departmentId, antiPassbackInd, alarmUserInd, firstName, middleName, surname, telephoneNo, telephoneExtension, pinCode, pictureFileName, activationDate, cardNumber, cardTypeId, active, faxNo, expiryDate, customFields);
		}

		public bool UpdateUserRecord(int userId, int accessLevelId, int departmentId, bool antiPassbackInd, bool alarmUserInd, string firstName, string middleName, string surname, string telephoneNo, string telephoneExtension, string pinCode, string pictureFileName, DateTime activationDate, bool activeInd, string faxNo, DateTime expiryDate, string[] customFields)
		{
			return this.inner.UpdateUserRecord(userId, accessLevelId, departmentId, antiPassbackInd, alarmUserInd, firstName, middleName, surname, telephoneNo, telephoneExtension, pinCode, pictureFileName, activationDate, activeInd, faxNo, expiryDate, customFields);
		}

		public IEvents ViewEvents(int maxRowsReturned, DateTime startDate, DateTime endDate, string startTime, string endTime, bool accessEvents, bool infoEvents, bool alarmEvents, bool systemEvents, bool warningEvents, string firstName, string surname, string evnt, string evntDetail, string deviceName, int minEventID)
		{
			return this.inner.ViewEvents(maxRowsReturned, startDate, endDate, startTime, endTime, accessEvents, infoEvents, alarmEvents, systemEvents, warningEvents, firstName, surname, evnt, evntDetail, deviceName, minEventID);
		}

		public IOperators GetListOfOperators()
		{
			return this.inner.GetListOfOperators();
		}

		protected virtual void Dispose(bool disposing)
		{
			if (!this.isDisposed)
			{
				if (disposing)
				{
					this.inner.Dispose();
				}

				this.isDisposed = true;
			}
		}

		public void Dispose()
		{
			Dispose(true);
		}
	}
}
