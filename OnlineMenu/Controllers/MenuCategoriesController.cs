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
        private ICategoryService categoryService;
        private IRestaurantService restaurantService;

        public MenuCategoriesController(ICategoryService categoryService, IRestaurantService restaurantService)
        {
            this.categoryService = categoryService;
            this.restaurantService = restaurantService;
        }

        public ActionResult Index(Guid restaurantId)
        {
            var categories = categoryService.GetByRestaurantId(restaurantId);

            ViewBag.RestaurantId = restaurantId;
            ViewBag.RestaurantName = restaurantService.GetById(restaurantId).Name;
            return View(categories);
        }

        public ActionResult Create(Guid restaurantId)
        {
            var category = new VMCategory()
            {
                RestaurantId = restaurantId,
            };

            return View(category);
        }

        [HttpPost]
        public ActionResult Create(VMCategory vmEntity)
        {
            categoryService.Create(vmEntity);
            return RedirectToAction("Index", new { restaurantId = vmEntity.RestaurantId });
        }

        public ActionResult Edit(Guid id)
        {
            return View(categoryService.GetById(id));
        }

        [HttpPost]
        public ActionResult Edit(VMCategory vmEntity)
        {
            categoryService.Update(vmEntity);
            return RedirectToAction("Index", new { restaurantId = vmEntity.RestaurantId });
        }
    }
}