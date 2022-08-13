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

        public MenuCategoriesController(IMenuCategoryService menuCategoryService)
        {
            this.menuCategoryService = menuCategoryService;
        }

        public ActionResult Index(Guid restaurantId, string restaurantName)
        {
            var categories = menuCategoryService.GetByRestaurantId(restaurantId);

            ViewBag.RestaurantId = restaurantId;
            ViewBag.RestaurantName = restaurantName;
            return View(categories);
        }
    }
}