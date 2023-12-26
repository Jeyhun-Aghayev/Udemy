using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;
using Udemy.CORE.Entities.Base;
using Udemy.DAL.Context;
using Udemy.DAL.Repositories.Interfaces;

namespace Udemy.DAL.Repositories.Implementations
{
    public class Repository<T> : IRepository<T> where T : BaseAuditableEntity, new()
    {
        private readonly AppDbContext _context;

        public Repository(AppDbContext context)
        {
            _context = context;
        }

        public DbSet<T> Table => _context.Set<T>();

        public async Task<bool> Check(int id)
        {
            return await Table.AnyAsync(a=>a.Id == id);
        }

        public async Task Create(T entity)
        {
            await Table.AddAsync(entity);
        }

        public void Delete(int id)
        {
            var category = Table.FirstOrDefault(b => b.Id == id);
            if (category != null)
            {
                category.IsDeleted = true;
            }
        }
        public void DeleteAll()
        {
            if (Table != null)
                foreach (var item in Table)
                {
                    item.IsDeleted = true;
                }
        }
        public async Task<IQueryable<T>> GetAllAsync(Expression<Func<T, bool>>? expression = null, params string[] includes)
        {
            IQueryable<T> query = Table.Where(b => !b.IsDeleted);
            if (includes is not null)
            {
                for (int i = 0; i < includes.Length; i++)
                {
                    query = query.Include(includes[i]);
                }
            }
            if (expression is not null)
            {
                query = query.Where(expression);
            }
            return query;
        }

        public async Task<T> GetById(int id)
        {
            return await Table.AsNoTracking().FirstOrDefaultAsync(b => b.Id == id);
        }

        public async Task<IQueryable<T>> RecycleBin(Expression<Func<T, bool>>? expression = null, params string[] includes)
        {
            IQueryable<T> query = Table.Where(b => b.IsDeleted);
            if (includes is not null)
            {
                for (int i = 0; i < includes.Length; i++)
                {
                    query = query.Include(includes[i]);
                }
            }
            if (expression is not null)
            {
                query = query.Where(expression);
            }
            return query;
        }

        public void Restore()
        {
            if (Table != null) foreach (var item in Table)
                {
                    item.IsDeleted = false;
                }

        }

        public void SaveChangesAsync()
        {
            _context.SaveChanges();
        }

        public void Update(T entity)
        {
            Table.Update(entity);

        }
    }
}
