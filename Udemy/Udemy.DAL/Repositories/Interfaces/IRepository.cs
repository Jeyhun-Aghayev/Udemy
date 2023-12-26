using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;
using Udemy.CORE.Entities.Base;

namespace Udemy.DAL.Repositories.Interfaces
{
    public interface IRepository<T> where T : BaseAuditableEntity, new()
    {
        DbSet<T> Table { get; }
        Task<IQueryable<T>> GetAllAsync(Expression<Func<T, bool>>? expression = null, params string[] includes);
        Task<IQueryable<T>> RecycleBin(Expression<Func<T, bool>>? expression = null, params string[] includes);

        Task<T> GetById(int id);
        Task Create(T entity);
        void Update(T entity);
        void Delete(int id);
        void DeleteAll();
        void Restore();
        Task<bool> Check(int id);

        void SaveChangesAsync();

    }
}
