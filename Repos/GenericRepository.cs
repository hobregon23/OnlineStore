using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.ChangeTracking;
using OnlineStore.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Threading.Tasks;

namespace OnlineStore.Repos
{
    public interface IGenericRepository<T> where T : class
    {
        Task<IEnumerable<T>> GetAll();
        Task<T> GetById(int id);
        Task<T> GetById(string id);
        Task<EntityEntry<T>> Add(T entity);
        EntityEntry<T> Remove(T entity);
        EntityEntry<T> Update(T entity);
        IQueryable<T> Where(params Expression<Func<T, bool>>[] predicates);
    }

    public class GenericRepository<T> : IGenericRepository<T> where T : class
    {
        protected readonly ApplicationDbContext _context; // use dependecy injection
        protected readonly UserManager<User> _userManager;
        internal DbSet<T> dbSet;
        private ApplicationDbContext context;

        public GenericRepository(ApplicationDbContext context, UserManager<User> userManager)
        {
            _context = context;
            _userManager = userManager;
            dbSet = context.Set<T>();
        }

        public virtual async Task<IEnumerable<T>> GetAll()
        {
            return await dbSet.ToListAsync();
        }

        public virtual async Task<T> GetById(int id)
        {
            return await dbSet.FindAsync(id);
        }

        public virtual async Task<T> GetById(string id)
        {
            return await dbSet.FindAsync(id);
        }

        public virtual async Task<EntityEntry<T>> Add(T entity)
        {
            return await dbSet.AddAsync(entity);
        }

        public virtual EntityEntry<T> Remove(T entity)
        {
            return dbSet.Remove(entity);
        }

        public virtual EntityEntry<T> Update(T entity) => dbSet.Update(entity);


        public virtual IQueryable<T> Where(params Expression<Func<T, bool>>[] predicates)
        {
            if (predicates != null && predicates.Length > 0)
            {
                IQueryable<T> _query = _context.Set<T>();
                foreach (var p in predicates)
                {
                    if (p != null)
                        _query = _query.Where(p);
                }
                return _query;
            }
            return _context.Set<T>();
        }
    }
}
