using AutoMapper;
using OnlineMenu.Data;
using OnlineMenu.Model;
using OnlineMenu.Service.ViewModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OnlineMenu.Service.Services
{
    public interface IRestaurantService
    {
        VMRestaurant GetById(Guid Id);

        int Create(VMRestaurant entity);

        int Update(VMRestaurant entity);

        List<VMRestaurant> GetAll();
    }

    public class RestaurantService : IRestaurantService
    {
        private IUnitOfWork unitOfWork;

        public RestaurantService(IUnitOfWork unitOfWork)
        {
            this.unitOfWork = unitOfWork;
        }

        public int Create(VMRestaurant vmEntity)
        {
            var entity = Mapper.Map<Restaurant>(vmEntity);
            entity.Id = Guid.NewGuid();
            entity.CreateDate = DateTime.Now;
            entity.LastModifiedDate = DateTime.Now;

            //Todo: Use the name of the user logged in
            entity.LastModifiedBy = Environment.UserName;
            unitOfWork.Restaurant.Add(entity);
            return unitOfWork.SaveChanges();
        }

        public List<VMRestaurant> GetAll()
        {
            var entities = unitOfWork.Restaurant.GetAll();
            return Mapper.Map<List<VMRestaurant>>(entities);
        }

        public VMRestaurant GetById(Guid Id)
        {
            var entity = unitOfWork.Restaurant.Get(Id);
            return Mapper.Map<VMRestaurant>(entity);
        }

        public int Update(VMRestaurant vmEntity)
        {
            var entity = Mapper.Map<Restaurant>(vmEntity);
            entity.LastModifiedDate = DateTime.Now;
            entity.LastModifiedBy = Environment.UserName;
            unitOfWork.Restaurant.Update(entity);
            return unitOfWork.SaveChanges();
        }
    }
}