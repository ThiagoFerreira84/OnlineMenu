using OnlineMenu.Service.Services;
using OnlineMenu.Service.ViewModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace OnlineMenu.Controllers
{
    public class MenuCategoriesController : Controller
    {
        private IMenuCategoryService menuCategoryService;
        private IRestaurantService restaurantService;

        public MenuCategoriesController(IMenuCategoryService menuCategoryService, IRestaurantService restaurantService)
        {
            this.menuCategoryService = menuCategoryService;
            this.restaurantService = restaurantService;
        }

        public ActionResult Index(Guid restaurantId)
        {
            var categories = menuCategoryService.GetByRestaurantId(restaurantId);

            ViewBag.RestaurantId = restaurantId;
            ViewBag.RestaurantName = restaurantService.GetById(restaurantId).Name;
            return View(categories);
        }

        public ActionResult Create(Guid restaurantId)
        {
            var menuCategory = new VMMenuCategory()
            {
                RestaurantId = restaurantId,
            };

            return View(menuCategory);
        }

        [HttpPost]
        public ActionResult Create(VMMenuCategory vmEntity)
        {
            menuCategoryService.Create(vmEntity);
            return RedirectToAction("Index", new { restaurantId = vmEntity.RestaurantId });
        }

        public ActionResult Edit(Guid id)
        {
            return View(menuCategoryService.GetById(id));
        }

        [HttpPost]
        public ActionResult Edit(VMMenuCategory vmEntity)
        {
            menuCategoryService.Update(vmEntity);
            return RedirectToAction("Index");
        }
    }
}