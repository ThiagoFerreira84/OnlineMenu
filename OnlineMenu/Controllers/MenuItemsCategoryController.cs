using OnlineMenu.Service.Services;
using OnlineMenu.Service.ViewModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace OnlineMenu.Controllers
{
    public class MenuItemsCategoryController : Controller
    {
        private IMenuItemsService MenuItemsService;
        private IRestaurantService restaurantService;

        public MenuItemsCategoryController(IMenuItemsService MenuItemsService, IRestaurantService restaurantService)
        {
            this.MenuItemsService = MenuItemsService;
            this.restaurantService = restaurantService;
        }

        public ActionResult Index(Guid menuCategoryId)
        {
            var categories = MenuItemsService.GetByCategoryId(menuCategoryId);
            ViewBag.CategoryId = menuCategoryId;
            return View(categories);
        }

        public ActionResult Create(Guid menuCategoryId)
        {
            var MenuItems = new VMMenuItem()
            {
                MenuCategoryId = menuCategoryId,
            };

            return View(MenuItems);
        }

        [HttpPost]
        public ActionResult Create(VMMenuItem vmEntity)
        {
            MenuItemsService.Create(vmEntity);
            return RedirectToAction("Index", new { menuCategoryId = vmEntity.MenuCategoryId });
        }

        public ActionResult Edit(Guid id)
        {
            return View(MenuItemsService.GetById(id));
        }

        [HttpPost]
        public ActionResult Edit(VMMenuItem vmEntity)
        {
            MenuItemsService.Update(vmEntity);
            return RedirectToAction("Index", new { menuCategoryId = vmEntity.MenuCategoryId });
        }
    }
}