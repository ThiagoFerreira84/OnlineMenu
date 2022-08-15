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
    public interface ISubCategoryVsItemService
    {
        VMSubCategoryVsItem GetById(Guid id);

        int Create(VMSubCategoryVsItem entity);

        int Update(VMSubCategoryVsItem entity);

        List<VMSubCategoryVsItem> GetAll();
    }

    public class SubCategoryVsItemService : ISubCategoryVsItemService
    {
        private IUnitOfWork unitOfWork;

        public SubCategoryVsItemService(IUnitOfWork unitOfWork)
        {
            this.unitOfWork = unitOfWork;
        }

        public int Create(VMSubCategoryVsItem vmEntity)
        {
            var entity = Mapper.Map<SubCategoryVsItem>(vmEntity);
            entity.Id = Guid.NewGuid();

            unitOfWork.SubCategoryVsItem.Add(entity);
            return unitOfWork.SaveChanges();
        }

        public List<VMSubCategoryVsItem> GetAll()
        {
            var entities = unitOfWork.SubCategoryVsItem.GetAll();
            return Mapper.Map<List<VMSubCategoryVsItem>>(entities);
        }

        public VMSubCategoryVsItem GetById(Guid id)
        {
            var entity = unitOfWork.SubCategoryVsItem.Get(id);
            return Mapper.Map<VMSubCategoryVsItem>(entity);
        }

        public int Update(VMSubCategoryVsItem vmEntity)
        {
            var entity = Mapper.Map<SubCategoryVsItem>(vmEntity);
            unitOfWork.SubCategoryVsItem.Update(entity);

            return unitOfWork.SaveChanges();
        }
    }
}