using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.IO;
using System.Linq;
using System.Net;
using System.Web;
using System.Web.Configuration;
using System.Web.Mvc;
using System.Xml;
using OnlineMenu.Service.Managers;
using OnlineMenu.Service.Services;
using OnlineMenu.Service.ViewModels;
using static System.Net.WebRequestMethods;

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
            var restaurants = restaurantService.GetAll();
            foreach (var restaurant in restaurants)
            {
                if (!string.IsNullOrEmpty(restaurant.LogoFileName))
                {
                    restaurant.LogoPath = AppManager.GetLogosFilePath() + restaurant.LogoFileName;
                }
                else
                {
                    restaurant.LogoPath = string.Empty;
                }
            }
            return View(restaurants);
        }

        public ActionResult Create()
        {
            ViewBag.CountryId = new SelectList(countryService.GetAll(), "Id", "CountryName");

            return View();
        }

        public ActionResult Edit(Guid id)
        {
            var vmEntity = restaurantService.GetById(id);
            ViewBag.Logo = string.Empty;

            if (!string.IsNullOrEmpty(vmEntity.LogoFileName))
            {
                var folder = AppManager.GetLogosFilePath();
                string logoFileName = vmEntity.LogoFileName;
                string fileName = folder + logoFileName;
                ViewBag.Logo = fileName;
            }

            return View(vmEntity);
        }

        [HttpPost]
        public ActionResult Upload(VMRestaurant vmEntity)
        {
            if (ModelState.IsValid)
            {
                //string path = Path.Combine(Server.MapPath("~" + folder), Path.GetFileName(vmEntity.LogoFileName));

                if (Request.Files.Count > 0)
                {
                    var file = Request.Files[0];

                    if (file != null && file.ContentLength > 0)
                    {
                        var folder = AppManager.GetLogosFilePath();
                        string logoFileName = Path.GetFileName(vmEntity.Id + file.FileName);
                        vmEntity.LogoFileName = logoFileName;
                        string _path = Path.Combine(Server.MapPath(folder), logoFileName);
                        file.SaveAs(_path);
                    }
                }

                if (vmEntity.Id == new Guid())
                {
                    restaurantService.Create(vmEntity);
                }
                else
                {
                    restaurantService.Update(vmEntity);
                }
            }

            return RedirectToAction("Index");
        }

        public ActionResult Details(Guid id)
        {
            var vmEntity = restaurantService.GetById(id);
            ViewBag.Logo = string.Empty;

            if (!string.IsNullOrEmpty(vmEntity.LogoFileName))
            {
                var folder = AppManager.GetLogosFilePath();
                string logoFileName = vmEntity.LogoFileName;
                string fileName = folder + logoFileName;
                ViewBag.Logo = fileName;
            }

            return View(vmEntity);
        }
    }
}