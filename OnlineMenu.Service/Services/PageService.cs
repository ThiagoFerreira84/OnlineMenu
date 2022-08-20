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
    public interface IPageService
    {
        VMPage GetById(Guid id);

        List<VMPage> GetByRestaurantId(Guid id);

        int Create(VMPage entity);

        int Update(VMPage entity);

        List<VMPage> GetAll();
    }

    public class PageService : IPageService
    {
        private IUnitOfWork unitOfWork;

        public PageService(IUnitOfWork unitOfWork)
        {
            this.unitOfWork = unitOfWork;
        }

        public int Create(VMPage vmEntity)
        {
            var entity = Mapper.Map<Page>(vmEntity);
            entity.Id = Guid.NewGuid();

            unitOfWork.Page.Add(entity);
            return unitOfWork.SaveChanges();
        }

        public List<VMPage> GetAll()
        {
            var entities = unitOfWork.Page.GetAll();
            return Mapper.Map<List<VMPage>>(entities);
        }

        public VMPage GetById(Guid id)
        {
            var entity = unitOfWork.Page.Get(id);
            return Mapper.Map<VMPage>(entity);
        }

        public List<VMPage> GetByRestaurantId(Guid id)
        {
            var entities = unitOfWork.Page.Find(t => t.RestaurantId == id).OrderBy(t => t.Sequence).ToList();
            return Mapper.Map<List<VMPage>>(entities);
        }

        public int Update(VMPage vmEntity)
        {
            var entity = Mapper.Map<Page>(vmEntity);
            unitOfWork.Page.Update(entity);

            return unitOfWork.SaveChanges();
        }
    }
}