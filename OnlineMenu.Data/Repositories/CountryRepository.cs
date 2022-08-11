using OnlineMenu.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Threading.Tasks;

namespace OnlineMenu.Data.Repositories
{
    public interface ICountryRepository : IRepository<Country>
    {
        List<Country> GetAllList();
    }

    public class CountryRepository : Repository<Country>, ICountryRepository
    {
        public CountryRepository(OnlineMenuEntities context) : base(context)
        {
        }

        public OnlineMenuEntities Entities
        {
            get { return context as OnlineMenuEntities; }
        }

        public List<Country> GetAllList()
        {
            return Entities.Countries.ToList();
        }
    }
}