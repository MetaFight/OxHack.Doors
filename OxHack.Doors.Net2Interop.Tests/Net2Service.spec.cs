using System;
using FluentAssertions;
using System.Linq;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using Machine.Specifications;
using OxHack.Doors.Common.Models;
using System.Collections.Generic;
using Rhino.Mocks;
using OxHack.Doors.Common.Services;
using System.Threading.Tasks;
using OxHack.Doors.Net2Interop;
using Paxton.Net2.OemClientLibrary;
using OxHack.Doors.Net2Interop.Tests.Dummies;

namespace OxHack.Doors.Service.Tests
{
	[Subject(typeof(Net2Service))]
	public class When_UserService_requests_User_list
	{
		static readonly string oxHackDepartment = "Oxford Hackspace";
		static List<IUserView> dummyUsers =
			new List<IUserView>
			{
				new DummyUserView()
				{
					UserId = 1,
					FirstName = "Larry",
					Department = oxHackDepartment,
					Active = true
				},
				new DummyUserView()
				{
					UserId = 2,
					FirstName = "Curly",
					Department = "not " + oxHackDepartment,
					Active = true
				},
				new DummyUserView()
				{
					UserId = 3,
					FirstName = "Moe",
					Department = oxHackDepartment,
					Active = true
				}
			};
		static Dictionary<int, IEnumerable<int>> dummyCardsByUserId =
			new Dictionary<int, IEnumerable<int>>
			{
				{ 1, new [] { 123456 } },
				{ 2, new [] { 345678 } },
				{ 3, new [] { 567890 } },
			};

		static Net2Service subject;
		static IEnumerable<User> userList;

		Establish context = () =>
		{
			var filteredUserListStub = MockRepository.GenerateStub<IUsers>();
			filteredUserListStub
				.Stub(item => item.UsersList())
				.Return(dummyUsers.Where(item => item.DisplayName == oxHackDepartment).ToDictionary(key => key.UserId));

			var unfilteredUserListStub = MockRepository.GenerateStub<IUsers>();
			unfilteredUserListStub
				.Stub(item => item.UsersList())
				.Return(dummyUsers.ToDictionary(key => key.UserId));

			var oemClientStub = MockRepository.GenerateStub<IOemClient>();
			oemClientStub
				.Stub(item => item.ViewUserRecords("Department = '" + oxHackDepartment + "'"))
				.Return(filteredUserListStub);
			oemClientStub
				.Stub(item => item.ViewUserRecords())
				.Return(unfilteredUserListStub);
			oemClientStub
				.Stub(item => item.ViewCards(1))
				.Return(dummyCardsByUserId[1].ToList());
			oemClientStub
				.Stub(item => item.ViewCards(2))
				.Return(dummyCardsByUserId[2].ToList());
			oemClientStub
				.Stub(item => item.ViewCards(3))
				.Return(dummyCardsByUserId[3].ToList());
			subject = new Net2Service(() => oemClientStub);
		};

		Because of = () =>
		{
			userList = subject.GetUsers().Result;
		};

		It returns_only_Users_in_the_hackspace_department = () =>
		{
			userList.Should().NotBeNullOrEmpty();
			userList.Count().Should().Be(3);
			userList
				.Select(item => new
				{
					FirstName = item.FirstName,
					CardNumbers = item.Cards
				})
				.ShouldBeEquivalentTo(dummyCardsByUserId.Keys.Select(item => new
				{
					FirstName = dummyUsers.Single(user => user.UserId == item).FirstName,
					CardNumbers = dummyCardsByUserId[item]
				}));
		};
	}
}
