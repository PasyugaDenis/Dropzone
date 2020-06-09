[assembly: WebActivatorEx.PreApplicationStartMethod(typeof(DropZone.API.App_Start.NinjectWebCommon), "Start")]
[assembly: WebActivatorEx.ApplicationShutdownMethodAttribute(typeof(DropZone.API.App_Start.NinjectWebCommon), "Stop")]

namespace DropZone.API.App_Start
{
    using DropZone.Core.Managers.AircraftManager;
    using DropZone.Core.Managers.AuthorizationManager;
    using DropZone.Core.Managers.DropZoneManager;
    using DropZone.Core.Managers.UserManager;
    using DropZone.Core.Services.AircraftService;
    using DropZone.Core.Services.AuthorizationService;
    using DropZone.Core.Services.DropZoneService;
    using DropZone.Core.Services.UserService;
    using DropZone.Database.Repository;
    using Microsoft.Web.Infrastructure.DynamicModuleHelper;
    using Ninject;
    using Ninject.Web.Common;
    using Ninject.Web.Common.WebHost;
    using System;
    using System.Web;

    public static class NinjectWebCommon
    {
        private static readonly Bootstrapper bootstrapper = new Bootstrapper();

        /// <summary>
        /// Starts the application.
        /// </summary>
        public static void Start()
        {
            DynamicModuleUtility.RegisterModule(typeof(OnePerRequestHttpModule));
            DynamicModuleUtility.RegisterModule(typeof(NinjectHttpModule));
            bootstrapper.Initialize(CreateKernel);
        }

        /// <summary>
        /// Stops the application.
        /// </summary>
        public static void Stop()
        {
            bootstrapper.ShutDown();
        }

        /// <summary>
        /// Creates the kernel that will manage your application.
        /// </summary>
        /// <returns>The created kernel.</returns>
        private static IKernel CreateKernel()
        {
            var kernel = new StandardKernel();
            try
            {
                kernel.Bind<Func<IKernel>>().ToMethod(ctx => () => new Bootstrapper().Kernel);
                kernel.Bind<IHttpModule>().To<HttpApplicationInitializationHttpModule>();

                RegisterServices(kernel);
                return kernel;
            }
            catch
            {
                kernel.Dispose();
                throw;
            }
        }

        /// <summary>
        /// Load your modules or register your services here!
        /// </summary>
        /// <param name="kernel">The kernel.</param>
        private static void RegisterServices(IKernel kernel)
        {
            //repository
            kernel.Bind<IRepository>().To<Repository>();

            //services
            kernel.Bind<IAircraftService>().To<AircraftService>();
            kernel.Bind<IAuthorizationService>().To<AuthorizationService>()
                .WithConstructorArgument(AuthConfig.OAuthOptions);
            kernel.Bind<IDropZoneService>().To<DropZoneService>();
            kernel.Bind<IUserService>().To<UserService>();

            //managers
            kernel.Bind<IAircraftManager>().To<AircraftManager>();
            kernel.Bind<IAuthorizationManager>().To<AuthorizationManager>();
            kernel.Bind<IDropZoneManager>().To<DropZoneManager>();
            kernel.Bind<IUserManager>().To<UserManager>();
        }
    }
}