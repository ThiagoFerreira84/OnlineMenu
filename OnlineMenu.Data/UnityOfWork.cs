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
        IRepository<Table> Table { get; }
        IRepository<MenuCategory> MenuCategory { get; }
        IRepository<MenuSubCategory> MenuSubCategory { get; }
        IRepository<MenuItem> MenuItem { get; }
        IRepository<Order> Order { get; }
        IRepository<OrderItem> OrderItem { get; }
        IRepository<Subscription> Subscription { get; }
        IRepository<User> User { get; }

        int SaveChanges();
    }

    public class UnitOfWork : IUnitOfWork
    {
        private readonly OnlineMenuEntities _context;
        public IRepository<Country> Country { get; private set; }
        public IRepository<Restaurant> Restaurant { get; private set; }
        public IRepository<Table> Table { get; private set; }
        public IRepository<MenuCategory> MenuCategory { get; private set; }
        public IRepository<MenuSubCategory> MenuSubCategory { get; private set; }
        public IRepository<MenuItem> MenuItem { get; private set; }
        public IRepository<Order> Order { get; private set; }
        public IRepository<OrderItem> OrderItem { get; private set; }
        public IRepository<Subscription> Subscription { get; private set; }
        public IRepository<User> User { get; private set; }

        public UnitOfWork()
        {
            _context = new OnlineMenuEntities();
            Country = new Repository<Country>(_context);
            Restaurant = new Repository<Restaurant>(_context);
            Table = new Repository<Table>(_context);
            MenuCategory = new Repository<MenuCategory>(_context);
            MenuSubCategory = new Repository<MenuSubCategory>(_context);
            MenuItem = new Repository<MenuItem>(_context);
            Order = new Repository<Order>(_context);
            OrderItem = new Repository<OrderItem>(_context);
            Subscription = new Repository<Subscription>(_context);
            User = new Repository<User>(_context);
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