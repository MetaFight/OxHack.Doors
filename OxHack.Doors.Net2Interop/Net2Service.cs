using OxHack.Doors.Common.Services;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using OxHack.Doors.Common.Models;
using Paxton.Net2.OemClientLibrary;
using System.Configuration;
using OxHack.Doors.Net2Interop.Models;
using System.Globalization;

namespace OxHack.Doors.Net2Interop
{
	public class Net2Service : IDoorAccessService
	{
		private readonly int net2OperatorId;
		private readonly string net2OperatorPassword;
		private readonly int net2OxHackAccessLevelId;
		private readonly Func<IOemClient> clientFactory;

		public Net2Service(Func<IOemClient> clientFactory)
		{
			this.clientFactory = clientFactory;
			Net2Service.LoadConfiguration(out this.net2OperatorId, out this.net2OperatorPassword, out this.net2OxHackAccessLevelId);
		}

		private static void LoadConfiguration(out int net2OperatorId, out string net2OperatorPassword, out int net2OxHackAccessLevelId)
		{
			if (!Int32.TryParse(ConfigurationManager.AppSettings["net2OperatorId"], out net2OperatorId))
			{
				throw new ConfigurationErrorsException("App setting 'net2OperatorId' must be specified.");
			}

			net2OperatorPassword = ConfigurationManager.AppSettings["net2OperatorPassword"];
			if (String.IsNullOrWhiteSpace(net2OperatorPassword))
			{
				throw new ConfigurationErrorsException("App setting 'net2OperatorPassword' must be specified.");
			}

			if (!Int32.TryParse(ConfigurationManager.AppSettings["net2OxHackAccessLevelId"], out net2OxHackAccessLevelId))
			{
				throw new ConfigurationErrorsException("App setting 'net2OxHackAccessLevelId' must be specified.");
			}
		}

		private IOemClient GetNewClient()
		{
			var client = this.clientFactory();

			//var operatorsResult = client.GetListOfOperators();
			//if (operatorsResult != null)
			//{
			//	var operators = operatorsResult.UsersDictionary();
			//}
			//else
			//{
			//	throw new InvalidOperationException("Unable to fetch list of Net2 Operators.");
			//}

			var authenticationResult = client.AuthenticateUser(net2OperatorId, net2OperatorPassword);

			if (authenticationResult == null)
			{
				throw new InvalidOperationException("Unable to authenticate with Net2 service.");
			}

			return client;
		}

		public async Task<IEnumerable<User>> GetUsers()
		{
			var users = await Task.Run(() =>
			{
				try
				{
					using (var client = this.GetNewClient())
					{
						var result = this.GetUsersInner(client);

						return result;
					}
				}
				catch (Exception e)
				{
					// TODO: log here
					// TODO: wrap and rethrow exception
					throw;
				}
			});

			return users;
		}

		public async Task<IEnumerable<User>> GetUsersByDepartment(string department)
		{
			var users = await Task.Run(() =>
			{
				try
				{
					using (var client = this.GetNewClient())
					{
						//var result = this.GetUsersInner(client, item => item.Department == department);
						var result = this.GetUsersInner(client, "DepartmentName = '" + department + "'");
						return result;
					}
				}
				catch (Exception e)
				{
					// TODO: log here
					throw;
				}
			});

			return users;
		}

		public async Task<User> GetUserById(int id)
		{
			var user = await Task.Run(() =>
			{
				try
				{
					using (var client = this.GetNewClient())
					{
						//var match = this.GetUsersInner(client, item => item.UserId == id).SingleOrDefault();
						var match = this.GetUsersInner(client, "UserId = " + id).SingleOrDefault();
						return match;
					}
				}
				catch (Exception e)
				{
					// TODO: log here
					// TODO: wrap and rethrow exception
					throw;
				}
			});

			return user;
		}

		public async Task AssociateCardWithUser(int cardNumber, int userId)
		{
			await Task.Run(() =>
			{
				try
				{
					using (var client = this.GetNewClient())
					{
						var result = client.AddCard(cardNumber, 0, userId);

						if (!result)
						{
							throw new InvalidOperationException("AddCard returned false.  This might mean the operation didn't complete correctly.");
						}
					}
				}
				catch (Exception e)
				{
					// TODO: log here
					// TODO: wrap and rethrow exception
					throw;
				}
			});
		}

		public async Task DisassociateCardFromUser(int cardNumber, int userId)
		{
			await Task.Run(() =>
			{
				try
				{
					using (var client = this.GetNewClient())
					{
						var result = client.DeleteCard(cardNumber);

						if (!result)
						{
							throw new InvalidOperationException("DeleteCard returned false.  This might mean the operation didn't complete correctly.");
						}
					}
				}
				catch (Exception e)
				{
					// TODO: log here
					// TODO: wrap and rethrow exception
					throw;
				}
			});
		}

		public async Task CreateUser(User user)
		{
			await Task.Run(() =>
			{
				try
				{
					using (var client = this.GetNewClient())
					{
						var departmentsById = client.ViewDepartments().DepartmentsDictionary();
						var departmentMatches = departmentsById.Where(pair => pair.Value == user.Department);

						if (departmentMatches.Count() != 1)
						{
							throw new InvalidOperationException("Could not find user's department " + user.Department);
						}

						var operationResult =
							client.AddUserRecord(
								accessLevelId: this.net2OxHackAccessLevelId,
								departmentId: departmentMatches.Single().Key,
								antiPassbackInd: false,
								alarmUserInd: false,
								firstName: (user.FirstName ?? String.Empty).Trim(),
								middleName: String.Empty,
								surname: (user.Surname ?? String.Empty).Trim(),
								telephoneNo: String.Empty,
								telephoneExtension: String.Empty,
								pinCode: String.Empty,
								pictureFileName: String.Empty,
								activationDate: DateTime.Now,
								cardNumber: 0,
								cardTypeId: 0,
								active: true,
								faxNo: String.Empty,
								expiryDate: DateTime.MinValue,
								customFields: null);

						if (!operationResult)
						{
							throw new InvalidOperationException("AddUserRecord returned false.  This might mean the operation didn't complete correctly.");
						}
					}
				}
				catch (Exception e)
				{
					// TODO: log here
					// TODO: wrap and rethrow exception
					throw;
				}
			});
		}

		public async Task DeleteUser(int userId)
		{
			await Task.Run(() =>
			{
				try
				{
					using (var client = this.GetNewClient())
					{
						//var existingUserView = this.GetUserViews(client, item => item.UserId == userId).SingleOrDefault();
						var existingUserView = this.GetUserViews(client, "UserId = " + userId).SingleOrDefault();

						if (existingUserView == null)
						{
							throw new ArgumentException("Could not find User with Id " + userId);
						}

						var writeableUserView = new WriteableUserView(existingUserView);
						writeableUserView.Active = false;

						bool operationResult = this.UpdateUserView(client, writeableUserView);

						if (!operationResult)
						{
							throw new InvalidOperationException("UpdateUserRecord returned false.  This might mean the operation didn't complete correctly.");
						}
					}
				}
				catch (Exception e)
				{
					// TODO: log here
					// TODO: wrap and rethrow exception
					throw;
				}
			});
		}

		public async Task UpdateUser(User existingUser)
		{
			await Task.Run(() =>
			{
				try
				{
					using (var client = this.GetNewClient())
					{
						var userId = existingUser.Id;
						//var existingUserView = this.GetUserViews(client, item => item.UserId == userId).SingleOrDefault();
						var existingUserView = this.GetUserViews(client, "UserId = " + userId).SingleOrDefault();

						if (existingUserView == null)
						{
							throw new ArgumentException("Could not find User with Id " + userId);
						}

						var writeableUserView = new WriteableUserView(existingUserView);
						writeableUserView.FirstName = existingUser.FirstName;
						writeableUserView.Surname = existingUser.Surname;

						bool operationResult = this.UpdateUserView(client, writeableUserView);

						if (!operationResult)
						{
							throw new InvalidOperationException("UpdateUserRecord returned false.  This might mean the operation didn't complete correctly.");
						}
					}
				}
				catch (Exception e)
				{
					// TODO: log here
					// TODO: wrap and rethrow exception
					throw;
				}
			});
		}

		public async Task<IEnumerable<dynamic>> GetEventsInDateRange(DateTime inclusiveStartTime, DateTime exclusiveEndTime, int? maxResultCount = null)
		{
			var events = await Task.Run(() =>
			{
				try
				{
					using (var client = this.GetNewClient())
					{
						var eventsView =
							client.ViewEvents(
								maxResultCount ?? Int32.MaxValue,
								inclusiveStartTime,
								exclusiveEndTime,
								inclusiveStartTime.ToString("T", CultureInfo.InvariantCulture),
								exclusiveEndTime.ToString("T", CultureInfo.InvariantCulture),
								true, true, true, true, true,
								String.Empty, String.Empty, String.Empty, String.Empty, String.Empty,
								0);

						var result = eventsView.EventsList().Values;
						return result;
					}
				}
				catch (Exception e)
				{
					// TODO: log here
					// TODO: wrap and rethrow exception
					throw;
				}
			});

			return events;
		}

		//private IEnumerable<User> GetUsersInner(IOemClient client, Func<IUserView, bool> filter = null)
		//{
		//	var result =
		//		this.GetUserViews(client, filter)
		//			.Select(item =>
		//				new User()
		//				{
		//					Id = item.UserId,
		//					FirstName = item.FirstName,
		//					Surname = item.Surname,
		//					Department = item.Department,
		//					Cards = (client.ViewCards(item.UserId) ?? Enumerable.Empty<int>()),
		//				});

		//	return result;
		//}

		//private IEnumerable<IUserView> GetUserViews(IOemClient client, Func<IUserView, bool> filter)
		//{
		//	var allUserViews = client.ViewUserRecords().UsersList().Select(pair => pair.Value);

		//	var result =
		//		allUserViews
		//			.Where(item => item.Active)
		//			.Where(filter ?? (item => true));

		//	return result;
		//}

		private IEnumerable<User> GetUsersInner(IOemClient client, string sqlWhereClause = null)
		{
			var result =
				this.GetUserViews(client, sqlWhereClause)
					.Select(item =>
						new User()
						{
							Id = item.UserId,
							FirstName = item.FirstName,
							Surname = item.Surname,
							Department = item.Department,
							Cards = (client.ViewCards(item.UserId) ?? Enumerable.Empty<int>()),
						});

			return result.ToList();
		}

		private IEnumerable<IUserView> GetUserViews(IOemClient client, string sqlWhereClause = null)
		{
			IEnumerable<IUserView> result = null;

			var activeUserFilter = "Active = 1";
			sqlWhereClause = sqlWhereClause != null ? sqlWhereClause + " AND " : String.Empty;

			var records = client.ViewUserRecords(sqlWhereClause + activeUserFilter);

			if (records != null)
			{
				var usersById = records.UsersList();
				result = usersById.Select(pair => pair.Value);
			}

			return result;
		}

		private bool UpdateUserView(IOemClient client, IUserView source)
		{
			return
				client.UpdateUserRecord(
					userId: source.UserId,
					accessLevelId: source.AccessLevelId,
					departmentId: source.DepartmentId,
					antiPassbackInd: source.AntiPassbackUser,
					alarmUserInd: source.AlarmUser,
					firstName: source.FirstName,
					middleName: source.MiddleName,
					surname: source.Surname,
					telephoneNo: source.Telephone,
					telephoneExtension: source.Extension,
					pinCode: source.PIN,
					pictureFileName: source.Picture,
					activationDate: source.ActivationDate,
					activeInd: source.Active,
					faxNo: source.Fax,
					expiryDate: source.ExpiryDate,
					customFields: null);
		}
	}
}
