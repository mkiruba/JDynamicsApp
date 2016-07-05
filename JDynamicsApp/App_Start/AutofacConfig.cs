using Autofac;
using Autofac.Integration.WebApi;
using JDynamicsApp.Data.DbContext;
using JDynamicsApp.Data.Repository;
using JDynamicsApp.Service;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Web;
using System.Web.Http;

namespace JDynamicsApp.App_Start
{
    public class AutofacConfig
    {
        public static void ConfigureContainer()
        {
            var builder = new ContainerBuilder();
            var config = GlobalConfiguration.Configuration;

            builder.RegisterType<CalculationDbContext>().AsSelf().InstancePerRequest();
            builder.RegisterType<CalculateRepository>().As<ICalculateRepository>().InstancePerRequest();
            builder.RegisterType<CalculationService>().As<ICalculationService>().InstancePerRequest();            
            builder.RegisterApiControllers(typeof(AutofacConfig).Assembly);

            var container = builder.Build();
            config.DependencyResolver = new AutofacWebApiDependencyResolver(container);
        }
    }
}