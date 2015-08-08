using Autofac;
using Autofac.Integration.WebApi;
using OxHack.Doors.Common.Services;
using OxHack.Doors.Net2Interop;
using OxHack.Doors.Service;
using System;
using System.Collections.Generic;
using System.Configuration;
using System.Linq;
using System.Reflection;
using System.Web;
using System.Web.Http;
using System.Web.Mvc;
using System.Web.Optimization;
using System.Web.Routing;

namespace OxHack.Doors.ServiceHost
{
	public class WebApiApplication : System.Web.HttpApplication
	{
		protected void Application_Start()
		{
			WebApiApplication.AutofacConfiguration();
			WebApiApplication.DefaultConfiguration();
		}

		private static void DefaultConfiguration()
		{
			AreaRegistration.RegisterAllAreas();
			GlobalConfiguration.Configure(WebApiConfig.Register);
			FilterConfig.RegisterGlobalFilters(GlobalFilters.Filters);
			RouteConfig.RegisterRoutes(RouteTable.Routes);
			BundleConfig.RegisterBundles(BundleTable.Bundles);
		}

		private static void AutofacConfiguration()
		{
			var builder = new ContainerBuilder();
			var config = GlobalConfiguration.Configuration;

			builder.RegisterApiControllers(Assembly.GetExecutingAssembly());
			WebApiApplication.RegisterComponents(builder);

			var container = builder.Build();
			config.DependencyResolver = new AutofacWebApiDependencyResolver(container);
		}

		private static void RegisterComponents(ContainerBuilder builder)
		{
			string net2Host;
			int net2HostPort;
			WebApiApplication.LoadConfiguration(out net2Host, out net2HostPort);

			builder.Register(c => new OemClientWrapper(net2Host, net2HostPort)).As<IOemClient>();
			//builder.Register<Func<IOemClient>>(c => () => c.Resolve<IOemClient>());
			builder.Register(c =>
			{
				var container = c.Resolve<IContainer>();
				return new Net2Service(() => container.Resolve<IOemClient>());
            }).As<IDoorAccessService>();
			builder.RegisterType<Net2Service>().As<IDoorAccessService>();
			builder.RegisterType<UserService>().As<IUserService>();
			builder.RegisterType<CardService>().As<ICardService>();
			builder.RegisterType<EventService>().As<IEventService>();
		}

		private static void LoadConfiguration(out string net2Host, out int net2HostPort)
		{
			net2Host = ConfigurationManager.AppSettings["net2Host"];
			if (String.IsNullOrWhiteSpace(net2Host))
			{
				throw new ConfigurationErrorsException("App setting 'net2Host' must be specified.");
			}

			if (!Int32.TryParse(ConfigurationManager.AppSettings["net2HostPort"], out net2HostPort))
			{
				throw new ConfigurationErrorsException("App setting 'net2HostPort' must be specified.");
			}
		}
	}
}