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
    public interface ICategoryService
    {
        VMCategory GetById(Guid id);

        List<VMCategory> GetByPageId(Guid id);

        int Create(VMCategory entity);

        int Update(VMCategory entity);

        List<VMCategory> GetAll();
    }

    public class CategoryService : ICategoryService
    {
        private IUnitOfWork unitOfWork;

        public CategoryService(IUnitOfWork unitOfWork)
        {
            this.unitOfWork = unitOfWork;
        }

        public int Create(VMCategory vmEntity)
        {
            var entity = Mapper.Map<Category>(vmEntity);
            entity.Id = Guid.NewGuid();

            unitOfWork.Category.Add(entity);
            return unitOfWork.SaveChanges();
        }

        public List<VMCategory> GetAll()
        {
            var entities = unitOfWork.Category.GetAll();
            return Mapper.Map<List<VMCategory>>(entities);
        }

        public VMCategory GetById(Guid id)
        {
            var entity = unitOfWork.Category.Get(id);
            return Mapper.Map<VMCategory>(entity);
        }

        public List<VMCategory> GetByPageId(Guid id)
        {
            var entities = unitOfWork.Category.Find(t => t.PageId == id).OrderBy(t => t.Sequence).ToList();
            return Mapper.Map<List<VMCategory>>(entities);
        }

        public int Update(VMCategory vmEntity)
        {
            var entity = Mapper.Map<Category>(vmEntity);
            unitOfWork.Category.Update(entity);

            return unitOfWork.SaveChanges();
        }
    }
}