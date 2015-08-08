using Autofac.Integration.WebApi;
using OxHack.Doors.Common.Models;
using OxHack.Doors.Common.Services;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using System.Web.Http;

namespace OxHack.Doors.ServiceHost.Controllers
{
	//[Authorize]
	[AutofacControllerConfiguration]
	public class UsersController : ApiController
	{
		private IUserService service;

		public UsersController(IUserService service)
		{
			this.service = service;
		}

		public async Task<IEnumerable<User>> Get()
		{
			try
			{
				return await this.service.GetUsers();
			}
			catch
			{
				// TODO: return appropriate error, log error
				throw;
			}
		}

		public async Task<User> Get(int id)
		{
			try
			{
				return await this.service.GetUserById(id);
			}
			catch
			{
				// TODO: return appropriate error, log error
				throw;
			}
		}

		public async Task Post([FromBody]User value)
		{
			try
			{
				await this.service.CreateUser(value);
			}
			catch
			{
				// TODO: return appropriate error, log error
				throw;
			}
		}

		public async Task Put(int id, [FromBody]User value)
		{
			try
			{
				if (value.Id != id)
				{
					throw new ArgumentException("Resource URL and provided User have mismatched Ids.");
				}

				await this.service.UpdateUser(value);
			}
			catch
			{
				// TODO: return appropriate error, log error
				throw;
			}
		}

		public async Task Delete(int id)
		{
			try
			{
				await this.service.DeleteUser(id);
			}
			catch
			{
				// TODO: return appropriate error, log error
				throw;
			}
		}
	}
}
