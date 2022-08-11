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
    public class CountriesController : Controller
    {
        ICountryService countryServie;

        public CountriesController(ICountryService countryServie)
        {
            this.countryServie = countryServie;
        }

        // GET: Countries
        public ActionResult Index()
        {
            return View(countryServie.GetAll());
        }

        // GET: Countries/Create
        public ActionResult Create()
        {
            return View();
        }

        [HttpPost]
        public ActionResult Create(VMCountry vmEntity)
        {
            if (ModelState.IsValid)
            {
                countryServie.Create(vmEntity);
                return Json(new { success = true, adminSection = true }, JsonRequestBehavior.AllowGet);
            }

            return Json(new { success = false }, JsonRequestBehavior.AllowGet);
        }
    }
}