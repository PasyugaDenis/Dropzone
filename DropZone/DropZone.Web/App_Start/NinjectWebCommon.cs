[assembly: WebActivatorEx.PreApplicationStartMethod(typeof(DropZone.Web.App_Start.NinjectWebCommon), "Start")]
[assembly: WebActivatorEx.ApplicationShutdownMethodAttribute(typeof(DropZone.Web.App_Start.NinjectWebCommon), "Stop")]

namespace DropZone.Web.App_Start
{
    using DropZone.Core.Managers.AuthorizationManager;
    using DropZone.Core.Services.AuthorizationService;
    using DropZone.Core.Services.UserService;
    using DropZone.Database.Repository;
    using Microsoft.Web.Infrastructure.DynamicModuleHelper;
    using Ninject;
    using Ninject.Web.Common;
    using Ninject.Web.WebApi;
    using Ninject.Web.WebApi.Filter;
    using System;
    using System.Linq;
    using System.Web;
    using System.Web.Http;
    using System.Web.Http.Validation;

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
                //kernel.Bind<DefaultModelValidatorProviders>()
                //    .ToConstant(new DefaultModelValidatorProviders(
                //        GlobalConfiguration.Configuration.Services.GetServices(typeof(ModelValidatorProvider))
                //        .Cast<ModelValidatorProvider>()));

                //GlobalConfiguration.Configuration.DependencyResolver = new NinjectDependencyResolver(kernel);

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
            kernel.Bind<IUserService>().To<UserService>();
            kernel.Bind<IAuthorizationService>().To<AuthorizationService>()
                .WithConstructorArgument(AuthConfig.OAuthOptions);

            //managers
            kernel.Bind<IAuthorizationManager>().To<AuthorizationManager>();
        }
    }
}