[assembly: WebActivator.PreApplicationStartMethod(typeof(nfebox.presentation.mvc.App_Start.NinjectMVC3), "Start")]
[assembly: WebActivator.ApplicationShutdownMethodAttribute(typeof(nfebox.presentation.mvc.App_Start.NinjectMVC3), "Stop")]

namespace nfebox.presentation.mvc.App_Start
{
    using System.Reflection;
    using Microsoft.Web.Infrastructure.DynamicModuleHelper;
    using Ninject;
    using Ninject.Web.Mvc;
    using nfebox.infrastructure.data.contracts;
    using nfebox.infrastructure.data.factories;
    using nfebox.domain.contracts;
    using nfebox.infrastructure.data.repositories;
    using nfebox.domain.services;
    using System.Configuration;

    public static class NinjectMVC3
    {
        private static readonly Bootstrapper bootstrapper = new Bootstrapper();
        private static string uriString;
        private static IConexao Conexao;

        /// <summary>
        /// Starts the application
        /// </summary>
        public static void Start()
        {
            DynamicModuleUtility.RegisterModule(typeof(OnePerRequestModule));
            DynamicModuleUtility.RegisterModule(typeof(HttpApplicationInitializationModule));
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
            RegisterServices(kernel);
            return kernel;
        }

        /// <summary>
        /// Load your modules or register your services here!
        /// </summary>
        /// <param name="kernel">The kernel.</param>
        private static void RegisterServices(IKernel kernel)
        {
            uriString = ConfigurationManager.AppSettings["SQLSERVER_URI"];
            Conexao = FabricaConexao.Criar(uriString);

            kernel.Bind<IRepositorioUsuario>().To<RepositorioUsuario>().WithConstructorArgument("conexao", Conexao);
            kernel.Bind<IRepositorioNotaFiscal>().To<RepositorioNotaFiscal>().WithConstructorArgument("conexao", Conexao);
            kernel.Bind<IRepositorioParticipante>().To<ReposiotorioParticipante>().WithConstructorArgument("conexao", Conexao);

            kernel.Bind<IServicosUsuario>().To<ServicosUsuario>();
            kernel.Bind<IServicoNotaFiscal>().To<ServicosNotaFiscal>();
        }
    }
}
