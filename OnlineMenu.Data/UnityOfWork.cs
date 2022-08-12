using OnlineMenu.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OnlineMenu.Data
{
    public interface IUnitOfWork : IDisposable
    {
        IRepository<Country> Country { get; }
        IRepository<Restaurant> Restaurant { get; }

        int SaveChanges();
    }

    public class UnitOfWork : IUnitOfWork
    {
        private readonly OnlineMenuEntities _context;

        public IRepository<Country> Country { get; private set; }
        public IRepository<Restaurant> Restaurant { get; private set; }

        public UnitOfWork()
        {
            _context = new OnlineMenuEntities();

            Country = new Repository<Country>(_context);
            Restaurant = new Repository<Restaurant>(_context);
        }

        public int SaveChanges()
        {
            return _context.SaveChanges();
        }

        public void Dispose()
        {
            _context.Dispose();
        }
    }
}