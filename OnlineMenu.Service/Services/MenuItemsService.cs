using AutoMapper;
using OnlineMenu.Data;
using OnlineMenu.Model;
using OnlineMenu.Service.ViewModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.InteropServices.ComTypes;
using System.Text;
using System.Threading.Tasks;

namespace OnlineMenu.Service.Services
{
    public interface IMenuItemsService
    {
        VMMenuItem GetById(Guid id);

        List<VMMenuItem> GetByCategoryId(Guid id);

        List<VMMenuItem> GetBySubCategoryId(Guid id);

        int Create(VMMenuItem entity);

        int Update(VMMenuItem entity);

        List<VMMenuItem> GetAll();
    }

    public class MenuItemsService : IMenuItemsService
    {
        private IUnitOfWork unitOfWork;

        public MenuItemsService(IUnitOfWork unitOfWork)
        {
            this.unitOfWork = unitOfWork;
        }

        public int Create(VMMenuItem vmEntity)
        {
            var entity = Mapper.Map<MenuItem>(vmEntity);
            entity.Id = Guid.NewGuid();

            unitOfWork.MenuItem.Add(entity);
            return unitOfWork.SaveChanges();
        }

        public List<VMMenuItem> GetAll()
        {
            var entities = unitOfWork.MenuItem.GetAll();
            return Mapper.Map<List<VMMenuItem>>(entities);
        }

        public VMMenuItem GetById(Guid id)
        {
            var entity = unitOfWork.MenuItem.Get(id);
            return Mapper.Map<VMMenuItem>(entity);
        }

        public List<VMMenuItem> GetByCategoryId(Guid id)
        {
            var entities = unitOfWork.MenuItem.Find(t => t.MenuCategoryId == id).OrderBy(t => t.Sequence).ToList();
            return Mapper.Map<List<VMMenuItem>>(entities);
        }

        public List<VMMenuItem> GetBySubCategoryId(Guid id)
        {
            var entities = unitOfWork.MenuItem.Find(t => t.MenuSubCategoryId == id).OrderBy(t => t.Sequence).ToList();
            return Mapper.Map<List<VMMenuItem>>(entities);
        }

        public int Update(VMMenuItem vmEntity)
        {
            var entity = Mapper.Map<MenuItem>(vmEntity);
            unitOfWork.MenuItem.Update(entity);

            return unitOfWork.SaveChanges();
        }
    }
}