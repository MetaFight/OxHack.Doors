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

namespace OxHack.Doors.Service.Tests
{
	[Subject(typeof(UserService))]
	public class When_user_requests_User_list
	{
		static readonly string oxHackDepartment = "Oxford Hackspace";
		static List<User> dummyUsers =
			new List<User>
			{
				new User()
				{
					FirstName = "Larry",
					Department = oxHackDepartment,
					Cards = new [] { 123456 }
				},
				new User() {
					FirstName = "Curly",
					Department = oxHackDepartment,
					Cards = new [] { 234567 }
				},
				new User() {
					FirstName = "Moe",
					Department = oxHackDepartment,
					Cards = new [] { 345678 }
				},
			};
		static UserService subject;
		static IEnumerable<User> userList;

		Establish context = () =>
		{
			IDoorAccessService doorAccessServiceMock = MockRepository.GenerateStub<IDoorAccessService>();
			doorAccessServiceMock
				.Stub(item => item.GetUsersByDepartment(oxHackDepartment))
				.Return(Task.FromResult(dummyUsers.AsEnumerable()));

			subject = new UserService(doorAccessServiceMock);
		};

		Because of = () =>
		{
			userList = subject.GetUsers().Result;
		};

		It returns_a_User_list = () =>
		{
			userList.Should().NotBeNullOrEmpty();
			userList.Count().Should().Be(3);
			userList
				.Select(item => new
				{
					FirstName = item.FirstName,
					Cards = item.Cards
				})
				.ShouldBeEquivalentTo(dummyUsers);
		};
	}

	[Subject(typeof(UserService))]
	public class When_user_request_a_specific_OxHack_User_by_Id
	{
		static readonly int oxHackMemberId = 1;
		static UserService subject;
		static User actual;

		Establish context = () =>
		{
			IDoorAccessService doorAccessServiceMock = MockRepository.GenerateStub<IDoorAccessService>();
			doorAccessServiceMock
				.Stub(item => item.GetUserById(oxHackMemberId))
				.Return(Task.FromResult(new User()
				{
					Id = oxHackMemberId,
					FirstName = "Larry",
					Department = "Oxford Hackspace",
				}));

			subject = new UserService(doorAccessServiceMock);
		};

		Because of = () =>
		{
			actual = subject.GetUserById(oxHackMemberId).Result;
		};

		It returns_that_User = () =>
		{
			actual.Should().NotBeNull();
			actual.Id.Should().Be(oxHackMemberId);
		};
	}

	[Subject(typeof(UserService))]
	public class When_user_request_a_specific_a_NonOxHack_User_by_Id
	{
		static readonly int nonOxHackMemberId = 3;
		static UserService subject;
		static User actual;

		Establish context = () =>
		{
			IDoorAccessService doorAccessServiceMock = MockRepository.GenerateStub<IDoorAccessService>();
			doorAccessServiceMock
				.Stub(item => item.GetUserById(nonOxHackMemberId))
				.Return(Task.FromResult(new User()
				{
					Id = nonOxHackMemberId,
					FirstName = "Larry",
					Department = "Other Department",
				}));

			subject = new UserService(doorAccessServiceMock);
		};

		Because of = () =>
		{
			actual = subject.GetUserById(nonOxHackMemberId).Result;
		};

		It returns_null = () =>
		{
			actual.Should().BeNull();
		};
	}
}
