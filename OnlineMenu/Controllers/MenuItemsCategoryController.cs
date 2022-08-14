using OnlineMenu.Service.Managers;
using OnlineMenu.Service.Services;
using OnlineMenu.Service.ViewModels;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace OnlineMenu.Controllers
{
    public class MenuItemsCategoryController : Controller
    {
        private IMenuItemsService menuItemsService;
        private IRestaurantService restaurantService;

        public MenuItemsCategoryController(IMenuItemsService menuItemsService, IRestaurantService restaurantService)
        {
            this.menuItemsService = menuItemsService;
            this.restaurantService = restaurantService;
        }

        public ActionResult Index(Guid menuCategoryId)
        {
            var categories = menuItemsService.GetByCategoryId(menuCategoryId);
            ViewBag.MenuCategoryId = menuCategoryId;
            return View(categories);
        }

        public ActionResult Create(Guid menuCategoryId)
        {
            var itemWithMaxSequence = menuItemsService.GetByCategoryId(menuCategoryId).Max(x => x.Sequence);
            var nextSequence = itemWithMaxSequence == null ? 1 : itemWithMaxSequence + 1;

            var MenuItems = new VMMenuItem()
            {
                MenuCategoryId = menuCategoryId,
                Sequence = nextSequence,
            };

            return View(MenuItems);
        }

        [HttpPost]
        public ActionResult CreateOrUpdate(VMMenuItem vmEntity)
        {
            if (ModelState.IsValid)
            {
                if (Request.Files.Count > 0)
                {
                    var file = Request.Files[0];

                    if (file != null && file.ContentLength > 0)
                    {
                        var folder = AppManager.GetLogosFilePath();
                        string logoFileName = Path.GetFileName(vmEntity.Id + file.FileName);
                        vmEntity.Photo = logoFileName;
                        string _path = Path.Combine(Server.MapPath(folder), logoFileName);
                        file.SaveAs(_path);
                    }
                }

                if (vmEntity.Id == new Guid())
                {
                    menuItemsService.Create(vmEntity);
                }
                else
                {
                    menuItemsService.Update(vmEntity);
                }
            }

            return RedirectToAction("Index");
        }

        public ActionResult Edit(Guid id)
        {
            return View(menuItemsService.GetById(id));
        }

        [HttpPost]
        public ActionResult Edit(VMMenuItem vmEntity)
        {
            menuItemsService.Update(vmEntity);
            return RedirectToAction("Index", new { menuCategoryId = vmEntity.MenuCategoryId });
        }
    }
}