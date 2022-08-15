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
    public interface ICategoryVsItemService
    {
        VMCategoryVsItem GetById(Guid id);

        int Create(VMCategoryVsItem entity);

        int Update(VMCategoryVsItem entity);

        List<VMCategoryVsItem> GetAll();
    }

    public class CategoryVsItemService : ICategoryVsItemService
    {
        private IUnitOfWork unitOfWork;

        public CategoryVsItemService(IUnitOfWork unitOfWork)
        {
            this.unitOfWork = unitOfWork;
        }

        public int Create(VMCategoryVsItem vmEntity)
        {
            var entity = Mapper.Map<Category>(vmEntity);
            entity.Id = Guid.NewGuid();

            unitOfWork.Category.Add(entity);
            return unitOfWork.SaveChanges();
        }

        public List<VMCategoryVsItem> GetAll()
        {
            var entities = unitOfWork.Category.GetAll();
            return Mapper.Map<List<VMCategoryVsItem>>(entities);
        }

        public VMCategoryVsItem GetById(Guid id)
        {
            var entity = unitOfWork.Category.Get(id);
            return Mapper.Map<VMCategoryVsItem>(entity);
        }

        public int Update(VMCategoryVsItem vmEntity)
        {
            var entity = Mapper.Map<Category>(vmEntity);
            unitOfWork.Category.Update(entity);

            return unitOfWork.SaveChanges();
        }
    }
}