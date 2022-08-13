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
    public class TablesController : Controller
    {
        private ITableService tableService;

        public TablesController(ITableService tableServie)
        {
            this.tableService = tableServie;
        }

        public ActionResult Index()
        {
            return View(tableService.GetAll());
        }

        public ActionResult Create()
        {
            return View();
        }

        [HttpPost]
        public ActionResult Create(VMTable vmEntity)
        {
            tableService.Create(vmEntity);
            return RedirectToAction("Index");
        }

        public ActionResult Edit(Guid id)
        {
            return View(tableService.GetById(id));
        }

        [HttpPost]
        public ActionResult Edit(VMTable vmEntity)
        {
            tableService.Update(vmEntity);
            return RedirectToAction("Index");
        }

        public ActionResult Delete(Guid id)
        {
            return View(tableService.GetById(id));
        }

        [HttpPost]
        public ActionResult Delete(VMTable vmEntity)
        {
            tableService.Delete(vmEntity.Id);
            return RedirectToAction("Index");
        }
    }
}