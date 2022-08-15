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
    public interface ISubCategoryService
    {
        VMSubCategory GetById(Guid id);

        List<VMSubCategory> GetByCategoryId(Guid id);

        int Create(VMSubCategory entity);

        int Update(VMSubCategory entity);

        List<VMSubCategory> GetAll();
    }

    public class SubCategoryService : ISubCategoryService
    {
        private IUnitOfWork unitOfWork;

        public SubCategoryService(IUnitOfWork unitOfWork)
        {
            this.unitOfWork = unitOfWork;
        }

        public int Create(VMSubCategory vmEntity)
        {
            var entity = Mapper.Map<SubCategory>(vmEntity);
            entity.Id = Guid.NewGuid();

            unitOfWork.SubCategory.Add(entity);
            return unitOfWork.SaveChanges();
        }

        public List<VMSubCategory> GetAll()
        {
            var entities = unitOfWork.SubCategory.GetAll();
            return Mapper.Map<List<VMSubCategory>>(entities);
        }

        public VMSubCategory GetById(Guid id)
        {
            var entity = unitOfWork.SubCategory.Get(id);
            return Mapper.Map<VMSubCategory>(entity);
        }

        public List<VMSubCategory> GetByCategoryId(Guid id)
        {
            var entities = unitOfWork.SubCategory.Find(t => t.CategoryId == id).OrderBy(t => t.Sequence).ToList();
            return Mapper.Map<List<VMSubCategory>>(entities);
        }

        public int Update(VMSubCategory vmEntity)
        {
            var entity = Mapper.Map<SubCategory>(vmEntity);
            unitOfWork.SubCategory.Update(entity);

            return unitOfWork.SaveChanges();
        }
    }
}