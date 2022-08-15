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
    public class ItemsCategoryController : Controller
    {
        private IItemsService itemsService;
        private IRestaurantService restaurantService;

        public ItemsCategoryController(IItemsService itemsService, IRestaurantService restaurantService)
        {
            this.itemsService = itemsService;
            this.restaurantService = restaurantService;
        }

        public ActionResult Index(Guid categoryId)
        {
            var categories = itemsService.GetByCategoryId(categoryId);
            ViewBag.CategoryId = categoryId;
            return View(categories);
        }

        public ActionResult Create(Guid categoryId)
        {
            var itemWithMaxSequence = itemsService.GetByCategoryId(categoryId).Max(x => x.Sequence);
            var nextSequence = itemWithMaxSequence == null ? 1 : itemWithMaxSequence + 1;

            var Items = new VMItem()
            {
                CategoryId = categoryId,
                Sequence = nextSequence,
            };

            return View(Items);
        }

        [HttpPost]
        public ActionResult CreateOrUpdate(VMItem vmEntity)
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
                    itemsService.Create(vmEntity);
                }
                else
                {
                    itemsService.Update(vmEntity);
                }
            }

            return RedirectToAction("Index");
        }

        public ActionResult Edit(Guid id)
        {
            return View(itemsService.GetById(id));
        }

        [HttpPost]
        public ActionResult Edit(VMItem vmEntity)
        {
            itemsService.Update(vmEntity);
            return RedirectToAction("Index", new { categoryId = vmEntity.CategoryId });
        }
    }
}