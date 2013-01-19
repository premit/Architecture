[assembly: WebActivator.PreApplicationStartMethod(typeof(Architecture.Website.App_Start.NinjectWebCommon), "Start")]
[assembly: WebActivator.ApplicationShutdownMethodAttribute(typeof(Architecture.Website.App_Start.NinjectWebCommon), "Stop")]

namespace Architecture.Website.App_Start
{
    using System;
    using System.Web;

    using Microsoft.Web.Infrastructure.DynamicModuleHelper;

    using Ninject;
    using Ninject.Web.Common;

    using Architecture.Domain;

    public static class NinjectWebCommon
    {
        private static readonly Bootstrapper bootstrapper = new Bootstrapper();

        /// <summary>
        /// Starts the application
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
            kernel.Bind<Func<IKernel>>().ToMethod(ctx => () => new Bootstrapper().Kernel);
            kernel.Bind<IHttpModule>().To<HttpApplicationInitializationHttpModule>();

            RegisterServices(kernel);
            return kernel;
        }

        /// <summary>
        /// Load your modules or register your services here!
        /// </summary>
        /// <param name="kernel">The kernel.</param>
        private static void RegisterServices(IKernel kernel)
        {
            // Register entity mappings here.
            kernel.Bind<Architecture.Domain.IEntitiesContext>().To<Architecture.Domain.EntitiesContext>().InRequestScope();

            // Register repository mappings here.
            kernel.Bind<IRepository<Genre>>().To<Repository<Genre>>();
            kernel.Bind<IRepository<Artist>>().To<Repository<Artist>>();
            kernel.Bind<IRepository<Album>>().To<Repository<Album>>();

            // Register service mappings here.
            kernel.Bind<IGenreService>().To<GenreService>();
            kernel.Bind<IArtistService>().To<ArtistService>();
            kernel.Bind<IAlbumService>().To<AlbumService>();

            // Register unit of work mappings here.
            kernel.Bind<IUnitOfWork>().To<UnitOfWork>();
        }
    }
}
