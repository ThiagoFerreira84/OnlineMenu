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
        VMTable GetById(Guid id);

        int AddOrRemove(VMTable entity);

        int Update(VMTable entity);

        void Delete(Guid id);

        List<VMTable> GetAll();

        List<VMTable> GetByRestaurantId(Guid guid);
    }

    public class TableService : ITableService
    {
        private IUnitOfWork unitOfWork;

        public TableService(IUnitOfWork unitOfWork)
        {
            this.unitOfWork = unitOfWork;
        }

        public int AddOrRemove(VMTable vmEntity)
        {
            var restaurantId = vmEntity.RestaurantId;
            var numberOfTables = vmEntity.Number;
            var allTables = GetByRestaurantId(restaurantId);

            if (allTables.Count > 0)
            {
                if (numberOfTables > allTables.Count)
                {
                    for (int i = 0; i < numberOfTables; i++)
                    {
                        if (allTables.Exists(t => t.Number == i + 1))
                        {
                            continue;
                        }
                        var table = new Table()
                        {
                            Id = Guid.NewGuid(),
                            RestaurantId = restaurantId,
                            Number = i + 1,
                            Status = EnumTablesStatus.Available
                        };
                        unitOfWork.Table.Add(table);
                    }
                }
                else
                {
                    var itemsToDelete = Mapper.Map<List<Table>>(allTables.Where(t => t.Number > numberOfTables).ToList());
                    foreach (var item in itemsToDelete)
                    {
                        unitOfWork.Table.Remove(item);
                    }
                }
            }
            else
            {
                //Just Add
                for (int i = 0; i < numberOfTables; i++)
                {
                    var table = new Table()
                    {
                        Id = Guid.NewGuid(),
                        RestaurantId = restaurantId,
                        Number = i + 1,
                        Status = EnumTablesStatus.Available
                    };
                    unitOfWork.Table.Add(table);
                }
            }

            return unitOfWork.SaveChanges();
        }

        public List<VMTable> GetAll()
        {
            var entities = unitOfWork.Table.GetAll();
            return Mapper.Map<List<VMTable>>(entities);
        }

        public VMTable GetById(Guid id)
        {
            var entity = unitOfWork.Table.Get(id);
            return Mapper.Map<VMTable>(entity);
        }

        public int Update(VMTable vmEntity)
        {
            var entity = Mapper.Map<Table>(vmEntity);
            unitOfWork.Table.Update(entity);
            return unitOfWork.SaveChanges();
        }

        public void Delete(Guid id)
        {
            var entity = Mapper.Map<Table>(GetById(id));
            unitOfWork.Table.Remove(entity);
            return;
        }

        public List<VMTable> GetByRestaurantId(Guid guid)
        {
            var entities = unitOfWork.Table.Find(t => t.RestaurantId == guid).OrderBy(t => t.Number).ToList();
            return Mapper.Map<List<VMTable>>(entities);
        }
    }
}