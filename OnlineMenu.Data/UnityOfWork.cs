﻿using OnlineMenu.Model;
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
        IRepository<Category> Category { get; }
        IRepository<Item> Item { get; }
        IRepository<Order> Order { get; }
        IRepository<OrderItem> OrderItem { get; }
        IRepository<Subscription> Subscription { get; }
        IRepository<User> User { get; }
        IRepository<UserVsRestaurant> UserVsRestaurant { get; }
        IRepository<Page> Page { get; }

        int SaveChanges();
    }

    public class UnitOfWork : IUnitOfWork
    {
        private readonly OnlineMenuEntities _context;
        public IRepository<Country> Country { get; private set; }
        public IRepository<Restaurant> Restaurant { get; private set; }
        public IRepository<Table> Table { get; private set; }
        public IRepository<Category> Category { get; private set; }
        public IRepository<Item> Item { get; private set; }
        public IRepository<Order> Order { get; private set; }
        public IRepository<OrderItem> OrderItem { get; private set; }
        public IRepository<Subscription> Subscription { get; private set; }
        public IRepository<User> User { get; private set; }
        public IRepository<UserVsRestaurant> UserVsRestaurant { get; private set; }
        public IRepository<Page> Page { get; private set; }

        public UnitOfWork()
        {
            _context = new OnlineMenuEntities();
            Country = new Repository<Country>(_context);
            Restaurant = new Repository<Restaurant>(_context);
            Table = new Repository<Table>(_context);
            Category = new Repository<Category>(_context);
            Item = new Repository<Item>(_context);
            Order = new Repository<Order>(_context);
            OrderItem = new Repository<OrderItem>(_context);
            Subscription = new Repository<Subscription>(_context);
            User = new Repository<User>(_context);
            UserVsRestaurant = new Repository<UserVsRestaurant>(_context);
            Page = new Repository<Page>(_context);
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