using OnlineMenu.Service.Services;
using OnlineMenu.Service.ViewModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace OnlineMenu.Controllers
{
    public class CategoriesController : Controller
    {
        private ICategoryService categoryService;
        private IPageService pageService;

        public CategoriesController(ICategoryService categoryService, IPageService pageService)
        {
            this.categoryService = categoryService;
            this.pageService = pageService;
        }

        public ActionResult Index(Guid pageId)
        {
            var categories = categoryService.GetByPageId(pageId);

            ViewBag.PageId = pageId;
            ViewBag.PageName = pageService.GetById(pageId).Title;
            return View(categories);
        }

        public ActionResult Create(Guid pageId)
        {
            var category = new VMCategory()
            {
                PageId = pageId,
            };

            return View(category);
        }

        [HttpPost]
        public ActionResult Create(VMCategory vmEntity)
        {
            categoryService.Create(vmEntity);
            return RedirectToAction("Index", new { pageId = vmEntity.PageId });
        }

        public ActionResult Edit(Guid id)
        {
            return View(categoryService.GetById(id));
        }

        [HttpPost]
        public ActionResult Edit(VMCategory vmEntity)
        {
            categoryService.Update(vmEntity);
            return RedirectToAction("Index", new { pageId = vmEntity.PageId });
        }
    }
}