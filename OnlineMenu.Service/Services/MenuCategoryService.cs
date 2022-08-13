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
    public interface IMenuCategoryService
    {
        VMMenuCategory GetById(Guid id);

        List<VMMenuCategory> GetByRestaurantId(Guid id);

        int Create(VMMenuCategory entity);

        int Update(VMMenuCategory entity);

        List<VMMenuCategory> GetAll();
    }

    public class MenuCategoryService : IMenuCategoryService
    {
        private IUnitOfWork unitOfWork;

        public MenuCategoryService(IUnitOfWork unitOfWork)
        {
            this.unitOfWork = unitOfWork;
        }

        public int Create(VMMenuCategory vmEntity)
        {
            var entity = Mapper.Map<MenuCategory>(vmEntity);
            entity.Id = Guid.NewGuid();

            unitOfWork.MenuCategory.Add(entity);
            return unitOfWork.SaveChanges();
        }

        public List<VMMenuCategory> GetAll()
        {
            var entities = unitOfWork.MenuCategory.GetAll();
            return Mapper.Map<List<VMMenuCategory>>(entities);
        }

        public VMMenuCategory GetById(Guid id)
        {
            var entity = unitOfWork.MenuCategory.Get(id);
            return Mapper.Map<VMMenuCategory>(entity);
        }

        public List<VMMenuCategory> GetByRestaurantId(Guid id)
        {
            var entities = unitOfWork.MenuCategory.Find(t => t.RestaurantId == id).OrderBy(t=>t.Sequence).ToList();
            return Mapper.Map<List<VMMenuCategory>>(entities);
        }

        public int Update(VMMenuCategory vmEntity)
        {
            var entity = Mapper.Map<MenuCategory>(vmEntity);
            unitOfWork.MenuCategory.Update(entity);

            return unitOfWork.SaveChanges();
        }
    }
}