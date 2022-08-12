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
        private ICountryService countryService;

        public CountriesController(ICountryService countryServie)
        {
            this.countryService = countryServie;
        }

        public ActionResult Index()
        {
            return View(countryService.GetAll());
        }

        public ActionResult Create()
        {
            return View();
        }

        [HttpPost]
        public ActionResult Create(VMCountry vmEntity)
        {
            countryService.Create(vmEntity);
            return RedirectToAction("Index");
        }

        public ActionResult Edit(Guid id)
        {
            return View(countryService.GetById(id));
        }

        [HttpPost]
        public ActionResult Edit(VMCountry vmEntity)
        {
            countryService.Update(vmEntity);
            return RedirectToAction("Index");
        }

        public ActionResult Delete(Guid id)
        {
            return View(countryService.GetById(id));
        }

        [HttpPost]
        public ActionResult Delete(VMCountry vmEntity)
        {
            countryService.Delete(vmEntity.Id);
            return RedirectToAction("Index");
        }
    }
}