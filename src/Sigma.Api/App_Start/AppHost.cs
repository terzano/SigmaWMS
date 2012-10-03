#region License
//-----------------------------------------------------------------------
// <copyright file="AppHost.cs" company="Pi2 LLC">
//     Copyright (c) Pi2 LLC. All rights reserved.
// </copyright>
//-----------------------------------------------------------------------
#endregion

#region Using Directives
using System;
using System.Linq;
using System.Configuration;
using System.Collections.Generic;
using ServiceStack.Configuration;
using ServiceStack.OrmLite;
using ServiceStack.OrmLite.SqlServer;
using ServiceStack.ServiceInterface;
using ServiceStack.ServiceInterface.Auth;
using ServiceStack.ServiceInterface.ServiceModel;
using ServiceStack.WebHost.Endpoints;
using Autofac;
#endregion

[assembly: WebActivator.PreApplicationStartMethod(typeof(Sigma.Api.App_Start.AppHost), "Start")]

namespace Sigma.Api.App_Start
{
    public class AppHost : AppHostBase
    {
        public AppHost() : base("SigmaWMS API", typeof(Todo).Assembly) { }

        public override void Configure(Funq.Container container)
        {
            //Set JSON web services to return idiomatic JSON camelCase properties
            ServiceStack.Text.JsConfig.EmitCamelCaseNames = true;

            //Create Autofac builder
            var builder = new ContainerBuilder();
            //Now register all depedencies to your custom IoC container
            //...
            builder.RegisterType<TodoRepository>();

            //Register Autofac IoC container adapter, so ServiceStack can use it
            IContainerAdapter adapter = new AutofacIocAdapter(builder.Build());
            container.Adapter = adapter;

            //Configure User Defined REST Paths
            Routes
                .Add<Todo>("/todos")
                .Add<Todo>("/todos/{Id}");
        }

        public static void Start()
        {
            new AppHost().Init();
        }
    }
}
