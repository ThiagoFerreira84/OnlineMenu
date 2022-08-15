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
    public interface IItemsService
    {
        VMItem GetById(Guid id);

        List<VMItem> GetByCategoryId(Guid id);

        List<VMItem> GetBySubCategoryId(Guid id);

        int Create(VMItem entity);

        int Update(VMItem entity);

        List<VMItem> GetAll();
    }

    public class ItemsService : IItemsService
    {
        private IUnitOfWork unitOfWork;

        public ItemsService(IUnitOfWork unitOfWork)
        {
            this.unitOfWork = unitOfWork;
        }

        public int Create(VMItem vmEntity)
        {
            var entity = Mapper.Map<Item>(vmEntity);
            entity.Id = Guid.NewGuid();

            unitOfWork.Item.Add(entity);
            return unitOfWork.SaveChanges();
        }

        public List<VMItem> GetAll()
        {
            var entities = unitOfWork.Item.GetAll();
            return Mapper.Map<List<VMItem>>(entities);
        }

        public VMItem GetById(Guid id)
        {
            var entity = unitOfWork.Item.Get(id);
            return Mapper.Map<VMItem>(entity);
        }

        public List<VMItem> GetByCategoryId(Guid id)
        {
            var entities = unitOfWork.Item.Find(t => t.CategoryId == id).OrderBy(t => t.Sequence).ToList();
            return Mapper.Map<List<VMItem>>(entities);
        }

        public List<VMItem> GetBySubCategoryId(Guid id)
        {
            var entities = unitOfWork.Item.Find(t => t.SubCategoryId == id).OrderBy(t => t.Sequence).ToList();
            return Mapper.Map<List<VMItem>>(entities);
        }

        public int Update(VMItem vmEntity)
        {
            var entity = Mapper.Map<Item>(vmEntity);
            unitOfWork.Item.Update(entity);

            return unitOfWork.SaveChanges();
        }
    }
}