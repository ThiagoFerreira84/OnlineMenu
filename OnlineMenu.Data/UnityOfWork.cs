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
        //ITypeRepository Type { get; }
        
        int Complete();
    }

    public class UnitOfWork : IUnitOfWork
    {
        private readonly OnlineMenuEntities _context;

        //public ITypeRepository Type { get; private set; }
       
        public UnitOfWork()
        {
            _context = new OnlineMenuEntities();
            
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
