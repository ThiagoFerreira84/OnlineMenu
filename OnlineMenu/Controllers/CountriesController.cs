using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Linq;
using System.Net;
using System.Web;
using System.Web.Mvc;
using OnlineMenu.Service.Services;

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
    }
}