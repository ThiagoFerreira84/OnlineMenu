using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Linq;
using System.Net;
using System.Web;
using System.Web.Mvc;
using OnlineMenu.Service.Services;
using OnlineMenu.Service.ViewModels;

namespace OnlineMenu.Controllers
{
    public class RestaurantsController : Controller
    {
        private IRestaurantService restaurantService;
        private ICountryService countryService;

        public RestaurantsController(IRestaurantService restaurantService, ICountryService countryService)
        {
            this.restaurantService = restaurantService;
            this.countryService = countryService;
        }

        public ActionResult Index()
        {
            return View(restaurantService.GetAll());
        }

        public ActionResult Create()
        {
            ViewBag.CountryId = new SelectList(countryService.GetAll(), "Id", "CountryName");

            return View();
        }

        [HttpPost]
        public ActionResult Create(VMRestaurant vmEntity)
        {
            restaurantService.Create(vmEntity);
            return RedirectToAction("Index");
        }

        public ActionResult Edit(Guid id)
        {
            return View(restaurantService.GetById(id));
        }

        [HttpPost]
        public ActionResult Edit(VMRestaurant vmEntity)
        {
            restaurantService.Update(vmEntity);
            return RedirectToAction("Index");
        }

        //public ActionResult Delete(Guid id)
        //{
        //    return View(restaurantService.GetById(id));
        //}

        //[HttpPost]
        //public ActionResult Delete(VMRestaurant vmEntity)
        //{
        //    restaurantService.Delete(vmEntity.Id);
        //    return RedirectToAction("Index");
        //}
    }
}