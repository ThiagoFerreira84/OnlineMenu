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
    public interface IOrderItemService
    {
        VMOrderItem GetById(Guid id);

        int Create(VMOrderItem entity);

        int Update(VMOrderItem entity);

        List<VMOrderItem> GetAll();
    }

    public class OrderItemService : IOrderItemService
    {
        private IUnitOfWork unitOfWork;

        public OrderItemService(IUnitOfWork unitOfWork)
        {
            this.unitOfWork = unitOfWork;
        }

        public int Create(VMOrderItem vmEntity)
        {
            var entity = Mapper.Map<OrderItem>(vmEntity);
            entity.Id = Guid.NewGuid();

            unitOfWork.OrderItem.Add(entity);
            return unitOfWork.SaveChanges();
        }

        public List<VMOrderItem> GetAll()
        {
            var entities = unitOfWork.OrderItem.GetAll();
            return Mapper.Map<List<VMOrderItem>>(entities);
        }

        public VMOrderItem GetById(Guid id)
        {
            var entity = unitOfWork.OrderItem.Get(id);
            return Mapper.Map<VMOrderItem>(entity);
        }

        public int Update(VMOrderItem vmEntity)
        {
            var entity = Mapper.Map<OrderItem>(vmEntity);
            unitOfWork.OrderItem.Update(entity);

            return unitOfWork.SaveChanges();
        }
    }
}