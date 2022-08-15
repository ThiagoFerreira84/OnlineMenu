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
    public interface IUserVsRestaurantService
    {
        VMUserVsRestaurant GetById(Guid id);

        int Create(VMUserVsRestaurant entity);

        int Update(VMUserVsRestaurant entity);

        List<VMUserVsRestaurant> GetAll();
    }

    public class UserVsRestaurantService : IUserVsRestaurantService
    {
        private IUnitOfWork unitOfWork;

        public UserVsRestaurantService(IUnitOfWork unitOfWork)
        {
            this.unitOfWork = unitOfWork;
        }

        public int Create(VMUserVsRestaurant vmEntity)
        {
            var entity = Mapper.Map<UserVsRestaurant>(vmEntity);
            entity.Id = Guid.NewGuid();

            unitOfWork.UserVsRestaurant.Add(entity);
            return unitOfWork.SaveChanges();
        }

        public List<VMUserVsRestaurant> GetAll()
        {
            var entities = unitOfWork.UserVsRestaurant.GetAll();
            return Mapper.Map<List<VMUserVsRestaurant>>(entities);
        }

        public VMUserVsRestaurant GetById(Guid id)
        {
            var entity = unitOfWork.UserVsRestaurant.Get(id);
            return Mapper.Map<VMUserVsRestaurant>(entity);
        }

        public int Update(VMUserVsRestaurant vmEntity)
        {
            var entity = Mapper.Map<UserVsRestaurant>(vmEntity);
            unitOfWork.UserVsRestaurant.Update(entity);

            return unitOfWork.SaveChanges();
        }
    }
}