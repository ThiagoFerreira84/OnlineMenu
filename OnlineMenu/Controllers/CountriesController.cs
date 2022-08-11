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
        private ICountryService countryServie;

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
            countryServie.Create(vmEntity);
            return RedirectToAction("Index");
        }

        public ActionResult Edit(Guid id)
        {
            return View(countryServie.GetById(id));
        }

        [HttpPost]
        public ActionResult Edit(VMCountry vmEntity)
        {
            countryServie.Update(vmEntity);
            return RedirectToAction("Index");
        }

        public ActionResult Delete(Guid id)
        {
            return View(countryServie.GetById(id));
        }

        [HttpPost]
        public ActionResult Delete(VMCountry vmEntity)
        {
            countryServie.Delete(vmEntity.Id);
            return RedirectToAction("Index");
        }
    }
}