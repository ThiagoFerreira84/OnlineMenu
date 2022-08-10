using Microsoft.Practices.Unity;
using OnlineMenu.Data;
using OnlineMenu.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Web.Mvc;
using Unity.Mvc5;

namespace OnlineMenu.Service.DI
{
    public static class UnityConfig
    {
        public static void RegisterComponents()
        {
            var container = new UnityContainer();
            //container.RegisterType<ITypeService, TypeService>(new ContainerControlledLifetimeManager());
            container.RegisterType<IRepository<Country>, Repository<Country>>(new ContainerControlledLifetimeManager());
            container.RegisterType<IRepository<Restaurant>, Repository<Restaurant>>(new ContainerControlledLifetimeManager());

            container.RegisterType<IUnitOfWork, UnitOfWork>(new ContainerControlledLifetimeManager());
            DependencyResolver.SetResolver(new UnityDependencyResolver(container));
        }
    }
}