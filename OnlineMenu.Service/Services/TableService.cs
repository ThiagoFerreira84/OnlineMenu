using AutoMapper;
using OnlineMenu.Data;
using OnlineMenu.Model;
using OnlineMenu.Service.ViewModels;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OnlineMenu.Service.Services
{
    public interface ITableService
    {
        VMTable GetById(Guid Id);

        int Create(VMTable entity);

        int Update(VMTable entity);

        void Delete(Guid Id);

        List<VMTable> GetAll();
    }

    public class TableService : ITableService
    {
        private IUnitOfWork unitOfWork;

        public TableService(IUnitOfWork unitOfWork)
        {
            this.unitOfWork = unitOfWork;
        }

        public int Create(VMTable vmEntity)
        {
            var entity = Mapper.Map<Table>(vmEntity);
            entity.Id = Guid.NewGuid();
            unitOfWork.Table.Add(entity);
            return unitOfWork.SaveChanges();
        }

        public List<VMTable> GetAll()
        {
            var entities = unitOfWork.Table.GetAll();
            return Mapper.Map<List<VMTable>>(entities);
        }

        public VMTable GetById(Guid Id)
        {
            var entity = unitOfWork.Table.Get(Id);
            return Mapper.Map<VMTable>(entity);
        }

        public int Update(VMTable vmEntity)
        {
            var entity = Mapper.Map<Table>(vmEntity);
            unitOfWork.Table.Update(entity);
            return unitOfWork.SaveChanges();
        }

        public void Delete(Guid Id)
        {
            var entity = Mapper.Map<Table>(GetById(Id));
            unitOfWork.Table.Remove(entity);
            return;
        }
    }
}