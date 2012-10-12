#region License
//-----------------------------------------------------------------------
// <copyright file="AutofacBootStrapper.cs" company="Pi2 LLC">
//     Copyright (c) Pi2 LLC. All rights reserved.
// </copyright>
//-----------------------------------------------------------------------
#endregion

#region Using Directives 
using Autofac;
using Autofac.Integration.Mvc;
using Sigma.Core.BootStrapper;
using Sigma.Core.Extensibility;
using Sigma.Core.ServiceLocator;
using System;
using System.Collections.Generic;
using System.Reflection;
using System.Web.Mvc;
#endregion

namespace Sigma.Web.BootStrapper
{
    public class AutofacBootStrapper : CommonBootStrapper
    {
        public AutofacBootStrapper(Assembly callingAssembly, IEnumerable<string> bootTaskAssemblies) 
            : base(callingAssembly, bootTaskAssemblies) { }

        protected override IServiceLocator CreateServiceLocator(IEnumerable<string> bootTaskAssemblies)
        {
            var builder = new ContainerBuilder();
            RegisterTypes(builder, _callingAssembly, bootTaskAssemblies);
            var container = builder.Build();

            // Set MVC dependency resolver to Autofac 
            DependencyResolver.SetResolver(new AutofacDependencyResolver(container));
            return new AutofacServiceLocator(container);
        }

        /// <summary>
        /// Registers services into ioc container. 
        /// </summary>
        private static void RegisterTypes(ContainerBuilder builder, Assembly callingAssembly, IEnumerable<string> bootTaskAssemblies)
        {
            builder.RegisterControllers(callingAssembly);
            builder.RegisterFilterProvider();
            
            // Perform Registrations Here...
            //builder.RegisterType<Person>().As<IPerson>();

            // Register Bootstrapper tasks based on the assemblies passed. 
            if (bootTaskAssemblies != null)
            {
                foreach (string asm in bootTaskAssemblies)
                {
                    var assembly = Assembly.Load(asm);
                    RegisterFromAssembly(builder, assembly, typeof(IBootstrapperTask));
                }
            }
            
            // Register Plugins and override any previous registrations.
            var plugins = Assembly.Load("Sigma.Plugins");
            RegisterFromAssembly(builder, plugins, typeof(IPlugin));
        }

        /// <summary>
        /// Registers type from an assembly.
        /// </summary>
        private static void RegisterFromAssembly(ContainerBuilder builder, Assembly assembly, Type serviceType)
        {
            builder.RegisterAssemblyTypes(assembly)
               .Where(t => serviceType.IsAssignableFrom(t))
               .AsImplementedInterfaces();
        }

        /// <summary>
        /// Scanning all instances from Assemply
        /// and execute accordingly. 
        /// </summary>
        protected override void Run()
        {
            var listTask = IoC.GetAllInstances<IBootstrapperTask>();

            if (listTask != null)
            {
                foreach (var task in listTask)
                {
                    task.Execute();
                }
            }
        }

    }
}
