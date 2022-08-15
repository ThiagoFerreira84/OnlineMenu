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
    public interface IOrderService
    {
        VMOrder GetById(Guid id);

        int Create(VMOrder entity);

        int Update(VMOrder entity);

        List<VMOrder> GetAll();
    }

    public class OrderService : IOrderService
    {
        private IUnitOfWork unitOfWork;

        public OrderService(IUnitOfWork unitOfWork)
        {
            this.unitOfWork = unitOfWork;
        }

        public int Create(VMOrder vmEntity)
        {
            var entity = Mapper.Map<Order>(vmEntity);
            entity.Id = Guid.NewGuid();

            unitOfWork.Order.Add(entity);
            return unitOfWork.SaveChanges();
        }

        public List<VMOrder> GetAll()
        {
            var entities = unitOfWork.Order.GetAll();
            return Mapper.Map<List<VMOrder>>(entities);
        }

        public VMOrder GetById(Guid id)
        {
            var entity = unitOfWork.Order.Get(id);
            return Mapper.Map<VMOrder>(entity);
        }

        public int Update(VMOrder vmEntity)
        {
            var entity = Mapper.Map<Order>(vmEntity);
            unitOfWork.Order.Update(entity);

            return unitOfWork.SaveChanges();
        }
    }
}