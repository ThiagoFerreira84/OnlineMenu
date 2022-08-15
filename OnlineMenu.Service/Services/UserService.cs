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
    public interface IUserService
    {
        VMUser GetById(Guid id);

        int Create(VMUser entity);

        int Update(VMUser entity);

        List<VMUser> GetAll();
    }

    public class UserService : IUserService
    {
        private IUnitOfWork unitOfWork;

        public UserService(IUnitOfWork unitOfWork)
        {
            this.unitOfWork = unitOfWork;
        }

        public int Create(VMUser vmEntity)
        {
            var entity = Mapper.Map<User>(vmEntity);
            entity.Id = Guid.NewGuid();

            unitOfWork.User.Add(entity);
            return unitOfWork.SaveChanges();
        }

        public List<VMUser> GetAll()
        {
            var entities = unitOfWork.User.GetAll();
            return Mapper.Map<List<VMUser>>(entities);
        }

        public VMUser GetById(Guid id)
        {
            var entity = unitOfWork.User.Get(id);
            return Mapper.Map<VMUser>(entity);
        }

        public int Update(VMUser vmEntity)
        {
            var entity = Mapper.Map<User>(vmEntity);
            unitOfWork.User.Update(entity);

            return unitOfWork.SaveChanges();
        }
    }
}