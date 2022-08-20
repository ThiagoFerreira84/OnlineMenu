using OnlineMenu.Service.Services;
using OnlineMenu.Service.ViewModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace OnlineMenu.Controllers
{
    public class PagesController : Controller
    {
        private IPageService pageService;
        private IRestaurantService restaurantService;

        public PagesController(IPageService pageService, IRestaurantService restaurantService)
        {
            this.pageService = pageService;
            this.restaurantService = restaurantService;
        }

        public ActionResult Index(Guid restaurantId)
        {
            var categories = pageService.GetByRestaurantId(restaurantId);

            ViewBag.RestaurantId = restaurantId;
            ViewBag.RestaurantName = restaurantService.GetById(restaurantId).Name;
            return View(categories);
        }

        public ActionResult Create(Guid restaurantId)
        {
            var page = new VMPage()
            {
                RestaurantId = restaurantId,
            };

            return View(page);
        }

        [HttpPost]
        public ActionResult Create(VMPage vmEntity)
        {
            pageService.Create(vmEntity);
            return RedirectToAction("Index", new { restaurantId = vmEntity.RestaurantId });
        }

        public ActionResult Edit(Guid id)
        {
            return View(pageService.GetById(id));
        }

        [HttpPost]
        public ActionResult Edit(VMPage vmEntity)
        {
            pageService.Update(vmEntity);
            return RedirectToAction("Index", new { restaurantId = vmEntity.RestaurantId });
        }
    }
}