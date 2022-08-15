﻿using Microsoft.Practices.Unity;
using OnlineMenu.Data;
using OnlineMenu.Model;
using OnlineMenu.Service.Services;
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
            container.RegisterType<ICountryService, CountryService>(new ContainerControlledLifetimeManager());
            container.RegisterType<IRestaurantService, RestaurantService>(new ContainerControlledLifetimeManager());
            container.RegisterType<ITableService, TableService>(new ContainerControlledLifetimeManager());
            container.RegisterType<ICategoryService, CategoryService>(new ContainerControlledLifetimeManager());
            container.RegisterType<IItemsService, ItemsService>(new ContainerControlledLifetimeManager());
            container.RegisterType<ICategoryVsItemService, CategoryVsItemService>(new ContainerControlledLifetimeManager());
            container.RegisterType<IOrderService, OrderService>(new ContainerControlledLifetimeManager());
            container.RegisterType<IOrderItemService, OrderItemService>(new ContainerControlledLifetimeManager());
            container.RegisterType<ISubCategoryVsItemService, SubCategoryVsItemService>(new ContainerControlledLifetimeManager());
            container.RegisterType<IUserService, UserService>(new ContainerControlledLifetimeManager());
            container.RegisterType<IUserVsRestaurantService, UserVsRestaurantService>(new ContainerControlledLifetimeManager());

            container.RegisterType<IUnitOfWork, UnitOfWork>(new ContainerControlledLifetimeManager());
            DependencyResolver.SetResolver(new UnityDependencyResolver(container));
        }
    }
}