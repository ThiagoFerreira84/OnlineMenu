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
    public interface ICountryService
    {
        VMCountry GetById(Guid id);

        int Create(VMCountry entity);

        int Update(VMCountry entity);

        void Delete(Guid id);

        List<VMCountry> GetAll();
    }

    public class CountryService : ICountryService
    {
        private IUnitOfWork unitOfWork;

        public CountryService(IUnitOfWork unitOfWork)
        {
            this.unitOfWork = unitOfWork;
        }

        public int Create(VMCountry vmEntity)
        {
            var entity = Mapper.Map<Country>(vmEntity);
            entity.Id = Guid.NewGuid();
            unitOfWork.Country.Add(entity);
            return unitOfWork.SaveChanges();
        }

        public List<VMCountry> GetAll()
        {
            //using (var dbContext = new OnlineMenuEntities())
            //{
            //    var entities = dbContext.Countries.Include(x => x.Restaurants).ToList();
            //    var vmEntity = Mapper.Map<List<VMCountry>>(entities);
            //    return vmEntity;
            //}
            var entities = unitOfWork.Country.GetAll();
            return Mapper.Map<List<VMCountry>>(entities);
        }

        public VMCountry GetById(Guid id)
        {
            var entity = unitOfWork.Country.Get(id);
            return Mapper.Map<VMCountry>(entity);
        }

        public int Update(VMCountry vmEntity)
        {
            var entity = Mapper.Map<Country>(vmEntity);
            unitOfWork.Country.Update(entity);
            return unitOfWork.SaveChanges();
        }

        public void Delete(Guid id)
        {
            var entity = Mapper.Map<Country>(GetById(id));
            unitOfWork.Country.Remove(entity);
            return;
        }
    }
}