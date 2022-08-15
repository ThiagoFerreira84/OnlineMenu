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
    public interface ISubscriptionService
    {
        VMSubscription GetById(Guid id);

        int Create(VMSubscription entity);

        int Update(VMSubscription entity);

        List<VMSubscription> GetAll();
    }

    public class SubscriptionService : ISubscriptionService
    {
        private IUnitOfWork unitOfWork;

        public SubscriptionService(IUnitOfWork unitOfWork)
        {
            this.unitOfWork = unitOfWork;
        }

        public int Create(VMSubscription vmEntity)
        {
            var entity = Mapper.Map<Subscription>(vmEntity);
            entity.Id = Guid.NewGuid();

            unitOfWork.Subscription.Add(entity);
            return unitOfWork.SaveChanges();
        }

        public List<VMSubscription> GetAll()
        {
            var entities = unitOfWork.Subscription.GetAll();
            return Mapper.Map<List<VMSubscription>>(entities);
        }

        public VMSubscription GetById(Guid id)
        {
            var entity = unitOfWork.Subscription.Get(id);
            return Mapper.Map<VMSubscription>(entity);
        }

        public int Update(VMSubscription vmEntity)
        {
            var entity = Mapper.Map<Subscription>(vmEntity);
            unitOfWork.Subscription.Update(entity);

            return unitOfWork.SaveChanges();
        }
    }
}