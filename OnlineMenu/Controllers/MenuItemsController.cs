using OnlineMenu.Service.Services;
using OnlineMenu.Service.ViewModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace OnlineMenu.Controllers
{
    public class MenuItemsController : Controller
    {
        private IMenuItemsService MenuItemsService;
        private IRestaurantService restaurantService;

        public MenuItemsController(IMenuItemsService MenuItemsService, IRestaurantService restaurantService)
        {
            this.MenuItemsService = MenuItemsService;
            this.restaurantService = restaurantService;
        }

        public ActionResult Index(Guid restaurantId)
        {
            var categories = MenuItemsService.GetByCategoryId(restaurantId);

            ViewBag.RestaurantId = restaurantId;
            ViewBag.RestaurantName = restaurantService.GetById(restaurantId).Name;
            return View(categories);
        }

        public ActionResult Create(Guid restaurantId)
        {
            var MenuItems = new VMMenuItems()
            {
                RestaurantId = restaurantId,
            };

            return View(MenuItems);
        }

        [HttpPost]
        public ActionResult Create(VMMenuItems vmEntity)
        {
            MenuItemsService.Create(vmEntity);
            return RedirectToAction("Index", new { restaurantId = vmEntity.RestaurantId });
        }

        public ActionResult Edit(Guid id)
        {
            return View(MenuItemsService.GetById(id));
        }

        [HttpPost]
        public ActionResult Edit(VMMenuItems vmEntity)
        {
            MenuItemsService.Update(vmEntity);
            return RedirectToAction("Index", new { restaurantId = vmEntity.RestaurantId });
        }
    }
}