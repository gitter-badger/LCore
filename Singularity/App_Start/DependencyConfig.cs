using System.Web.Mvc;
using Autofac;
using Autofac.Integration.Mvc;

namespace Singularity.Config
    {
    public static class DependencyConfig
        {
        public static void RegisterDI()
            {
            var Builder = new ContainerBuilder();
            var Assembly = System.Reflection.Assembly.GetExecutingAssembly();

            // Register your MVC controllers.
            Builder.RegisterControllers(Assembly);

            // OPTIONAL: Register model binders that require DI.
            //            builder.RegisterModelBinders(assembly);
            //            builder.RegisterModelBinderProvider();

            // OPTIONAL: Register web abstractions like HttpContextBase.
            Builder.RegisterModule<AutofacWebTypesModule>();

            // OPTIONAL: Enable property injection in view pages.
            Builder.RegisterSource(new ViewRegistrationSource());

            // OPTIONAL: Enable property injection into action filters.
            Builder.RegisterFilterProvider();


            // Register all Factories
            Builder.RegisterAssemblyTypes(Assembly)
                   .Where(Type => Type.Name.EndsWith("Service"))
                   .AsImplementedInterfaces();

            // builder.RegisterType<ModelContext>().As<SingularityContext>();

            // Set the dependency resolver to be Autofac.
            var Container = Builder.Build();
            DependencyResolver.SetResolver(new AutofacDependencyResolver(Container));

            }
        }
    }
