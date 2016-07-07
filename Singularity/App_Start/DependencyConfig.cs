using System.Reflection;
using System.Web.Mvc;
using Autofac;
using Autofac.Integration.Mvc;

namespace Singularity.Config
    {
    public static class DependencyConfig
        {
        public static void RegisterDI()
            {
            var builder = new ContainerBuilder();
            var assemby = Assembly.GetExecutingAssembly();

            // Register your MVC controllers.
            builder.RegisterControllers(assemby);

            // OPTIONAL: Register model binders that require DI.
            //            builder.RegisterModelBinders(assemby);
            //            builder.RegisterModelBinderProvider();

            // OPTIONAL: Register web abstractions like HttpContextBase.
            builder.RegisterModule<AutofacWebTypesModule>();

            // OPTIONAL: Enable property injection in view pages.
            builder.RegisterSource(new ViewRegistrationSource());

            // OPTIONAL: Enable property injection into action filters.
            builder.RegisterFilterProvider();


            // Register all Factories
            builder.RegisterAssemblyTypes(assemby)
                   .Where(t => t.Name.EndsWith("Service"))
                   .AsImplementedInterfaces();

           // builder.RegisterType<ModelContext>().As<SingularityContext>();

            // Set the dependency resolver to be Autofac.
            var container = builder.Build();
            DependencyResolver.SetResolver(new AutofacDependencyResolver(container));

            }
        }
    }
