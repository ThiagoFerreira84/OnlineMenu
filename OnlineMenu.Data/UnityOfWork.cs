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
        IRepository<Restaurant> Restaurant { get; }

        int Complete();
    }

    public class UnitOfWork : IUnitOfWork
    {
        private readonly OnlineMenuEntities _context;

        public IRepository<Restaurant> Restaurant { get; private set; }

        public UnitOfWork()
        {
            _context = new OnlineMenuEntities();

            Restaurant = new Repository<Restaurant>(_context);
        }

        public int Complete()
        {
            return _context.SaveChanges();
        }

        public void Dispose()
        {
            _context.Dispose();
        }
    }
}